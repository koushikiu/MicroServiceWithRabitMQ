using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Transfer.Data.Repository
{
    public class TrnasferRepository : ITransferRepository
    {
        private readonly TransferDbContext _transferDbContext;
        public TrnasferRepository(TransferDbContext transferDbContext)
        {
            _transferDbContext = transferDbContext;
        }
        public IEnumerable<TransferLog> GetTrnasferLogs()
        {
            return _transferDbContext.transferLogs;
        }
    }
}

public interface ITransferRepository
{
    IEnumerable<TransferLog> GetTrnasferLogs();
}
