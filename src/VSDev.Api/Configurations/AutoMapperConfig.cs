using AutoMapper;
using VSDev.Api.DTOs;
using VSDev.Business.Models;

namespace VSDev.Api.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Casa, CasaViewModel>().ReverseMap();
            CreateMap<DespesaIndividual, DespesaIndividualViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Morador, MoradorViewModel>().ReverseMap();
        }
    }
}
