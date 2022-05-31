using CliningContoraFromValera.Bll;
using AutoMapper;
using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL;

ClientDTO ClientDTO = new ClientDTO()
{
    Id = 4,
    FirstName = "asdasdas",
    LastName = "sadasdas",
    Email = "12e123423",
    Phone = "100"
};


MapperConfigStorage configStorage = new MapperConfigStorage();

AutoMapper.Mapper mapper = MapperConfigStorage.GetInstance();

ClientModel clientModel = mapper.Map<ClientModel>(ClientDTO);

Console.WriteLine();