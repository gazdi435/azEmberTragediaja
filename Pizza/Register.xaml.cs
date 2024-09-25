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
            MainWindow.mainWindow.Login = new Login();
            MainWindow.mainWindow.RefreshUI();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

            emailTXTB.Clear();
            pswB.Clear();
            MessageBox.Show("Köszönjük");
        }
    }
}
