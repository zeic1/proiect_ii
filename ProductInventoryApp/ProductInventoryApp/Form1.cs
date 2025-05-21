using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ProductInventoryApp
{
    public partial class Form1 : Form
    {
        // UI Controls
        private TabControl tabControl;
        private TabPage tabProducts;
        private TabPage tabUtilities;

        // Products Tab Controls
        private ListBox listBoxProducts;
        private Label lblProductName;
        private TextBox txtProductName;
        private Label lblCategory;
        private TextBox txtCategory;
        private Label lblPrice;
        private TextBox txtPrice;
        private Label lblQuantity;
        private TextBox txtQuantity;
        private Button btnAddProduct;
        private Button btnUpdate;
        private Button btnClear;

        // Utilities Tab Controls
        private GroupBox grpConversions;
        private Label lblTempC;
        private TextBox txtTempC;
        private Label lblTempF;
        private TextBox txtTempF;
        private Button btnConvertF2C;
        private Button btnConvertC2F;
        private Label lblEuro;
        private TextBox txtEuro;
        private Label lblRon;
        private TextBox txtRon;
        private Button btnEuroToRon;

        private GroupBox grpList;
        private ListBox listBox1;
        private Button btnAddList;

        private GroupBox grpDateTime;
        private Label lblDateTime;
        private Button btnGetDateTime;

        private DataAccess dataAccess;
        private DataTable productsTable;

        public Form1()
        {
            SetupComponents();
            dataAccess = new DataAccess();
        }

        private void SetupComponents()
        {
            // Form settings
            this.Text = "Product Inventory Management";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Create TabControl
            tabControl = new TabControl();
            tabControl.Dock = DockStyle.Fill;
            tabControl.Name = "tabControl";

            // Create TabPages
            tabProducts = new TabPage("Products");
            tabUtilities = new TabPage("Utilities");

            // Add TabPages to TabControl
            tabControl.TabPages.Add(tabProducts);
            tabControl.TabPages.Add(tabUtilities);

            // Add controls to Products tab
            CreateProductsTabControls();

            // Add controls to Utilities tab
            CreateUtilitiesTabControls();

            // Add TabControl to Form
            this.Controls.Add(tabControl);

            // Wire up events
            this.Load += Form1_Load;
            btnAddProduct.Click += btnAddProduct_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnClear.Click += btnClear_Click;
            listBoxProducts.SelectedIndexChanged += listBoxProducts_SelectedIndexChanged;
            btnConvertF2C.Click += btnConvertF2C_Click;
            btnConvertC2F.Click += btnConvertC2F_Click;
            btnEuroToRon.Click += btnEuroToRon_Click;
            btnAddList.Click += btnAddList_Click;
            btnGetDateTime.Click += btnGetDateTime_Click;
        }

        private void CreateProductsTabControls()
        {
            // ListBox for products
            listBoxProducts = new ListBox();
            listBoxProducts.Location = new Point(20, 20);
            listBoxProducts.Size = new Size(250, 450);
            listBoxProducts.Name = "listBoxProducts";

            // Labels and TextBoxes for product details
            lblProductName = new Label();
            lblProductName.Text = "Product Name:";
            lblProductName.Location = new Point(290, 20);
            lblProductName.Size = new Size(100, 20);

            txtProductName = new TextBox();
            txtProductName.Location = new Point(400, 20);
            txtProductName.Size = new Size(200, 20);

            lblCategory = new Label();
            lblCategory.Text = "Category:";
            lblCategory.Location = new Point(290, 50);
            lblCategory.Size = new Size(100, 20);

            txtCategory = new TextBox();
            txtCategory.Location = new Point(400, 50);
            txtCategory.Size = new Size(200, 20);

            lblPrice = new Label();
            lblPrice.Text = "Price:";
            lblPrice.Location = new Point(290, 80);
            lblPrice.Size = new Size(100, 20);

            txtPrice = new TextBox();
            txtPrice.Location = new Point(400, 80);
            txtPrice.Size = new Size(200, 20);

            lblQuantity = new Label();
            lblQuantity.Text = "Quantity:";
            lblQuantity.Location = new Point(290, 110);
            lblQuantity.Size = new Size(100, 20);

            txtQuantity = new TextBox();
            txtQuantity.Location = new Point(400, 110);
            txtQuantity.Size = new Size(200, 20);

            // Buttons
            btnAddProduct = new Button();
            btnAddProduct.Text = "Add";
            btnAddProduct.Location = new Point(290, 150);
            btnAddProduct.Size = new Size(100, 30);

            btnUpdate = new Button();
            btnUpdate.Text = "Update";
            btnUpdate.Location = new Point(400, 150);
            btnUpdate.Size = new Size(100, 30);

            btnClear = new Button();
            btnClear.Text = "Clear";
            btnClear.Location = new Point(510, 150);
            btnClear.Size = new Size(100, 30);

            // Add controls to Products tab
            tabProducts.Controls.Add(listBoxProducts);
            tabProducts.Controls.Add(lblProductName);
            tabProducts.Controls.Add(txtProductName);
            tabProducts.Controls.Add(lblCategory);
            tabProducts.Controls.Add(txtCategory);
            tabProducts.Controls.Add(lblPrice);
            tabProducts.Controls.Add(txtPrice);
            tabProducts.Controls.Add(lblQuantity);
            tabProducts.Controls.Add(txtQuantity);
            tabProducts.Controls.Add(btnAddProduct);
            tabProducts.Controls.Add(btnUpdate);
            tabProducts.Controls.Add(btnClear);
        }

        private void CreateUtilitiesTabControls()
        {
            // Conversions Group
            grpConversions = new GroupBox();
            grpConversions.Text = "Conversions";
            grpConversions.Location = new Point(20, 20);
            grpConversions.Size = new Size(700, 150);

            // Temperature conversion
            lblTempC = new Label();
            lblTempC.Text = "Temperature (Celsius):";
            lblTempC.Location = new Point(20, 30);
            lblTempC.Size = new Size(130, 20);

            txtTempC = new TextBox();
            txtTempC.Location = new Point(150, 30);
            txtTempC.Size = new Size(100, 20);

            lblTempF = new Label();
            lblTempF.Text = "Temperature (Fahrenheit):";
            lblTempF.Location = new Point(350, 30);
            lblTempF.Size = new Size(150, 20);

            txtTempF = new TextBox();
            txtTempF.Location = new Point(500, 30);
            txtTempF.Size = new Size(100, 20);

            btnConvertF2C = new Button();
            btnConvertF2C.Text = "F to C";
            btnConvertF2C.Location = new Point(270, 30);
            btnConvertF2C.Size = new Size(60, 30);

            btnConvertC2F = new Button();
            btnConvertC2F.Text = "C to F";
            btnConvertC2F.Location = new Point(610, 30);
            btnConvertC2F.Size = new Size(60, 30);

            // Currency conversion
            lblEuro = new Label();
            lblEuro.Text = "Euro:";
            lblEuro.Location = new Point(20, 80);
            lblEuro.Size = new Size(100, 20);

            txtEuro = new TextBox();
            txtEuro.Location = new Point(150, 80);
            txtEuro.Size = new Size(100, 20);

            lblRon = new Label();
            lblRon.Text = "RON:";
            lblRon.Location = new Point(350, 80);
            lblRon.Size = new Size(100, 20);

            txtRon = new TextBox();
            txtRon.Location = new Point(500, 80);
            txtRon.Size = new Size(100, 20);

            btnEuroToRon = new Button();
            btnEuroToRon.Text = "€ to RON";
            btnEuroToRon.Location = new Point(270, 80);
            btnEuroToRon.Size = new Size(60, 30);

            // Add controls to Conversions group
            grpConversions.Controls.Add(lblTempC);
            grpConversions.Controls.Add(txtTempC);
            grpConversions.Controls.Add(lblTempF);
            grpConversions.Controls.Add(txtTempF);
            grpConversions.Controls.Add(btnConvertF2C);
            grpConversions.Controls.Add(btnConvertC2F);
            grpConversions.Controls.Add(lblEuro);
            grpConversions.Controls.Add(txtEuro);
            grpConversions.Controls.Add(lblRon);
            grpConversions.Controls.Add(txtRon);
            grpConversions.Controls.Add(btnEuroToRon);

            // List Group
            grpList = new GroupBox();
            grpList.Text = "List with 5 Elements";
            grpList.Location = new Point(20, 180);
            grpList.Size = new Size(700, 150);

            listBox1 = new ListBox();
            listBox1.Location = new Point(150, 30);
            listBox1.Size = new Size(300, 100);

            btnAddList = new Button();
            btnAddList.Text = "Add List";
            btnAddList.Location = new Point(20, 30);
            btnAddList.Size = new Size(100, 30);

            // Add controls to List group
            grpList.Controls.Add(listBox1);
            grpList.Controls.Add(btnAddList);

            // DateTime Group
            grpDateTime = new GroupBox();
            grpDateTime.Text = "Date and Time";
            grpDateTime.Location = new Point(20, 340);
            grpDateTime.Size = new Size(700, 100);

            lblDateTime = new Label();
            lblDateTime.Text = "Click button to get time...";
            lblDateTime.Location = new Point(150, 30);
            lblDateTime.Size = new Size(300, 30);
            lblDateTime.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);

            btnGetDateTime = new Button();
            btnGetDateTime.Text = "Get Date and Time";
            btnGetDateTime.Location = new Point(20, 30);
            btnGetDateTime.Size = new Size(120, 30);

            // Add controls to DateTime group
            grpDateTime.Controls.Add(lblDateTime);
            grpDateTime.Controls.Add(btnGetDateTime);

            // Add groups to Utilities tab
            tabUtilities.Controls.Add(grpConversions);
            tabUtilities.Controls.Add(grpList);
            tabUtilities.Controls.Add(grpDateTime);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshProductList();
        }

        private void RefreshProductList()
        {
            productsTable = dataAccess.GetAllProducts();
            listBoxProducts.DataSource = productsTable;
            listBoxProducts.DisplayMember = "ProductName";
            listBoxProducts.ValueMember = "ProductID";
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Please enter a product name.");
                return;
            }

            decimal price;
            if (!decimal.TryParse(txtPrice.Text, out price))
            {
                MessageBox.Show("Please enter a valid price.");
                return;
            }

            int quantity;
            if (!int.TryParse(txtQuantity.Text, out quantity))
            {
                MessageBox.Show("Please enter a valid quantity.");
                return;
            }

            bool success = dataAccess.AddProduct(txtProductName.Text, txtCategory.Text, price, quantity);

            if (success)
            {
                MessageBox.Show("Product added successfully!");
                ClearForm();
                RefreshProductList();
            }
            else
            {
                MessageBox.Show("Failed to add product. Please try again.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listBoxProducts.SelectedValue == null)
            {
                MessageBox.Show("Please select a product to update.");
                return;
            }

            int productId = Convert.ToInt32(listBoxProducts.SelectedValue);

            decimal price;
            if (!decimal.TryParse(txtPrice.Text, out price))
            {
                MessageBox.Show("Please enter a valid price.");
                return;
            }

            int quantity;
            if (!int.TryParse(txtQuantity.Text, out quantity))
            {
                MessageBox.Show("Please enter a valid quantity.");
                return;
            }

            bool success = dataAccess.UpdateProduct(productId, txtProductName.Text, txtCategory.Text, price, quantity);

            if (success)
            {
                MessageBox.Show("Product updated successfully!");
                ClearForm();
                RefreshProductList();
            }
            else
            {
                MessageBox.Show("Failed to update product. Please try again.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtProductName.Text = string.Empty;
            txtCategory.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtQuantity.Text = string.Empty;
        }

        private void listBoxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxProducts.SelectedIndex >= 0)
            {
                DataRowView row = (DataRowView)listBoxProducts.SelectedItem;
                txtProductName.Text = row["ProductName"].ToString();
                txtCategory.Text = row["Category"].ToString();
                txtPrice.Text = row["Price"].ToString();
                txtQuantity.Text = row["StockQuantity"].ToString();
            }
        }

        private void btnConvertF2C_Click(object sender, EventArgs e)
        {
            decimal fahrenheit;
            if (decimal.TryParse(txtTempF.Text, out fahrenheit))
            {
                decimal celsius = dataAccess.ConvertFahrenheitToCelsius(fahrenheit);
                txtTempC.Text = celsius.ToString("F2");
            }
            else
            {
                MessageBox.Show("Please enter a valid temperature in Fahrenheit.");
            }
        }

        private void btnConvertC2F_Click(object sender, EventArgs e)
        {
            decimal celsius;
            if (decimal.TryParse(txtTempC.Text, out celsius))
            {
                // Conversion formula: F = C * 9/5 + 32
                decimal fahrenheit = celsius * 9 / 5 + 32;
                txtTempF.Text = fahrenheit.ToString("F2");
            }
            else
            {
                MessageBox.Show("Please enter a valid temperature in Celsius.");
            }
        }

        private void btnEuroToRon_Click(object sender, EventArgs e)
        {
            decimal euro;
            if (decimal.TryParse(txtEuro.Text, out euro))
            {
                decimal ron = dataAccess.ConvertEuroToRon(euro);
                txtRon.Text = ron.ToString("F2");
            }
            else
            {
                MessageBox.Show("Please enter a valid amount in Euro.");
            }
        }

        private void btnAddList_Click(object sender, EventArgs e)
        {
            string[] items = dataAccess.GetList(5);
            listBox1.Items.Clear();
            listBox1.Items.AddRange(items);
        }

        private void btnGetDateTime_Click(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}