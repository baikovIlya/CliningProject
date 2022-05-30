using CliningContoraFromValera.DAL;
using CliningContoraFromValera.DAL.Managers;

//List<ClientDTO> test = CL.GetAllClients();
//CL.AddClient("малыш", "пупсович", "mfkssd", "+799992332");
//CL.AddClient("котик", "мяукович", "may", "+79514871215");
//CL.UpdateClientById(2, "гномик", "пупсочик", null, "+792532342");
//CL.DeleteClientById(2);
var E = new EmployeeManager();
var EDTO = new EmployeeDTO()
{
    FirstName = "Карина",
    LastName = "Быстрова",
    Phone = "+79821247892"
};
//E.AddEmployee(EDTO);
var WA = new WorkAreaManager();
var WADTO = new WorkAreaDTO()
{
    Name = "Морской"
};
WA.AddWorkArea(WADTO);
var A = new AddressManager();
var ADTO = new AddressDTO()
{
    Street = "Невский",
    Building = "пятая парадная",
    Room = "12",
    WorkAreaId = 1
};
//A.AddAddress(ADTO);
//Console.WriteLine(E.GetAllEmployeesInfoById(1));
Console.WriteLine(E.GetOrderHistoryOfTheEmployeeById(1));
//Console.WriteLine(E.GetEmployeeByID(1));
var WT = new WorkTimeManager();
var WTDTO = new WorkTimeDTO()
{
    Date = new DateTime(2022, 06, 02),
    StartTime = new TimeSpan(12, 30, 00),
    FinishTime = new TimeSpan(20, 00, 00),
    EmployeeId = 1
};
//List<WorkTimeDTO> test = WT.GetAllWorkTimes();
var S = new ServiceManager();
var SDTO = new ServiceDTO()
{
    Name = "химчистка диванов",
    Description = "обработка шампунем",
    Price = 30,
    CommercialPrice = 40,
    Unit = "м2",
    EstimatedTime = new TimeSpan(02, 00, 00)
};
var O = new OrderManager();
var ODTO = new OrderDTO()
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
//O.AddOrder(ODTO);
var C = new ClientManager();
var CDTO = new ClientDTO()
{
    FirstName = "Маша",
    LastName = "Иванова",
    Email = "@fgmn",
    Phone = "+79851476512"
};
//C.AddClient (CDTO);
//ST.AddServiceType(STDTO);
//S.AddService(SDTO);
//WT.AddWorkTime(WTDTO);
//WT.DeleteWorkTimeById(WTDTO);
//Console.WriteLine(WT.GetWorkTimeById(1));
//WT.ChangeEmployeeScheduleByEmployeeIdByDate(WTDTO);
//foreach (var i in test)
//{
//    i.ToString();
//    Console.WriteLine(i.ToString());
//}
//var E = new EmployeeManager();
////E.AddEmployee("Вася", "Петров", "+79514521271");
//var WT = new WorkTimeManager();
//var WTDTO = new WorkTimeDTO()
//{
//    Date = new DateTime(2022, 06, 02),
//    StartTime = new TimeSpan(12,30,00),
//    FinishTime = new TimeSpan(20,00,00),
//    EmployeeId = 1
//};
//List<WorkTimeDTO> test = WT.GetAllWorkTimes();
////WT.AddWorkTime(WTDTO);
////WT.DeleteWorkTimeById(WTDTO);
////Console.WriteLine(WT.GetWorkTimeById(1));
////WT.ChangeEmployeeScheduleByEmployeeIdByDate(WTDTO);
//foreach (var i in test)
//{
//    i.ToString();
//    Console.WriteLine(i.ToString());
//}

var SO = new ServiceOrderManager();

var q = SO.GetById(2);

Console.WriteLine(q);
//foreach (var i in test)
//{
//    i.ToString();
//    Console.WriteLine(i.ToString());
//}