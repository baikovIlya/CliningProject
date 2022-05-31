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
                        EmployeeDTO crnt = result[employee.Id];
                        if (crnt.Services == null && crnt.WorkAreas == null)
                        {
                            crnt.Services = new Dictionary<int, ServiceDTO>();
                            crnt.WorkAreas = new Dictionary<int, WorkAreaDTO>();
                        }
                        if (service != null && !crnt.Services!.ContainsKey(service.Id))
                        {
                            crnt.Services.Add(service.Id, service);
                        }
                        if (workArea != null && !crnt.WorkAreas!.ContainsKey(workArea.Id))
                        {
                            crnt.WorkAreas.Add(workArea.Id, workArea);
                        }
                        return crnt;
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

                connection.Query<EmployeeDTO, OrderDTO, ClientDTO, AddressDTO, WorkAreaDTO, ServiceDTO, EmployeeDTO>(
                    StoredProcedures.GetOrderHistoryOfTheEmployeeById,
                    (employee, order, client, address, workArea, service) =>
                    {
                        if (!result.ContainsKey(employee.Id))
                        {
                            result.Add(employee.Id, employee);
                        }
                        EmployeeDTO crnt = result[employee.Id];
                        if (crnt.Orders == null )
                        {
                            crnt.Orders = new Dictionary<int, OrderDTO>();
                        }
                        if (order != null && !crnt.Orders!.ContainsKey(order.Id))
                        {
                            crnt.Orders!.Add(order.Id, order);
                        }
                        OrderDTO employeeOrder = crnt.Orders[order!.Id];
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
                        }
                        return crnt;
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
                        EmployeeDTO crnt = result[employee.Id];
                        if (crnt.Services == null && crnt.WorkAreas == null && crnt.WorkTime == null)
                        {
                            crnt.Services = new Dictionary<int, ServiceDTO>();
                            crnt.WorkAreas = new Dictionary<int, WorkAreaDTO>();
                            crnt.WorkTime = new WorkTimeDTO();
                        }
                        if (service != null)
                        {
                            crnt.Services!.Add(service.Id, service);
                        }
                        if (workArea != null)
                        {
                            crnt.WorkAreas!.Add(workArea.Id, workArea);
                        }
                        if (workTime != null)
                        {
                            crnt.WorkTime = workTime;
                        }
                        return crnt;
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
