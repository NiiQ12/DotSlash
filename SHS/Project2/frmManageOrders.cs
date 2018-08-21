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
    public partial class frmManageOrders : Form
    {
        public frmManageOrders()
        {
            InitializeComponent();
        }

        List<Order> orders = new List<Order>();

        private void frmManageOrders_Load(object sender, EventArgs e)
        {
            string[] typesOfOrders = { "ALL ORDERS", "COMPLETED ORDERS", "PENDING ORDERS" };

            panel2.BackColor = Color.FromArgb(150, 0, 0, 0);
            label10.BackColor = Color.FromArgb(0, 0, 0, 0);

            btnBack.TabStop = false;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;

            btnExit.TabStop = false;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;

            btnAddOrder.TabStop = false;
            btnAddOrder.FlatStyle = FlatStyle.Flat;
            btnAddOrder.FlatAppearance.BorderSize = 0;

            btnCancelOrder.TabStop = false;
            btnCancelOrder.FlatStyle = FlatStyle.Flat;
            btnCancelOrder.FlatAppearance.BorderSize = 0;
        
            for (int i = 0; i < typesOfOrders.Length; i++)
            {
                cbxTypesOfOrders.Items.Add(typesOfOrders[i].ToString());
            }

            cbxTypesOfOrders.SelectedItem = cbxTypesOfOrders.Items[0];

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
            frmAddOrder form = new frmAddOrder(null);
            form.Show();

            this.Hide();
        }

        private void cbxTypesOfOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetDataGrid();
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int orderID = int.Parse(dgvOrders.SelectedRows[0].Cells[0].Value.ToString());

            foreach (Order order in orders)
            {
                if (order.OrderID == orderID)
                {
                    dgvOrderDetails.DataSource = order.OrderDetails;
                }
            }
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            string orderId = dgvOrders.SelectedRows[0].Cells[0].Value.ToString();

            Order.DeleteOrderFromDB(orderId);

            MessageBox.Show("Order " + orderId + " has been successfully removed from the database!", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ResetDataGrid();
        }

        private void ResetDataGrid()
        {
            dgvOrderDetails.DataSource = null;

            int typeOfOrder = cbxTypesOfOrders.SelectedIndex;

            if (typeOfOrder != -1)
            {
                orders = Order.GetOrders((OrderType)typeOfOrder);

                dgvOrders.DataSource = orders;
            }

            if (cbxTypesOfOrders.SelectedIndex == 2)
            {
                btnCancelOrder.Enabled = true;
                btnCancelOrder.BackColor = Color.FromArgb(0, 130, 130);
            }
            else
            {
                btnCancelOrder.Enabled = false;
                btnCancelOrder.BackColor = Color.FromArgb(80, 130, 130);
            }
        }
    }
}
