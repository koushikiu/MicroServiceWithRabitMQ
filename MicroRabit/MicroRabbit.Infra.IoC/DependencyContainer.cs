using MediatR;
using MicroRabbit.Transfer.Application.Services;
using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Data.Repository;
using MicroRabbit.Transfer.Domain.EventHandlers;
using MicroRabit.Banking.Application.services;
using MicroRabit.Banking.Data.Context;
using MicroRabit.Banking.Data.Repository;
using MicroRabit.Banking.Domain.CommandHandler;
using MicroRabit.Banking.Domain.Commands;
using MicroRabit.Domain.Core.Bus;
using MicroRabit.Infra.Bus;
using MicroRabit.Transfer.Domain.Events;
using Microsoft.EntityFrameworkCore;
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

            //Domain Events

            services.AddTransient<IEventHandler<TrnasferCreatedEvent>, TrnasferEventHandler>();

            //ApplicationService
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITransferService, TransferService >();

            //Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransferRepository, TrnasferRepository>();
            services.AddTransient<BankingDbContext>();
            services.AddTransient<TransferDbContext>();
        }
    }
}
