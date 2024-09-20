using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Models
{
    internal class OrderItem
    {
        public OrderItem(int iD, int orderID, int pizzaID, int quantity, string size)
        {
            ID = iD;
            OrderID = orderID;
            PizzaID = pizzaID;
            Quantity = quantity;
            Size = size;
        }

        public int ID { get; private set; }
        public int OrderID { get; private set; }
        public int PizzaID { get; private set; }
        public int Quantity { get; private set; }
        public string Size { get; private set; }
    }
}
