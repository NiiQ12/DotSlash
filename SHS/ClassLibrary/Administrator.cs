using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Administrator : Person
    {
        private decimal salary;
        private DateTime dateEmployed;

        public decimal Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public DateTime DateEmployed
        {
            get { return dateEmployed; }
        }
                
        public Administrator()
        {

        }

        public Administrator(string id, string name, string surname, string contactNo, string email, decimal salary, DateTime dateEmployed)
            : base(id, name, surname, contactNo, email)
        {
            this.salary = salary;
            this.dateEmployed = dateEmployed;
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (!(obj is Administrator))
                {
                    Administrator administrator = obj as Administrator;

                    return ((base.Equals(administrator)) && (this.salary == administrator.salary) && (this.dateEmployed == administrator.dateEmployed));
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
