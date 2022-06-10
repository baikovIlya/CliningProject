using CliningContoraFromValera.Bll.Models;
using System.Collections.Generic;


namespace CliningContoraFromValera.Bll.Interfaces
{
    public interface IClientModelManager
    {
        List<ClientModel> GetAllClients();
        ClientModel GetClientById(int clientId);
        void UpdateClientById(ClientModel clientModel);
        void AddClient(ClientModel clientModel);
        void DeleteClientById(int id);


    }
}
