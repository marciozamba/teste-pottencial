using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pottencial.Core.Domains;
using Pottencial.Core.Handlers.Vendas;
using Pottencial.Core.Model.Commands.Vendas;
using Pottencial.Test.Mocks;
using Pottencial.Test.Mocks.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pottencial.Test.Handlers.Venda
{
    [TestClass]
    public class InserirVendaHandlerTest
    {
        private readonly InserirVendaHandler _inserirVendaHandler;

        public InserirVendaHandlerTest()
        {
            _inserirVendaHandler = new InserirVendaHandler(new UnitOfWorkMock(), new VendaRepositoryMock());
        }

        [TestMethod]
        public void ErroListaProdutoVazia()
        {
            var commandResult = _inserirVendaHandler.Handle(new InserirVendaCommand
            {
                Vendedor = new InserirDadosVendedorCommand()
                {
                    CPF = "03285943234",
                    Email = "email@mail.com",
                    Nome = "Vendedor Teste",
                    Telefone = "51987653213"
                }
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroVendedorNull()
        {
            var commandResult = _inserirVendaHandler.Handle(new InserirVendaCommand
            {
                Produtos = new List<InserirProdutosCommand>
                {
                    new InserirProdutosCommand
                    {
                        Nome = "Pneu"
                    },
                    new InserirProdutosCommand
                    {
                        Nome = "Mesa"
                    }
                }
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroTelefoneInvalido()
        {
            var commandResult = _inserirVendaHandler.Handle(new InserirVendaCommand
            {
                Produtos = new List<InserirProdutosCommand>
                {
                    new InserirProdutosCommand
                    {
                        Nome = "Pneu"
                    },
                    new InserirProdutosCommand
                    {
                        Nome = "Mesa"
                    }
                },

                Vendedor = new InserirDadosVendedorCommand()
                {
                    CPF = "03285943234",
                    Email = "email@mail.com",
                    Nome = "Vendedor Teste",
                    Telefone = "PP007653213"
                }
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroCPFInvalido()
        {
            var commandResult = _inserirVendaHandler.Handle(new InserirVendaCommand
            {
                Produtos = new List<InserirProdutosCommand>
                {
                    new InserirProdutosCommand
                    {
                        Nome = "Pneu"
                    },
                    new InserirProdutosCommand
                    {
                        Nome = "Mesa"
                    }
                },

                Vendedor = new InserirDadosVendedorCommand()
                {
                    CPF = "PPP00943234",
                    Email = "email@mail.com",
                    Nome = "Vendedor Teste",
                    Telefone = "51987653213"
                }
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroEmailInvalido()
        {
            var commandResult = _inserirVendaHandler.Handle(new InserirVendaCommand
            {
                Produtos = new List<InserirProdutosCommand>
                {
                    new InserirProdutosCommand
                    {
                        Nome = "Pneu"
                    },
                    new InserirProdutosCommand
                    {
                        Nome = "Mesa"
                    }
                },

                Vendedor = new InserirDadosVendedorCommand()
                {
                    CPF = "PPP00943234",
                    Email = "email.mail.com",
                    Nome = "Vendedor Teste",
                    Telefone = "51987653213"
                }
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroCPFNullOuVazio()
        {
            var commandResult = _inserirVendaHandler.Handle(new InserirVendaCommand
            {
                Produtos = new List<InserirProdutosCommand>
                {
                    new InserirProdutosCommand
                    {
                        Nome = "Pneu"
                    },
                    new InserirProdutosCommand
                    {
                        Nome = "Mesa"
                    }
                },

                Vendedor = new InserirDadosVendedorCommand()
                {
                    Email = "email.mail.com",
                    Nome = "Vendedor Teste",
                    Telefone = "51987653213"
                }
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroNomeNullOuVazio()
        {
            var commandResult = _inserirVendaHandler.Handle(new InserirVendaCommand
            {
                Produtos = new List<InserirProdutosCommand>
                {
                    new InserirProdutosCommand
                    {
                        Nome = "Pneu"
                    },
                    new InserirProdutosCommand
                    {
                        Nome = "Mesa"
                    }
                },

                Vendedor = new InserirDadosVendedorCommand()
                {
                    CPF = "03285943234",
                    Email = "email@mail.com",
                    Telefone = "51987653213"
                }
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroEmailNullOuVazio()
        {
            var commandResult = _inserirVendaHandler.Handle(new InserirVendaCommand
            {
                Produtos = new List<InserirProdutosCommand>
                {
                    new InserirProdutosCommand
                    {
                        Nome = "Pneu"
                    },
                    new InserirProdutosCommand
                    {
                        Nome = "Mesa"
                    }
                },

                Vendedor = new InserirDadosVendedorCommand()
                {
                    CPF = "03285943234",
                    Telefone = "51987653213",
                    Nome = "Vendedor"
                }
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroTelefoneNullOuVazio()
        {
            var commandResult = _inserirVendaHandler.Handle(new InserirVendaCommand
            {
                Produtos = new List<InserirProdutosCommand>
                {
                    new InserirProdutosCommand
                    {
                        Nome = "Pneu"
                    },
                    new InserirProdutosCommand
                    {
                        Nome = "Mesa"
                    }
                },

                Vendedor = new InserirDadosVendedorCommand()
                {
                    CPF = "03285943234",
                    Email = "email@mail.com",
                    Nome = "Vendedor"
                }
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroNomeMaxLenght()
        {
            var commandResult = _inserirVendaHandler.Handle(new InserirVendaCommand
            {
                Produtos = new List<InserirProdutosCommand>
                {
                    new InserirProdutosCommand
                    {
                        Nome = "Pneu"
                    },
                    new InserirProdutosCommand
                    {
                        Nome = "Mesa"
                    }
                },

                Vendedor = new InserirDadosVendedorCommand()
                {
                    CPF = "03285943234",
                    Email = "email@mail.com",
                    Nome = "qwewqewqeqeeqweqwewqewqewqewqewqewqeqwewqewqewqewqewqe",
                    Telefone = "51987653213"
                }
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroEmailMaxLenght()
        {
            var commandResult = _inserirVendaHandler.Handle(new InserirVendaCommand
            {
                Produtos = new List<InserirProdutosCommand>
                {
                    new InserirProdutosCommand
                    {
                        Nome = "Pneu"
                    },
                    new InserirProdutosCommand
                    {
                        Nome = "Mesa"
                    }
                },

                Vendedor = new InserirDadosVendedorCommand()
                {
                    CPF = "03285943234",
                    Email = "qwewqewqeqeeqweqwewqewqewqewqewqewqeqwewqewqewqewqewqe@mail.com",
                    Nome = "Teste",
                    Telefone = "51987653213"
                }
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroTelefoneMaxLenght()
        {
            var commandResult = _inserirVendaHandler.Handle(new InserirVendaCommand
            {
                Produtos = new List<InserirProdutosCommand>
                {
                    new InserirProdutosCommand
                    {
                        Nome = "Pneu"
                    },
                    new InserirProdutosCommand
                    {
                        Nome = "Mesa"
                    }
                },

                Vendedor = new InserirDadosVendedorCommand()
                {
                    CPF = "03285943234",
                    Email = "teste@mail.com",
                    Nome = "Teste",
                    Telefone = "519876532143"
                }
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroCPFMaxLenght()
        {
            var commandResult = _inserirVendaHandler.Handle(new InserirVendaCommand
            {
                Produtos = new List<InserirProdutosCommand>
                {
                    new InserirProdutosCommand
                    {
                        Nome = "Pneu"
                    },
                    new InserirProdutosCommand
                    {
                        Nome = "Mesa"
                    }
                },

                Vendedor = new InserirDadosVendedorCommand()
                {
                    CPF = "03285545454943234",
                    Email = "teste@mail.com",
                    Nome = "Teste",
                    Telefone = "51987653213"
                }
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroNomeMinLenght()
        {
            var commandResult = _inserirVendaHandler.Handle(new InserirVendaCommand
            {
                Produtos = new List<InserirProdutosCommand>
                {
                    new InserirProdutosCommand
                    {
                        Nome = "Pneu"
                    },
                    new InserirProdutosCommand
                    {
                        Nome = "Mesa"
                    }
                },

                Vendedor = new InserirDadosVendedorCommand()
                {
                    CPF = "03285943234",
                    Email = "email@mail.com",
                    Nome = "quer",
                    Telefone = "51987653213"
                }
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroProdutoSemNome()
        {
            var commandResult = _inserirVendaHandler.Handle(new InserirVendaCommand
            {
                Produtos = new List<InserirProdutosCommand>
                {
                    new InserirProdutosCommand
                    {
                        
                    },
                    new InserirProdutosCommand
                    {
                        Nome = "Mesa"
                    }
                },

                Vendedor = new InserirDadosVendedorCommand()
                {
                    CPF = "03285943234",
                    Email = "email@mail.com",
                    Nome = "Teste",
                    Telefone = "51987653213"
                }
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroNomeProdutoMinLength()
        {
            var commandResult = _inserirVendaHandler.Handle(new InserirVendaCommand
            {
                Produtos = new List<InserirProdutosCommand>
                {
                    new InserirProdutosCommand
                    {
                        Nome = "O"
                    },
                    new InserirProdutosCommand
                    {
                        Nome = "Mesa"
                    }
                },

                Vendedor = new InserirDadosVendedorCommand()
                {
                    CPF = "03285943234",
                    Email = "email@mail.com",
                    Nome = "Teste",
                    Telefone = "51987653213"
                }
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroNomeProdutoMaxLenght()
        {
            var commandResult = _inserirVendaHandler.Handle(new InserirVendaCommand
            {
                Produtos = new List<InserirProdutosCommand>
                {
                    new InserirProdutosCommand
                    {
                        Nome = "qwewqewqeqeeqweqwewqewqewqewqewqewqeqwewqewqewqewqewqe"
                    },
                    new InserirProdutosCommand
                    {
                        Nome = "Mesa"
                    }
                },

                Vendedor = new InserirDadosVendedorCommand()
                {
                    CPF = "03285943234",
                    Email = "email@mail.com",
                    Nome = "Teste",
                    Telefone = "51987653213"
                }
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroVendaNulll()
        {
            var commandResult = _inserirVendaHandler.Handle(new InserirVendaCommand
            { }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void DeveRetornarSucesso()
        {
            var commandResult = _inserirVendaHandler.Handle(new InserirVendaCommand
            {
                Produtos = new List<InserirProdutosCommand>
                {
                    new InserirProdutosCommand
                    {
                        Nome = "Teste"
                    },
                    new InserirProdutosCommand
                    {
                        Nome = "Mesa"
                    }
                },

                Vendedor = new InserirDadosVendedorCommand()
                {
                    CPF = "03285943234",
                    Email = "email@mail.com",
                    Nome = "Teste",
                    Telefone = "51987653213"
                }
            }, default).Result;

            Assert.IsTrue(commandResult.Sucesso);
        }
    }
}
