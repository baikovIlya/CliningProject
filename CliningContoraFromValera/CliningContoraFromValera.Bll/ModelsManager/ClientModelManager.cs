using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.Managers;
using CliningContoraFromValera.DAL.DTOs;
using CliningContoraFromValera.DAL.Interfaces;
using CliningContoraFromValera.Bll.Interfaces;

namespace CliningContoraFromValera.Bll.ModelsManager
{
    public class ClientModelManager : IClientModelManager
    {
        private IClientManager _clientManager;

        public ClientModelManager()
        {
            _clientManager = new ClientManager();
        }     

        public ClientModelManager(IClientManager clientManager)
        {
            _clientManager = clientManager;
        }

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
