using NUnit.Framework;
using Moq;
using CliningContoraFromValera.DAL.Interfaces;
using CliningContoraFromValera.Bll.ModelsManager;
using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.DTOs;

namespace CliningContoraFromValera.Tests
{
    public class ClientModelManagerTests
    {
        public ClientModelManager _clientModelManager;
        private Mock<IClientManager> _clientManagerMock;
        

        [SetUp]
        public void Setup()
        {
            _clientManagerMock = new Mock<IClientManager>();
            _clientModelManager = new ClientModelManager(_clientManagerMock.Object);
        }

        [TestCaseSource(typeof(UpdateClientByIdTestSource))]
        public void UpdateClientByIdTest_ShouldUpdateClient(ClientModel clientModel, ClientDTO clientDto)
        {
            _clientManagerMock.Setup(o => o.UpdateClientById(clientDto)).Verifiable();
            _clientModelManager.UpdateClientById(clientModel);
            _clientManagerMock.Verify();
        }

        [TestCaseSource(typeof(UpdateClientByIdTestSource))]
        public void DeleteClientByIdTest_ShouldUpdateClient(ClientModel clientModel, ClientDTO clientDto)
        {
            _clientManagerMock.Setup(o => o.DeleteClientById(clientDto.Id)).Verifiable();
            _clientModelManager.DeleteClientById(clientModel.Id);
            _clientManagerMock.Verify();
        }

        [TestCaseSource(typeof(GetClientByIdTestSource))]
        public void GetClientByIdTest_ShouldReturnClient(int clientId, ClientDTO clientDto, ClientModel expected)
        {
            _clientManagerMock.Setup(o => o.GetClientByID(clientId)).Returns(clientDto).Verifiable();
            ClientModel actualClient = _clientModelManager.GetClientById(clientId);
            Assert.AreEqual(expected, actualClient);
            _clientManagerMock.Verify();
        }

        [TestCaseSource(typeof(AddClientTestSource))]
        public void AddClientTest(ClientModel client, ClientDTO expected)
        {
            _clientManagerMock.Setup(o => o.AddClient(expected)).Verifiable();
            _clientModelManager.AddClient(client);
            _clientManagerMock.Verify();
        }
    }
}