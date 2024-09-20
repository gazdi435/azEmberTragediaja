using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Models
{
    internal class Order
    {
        public Order(int iD, int userID, DateTime orderDate, string status)
        {
            ID = iD;
            UserID = userID;
            OrderDate = orderDate;
            Status = status;
        }

        public int ID { get; private set; }
        public int UserID { get; private set; }
        public DateTime OrderDate { get; private set; }
        public string Status { get; private set; }
    }
}
