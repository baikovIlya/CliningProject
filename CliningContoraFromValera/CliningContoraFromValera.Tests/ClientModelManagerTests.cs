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

        [TestCaseSource(typeof(UpdateClientByIdTestSource2))]
        public void UpdateClientByIdTest_ShouldUpdateClient(ClientModel clientModel, ClientDTO clientDto)
        {
            _clientManagerMock.Setup(o => o.UpdateClientById(clientDto)).Verifiable();
            _clientModelManager.UpdateClientById(clientModel);
            _clientManagerMock.Verify();
        }

        //[TestCase()]
        //public void DeleteClientByIdTest_ShouldDeleteClient(int id)
        //{
        //    var expected = GetClientModelToFillMock(id);
        //    _clientModelManager.DeleteClientById(expected);
        //}

        //public ClientModel GetClientModelToFillMock(int key)
        //{
        //    ClientModel _clientModel;
        //    switch (key)
        //    {
        //        case 0:
        //            _clientModel = new ClientModel
        //            {
        //                Id = 1,
        //                FirstName = "Milana",
        //                LastName = "Maksina",
        //                Email = "maksina@mail.ru",
        //                Phone = "88005553535"
        //            };
        //            break;
        //        case 1:
        //            _clientModel = new ClientModel
        //            {
        //                Id = 2,
        //                FirstName = "Naruto",
        //                LastName = "Uzumaki",
        //                Email = "narutothegod@gmail.com",
        //                Phone = "88923723505"
        //            };
        //        default:
        //            _clientModel = null;
        //            break;                    
        //    }
        //    return _clientModel;
        //}

        //public void FillMockGetAllClients()
        //{
        //    _clientManagerMock.Setup(o => o.GetAllClients()).Returns(new List<ClientModel>()
        //    {
        //        new ClientModel
        //        {
        //                Id = 1,
        //                FirstName = "Milana",
        //                LastName = "Maksina",
        //                Email = "maksina@mail.ru",
        //                Phone = "88005553535"
        //        },

        //        new ClientModel
        //        {
        //                Id = 2,
        //                FirstName = "Naruto",
        //                LastName = "Uzumaki",
        //                Email = "narutothegod@gmail.com",
        //                Phone = "88923723505"
        //        }
        //    });
        //}


        //[TestCaseSource(1)]
        //public void GetClientByIdTest_ShouldReturnClient(int clientId, ClientDTO clientDto, ClientModel expected)
        //{
        //    _clientManagerMock.Setup(o => o.GetClientByID(clientId)).Returns
        //        (
        //            new ClientDTO
        //            {
        //                Id = 1,
        //                FirstName = "Milana",
        //                LastName = "Maksina",
        //                Email = "maksina@mail.ru",
        //                Phone = "88005553535"
        //            }
        //        );
        //    var actual = _clientModelManager.GetClientById(clientId);
        //    _clientManagerMock.Verify();

        //    Assert.AreEqual(expected, actual);
        //}

    }
}