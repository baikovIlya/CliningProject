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
                cfg.CreateMap<ClientDTO, ClientModel>()
                .ForMember("FirstName", opt => opt.MapFrom(c => c.FirstName))
                .ForMember("LastName", opt => opt.MapFrom(c => c.LastName))
                .ForMember("Email", opt => opt.MapFrom(c => c.Email))
                .ForMember("Phone", opt => opt.MapFrom(c => c.Phone)).ReverseMap();

                cfg.CreateMap<OrderDTO, OrderModel>();

                cfg.CreateMap<ServiceDTO, ServiceModel>()
                .ForMember("ServiceType", opt => opt.MapFrom(c => c.ServiceType))
                .ForMember("Name", opt => opt.MapFrom(c => c.Name))
                .ForMember("Description", opt => opt.MapFrom(c => c.Description))
                .ForMember("Price", opt => opt.MapFrom(c => c.Price))
                .ForMember("CommercialPrice", opt => opt.MapFrom(c => c.CommercialPrice))
                .ForMember("Unit", opt => opt.MapFrom(c => c.Unit))
                .ForMember("EstimatedTime", opt => opt.MapFrom(c => c.EstimatedTime));          

                cfg.CreateMap<WorkAreaDTO, WorkAreaModel>()
                .ForMember("Name", opt => opt.MapFrom(c => c.Name));

                cfg.CreateMap<EmployeeDTO, EmployeeModel>()
                .ForMember("FirstName", opt => opt.MapFrom(c => c.FirstName))
                .ForMember("LastName", opt => opt.MapFrom(c => c.LastName))
                .ForMember("Phone", opt => opt.MapFrom(c => c.Phone)).ReverseMap();

                cfg.CreateMap<WorkTimeDTO, WorkTimeModel>()
                .ForMember("Date", opt => opt.MapFrom(c => c.Date))
                .ForMember("StartTime", opt => opt.MapFrom(c => c.StartTime))
                .ForMember("FinishTime", opt => opt.MapFrom(c => c.FinishTime));

                cfg.CreateMap<WorkTimeDTO, WorkTimeModel>();

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
