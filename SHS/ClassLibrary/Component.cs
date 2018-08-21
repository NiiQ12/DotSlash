using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Component
    {
        private string productCode;
        private string componentCode;
        private string description;
        private decimal price;
        private int quantity;

        public string ProductCode
        {
            get { return productCode; }
            set { productCode = value; }
        }

        public string ComponentCode
        {
            get { return componentCode; }
            set { componentCode = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public Component()
        {

        }

        public Component(string componentCode, string description, decimal price)
        {
            _ValidationMethods.Reset();

            _ValidationMethods.ValidateCode(componentCode, "Component Code", 5);
            _ValidationMethods.ValidateStringWithSpaces(description, "Description", 50);

            if (price == 0)
            {
                _ValidationMethods.AddToInvalidFields("Price");
            }

            if (_ValidationMethods.isValid)
            {
                this.componentCode = componentCode;
                this.description = description;
                this.price = price;
            }
            else
            {
                _ValidationMethods.ShowErrorMessage();
            }
        }

        public Component(string productCode, string componentCode, string description, decimal price, int quantity)
        {
            _ValidationMethods.Reset();

            if (productCode != null || quantity != 0)
            {
                _ValidationMethods.ValidateCode(productCode, "Product Code", 5);
                _ValidationMethods.ValidateInteger(quantity.ToString(), "Quantity", 10);
            }

            _ValidationMethods.ValidateCode(componentCode, "Component Code", 5);
            _ValidationMethods.ValidateStringWithSpaces(description, "Description", 50);

            if (price == 0)
            {
                _ValidationMethods.AddToInvalidFields("Price");
            }
            
            if (_ValidationMethods.isValid)
            {
                this.productCode = productCode;
                this.componentCode = componentCode;
                this.description = description;
                this.price = price;
                this.quantity = quantity;
            }
            else
            {
                _ValidationMethods.ShowErrorMessage();
            }
        }

        public static List<Component> GetComponents(string productCode = null)
        {
            List<Component> components = new List<Component>();

            string tableName = "Component";

            if (DataHandler.ds.Tables.Contains(tableName))
            {
                DataHandler.ResetDataTable(tableName);
            }

            DataSet ds = new DataSet();

            if (productCode == null)
            {
                ds = DataHandler.GetDataSet(tableName);

                foreach (DataRow row in ds.Tables[tableName].Rows)
                {
                    components.Add(new Component(row["ComponentCode"].ToString(), row["Description"].ToString(), decimal.Parse(row["Price"].ToString())));
                }
            }
            else
            {
                ds = DataHandler.GetDataSet("Component", null, "spGetProductComponents", null, 0, productCode);

                foreach (DataRow row in ds.Tables[tableName].Rows)
                {
                    components.Add(new Component(row["ProductCode"].ToString(), row["ComponentCode"].ToString(), row["Description"].ToString(), decimal.Parse(row["Price"].ToString()), int.Parse(row["Quantity"].ToString())));
                }
            }

            return components;
        }

        public bool SaveComponentToDB()
        {
            if ((this.componentCode != null) && (this.description != null))
            {
                DataHandler.ResetDataSet();
                DataSet ds = DataHandler.GetDataSet("Component");

                DataHandler.AddComponent(this);

                return true;
            }
            else
            {
                return false;
            }            
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (!(obj is Component))
                {
                    Component component = obj as Component;

                    if (this != null && component != null)
                    {
                        return ((this.componentCode == component.componentCode) && (this.description == component.description) && (this.price == component.price) && (this.quantity == component.quantity));
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
