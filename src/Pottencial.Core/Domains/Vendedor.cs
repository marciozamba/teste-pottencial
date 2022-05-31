using Pottencial.Core.Domains.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pottencial.Core.Domains
{
    public class Vendedor : EntityBase
    {
        public Vendedor()
        {

        }

        public Vendedor(string nome, string cpf, string email, string telefone)
        {
            Nome = nome;
            CPF = cpf;
            Email = email;
            Telefone = telefone;
        }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }
    }
}
