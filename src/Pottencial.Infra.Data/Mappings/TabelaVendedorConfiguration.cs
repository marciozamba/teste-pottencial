using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pottencial.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pottencial.Infra.Data.Mappings
{
    public class TabelaVendedorConfiguration : IEntityTypeConfiguration<TabelaVendedor>
    {
        public void Configure(EntityTypeBuilder<TabelaVendedor> builder)
        {
            builder.ToTable("Vendedor");

            builder.HasKey(nameof(TabelaVendedor.Id));

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasMany(x => x.Venda).WithOne(x => x.Vendedor).HasForeignKey(x => x.VendedorId);
        }
    }
}
