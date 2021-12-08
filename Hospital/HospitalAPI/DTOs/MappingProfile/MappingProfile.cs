using AutoMapper;
using HospitalClassLibrary.GraphicalEditor.Models;
using HospitalClassLibrary.RoomEquipment.Models;

namespace HospitalAPI.DTOs.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EquipmentDto, Equipment>();
            CreateMap<RoomEquipmentDto, Equipment>();
            CreateMap<RoomDto, Room>();
            CreateMap<EquipmentTransferDto, EquipmentTransfer>();

            CreateMap<Equipment, EquipmentDto>();
            CreateMap<Equipment, RoomEquipmentDto>();
            CreateMap<Room, RoomDto>().IncludeMembers(r => r.RoomDimensions);
            CreateMap<RoomDimensions, RoomDto>();
            CreateMap<EquipmentTransfer, EquipmentTransferDto>();
        }
    }
}
