using Pottencial.Core.Model.Commands.Base;
using Pottencial.Core.Model.Commands.Vendas;
using Pottencial.Core.Model.DTOs.Produto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pottencial.Application.Interfaces
{
    public interface IVendaService
    {
        Task<VendaDTO> BuscarVenda(int id);

        Task<List<VendaDTO>> ListarVendas();

        Task<CommandResult> RegistrarVenda(InserirVendaCommand command);

        Task<CommandResult> AtualizarVenda(AtualizarVendaCommand command);
    }
}
