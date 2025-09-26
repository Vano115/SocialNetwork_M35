using AutoMapper;
using System.Net;
using SocialNetwork_M35.Data.Entityes;
using SocialNetwork_M35.Models.Account;

namespace SocialNetwork_M35.Services
{
    public class MappingProfile : Profile
    {
        /// <summary>
        /// В конструкторе настроим соответствие сущностей при маппинге
        /// </summary>
        public MappingProfile()
        {
            CreateMap<RegisterViewModel, User>().ForMember(d => d.UserName,
                    opt => opt.MapFrom(r => r.Login));

            /*
            CreateMap<Address, AddressInfo>();

            // Тут идёт настройка сопоставления сущностей
            // Явно указываем что m.AddressInfo будет соответствовать строке из HomeOptions - Address
            CreateMap<HomeOptions, InfoResponse>()
                .ForMember(m => m.AddressInfo,
                    opt => opt.MapFrom(src => src.Address));

            // Валидация запросов:
            CreateMap<AddDeviceRequest, Device>()
                .ForMember(d => d.Location,
                    opt => opt.MapFrom(r => r.RoomLocation));

            CreateMap<AddRoomRequest, Room>();
            CreateMap<Device, DeviceView>();*/
        }
    }
}
