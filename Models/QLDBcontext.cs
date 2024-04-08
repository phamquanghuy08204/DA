using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace BTLONKY5.Models
{
    public class QLDBcontext : DbContext
    {
        public QLDBcontext(DbContextOptions<QLDBcontext> options): base(options) { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillInfo> BillInfos { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public DbSet<BookingFood> BookingFoods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Statistics> Statistics { get; set; }
        public DbSet<Table> Tables { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable("tbAccount");
            modelBuilder.Entity<Bill>().ToTable("tbBill");
            modelBuilder.Entity<BillInfo>().ToTable("tbBillInfo");
            modelBuilder.Entity<Booking>().ToTable("tbBooking");
			modelBuilder.Entity<BookingFood>().ToTable("tbBookingFood");
			modelBuilder.Entity<Category>().ToTable("tbCategory");
            modelBuilder.Entity<Food>().ToTable("tbFood");
            modelBuilder.Entity<Statistics>().ToTable("tbStatistics");
            modelBuilder.Entity<Table>().ToTable("tbTable");
        }
    }   
}
