using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using BTLONKY5.Models;

namespace BTLONKY5.Models
{
    public class QLDBcontext : DbContext
    {
        public QLDBcontext(DbContextOptions<QLDBcontext> options): base(options) { }
        public DbSet<Account> Accounts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable("tbAccount");
        }
        public DbSet<BTLONKY5.Models.Food> Food { get; set; } = default!;
    }   
}
