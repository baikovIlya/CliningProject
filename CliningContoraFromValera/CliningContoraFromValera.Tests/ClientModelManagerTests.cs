using NUnit.Framework;
using Moq;
using CliningContoraFromValera.DAL.Interfaces;
using CliningContoraFromValera.Bll.ModelsManager;

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

        public ClientModelManager GetClientModelManagerToFillMock(int key)
        {
            ClientModelManager _clientModel;
            switch (key)
            {
                case 0:
                    _clientModel = new ClientModelManager
                    {
                        Id = 1,
                        FirstName = "Milana",
                        LastName = "Maksina",
                        Email = "maksina@mail.ru",
                        Phone = "88005553535"
                    };
                    break;
                default:
                    _clientModel = null;
                    break;                    
            }
            return _clientModel;
        }

        public void FillMockGetAllClients()
        {
            _clientManagerMock.Setup(o => o.GetAllClients()).Returns(new List<ClientModelManager>()
            {
                new ClientModelManager
                {
                        Id = 1,
                        FirstName = "Milana",
                        LastName = "Maksina",
                        Email = "maksina@mail.ru",
                        Phone = "88005553535"
                }
            });
        }

        [TestCase(1)]
        public void GetClientById_ShouldReturnClient(int clientId)
        {
            _clientManagerMock.Setup(o => o.GetClientByID(clientId)).Returns
                (
                    new ClientModelManager
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


    }
}