using AutoMapper;
using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.Dtos;

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
                cfg.CreateMap<ClientDto, ClientModel>().ReverseMap();

                cfg.CreateMap<OrderDto, OrderModel>();

                cfg.CreateMap<ServiceDto, ServiceModel>();

                cfg.CreateMap<WorkAreaDto, WorkAreaModel>();

                cfg.CreateMap<EmployeeDto, EmployeeModel>().ReverseMap();

                cfg.CreateMap<AddressDto, AddressModel>();

                cfg.CreateMap<WorkTimeDto, WorkTimeModel>();

                cfg.CreateMap<EmployeeDto, EmployeeWorkTimeModel>()
                .ForMember("FirstName", opt => opt.MapFrom(c => c.FirstName))
                .ForMember("LastName", opt => opt.MapFrom(c => c.LastName))
                .ForMember(pts => pts.Date, opt => opt.MapFrom(ps => ps.WorkTime!.Date))
                .ForMember(pts => pts.StartTime, opt => opt.MapFrom(ps => ps.WorkTime!.StartTime))
                .ForMember(pts => pts.FinishTime, opt => opt.MapFrom(ps => ps.WorkTime!.FinishTime));

            })); 
        }

    }
}
