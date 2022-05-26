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
                    param: new {id = id},
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

    }
}
