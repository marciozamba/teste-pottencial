using Pottencial.Core.Domains;
using Pottencial.Core.Enums;
using Pottencial.Core.Helpers;
using Pottencial.Core.Model.DTOs.Produto;
using Pottencial.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pottencial.Infra.Data.AutoMapper.Mappers
{
    public class VendaMapperProfile : ProfileBase
    {
        public VendaMapperProfile()
        {
            CreateMap<TabelaVenda, Venda>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.StatusVenda, opt => opt.MapFrom(src => src.StatusVenda))
            .ForMember(x => x.DataVenda, opt => opt.MapFrom(src => src.DataVenda))
            .ForMember(x => x.Produtos, opt => opt.MapFrom(src => src.Produtos))
            .ForMember(x => x.Vendedor, opt => opt.MapFrom(src => src.Vendedor))
            .ReverseMap();

            CreateMap<TabelaVenda, VendaDTO>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.StatusVenda, opt => opt.MapFrom(src => EnumHelper.GetDescription((StatusVenda)src.StatusVenda)))
            .ForMember(x => x.DataVenda, opt => opt.MapFrom(src => src.DataVenda))
            .ForMember(x => x.Produtos, opt => opt.MapFrom(src => src.Produtos))
            .ForMember(x => x.Vendedor, opt => opt.MapFrom(src => src.Vendedor));

            CreateMap<VendaDTO, TabelaVenda>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.StatusVenda, opt => opt.MapFrom(src => src.StatusVenda))
            .ForMember(x => x.DataVenda, opt => opt.MapFrom(src => src.DataVenda))
            .ForMember(x => x.Produtos, opt => opt.MapFrom(src => src.Produtos))
            .ForMember(x => x.Vendedor, opt => opt.MapFrom(src => src.Vendedor));
        }
    }
}
