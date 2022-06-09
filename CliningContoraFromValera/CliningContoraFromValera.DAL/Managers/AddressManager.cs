using Dapper;
using System.Data.SqlClient;
using CliningContoraFromValera.DAL.DTOs;
using CliningContoraFromValera.DAL.ManagersInterfaces;

namespace CliningContoraFromValera.DAL.Managers
{
    public class AddressManager: IAddressManager
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

                connection.QuerySingle<AddressDTO>
                    (
                        StoredProcedures.Address_DeleteById,
                        param: new { id = addressId },
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
                            newAddress.Building,
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

        public AddressDTO GetAddressById(int addressId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<AddressDTO>
                    (
                        StoredProcedures.Address_GetById,
                        param: new { id = addressId },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
