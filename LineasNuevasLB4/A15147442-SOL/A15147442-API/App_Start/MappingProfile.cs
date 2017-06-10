using AutoMapper;
using A15147442_ENT.Entities;
using A15147442_API.DTO;

namespace A15147442_API.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Distrito, DistritoDTO>();
            CreateMap<DistritoDTO, Distrito>();

            CreateMap<Provincia, ProvinciaDTO>();
            CreateMap<ProvinciaDTO, Provincia>();

            CreateMap<Trabajador, TrabajadorDTO>();
            CreateMap<TrabajadorDTO, Trabajador>();

            CreateMap<Departamento, DepartamentoDTO>();
            CreateMap<DepartamentoDTO, Departamento>();

            CreateMap<Contrato, ContratoDTO>();
            CreateMap<ContratoDTO, Contrato>();

        }
    }
}