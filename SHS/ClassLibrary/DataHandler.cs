using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary
{
    public static class DataHandler
    {
        private static OleDbConnection connection = new OleDbConnection("Provider=SQLNCLI10;Data Source=NICKYPC\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=SHS");
        public static DataSet ds = new DataSet();
        private static OleDbDataAdapter adapter;

        public static string lastAddedPK;
        public static int lastAddedServiceTicketID;
        public static string lastCallLogID;

        //Clear the tables and data in the dataset
        public static void ResetDataSet()
        {
            ds.Reset();
        }

        //Clear a specific table and its data in the dataset
        public static void ResetDataTable(string tableName)
        {
            ds.Tables[tableName].Rows.Clear();
        }

        //Clear last added primary key, in order to add it as a foreigh key in another table
        public static void SetLastAddedPK(string tableName, string primaryKeyName)
        {
            DataSet tempDataSet = GetDataSet(tableName);

            int rowCount = tempDataSet.Tables[tableName].Rows.Count;

            lastAddedPK = tempDataSet.Tables[tableName].Rows[rowCount - 1][primaryKeyName].ToString();
        }

        public static void SetCallLogID()
        {
            string tableName = "CallLog";

            DataSet tempDataSet = GetDataSet(tableName);

            int rowCount = tempDataSet.Tables[tableName].Rows.Count;

            lastCallLogID = tempDataSet.Tables[tableName].Rows[rowCount - 1]["CallLogID"].ToString();
        }

        public static void SetLastAddedServiceTicketID()
        {
            string tableName = "ServiceTicket";

            DataSet tempDataSet = GetDataSet(tableName);

            int rowCount = tempDataSet.Tables[tableName].Rows.Count;

            lastAddedServiceTicketID = int.Parse(tempDataSet.Tables[tableName].Rows[rowCount - 1]["ServiceTicketID"].ToString());
        }


        #region SelectOperations
        public static DataSet GetDataSet(string tableName, string selectQuery = null, string spName = null, string spParamClientID = null, int spParamOrderID = 0, string spParamProductCode = null, string spParamPackageCode = null, bool? spParamSellable = null)
        {
            try
            {
                connection.Open();

                if (connection.State == ConnectionState.Open)
                {
                    if (spName != null)
                    {
                        OleDbCommand cmd = new OleDbCommand(spName, connection);

                        //Set parameters of stored procedures
                        if (spParamOrderID != 0)
                        {
                            cmd.Parameters.Add("@OrderID", OleDbType.Integer).Value = spParamOrderID;
                        }
                        else if (spParamClientID != null)
                        {
                            cmd.Parameters.Add("@ClientID", OleDbType.Char, 9).Value = spParamClientID;
                        }
                        else if (spParamProductCode != null)
                        {
                            cmd.Parameters.Add("@ProductCode", OleDbType.Char, 5).Value = spParamProductCode;
                        }
                        else if (spParamPackageCode == null && spParamSellable != null)
                        {
                            cmd.Parameters.Add("@Sellable", OleDbType.Boolean).Value = spParamSellable;
                        }
                        else if (spParamPackageCode != null && spParamSellable == null)
                        {
                            cmd.Parameters.Add("@PackageCode", OleDbType.Char, 3).Value = spParamPackageCode;
                        }
                        else if (spParamPackageCode != null && spParamSellable != null)
                        {
                            cmd.Parameters.Add("@Sellable", OleDbType.Boolean).Value = spParamSellable;
                            cmd.Parameters.Add("@PackageCode", OleDbType.Char, 3).Value = spParamPackageCode;
                        }

                        cmd.CommandType = CommandType.StoredProcedure;

                        adapter.SelectCommand = cmd;
                    }
                    else if (selectQuery != null)
                    {
                        adapter = new OleDbDataAdapter(selectQuery, connection);
                    }
                    else
                    {
                        adapter = new OleDbDataAdapter("SELECT * FROM " + tableName, connection);
                    }

                    adapter.FillSchema(ds, SchemaType.Source, tableName);
                    adapter.Fill(ds, tableName);

                    return ds;
                }
                else
                {
                    throw new CustomException("Connection to the database cannot be established!");
                }
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (CustomException e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }

            return null;
        }
        #endregion
        

        #region UpdateOperations
        public static void RemoveProduct(string productCode)
        {
            try
            {
                connection.Open();

                if (connection.State == ConnectionState.Open)
                {
                    OleDbCommand cmd = new OleDbCommand("spRemoveProduct", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProductCode", OleDbType.Char, 5).Value = productCode;

                    cmd.ExecuteNonQuery();
                }
                else
                {
                    throw new CustomException("Connection to the database cannot be established!");
                }
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (CustomException e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        public static void FinaliseOperation(string spName, int operationID, string technicianID, int? duration, decimal? cost = null)
        {
            try
            {
                connection.Open();

                if (connection.State == ConnectionState.Open)
                {
                    OleDbCommand cmd = new OleDbCommand(spName, connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@OperationID", OleDbType.Integer).Value = operationID;
                    cmd.Parameters.Add("@TechnicianID", OleDbType.Char, 13).Value = technicianID;
                    cmd.Parameters.Add("@Duration", OleDbType.Integer).Value = duration;

                    if (cost != null)
                    {
                        cmd.Parameters.Add("@Cost", OleDbType.Currency).Value = cost;
                    }

                    cmd.ExecuteNonQuery();
                }
                else
                {
                    throw new CustomException("Connection to the database cannot be established!");
                }
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (CustomException e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        public static void EndCallLog(CallLog callLog)
        {
            try
            {
                connection.Open();

                if (connection.State == ConnectionState.Open)
                {
                    OleDbCommand cmd = new OleDbCommand("spEndCall", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EndDateTime", OleDbType.Date).Value = callLog.EndDateTime;
                    cmd.Parameters.Add("@CallLogID", OleDbType.Integer).Value = lastCallLogID;

                    cmd.ExecuteNonQuery();
                }
                else
                {
                    throw new CustomException("Connection to the database cannot be established!");
                }
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (CustomException e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        //Update any changes made to current table in the dataset
        public static void UpdateDB(string tableName)
        {
            OleDbCommandBuilder objCommandBuilder = new OleDbCommandBuilder(adapter);
            adapter.Update(ds, tableName);
        }
        #endregion
        

        #region InsertOperations
        public static void AddAddress(Address address)
        {
            DataTable tbl;
            tbl = ds.Tables["Address"];

            DataRow drNew;
            drNew = tbl.NewRow();

            drNew["City"] = address.City;
            drNew["Suburb"] = address.Suburb;
            drNew["Street"] = address.Street;
            drNew["Port"] = address.Port;

            tbl.Rows.Add(drNew);

            UpdateDB("Address");

            SetLastAddedPK("Address", "AddressID");
        }

        public static bool AddClient(Client client)
        {
            DataTable tbl;
            tbl = ds.Tables["Client"];

            if (!tbl.Rows.Contains(client.ID))
            {
                DataRow drNew;
                drNew = tbl.NewRow();

                drNew["ClientID"] = client.ClientID;
                drNew["IDNumber"] = client.ID;
                drNew["Name"] = client.Name;
                drNew["Surname"] = client.Surname;
                drNew["ContactNo"] = client.ContactNo;
                drNew["Email"] = client.Email;
                drNew["AddressID"] = int.Parse(lastAddedPK);
                drNew["Contract"] = client.Contract;

                tbl.Rows.Add(drNew);

                UpdateDB("Client");

                SetLastAddedPK("Client", "ClientID");

                return true;
            }
            else
            {
                MessageBox.Show("Client ID already exists!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }

        public static void AddOrder(Order order)
        {
            DataTable tbl;
            tbl = ds.Tables["tblOrder"];

            DataRow drNew;
            drNew = tbl.NewRow();

            drNew["ClientID"] = order.ClientID;
            drNew["DateOrdered"] = order.OrderDate;

            tbl.Rows.Add(drNew);

            UpdateDB("tblOrder");

            SetLastAddedPK("tblOrder", "OrderID");
        }

        public static void AddOrderDetails(Order order)
        {
            DataTable tbl;
            tbl = ds.Tables["OrderDetail"];

            foreach (OrderDetail orderDetail in order.OrderDetails)
            {
                DataRow drNew;
                drNew = tbl.NewRow();

                drNew["OrderID"] = int.Parse(lastAddedPK);
                drNew["ProductCode"] = orderDetail.ProductCode;
                drNew["ComponentCode"] = orderDetail.ComponentCode;
                drNew["Quantity"] = orderDetail.Quantity;

                tbl.Rows.Add(drNew);
            }

            UpdateDB("OrderDetail");
        }

        public static void AddInstalledProducts(List<InstalledProduct> installedProducts)
        {
            DataTable tbl;
            tbl = ds.Tables["InstalledProduct"];

            foreach (InstalledProduct installedProduct in installedProducts)
            {
                DataRow drNew;
                drNew = tbl.NewRow();

                drNew["OrderID"] = installedProduct.OrderID;
                drNew["ProductCode"] = installedProduct.ProductCode;
                drNew["LastMaintenance"] = DBNull.Value;
                drNew["StillInstalled"] = true;

                tbl.Rows.Add(drNew);
            }

            UpdateDB("InstalledProduct");
        }

        public static void AddInstallations(List<Installation> installations)
        {
            DataTable tbl;
            tbl = ds.Tables["Installation"];

            foreach (Installation installation in installations)
            {
                DataRow drNew;
                drNew = tbl.NewRow();

                drNew["OrderID"] = installation.OrderID;
                drNew["ProductCode"] = installation.ProductCode;
                drNew["DateOfInstallation"] = installation.StartDateTimeOfOperation.ToShortDateString();

                tbl.Rows.Add(drNew);
            }

            UpdateDB("Installation");
        }

        public static void AddMaintenances(List<Maintenance> maintenances)
        {
            DataTable tbl;
            tbl = ds.Tables["Maintenance"];

            foreach (Maintenance maintenance in maintenances)
            {
                DataRow drNew;
                drNew = tbl.NewRow();

                drNew["OrderID"] = maintenance.OrderID;
                drNew["ProductCode"] = maintenance.ProductCode;
                drNew["DateOfMaintenance"] = maintenance.StartDateTimeOfOperation.ToShortDateString();

                tbl.Rows.Add(drNew);
            }

            UpdateDB("Maintenance");
        }

        public static void AddPackage(Package package)
        {
            DataTable tbl;
            tbl = ds.Tables["Package"];

            DataRow drNew;
            drNew = tbl.NewRow();

            drNew["PackageCode"] = package.PackageCode;
            drNew["Name"] = package.Name;

            tbl.Rows.Add(drNew);

            UpdateDB("Package");
        }

        public static void AddComponent(Component component)
        {
            DataTable tbl;
            tbl = ds.Tables["Component"];

            DataRow drNew;
            drNew = tbl.NewRow();

            drNew["ComponentCode"] = component.ComponentCode;
            drNew["Description"] = component.Description;
            drNew["Price"] = component.Price;

            tbl.Rows.Add(drNew);

            UpdateDB("Component");
        }

        public static void AddProduct(Product product)
        {
            DataTable tbl;
            tbl = ds.Tables["Product"];

            DataRow drNew;
            drNew = tbl.NewRow();

            drNew["ProductCode"] = product.ProductCode;
            drNew["PackageCode"] = product.PackageCode;
            drNew["Description"] = product.Description;
            drNew["ManufacturerID"] = product.ManufacturerID;
            drNew["Sellable"] = true;

            tbl.Rows.Add(drNew);

            UpdateDB("Product");
        }

        public static void AddProductComponents(Product product)
        {
            List<ClassLibrary.Component> components = product.Components;

            DataTable tbl = ds.Tables["ProductComponent"];

            for (int i = 0; i < components.Count; i++)
            {
                DataRow drNew = tbl.NewRow();

                drNew["ProductCode"] = product.ProductCode;
                drNew["ComponentCode"] = components[i].ComponentCode;
                drNew["DefaultQuantity"] = components[i].Quantity;

                tbl.Rows.Add(drNew);
            }

            UpdateDB("ProductComponent");
        }

        public static void AddCallLog(CallLog callLog)
        {
            DataTable tbl;
            tbl = ds.Tables["CallLog"];

            DataRow drNew;
            drNew = tbl.NewRow();

            string startDate = callLog.StartDateTime.ToString();

            DateTime startDateTime = DateTime.Parse(startDate);

            drNew["StartDateTime"] = startDateTime;
            drNew["AdministratorID"] = callLog.AdministratorID;

            tbl.Rows.Add(drNew);

            UpdateDB("CallLog");

            SetCallLogID();
        }
        
        public static void AddServiceTicket(ServiceTicket serviceTicket)
        {
            DataTable tbl;
            tbl = ds.Tables["ServiceTicket"];

            DataRow drNew;
            drNew = tbl.NewRow();

            drNew["CallLogID"] = serviceTicket.CallLogID;
            drNew["ProblemDescription"] = serviceTicket.ProblemDescription;

            tbl.Rows.Add(drNew);

            UpdateDB("ServiceTicket");

            SetLastAddedServiceTicketID();
        }

        public static void AddCorrection(Correction correction)
        {
            DataTable tbl;
            tbl = ds.Tables["Correction"];

            DataRow drNew;
            drNew = tbl.NewRow();

            drNew["ServiceTicketID"] = lastAddedServiceTicketID;
            drNew["OrderID"] = correction.OrderID;
            drNew["ProductCode"] = correction.ProductCode;
            drNew["DateOfCorrection"] = correction.StartDateTimeOfOperation.ToShortDateString();

            tbl.Rows.Add(drNew);

            UpdateDB("Correction");
        }
        #endregion


        #region DeleteOperations
        public static void DeleteRow(string tableName, string idValue)
        {
            ResetDataSet();
            ds = DataHandler.GetDataSet(tableName);

            ds.Tables[tableName].Rows.Find(idValue).Delete();

            UpdateDB(tableName);
        }

        public static void DeleteRows(string tableName, string idKey, string idValue)
        {
            ResetDataSet();
            ds = DataHandler.GetDataSet(tableName);

            foreach (DataRow row in ds.Tables[tableName].Rows)
            {
                if (row[idKey].ToString() == idValue)
                {
                    row.Delete();
                }
            }

            UpdateDB(tableName);
        }
        #endregion
    }
}
