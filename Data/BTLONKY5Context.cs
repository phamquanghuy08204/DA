using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BTLONKY5.Models;

namespace BTLONKY5.Data
{
    public class BTLONKY5Context : DbContext
    {
        public BTLONKY5Context (DbContextOptions<BTLONKY5Context> options)
            : base(options)
        {
        }

        public DbSet<BTLONKY5.Models.Booking> Booking { get; set; } = default!;
    }
}
