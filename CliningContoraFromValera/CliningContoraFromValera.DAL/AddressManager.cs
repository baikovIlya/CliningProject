using Dapper;
using System.Data.SqlClient;
using CliningContoraFromValera.DAL.DTOs;

namespace CliningContoraFromValera.DAL
{
    public class AddressManager
    {
        public string _connectionString = @"Server=.\SQLEXPRESS;Database=CliningContoraFromValera;Trusted_Connection=True;";

        public void AddAddress(int id, string street, string building, string room, int workAreaId)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                connection.QuerySingle<AddressDTO>
                    (
                        StoredProcedures.Address_Add,
                        param: new 
                        {
                            id = id,
                            street = street,
                            building = building,
                            room = room,
                            workAreaId = workAreaId
                        },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteAddressById(int id)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                connection.QuerySingle<AddressDTO>
                    (
                        StoredProcedures.Address_DeleteById,
                        param: new { id = id },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void UpdateAddressById(int id, string street, string building, string room, int workAreaId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                connection.QuerySingle<AddressDTO>
                    (
                        StoredProcedures.Address_UpdateById,
                        param: new
                        {
                            id = id,
                            street = street,
                            building = building,
                            room = room,
                            workAreaId = workAreaId
                        },
                        commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public List<AddressDTO> GetAllAddresses()
        {
            using (var connection = new SqlConnection(_connectionString))
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
            using (var connection = new SqlConnection(_connectionString))
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
