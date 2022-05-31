using Flunt.Validations;
using Pottencial.Core.Domains;
using Pottencial.Core.Enums;
using Pottencial.Core.Handlers.Base;
using Pottencial.Core.Helpers;
using Pottencial.Core.Interfaces.Repositories;
using Pottencial.Core.Interfaces.UoW;
using Pottencial.Core.Model.Commands.Base;
using Pottencial.Core.Model.Commands.Vendas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pottencial.Core.Handlers.Vendas
{
    public class AtualizarVendaHandler : CommandHandler<AtualizarVendaCommand, CommandResult>
    {
        private readonly IVendaRepository _produtoRepository;

        public AtualizarVendaHandler(IUnitOfWork unitOfWork, IVendaRepository produtoRepository) 
            : base(unitOfWork)
        {
            _produtoRepository = produtoRepository;
        }

        public override async Task<CommandResult> Handle(AtualizarVendaCommand command, CancellationToken cancellationToken)
        {
            var venda = await _produtoRepository.Obter(command.Id);

            await Validate(command, venda);

            if (Invalid)
                return new CommandResult(false, erros: ValidationErrors);

            venda.StatusVenda = command.StatusVenda;

            await _produtoRepository.Atualizar(venda);

            await Commit();

            return new CommandResult(true);
        }

        private async Task Validate(AtualizarVendaCommand command, Venda venda)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(command.Id, 0, nameof(command.Id), "Id da venda vazio.")
                .IsGreaterThan(command.StatusVenda, 0, nameof(command.StatusVenda), "O status enviado não pode ser 0.")
            );

            if (command.Id != 0 && command.StatusVenda != 0)
            {
                StatusVenda statusOrigem = (StatusVenda)venda.StatusVenda;
                StatusVenda statusDestino = new StatusVenda();

                if (EnumHelper.ValidaEnum(command.StatusVenda, statusDestino) == false)
                {
                    AddNotification(nameof(command.StatusVenda), "Status de venda inválido.");
                }
                else
                {
                    statusDestino = (StatusVenda)command.StatusVenda;

                    if (statusOrigem.Equals(statusDestino))
                    {
                        AddNotification(nameof(command.StatusVenda), "Status de venda selecionado é igual ao mesmo já cadastrado.");
                    }
                    else if (ValidarPermissaoDeStatus(statusOrigem, statusDestino) == false)
                    {
                        string statusOrigemString = EnumHelper.GetDescription(statusOrigem);
                        string statusDestinoString = EnumHelper.GetDescription(statusDestino);

                        AddNotification(nameof(command.StatusVenda), $"Não é permitido mudar o status de {statusOrigemString} para {statusDestinoString}.");
                    }
                }
            }
        }

        private bool ValidarPermissaoDeStatus(StatusVenda statusOrigem, StatusVenda statusDestino)
        {
            switch (statusOrigem)
            {
                case StatusVenda.AguardandoPagamento:
                    return 
                        statusDestino == StatusVenda.PagamentoAprovado || 
                        statusDestino == StatusVenda.Cancelada ? true : false;
                case StatusVenda.PagamentoAprovado:
                    return
                        statusDestino == StatusVenda.EnviadoTransportadora ||
                        statusDestino == StatusVenda.Cancelada ? true : false;
                case StatusVenda.EnviadoTransportadora:
                    return 
                        statusDestino == StatusVenda.Entregue ? true : false;
                default:
                    return false;
            }
        }
    }
}
