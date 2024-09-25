using Pizza.Models;
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

namespace Pizza
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        private static User GetUserByEmail(string email) => throw new NotImplementedException();
        public Login()
        {
            InitializeComponent();
        }

        

        private void TextBlock_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.Page = new Register();
            MainWindow.mainWindow.RefreshUI();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Sql.EmailPasswordValid(emailTXTB.Text, pswB.Password))
            {
                //MainWindow.mainWindow.Page = new UserPage();
                //MainWindow.mainWindow.RefreshUI();
            }
            else
            {
                MessageBox.Show("Hibás email cím vagy jelszó!");
            }


            emailTXTB.Clear();
            pswB.Clear();


        }
    }
}
