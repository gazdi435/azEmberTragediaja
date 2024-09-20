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
        //public List<T> GetAllFrom<T>(string table)
        //{
        //    List<T> items = new();
        //    MySqlCommand cmd = new("SELECT * FROM @table");
        //    cmd.Parameters.AddWithValue("table", table);

        //    using (MySqlConnection con = new(conStr))
        //    {
        //        cmd.Connection = con;
        //        con.Open();
        //        using (MySqlDataReader reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                items.Add(new(reader));
        //            }
        //        }
        //    }

        //    return items;
        //}
    }
}
