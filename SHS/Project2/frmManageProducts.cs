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
    public partial class frmManageProducts : Form
    {
        public frmManageProducts()
        {
            InitializeComponent();
        }

        string[] typesOfProducts = { "ALL PRODUCTS", "SELLABLE PRODUCTS", "NON-SELLABLE PRODUCTS" };

        private void frmManageProducts_Load(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(150, 0, 0, 0);
            label10.BackColor = Color.FromArgb(0, 0, 0, 0);

            btnAddProduct.TabStop = false;
            btnAddProduct.FlatStyle = FlatStyle.Flat;
            btnAddProduct.FlatAppearance.BorderSize = 0;

            btnRemoveProduct.TabStop = false;
            btnRemoveProduct.FlatStyle = FlatStyle.Flat;
            btnRemoveProduct.FlatAppearance.BorderSize = 0;
                        
            btnExit.TabStop = false;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;

            btnBack.TabStop = false;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;

            for (int i = 0; i < typesOfProducts.Length; i++)
            {
                cbxTypesOfProducts.Items.Add(typesOfProducts[i]);
            }

            cbxTypesOfProducts.SelectedItem = cbxTypesOfProducts.Items[0];

            ResetDataGrid();
        }
        
        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMain form = new frmMain();
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
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddProduct form = new frmAddProduct();
            form.Show();

            this.Hide();
        }

        private void cbxTypesOfProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetDataGrid();
        }

        private void ResetDataGrid()
        {
            dgvProducts.DataSource = null;

            int typeOfProduct = cbxTypesOfProducts.SelectedIndex;

            if (typeOfProduct != -1)
            {
                List<Product> products = new List<Product>();

                switch (cbxTypesOfProducts.SelectedIndex)
                {
                    case 1:
                        products = Product.GetProducts(null, true);
                        break;
                    case 2:
                        products = Product.GetProducts(null, false);
                        break;
                    default:
                        products = Product.GetProducts();
                        break;
                }

                dgvProducts.DataSource = products;

                dgvProducts.Columns["ManufacturerID"].Visible = false;
                dgvProducts.Columns["ProductCode"].Width = 80;
                dgvProducts.Columns["PackageCode"].Width = 80;
                dgvProducts.Columns["Description"].Width = 220;
            }
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            string productCode = dgvProducts.SelectedRows[0].Cells["ProductCode"].Value.ToString();

            Product.RemoveProduct(productCode);

            ResetDataGrid();
        }
    }
}
