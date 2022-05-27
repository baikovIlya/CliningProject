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

        public EmployeeDTO GetEmployeeByID(int id)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<EmployeeDTO>(
                    StoredProcedures.Employee_GetById,
                    param: new { id = id },
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

        public void DeleteEmployeeById(EmployeeDTO newEmployee)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<EmployeeDTO>(
                    StoredProcedures.Employee_DeleteById,
                    param: new { newEmployee.Id },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
