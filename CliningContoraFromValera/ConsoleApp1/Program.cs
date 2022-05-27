using CliningContoraFromValera.DAL;

//var CL = new ClientManager();

//List<ClientDTO> test = CL.GetAllClients();

//CL.AddClient("малыш", "пупсович", "mfkssd", "+799992332");
//CL.AddClient("котик", "мяукович", "may", "+79514871215");
//CL.UpdateClientById(2, "гномик", "пупсочик", null, "+792532342");
//CL.DeleteClientById(2);
var E = new EmployeeManager();
//E.AddEmployee("Вася", "Петров", "+79514521271");
var WT = new WorkTimeManager();
List<WorkTimeDTO> test = WT.GetAllWorkTimes();
//WT.AddWorkTime("01.06.2022", "10.00", "22.00", 1);
//WT.AddWorkTime("02.06.2022", "11.00", "20.00", 1);
//WT.DeleteWorkTimeById(3);
WT.ChangeEmployeeScheduleByEmployeeIdByDate(1, new DateOnly(01,06,2022), new TimeOnly(08,00), new TimeOnly(12, 00));
foreach (var i in test)
{
    i.ToString();
    Console.WriteLine(i.ToString());
}