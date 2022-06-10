using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliningContoraFromValera.Tests
{
    public static class ClientTestModels
    {
        public static List<ClientModel> clientModels = new List<ClientModel>()
        {
            new ClientModel()
            {
                Id = 1,
                FirstName = "Milana",
                LastName = "Maksina",
                Email = "maksina@mail.ru",
                Phone = "88005553535"
            },

            new ClientModel()
            {
                Id = 2,
                FirstName = "Naruto",
                LastName = "Uzumaki",
                Email = "narutothegod@gmail.com",
                Phone = "88923723505"
            }
        };
    }

    public static class ClientTestDtos
    {
        public static List<ClientDTO> clientDTOs = new List<ClientDTO>()
        {
            new ClientDTO()
            {
                Id = 1,
                FirstName = "Milana",
                LastName = "Maksina",
                Email = "maksina@mail.ru",
                Phone = "88005553535"
            },

            new ClientDTO()
            {
                Id = 2,
                FirstName = "Naruto",
                LastName = "Uzumaki",
                Email = "narutothegod@gmail.com",
                Phone = "88923723505"
            }
        };
    }

    public class GetClientByIdTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                1,
                ClientTestDtos.clientDTOs[0],
                ClientTestModels.clientModels[0],
            };
            yield return new object[]
            {
                2,
                ClientTestDtos.clientDTOs[1],
                ClientTestModels.clientModels[1],
            };
        }
    }

    public class GetAllClientByIdTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
           {
                new List<ClientDTO>
                {
                    new ClientDTO
                    {
                        Id = 1,
                        FirstName = "Milana",
                        LastName = "Maksina",
                        Email = "maksina@mail.ru",
                        Phone = "88005553535" 
                    },
                    new ClientDTO
                    {
                        Id = 2,
                        FirstName = "Milana",
                        LastName = "Maksina",
                        Email = "maksina@mail.ru",
                        Phone = "88005553535"
                    },
                    new ClientDTO
                    {
                        Id = 3,
                        FirstName = "Milana",
                        LastName = "Maksina",
                        Email = "maksina@mail.ru",
                        Phone = "88005553535"
                    }
                },

                new List<ClientModel>
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
                        FirstName = "Milana",
                        LastName = "Maksina",
                        Email = "maksina@mail.ru",
                        Phone = "88005553535"
                    },
                    new ClientModel
                    {
                        Id = 3,
                        FirstName = "Milana",
                        LastName = "Maksina",
                        Email = "maksina@mail.ru",
                        Phone = "88005553535"
                    }
                }
            };
        }
    }

    public class AddClientTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                ClientTestModels.clientModels[0],
                ClientTestDtos.clientDTOs[0]
            };

            yield return new object[]
            {
                ClientTestModels.clientModels[1],
                ClientTestDtos.clientDTOs[1]
            };
        }
    }
    public class UpdateClientByIdTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                ClientTestModels.clientModels[0],
                ClientTestDtos.clientDTOs[0]
            };

            yield return new object[]
            {
                ClientTestModels.clientModels[1],
                ClientTestDtos.clientDTOs[1]
            };
        }
    }
}
