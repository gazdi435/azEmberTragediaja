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
        public Login()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.Page = new Register();
            MainWindow.mainWindow.RefreshUI();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!Sql.EmailPasswordValid(emailTXTB.Text, pswB.Password))
            {
                MessageBox.Show("Hibás email cím vagy jelszó!");
                return;
            }

            MainWindow.user = Sql.GetUserByEmail(emailTXTB.Text);

            MainWindow.mainWindow.Page = MainWindow.user.IsAdmin ? new AdminPage() : new UserPage();
            MainWindow.mainWindow.RefreshUI();
        }
    }
}
