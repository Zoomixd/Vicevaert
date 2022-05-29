using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vicevært.Domain.Entities;

namespace Vicevært.Infrastructure.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Vicevært.Domain.Entities.Rekvisition> Rekvisition { get; set; }
        public DbSet<Vicevært.Domain.Entities.Lejemaal> Lejemaal { get; set; }
        public DbSet<Vicevært.Domain.Entities.Lejer> Lejer { get; set; }
        public DbSet<Vicevært.Domain.Entities.Booking> Bookings { get; set; }
    }
}