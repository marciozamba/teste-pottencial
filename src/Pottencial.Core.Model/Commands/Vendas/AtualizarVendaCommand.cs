using MediatR;
using Pottencial.Core.Model.Commands.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pottencial.Core.Model.Commands.Vendas
{
    public class AtualizarVendaCommand : IRequest<CommandResult>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int StatusVenda { get; set; }
    }
}
