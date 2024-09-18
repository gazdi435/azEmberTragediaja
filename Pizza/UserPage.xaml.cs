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
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : UserControl
    {
        public UserPage()
        {
            InitializeComponent();

            lbFood.ItemsSource = new List<string>(["PLACEHOLDER 1", "PLACEHOLDER 2", "PLACEHOLDER 3", "PLACEHOLDER 4"]);
        }

        private void lbFood_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblSelectedFood.Content = lbFood.SelectedItem.ToString();

            dgIngredients.ItemsSource = new List<IngredientView>([new("test", 2), new("asdasd", 3), new("dfsdff", 1)]);
        }
    }

    public class IngredientView(string name, int amount)
    {
        public string Name => name;
        public int Amount => amount;
    }
}
