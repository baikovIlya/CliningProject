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
    public static class WorkAreaModelsTest
    {
        public static List<WorkAreaModel> workAreaModels = new List<WorkAreaModel>()
        {
            new WorkAreaModel()
            {
                Id = 1,
                Name = "Moscovskiy"
            },

            new WorkAreaModel()
            {
                Id = 2,
                Name = "Frunzenskiy"
            }
        };
    }

    public static class WorkAreaDtosTest
    {
        public static List<WorkAreaDTO> workAreaDtos = new List<WorkAreaDTO>()
        {
            new WorkAreaDTO()
            {
                Id = 1,
                Name = "Moskovskiy"
            },

            new WorkAreaDTO()
            {
                Id = 2,
                Name = "Frunzenskiy"
            }
        };
    }

    public class WorkAreaManagerTestSources : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                WorkAreaModelsTest.workAreaModels[0],
                WorkAreaDtosTest.workAreaDtos[0]
            };
        }
    }
}
