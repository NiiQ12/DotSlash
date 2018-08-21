using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary
{
    public enum CorrectionType
    { 
        ALL = 0, COMPLETED, SCHEDULED
    }

    public class Correction : Operation
    {
        public static int days;

        private decimal? cost;
        private int? serviceTicketID;

        public decimal? Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        public int? ServiceTicketID
        {
            get { return serviceTicketID; }
            set { serviceTicketID = value; }
        }

        public Correction()
        {

        }

        public Correction(int id, int orderID, string productCode, string technicianID, DateTime startDateTimeOfOperation, int? duration, decimal? cost, int? serviceTicketID)
            : base(id, orderID, productCode, technicianID, startDateTimeOfOperation, duration)
        {
            this.cost = cost;
            this.serviceTicketID = serviceTicketID;
            
            if (StartDateTimeOfOperation == DateTime.MinValue)
            {
                this.StartDateTimeOfOperation = SetStartDateTime();
            }
        }

        public static List<Correction> GetCorrections(CorrectionType typeOfCorrection)
        {
            List<Correction> corrections = new List<Correction>();

            string tableName = "Correction";

            DataHandler.ResetDataSet();
            DataSet ds = new DataSet();

            switch (typeOfCorrection)
            {
                case CorrectionType.COMPLETED:
                    ds = DataHandler.GetDataSet(tableName, "SELECT * FROM Correction WHERE Duration IS NOT NULL");
                    break;
                case CorrectionType.SCHEDULED:
                    ds = DataHandler.GetDataSet(tableName, "SELECT * FROM Correction WHERE Duration IS NULL");
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
                    corrections.Add(new Correction(int.Parse(row["CorrectionID"].ToString()), int.Parse(row["OrderID"].ToString()), row["ProductCode"].ToString(), row["TechnicianID"].ToString(), DateTime.Parse(row["DateOfCorrection"].ToString()), null, null, int.Parse(row["ServiceTicketID"].ToString())));
                }
                else if (duration == null || duration == "")
                {
                    corrections.Add(new Correction(int.Parse(row["CorrectionID"].ToString()), int.Parse(row["OrderID"].ToString()), row["ProductCode"].ToString(), row["TechnicianID"].ToString(), DateTime.Parse(row["DateOfCorrection"].ToString()), null, decimal.Parse(cost), int.Parse(row["ServiceTicketID"].ToString())));
                }
                else if (cost == null || cost == "")
                {
                    corrections.Add(new Correction(int.Parse(row["CorrectionID"].ToString()), int.Parse(row["OrderID"].ToString()), row["ProductCode"].ToString(), row["TechnicianID"].ToString(), DateTime.Parse(row["DateOfCorrection"].ToString()), int.Parse(duration), null, int.Parse(row["ServiceTicketID"].ToString())));
                }
                else
                {
                    corrections.Add(new Correction(int.Parse(row["CorrectionID"].ToString()), int.Parse(row["OrderID"].ToString()), row["ProductCode"].ToString(), row["TechnicianID"].ToString(), DateTime.Parse(row["DateOfCorrection"].ToString()), int.Parse(duration), decimal.Parse(cost), int.Parse(row["ServiceTicketID"].ToString())));
                }
            }

            return corrections;
        }

        public void SaveCorrectionToDB()
        {
            DataHandler.ResetDataSet();

            DataSet ds = DataHandler.GetDataSet("Correction");
            DataHandler.AddCorrection(this);
        }

        public static void DeleteCorrectionFromDB(string correctionID)
        {
            DataHandler.ResetDataSet();
            DataSet ds = DataHandler.GetDataSet("Correction");

            DataHandler.DeleteRow("Correction", correctionID);
        }

        public void FinaliseCorrection()
        {
            DataHandler.FinaliseOperation("spFinaliseCorrection", this.ID, this.TechnicianID, this.Duration, this.cost);
        }

        public static DateTime SetStartDateTime()
        {
            bool scheduled = false;

            do
            {
                //Get the amount of scheduled operations the following day
                List<Schedule> schedule = Schedule.GetScheduleFromDB(DateTime.Now.AddDays(days).ToString().Substring(0, 10));

                if (schedule.Count < 10)
                {
                    //Schedule the operation on the following day if less than 10 operations has been scheduled
                    return DateTime.Now.AddDays(days);
                }
                else
                {
                    //Increment days, in order to check the next day
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
                if (!(obj is Correction))
                {
                    Correction correction = obj as Correction;

                    return ((base.Equals(correction)) && (this.cost == correction.cost) && (this.serviceTicketID == correction.serviceTicketID));
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
