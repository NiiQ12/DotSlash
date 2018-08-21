using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class OrderDetail
    {
        private string productCode;
        private string componentCode;
        private int quantity;

        public string ProductCode
        {
            get { return productCode; }
            set { productCode = value; }
        }

        public string ComponentCode
        {
            get { return componentCode; }
            set { componentCode = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public OrderDetail()
        {

        }

        public OrderDetail(string productCode, string componentCode, int quantity)
        {
            this.productCode = productCode;
            this.componentCode = componentCode;
            this.quantity = quantity;
        }
        
        public static List<OrderDetail> GetOrderDetails(int orderID)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();

            string tableName = "OrderDetail";

            if (DataHandler.ds.Tables.Contains(tableName))
            {
                DataHandler.ResetDataTable(tableName);
            }

            DataSet ds = DataHandler.GetDataSet("OrderDetail", null, "spGetOrderDetails", null, orderID);

            foreach (DataRow row in ds.Tables[tableName].Rows)
            {
                orderDetails.Add(new OrderDetail(row["ProductCode"].ToString(), row["ComponentCode"].ToString(), int.Parse(row["Quantity"].ToString())));
            }

            return orderDetails;
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (!(obj is OrderDetail))
                {
                    OrderDetail orderDetail = obj as OrderDetail;

                    return ((this.productCode == orderDetail.productCode) && (this.componentCode == orderDetail.componentCode) && (this.quantity == orderDetail.quantity));
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
