using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Pizza.Models
{
    internal class User : Queryable
    {
        public int ID { get; private set; } = 0;
        public string Name { get; private set; }
        public string HashedPassword { get; private set; }
        public string Salt { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }
        public bool IsAdmin { get; private set; }

        public User(MySqlDataReader reader) : base(reader)
        {
            ID = reader.GetInt32("ID");
            Name = reader.GetString("Name");
            HashedPassword = reader.GetString("Password");
            Salt = reader.GetString("Salt");
            Email = reader.GetString("Email");
            Phone = reader.GetString("Phone");
            Address = reader.GetString("Address");
            IsAdmin = reader.GetBoolean("IsAdmin");
        }

        public User(string name, string plaintextPassword, string email, string phone, string address, Boolean isAdmin) : base(null)
        {
            Name = name;

            byte[] salt;
            HashedPassword = HashPassword(plaintextPassword, out salt);
            Salt = Convert.ToHexString(salt);

            Email = email;
            Phone = phone;
            Address = address;
            IsAdmin = isAdmin;
        }

        public override string ToString() => Name;

        public static string HashPassword(string plaintextPassword, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(64);

            var hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(plaintextPassword), salt, 350000, HashAlgorithmName.SHA512, 64);

            return Convert.ToHexString(hash);
        }

        public bool VerifyPassword(string plaintextPassword)
        {
            byte[] salt = Convert.FromHexString(Salt);
            var newHash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(plaintextPassword), salt, 350000, HashAlgorithmName.SHA512, 64);

            return CryptographicOperations.FixedTimeEquals(newHash, Convert.FromHexString(HashedPassword));
        }
    }
}
