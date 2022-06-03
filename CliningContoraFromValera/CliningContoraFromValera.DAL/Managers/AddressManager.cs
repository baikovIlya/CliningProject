using Dapper;
using System.Data.SqlClient;
using CliningContoraFromValera.DAL.Dtos;

namespace CliningContoraFromValera.DAL.Managers
{
    public class AddressManager
    {
        public void AddAddress(AddressDto newAddress)
        {
            using(var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<AddressDto>
                    (
                        StoredProcedures.Address_Add,
                        param: new 
                        {
                            newAddress.Street,
                            newAddress.Building,
                            newAddress.Room,
                            newAddress.WorkAreaId
                        },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteAddressById(int addressId)
        {
            using(var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<AddressDto>
                    (
                        StoredProcedures.Address_DeleteById,
                        param: new { id = addressId },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void UpdateAddressById(AddressDto newAddress)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<AddressDto>
                    (
                        StoredProcedures.Address_UpdateById,
                        param: new
                        {
                            newAddress.Id,
                            newAddress.Street,
                            newAddress.Building,
                            newAddress.Room,
                            newAddress.WorkAreaId
                        },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public List<AddressDto> GetAllAddresses()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.Query<AddressDto>
                    (
                        StoredProcedures.Address_GetAll,
                        commandType: System.Data.CommandType.StoredProcedure
                    ).ToList();
            }
        }

        public AddressDto GetAddressById(int addressId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<AddressDto>
                    (
                        StoredProcedures.Address_GetById,
                        param: new { id = addressId },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
