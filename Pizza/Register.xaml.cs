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

        private void TextBlock_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.Page = new Login();
            MainWindow.mainWindow.RefreshUI();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string pattern = @"^\S+@\S+\.\S+$";

            if (!Regex.IsMatch(emailTXTB.Text, pattern))
            {
                pattern = "^[\\p{L} \\.'\\-]+$";
                if (!Regex.IsMatch(nameTXTB.Text, pattern))
                {
                    if (!Sql.EmailExists(emailTXTB.Text))
                    {
                        User newUser = new Models.User(nameTXTB.Text, pswB.Password, emailTXTB.Text, phoneTXTB.Text, addressTXTB.Text);
                        Sql.CreateUser(newUser);
                        MainWindow.user = newUser;

                        MainWindow.mainWindow.Page = new UserPage();
                        MainWindow.mainWindow.RefreshUI();

                    }
                    else
                    {
                        MessageBox.Show("Az email cím már létezik");
                    }
                }
                else
                {
                    MessageBox.Show("Hibás felhasználónév!");
                }
            }
            else
            {
                MessageBox.Show("Hibás email cím!");
            }
            

            nameTXTB.Clear();
            emailTXTB.Clear();
            addressTXTB.Clear();
            phoneTXTB.Clear();
            pswB.Clear();

        }
    }
}
