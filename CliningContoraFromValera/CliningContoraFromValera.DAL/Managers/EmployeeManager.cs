using Dapper;
using System.Data.SqlClient;
using CliningContoraFromValera.DAL.Dtos;

namespace CliningContoraFromValera.DAL.Managers
{
    public class EmployeeManager
    {
        public List<EmployeeDto> GetAllEmployees()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.Query<EmployeeDto>(
                    StoredProcedures.Employee_GetAll,
                    commandType: System.Data.CommandType.StoredProcedure)
                    .ToList();
            }
        }

        public EmployeeDto GetEmployeeByID(int employeeId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<EmployeeDto>(
                    StoredProcedures.Employee_GetById,
                    param: new { id = employeeId },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void AddEmployee(EmployeeDto newEmployee)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<EmployeeDto>(
                    StoredProcedures.Employee_Add,
                    param: new
                    {
                        newEmployee.FirstName,
                        newEmployee.LastName,
                        newEmployee.Phone
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void UpdateEmployeeById(EmployeeDto newEmployee)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<EmployeeDto>(
                    StoredProcedures.Employee_UpdateById,
                    param: new
                    {
                        newEmployee.Id,
                        newEmployee.FirstName,
                        newEmployee.LastName,
                        newEmployee.Phone
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteEmployeeById(int employeeId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<EmployeeDto>(
                    StoredProcedures.Employee_DeleteById,
                    param: new { id = employeeId },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
        public void DeleteEmployeesOrder(int employeeId, int orderId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<EmployeeDto>(
                    StoredProcedures.Employee_Order_DeleteByValue,
                    param: new { EmployeeId = employeeId, OrderId = orderId },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteEmployeesWorkArea(int employeeId, int workAreaId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<EmployeeDto>(
                    StoredProcedures.Employee_WorkArea_DeleteByValue,
                    param: new { EmployeeId = employeeId, OrderId = workAreaId },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
        public void DeleteEmployeesService(int employeeId, int serviceId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<EmployeeDto>(
                    StoredProcedures.Employee_Service_DeleteByValue,
                    param: new { EmployeeId = employeeId, OrderId = serviceId },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public EmployeeDto GetAllEmployeesInfoById(int employeeId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                EmployeeDto result = new EmployeeDto();
                List<int> serviceId = new List<int>();
                List<int>  workAreaId = new List<int>();
                connection.Query<EmployeeDto, ServiceDto, WorkAreaDto, EmployeeDto>(
                    StoredProcedures.GetAllEmployeesInfoById,
                    (employee, service, workArea) => {
                        if (employee != null && result.Id != employee.Id)
                        {
                            result = employee;
                        }
                        if (result.Services == null && result.WorkAreas == null)
                        {
                            result.Services = new List<ServiceDto>();
                            result.WorkAreas = new List<WorkAreaDto>();
                        }
                        if (service != null && !serviceId.Contains(service.Id))
                        {
                            serviceId.Add(service.Id);
                            result.Services!.Add(service);
                        }
                        if (workArea != null && !workAreaId.Contains(workArea.Id))
                        {
                            workAreaId.Add(workArea.Id);
                            result.WorkAreas!.Add(workArea);
                        }
                        return result;
                    },
                    param: new { id = employeeId },
                    commandType: System.Data.CommandType.StoredProcedure,
                    splitOn: "Id"
                );
                return result;
            }
        }

        public EmployeeDto GetOrderHistoryOfTheEmployeeById(int employeeId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();
                EmployeeDto result = new EmployeeDto();
                List<int> orderId = new List<int>();
                List<int> serviceId = new List<int>();
                connection.Query<EmployeeDto, OrderDto, ClientDto, AddressDto, WorkAreaDto, ServiceDto, ServiceOrderDto, EmployeeDto>(
                    StoredProcedures.GetOrderHistoryOfTheEmployeeById,
                    (employee, order, client, address, workArea, service, serviceOrder) =>
                    {
                        if (employee != null && result.Id != employee.Id)
                        {
                            result = employee;
                        }
                        if (result.Orders == null)
                        {
                            result.Orders = new List<OrderDto>();
                        }
                        if (order != null && !orderId.Contains(order.Id))
                        {
                            orderId.Add(order.Id);
                            result.Orders!.Add(order);
                            serviceId.Clear();
                        }
                        for (int i = 0; i <= result.Orders.Count-1; i++)
                        {
                            if (order != null && result.Orders[i].Id == order.Id)
                            {
                                OrderDto employeeOrder = result.Orders[i];
                                if (employeeOrder.Services == null)
                                {
                                    employeeOrder.Services = new List<ServiceDto>();
                                }
                                if (order != null && client != null && employeeOrder.Client == null)
                                {
                                    employeeOrder.Client = client;
                                }
                                if (order != null && address != null && employeeOrder.Address == null)
                                {
                                    employeeOrder.Address = address;
                                }
                                if (order != null && address != null && workArea != null
                                && employeeOrder.Address!.WorkArea == null)
                                {
                                    employeeOrder.Address!.WorkArea = workArea;
                                }
                                if (service != null && !serviceId.Contains(service.Id))
                                {
                                    serviceId.Add(service.Id);
                                    employeeOrder.Services!.Add(service);
                                    for (int j = 0; j <= employeeOrder.Services.Count-1; j++)
                                    {
                                        ServiceDto crntServiceOrder = employeeOrder.Services[j];
                                        if (crntServiceOrder.ServiceOrder == null)
                                        {
                                            crntServiceOrder.ServiceOrder = new ServiceOrderDto();
                                        }
                                        if (serviceOrder.OrderId == employeeOrder.Id
                                        && serviceOrder.ServiceId == crntServiceOrder.Id)
                                        {
                                            crntServiceOrder.ServiceOrder = serviceOrder;
                                        }
                                    }
                                }
                            }
                        }
                        return result;
                    },
                    param: new { id = employeeId },
                    commandType: System.Data.CommandType.StoredProcedure,
                    splitOn: "Id"
                );
                return result;
            }
        }

        public List<EmployeeDto> GetEmployyesAvailableForOrder(DateTime date, int serviceId, int workAreaId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();
                Dictionary<int, EmployeeDto> result = new Dictionary<int, EmployeeDto>();
                connection.Query<EmployeeDto, WorkTimeDto, EmployeeDto>(
                    StoredProcedures.GetEmployyesAvailableForOrder,
                    (employee, workTime) =>
                    {
                        if (!result.ContainsKey(employee.Id))
                        {
                            result.Add(employee.Id, employee);
                        }
                        EmployeeDto crntEmployee = result[employee.Id];
                        if (crntEmployee.WorkTime == null)
                        {
                            crntEmployee.WorkTime = new WorkTimeDto();
                        }
                        if (workTime != null)
                        {
                            crntEmployee.WorkTime = workTime;
                        }
                        return crntEmployee;
                    },
                    param: new { date = date, serviceId = serviceId, workAreaId = workAreaId },
                    commandType: System.Data.CommandType.StoredProcedure,
                    splitOn: "Id"
                );
                return result.Values.ToList();
            }
        }
    }
}
