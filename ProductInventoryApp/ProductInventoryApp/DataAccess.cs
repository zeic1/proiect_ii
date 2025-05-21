using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

namespace ProductInventoryApp
{
    public class DataAccess
    {
        private string connectionString;

        public DataAccess()
        {
            // Directly set the connection string instead of using ConfigurationManager
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProductInventory.mdf");
            connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True";
        }

        public DataTable GetAllProducts()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Products", conn);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting products: " + ex.Message);
            }
            return dt;
        }

        public bool AddProduct(string name, string category, decimal price, int quantity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Products (ProductName, Category, Price, StockQuantity) VALUES (@Name, @Category, @Price, @Quantity)", conn);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Category", category);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding product: " + ex.Message);
                return false;
            }
        }

        public bool UpdateProduct(int productId, string name, string category, decimal price, int quantity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Products SET ProductName = @Name, Category = @Category, Price = @Price, StockQuantity = @Quantity WHERE ProductID = @ID", conn);
                    cmd.Parameters.AddWithValue("@ID", productId);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Category", category);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating product: " + ex.Message);
                return false;
            }
        }

        // Utility methods
        public decimal ConvertFahrenheitToCelsius(decimal fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }

        public decimal ConvertEuroToRon(decimal euroAmount)
        {
            // Using a fixed exchange rate for demonstration
            const decimal exchangeRate = 4.97m;
            return euroAmount * exchangeRate;
        }

        public string[] GetList(int elementCount)
        {
            string[] list = new string[elementCount];
            for (int i = 0; i < elementCount; i++)
            {
                list[i] = $"Element {i + 1}";
            }
            return list;
        }
    }
}