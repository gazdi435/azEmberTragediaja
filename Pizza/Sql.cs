using MySqlConnector;
using Pizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace Pizza;

internal static class Sql
{
    public static string conStr = "server=127.0.0.1;uid=root;pwd=;database=pizza";


    #region __GetByID__
    private static T? GetItemByID<T>(string table, int id) where T : Queryable<MySqlDataReader>
    {
        T? res;
        MySqlCommand cmd = new("SELECT * FROM @table WHERE ID = @id");
        cmd.Parameters.AddWithValue("@table", table);
        cmd.Parameters.AddWithValue("@id", id);

        using(MySqlConnection con = new(conStr))
        {
            cmd.Connection = con;
            con.Open();
            using(MySqlDataReader reader = cmd.ExecuteReader())
            {
                reader.Read();
                res = Activator.CreateInstance(typeof(T), reader) as T;
            }
        }

        return res;
    }

    public static User? GetUserByID(int id) => GetItemByID<User>("users", id);
    public static PizzaItem? GetPizzabyID(int id) => GetItemByID<PizzaItem>("pizzas", id);
    public static OrderItem? GetOrderItemByID(int id) => GetItemByID<OrderItem>("orderitems", id);
    public static Ingredient? GetIngredientByID(int id) => GetItemByID<Ingredient>("ingredients", id);
    #endregion

    public static List<PizzaItem> GetPizzas()
    {
        List<PizzaItem> pizzas = new();
        MySqlCommand cmd = new("SELECT * FROM pizzas");

        using(MySqlConnection con = new(conStr))
        {
            cmd.Connection = con;
            con.Open();
            using(MySqlDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
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

        using(MySqlConnection con = new(conStr))
        {
            cmd.Connection = con;
            con.Open();
            using(MySqlDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
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
        MySqlCommand cmd = new("SELECT ingredients.ID, ingredients.Name, ingredients.Quantity, toppings.Quantity as 'ToppingQuantity' FROM pizzas JOIN toppings ON pizzas.ID = toppings.PizzaID JOIN ingredients ON ingredients.ID = toppings.IngredientID WHERE pizzas.ID = @id;");
        cmd.Parameters.AddWithValue("id", pizzaId);

        using(MySqlConnection con = new(conStr))
        {
            cmd.Connection = con;
            con.Open();
            using(MySqlDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
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
        cmd.Parameters.AddWithValue("user", MainWindow.user.ID);

        using(MySqlConnection con = new(conStr))
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

        using(MySqlConnection con = new(conStr))
        {
            cmd.Connection = con;
            con.Open();

            foreach(var item in pizzas)
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
        MySqlCommand cmd = new("UPDATE ingredients SET Quantity = Quantity - @amount WHERE ID = @id");
        cmd.Parameters.Add("amount", MySqlDbType.Int32);
        cmd.Parameters.Add("id", MySqlDbType.Int32);

        using(MySqlConnection con = new(conStr))
        {
            cmd.Connection = con;
            con.Open();

            foreach(var item in ingredients)
            {
                cmd.Parameters["amount"].Value = item.Value;
                cmd.Parameters["id"].Value = item.Key;
                cmd.ExecuteNonQuery();
            }
        }
    }

    public static void SetIngredientAmount(int id, int newAmount)
    {
        MySqlCommand cmd = new("UPDATE ingredients SET Quantity = @amount WHERE ID = @id");
        cmd.Parameters.AddWithValue("id", id);
        cmd.Parameters.AddWithValue("amount", newAmount);

        using (MySqlConnection con = new(conStr))
        {
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public static Ingredient CreateIngredient(string name)
    {
        MySqlCommand cmd = new("INSERT INTO ingredients (Name, Quantity) VALUES (@name, 0)");
        cmd.Parameters.AddWithValue("name", name);

        using (MySqlConnection con = new(conStr))
        {
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            return new Ingredient(Convert.ToInt32(cmd.LastInsertedId), name, 0);
        }
    }

    public static void DeleteIngredient(int id)
    {
        MySqlCommand cmd = new("DELETE FROM ingredients WHERE ID = @id");
        cmd.Parameters.AddWithValue("id", id);

        using (MySqlConnection con = new(conStr))
        {
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }

    #region __Auth__
    public static User GetUserByEmail(string email)
    {
        User user;
        MySqlCommand cmd = new("SELECT * FROM users WHERE Email = @email");
        cmd.Parameters.AddWithValue("email", email);
        using(MySqlConnection con = new(conStr))
        {
            cmd.Connection = con;
            con.Open();
            using(MySqlDataReader reader = cmd.ExecuteReader())
            {
                reader.Read();
                user = new(reader);
            }
        }

        return user;
    }
    public static bool EmailExists(string email)
    {
        bool res;
        MySqlCommand cmd = new("SELECT * FROM users WHERE Email = @email");
        cmd.Parameters.AddWithValue("email", email);
        using(MySqlConnection con = new(conStr))
        {
            cmd.Connection = con;
            con.Open();
            using(MySqlDataReader reader = cmd.ExecuteReader())
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
        using(MySqlConnection con = new(conStr))
        {
            cmd.Connection = con;
            con.Open();
            using(MySqlDataReader reader = cmd.ExecuteReader())
            {
                res = reader.Read();
            }
        }

        return res;
    }
    #endregion
}