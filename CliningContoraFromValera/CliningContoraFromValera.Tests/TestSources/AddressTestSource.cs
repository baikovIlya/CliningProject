using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliningContoraFromValera.Tests.TestSources
{
    public class AddressTestModels
    {
        public static List<AddressModel> addressModels = new List<AddressModel>()
        {
            new AddressModel()
            {
                Id = 1,
                Street = "Колотушкина",
                Building = "50",
                Room = "10A",
                WorkAreaId = 1
            },

            new AddressModel()
            {
                Id = 2,
                Street = "Кукушкина",
                Building = "10Б",
                Room = "123",
                WorkAreaId = 1
            }
        };

        public static class AddressTestDtos
        {

            public static List<AddressDTO> addressDto = new List<AddressDTO>()
            {
                new AddressDTO()
                {
                Id = 1,
                Street = "Колотушкина",
                Building = "50",
                Room = "10A",
                WorkAreaId = 1
                },

                new AddressDTO()
                {
                Id = 2,
                Street = "Кукушкина",
                Building = "10Б",
                Room = "123",
                WorkAreaId = 1
                }

            };
        }

        public class UpdateAddressTestSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[]
                {
                AddressTestModels.addressModels[0],
                AddressTestDtos.addressDto[0]
                };
            }
        }

        public class GetAddressByIdTestSource: IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[]
                {
                1,
                AddressTestDtos.addressDto[0],
                AddressTestModels.addressModels[0]
                };
            }
        }
        
        public class GetAllAddressTestSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[]
                {
                  AddressTestDtos.addressDto,
                  addressModels
                };
            }
        }


    }
}
