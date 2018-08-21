using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary
{
    public class Address
    {
        private string city;
        private string suburb;
        private string street;
        private string port;

        public string City
        {
            get { return city; }
        }

        public string Suburb
        {
            get { return suburb; }
        }

        public string Street
        {
            get { return street; }
        }

        public string Port
        {
            get { return port; }
        }

        public Address()
        {

        }

        public Address(string city, string suburb, string street, string port)
        {
            _ValidationMethods.Reset();

            _ValidationMethods.ValidateStringWithSpaces(city, "City", 50);
            _ValidationMethods.ValidateStringWithSpaces(suburb, "Suburb", 50);
            _ValidationMethods.ValidateStringWithSpaces(street, "Street", 50);

            if (port.Length > 10 || port == String.Empty || port == null)
            {
                _ValidationMethods.AddToInvalidFields("Port");
            }

            if (_ValidationMethods.isValid)
            {
                this.city = city;
                this.suburb = suburb;
                this.street = street;
                this.port = port;
            }
        }

        public static Address GetAddress(string clientID)
        {
            Address address = new Address();

            string tableName = "Address";

            if (DataHandler.ds.Tables.Contains(tableName))
            {
                DataHandler.ResetDataTable(tableName);
            }

            DataSet ds = DataHandler.GetDataSet("Address", null, "spGetAddress", clientID);

            foreach (DataRow row in ds.Tables[tableName].Rows)
            {
                address = new Address(row["City"].ToString(), row["Suburb"].ToString(), row["Street"].ToString(), row["Port"].ToString());
            }

            return address;
        }
        
        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (!(obj is Address))
                {
                    Address address = obj as Address;

                    if (this != null && address != null)
                    {
                        return ((this.city == address.city) && (this.suburb == address.suburb) && (this.street == address.street) && (this.port == address.port));
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
