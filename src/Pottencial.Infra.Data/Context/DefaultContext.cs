using Microsoft.EntityFrameworkCore;
using Pottencial.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Pottencial.Infra.Data.Context
{
    public class DefaultContext : DbContext
    {
        public string ConnectionString = "data source=MARCIO-NB\\SQLEXPRESS;initial catalog = Pottencial; persist security info=True;Integrated Security = SSPI;";

        public DbSet<TabelaVenda> TabelaVenda { get; set; }
        public DbSet<TabelaProduto> TabelaProduto { get; set; }
        public DbSet<TabelaVendedor> TabelaVendedor { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(ConnectionString);
        }
    }
}
