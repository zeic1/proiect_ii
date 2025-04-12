using Microsoft.EntityFrameworkCore;
using PharmacyApp.Models;
using System.Collections.Generic;

namespace PharmacyApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
