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
