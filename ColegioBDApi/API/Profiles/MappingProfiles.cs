using API.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles(){

            CreateMap<Colegio,ColegioDto>().ReverseMap();
            CreateMap<Directivo,PersonaDto>().ReverseMap();
            CreateMap<Estudiante,PersonaDto>().ReverseMap();
            CreateMap<Profesor, PersonaDto>().ReverseMap();
        }
    }
}