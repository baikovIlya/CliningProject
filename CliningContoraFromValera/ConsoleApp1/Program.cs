using CliningContoraFromValera.DAL;
using CliningContoraFromValera.DAL.DTOs;

//var CL = new ClientManager();

//List<ClientDTO> test = CL.GetAllClients();

//CL.AddClient(3, "малыш", "пупсович", "mfkssd", "+799992332");
//CL.UpdateClientById(3, "гномик", "пупсочик", "вонючкин", "+792532342");
//CL.DeleteClientById(3);

//foreach (var i in test)
//{
//    i.ToString();
//    Console.WriteLine(i.ToString());
//}

var SM = new ServiceManager();

//List<ServiceDTO> service = SM.GetAllServices();

//foreach (var i in service)
//{
//    i.ToString();
//    Console.WriteLine(i.ToString());
//}

Console.WriteLine(SM.GetServicetById(3));

SM.UpdateServiceById(4, "xbcnbv", "qqqqqqqqqqqqqqqqqqqqqqq", 1000, 2333, "v2", 1, "12");
SM.DeleteServiceById(1);