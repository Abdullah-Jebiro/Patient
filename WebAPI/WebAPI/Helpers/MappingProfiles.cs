using AutoMapper;
using Model.DbEntities;
using Model.Dtos;

namespace WebApi.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PatientForAddDto,Patient>();
            CreateMap<PatientForUpdateDto,Patient>();
        }
    }
}