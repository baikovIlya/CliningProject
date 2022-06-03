using CliningContoraFromValera.Bll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CliningContoraFromValera.DAL;
using CliningContoraFromValera.DAL.Managers;
using CliningContoraFromValera.DAL.Dtos;


namespace CliningContoraFromValera.Bll.ModelsManager
{
    public class ClientModelManager
    {
        ClientManager ClientManager = new ClientManager();

        public List<ClientModel> GetAllClients()
        {
            List<ClientDto> clients = ClientManager.GetAllClients();
            return MapperConfigStorage.GetInstance().Map<List<ClientModel>>(clients);
        }

        public ClientModel GetClientById(int clientId)
        {
            ClientDto client = ClientManager.GetClientByID(clientId);
            return MapperConfigStorage.GetInstance().Map<ClientModel>(client);
        }

        public void UpdateClientById(ClientModel clientModel)
        {
            ClientDto client = MapperConfigStorage.GetInstance().Map<ClientDto>(clientModel);
            ClientManager.UpdateClientById(client);
        }

        public void AddClient(ClientModel clientModel)
        {
            ClientDto client = MapperConfigStorage.GetInstance().Map<ClientDto>(clientModel);
            ClientManager.AddClient(client);
        }

        public void DeleteClientById(int id)
        {
            ClientManager.DeleteClientById(id);
        }

    }
}
