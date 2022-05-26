using Dapper;
using System.Data.SqlClient;

namespace CliningContoraFromValera.DAL
{
    public class OrderManager
    {
        public List<OrderDTO> GetAllOrders()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.Query<OrderDTO>(
                    StoredProcedures.Order_GetAll, 
                    commandType: System.Data.CommandType.StoredProcedure)
                    .ToList();
            }
        }

        public OrderDTO GetOrderById(int id)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<OrderDTO>(
                    StoredProcedures.Order_GetById,
                    param: new {Id = id},
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void AddOrder(DateOnly date, TimeOnly startTime, TimeOnly estimatedEndTime, 
            TimeOnly endTime, decimal summOfOrder, string status, int countOfEmployees, bool isCommercial,
            int clientId, int addressId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<OrderDTO>(
                    StoredProcedures.Order_Add,
                    param: new
                    {
                        Date = date,
                        StartTime = startTime,
                        EstimatedEndTime = estimatedEndTime,
                        EndTime = endTime,
                        SummOfOrder = summOfOrder,
                        Status = status,
                        CountOfEmployees = countOfEmployees,
                        IsCommercial = isCommercial,
                        ClientId = clientId,
                        AddressId = addressId
                    },
                    commandType: System.Data.CommandType.StoredProcedure);          
            }
        }

        public void UpdateOrderById(int id, DateOnly date, TimeOnly startTime, TimeOnly estimatedEndTime,
            TimeOnly endTime, decimal summOfOrder, string status, int countOfEmployees, bool isCommercial,
            int clientId, int addressId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<OrderDTO>(
                    StoredProcedures.Order_UpdateById,
                    param: new
                    {
                        Id = id,
                        Date = date,
                        StartTime = startTime,
                        EstimatedEndTime = estimatedEndTime,
                        EndTime = endTime,
                        SummOfOrder = summOfOrder,
                        Status = status,
                        CountOfEmployees = countOfEmployees,
                        IsCommercial = isCommercial,
                        ClientId = clientId,
                        AddressId = addressId
                    },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void DeleteOrderById(int id)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<OrderDTO>(
                    StoredProcedures.Order_DeleteById,
                    param: new { Id = id },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
