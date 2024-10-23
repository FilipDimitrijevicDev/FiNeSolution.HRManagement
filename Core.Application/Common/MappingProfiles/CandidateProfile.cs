using AutoMapper;
using Core.Application.Common.Models.DTOs;

namespace Core.Application.Common.MappingProfiles;

public class CandidateProfile : Profile
{
    public CandidateProfile()
    {
        CreateMap<Domain.Candidate, CandidateDto>().ReverseMap();
    }
}
