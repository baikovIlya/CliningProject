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

                yield return new object[]
                {
                    AddressTestModels.addressModels[1],
                    AddressTestDtos.addressDto[1]
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
                    new AddressDTO()
                    {
                        Id = 1,
                        Street = "Колотушкина",
                        Building = "50",
                        Room = "10A",
                        WorkAreaId = 1
                    },
                    new AddressModel()
                    {
                        Id = 1,
                        Street = "Колотушкина",
                        Building = "50",
                        Room = "10A",
                        WorkAreaId = 1
                    }
                };

                yield return new object[]
                {
                    2,
                    new AddressDTO()
                    {
                        Id = 2,
                        Street = "Кукушкина",
                        Building = "10Б",
                        Room = "123",
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
            }
        }

        public class AddAddressTestSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[]
                {
                    new AddressModel()
                    {
                        Id = 1,
                        Street = "Колотушкина",
                        Building = "50",
                        Room = "10A",
                        WorkAreaId = 1
                    },
                    new AddressDTO()
                    {
                        Id = 1,
                        Street = "Колотушкина",
                        Building = "50",
                        Room = "10A",
                        WorkAreaId = 1
                    }
                };

                yield return new object[]
                {
                    new AddressModel()
                    {
                        Id = 2,
                        Street = "Кукушкина",
                        Building = "10Б",
                        Room = "123",
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
        }
        
        public class DeleteAddressByIdTestSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[]
                {
                    new AddressModel()
                    {
                        Id = 1,
                        Street = "Колотушкина",
                        Building = "50",
                        Room = "10A",
                        WorkAreaId = 1
                    },
                    new AddressDTO()
                    {
                        Id = 1,
                        Street = "Колотушкина",
                        Building = "50",
                        Room = "10A",
                        WorkAreaId = 1
                    }
                };

                yield return new object[]
                {
                    new AddressModel()
                    {
                        Id = 2,
                        Street = "Кукушкина",
                        Building = "10Б",
                        Room = "123",
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
        }

        public class GetAllAddressTestSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[]
                {
                    new List<AddressDTO>{
                        new AddressDTO{ 
                        Id = 1,
                        Street = "Колотушкина",
                        Building = "50",
                        Room = "10A",
                        WorkAreaId = 1
                        },

                        new AddressDTO{
                        Id = 2,
                        Street = "Кукушкина",
                        Building = "10Б",
                        Room = "123",
                        WorkAreaId = 1
                        },
                    },

                    new List<AddressModel>{
                        new AddressModel{
                        Id = 1,
                        Street = "Колотушкина",
                        Building = "50",
                        Room = "10A",
                        WorkAreaId = 1
                        },

                        new AddressModel{ 
                        Id = 2,
                        Street = "Кукушкина",
                        Building = "10Б",
                        Room = "123",
                        WorkAreaId = 1
                        },
                    }
                };
            }
        }


    }
}
