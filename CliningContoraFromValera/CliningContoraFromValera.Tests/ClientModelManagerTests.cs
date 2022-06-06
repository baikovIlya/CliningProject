using NUnit.Framework;
using Moq;
using CliningContoraFromValera.DAL.Interfaces;
using CliningContoraFromValera.Bll.ModelsManager;
using CliningContoraFromValera.Bll.Models;

namespace CliningContoraFromValera.Tests
{
    public class ClientModelManagerTests
    {
        public ClientModelManager _clientModelManager;
        private readonly Mock<IClientManager> _clientManagerMock;

        public ClientModelManagerTests()
        {
            _clientManagerMock = new Mock<IClientManager>();
        }

        [SetUp]
        public void Setup(Mock<IClientManager> _clientManagerMock)
        {
            _clientManagerMock = new Mock<IClientManager>();
            _clientModelManager = new ClientModelManager(_clientManagerMock.Object);
        }

        public ClientModel GetClientModelToFillMock(int key)
        {
            ClientModel _clientModel;
            switch (key)
            {
                case 0:
                    _clientModel = new ClientModel
                    {
                        Id = 1,
                        FirstName = "Milana",
                        LastName = "Maksina",
                        Email = "maksina@mail.ru",
                        Phone = "88005553535"
                    };
                    break;
                case 1:
                    _clientModel = new ClientModel
                    {
                        Id = 2,
                        FirstName = "Naruto",
                        LastName = "Uzumaki",
                        Email = "narutothegod@gmail.com",
                        Phone = "88923723505"
                    };
                default:
                    _clientModel = null;
                    break;                    
            }
            return _clientModel;
        }

        public void FillMockGetAllClients()
        {
            _clientManagerMock.Setup(o => o.GetAllClients()).Returns(new List<ClientModel>()
            {
                new ClientModel
                {
                        Id = 1,
                        FirstName = "Milana",
                        LastName = "Maksina",
                        Email = "maksina@mail.ru",
                        Phone = "88005553535"
                },

                new ClientModel
                {
                        Id = 2,
                        FirstName = "Naruto",
                        LastName = "Uzumaki",
                        Email = "narutothegod@gmail.com",
                        Phone = "88923723505"
                }
            });
        }

        [TestCase(1)]
        public void GetClientByIdTest_ShouldReturnClient(int clientId)
        {
            _clientManagerMock.Setup(o => o.GetClientByID(clientId)).Returns
                (
                    new ClientModel
                    {
                        Id = 1,
                        FirstName = "Milana",
                        LastName = "Maksina",
                        Email = "maksina@mail.ru",
                        Phone = "88005553535"
                    }
                );
            var actual = _clientModelManager.GetClientById(clientId);
            _clientManagerMock.Verify(o => o.GetClientByID(clientId), Times.Once());

            //Assert.IsTrue(actual.);
            Assert.IsNotNull(actual);
        }

        [TestCase(1)]
        public void UpdateClientByIdTest_ShouldUpdateClient(int id)
        {
            var expected = GetClientModelToFillMock(id);
            var actual = _clientModelManager.UpdateClientById(expected);
            Assert.AreEqual(actual, expected);
        }

        public void DeleteClientByIdTest_ShouldDeleteClient(int id)
        {
            var expected = GetClientModelToFillMock(id);
            _clientModelManager.DeleteClientById(expected);
        }


    }
}