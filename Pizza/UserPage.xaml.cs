using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        List<PizzaItem> pizzas;
        PizzaItem selectedPizza;
        ObservableCollection<CartItem> cart = [];

        public UserPage()
        {
            InitializeComponent();

            pizzas = PizzaItem.GetPizzas();

            lbFood.ItemsSource = pizzas;
            lbCart.ItemsSource = cart;
        }

        private void lbFood_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbFood.SelectedIndex == -1)
            {
                return;
            }

            selectedPizza = lbFood.SelectedItem as PizzaItem;

            lblSelectedFood.Content = selectedPizza.Name;
            tbkDescription.Text = selectedPizza.Description;
            dgIngredients.ItemsSource = selectedPizza.GetIngredients();

            dgIngredients.Columns[0].Header = "Alapanyag";
            dgIngredients.Columns[1].Header = "Darab";
        }

        private void btnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            if (selectedPizza == null)
            {
                MessageBox.Show("Ki kell választanod egy pizzát!");
                return;
            }

            int amount;
            if (!(Int32.TryParse(tbCartAmount.Text, out amount)) || amount < 1)
            {
                MessageBox.Show("Adj meg egy pozitív darabszámot!");
                return;
            }

            try
            {
                CartItem existingItem = cart.First(x => x.Pizza == selectedPizza);
                existingItem.Amount += amount;
                lbCart.Items.Refresh();
            }
            catch (InvalidOperationException)
            {
                cart.Add(new CartItem(selectedPizza, amount));
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbSearch.Text == "")
            {
                lbFood.ItemsSource = pizzas;
            }
            else
            {
                lbFood.ItemsSource = pizzas.Where(x => x.Name.Contains(tbSearch.Text));      
            }
        }

        private void btnRemoveCart_Click(object sender, RoutedEventArgs e)
        {
            if (lbCart.SelectedIndex != -1)
            {
                cart.RemoveAt(lbCart.SelectedIndex);
            }
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            if (cart.Count == 0)
            {
                MessageBox.Show("Adj hozzá legalább 1 pizzát a kosárhoz!");
                return;
            }
        }
    }

    public class CartItem(PizzaItem pizza, int amount)
    {
        public PizzaItem Pizza = pizza;
        public int Amount = amount;

        public override string ToString()
        {
            return $"{Pizza.Name} x{Amount}";
        }
    }
}
