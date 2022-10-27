using AlpacaFinanceApp.Data.Mapping;
using AlpacaFinanceApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpacaFinanceApp.Data
{
    public class AlpacaDbContext : DbContext
    {
        public AlpacaDbContext(DbContextOptions<AlpacaDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}