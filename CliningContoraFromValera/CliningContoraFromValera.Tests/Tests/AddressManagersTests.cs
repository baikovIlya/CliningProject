using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.Bll.ModelsManager;
using CliningContoraFromValera.DAL.DTOs;
using CliningContoraFromValera.DAL.ManagersInterfaces;
using Moq;
using NUnit.Framework;
using static CliningContoraFromValera.Tests.TestSources.AddressTestModels;

namespace CliningContoraFromValera.Tests
{
    public class AddressManagersTests
    {
        public AddressModelManager _addressModelManager;
        private Mock<IAddressManager> _addressManagerMock;


        [SetUp]
        public void Setup()
        {
            _addressManagerMock = new Mock<IAddressManager>();
            _addressModelManager = new AddressModelManager(_addressManagerMock.Object);
        }

        [TestCaseSource(typeof(UpdateAddressTestSource))]
        public void UpdateAddressTest(AddressModel addressModel, AddressDTO addressDto)
        {
            _addressManagerMock.Setup(o => o.UpdateAddressById(addressDto)).Verifiable();
            _addressModelManager.UpdateAddressById(addressModel);
            _addressManagerMock.Verify();
        }

        [TestCaseSource(typeof(GetAllAddressTestSource))]
        public void GetAddressByIdAddressTest(int addressId, AddressDTO addressDto, AddressModel expectedAddress)
        {
            _addressManagerMock.Setup(o => o.GetAddressById(addressId)).Returns(addressDto).Verifiable();
            AddressModel actualAddress = _addressModelManager.GetAddressById(addressId);
            //Assert.AreEqual(expectedAddress, actualAddress);
            _addressManagerMock.Verify();
        }






    }
}
