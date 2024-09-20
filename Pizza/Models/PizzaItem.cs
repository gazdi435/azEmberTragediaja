using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace Pizza.Models
{
    internal class PizzaItem
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public BitmapImage Img { get; private set; }
        public double Price { get; private set; }

        public PizzaItem(int id, string name, string description, double price)
        {
            ID = id;
            Name = name;
            Description = description;
            Price = price;
        }

        public PizzaItem(MySqlDataReader reader)
        {
            ID = reader.GetInt32("PizzaID");
            Name = reader.GetString("Name");
            Description = reader.GetString("Description");
            //Img = reader.getb
            Price = reader.GetDouble("Price");
        }

        public static List<PizzaItem> GetPizzas()
        {
            // TEMP
            return [new PizzaItem(1, "Example 1", "asd asd asd asd asd", 1200),
                new PizzaItem(2, "Example 2", "dfgdfg g hdgdfg dgdsg dfgdf dfhdfgdfgdf", 3000),
                new PizzaItem(3, "Example 3", "hgfh dhfh dre sgd shdfh sdfds", 1000)];
        }

        public Dictionary<Ingredient, int> GetIngredients()
        {
            Dictionary<Ingredient, int> ingredients = new();

            // TEMP
            foreach (Ingredient ingredient in Ingredient.GetIngredients())
            {
                ingredients[ingredient] = 2;
            }

            return ingredients;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
