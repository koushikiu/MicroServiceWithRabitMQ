using MediatR;
using MicroRabit.Banking.Domain.Commands;
using MicroRabit.Banking.Domain.Events;
using MicroRabit.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroRabit.Banking.Domain.CommandHandler
{
    public class TransferCommandHandler : IRequestHandler<CreateTransferCommand, bool>
    {
        private readonly IEventBus _bus;

        public TransferCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            _bus.Puslish(new TrnasferCreatedEvent(request.To, request.From, request.Amount));
            return Task.FromResult(true);
        }
    }
}
