using CliningContoraFromValera.DAL;

//var CL = new ClientManager();

//List<ClientDTO> test = CL.GetAllClients();

//CL.AddClient("малыш", "пупсович", "mfkssd", "+799992332");
//CL.AddClient("котик", "мяукович", "may", "+79514871215");
//CL.UpdateClientById(2, "гномик", "пупсочик", null, "+792532342");
//CL.DeleteClientById(2);
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

var SO = new OrderManager();

var q = SO.GetAllOrderInfo();

foreach (var i in q)
{
    i.ToString();
    Console.WriteLine(i.ToString());
}