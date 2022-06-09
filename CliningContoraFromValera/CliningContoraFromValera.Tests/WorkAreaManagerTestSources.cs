using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.DTOs;

namespace CliningContoraFromValera.Tests
{
    public class WorkAreaTestData
    {
        public WorkAreaModel GetWorkAreaModelForTests()
        {
            WorkAreaModel workAreaModel = new WorkAreaModel()
            {
                Id = 1,
                Name = "Moskovskiy"
            };

            return workAreaModel;
        }
    }

    public class GetWorkAreaByIdTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                1,

                new WorkAreaDTO()
                {
                    Id = 1,
                    Name = "Moskovskiy"
                },

                new WorkAreaModel()
                {
                    Id = 1,
                    Name = "Moskovskiy"
                },
            };
            
            yield return new object[]
            {
                2,

                new WorkAreaDTO()
                {
                    Id = 2,
                    Name = "Frunzenskiy"
                },

                new WorkAreaModel()
                {
                    Id = 2,
                    Name = "Frunzenskiy"
                },
            };
        }
    }
    public class AddWorkAreaTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new WorkAreaModel()
                {
                    Id = 2,
                    Name = "Frunzenskiy"
                },

                new WorkAreaDTO()
                {
                    Id = 2,
                    Name = "Frunzenskiy"
                },
            };
            
            yield return new object[]
            {
                new WorkAreaModel()
                {
                    Id = 3,
                    Name = "Центральный"
                },

                new WorkAreaDTO()
                {
                    Id = 3,
                    Name = "Центральный"
                },
            };
        }
    }
    public class UpdateWorkAreaByIdTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new WorkAreaModel()
                {
                    Id = 2,
                    Name = "Frunzenskiy"
                },

                new WorkAreaDTO()
                {
                    Id = 2,
                    Name = "Frunzenskiy"
                },
            };
            
            yield return new object[]
            {
                new WorkAreaModel()
                {
                    Id = 3,
                    Name = "Центральный"
                },

                new WorkAreaDTO()
                {
                    Id = 3,
                    Name = "Центральный"
                },
            };
        }
    }
    public class DeleteWorkAreaByIdTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new WorkAreaModel()
                {
                    Id = 2,
                    Name = "Frunzenskiy"
                },

                new WorkAreaDTO()
                {
                    Id = 2,
                    Name = "Frunzenskiy"
                },
            };
            
            yield return new object[]
            {
                new WorkAreaModel()
                {
                    Id = 3,
                    Name = "Центральный"
                },

                new WorkAreaDTO()
                {
                    Id = 3,
                    Name = "Центральный"
                },
            };
        }
    } 
    public class GetAllWorkAreasTestSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new List<WorkAreaDTO>{
                    new WorkAreaDTO{ Id = 1, Name = "Moskovskiy"},
                    new WorkAreaDTO{ Id = 2, Name = "Frunzenskiy"},
                    new WorkAreaDTO{ Id = 3, Name = "Центральный"}
                },

                new List<WorkAreaModel>{
                    new WorkAreaModel{ Id = 1, Name = "Moskovskiy"},
                    new WorkAreaModel{ Id = 2, Name = "Frunzenskiy"},
                    new WorkAreaModel{ Id = 3, Name = "Центральный"}
                }
            };

            yield return new object[]
            {
                new List<WorkAreaDTO>{
                    new WorkAreaDTO{ Id = 4, Name = "Выборгский"},
                    new WorkAreaDTO{ Id = 5, Name = "Колпинский"},
                    new WorkAreaDTO{ Id = 6, Name = "Красногвардейский"}
                },

                new List<WorkAreaModel>{
                    new WorkAreaModel{ Id = 4, Name = "Выборгский"},
                    new WorkAreaModel{ Id = 5, Name = "Колпинский"},
                    new WorkAreaModel{ Id = 6, Name = "Красногвардейский"}
                }
            };
        }
    }
}
