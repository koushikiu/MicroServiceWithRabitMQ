using MediatR;
using MicroRabit.Banking.Application.services;
using MicroRabit.Banking.Data.Context;
using MicroRabit.Banking.Data.Repositpry;
using MicroRabit.Banking.Domain.CommandHandler;
using MicroRabit.Banking.Domain.Commands;
using MicroRabit.Domain.Core.Bus;
using MicroRabit.Infra.Bus;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabit.Infra.IoC
{
   public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //DomainBus
            services.AddTransient<IEventBus, RabitMQBus>();

            //Domain BankingCommands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            //ApplicationService
            services.AddTransient<IAccountService, AccountService>();

            //Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<BankingDbContext>();
        }
    }
}
