using AutoMapper;
using Pottencial.Core.Interfaces.Queries;
using Pottencial.Core.Model.DTOs.Produto;
using Pottencial.Infra.Data.Context;
using Pottencial.Infra.Data.Entities;
using Pottencial.Infra.Data.Queries.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pottencial.Infra.Data.Queries
{
    public class VendaQuery : BaseQuery<VendaDTO, TabelaVenda>, IVendaQuery
    {
        public VendaQuery(DefaultContext context, IMapper imapper) : base(context, imapper)
        {
        }

        public async Task<VendaDTO> ObterPorId(int id)
        {
            return await Get(x => x.Id == id);
        }

        public async Task<List<VendaDTO>> Listar()
        {
            return await GetList();
        }
    }
}
