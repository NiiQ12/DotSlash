using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary
{
    public class Package
    {
        private string packageCode;
        private string name;
        private List<Product> products;

        public string PackageCode
        {
            get { return packageCode; }
            set { packageCode = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<Product> Products
        {
            get { return products; }
            set { products = value; }
        }

        public Package()
        {

        }

        public Package(string name)
        {
            List<Package> packages = GetPackages();

            bool validPackageCode;
            bool validPackageName = true;

            string packageCode = "";

            int characterPos = 0;

            foreach (char character in name)
            {
                //Construct pakcago code based on the uppercased first letter of every word in the package name
                if (characterPos == 0 || name[characterPos - 1] == ' ')
                {
                    packageCode += character.ToString().ToUpper();
                }

                characterPos++;
            }

            Random ran = new Random();

            if (packageCode.Length > 3)
            {
                //Only use first 3 letters
                packageCode = packageCode.Substring(0, 3);
            }
            else if (packageCode.Length < 3)
            {
                int length = packageCode.Length;

                //Append random number(s)
                for (int i = 0; i < 3 - length; i++)
                {
                    packageCode += ran.Next(0, 10).ToString();
                }
            }

            int count = 0;

            do
            {
                validPackageCode = true;

                //Check if package name already exists
                foreach (Package package in packages)
                {
                    if (package.name == name)
                    {
                        validPackageName = false;
                    }

                    if (package.packageCode == packageCode)
                    {
                        validPackageCode = false;
                    }
                }

                if (!validPackageCode)
                {
                    packageCode = packageCode.Substring(0, 2) + count.ToString();
                    count++;
                }
            } while (!validPackageCode);

            this.name = name;

            if (validPackageName)
            {
                this.packageCode = packageCode;
            }
            else
            {
                this.packageCode = "-----";
            }
        }

        public Package(string packageCode, string name)
        {
            this.packageCode = packageCode;
            this.name = name;
        }

        public static List<Package> GetPackages(string packageName = null)
        {
            List<Package> packages = new List<Package>();

            string tableName = "Package";

            if (DataHandler.ds.Tables.Contains(tableName))
            {
                DataHandler.ResetDataTable(tableName);
            }

            DataSet ds = new DataSet();

            if (packageName == null)
            {
                ds = DataHandler.GetDataSet(tableName);
            }
            else
            {
                ds = DataHandler.GetDataSet(tableName, "SELECT * FROM Package WHERE Name = '"+packageName+"'");
            }

            foreach (DataRow row in ds.Tables[tableName].Rows)
            {
                packages.Add(new Package(row["PackageCode"].ToString(), row["Name"].ToString()));
            }

            return packages;
        }

        public void SavePackageToDB()
        {
            string tableName = "Package";

            DataHandler.ResetDataSet();
            DataSet ds = DataHandler.GetDataSet(tableName);

            DataHandler.AddPackage(this);
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (!(obj is Package))
                {
                    Package package = obj as Package;

                    if (this != null && package != null)
                    {
                        return ((this.name == package.name) && (this.products.Equals(package.products)));
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
