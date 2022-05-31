using MediatR;
using Pottencial.Core.Model.Commands.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pottencial.Core.Model.Commands.Vendas
{
    public class InserirVendaCommand : IRequest<CommandResult>
    {
        public InserirVendaCommand()
        {
            Produtos = new List<InserirProdutosCommand>();
        }

        [Required]
        public InserirDadosVendedorCommand Vendedor { get; set; }

        [Required]
        public List<InserirProdutosCommand> Produtos { get; set; }
    }

    public class InserirProdutosCommand
    {
        [Required]
        public string Nome { get; set; }
    }

    public class InserirDadosVendedorCommand
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string CPF { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Telefone { get; set; }
    }
}
