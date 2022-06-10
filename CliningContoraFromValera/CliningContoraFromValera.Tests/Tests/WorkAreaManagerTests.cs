using CliningContoraFromValera.Bll.ModelsManager;
using CliningContoraFromValera.DAL.Managers.ManagersInterfaces;
using NUnit.Framework;
using Moq;
using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.DTOs;
using System.Collections.Generic;
using CliningContoraFromValera.Tests.TestSources;

namespace CliningContoraFromValera.Tests
{
    public class WorkAreaManagerTests
    {
        private WorkAreaModelManager _workAreaModelManager;
        private Mock<IWorkAreaManager> _workAreaManagerMock;

        [SetUp]
        public void SetUp()
        {
            _workAreaManagerMock = new Mock<IWorkAreaManager>();
            _workAreaModelManager = new WorkAreaModelManager(_workAreaManagerMock.Object);
        }

        [TestCaseSource(typeof(GetWorkAreaByIdTestSource))]
        public void GetWorkAreaByIdTest(int id, WorkAreaDTO workAreaByIdResult, WorkAreaModel expected)
        {
            _workAreaManagerMock.Setup(o => o.GetWorkAreaByID(id)).Returns(workAreaByIdResult).Verifiable();

            WorkAreaModel actual = _workAreaModelManager.GetWorkAreaById(id);

            Assert.AreEqual(expected, actual);
            _workAreaManagerMock.Verify();
        }

        [TestCaseSource(typeof(AddWorkAreaTestSource))]
        public void AddWorkAreaTest(WorkAreaModel workArea, WorkAreaDTO expected)
        {
            _workAreaManagerMock.Setup(o => o.AddWorkArea(expected)).Verifiable();

            _workAreaModelManager.AddWorkArea(workArea);

            _workAreaManagerMock.Verify();
        }

        [TestCaseSource(typeof(DeleteWorkAreaByIdTestSource))]
        public void DeleteWorkAreaByIdTest(WorkAreaModel workAreaModel, WorkAreaDTO workAreaDto)
        {
            _workAreaManagerMock.Setup(o => o.DeleteWorkAreaById(workAreaDto.Id)).Verifiable();

            _workAreaModelManager.DeleteWorkAreaById(workAreaModel.Id);

            _workAreaManagerMock.Verify();
        }

        [TestCaseSource(typeof(UpdateWorkAreaByIdTestSource))]
        public void UpdateWorkAreaByIdTest(WorkAreaModel workAreaModel, WorkAreaDTO workAreaDto)
        {
            _workAreaManagerMock.Setup(o => o.UpdateWorkAreaById(workAreaDto)).Verifiable();

            _workAreaModelManager.UpdateWorkAreaById(workAreaModel);

            _workAreaManagerMock.Verify();
        }

        [TestCaseSource(typeof(GetAllWorkAreasTestSource))]
        public void GetAllWorkAreasTest(List<WorkAreaDTO> workAreaResult, List<WorkAreaModel> expected)
        {
            _workAreaManagerMock.Setup(o => o.GetAllWorkAreas()).Returns(workAreaResult).Verifiable();

            List<WorkAreaModel> actual = _workAreaModelManager.GetAllWorkAreas();
            Assert.AreEqual(expected, actual);

            _workAreaManagerMock.Verify();
        }
    }
}
