using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary
{
    public abstract class Operation
    {
        private int id;
        private int orderID;
        private string productCode;
        private string technicianID;
        private DateTime startDateTimeOfOperation;
        private int? duration;
                
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

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

        public string TechnicianID
        {
            get { return technicianID; }
            set { technicianID = value; }
        }

        public DateTime StartDateTimeOfOperation
        {
            get { return startDateTimeOfOperation; }
            set { startDateTimeOfOperation = value; }
        }

        public int? Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        public Operation()
        {

        }

        public Operation(int id, int orderID, string productCode, string technicianID, DateTime startDateTimeOfOperation, int? duration)
        {
            this.id = id;
            this.orderID = orderID;
            this.productCode = productCode;
            this.technicianID = technicianID;
            this.startDateTimeOfOperation = startDateTimeOfOperation;
            this.duration = duration;
        }
                        
        public virtual bool CalculateDuration(int startHours, int startMinutes, int endHours, int endMinutes)
        {
            if (startHours <= endHours && !(startHours == endHours && startMinutes >= endMinutes))
            {
                //Hours are from 8:00 - 17:59
                if (startHours >= 8 && startHours <= 17 && endHours >= 8 && endHours <= 17 && startMinutes < 60 && endMinutes < 60)
                {
                    this.duration = (endHours - startHours) * 60;

                    if (endMinutes < startMinutes)
                    {
                        this.duration = this.duration - 60 + (60 - startMinutes) + endMinutes;
                    }
                    else
                    {
                        this.duration += endMinutes - startMinutes;
                    }

                    return true;
                }
                else
                {
                    MessageBox.Show("Times range from 08:00 to 17:59!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid times specified!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.duration = 0;

            return false;
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (!(obj is Operation))
                {
                    Operation operation = obj as Operation;

                    return ((this.id == operation.id) && (this.orderID == operation.orderID) && (this.productCode == operation.productCode) && (this.technicianID == operation.technicianID) && (this.startDateTimeOfOperation == operation.startDateTimeOfOperation) && (this.duration == operation.duration));
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
