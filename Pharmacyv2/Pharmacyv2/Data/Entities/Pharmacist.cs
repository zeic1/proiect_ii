namespace PharmacyManagementSystem.Data.Entities
{
    public class Pharmacist
    {
        public int PharmacistId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LicenseNumber { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }

        // Navigation properties
        public virtual ICollection<Order> Orders { get; set; }
    }

}
