using CliningContoraFromValera.Bll.ModelsManager;
using CliningContoraFromValera.DAL.Managers.ManagersInterfaces;
using NUnit.Framework;
using Moq;
using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.DTOs;

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
        public void GetWorkAreaByIdTest(int id, WorkAreaDTO GetWorkAreaByIdResult, WorkAreaModel expected)
        {
            _workAreaManagerMock.Setup(o => o.GetWorkAreaByID(id)).Returns(GetWorkAreaByIdResult).Verifiable();

            WorkAreaModel actual = _workAreaModelManager.GetWorkAreaById(id);
         
            _workAreaManagerMock.Verify();
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(AddWorkAreaTestSource))]
        public void AddWorkAreaTest(WorkAreaModel workArea, WorkAreaDTO expected)
        {
            _workAreaManagerMock.Setup(o => o.AddWorkArea(expected)).Verifiable();

            _workAreaModelManager.AddWorkArea(workArea);

            _workAreaManagerMock.Verify();
        }
    }
}
