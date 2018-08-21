using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CallLog
    {
        private DateTime startDateTime;
        private DateTime? endDateTime;
        private string administratorID;

        public DateTime StartDateTime
        {
            get { return startDateTime; }
            set { startDateTime = value; }
        }
        
        public DateTime? EndDateTime
        {
            get { return endDateTime; }
            set { endDateTime = value; }
        }
        
        public string AdministratorID
        {
            get { return administratorID; }
            set { administratorID = value; }
        }

        public CallLog()
        {

        }

        public CallLog(DateTime startDateTime, DateTime? endDateTime)
        {
            this.startDateTime = startDateTime;
            this.endDateTime = endDateTime;
            this.administratorID = Login.loggedInAdministratorID;
        }

        public void StartCallLog()
        {
            DataHandler.ResetDataSet();
            DataSet ds = DataHandler.GetDataSet("CallLog");

            DataHandler.AddCallLog(this);
        }

        public void EndCallLog()
        {
            this.endDateTime = DateTime.Now;

            DataHandler.EndCallLog(this);
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (obj is CallLog)
                {
                    CallLog callLog = obj as CallLog;

                    return ((this.startDateTime == callLog.startDateTime) && (this.endDateTime == callLog.endDateTime) && (this.administratorID == callLog.administratorID));
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
