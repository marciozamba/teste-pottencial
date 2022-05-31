using Pottencial.Core.Domains.Base;
using Pottencial.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pottencial.Core.Domains
{
    public class Venda : EntityBase
    {
        public Venda() { }

        public Venda(DateTime dataVenda, int statusVenda, Vendedor vendedor, List<Produto> produtos)
        {
            DataVenda = dataVenda;
            StatusVenda = statusVenda;
            Vendedor = vendedor;
            Produtos = produtos;
        }

        public DateTime DataVenda { get; set; }

        public int StatusVenda { get; set; }

        public Vendedor Vendedor { get; set; }

        public List<Produto> Produtos { get; set; }
    }
}
