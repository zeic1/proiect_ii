using Microsoft.EntityFrameworkCore;

using PharmacyManagementSystem.Models;

namespace PharmacyManagement.Data
{
    public class PharmacyDbContext : DbContext
    {
        public PharmacyDbContext(DbContextOptions<PharmacyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pharmacist> Pharmacists { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<LoginAttempt> LoginAttempts { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure entity mappings
            // Pharmacist
            modelBuilder.Entity<Pharmacist>()
                .ToTable("Pharmacists")
                .HasKey(p => p.PharmacistId);

            modelBuilder.Entity<Pharmacist>()
                .Property(p => p.PharmacistId)
                .HasColumnName("pharmacist_id");

            modelBuilder.Entity<Pharmacist>()
                .Property(p => p.FirstName)
                .HasColumnName("first_name")
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Pharmacist>()
                .Property(p => p.LastName)
                .HasColumnName("last_name")
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Pharmacist>()
                .Property(p => p.LicenseNumber)
                .HasColumnName("license_number")
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Pharmacist>()
                .Property(p => p.Email)
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Pharmacist>()
                .Property(p => p.ContactNumber)
                .HasColumnName("contact_number")
                .HasMaxLength(20);

            // Admin
            modelBuilder.Entity<Admin>()
                .ToTable("Admins")
                .HasKey(a => a.AdminId);

            modelBuilder.Entity<Admin>()
                .Property(a => a.AdminId)
                .HasColumnName("admin_id");

            modelBuilder.Entity<Admin>()
                .Property(a => a.Username)
                .HasColumnName("username")
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Admin>()
                .Property(a => a.Email)
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Admin>()
                .Property(a => a.PasswordHash)
                .HasColumnName("password_hash")
                .IsRequired()
                .HasMaxLength(256);

            modelBuilder.Entity<Admin>()
                .Property(a => a.Role)
                .HasColumnName("role")
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Admin>()
                .Property(a => a.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            // Login Attempts
            modelBuilder.Entity<LoginAttempt>()
                .ToTable("Login_Attempts")
                .HasKey(la => la.AttemptId);

            modelBuilder.Entity<LoginAttempt>()
                .Property(la => la.AttemptId)
                .HasColumnName("attempt_id");

            modelBuilder.Entity<LoginAttempt>()
                .Property(la => la.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            modelBuilder.Entity<LoginAttempt>()
                .Property(la => la.AttemptTime)
                .HasColumnName("attempt_time")
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<LoginAttempt>()
                .Property(la => la.IpAddress)
                .HasColumnName("ip_address")
                .HasMaxLength(45);

            modelBuilder.Entity<LoginAttempt>()
                .Property(la => la.Success)
                .HasColumnName("success")
                .IsRequired();

            // Medicine
            modelBuilder.Entity<Medicine>()
                .ToTable("Medicines")
                .HasKey(m => m.MedicineId);

            modelBuilder.Entity<Medicine>()
                .Property(m => m.MedicineId)
                .HasColumnName("medicine_id");

            modelBuilder.Entity<Medicine>()
                .Property(m => m.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Medicine>()
                .Property(m => m.Description)
                .HasColumnName("description");

            modelBuilder.Entity<Medicine>()
                .Property(m => m.Price)
                .HasColumnName("price")
                .IsRequired()
                .HasColumnType("decimal(10, 2)");

            modelBuilder.Entity<Medicine>()
                .Property(m => m.StockQuantity)
                .HasColumnName("stock_quantity")
                .IsRequired();

            modelBuilder.Entity<Medicine>()
                .Property(m => m.Manufacturer)
                .HasColumnName("manufacturer")
                .HasMaxLength(100);

            // Orders
            modelBuilder.Entity<Order>()
                .ToTable("Orders")
                .HasKey(o => o.OrderId);

            modelBuilder.Entity<Order>()
                .Property(o => o.OrderId)
                .HasColumnName("order_id");

            modelBuilder.Entity<Order>()
                .Property(o => o.UserId)
                .HasColumnName("user_id");

            modelBuilder.Entity<Order>()
                .Property(o => o.PharmacistId)
                .HasColumnName("pharmacist_id");

            modelBuilder.Entity<Order>()
                .Property(o => o.OrderDate)
                .HasColumnName("order_date")
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Order>()
                .Property(o => o.Status)
                .HasColumnName("status")
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasColumnName("total_amount")
                .IsRequired()
                .HasColumnType("decimal(10, 2)");

            // Order Item
            modelBuilder.Entity<OrderItem>()
                .ToTable("Order_Items")
                .HasKey(oi => oi.OrderItemId);

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.OrderItemId)
                .HasColumnName("order_item_id");

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.OrderId)
                .HasColumnName("order_id")
                .IsRequired();

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.MedicineId)
                .HasColumnName("medicine_id")
                .IsRequired();

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.Quantity)
                .HasColumnName("quantity")
                .IsRequired();

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.ItemPrice)
                .HasColumnName("item_price")
                .IsRequired()
                .HasColumnType("decimal(10, 2)");

            // Payment
            modelBuilder.Entity<Payment>()
                .ToTable("Payments")
                .HasKey(p => p.PaymentId);

            modelBuilder.Entity<Payment>()
                .Property(p => p.PaymentId)
                .HasColumnName("payment_id");

            modelBuilder.Entity<Payment>()
                .Property(p => p.OrderId)
                .HasColumnName("order_id")
                .IsRequired();

            modelBuilder.Entity<Payment>()
                .Property(p => p.PaymentDate)
                .HasColumnName("payment_date")
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnName("amount")
                .IsRequired()
                .HasColumnType("decimal(10, 2)");

            modelBuilder.Entity<Payment>()
                .Property(p => p.PaymentMethod)
                .HasColumnName("payment_method")
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Payment>()
                .Property(p => p.PaymentStatus)
                .HasColumnName("payment_status")
                .IsRequired()
                .HasMaxLength(20);

            // User Account
            modelBuilder.Entity<UserAccount>()
                .ToTable("User_Accounts")
                .HasKey(ua => ua.AccountId);

            modelBuilder.Entity<UserAccount>()
                .Property(ua => ua.AccountId)
                .HasColumnName("account_id");

            modelBuilder.Entity<UserAccount>()
                .Property(ua => ua.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            modelBuilder.Entity<UserAccount>()
                .Property(ua => ua.AccountType)
                .HasColumnName("account_type")
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<UserAccount>()
                .Property(ua => ua.Status)
                .HasColumnName("status")
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<UserAccount>()
                .Property(ua => ua.LastUpdated)
                .HasColumnName("last_updated")
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            // Relationships
            modelBuilder.Entity<Order>()
                .HasOne<Pharmacist>()
                .WithMany()
                .HasForeignKey(o => o.PharmacistId);

            modelBuilder.Entity<OrderItem>()
                .HasOne<Order>()
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne<Medicine>()
                .WithMany()
                .HasForeignKey(oi => oi.MedicineId);

            modelBuilder.Entity<Payment>()
                .HasOne<Order>()
                .WithMany(o => o.Payments)
                .HasForeignKey(p => p.OrderId);

            // Seed data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Admin
            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    AdminId = 1,
                    Username = "admin",
                    Email = "admin@example.com",
                    // Password: "Admin@123"
                    PasswordHash = "AQAAAAEAACcQAAAAELEswJvOXtPbALrZIjvn6xfKk+xNbLrAoOoaY/Nt7Av/EyuPaHRqIuxBk2hhzz1cKA==",
                    Role = "Admin",
                    CreatedAt = DateTime.Now
                }
            );

            // Seed Pharmacist
            modelBuilder.Entity<Pharmacist>().HasData(
                new Pharmacist
                {
                    PharmacistId = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    LicenseNumber = "PH12345",
                    Email = "john.doe@example.com",
                    ContactNumber = "123-456-7890"
                }
            );

            // Seed Medicines
            modelBuilder.Entity<Medicine>().HasData(
                new Medicine
                {
                    MedicineId = 1,
                    Name = "Paracetamol 500mg",
                    Description = "Pain reliever and fever reducer",
                    Price = 5.99m,
                    StockQuantity = 100,
                    Manufacturer = "Pharma Inc."
                },
                new Medicine
                {
                    MedicineId = 2,
                    Name = "Amoxicillin 250mg",
                    Description = "Antibiotic used to treat bacterial infections",
                    Price = 12.50m,
                    StockQuantity = 50,
                    Manufacturer = "MediCare"
                },
                new Medicine
                {
                    MedicineId = 3,
                    Name = "Ibuprofen 400mg",
                    Description = "Non-steroidal anti-inflammatory drug (NSAID)",
                    Price = 6.75m,
                    StockQuantity = 75,
                    Manufacturer = "HealthPharm"
                }
            );
        }
    }
}