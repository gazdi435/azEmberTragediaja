using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Models
{
    internal class OrderItem : Queryable
    {
        public OrderItem(MySqlDataReader reader) : base(reader)
        {
            ID = reader.GetInt32("ID");
            OrderID = reader.GetInt32("OrderID");
            PizzaID = reader.GetInt32("PizzaID");
            Quantity = reader.GetInt32("Quantity");
        }

        public int ID { get; private set; }
        public int OrderID { get; private set; }
        public int PizzaID { get; private set; }
        public int Quantity { get; private set; }
    }
}
