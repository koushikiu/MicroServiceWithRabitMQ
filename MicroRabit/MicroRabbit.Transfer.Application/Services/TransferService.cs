using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Domain.Models;
using MicroRabit.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Transfer.Application.Services
{
    public class TransferService : ITransferService
    {
        private readonly ITransferRepository _transferRepository;
        private readonly IEventBus _bus;
        public TransferService(ITransferRepository transferRepository, IEventBus bus)
        {
            _transferRepository = transferRepository;
            _bus = bus;
        }
        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _transferRepository.GetTrnasferLogs();
        }
    }
}
public interface ITransferService
{
    IEnumerable<TransferLog> GetTransferLogs();
}
