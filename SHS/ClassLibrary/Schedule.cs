using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Schedule
    {
        private string type;
        private int orderID;
        private string productCode;
        private string dateOfOperation;
        private string technician;
        private char priority;

        public char Priority
        {
            get { return priority; }
            set { priority = value; }
        }
                
        public string Technician
        {
            get { return technician; }
            set { technician = value; }
        }
        
        public string DateOfOperation
        {
            get { return dateOfOperation; }
            set { dateOfOperation = value; }
        }
        
        public string ProductCode
        {
            get { return productCode; }
            set { productCode = value; }
        }
        
        public int OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }
        
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public Schedule(string type, int orderID, string productCode, string dateOfOperation, string technician, string contract)
        {
            this.type = type;
            this.orderID = orderID;
            this.productCode = productCode;
            this.dateOfOperation = dateOfOperation;
            this.technician = technician;

            if (contract != null && contract != "")
            {
                this.priority = char.Parse(contract.Substring(5,1));
            }
        }

        //Get scheduled installations, maintenances, and corrections
        public static List<Schedule> GetScheduleFromDB(string date)
        {
            List<Schedule> schedule = new List<Schedule>();

            DataHandler.ResetDataSet();

            DataSet dsClients = DataHandler.GetDataSet("tblOrder", "SELECT OrderID, Contract FROM tblOrder INNER JOIN Client ON tblOrder.ClientID = Client.ClientID");
            DataSet dsTechnicians = DataHandler.GetDataSet("Technician", "SELECT Name, Surname FROM Technician");
            DataSet dsInstallations = DataHandler.GetDataSet("Installation", "SELECT * FROM Installation WHERE DateOfInstallation = '" + date + "'");
            DataSet dsMaintenances = DataHandler.GetDataSet("Maintenance", "SELECT * FROM Maintenance WHERE DateOfMaintenance = '" + date + "'");
            DataSet dsCorrections = DataHandler.GetDataSet("Correction", "SELECT * FROM Correction WHERE DateOfCorrection = '" + date + "'");

            List<string> technicians = new List<string>();

            //Add technicians twice, since 1 technician can perform 2 operations daily
            foreach (DataRow row in dsTechnicians.Tables["Technician"].Rows)
            {
                technicians.Add(row["Name"].ToString() + " " + row["Surname"].ToString());
            }

            foreach (DataRow row in dsTechnicians.Tables["Technician"].Rows)
            {
                technicians.Add(row["Name"].ToString() + " " + row["Surname"].ToString());
            }

            int technicianCounter = 0;

            foreach (DataRow row in dsInstallations.Tables["Installation"].Rows)
            {
                string contract = "";

                foreach (DataRow row2 in dsClients.Tables["tblOrder"].Rows)
                {
                    if (row["OrderID"].ToString() == row2["OrderID"].ToString())
                    {
                        contract = row2["Contract"].ToString();
                    }
                }

                schedule.Add(new Schedule("Installation", int.Parse(row["OrderID"].ToString()), row["ProductCode"].ToString(), row["DateOfInstallation"].ToString().Substring(0, 10), technicians[technicianCounter], contract));
                technicianCounter++;
            }

            foreach (DataRow row in dsMaintenances.Tables["Maintenance"].Rows)
            {
                string contract = "";

                foreach (DataRow row2 in dsClients.Tables["tblOrder"].Rows)
                {
                    if (row["OrderID"].ToString() == row2["OrderID"].ToString())
                    {
                        contract = row2["Contract"].ToString();
                    }
                }

                schedule.Add(new Schedule("Maintenance", int.Parse(row["OrderID"].ToString()), row["ProductCode"].ToString(), row["DateOfMaintenance"].ToString().Substring(0, 10), technicians[technicianCounter], contract));
                technicianCounter++;
            }

            foreach (DataRow row in dsCorrections.Tables["Correction"].Rows)
            {
                string contract = "";

                foreach (DataRow row2 in dsClients.Tables["tblOrder"].Rows)
                {
                    if (row["OrderID"].ToString() == row2["OrderID"].ToString())
                    {
                        contract = row2["Contract"].ToString();
                    }
                }

                schedule.Add(new Schedule("Correction", int.Parse(row["OrderID"].ToString()), row["ProductCode"].ToString(), row["DateOfCorrection"].ToString().Substring(0, 10), technicians[technicianCounter], contract));
                technicianCounter++;
            }

            return schedule;
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (!(obj is Schedule))
                {
                    Schedule schedule = obj as Schedule;

                    return ((this.type == schedule.type) && (this.orderID == schedule.orderID) && (this.productCode == schedule.productCode) && (this.dateOfOperation == schedule.dateOfOperation));
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
