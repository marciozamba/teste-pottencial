using System;
using System.Collections.Generic;
using System.Text;

namespace Pottencial.Infra.Data.Entities
{
    public class TabelaVendedor
    {
        public TabelaVendedor()
        {
            Venda = new List<TabelaVenda>();
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public virtual IList<TabelaVenda> Venda { get; set; }
    }
}
