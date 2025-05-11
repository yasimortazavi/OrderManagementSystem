using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace PaymentService.Data
{
    public class PaymentDbContext : DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options) { }

        public DbSet<Payment> payments { get; set; }
    }
}


