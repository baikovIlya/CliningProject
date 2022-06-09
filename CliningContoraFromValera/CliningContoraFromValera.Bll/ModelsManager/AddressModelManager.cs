using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.Managers;
using CliningContoraFromValera.DAL.DTOs;
using CliningContoraFromValera.DAL.ManagersInterfaces;

namespace CliningContoraFromValera.Bll.ModelsManager
{
    public class AddressModelManager
    {
        private IAddressManager _addressManager;

        public AddressModelManager()
        {
            _addressManager = new AddressManager();
        }

        public AddressModelManager(IAddressManager addressManager)
        {
            _addressManager = addressManager;
        }


        public void AddAddress(AddressModel newAddress)
        {
            AddressDTO addressDTO = MapperConfigStorage.GetInstance().Map<AddressDTO>(newAddress);
            _addressManager.AddAddress(addressDTO);
        }

        public void DeleteAddressById(int addressId)
        {
            _addressManager.DeleteAddressById(addressId);
        }

        public void UpdateAddressById(AddressModel newAddress)
        {
            AddressDTO newAddressDTO = MapperConfigStorage.GetInstance().Map<AddressDTO>(newAddress);
            _addressManager.UpdateAddressById(newAddressDTO);
        }

        public List<AddressModel> GetAllAddresses()
        {
            List<AddressDTO> addressDTO = _addressManager.GetAllAddresses();
            return MapperConfigStorage.GetInstance().Map<List<AddressModel>>(addressDTO);
        }

        public AddressModel GetAddressById(int addressId)
        {
            AddressDTO addressDTO = _addressManager.GetAddressById(addressId);
            return MapperConfigStorage.GetInstance().Map<AddressModel>(addressDTO);
        }


    }
}
