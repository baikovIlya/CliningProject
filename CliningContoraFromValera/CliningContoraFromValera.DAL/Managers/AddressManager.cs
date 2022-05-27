using Dapper;
using System.Data.SqlClient;

namespace CliningContoraFromValera.DAL
{
    public class AddressManager
    {
        public void AddAddress(AddressDTO newAddress)
        {
            using(var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<AddressDTO>
                    (
                        StoredProcedures.Address_Add,
                        param: new 
                        {
                            newAddress.Street,
                            newAddress.Bilding,
                            newAddress.Room,
                            newAddress.WorkAreaId
                        },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteAddressById(AddressDTO newAddress)
        {
            using(var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<AddressDTO>
                    (
                        StoredProcedures.Address_DeleteById,
                        param: new { newAddress.Id },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void UpdateAddressById(AddressDTO newAddress)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<AddressDTO>
                    (
                        StoredProcedures.Address_UpdateById,
                        param: new
                        {
                            newAddress.Id,
                            newAddress.Street,
                            newAddress.Bilding,
                            newAddress.Room,
                            newAddress.WorkAreaId
                        },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public List<AddressDTO> GetAllAddresses()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.Query<AddressDTO>
                    (
                        StoredProcedures.Address_GetAll,
                        commandType: System.Data.CommandType.StoredProcedure
                    ).ToList();
            }
        }

        public AddressDTO GetAddressById(int id)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<AddressDTO>
                    (
                        StoredProcedures.Address_GetById,
                        param: new { id = id },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
