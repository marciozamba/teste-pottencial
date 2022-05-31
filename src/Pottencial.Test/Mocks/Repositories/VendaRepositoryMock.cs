using Pottencial.Core.Domains;
using Pottencial.Core.Interfaces.Repositories;
using Pottencial.Test.Mocks.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pottencial.Test.Mocks.Repositories
{
    public class VendaRepositoryMock : RepositoryBaseMock<Venda>, IVendaRepository
    {
        public override IEnumerable<Venda> PopulateEntities()
        {
            yield return new Venda
            {
                Id = 1,
                DataVenda = DateTime.Now.AddDays(1),
                StatusVenda = 0,
                Produtos = new List<Produto>
                {
                    new Produto
                    {
                        Id = 1,
                        Nome = "Pneu"
                    },
                    new Produto
                    {
                        Id = 2,
                        Nome = "Mesa"
                    }
                },
                Vendedor = new Vendedor()
                {
                    Id = 2,
                    CPF = "03285943234",
                    Email = "email@mail.com",
                    Nome = "Vendedor Teste",
                    Telefone = "51987653213"
                }
            };

            yield return new Venda
            {
                Id = 2,
                DataVenda = DateTime.Now.AddDays(3),
                StatusVenda = 1,
                Produtos = new List<Produto>
                {
                    new Produto
                    {
                        Id = 3,
                        Nome = "Arroz"
                    },
                    new Produto
                    {
                        Id = 4,
                        Nome = "Feijão"
                    }
                },
                Vendedor = new Vendedor()
                {
                    Id = 1,
                    CPF = "09736478654",
                    Email = "email002@mail.com",
                    Nome = "Vendedor Mário",
                    Telefone = "51987653546"
                }
            };
        }
    }
}
