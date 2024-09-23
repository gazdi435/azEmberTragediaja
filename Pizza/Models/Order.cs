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

        public static bool PlaceOrder(List<PizzaItem> pizzas)
        {
            Dictionary<int, int> totalIngredients = [];
            Dictionary<int, int> orderItems = [];
            foreach (PizzaItem pizza in pizzas)
            {
                Dictionary<Ingredient, int> ingredients = Sql.GetPizzaIngredients(pizza.ID);
                foreach (var item in ingredients)
                {
                    totalIngredients[item.Key.ID] = totalIngredients.GetValueOrDefault(item.Key.ID, 0) + item.Value;
                }

                orderItems[pizza.ID] = orderItems.GetValueOrDefault(pizza.ID, 0) + 1;
            }

            List<Ingredient> allIngredients = Sql.GetIngredients();

            if (totalIngredients.Any(x => allIngredients.Find(y => y.ID == x.Key).Quantity < x.Value))
            {
                return false;
            }

            int orderId = Sql.CreateOrder();
            Sql.AddOrderItems(orderId, orderItems);
            Sql.DecreaseIngredients(totalIngredients);

            return true;
        }
    }
}
