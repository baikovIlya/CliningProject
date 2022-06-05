using CliningContoraFromValera.DAL.DTOs;
using System.Collections.Generic;


namespace CliningContoraFromValera.DAL.Interfaces
{
    public interface IClientManager
    {
        List<ClientDTO> GetAllClients();
        ClientDTO GetClientByID(int clientId);
        void AddClient(ClientDTO newClient);
        void UpdateClientById(ClientDTO newClient);
        void DeleteClientById(int clientId);

    }
}
