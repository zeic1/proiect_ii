using System.ComponentModel.DataAnnotations;

namespace PharmacyManagement.Models
{
    // Pharmacist entity
    public class Pharmacist
    {
        public int PharmacistId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LicenseNumber { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }

        // Navigation properties
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }

    // Admin entity
    public class Admin
    {
        public int AdminId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
       
}

// Medicine entity
public class Medicine
{
    public int MedicineId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string Manufacturer { get; set; }
}

// Order entity
public class Order
{
    public int OrderId { get; set; }
    public int? UserId { get; set; }
    public int? PharmacistId { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; }
    public decimal TotalAmount { get; set; }

    // Navigation properties
    public virtual Pharmacist Pharmacist { get; set; }
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}

// OrderItem entity
public class OrderItem
{
    public int OrderItemId { get; set; }
    public int OrderId { get; set; }
    public int MedicineId { get; set; }
    public int Quantity { get; set; }
    public decimal ItemPrice { get; set; }

    // Navigation properties
    public virtual Order Order { get; set; }
    public virtual Medicine Medicine { get; set; }
}

// Payment entity
public class Payment
{
    public int PaymentId { get; set; }
    public int OrderId { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; }
    public string PaymentStatus { get; set; }

    // Navigation properties
    public virtual Order Order { get; set; }
}

// Login Attempt entity
public class LoginAttempt
{
    public int AttemptId { get; set; }
    public int UserId { get; set; }
    public DateTime AttemptTime { get; set; }
    public string IpAddress { get; set; }
    public bool Success { get; set; }
}

// User Account entity
public class UserAccount
{
    public int AccountId { get; set; }
    public int UserId { get; set; }
    public string AccountType { get; set; }
    public string Status { get; set; }
    public DateTime LastUpdated { get; set; }
}
}