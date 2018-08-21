using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Manufacturer
    {
        private int manufacturerID;
        private string name;
        private string contactNo;

        public int ManufacturerID
        {
            get { return manufacturerID; }
            set { manufacturerID = value; }
        }
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string ContactNo
        {
            get { return contactNo; }
            set { contactNo = value; }
        }

        public Manufacturer()
        {

        }

        public Manufacturer(int manufacturerID, string name, string contactNo)
        {
            this.manufacturerID = manufacturerID;
            this.name = name;
            this.contactNo = contactNo;
        }

        public static List<Manufacturer> GetManufacturers(string productCode = null)
        {
            List<Manufacturer> manufacturers = new List<Manufacturer>();

            string tableName = "Manufacturer";
            
            if (DataHandler.ds.Tables.Contains(tableName))
            {
                DataHandler.ResetDataTable(tableName);
            }

            DataSet ds;

            if (productCode == null)
            {
                ds = DataHandler.GetDataSet(tableName);
            }
            else
            {
                ds = DataHandler.GetDataSet(tableName, null, "spGetManufacturer", null, 0, productCode);
            }
             
            foreach (DataRow row in ds.Tables[tableName].Rows)
            {
                manufacturers.Add(new Manufacturer(int.Parse(row["ManufacturerID"].ToString()), row["Name"].ToString(), row["ContactNo"].ToString()));
            }

            return manufacturers;
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (!(obj is Manufacturer))
                {
                    Manufacturer manufacturer = obj as Manufacturer;

                    return ((this.name == manufacturer.name) && (this.contactNo == manufacturer.contactNo));
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
