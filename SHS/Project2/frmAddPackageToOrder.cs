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
    public partial class frmAddPackageToOrder : Form
    {
        private static int[][] oldQuantities = null;

        private static List<Package> packages = new List<Package>();
        private static List<Product> productsInPackage = new List<Product>();

        private static bool formHasLoaded = false;
        private static bool alreadyAdded = false;

        private string clientIDNumber;

        public frmAddPackageToOrder(string clientIDNumberParam)
        {
            InitializeComponent();
            clientIDNumber = clientIDNumberParam;
        }

        private void frmAddPackageToOrder_Load(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(150, 0, 0, 0);
            label10.BackColor = Color.FromArgb(0, 0, 0, 0);
            label1.BackColor = Color.FromArgb(0, 0, 0, 0);

            btnAddPackage.TabStop = false;
            btnAddPackage.FlatStyle = FlatStyle.Flat;
            btnAddPackage.FlatAppearance.BorderSize = 0;

            btnExit.TabStop = false;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;

            btnBack.TabStop = false;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;

            btnUpdateQuantity.TabStop = false;
            btnUpdateQuantity.FlatStyle = FlatStyle.Flat;
            btnUpdateQuantity.FlatAppearance.BorderSize = 0;

            packages = Package.GetPackages();

            cbxPackage.DataSource = packages;
            cbxPackage.DisplayMember = "Name";
            cbxPackage.Text = null;

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

        private void cbxPackage_SelectedIndexChanged(object sender, EventArgs e)
        {
            productsInPackage.Clear();
            dgvComponents.DataSource = null;

            if (formHasLoaded)
            {
                string selectedPackageName = cbxPackage.Text;

                Package selectedPackage = new Package();

                foreach (Package package in packages)
                {
                    if (package.Name == selectedPackageName)
                    {
                        selectedPackage = package;
                    }
                }

                productsInPackage = Product.GetProducts(selectedPackage.PackageCode, true);

                dgvProducts.DataSource = productsInPackage;
                dgvProducts.Columns["ManufacturerID"].Visible = false;
                dgvProducts.Columns["ManufacturerName"].Visible = false;
                dgvProducts.Columns["ProductCode"].Width = 100;
                dgvProducts.Columns["PackageCode"].Width = 100;

                oldQuantities = new int[productsInPackage.Count][];

                int[] oldQty;
                int productCount = 0;

                foreach (Product product in productsInPackage)
                {
                    List<ClassLibrary.Component> components = new List<ClassLibrary.Component>();
                    components = ClassLibrary.Component.GetComponents(product.ProductCode);

                    product.Components = components;

                    oldQty = new int[components.Count];

                    int componentCount = 0;

                    foreach (ClassLibrary.Component component in components)
                    {
                        oldQty[componentCount] = component.Quantity;
                        componentCount++;
                    }

                    oldQuantities[productCount] = oldQty;
                    productCount++;
                }

                alreadyAdded = false;

                foreach (Product productToOrder in Order.productsToOrder)
                {
                    foreach (Product productInPackage in productsInPackage)
                    {
                        if (productToOrder.ProductCode == productInPackage.ProductCode)
                        {
                            alreadyAdded = true;
                        }
                    }
                }

                if (alreadyAdded)
                {
                    MessageBox.Show("A product(s) from this package has already been added!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdateQuantity_Click(object sender, EventArgs e)
        {
            if (dgvComponents.Rows.Count > 0)
            {
                int newQty = int.Parse(nudQty.Value.ToString());

                int selectedProductIndex = dgvProducts.SelectedRows[0].Index;
                int selectedComponentIndex = dgvComponents.SelectedRows[0].Index;
                
                if (newQty >= oldQuantities[selectedProductIndex][selectedComponentIndex])
                {
                    dgvComponents.SelectedRows[0].Cells["Quantity"].Value = newQty;

                    productsInPackage[selectedProductIndex].Components[selectedComponentIndex].Quantity = newQty;
                }
                else
                {
                    MessageBox.Show("Invalid Quantity specified!\n(Must be greater than or equal to " + oldQuantities[selectedProductIndex][selectedComponentIndex] + ")", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddPackage_Click(object sender, EventArgs e)
        {
            if (!alreadyAdded)
            {
                foreach (Product product in productsInPackage)
                {
                    Order.productsToOrder.Add(product);
                }

                formHasLoaded = false;

                frmAddOrder form = new frmAddOrder(clientIDNumber);
                form.Show();

                this.Hide();
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProducts.Rows.Count > 0)
            {
                dgvComponents.DataSource = null;

                string selectedProductCode = dgvProducts.SelectedRows[0].Cells["ProductCode"].Value.ToString();

                List<ClassLibrary.Component> components = new List<ClassLibrary.Component>();
                components = ClassLibrary.Component.GetComponents(selectedProductCode);

                dgvComponents.DataSource = components;

                dgvComponents.Columns["ProductCode"].Visible = false;
                dgvComponents.Columns["ComponentCode"].Width = 100;
                dgvComponents.Columns["Description"].Width = 200;
            }
        }
    }
}