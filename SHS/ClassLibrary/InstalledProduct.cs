using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class InstalledProduct
    {
        private int orderID;
        private string productCode;
        private DateTime lastMaintenance;
        private bool stillInstalled;
                
        public int OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }

        public string ProductCode
        {
            get { return productCode; }
            set { productCode = value; }
        }

        public DateTime LastMaintenance
        {
            get { return lastMaintenance; }
            set { lastMaintenance = value; }
        }

        public bool StillInstalled
        {
            get { return stillInstalled; }
            set { stillInstalled = value; }
        }

        public InstalledProduct()
        {

        }

        public InstalledProduct(int orderID, string productCode, bool stillInstalled)
        {
            this.orderID = orderID;
            this.productCode = productCode;
            this.stillInstalled = stillInstalled;
        }

        public static void DeleteInstalledProductFromDB(string orderID)
        {
            DataHandler.ResetDataSet();
            DataSet ds = DataHandler.GetDataSet("InstalledProduct");

            DataHandler.DeleteRows("InstalledProduct", "OrderID", orderID);
        }
        
        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (!(obj is InstalledProduct))
                {
                    InstalledProduct installedProduct = obj as InstalledProduct;

                    return ((this.orderID == installedProduct.orderID) && (this.productCode == installedProduct.productCode) && (this.stillInstalled == installedProduct.stillInstalled));
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
