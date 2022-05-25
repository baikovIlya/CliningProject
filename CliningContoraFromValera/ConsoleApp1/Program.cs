using CliningContoraFromValera.DAL;

var CL = new ClientManager();

List<ClientDTO> test = CL.GetAllClients();

//CL.AddClient(3, "малыш", "пупсович", "mfkssd", "+799992332");
//CL.UpdateClientById(3, "гномик", "пупсочик", "вонючкин", "+792532342");
//CL.DeleteClientById(3);

foreach (var i in test)
{
    i.ToString();
    Console.WriteLine(i.ToString());
}