using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary
{
    public enum InstallationType
    {
        ALL = 0, COMPLETED, SCHEDULED
    }

    public class Installation : Operation
    {
        public static int listCount;
        public static int days;

        private decimal? cost;

        public decimal? Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        public Installation()
        {

        }

        public Installation(int id, int orderID, string productCode, string technicianID, DateTime startDateTimeOfOperation, int? duration, decimal? cost)
            : base(id, orderID, productCode, technicianID, startDateTimeOfOperation, duration)
        {
            this.cost = cost;

            if (StartDateTimeOfOperation == DateTime.MinValue)
            {
                this.StartDateTimeOfOperation = SetStartDateTime();
            }
        }

        public static List<Installation> GetInstallations(InstallationType typeOfInstallation)
        {
            List<Installation> installations = new List<Installation>();

            string tableName = "Installation";

            DataHandler.ResetDataSet();

            DataSet ds = new DataSet();

            switch (typeOfInstallation)
            {
                case InstallationType.COMPLETED:
                    ds = DataHandler.GetDataSet(tableName, "SELECT * FROM Installation WHERE Duration IS NOT NULL");
                    break;
                case InstallationType.SCHEDULED: 
                    ds = DataHandler.GetDataSet(tableName, "SELECT * FROM Installation WHERE Duration IS NULL");
                    break;
                default:
                    ds = DataHandler.GetDataSet(tableName);
                    break;
            }
            
            foreach (DataRow row in ds.Tables[tableName].Rows)
            {
                string duration = row["Duration"].ToString();
                string cost = row["Cost"].ToString();
                
                if ((duration == null || duration == "") && (cost == null || cost == ""))
                {
                    installations.Add(new Installation(int.Parse(row["InstallationID"].ToString()), int.Parse(row["OrderID"].ToString()), row["ProductCode"].ToString(), row["TechnicianID"].ToString(), DateTime.Parse(row["DateOfInstallation"].ToString()), null, null));
                }
                else if (duration == null || duration == "")
                {
                    installations.Add(new Installation(int.Parse(row["InstallationID"].ToString()), int.Parse(row["OrderID"].ToString()), row["ProductCode"].ToString(), row["TechnicianID"].ToString(), DateTime.Parse(row["DateOfInstallation"].ToString()), null, decimal.Parse(cost)));
                }
                else if (cost == null || cost == "")
                {
                    installations.Add(new Installation(int.Parse(row["InstallationID"].ToString()), int.Parse(row["OrderID"].ToString()), row["ProductCode"].ToString(), row["TechnicianID"].ToString(), DateTime.Parse(row["DateOfInstallation"].ToString()), int.Parse(duration), null));
                }
                else
                {
                    installations.Add(new Installation(int.Parse(row["InstallationID"].ToString()), int.Parse(row["OrderID"].ToString()), row["ProductCode"].ToString(), row["TechnicianID"].ToString(), DateTime.Parse(row["DateOfInstallation"].ToString()), int.Parse(duration), decimal.Parse(cost)));
                }
            }

            return installations;
        }

        public void OnProductsOrdered(object sender, OrderEventArgs e)
        {
            //--- Create InstalledProducts, Installations and Maintenance objects
            List<InstalledProduct> installedProducts = new List<InstalledProduct>();
            List<Installation> installations = new List<Installation>();
            List<Maintenance> maintenances = new List<Maintenance>();

            foreach (Product product in Order.productsToOrder)
            {
                installedProducts.Add(new InstalledProduct(int.Parse(DataHandler.lastAddedPK), product.ProductCode, true));

                installations.Add(new Installation(0, int.Parse(DataHandler.lastAddedPK), product.ProductCode, null, DateTime.MinValue, 0, 0));
                Installation.listCount++;

                if (e.Client.Contract != null)
                {
                    maintenances.Add(new Maintenance(0, int.Parse(DataHandler.lastAddedPK), product.ProductCode, null, DateTime.MinValue, 0, e.Client.Contract));
                    Maintenance.listCount++;
                }
            }
            //---

            //--- Add InstalledProducts, Installations and Maintenance
            DataSet ds = DataHandler.GetDataSet("InstalledProduct");
            DataHandler.AddInstalledProducts(installedProducts);

            ds = DataHandler.GetDataSet("Installation");
            DataHandler.AddInstallations(installations);

            ds = DataHandler.GetDataSet("Maintenance");
            DataHandler.AddMaintenances(maintenances);
            //---
        }

        public void FinaliseInstallation()
        {
            DataHandler.FinaliseOperation("spFinaliseInstallation", this.ID, this.TechnicianID, this.Duration, this.cost);
        }

        public DateTime SetStartDateTime()
        {
            bool scheduled = false;
            
            do
            {
                //Get the amount of scheduled operations the following day
                List<Schedule> schedule = Schedule.GetScheduleFromDB(DateTime.Now.AddDays(days).ToString().Substring(0, 10));

                if (schedule.Count + listCount < 10)
                {
                    //Schedule the operation on the following day if less than 10 operations has been scheduled
                    return DateTime.Now.AddDays(days);
                }
                else
                {
                    //Increment days, in order to check the next day
                    listCount = 0;
                    days++;
                }
            } while (!scheduled);

            return DateTime.Now;
        }

        public override bool CalculateDuration(int startHours, int startMinutes, int endHours, int endMinutes)
        {
            return base.CalculateDuration(startHours, startMinutes, endHours, endMinutes);
        }
        
        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (!(obj is Installation))
                {
                    Installation installation = obj as Installation;

                    return ((base.Equals(installation)) && (this.cost == installation.cost));
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
