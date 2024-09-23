using MySqlConnector;
using Pizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza
{
    internal static class Sql
    {
        public static string conStr = "server=127.0.0.1;uid=root;pwd=;database=pizza";

        public static User GetUserByID(int id)
        {
            User user;
            MySqlCommand cmd = new("SELECT * FROM users WHERE UserID =@id");
            cmd.Parameters.AddWithValue("id", id);

            using (MySqlConnection con = new(conStr))
            {
                cmd.Connection = con;
                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    user = new(reader);
                }
            }

            return user;
        }

        public static List<PizzaItem> GetPizzas()
        {
            List <PizzaItem> pizzas = new();
            MySqlCommand cmd = new("SELECT * FROM pizzas");

            using (MySqlConnection con = new(conStr))
            {
                cmd.Connection = con;
                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pizzas.Add(new(reader));
                    }
                }
            }

            return pizzas;
        }
        public static List<Ingredient> GetIngredients()
        {
            List<Ingredient> ingredients = new();
            MySqlCommand cmd = new("SELECT * FROM ingredients");

            using (MySqlConnection con = new(conStr))
            {
                cmd.Connection = con;
                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ingredients.Add(new(reader));
                    }
                }
            }

            return ingredients;
        }

        public static Dictionary<Ingredient, int> GetPizzaIngredients(int pizzaId)
        {
            Dictionary<Ingredient, int> ingredients = [];
            MySqlCommand cmd = new("SELECT ingredients.IngredientID, ingredients.Name, ingredients.Quantity, toppings.Quantity as 'ToppingQuantity' FROM pizzas JOIN toppings ON pizzas.PizzaID = toppings.PizzaID JOIN ingredients ON ingredients.IngredientID = toppings.ToppingID WHERE pizzas.PizzaID = @id;");
            cmd.Parameters.AddWithValue("id", pizzaId);

            using (MySqlConnection con = new(conStr))
            {
                cmd.Connection = con;
                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Ingredient ingredient = new(reader);
                        ingredients[ingredient] = reader.GetInt32("ToppingQuantity");
                    }
                }
            }

            return ingredients;
        }

        public static int CreateOrder()
        {
            MySqlCommand cmd = new("INSERT INTO orders (UserID, OrderDate, Status) VALUES (@user, now(), 'Baking')");
            cmd.Parameters.AddWithValue("user", 1); //TODO

            using (MySqlConnection con = new(conStr))
            {
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(cmd.LastInsertedId);
            }
        }

        public static void AddOrderItems(int orderId, Dictionary<int, int> pizzas)
        {
            MySqlCommand cmd = new("INSERT INTO orderitems (OrderID, PizzaID, Quantity, Size) VALUES (@order, @pizza, @qty, @size)");
            cmd.Parameters.AddWithValue("order", orderId);
            cmd.Parameters.Add("pizza", MySqlDbType.Int32);
            cmd.Parameters.Add("qty", MySqlDbType.Int32);
            cmd.Parameters.Add("size", MySqlDbType.String);

            using (MySqlConnection con = new(conStr))
            {
                cmd.Connection = con;
                con.Open();

                foreach (var item in pizzas)
                {
                    cmd.Parameters["pizza"].Value = item.Key;
                    cmd.Parameters["qty"].Value = item.Value;
                    cmd.Parameters["size"].Value = "24"; //TODO
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DecreaseIngredients(Dictionary<int, int> ingredients)
        {
            MySqlCommand cmd = new("UPDATE ingredients SET Quantity = Quantity - @amount WHERE IngredientID = @id");
            cmd.Parameters.Add("amount", MySqlDbType.Int32);
            cmd.Parameters.Add("id", MySqlDbType.Int32);

            using (MySqlConnection con = new(conStr))
            {
                cmd.Connection = con;
                con.Open();

                foreach (var item in ingredients)
                {
                    cmd.Parameters["amount"].Value = item.Value;
                    cmd.Parameters["id"].Value = item.Key;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static bool EmailExists(string email)
        {
            bool res;
            MySqlCommand cmd = new("SELECT * FROM users WHERE Email = @email");
            cmd.Parameters.AddWithValue("email", email);
            using (MySqlConnection con = new(conStr))
            {
                cmd.Connection = con;
                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    res = reader.Read();
                }
            }

            return res;
        }
        public static bool EmailPasswordValid(string email, string password)
        {
            bool res;
            MySqlCommand cmd = new("SELECT * FROM users WHERE Email = @email AND Password = @password");
            cmd.Parameters.AddWithValue("email", email);
            cmd.Parameters.AddWithValue("password", password);
            using (MySqlConnection con = new(conStr))
            {
                cmd.Connection = con;
                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    res = reader.Read();
                }
            }

            return res;
        }
    }
}
