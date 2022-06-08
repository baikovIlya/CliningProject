using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.Managers;
using CliningContoraFromValera.DAL.DTOs;


namespace CliningContoraFromValera.Bll.ModelsManager
{
    public class ClientModelManager
    {
        ClientManager _clientManager = new ClientManager();

        public List<ClientModel> GetAllClients()
        {
            List<ClientDTO> clients = _clientManager.GetAllClients();
            return MapperConfigStorage.GetInstance().Map<List<ClientModel>>(clients);
        }

        public ClientModel GetClientById(int clientId)
        {
            ClientDTO client = _clientManager.GetClientByID(clientId);
            return MapperConfigStorage.GetInstance().Map<ClientModel>(client);
        }

        public void UpdateClientById(ClientModel clientModel)
        {
            ClientDTO client = MapperConfigStorage.GetInstance().Map<ClientDTO>(clientModel);
            _clientManager.UpdateClientById(client);
        }

        public void AddClient(ClientModel clientModel)
        {
            ClientDTO client = MapperConfigStorage.GetInstance().Map<ClientDTO>(clientModel);
            _clientManager.AddClient(client);
        }

        public void DeleteClientById(int id)
        {
            _clientManager.DeleteClientById(id);
        }

    }
}
