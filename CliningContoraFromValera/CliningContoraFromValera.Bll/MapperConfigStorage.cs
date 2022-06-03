using AutoMapper;
using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.DTOs;

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
                cfg.CreateMap<ClientDTO, ClientModel>().ReverseMap();

                cfg.CreateMap<OrderDTO, OrderModel>();

                cfg.CreateMap<ServiceDTO, ServiceModel>();

                cfg.CreateMap<WorkAreaDTO, WorkAreaModel>();

                cfg.CreateMap<EmployeeDTO, EmployeeModel>();

                cfg.CreateMap<AddressDTO, AddressModel>();

                cfg.CreateMap<WorkTimeDTO, WorkTimeModel>().ReverseMap();

                cfg.CreateMap<EmployeeDTO, EmployeeWorkTimeModel>()
                .ForMember("FirstName", opt => opt.MapFrom(c => c.FirstName))
                .ForMember("LastName", opt => opt.MapFrom(c => c.LastName))
                .ForMember(pts => pts.Date, opt => opt.MapFrom(ps => ps.WorkTime!.Date))
                .ForMember(pts => pts.StartTime, opt => opt.MapFrom(ps => ps.WorkTime!.StartTime))
                .ForMember(pts => pts.FinishTime, opt => opt.MapFrom(ps => ps.WorkTime!.FinishTime));

            })); 
        }

    }
}
