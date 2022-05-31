using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pottencial.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pottencial.Infra.Data.Mappings
{
    public class TabelaProdutoConfiguration : IEntityTypeConfiguration<TabelaProduto>
    {
        public void Configure(EntityTypeBuilder<TabelaProduto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(nameof(TabelaProduto.Id));

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
