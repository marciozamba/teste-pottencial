using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pottencial.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pottencial.Infra.Data.Mappings
{
    public class TabelaVendaConfiguration : IEntityTypeConfiguration<TabelaVenda>
    {
        public void Configure(EntityTypeBuilder<TabelaVenda> builder)
        {
            builder.ToTable("Venda");

            builder.HasKey(nameof(TabelaVenda.Id));

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasMany(x => x.Produtos).WithOne(x => x.Venda).HasForeignKey(x => x.VendaId);

            builder.HasOne(x => x.Vendedor).WithMany().HasForeignKey(x => x.VendedorId);
        }
    }
}
