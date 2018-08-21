using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary
{
    public class Product
    {
        private string productCode;
        private string packageCode;
        private string description;
        private string manufacturerName;
        private int manufacturerID;
        private List<ClassLibrary.Component> components;

        public string ProductCode
        {
            get { return productCode; }
            set { productCode = value; }
        }

        public string PackageCode
        {
            get { return packageCode; }
            set { packageCode = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string ManufacturerName
        {
            get { return manufacturerName; }
            set { manufacturerName = value; }
        }

        public int ManufacturerID
        {
            get { return manufacturerID; }
            set { manufacturerID = value; }
        }

        public List<ClassLibrary.Component> Components
        {
            get { return components; }
            set { components = value; }
        }
        
        public Product()
        {

        }

        public Product(string packageCode, string productCode, string description, int manufacturerID)
        {
            _ValidationMethods.Reset();

            _ValidationMethods.ValidateDropDown(packageCode, "Package");
            _ValidationMethods.ValidateCode(productCode, "Product Code", 5);
            _ValidationMethods.ValidateStringWithSpaces(description, "Description", 50);

            if (_ValidationMethods.isValid)
            {
                this.packageCode = packageCode;
                this.productCode = productCode;
                this.description = description;

                this.manufacturerName = Manufacturer.GetManufacturers(productCode)[0].Name;
            }
            else
            {
                _ValidationMethods.ShowErrorMessage();
            }
        }

        public Product(string packageCode, string productCode, string description, string manufacturerName)
        {
            _ValidationMethods.Reset();

            _ValidationMethods.ValidateDropDown(packageCode, "Package");
            _ValidationMethods.ValidateCode(productCode, "Product Code", 5);
            _ValidationMethods.ValidateStringWithSpaces(description, "Description", 50);
            _ValidationMethods.ValidateDropDown(manufacturerName, "Manufacturer");
            
            if (_ValidationMethods.isValid)
            {
                this.packageCode = packageCode;
                this.productCode = productCode;
                this.description = description;
                this.manufacturerName = manufacturerName;

                List<Manufacturer> manufacturers = Manufacturer.GetManufacturers();

                foreach (Manufacturer manufacturer in manufacturers)
                {
                    if (manufacturer.Name == manufacturerName)
                    {
                        this.manufacturerID = manufacturer.ManufacturerID;
                    }
                }
            }
            else
            {
                _ValidationMethods.ShowErrorMessage();
            }
        }

        public static List<Product> GetProducts(string packageCode = null, bool? sellable = null)
        {
            List<Product> products = new List<Product>();

            string tableName = "Product";

            DataHandler.ResetDataSet();
            DataSet ds = new DataSet();

            if (packageCode == null && sellable == null)
            {
                ds = DataHandler.GetDataSet(tableName);
            }
            else if (packageCode == null && sellable != null)
            {
                ds = DataHandler.GetDataSet(tableName, null, "spGetSellableProducts", null, 0, null, null, sellable);
            }
            else if (packageCode != null && sellable != null)
            {
                ds = DataHandler.GetDataSet(tableName, null, "spGetSellableProductsInPackage", null, 0, null, packageCode, sellable);
            }

            foreach (DataRow row in ds.Tables[tableName].Rows)
            {
                string productCode = row["ProductCode"].ToString();

                products.Add(new Product(row["PackageCode"].ToString(), productCode, row["Description"].ToString(), int.Parse(row["ManufacturerID"].ToString())));
            }

            return products;
        }

        public static List<string> GetOrderProductCodes(string orderID)
        {
            List<string> productCodes = new List<string>();

            string tableName = "ProductCode";

            DataHandler.ResetDataSet();
            DataSet ds = DataHandler.GetDataSet(tableName, "SELECT DISTINCT ProductCode FROM OrderDetail WHERE OrderID = '"+orderID+"'");

            foreach (DataRow row in ds.Tables[tableName].Rows)
            {
                productCodes.Add(row["ProductCode"].ToString());
            }

            return productCodes;
        }

        public void SaveProductToDB()
        {
            DataHandler.ResetDataSet();
            DataSet ds = DataHandler.GetDataSet("Product");

            DataHandler.AddProduct(this);

            DataHandler.ResetDataSet();
            ds = DataHandler.GetDataSet("ProductComponent");

            DataHandler.AddProductComponents(this);
        }

        public static void RemoveProduct(string productCode)
        {
            DataHandler.RemoveProduct(productCode);
        }
        
        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (!(obj is Product))
                {
                    Product product = obj as Product;

                    if (this != null && product != null)
                    {
                        return ((this.packageCode == product.packageCode) && (this.productCode == product.productCode) && (this.description == product.description) && (this.manufacturerName == product.manufacturerName));
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
