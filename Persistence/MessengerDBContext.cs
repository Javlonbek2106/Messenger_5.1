using Domein.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class MessengerDBContext  : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<BunchOfAccount> BunchOfAccounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // here change  your password. 
            optionsBuilder.UseNpgsql("Server=localhost;port=5432;database=messanger_5.0;User Id=postgres;password=Jam2001!!!");
        }

    }
}
