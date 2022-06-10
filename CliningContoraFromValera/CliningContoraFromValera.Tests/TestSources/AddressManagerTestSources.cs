using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.DTOs;
using System.Collections;
using System.Collections.Generic;

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
                WorkArea = new WorkAreaModel() { Id = 1, Name = "Nevstyi" }
            },

            new AddressModel()
            {
                Id = 2,
                Street = "Кукушкина",
                Building = "10Б",
                Room = "123",
                WorkArea = new WorkAreaModel() { Id = 1, Name = "Nevstyi" }
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
                WorkArea = new WorkAreaDTO() { Id = 1, Name = "Nevstyi" }
                },

                new AddressDTO()
                {
                Id = 2,
                Street = "Кукушкина",
                Building = "10Б",
                Room = "123",
                WorkArea = new WorkAreaDTO() { Id = 1, Name = "Nevstyi" }
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
                        WorkArea = new WorkAreaDTO() { Id = 1, Name = "Nevstyi" }
                    },
                    new AddressModel()
                    {
                        Id = 1,
                        Street = "Колотушкина",
                        Building = "50",
                        Room = "10A",
                        WorkArea = new WorkAreaModel() { Id = 1, Name = "Nevstyi" }
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
                        WorkArea = new WorkAreaDTO() { Id = 1, Name = "Nevstyi" }
                    },

                    new AddressModel()
                    {
                        Id = 2,
                        Street = "Кукушкина",
                        Building = "10Б",
                        Room = "123",
                        WorkArea = new WorkAreaModel() { Id = 1, Name = "Nevstyi" }
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
                        WorkArea = new WorkAreaModel() { Id = 1, Name = "Nevstyi" }
                    },
                    new AddressDTO()
                    {
                        Id = 1,
                        Street = "Колотушкина",
                        Building = "50",
                        Room = "10A",
                        WorkArea = new WorkAreaDTO() { Id = 1, Name = "Nevstyi" }
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
                        WorkArea = new WorkAreaModel() { Id = 1, Name = "Nevstyi" }
                    },

                    new AddressDTO()
                    {
                        Id = 2,
                        Street = "Кукушкина",
                        Building = "10Б",
                        Room = "123",
                        WorkArea = new WorkAreaDTO() { Id = 1, Name = "Nevstyi" }
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
                        WorkArea = new WorkAreaModel() { Id = 1, Name = "Nevstyi" }
                    },
                    new AddressDTO()
                    {
                        Id = 1,
                        Street = "Колотушкина",
                        Building = "50",
                        Room = "10A",
                        WorkArea = new WorkAreaDTO() { Id = 1, Name = "Nevstyi" }
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
                        WorkArea = new WorkAreaModel() { Id = 1, Name = "Nevstyi" }
                    },

                    new AddressDTO()
                    {
                        Id = 2,
                        Street = "Кукушкина",
                        Building = "10Б",
                        Room = "123",
                        WorkArea = new WorkAreaDTO() { Id = 1, Name = "Nevstyi" }
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
                        WorkArea = new WorkAreaDTO() { Id = 1, Name = "Nevstyi" }
                        },

                        new AddressDTO{
                        Id = 2,
                        Street = "Кукушкина",
                        Building = "10Б",
                        Room = "123",
                        WorkArea = new WorkAreaDTO() { Id = 1, Name = "Nevstyi" }
                        },
                    },

                    new List<AddressModel>{
                        new AddressModel{
                        Id = 1,
                        Street = "Колотушкина",
                        Building = "50",
                        Room = "10A",
                        WorkArea = new WorkAreaModel() { Id = 1, Name = "Nevstyi" }
                        },

                        new AddressModel{ 
                        Id = 2,
                        Street = "Кукушкина",
                        Building = "10Б",
                        Room = "123",
                        WorkArea = new WorkAreaModel() { Id = 1, Name = "Nevstyi" }
                        },
                    }
                };
            }
        }


    }
}
