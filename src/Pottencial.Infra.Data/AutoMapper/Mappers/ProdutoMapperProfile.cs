using Pottencial.Core.Domains;
using Pottencial.Core.Model.DTOs.Produto;
using Pottencial.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pottencial.Infra.Data.AutoMapper.Mappers
{
    public class ProdutoMapperProfile : ProfileBase
    {
        public ProdutoMapperProfile()
        {
            CreateMap<TabelaProduto, Produto>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.Nome, opt => opt.MapFrom(src => src.Nome))
            .ReverseMap();

            CreateMap<TabelaProduto, ProdutoDTO>()
            .ForMember(x => x.Nome, opt => opt.MapFrom(src => src.Nome))
            .ReverseMap();
        }
    }
}
