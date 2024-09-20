using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Models
{
    public class Ingredient
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public int Quantity { get; private set; }

        public Ingredient(MySqlDataReader reader)
        {
            ID = reader.GetInt32("IngredientID");
            Name = reader.GetString("Name");
            Quantity = reader.GetInt32("Quantity");
        }

        public Ingredient(int id, string name, int quantity = 0)
        {
            ID = id;
            Name = name;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
