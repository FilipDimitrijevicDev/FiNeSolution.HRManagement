using AutoMapper;
using Core.Application.Common.Models;
using Core.Application.Common.Models.DTOs;

namespace Core.Application.Common.MappingProfiles
{
    public class LeaveRequestProfile : Profile
    {
        public LeaveRequestProfile()
        {
            CreateMap<Domain.LeaveRequest, LeaveRequest>().ReverseMap();
            CreateMap<Domain.LeaveRequest, LeaveRequestListDto>()
                .ForMember(dest => dest.RequestingEmployeeId,
                       opt => opt.MapFrom(src => Guid.Parse(src.RequestingEmployeeId))); 
            CreateMap<Domain.LeaveRequest, LeaveRequestDetailsDto>();
        }
    }
}
