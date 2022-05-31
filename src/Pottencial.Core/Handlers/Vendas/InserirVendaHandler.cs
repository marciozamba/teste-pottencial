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
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pottencial.Core.Handlers.Vendas
{
    public class InserirVendaHandler : CommandHandler<InserirVendaCommand, CommandResult>
    {
        private readonly IVendaRepository _produtoRepository;

        public InserirVendaHandler(IUnitOfWork unitOfWork, IVendaRepository produtoRepository) 
            : base(unitOfWork)
        {
            _produtoRepository = produtoRepository;
        }

        public override async Task<CommandResult> Handle(InserirVendaCommand command, CancellationToken cancellationToken)
        {
            await Validate(command);

            if (Invalid)
                return new CommandResult(false, erros: ValidationErrors);

            var vendedor = new Vendedor(command.Vendedor.Nome, command.Vendedor.CPF, command.Vendedor.Email, command.Vendedor.Telefone);
            var produtos = new List<Produto>(command.Produtos.Select(x => new Produto(x.Nome)));

            var venda = new Venda(DateTime.Now, (int)StatusVenda.AguardandoPagamento, vendedor, produtos); 

            var result = await _produtoRepository.Inserir(venda);
            await Commit();

            return new CommandResult(true, result.Valor);
        }

        private async Task Validate(InserirVendaCommand command)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(command.Produtos.Count, 0, nameof(command.Produtos), "Os produtos são obrigatórios.")
                .IsNotNull(command.Vendedor, nameof(command.Vendedor), "O vendedor é obrigatório.")
            );

            if (command.Vendedor != null)
            {
                command.Vendedor.Telefone = ValidadorHelper.ValidaTelefone(command.Vendedor.Telefone);
                command.Vendedor.CPF = ValidadorHelper.ValidaTelefone(command.Vendedor.CPF);

                AddNotifications(new Contract()
                    .Requires()
                    .IsEmailOrEmpty(command.Vendedor.Email, nameof(command.Vendedor.Email), "O e-mail do vendedor é obrigatório.")
                    .IsNotNullOrEmpty(command.Vendedor.Telefone, nameof(command.Vendedor.Telefone), "O telefone do vendedor é obrigatório.")
                    .IsNotNullOrEmpty(command.Vendedor.CPF, nameof(command.Vendedor.CPF), "O CPF do vendedor é obrigatório.")
                    .IsNotNullOrEmpty(command.Vendedor.Nome, nameof(command.Vendedor.Nome), "O nome do vendedor é obrigatório.")
                    .HasMaxLen(command.Vendedor.Email, 50, nameof(command.Vendedor.Email), "O e-mail do vendedor suporta até 50 caracteres.")
                    .HasMaxLen(command.Vendedor.Telefone, 11, nameof(command.Vendedor.Telefone), "O número de telefone do vendedor suporta até 11 caracteres.")
                    .HasMaxLen(command.Vendedor.CPF, 11, nameof(command.Vendedor.CPF), "O número de CPF do vendedor suporta até 11 caracteres.")
                    .HasMaxLen(command.Vendedor.Nome, 50, nameof(command.Vendedor.Nome), "O nome do vendedor suporta até 50 caracteres.")
                    .HasMinLen(command.Vendedor.Nome, 5, nameof(command.Vendedor.Nome), "O nome do vendedor precisa ter no mínimo 5 caracteres.")
                );
            }

            if(command.Produtos.Count > 0)
            {
                foreach (var produto in command.Produtos)
                {
                    AddNotifications(new Contract()
                       .Requires()
                       .IsNotNullOrEmpty(produto.Nome, nameof(produto.Nome), "O nome do produto é obrigatório.")
                       .HasMinLen(produto.Nome, 3, nameof(produto.Nome), "O nome do produto precisa ter no mínimo 3 caracteres.")
                       .HasMaxLen(produto.Nome, 20, nameof(produto.Nome), "O nome do produto suporta até 50 caracteres.")
                    );
                }
            }
        }
    }
}
