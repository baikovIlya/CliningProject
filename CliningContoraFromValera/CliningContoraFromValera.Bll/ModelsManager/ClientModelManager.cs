using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.Managers;
using CliningContoraFromValera.DAL.DTOs;


namespace CliningContoraFromValera.Bll.ModelsManager
{
    public class ClientModelManager
    {
        ClientManager clientManager = new ClientManager();

        public List<ClientModel> GetAllClients()
        {
            List<ClientDTO> clients = clientManager.GetAllClients();
            return MapperConfigStorage.GetInstance().Map<List<ClientModel>>(clients);
        }

        public ClientModel GetClientById(int clientId)
        {
            ClientDTO client = clientManager.GetClientByID(clientId);
            return MapperConfigStorage.GetInstance().Map<ClientModel>(client);
        }

        public void UpdateClientById(ClientModel clientModel)
        {
            ClientDTO client = MapperConfigStorage.GetInstance().Map<ClientDTO>(clientModel);
            clientManager.UpdateClientById(client);
        }

        public void AddClient(ClientModel clientModel)
        {
            ClientDTO client = MapperConfigStorage.GetInstance().Map<ClientDTO>(clientModel);
            clientManager.AddClient(client);
        }

        public void DeleteClientById(int id)
        {
            clientManager.DeleteClientById(id);
        }

    }
}
