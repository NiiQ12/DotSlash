using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;

namespace SHS
{
    public partial class frmAddComponent : Form
    {
        BindingList<ClassLibrary.Component> componentsChosen = new BindingList<ClassLibrary.Component>();

        public frmAddComponent(BindingList<ClassLibrary.Component> components)
        {
            InitializeComponent();

            componentsChosen = components;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmAddProduct form = new frmAddProduct(componentsChosen);
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

        private void frmAddComponent_Load(object sender, EventArgs e)
        {
            helpProvider1.SetShowHelp(this.txtDescription, true);
            helpProvider1.SetShowHelp(this.txtPrice, true);

            panel2.BackColor = Color.FromArgb(150, 0, 0, 0);

            btnExit.TabStop = false;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;

            btnBack.TabStop = false;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;

            btnAddComponent.TabStop = false;
            btnAddComponent.FlatStyle = FlatStyle.Flat;
            btnAddComponent.FlatAppearance.BorderSize = 0;
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            int characterPos = 0;
            int wordCount = 0;
            string componentCodeString = "";
            string componentCodeNumber = "";

            Random ran = new Random();

            foreach (char character in txtDescription.Text)
            {
                if (characterPos == 0 || txtDescription.Text[characterPos - 1] == ' ')
                {
                    if (wordCount < 5)
                    {
                        componentCodeString += character.ToString().ToUpper();
                        wordCount++;

                        componentCodeNumber = "";

                        for (int i = 0; i < 5 - wordCount; i++)
                        {
                            componentCodeNumber += ran.Next(0, 10).ToString();
                        }
                    }
                }

                characterPos++;
            }

            txtComponentCode.Text = componentCodeString + componentCodeNumber.ToString();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((sender as TextBox).Text.Length == 0 && (e.KeyChar == '0'))
            {
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Only allow one decimal point
            if ((sender as TextBox).Text.IndexOf('.') > -1)
            {
                if (((e.KeyChar == '.') || ((sender as TextBox).Text.Length > (sender as TextBox).Text.IndexOf('.') + 2)) && (e.KeyChar != '\b'))
                {
                    e.Handled = true;
                }
            }

            if ((sender as TextBox).Text.Length >= 10 && (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }

        private void btnAddComponent_Click(object sender, EventArgs e)
        {
            decimal price;

            if (txtPrice.Text != null && txtPrice.Text != "")
            {
                price = decimal.Parse(txtPrice.Text);
            }
            else
            {
                price = 0;
            }

            List<ClassLibrary.Component> components = ClassLibrary.Component.GetComponents();

            bool descriptionExists = false;

            foreach (ClassLibrary.Component cmp in components)
            {
                if (cmp.Description == txtDescription.Text)
                {
                    descriptionExists = true;
                }
            }

            if (descriptionExists)
            {
                MessageBox.Show("The component description already exists!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool codeExists;
                string componentCode = txtComponentCode.Text;

                do
                {
                    codeExists = false;

                    foreach (ClassLibrary.Component cmp in components)
                    {
                        if (cmp.ComponentCode == componentCode)
                        {
                            codeExists = true;
                        }
                    }

                    if (!codeExists)
                    {
                        ClassLibrary.Component component = new ClassLibrary.Component(null, componentCode, txtDescription.Text, price, 0);

                        if (component.SaveComponentToDB())
                        {
                            frmAddProduct form = new frmAddProduct(componentsChosen);
                            form.Show();

                            this.Hide();
                        }
                    }
                    else
                    {
                        Regex r = new Regex("^[a-zA-Z0-9]*$");

                        do
                        {
                            if (componentCode.Length != 5)
                            {
                                componentCode = Interaction.InputBox("Enter a new component code:", "The component code must have a length of 5!", "AAAAA").ToUpper();
                            }
                            else if (!r.IsMatch(componentCode))
                            {
                                componentCode = Interaction.InputBox("Enter a new component code:", "Invalid component code!", "AAAAA").ToUpper();
                            }
                            else if (codeExists)
                            {
                                componentCode = Interaction.InputBox("Enter a new component code:", "The component code already exists!", "AAAAA").ToUpper();
                            }
                        } while (componentCode.Length != 5 || !r.IsMatch(componentCode));
                    }
                } while (codeExists);
            }
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(this.label6, "Max 50 Characters");
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

        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                e.Cancel = true;
                txtPrice.Focus();
                errorProvider.SetError(txtPrice, "Please enter a price!");
            }
            else
            {
                errorProvider.Clear();
            }
        }
    }
}
