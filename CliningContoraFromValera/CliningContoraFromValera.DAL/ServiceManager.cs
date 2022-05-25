using CliningContoraFromValera.DAL;
using Dapper;
using System.Data.SqlClient;
using CliningContoraFromValera.DAL.DTOs;

namespace CliningContoraFromValera.DAL
{
    public class ServiceManager
    {
        public string connectionString = @"Server=.;Database=CliningContoraFromValera.DB;Trusted_Connection=True;";

        public List<ServiceDTO> GetAllServices()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.Query<ServiceDTO>(
                    StoredProcedures.Service_GetAll,
                    commandType: System.Data.CommandType.StoredProcedure)
                    .ToList();
            }
        }
    }
}
