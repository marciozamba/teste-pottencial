using Pottencial.Core.Model.DTOs.Vendedor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pottencial.Core.Model.DTOs.Produto
{
    public class VendaDTO
    {
        public int Id { get; set; }

        public DateTime DataVenda { get; set; }

        public string StatusVenda { get; set; }

        public VendedorDTO Vendedor { get; set; }

        public List<ProdutoDTO> Produtos { get; set; }
    }
}
