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
        public WorkAreaModelManager _workAreaModelManager;
        private Mock<IWorkAreaManager> _workAreaManagerMock;

        [SetUp]
        public void SetUp()
        {
            _workAreaManagerMock = new Mock<IWorkAreaManager>();
            _workAreaModelManager = new WorkAreaModelManager(_workAreaManagerMock.Object);
        }


    }
}
