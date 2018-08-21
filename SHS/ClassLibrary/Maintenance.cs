using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary
{
    public enum MaintenanceType
    {
        ALL = 0, COMPLETED, SCHEDULED
    }

    public class Maintenance : Operation
    {
        public static int listCount;
        public static int days;

        public Maintenance()
        {

        }

        public Maintenance(int id, int orderID, string productCode, string technicianID, DateTime startDateTimeOfOperation, int? duration, string contract = null)
            : base(id, orderID, productCode, technicianID, startDateTimeOfOperation, duration)
        {
            if (StartDateTimeOfOperation == DateTime.MinValue && contract != null)
            {
                this.StartDateTimeOfOperation = SetStartDateTime(contract);
            }
        }

        public static List<Maintenance> GetMaintenances(MaintenanceType typeOfMaintenance)
        {
            List<Maintenance> maintenances = new List<Maintenance>();

            string tableName = "Maintenance";

            DataHandler.ResetDataSet();

            DataSet ds = new DataSet();

            switch (typeOfMaintenance)
            {
                case MaintenanceType.COMPLETED:
                    ds = DataHandler.GetDataSet(tableName, "SELECT * FROM Maintenance WHERE Duration IS NOT NULL");
                    break;
                case MaintenanceType.SCHEDULED:
                    ds = DataHandler.GetDataSet(tableName, "SELECT * FROM Maintenance WHERE Duration IS NULL");
                    break;
                default:
                    ds = DataHandler.GetDataSet(tableName);
                    break;
            }

            foreach (DataRow row in ds.Tables[tableName].Rows)
            {
                string duration = row["Duration"].ToString();

                if (duration == null || duration == "")
                {
                    maintenances.Add(new Maintenance(int.Parse(row["MaintenanceID"].ToString()), int.Parse(row["OrderID"].ToString()), row["ProductCode"].ToString(), row["TechnicianID"].ToString(), DateTime.Parse(row["DateOfMaintenance"].ToString()), null, null));
                }
                else
                {
                    maintenances.Add(new Maintenance(int.Parse(row["MaintenanceID"].ToString()), int.Parse(row["OrderID"].ToString()), row["ProductCode"].ToString(), row["TechnicianID"].ToString(), DateTime.Parse(row["DateOfMaintenance"].ToString()), int.Parse(duration), null));
                }
            }

            return maintenances;
        }

        public void FinaliseMaintenance()
        {
            DataHandler.FinaliseOperation("spFinaliseMaintenance", this.ID, this.TechnicianID, this.Duration);
        }

        public static DateTime SetStartDateTime(string contract)
        {
            char maintenanceCode = Char.Parse(contract.Substring(4, 1));

            bool scheduled = false;

            do
            {
                List<Schedule> schedule = new List<Schedule>();

                //Get the amount of scheduled operations the in 6/12 months depending on the maintenance plan
                if (maintenanceCode == 'A')
                {
                    schedule = Schedule.GetScheduleFromDB(DateTime.Now.AddMonths(6).AddDays(days).ToString().Substring(0, 10));
                }
                else if (maintenanceCode == 'B')
                {
                    schedule = Schedule.GetScheduleFromDB(DateTime.Now.AddMonths(12).AddDays(days).ToString().Substring(0, 10));
                }

                if (schedule.Count + listCount < 10)
                {
                    //Schedule the operation if less than 10 operations has been scheduled
                    if (maintenanceCode == 'A')
                    {
                        return DateTime.Now.AddMonths(6).AddDays(days);
                    }
                    else if (maintenanceCode == 'B')
                    {
                        return DateTime.Now.AddMonths(12).AddDays(days);
                    }                    
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
                if (!(obj is Maintenance))
                {
                    Maintenance maintenance = obj as Maintenance;

                    return (base.Equals(maintenance));
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
