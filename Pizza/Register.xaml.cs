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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!Sql.EmailExists(emailTXTB.Text))
            {
                MessageBox.Show("not implemented bro");
            }
            else
            {
                MessageBox.Show("Az email cím már létezik");
            }

            nameTXTB.Clear();
            emailTXTB.Clear();
            addressTXTB.Clear();
            phoneTXTB.Clear();
            pswB.Clear();

        }
    }
}
