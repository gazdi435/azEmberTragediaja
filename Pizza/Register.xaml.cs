using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using MySqlConnector;
using System.Text.RegularExpressions;
using Pizza.Models;
using System.Diagnostics;

namespace Pizza
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class Register : UserControl
    {
        public string name;

        public Register()
        {
            InitializeComponent();
        }

        //=> MainWindow.mainWindow.TransitionTo();

        private string MindenOk()
        {
            StringBuilder sb = new();

            Regex email = new(@"^\S+@\S+\.\S+$"),
                  name = new("^[\\p{L} \\.'\\-]+$");

            if (!email.IsMatch(emailTXTB.Text))
                sb.Append("Az email cím már létezik!");

            if (!name.IsMatch(name2TXTB.Text))
                sb.Append("Hibás felhasználónév!");

            if (!Sql.EmailExists(emailTXTB.Text))
                sb.Append("Hibás email cím!");
            
            return sb.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = MindenOk();

            if (!string.IsNullOrWhiteSpace(str))
            {
                MessageBox.Show($"Hibák:\n\t{string.Join("!\n\t", str.Split('!')[..^1])}!");
                return;
            }

            User newUser = new(nameTXTB.Text, pswB.Password, emailTXTB.Text, phoneTXTB.Text, addressTXTB.Text);
            Sql.CreateUser(newUser);
            MainWindow.user = newUser;

            MainWindow.mainWindow.Page = new UserPage();
            MainWindow.mainWindow.RefreshUI();
        }
    }
}
