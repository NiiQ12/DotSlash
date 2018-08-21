using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Technician : Person
    {
        private DateTime dateEmployed;
        private decimal commission;

        public DateTime DateEmployed
        {
            get { return dateEmployed; }
            set { dateEmployed = value; }
        }

        public decimal Commission
        {
            get { return commission; }
            set { commission = value; }
        }

        public Technician()
        {

        }

        public Technician(string id, string name, string surname, string contactNo, string email, DateTime dateEmployed, decimal commission)
            : base(id, name, surname, contactNo, email)
        {
            this.dateEmployed = dateEmployed;
            this.commission = commission;
        }

        public static List<Technician> GetTechnicians()
        {
            List<Technician> technicians = new List<Technician>();

            string tableName = "Technician";

            DataHandler.ResetDataSet();
            DataSet ds = DataHandler.GetDataSet(tableName);

            foreach (DataRow row in ds.Tables[tableName].Rows)
            {
                technicians.Add(new Technician(row["ID"].ToString(), row["Name"].ToString(), row["Surname"].ToString(), row["ContactNo"].ToString(), row["Email"].ToString(), DateTime.Parse(row["DateEmployed"].ToString()), decimal.Parse(row["Commission"].ToString())));
            }

            return technicians;
        }
        
        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (!(obj is Technician))
                {
                    Technician technician = obj as Technician;

                    return ((base.Equals(technician)) && (this.commission == technician.commission) && (this.dateEmployed == technician.dateEmployed));
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
