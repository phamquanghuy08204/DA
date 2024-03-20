using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace BTLONKY5.Models
{
    public class QLDBcontext : DbContext
    {
        public QLDBcontext(DbContextOptions<QLDBcontext> options): base(options) { }
        public DbSet<Account> Accounts { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable("Account");
        }
    }   
}
