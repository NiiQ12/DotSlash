using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary
{
    public class Client : Person
    {
        DataSet ds = new DataSet();
        public static string[] maintenancePlans = { "6-Month Plan", "12-Month Plan" };

        private string clientID;
        private Address address;
        private string contract;
        private string maintenancePlan;
        private char priority;

        public string ClientID
        {
            get { return clientID; }
            set { clientID = value; }
        }

        public Address Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Contract
        {
            get { return contract; }
            set { contract = value; }
        }

        public string MaintenancePlan
        {
            get { return maintenancePlan; }
            set { maintenancePlan = value; }
        }

        public char Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        public Client()
        {

        }

        public string SetClientID()
        {
            string str = "";

            DataHandler.ResetDataSet();
            ds = DataHandler.GetDataSet("Client");

            bool clientIdIsValid = true;

            //Generate unique client ID
            do
            {
                Random ran1 = new Random();
                int num1 = ran1.Next(1, 6);
                char chr = '\0';

                //Choose random character between A,B,C,D,E
                switch (num1)
                {
                    case 1: chr = 'A'; break;
                    case 2: chr = 'B'; break;
                    case 3: chr = 'C'; break;
                    case 4: chr = 'D'; break;
                    case 5: chr = 'E'; break;
                }

                Random ran2 = new Random();
                int num2 = ran2.Next(1, 99999999);      //Generate random 8-digit number

                int numLength = num2.ToString().Length;
                string zeroes = "";

                //Append 0's to the left if the 8-digit number begins with a 0
                for (int i = 0; i < 8 - numLength; i++)
                {
                    zeroes += "0";
                }

                string clientIdNum = zeroes + num2.ToString();

                str = chr + clientIdNum;

                foreach (DataRow row in ds.Tables["Client"].Rows)
                {
                    if (row["ClientID"].ToString() == str)
                    {
                        clientIdIsValid = false;
                    }
                }
            } while (!clientIdIsValid);

            return str;
        }

        public Client(string id, string clientID, string name, string surname, string contactNo, string email, Address address, string contract)
            : base(id, name, surname, contactNo, email)
        {
            this.address = address;

            if (clientID != null)
            {
                this.clientID = clientID;
            }
            else
            {
                this.clientID = SetClientID();
            }

            if (contract != null && contract != String.Empty)
            {
                this.contract = contract;

                //Get maintenance plan based on the character A/B in the client contract ID
                switch (Char.Parse(contract.Substring(4, 1)))
                {
                    case 'A':
                        this.maintenancePlan = maintenancePlans[0];
                        break;
                    case 'B':
                        this.maintenancePlan = maintenancePlans[1];
                        break;
                }

                this.priority = Char.Parse(contract.Substring(5, 1));
            }
            else
            {
                this.contract = null;
                this.maintenancePlan = null;
                this.priority = '\0';
            }

            if (!_ValidationMethods.isValid)
            {
                _ValidationMethods.ShowErrorMessage();
            }
        }

        public Client(string id, string clientID, string name, string surname, string contactNo, string email, Address address, string maintenancePlan, char priority)
            : base(id, name, surname, contactNo, email)
        {
            this.address = address;

            _ValidationMethods.ValidateDropDown(maintenancePlan, "Maintenance");
            _ValidationMethods.ValidateChar(priority, "Priority");

            if (_ValidationMethods.isValid)
            {
                this.maintenancePlan = maintenancePlan;
                this.priority = priority;

                if (clientID != null)
                {
                    this.clientID = clientID;

                    DataHandler.ResetDataSet();
                    ds = DataHandler.GetDataSet("Client");
                }
                else
                {
                    this.clientID = SetClientID();
                }

                char maintenanceChar;

                //Get maintenance plan character (A/B) based on the maintenance plan chosen
                if (this.maintenancePlan == maintenancePlans[0])
                {
                    maintenanceChar = 'A';
                }
                else
                {
                    maintenanceChar = 'B';
                }

                bool contractIsValid = true;
                int num = 1;

                do
                {
                    int numLength = num.ToString().Length;
                    string zeroes = "";

                    //Append 0's to the left if the 6-digit number begins with a 0
                    for (int i = 0; i < 6 - numLength; i++)
                    {
                        zeroes += "0";
                    }

                    string contractNumber = zeroes + num.ToString();

                    //Construct the new contract - e.g. 2018AA837462
                    this.contract = DateTime.Now.Year.ToString() + maintenanceChar.ToString() + priority.ToString() + contractNumber;

                    foreach (DataRow row in ds.Tables["Client"].Rows)
                    {
                        if (row["Contract"].ToString() == this.contract)
                        {
                            contractIsValid = false;
                            num++;
                        }
                    }
                } while (!contractIsValid);
            }
            else
            {
                _ValidationMethods.ShowErrorMessage();
            }
        }

        public bool SaveClientToDB()
        {
            bool idNumberIsValid = true;

            DataHandler.ResetDataSet();
            ds = DataHandler.GetDataSet("Client");

            //Check if the client already exists in the database - ID Number cannot be duplicated
            foreach (DataRow row in ds.Tables["Client"].Rows)
            {
                if (row["IDNumber"].ToString() == this.ID)
                {
                    idNumberIsValid = false;
                }
            }

            if (!idNumberIsValid)
            {
                MessageBox.Show("Client with the ID Number, " + this.ID + ", already exists!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            else
            {
                //Add address first
                DataHandler.ResetDataSet();
                ds = DataHandler.GetDataSet("Address");
                DataHandler.AddAddress(this.address);

                //Get address again, in order to get the last added primary key
                DataHandler.ResetDataSet();
                ds = DataHandler.GetDataSet("Address");

                //Add client last
                DataHandler.ResetDataSet();
                ds = DataHandler.GetDataSet("Client");

                Client client = new Client(this.ID, this.clientID, this.Name, this.Surname, this.ContactNo, this.Email, this.address, this.contract);

                DataHandler.AddClient(client);

                return true;
            }
        }

        public static List<Client> GetClients()
        {
            List<Client> clients = new List<Client>();

            string tableName = "Client";

            DataHandler.ResetDataSet();
            DataSet ds = DataHandler.GetDataSet(tableName);

            foreach (DataRow row in ds.Tables[tableName].Rows)
            {
                string clientID = row["ClientID"].ToString();

                clients.Add(new Client(row["IDNumber"].ToString(), clientID, row["Name"].ToString(), row["Surname"].ToString(), row["ContactNo"].ToString(), row["Email"].ToString(), Address.GetAddress(clientID), row["Contract"].ToString()));
            }

            return clients;
        }

        public static DataTable GetClientDataTable()
        {
            DataHandler.ResetDataSet();

            string tableName = "Client";

            return DataHandler.GetDataSet(tableName).Tables[tableName];
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (!(obj is Client))
                {
                    Client client = obj as Client;

                    return (base.Equals(client) && (this.address.Equals(client.address)) && (this.contract == client.contract));
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
