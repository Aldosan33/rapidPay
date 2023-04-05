using Microsoft.EntityFrameworkCore;
using RapidPay.Domain.Entities;

namespace RapidPay.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }

        public DbSet<FeeHistory> FeeHistories { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
