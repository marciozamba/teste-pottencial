using System;
using System.Collections.Generic;
using System.Text;

namespace Pottencial.Infra.Data.Entities
{
    public class TabelaVenda
    {
        public TabelaVenda()
        {
            Produtos = new List<TabelaProduto>();
        }

        public int Id { get; set; }

        public DateTime DataVenda { get; set; }

        public int StatusVenda { get; set; }

        public int VendedorId { get; set; }

        public virtual TabelaVendedor Vendedor { get; set; }

        public virtual IList<TabelaProduto> Produtos { get; set; }
    }
}
