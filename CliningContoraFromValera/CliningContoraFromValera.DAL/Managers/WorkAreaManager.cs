using Dapper;
using System.Data.SqlClient;

namespace CliningContoraFromValera.DAL
{
    public class WorkAreaManager
    {
        public List<WorkAreaDTO> GetAllWorkAreas()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.Query<WorkAreaDTO>(
                    StoredProcedures.WorkArea_GetAll,
                    commandType: System.Data.CommandType.StoredProcedure)
                    .ToList();
            }
        }

        public WorkAreaDTO GetWorkAreaByID(int workAreaId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                return connection.QuerySingle<WorkAreaDTO>(
                    StoredProcedures.WorkArea_GetById,
                    param: new { id = workAreaId },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void AddWorkArea(WorkAreaDTO newWorkArea)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingle<WorkAreaDTO>(
                    StoredProcedures.WorkArea_Add,
                    param: new
                    { newWorkArea.Name},
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void UpdateClientById(WorkAreaDTO newWorkArea)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<WorkAreaDTO>(
                    StoredProcedures.WorkArea_UpdateById,
                    param: new
                    {
                        newWorkArea.Id,
                        newWorkArea.Name,
                    },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteClientById(int workAreaId)
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                connection.QuerySingleOrDefault<WorkAreaDTO>(
                    StoredProcedures.WorkArea_DeleteById,
                    param: new { id = workAreaId },
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public List<WorkAreaDTO> GetWorkareasAndAdresses()
        {
            using (var connection = new SqlConnection(ServerSettings._connectionString))
            {
                connection.Open();

                Dictionary<int, WorkAreaDTO> result = new Dictionary<int, WorkAreaDTO>();

                connection.Query<WorkAreaDTO, AddressDTO, WorkAreaDTO>
                (
                    StoredProcedures.GetWorkareasAndAdresses,
                    (workarea, address) => {
                        if (!result.ContainsKey(workarea.Id))
                        {
                            result.Add(workarea.Id, workarea);
                        }
                        WorkAreaDTO crnt = result[workarea.Id];
                        if (address != null)
                        {
                            crnt.Addresses.Add(address);
                        }
                        return crnt;
                    },
                    commandType: System.Data.CommandType.StoredProcedure,
                    splitOn: "Id"
                );
                return result.Values.ToList();
            }
        }
    }
}
