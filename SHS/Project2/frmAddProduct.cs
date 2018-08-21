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
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;

namespace SHS
{
    public partial class frmAddProduct : Form
    {
        List<Package> packages = new List<Package>();
        List<Manufacturer> manufacturers = new List<Manufacturer>();

        List<ClassLibrary.Component> allComponents = new List<ClassLibrary.Component>();
        List<ClassLibrary.Component> componentsLeft = new List<ClassLibrary.Component>();
        BindingList<ClassLibrary.Component> componentsChosen = new BindingList<ClassLibrary.Component>();

        public frmAddProduct(BindingList<ClassLibrary.Component> components = null)
        {
            InitializeComponent();

            if (components != null)
            {
                componentsChosen = components;
            }
        }

        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            helpProvider1.SetShowHelp(this.txtDescription, true);

            panel2.BackColor = Color.FromArgb(150, 0, 0, 0);

            btnAddProduct.TabStop = false;
            btnAddProduct.FlatStyle = FlatStyle.Flat;
            btnAddProduct.FlatAppearance.BorderSize = 0;

            btnAddComponent.TabStop = false;
            btnAddComponent.FlatStyle = FlatStyle.Flat;
            btnAddComponent.FlatAppearance.BorderSize = 0;

            btnAddNewComponent.TabStop = false;
            btnAddNewComponent.FlatStyle = FlatStyle.Flat;
            btnAddNewComponent.FlatAppearance.BorderSize = 0;

            btnAddPackage.TabStop = false;
            btnAddPackage.FlatStyle = FlatStyle.Flat;
            btnAddPackage.FlatAppearance.BorderSize = 0;

            btnExit.TabStop = false;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;

            btnBack.TabStop = false;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;

            btnRemoveComponent.TabStop = false;
            btnRemoveComponent.FlatStyle = FlatStyle.Flat;
            btnRemoveComponent.FlatAppearance.BorderSize = 0;

            ResetPackageDropDown();
            ResetManufacturerDropDown();
            ResetComponentDropDown();

            //REMOVE
            cbxManufacturer.SelectedIndex = 0;
            cbxPackageName.SelectedIndex = 0;
            //
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmManageProducts form = new frmManageProducts();
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
            List<Product> products = Product.GetProducts();

            bool productDescriptionExists = false;

            foreach (Product product in products)
            {
                if (product.Description == txtDescription.Text)
                {
                    productDescriptionExists = true;
                }
            }

            if (productDescriptionExists)
            {
                MessageBox.Show("The product description already exists!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool codeExists;
                string productCode = txtProductCode.Text;

                do
                {
                    codeExists = false;

                    foreach (Product product in products)
                    {
                        if (product.ProductCode == productCode)
                        {
                            codeExists = true;
                        }
                    }

                    if (codeExists)
                    {
                        Regex r = new Regex("^[a-zA-Z0-9]*$");

                        do
                        {
                            if (productCode.Length != 5)
                            {
                                productCode = Interaction.InputBox("Enter a new product code:", "The product code must have a length of 5!", "AAAAA").ToUpper();
                            }
                            else if (!r.IsMatch(productCode))
                            {
                                productCode = Interaction.InputBox("Enter a new product code:", "Invalid product code!", "AAAAA").ToUpper();
                            }
                            else if (codeExists)
                            {
                                productCode = Interaction.InputBox("Enter a new product code:", "The product code already exists!", "AAAAA").ToUpper();
                            }
                        } while (productCode.Length != 5 || !r.IsMatch(productCode));
                    }
                } while (codeExists);

                txtProductCode.Text = productCode;

                string packageCode = Package.GetPackages(cbxPackageName.Text)[0].PackageCode;

                Product productToAdd = new Product(packageCode, txtProductCode.Text, txtDescription.Text, cbxManufacturer.Text);

                if (componentsChosen.Count > 0)
                {
                    if (_ValidationMethods.isValid)
                    {
                        List<ClassLibrary.Component> components = new List<ClassLibrary.Component>();

                        foreach (ClassLibrary.Component component in componentsChosen)
                        {
                            components.Add(component);
                        }

                        productToAdd.Components = components;
                        productToAdd.SaveProductToDB();

                        frmManageProducts form = new frmManageProducts();
                        form.Show();

                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("No components were chosen!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            int characterPos = 0;
            int wordCount = 0;
            string productCodeString = "";
            string productCodeNumber = "";

            Random ran = new Random();

            foreach (char character in txtDescription.Text)
            {
                if (characterPos == 0 || txtDescription.Text[characterPos - 1] == ' ')
                {
                    if (wordCount < 5)
                    {
                        productCodeString += character.ToString().ToUpper();
                        wordCount++;

                        productCodeNumber = "";

                        for (int i = 0; i < 5 - wordCount; i++)
                        {
                            productCodeNumber += ran.Next(0, 10).ToString();
                        }
                    }
                }

                characterPos++;
            }

            txtProductCode.Text = productCodeString + productCodeNumber.ToString();
        }

        private void btnAddPackage_Click(object sender, EventArgs e)
        {
            string packageName = Interaction.InputBox("Enter the Package Name:", "New Package Name", "Home Irrigation Management");

            int characterPos = 0;
            string newPackageName = "";

            foreach (char character in packageName)
            {
                if (characterPos == 0 || packageName[characterPos - 1] == ' ')
                {
                    newPackageName += character.ToString().ToUpper();
                }
                else
                {
                    newPackageName += character;
                }

                characterPos++;
            }

            Package packageToAdd = new Package(newPackageName);

            if (packageToAdd.PackageCode == "-----")
            {
                MessageBox.Show("The package name, " + packageToAdd.Name + ", already exists!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (packageToAdd.Name != null && packageToAdd.Name != "")
            {
                packageToAdd.SavePackageToDB();
                ResetPackageDropDown(packageToAdd.Name);
            }
        }

        private void btnAddNewComponent_Click(object sender, EventArgs e)
        {
            frmAddComponent form = new frmAddComponent(componentsChosen);
            form.Show();

            this.Hide();
        }

        private void ResetPackageDropDown(string selectedPackage = null)
        {
            cbxPackageName.Items.Clear();

            packages = Package.GetPackages();

            foreach (Package package in packages)
            {
                cbxPackageName.Items.Add(package.Name);
            }

            if (selectedPackage != null)
            {
                cbxPackageName.SelectedItem = selectedPackage;
            }
        }

        private void ResetManufacturerDropDown()
        {
            cbxManufacturer.Items.Clear();

            manufacturers = Manufacturer.GetManufacturers(null);

            foreach (Manufacturer manufacturer in manufacturers)
            {
                cbxManufacturer.Items.Add(manufacturer.Name);
            }
        }

        private void ResetComponentDropDown()
        {
            cbxComponents.DataSource = null;
            dgvComponentsChosen.DataSource = null;
            componentsLeft.Clear();

            allComponents = ClassLibrary.Component.GetComponents(null);

            bool componentLeft;

            for (int i = 0; i < allComponents.Count(); i++)
            {
                componentLeft = true;

                for (int l = 0; l < componentsChosen.Count(); l++)
                {
                    if (allComponents[i].Description == componentsChosen[l].Description)
                    {
                        componentLeft = false;
                    }
                }

                if (componentLeft)
                {
                    componentsLeft.Add(allComponents[i]);
                }
            }

            cbxComponents.DataSource = componentsLeft;
            cbxComponents.DisplayMember = "Description";
            cbxComponents.Text = null;

            if (componentsChosen.Count > 0)
            {
                dgvComponentsChosen.DataSource = componentsChosen;
                dgvComponentsChosen.Columns["ProductCode"].Visible = false;
                dgvComponentsChosen.Columns["ComponentCode"].Width = 100;
                dgvComponentsChosen.Columns["Description"].Width = 200;
            }
        }

        private void btnAddComponent_Click(object sender, EventArgs e)
        {
            if (cbxComponents.Text != null && cbxComponents.Text != "")
            {
                int quantity = 0;
                bool isQuantity = false;

                do
                {
                    isQuantity = int.TryParse(Interaction.InputBox("Enter the default quantity:", "Component Quantity", "1"), out quantity);
                } while (!isQuantity);

                foreach (ClassLibrary.Component component in allComponents)
                {
                    if (component.Description == cbxComponents.Text)
                    {
                        componentsChosen.Add(new ClassLibrary.Component("-----", component.ComponentCode, component.Description, component.Price, quantity));
                    }
                }

                ResetComponentDropDown();
            }
            else
            {
                MessageBox.Show("Please select a component!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveComponent_Click(object sender, EventArgs e)
        {
            if (dgvComponentsChosen.Rows.Count > 0)
            {
                dgvComponentsChosen.Rows.RemoveAt(dgvComponentsChosen.SelectedRows[0].Index);

                if (dgvComponentsChosen.Rows.Count == 0)
                {
                    dgvComponentsChosen.DataSource = null;
                }
            }

            ResetComponentDropDown();
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(this.label5, "Max 50 Characters");
        }

        ErrorProvider errorProvider = new ErrorProvider();

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                e.Cancel = true;
                txtDescription.Focus();
                errorProvider.SetError(txtDescription, "Please enter a description!");
            }
            else
            {
                errorProvider.Clear();
            }
        }
    }
}
