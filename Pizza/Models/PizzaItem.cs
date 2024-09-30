using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace Pizza.Models
{
    internal class PizzaItem : Queryable
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }

        public PizzaItem(MySqlDataReader reader) : base(reader)
        {
            ID = reader.GetInt32("ID");
            Name = reader.GetString("Name");
            Description = reader.GetString("Description");
            Price = reader.GetDouble("Price");
        }

        public override string ToString() => Name;
    }
}
