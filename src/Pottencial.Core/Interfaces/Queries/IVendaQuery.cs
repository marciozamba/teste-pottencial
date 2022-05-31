using Pottencial.Core.Domains;
using Pottencial.Core.Model.DTOs.Produto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pottencial.Core.Interfaces.Queries
{
    public interface IVendaQuery
    {
        Task<VendaDTO> ObterPorId(int id);

        Task<List<VendaDTO>> Listar();
    }
}
