using AutoMapper;
using CliningContoraFromValera.Bll;
using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.Bll.ModelsManager;

using CliningContoraFromValera.DAL.Dtos;
using CliningContoraFromValera.DAL.Managers;

//var C = new ClientModelManager();
//ClientModelManager.UpdateClientByID(ClientModel);






//E.AddEmployee(EDto);
var WA = new WorkAreaManager();
var WADto = new WorkAreaDto()
{
    Name = "Морской"
};
WA.AddWorkArea(WADto);
var A = new AddressManager();
var ADto = new AddressDto()
{
    Street = "Невский",
    Building = "пятая парадная",
    Room = "12",
    WorkAreaId = 1
};
//A.AddAddress(ADto);
var E = new EmployeeManager();
var O = new OrderManager();
//Console.WriteLine(O.GetAllOrder());
//Console.WriteLine(E.GetAllEmployeesInfoById(1));
//Console.WriteLine(E.GetOrderHistoryOfTheEmployeeById(1));
//E.GetEmployyesAvailableForOrder(new DateTime(2022, 06, 01), 4, 3);
//Console.WriteLine(E.GetEmployeeByID(1));
var WT = new WorkTimeManager();
var WTDto = new WorkTimeDto()
{
    Date = new DateTime(2022, 06, 02),
    StartTime = new TimeSpan(12, 30, 00),
    FinishTime = new TimeSpan(20, 00, 00),
    EmployeeId = 1
};
//List<WorkTimeDto> test = WT.GetAllWorkTimes();
var S = new ServiceManager();
var SDto = new ServiceDto()
{
    Name = "химчистка диванов",
    Description = "обработка шампунем",
    Price = 30,
    CommercialPrice = 40,
    Unit = "м2",
    EstimatedTime = new TimeSpan(02, 00, 00)
};
var ODto = new OrderDto()
{
    Date = new DateTime(2022, 06, 05),
    StartTime = new TimeSpan(12, 30, 00),
    EstimatedEndTime = new TimeSpan(02, 00, 00),
    FinishTime = new TimeSpan(15, 00, 00),
    Price = 30,
    Status = "не выполнен",
    CountOfEmployees = 1,
    IsCommercial = false,
    ClientId = 1,
    AddressId = 2
};
//O.AddOrder(ODto);
var C = new ClientManager();
var CDto = new ClientDto()
{
    FirstName = "Маша",
    LastName = "Иванова",
    Email = "@fgmn",
    Phone = "+79851476512"
};
//C.AddClient (CDto);
//ST.AddServiceType(STDto);
//S.AddService(SDto);
//WT.AddWorkTime(WTDto);
//WT.DeleteWorkTimeById(WTDto);
//Console.WriteLine(WT.GetWorkTimeById(1));
//WT.ChangeEmployeeScheduleByEmployeeIdByDate(WTDto);
//foreach (var i in test)
//{
//    i.ToString();
//    Console.WriteLine(i.ToString());
//}
////E.AddEmployee("Вася", "Петров", "+79514521271");
//var WT = new WorkTimeManager();
//var WTDto = new WorkTimeDto()
//{
//    Date = new DateTime(2022, 06, 02),
//    StartTime = new TimeSpan(12,30,00),
//    FinishTime = new TimeSpan(20,00,00),
//    EmployeeId = 1
//};
//List<WorkTimeDto> test = WT.GetAllWorkTimes();
////WT.AddWorkTime(WTDto);
////WT.DeleteWorkTimeById(WTDto);
////Console.WriteLine(WT.GetWorkTimeById(1));
////WT.ChangeEmployeeScheduleByEmployeeIdByDate(WTDto);
//foreach (var i in test)
//{
//    i.ToString();
//    Console.WriteLine(i.ToString());
//}


//MapperConfigStorage configStorage = new MapperConfigStorage();

//AutoMapper.Mapper mapper = MapperConfigStorage.GetInstance();

//ClientModel clientModel = mapper.Map<ClientModel>(ClientDto);

//Console.WriteLine();