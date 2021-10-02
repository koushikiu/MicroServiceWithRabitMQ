using MicroRabit.Domain.Core.Bus;
using MicroRabit.Transfer.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Transfer.Domain.EventHandlers
{
    public class TrnasferEventHandler : IEventHandler<TrnasferCreatedEvent>
    {
        public TrnasferEventHandler()
        {

        }

        public Task Handle(TrnasferCreatedEvent @event)
        {
            return Task.CompletedTask;
        }
    }
}
