using CliningContoraFromValera.DAL.DTOs;

namespace CliningContoraFromValera.DAL.ManagersInterfaces
{
    public interface IAddressManager
    {
        void AddAddress(AddressDTO newAddress);
        void DeleteAddressById(int addressId);
        void UpdateAddressById(AddressDTO newAddress);
        List<AddressDTO> GetAllAddresses();
        AddressDTO GetAddressById(int addressId);
    }
}
