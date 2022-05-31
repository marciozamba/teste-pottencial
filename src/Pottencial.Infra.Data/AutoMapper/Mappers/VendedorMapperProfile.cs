using Pottencial.Core.Domains;
using Pottencial.Core.Model.DTOs.Vendedor;
using Pottencial.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pottencial.Infra.Data.AutoMapper.Mappers
{
    public class VendedorMapperProfile : ProfileBase
    {
        public VendedorMapperProfile()
        {
            CreateMap<TabelaVendedor, Vendedor>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.Nome, opt => opt.MapFrom(src => src.Nome))
            .ForMember(x => x.CPF, opt => opt.MapFrom(src => src.CPF))
            .ForMember(x => x.Telefone, opt => opt.MapFrom(src => src.Telefone))
            .ForMember(x => x.Email, opt => opt.MapFrom(src => src.Email))
            .ReverseMap();

            CreateMap<TabelaVendedor, VendedorDTO>()
            .ForMember(x => x.Nome, opt => opt.MapFrom(src => src.Nome))
            .ForMember(x => x.CPF, opt => opt.MapFrom(src => src.CPF))
            .ForMember(x => x.Telefone, opt => opt.MapFrom(src => src.Telefone))
            .ForMember(x => x.Email, opt => opt.MapFrom(src => src.Email))
            .ReverseMap();
        }
    }
}
