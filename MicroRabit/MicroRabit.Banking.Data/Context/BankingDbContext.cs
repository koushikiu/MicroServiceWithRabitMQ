using MicroRabit.Banking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabit.Banking.Data.Context
{
   public class BankingDbContext : DbContext
    {
        public BankingDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
    }
}
