
using PharmacyManagementSystem.Models;

namespace PharmacyManagement.Services
{
    // Interface for Authentication Service
    public interface IAuthService
    {
        Task<bool> ValidateAdminCredentials(string username, string password);
        Task<bool> ValidatePharmacistCredentials(string email, string password);
        Task<Admin> GetAdminByUsername(string username);
        Task<Pharmacist> GetPharmacistByEmail(string email);
        Task RecordLoginAttempt(int userId, string ipAddress, bool success);
        Task<int> RegisterAdmin(Admin admin, string password);
        Task<int> RegisterPharmacist(Pharmacist pharmacist, string password);
        Task<bool> ChangePassword(string userType, int userId, string oldPassword, string newPassword);
    }

    // Interface for Medicine Service
    public interface IMedicineService
    {
        Task<List<Medicine>> GetAllMedicines();
        Task<(List<Medicine> Medicines, int TotalPages)> GetPagedMedicines(int page, int pageSize, string searchTerm = "");
        Task<Medicine> GetMedicineById(int id);
        Task<int> CreateMedicine(Medicine medicine);
        Task UpdateMedicine(Medicine medicine);
        Task DeleteMedicine(int id);
        Task<int> GetTotalMedicineCount();
        Task<List<Medicine>> GetLowStockMedicines(int count);
        Task<List<Medicine>> GetAvailableMedicines();
    }

    // Interface for Order Service
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrders();
        Task<(List<Order> Orders, int TotalPages)> GetPagedOrders(int page, int pageSize, string statusFilter = "", DateTime? dateFilter = null);
        Task<Order> GetOrderById(int id);
        Task<List<OrderItem>> GetOrderItems(int orderId);
        Task<List<Payment>> GetOrderPayments(int orderId);
        Task<int> CreateOrder(Order order);
        Task UpdateOrderStatus(int orderId, string status);
        Task<int> GetTotalOrderCount();
        Task<decimal> GetTotalRevenue();
        Task<List<Order>> GetRecentOrders(int count);

        // Pharmacist specific methods
        Task<int> GetPharmacistOrderCount(int pharmacistId);
        Task<int> GetPharmacistPendingOrderCount(int pharmacistId);
        Task<decimal> GetPharmacistTodayRevenue(int pharmacistId);
        Task<List<Order>> GetPharmacistRecentOrders(int pharmacistId, int count);
        Task<(List<Order> Orders, int TotalPages)> GetPharmacistPagedOrders(int pharmacistId, int page, int pageSize, string statusFilter = "", DateTime? dateFilter = null);
        Task<int> RecordPayment(Payment payment);
    }

    // Interface for Pharmacist Service
    public interface IPharmacistService
    {
        Task<List<Pharmacist>> GetAllPharmacists();
        Task<(List<Pharmacist> Pharmacists, int TotalPages)> GetPagedPharmacists(int page, int pageSize, string searchTerm = "");
        Task<Pharmacist> GetPharmacistById(int id);
        Task<int> CreatePharmacist(Pharmacist pharmacist, string password);
        Task UpdatePharmacist(Pharmacist pharmacist);
        Task DeletePharmacist(int id);
        Task<int> GetTotalPharmacistCount();
    }
}