using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ServiceTicket
    {
        private string callLogID;
        private string problemDescription;

        public string CallLogID
        {
            get { return callLogID; }
            set { callLogID = value; }
        }
        
        public string ProblemDescription
        {
            get { return problemDescription; }
            set { problemDescription = value; }
        }
        
        public ServiceTicket()
        {

        }

        public ServiceTicket(string callLogID, string problemDescription)
        {
            _ValidationMethods.ValidateStringWithSpaces(problemDescription, "Problem", 100);

            if (_ValidationMethods.isValid)
            {
                this.callLogID = callLogID;
                this.problemDescription = problemDescription;
            }
            else
            {
                _ValidationMethods.ShowErrorMessage();
            }
        }

        public void SaveServiceTicketToDB()
        {
            DataHandler.ResetDataSet();

            DataSet ds = DataHandler.GetDataSet("ServiceTicket");
            DataHandler.AddServiceTicket(this);
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (!(obj is ServiceTicket))
                {
                    ServiceTicket serviceTicket = obj as ServiceTicket;

                    return ((this.callLogID == serviceTicket.callLogID) && (this.problemDescription == serviceTicket.problemDescription));
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
