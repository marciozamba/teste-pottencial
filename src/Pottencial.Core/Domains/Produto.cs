using Pottencial.Core.Domains.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pottencial.Core.Domains
{
    public class Produto : EntityBase
    {
        public Produto()
        {

        }

        public Produto(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }
    }
}
