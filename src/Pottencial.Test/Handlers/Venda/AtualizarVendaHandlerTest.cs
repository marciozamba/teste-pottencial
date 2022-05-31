using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class AtualizarVendaHandlerTest
    {
        private readonly AtualizarVendaHandler _atualizarVendaHandler;

        public AtualizarVendaHandlerTest()
        {
            _atualizarVendaHandler = new AtualizarVendaHandler(new UnitOfWorkMock(), new VendaRepositoryMock());
        }

        [TestMethod]
        public void DeveRetornarSucesso()
        {
            var commandResult = _atualizarVendaHandler.Handle(new AtualizarVendaCommand
            {
                Id = 1,
                StatusVenda = 1
            }, default).Result;

            Assert.IsTrue(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroIdVazio()
        {
            var commandResult = _atualizarVendaHandler.Handle(new AtualizarVendaCommand
            {
                StatusVenda = 0
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroStatusVendaVazio()
        {
            var commandResult = _atualizarVendaHandler.Handle(new AtualizarVendaCommand
            {
                Id = 1
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroStatusVendaInvalido()
        {
            var commandResult = _atualizarVendaHandler.Handle(new AtualizarVendaCommand
            {
                Id = 1,
                StatusVenda = 10
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroStatusVendaDestinoEOrigemIgual()
        {
            var commandResult = _atualizarVendaHandler.Handle(new AtualizarVendaCommand
            {
                Id = 2,
                StatusVenda = 1
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }

        [TestMethod]
        public void ErroNaOrdemDeAlteracaoDeStatusVenda()
        {
            var commandResult = _atualizarVendaHandler.Handle(new AtualizarVendaCommand
            {
                Id = 1,
                StatusVenda = 3
            }, default).Result;

            Assert.IsFalse(commandResult.Sucesso);
        }
    }
}
