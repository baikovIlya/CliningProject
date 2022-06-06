using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.Managers;
using CliningContoraFromValera.DAL.DTOs;

namespace CliningContoraFromValera.Bll.ModelsManager
{
    public class AddressModelManager
    {
        AddressManager _addressManager = new AddressManager();

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
