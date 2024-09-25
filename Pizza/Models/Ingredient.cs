using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Models
{
    internal class Ingredient : Queryable
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public int Quantity { get; set; }

        public Ingredient(MySqlDataReader reader) : base(reader)
        {
            ID = reader.GetInt32(0);
            Name = reader.GetString(1);
            Quantity = reader.GetInt32(2);
        }

        public Ingredient(int id, string name, int quantity = 0) : base(null)
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
