using MediatR;
using Pottencial.Application.Interfaces;
using Pottencial.Core.Interfaces.Queries;
using Pottencial.Core.Model.Commands.Base;
using Pottencial.Core.Model.Commands.Vendas;
using Pottencial.Core.Model.DTOs.Produto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pottencial.Application.Services
{
    public class VendaService : IVendaService
    {
        private readonly IMediator _mediator;
        private readonly IVendaQuery _vendaQuery;

        public VendaService(IMediator mediator, IVendaQuery vendaQuery)
        {
            _mediator = mediator;
            _vendaQuery = vendaQuery;
        }

        public async Task<CommandResult> AtualizarVenda(AtualizarVendaCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<VendaDTO> BuscarVenda(int id)
        {
            return await _vendaQuery.ObterPorId(id);
        }

        public async Task<List<VendaDTO>> ListarVendas()
        {
            return await _vendaQuery.Listar();
        }

        public async Task<CommandResult> RegistrarVenda(InserirVendaCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
