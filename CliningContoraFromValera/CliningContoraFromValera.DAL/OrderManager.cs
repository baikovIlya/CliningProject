using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace CliningContoraFromValera.DAL
{
    public class OrderManager
    {
        public string connectionString = @"Server=.;Database=CliningContoraFromValera.DB;Trusted_Connection=True;";

        public List<OrderDTO> GetAllOrders()
        {
            using (var connection = new SqlConnection(connectionString))
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
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return connection.QuerySingle<OrderDTO>(
                    StoredProcedures.Order_GetById,
                    param: new {Id = id},
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void AddOrder(int id, string date, TimeOnly startTime, TimeOnly estimatedEndTime, 
            TimeOnly endTime, decimal summOfOrder, string status, int countOfEmployees, bool isCommercial,
            int clientId, int addressId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                connection.QuerySingle<OrderDTO>(
                    StoredProcedures.Order_Add,
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

        public void UpdateOrderById(int id, string date, TimeOnly startTime, TimeOnly estimatedEndTime,
            TimeOnly endTime, decimal summOfOrder, string status, int countOfEmployees, bool isCommercial,
            int clientId, int addressId)
        {
            using (var connection = new SqlConnection(connectionString))
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
            using (var connection = new SqlConnection(connectionString))
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
