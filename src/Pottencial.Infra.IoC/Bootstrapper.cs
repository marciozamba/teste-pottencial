using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Pottencial.Application.Interfaces;
using Pottencial.Application.Services;
using Pottencial.Core.Handlers.Vendas;
using Pottencial.Core.Interfaces.Queries;
using Pottencial.Core.Interfaces.Repositories;
using Pottencial.Core.Interfaces.UoW;
using Pottencial.Core.Model.Commands.Base;
using Pottencial.Core.Model.Commands.Vendas;
using Pottencial.Infra.Data.AutoMapper;
using Pottencial.Infra.Data.Context;
using Pottencial.Infra.Data.Queries;
using Pottencial.Infra.Data.Repository;
using Pottencial.Infra.Data.UoW;

namespace Boticario.Infra.IoC
{
    public static class Bootstrapper
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<InserirVendaCommand, CommandResult>, InserirVendaHandler>();
            services.AddTransient<IRequestHandler<AtualizarVendaCommand, CommandResult>, AtualizarVendaHandler>();

            services.AddTransient<IVendaService, VendaService>();

            services.AddTransient<IVendaRepository, VendaRepository>();

            services.AddTransient<IVendaQuery, VendaQuery>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddScoped<DefaultContext>();

            services.RegisterMappings();
        }
    }
}
