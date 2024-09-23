using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Pizza.Models
{
    internal class User : Queryable
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }

        public User(MySqlDataReader reader) : base(reader)
        {
            ID = reader.GetInt32("ID");
            Name = reader.GetString("Name");
            Password = reader.GetString("Password");
            Email = reader.GetString("Email");
            Phone = reader.GetString("Phone");
            Address = reader.GetString("Address");
        }

        public override string ToString() => Name;
    }
}
