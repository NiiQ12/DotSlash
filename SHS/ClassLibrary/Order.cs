using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary
{
    public enum OrderType
    {
        All, COMPLETED, PENDING
    }

    public class Order
    {
        public static BindingList<Product> productsToOrder = new BindingList<Product>();

        private int orderID;
        private string clientID;
        private DateTime orderDate;
        private List<OrderDetail> orderDetails;

        public int OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }

        public string ClientID
        {
            get { return clientID; }
            set { clientID = value; }
        }

        public DateTime OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }

        public List<OrderDetail> OrderDetails
        {
            get { return orderDetails; }
            set { orderDetails = value; }
        }

        public Order()
        {

        }

        public Order(string clientID, DateTime orderDate, List<OrderDetail> orderDetails)
        {
            this.clientID = clientID;
            this.orderDate = orderDate;
            this.orderDetails = orderDetails;
        }

        public Order(int orderID, string clientID, DateTime orderDate, List<OrderDetail> orderDetails)
            : this(clientID, orderDate, orderDetails)
        {
            this.orderID = orderID;
        }

        public static List<Order> GetOrders(OrderType typeOfOrder)
        {
            List<Order> orders = new List<Order>();

            string tableName = "tblOrder";

            DataHandler.ResetDataSet();
            DataSet ds = new DataSet();

            switch (typeOfOrder)
            {
                case OrderType.COMPLETED:
                    ds = DataHandler.GetDataSet(tableName, null, "spGetCompletedOrders");
                    break;
                case OrderType.PENDING:
                    ds = DataHandler.GetDataSet(tableName, null, "spGetPendingOrders");
                    break;
                default:
                    ds = DataHandler.GetDataSet(tableName);
                    break;
            }
                        
            foreach (DataRow row in ds.Tables[tableName].Rows)
            {
                int orderID = int.Parse(row["OrderID"].ToString());

                orders.Add(new Order(orderID, row["ClientID"].ToString(), DateTime.Parse(row["DateOrdered"].ToString()), OrderDetail.GetOrderDetails(orderID)));
            }

            return orders;
        }

        public static List<string> GetClientOrderIDs(string clientIDNumber)
        {
            List<string> orderIDs = new List<string>();

            string tableName = "tblOrder";

            DataHandler.ResetDataSet();
            DataSet ds = DataHandler.GetDataSet(tableName, "SELECT tblOrder.OrderID FROM tblOrder INNER JOIN Client	ON tblOrder.ClientID = Client.ClientID WHERE Client.IDNumber = '"+clientIDNumber+"'");

            foreach (DataRow row in ds.Tables[tableName].Rows)
            {
                orderIDs.Add(row["OrderID"].ToString());
            }

            return orderIDs;
        }

        public static bool ProductExistsInOrder(string productDescription)
        {
            foreach (Product product in productsToOrder)
            {
                if (product.Description == productDescription)
                {
                    return true;
                }
            }

            return false;
        }
        
        public delegate void ProductsOrderedEventHandler(object sender, OrderEventArgs e);

        //Event called after a product is ordered, in order to schedule the installation
        public event ProductsOrderedEventHandler ProductsOrdered;

        Client client = new Client();

        public void OrderProducts(Client clientParam)
        {
            client = clientParam;

            Installation.listCount = 0;
            Installation.days = 1;

            Maintenance.listCount = 0;
            Maintenance.days = 1;

            //--- Create Order and OrderDetails objects
            List<OrderDetail> orderDetails = new List<OrderDetail>();

            foreach (Product product in productsToOrder)
            {
                foreach (ClassLibrary.Component component in product.Components)
                {
                    orderDetails.Add(new OrderDetail(product.ProductCode, component.ComponentCode, component.Quantity));
                }
            }

            this.orderDetails = orderDetails;
            //---

            //--- Add Order and OrderDetails
            DataHandler.ResetDataSet();

            DataSet ds = DataHandler.GetDataSet("tblOrder");
            DataHandler.AddOrder(this);

            ds = DataHandler.GetDataSet("OrderDetail");
            DataHandler.AddOrderDetails(this);
            //---

            OnProductsOrdered();
        }

        protected virtual void OnProductsOrdered()
        {
            if (ProductsOrdered != null)
            {
                ProductsOrdered(this, new OrderEventArgs() { Client = client });
            }
        }

        public static string GetTotal()
        {
            decimal total = 0;

            foreach (Product product in productsToOrder)
            {
                foreach (ClassLibrary.Component component in product.Components)
                {
                    decimal subTotal = component.Price * component.Quantity;

                    total += subTotal;
                }
            }

            string strTotal = total.ToString();

            //Format the strTotal to always have 2 decimal places
            if (!strTotal.Contains('.'))
            {
                return strTotal + ".00";
            }
            else if (strTotal.Length < strTotal.IndexOf('.'))
            {
                return strTotal + "00";
            }
            else if (strTotal.Length < strTotal.IndexOf('.') + 1)
            {
                return strTotal + "0";
            }
            else 
            {
                return strTotal;
            }
        }

        public static void DeleteOrderFromDB(string orderID)
        {
            DataHandler.ResetDataSet();
            DataSet ds = DataHandler.GetDataSet("tblOrder");

            DataHandler.DeleteRow("tblOrder", orderID);

            InstalledProduct.DeleteInstalledProductFromDB(orderID);
        }
        
        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (!(obj is Order))
                {
                    Order order = obj as Order;

                    return ((this.clientID == order.clientID) && (this.orderDate == order.orderDate) && (this.orderDetails.Equals(order.orderDetails)));
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
