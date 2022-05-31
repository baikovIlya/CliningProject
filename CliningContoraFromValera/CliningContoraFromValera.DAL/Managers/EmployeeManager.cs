using Dapper;
using System.Data.SqlClient;

namespace CliningContoraFromValera.DAL
{
    public class EmployeeManager
    {
        public List<EmployeeDTO> GetAllEmployees()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.Query<EmployeeDTO>(
                    StoredProcedures.Employee_GetAll,
                    commandType: System.Data.CommandType.StoredProcedure)
                    .ToList();
            }
        }

        public EmployeeDTO GetEmployeeByID(int employeeId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<EmployeeDTO>(
                    StoredProcedures.Employee_GetById,
                    param: new { id = employeeId },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void AddEmployee(EmployeeDTO newEmployee)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<EmployeeDTO>(
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

        public void UpdateEmployeeById(EmployeeDTO newEmployee)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<EmployeeDTO>(
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

                connection.QuerySingleOrDefault<EmployeeDTO>(
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

                connection.QuerySingleOrDefault<EmployeeDTO>(
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

                connection.QuerySingleOrDefault<EmployeeDTO>(
                    StoredProcedures.Employee_WorkArea_DeleteByValue,
                    param: new { EmployeeId = employeeId, OrderId = workAreaId },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public EmployeeDTO GetAllEmployeesInfoById(int employeeId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                Dictionary<int, EmployeeDTO> result = new Dictionary<int, EmployeeDTO>();

                connection.Query<EmployeeDTO, ServiceDTO, WorkAreaDTO, EmployeeDTO>(
                    StoredProcedures.GetAllEmployeesInfoById,
                    (employee, service, workArea) => {
                        if (!result.ContainsKey(employee.Id))
                        {
                            result.Add(employee.Id, employee);
                        }
                        EmployeeDTO crntEmployee = result[employee.Id];
                        if (crntEmployee.Services == null && crntEmployee.WorkAreas == null)
                        {
                            crntEmployee.Services = new Dictionary<int, ServiceDTO>();
                            crntEmployee.WorkAreas = new Dictionary<int, WorkAreaDTO>();
                        }
                        if (service != null && !crntEmployee.Services!.ContainsKey(service.Id))
                        {
                            crntEmployee.Services.Add(service.Id, service);
                        }
                        if (workArea != null && !crntEmployee.WorkAreas!.ContainsKey(workArea.Id))
                        {
                            crntEmployee.WorkAreas.Add(workArea.Id, workArea);
                        }
                        return crntEmployee;
                    },
                    param: new { id = employeeId },
                    commandType: System.Data.CommandType.StoredProcedure,
                    splitOn: "Id"
                );
                return result[employeeId];
            }
        }

        public EmployeeDTO GetOrderHistoryOfTheEmployeeById(int employeeId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                Dictionary<int, EmployeeDTO> result = new Dictionary<int, EmployeeDTO>();

                connection.Query<EmployeeDTO, OrderDTO, ClientDTO, AddressDTO, WorkAreaDTO, ServiceDTO, ServiceOrderDTO, EmployeeDTO>(
                    StoredProcedures.GetOrderHistoryOfTheEmployeeById,
                    (employee, order, client, address, workArea, service, serviceOrder) =>
                    {
                        if (!result.ContainsKey(employee.Id))
                        {
                            result.Add(employee.Id, employee);
                        }
                        EmployeeDTO crntEmployee = result[employee.Id];
                        if (crntEmployee.Orders == null )
                        {
                            crntEmployee.Orders = new Dictionary<int, OrderDTO>();
                        }
                        if (order != null && !crntEmployee.Orders!.ContainsKey(order.Id))
                        {
                            crntEmployee.Orders!.Add(order.Id, order);
                        }
                        OrderDTO employeeOrder = crntEmployee.Orders[order!.Id];
                        if (employeeOrder.Services == null)
                        {
                            employeeOrder.Services = new Dictionary<int, ServiceDTO>();
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
                        if (order != null && !employeeOrder.Services!.ContainsKey(service.Id))
                        {
                            employeeOrder.Services!.Add(service.Id, service);
                            ServiceDTO crntServiceOrder = employeeOrder.Services[service.Id];
                            if (crntServiceOrder.ServiceOrder == null)
                            {
                                crntServiceOrder.ServiceOrder = new ServiceOrderDTO();
                            }
                            if(serviceOrder != null && serviceOrder.OrderId == employeeOrder.Id
                            && serviceOrder.ServiceId == crntServiceOrder.Id)
                            {
                                crntServiceOrder.ServiceOrder = serviceOrder;
                            }
                        }
                        return crntEmployee;
                    },
                    param: new { id = employeeId },
                    commandType: System.Data.CommandType.StoredProcedure,
                    splitOn: "Id"
                );
                return result[employeeId];
            }
        }

        public List<EmployeeDTO> GetEmployyesAvailableForOrder(DateTime date, int serviceId, int workAreaId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                Dictionary<int, EmployeeDTO> result = new Dictionary<int, EmployeeDTO>();

                connection.Query<EmployeeDTO, WorkTimeDTO, ServiceDTO, WorkAreaDTO, EmployeeDTO>(
                    StoredProcedures.GetEmployyesAvailableForOrder,
                    (employee, workTime, service, workArea) => {
                        if (!result.ContainsKey(employee.Id))
                        {
                            result.Add(employee.Id, employee);
                        }
                        EmployeeDTO crntEmployee = result[employee.Id];
                        if (crntEmployee.Services == null && crntEmployee.WorkAreas == null && crntEmployee.WorkTime == null)
                        {
                            crntEmployee.Services = new Dictionary<int, ServiceDTO>();
                            crntEmployee.WorkAreas = new Dictionary<int, WorkAreaDTO>();
                            crntEmployee.WorkTime = new WorkTimeDTO();
                        }
                        if (service != null)
                        {
                            crntEmployee.Services!.Add(service.Id, service);
                        }
                        if (workArea != null)
                        {
                            crntEmployee.WorkAreas!.Add(workArea.Id, workArea);
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
