using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;

namespace SHS
{
    public partial class frmAddProductToOrder : Form
    {
        List<Product> products = new List<Product>();
        List<ClassLibrary.Component> currentComponents = new List<ClassLibrary.Component>();

        private static int[] oldQuantities;

        private static bool formHasLoaded = false;
        private static bool alreadyAdded = false;

        private string clientIDNumber;

        public frmAddProductToOrder(string clientIDNumberParam)
        {
            InitializeComponent();
            clientIDNumber = clientIDNumberParam;
        }

        private void frmAddProductToOrder_Load(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(150, 0, 0, 0);
            label10.BackColor = Color.FromArgb(0, 0, 0, 0);
            label1.BackColor = Color.FromArgb(0, 0, 0, 0);

            btnAddProduct.TabStop = false;
            btnAddProduct.FlatStyle = FlatStyle.Flat;
            btnAddProduct.FlatAppearance.BorderSize = 0;

            btnExit.TabStop = false;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;

            btnBack.TabStop = false;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;

            btnUpdateQuantity.TabStop = false;
            btnUpdateQuantity.FlatStyle = FlatStyle.Flat;
            btnUpdateQuantity.FlatAppearance.BorderSize = 0;

            products = Product.GetProducts(null, true);

            cbxProduct.DataSource = products;
            cbxProduct.DisplayMember = "Description";
            cbxProduct.Text = null;

            formHasLoaded = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            formHasLoaded = false;
            
            frmAddOrder form = new frmAddOrder(clientIDNumber);
            form.Show();

            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (!frmCalls.onCall)
            {
                Environment.Exit(0);
            }
            else
            {
                MessageBox.Show("Application cannot exit while on a call!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProductDescription = cbxProduct.Text;
            Product selectedProduct = new Product();

            foreach (Product product in products)
	        {
		        if (product.Description == selectedProductDescription)
	            {
		            selectedProduct = product;
	            }
	        }

            alreadyAdded = Order.ProductExistsInOrder(selectedProductDescription);

            if (formHasLoaded)
            {
                currentComponents = ClassLibrary.Component.GetComponents(selectedProduct.ProductCode);

                dgvComponents.DataSource = currentComponents;

                dgvComponents.Columns["ProductCode"].Visible = false;
                dgvComponents.Columns["ComponentCode"].Width = 100;
                dgvComponents.Columns["Description"].Width = 200;

                oldQuantities = new int[currentComponents.Count];

                for (int i = 0; i < currentComponents.Count; i++)
                {
                    oldQuantities[i] = int.Parse(currentComponents[i].Quantity.ToString());
                }

                if (alreadyAdded)
                {
                    MessageBox.Show("This product has already been added!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdateQuantity_Click(object sender, EventArgs e)
        {
            if (dgvComponents.Rows.Count > 0)
            {
                int newQty = int.Parse(nudQty.Value.ToString());

                int selectedRowIndex = dgvComponents.SelectedRows[0].Index;

                if (newQty >= oldQuantities[selectedRowIndex])
                {
                    dgvComponents.SelectedRows[0].Cells["Quantity"].Value = newQty;
                }
                else
                {
                    MessageBox.Show("Invalid Quantity specified!\n(Must be greater than or equal to " + oldQuantities[selectedRowIndex] + ")", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (!alreadyAdded)
            {
                Product product = products[cbxProduct.SelectedIndex];
                product.Components = currentComponents;

                Order.productsToOrder.Add(product);

                formHasLoaded = false;

                frmAddOrder form = new frmAddOrder(clientIDNumber);
                form.Show();

                this.Hide();
            }
        }
    }
}
