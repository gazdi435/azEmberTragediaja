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
    public class PizzaItem
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

        public override string ToString()
        {
            return Name;
        }
    }
}
