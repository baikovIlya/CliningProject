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
}
