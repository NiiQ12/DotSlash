using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary
{
    public class Login
    {
        public static string loggedInAdministratorID;

        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public Login()
        {

        }

        public Login(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public bool ValidateLoginDetails()
        {
            DataHandler.ResetDataSet();
            DataSet ds = DataHandler.GetDataSet("Login");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string username = row[0].ToString();
                string password = row[1].ToString();

                if ((this.Username == username) && (this.Password == password))
                {
                    Login.loggedInAdministratorID = row["AdministratorID"].ToString();
                    return true;
                }
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (!(obj is Login))
                {
                    Login login = obj as Login;

                    return ((this.username == login.username) && (this.password == login.password));
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
