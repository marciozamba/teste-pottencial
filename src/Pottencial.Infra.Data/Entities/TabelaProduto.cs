using System;
using System.Collections.Generic;
using System.Text;

namespace Pottencial.Infra.Data.Entities
{
    public class TabelaProduto
    {
        public int Id { get; set; }

        public int VendaId { get; set; }

        public string Nome { get; set; }

        public virtual TabelaVenda Venda { get; set; }    
    }
}
