using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHS
{
    public partial class frmAddOrder : Form
    {
        private string clientIDNumber = null;

        public frmAddOrder(string clientIDNumberParam)
        {
            InitializeComponent();
            clientIDNumber = clientIDNumberParam;
        }

        List<Client> clients = new List<Client>();

        private void frmAddOrder_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.FromArgb(0, 0, 0, 0);
            lblTotal.BackColor = Color.FromArgb(0, 0, 0, 0);
            panel2.BackColor = Color.FromArgb(150, 0, 0, 0);

            btnAddOrder.TabStop = false;
            btnAddOrder.FlatStyle = FlatStyle.Flat;
            btnAddOrder.FlatAppearance.BorderSize = 0;

            btnAddPackage.TabStop = false;
            btnAddPackage.FlatStyle = FlatStyle.Flat;
            btnAddPackage.FlatAppearance.BorderSize = 0;

            btnAddProduct.TabStop = false;
            btnAddProduct.FlatStyle = FlatStyle.Flat;
            btnAddProduct.FlatAppearance.BorderSize = 0;

            btnExit.TabStop = false;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;

            btnBack.TabStop = false;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;

            btnAddClient.TabStop = false;
            btnAddClient.FlatStyle = FlatStyle.Flat;
            btnAddClient.FlatAppearance.BorderSize = 0;

            btnRemoveProduct.TabStop = false;
            btnRemoveProduct.FlatStyle = FlatStyle.Flat;
            btnRemoveProduct.FlatAppearance.BorderSize = 0;

            clients = Client.GetClients();

            if (clientIDNumber != null && clientIDNumber != "")
            {
                cbxClientID.Text = clientIDNumber;
            }
            else
            {
                cbxClientID.Text = null;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Order.productsToOrder.Clear();

            frmManageOrders form = new frmManageOrders();
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

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            frmAddProductToOrder form = new frmAddProductToOrder(cbxClientID.Text);
            form.Show();

            this.Hide();
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            frmAddClient form = new frmAddClient();
            form.Show();

            FormState.PreviousPage = this;

            this.Hide();
        }

        private void btnAddPackage_Click(object sender, EventArgs e)
        {
            frmAddPackageToOrder form = new frmAddPackageToOrder(cbxClientID.Text);
            form.Show();

            this.Hide();
        }

        private void frmAddOrder_Activated(object sender, EventArgs e)
        {
            //--- Client ID ComboBox
            cbxClientID.DataSource = clients;
            cbxClientID.DisplayMember = "ID";

            if (clientIDNumber != null && clientIDNumber != "")
            {
                cbxClientID.Text = clientIDNumber;
            }
            else
            {
                cbxClientID.Text = null;
            }
            //---

            if (Order.productsToOrder.Count > 0)
            {
                dgvProducts.DataSource = Order.productsToOrder;
                dgvProducts.Columns["ManufacturerID"].Visible = false;
                dgvProducts.Columns["ManufacturerName"].Visible = false;
                dgvProducts.Columns["ProductCode"].Width = 100;
                dgvProducts.Columns["PackageCode"].Width = 100;
            }

            UpdateTotal();
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            _ValidationMethods.Reset();
            _ValidationMethods.ValidateDropDown(cbxClientID.Text, "Client ID");

            if (Order.productsToOrder.Count > 0)
            {
                if (_ValidationMethods.isValid)
                {
                    Client client = clients[cbxClientID.SelectedIndex];

                    Order order = new Order(client.ClientID, DateTime.Now, null);
                    Installation installation = new Installation();

                    order.ProductsOrdered += installation.OnProductsOrdered;
                    order.OrderProducts(client);

                    Order.productsToOrder.Clear();

                    frmManageOrders form = new frmManageOrders();
                    form.Show();

                    this.Hide();
                }
                else
                {
                    _ValidationMethods.ShowErrorMessage();
                }
            }
            else
            {
                MessageBox.Show("No products were chosen!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProducts_Click(object sender, EventArgs e)
        {
            if (dgvProducts.Rows.Count > 0)
            {
                int selectedProductIndex = dgvProducts.CurrentCell.RowIndex;

                dgvComponents.DataSource = Order.productsToOrder[selectedProductIndex].Components;

                dgvComponents.Columns["ProductCode"].Visible = false;
                dgvComponents.Columns["ComponentCode"].Width = 100;
                dgvComponents.Columns["Description"].Width = 250;
            }
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.Rows.Count > 0 && dgvProducts.SelectedRows.Count > 0)
            {
                dgvProducts.Rows.RemoveAt(dgvProducts.SelectedRows[0].Index);

                if (dgvProducts.Rows.Count == 0)
                {
                    dgvProducts.DataSource = null;
                }

                dgvComponents.DataSource = null;
            }

            UpdateTotal();
        }

        private void UpdateTotal()
        {
            lblTotal.Text = Order.GetTotal();
        }
    }
}
