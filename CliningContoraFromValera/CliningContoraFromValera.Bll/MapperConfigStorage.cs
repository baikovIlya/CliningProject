using AutoMapper;
using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL;

namespace CliningContoraFromValera.Bll
{
    public class MapperConfigStorage
    {
        private static Mapper _instance;

        public static Mapper GetInstance()
        {
            if (_instance == null)
                InitializeInstance();
            return _instance;
        }

        private static void InitializeInstance()
        {
            _instance = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClientDTO,ClientModel>();
<<<<<<< HEAD
                cfg.CreateMap<OrderDTO, OrderModel>();
=======
                cfg.CreateMap<WorkAreaDTO, WorkAreaModel>();
>>>>>>> CC-52

            })); 
        }

    }
}
