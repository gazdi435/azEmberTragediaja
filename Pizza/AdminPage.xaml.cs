using MySqlConnector;
using Pizza.Models;
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
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : UserControl
    {
        ObservableCollection<Ingredient> ingredients;
        List<PizzaItem> pizzas;

        public AdminPage()
        {
            InitializeComponent();
            
            ingredients = new(Sql.GetIngredients());
            pizzas = Sql.GetPizzas();

            dgIngredients.ItemsSource = ingredients;

            cbPizza.ItemsSource = pizzas;
            cbIngredient.ItemsSource = ingredients;
        }

        private void dgIngredients_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            Ingredient editedIngredient = dgIngredients.SelectedItem as Ingredient;

            var element = e.EditingElement as TextBox;
            int newAmount;
            if (!Int32.TryParse(element.Text, out newAmount) || newAmount < 0)
            {
                e.Cancel = true;
                element.Text = editedIngredient.Quantity.ToString();
                return;
            }

            editedIngredient.Quantity = newAmount;
            Sql.SetIngredientAmount(editedIngredient.ID, newAmount);
        }

        private void btnNewIngredient_Click(object sender, RoutedEventArgs e)
        {
            if (tbNewIngredient.Text == "")
            {
                return;
            }

            if (ingredients.Any(x => x.Name == tbNewIngredient.Text))
            {
                MessageBox.Show("Ilyen nevű alapanyag már létezik!");
                return;
            }

            Ingredient newIngredient = Sql.CreateIngredient(tbNewIngredient.Text);
            ingredients.Add(newIngredient);
            UpdatePizza();
        }

        private void btnDeleteIngredient_Click(object sender, RoutedEventArgs e)
        {
            if (dgIngredients.SelectedIndex != -1)
            {
                Ingredient ingredient = dgIngredients.SelectedItem as Ingredient;

                try
                {
                    Sql.DeleteIngredient(ingredient.ID);
                }
                catch (MySqlConnector.MySqlException ex)
                {
                    if (ex.ErrorCode == MySqlErrorCode.RowIsReferenced2)
                    {
                        MessageBox.Show("Ez az alapanyag nem törölhető, mert hozzá van rendelve egy pizzához.");
                        return;
                    }
                    throw;
                }

                
                ingredients.Remove(ingredient);
                UpdatePizza();
            }
        }

        private void UpdatePizza()
        {
            if (cbPizza.SelectedIndex == -1)
            {
                dgPizzaIngredients.ItemsSource = null;
                cbIngredient.ItemsSource = ingredients;
                return;
            }

            PizzaItem selected = cbPizza.SelectedItem as PizzaItem;
            List<PizzaIngredientView> pizzaIngredients = Sql.GetPizzaIngredients(selected.ID)
                .Select(x => new PizzaIngredientView() { Ingredient = x.Key, Amount = x.Value }).ToList();

            dgPizzaIngredients.ItemsSource = pizzaIngredients;
            cbIngredient.ItemsSource = ingredients.Where(x => !pizzaIngredients.Any(y => y.Ingredient.ID == x.ID));
        }

        private void cbPizza_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdatePizza();
        }

        private void dgPizzaIngredients_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            PizzaIngredientView editedIngredient = dgPizzaIngredients.SelectedItem as PizzaIngredientView;
            PizzaItem selectedPizza = cbPizza.SelectedItem as PizzaItem;

            var element = e.EditingElement as TextBox;
            int newAmount;
            if (!Int32.TryParse(element.Text, out newAmount) || newAmount < 1)
            {
                e.Cancel = true;
                element.Text = editedIngredient.Amount.ToString();
                return;
            }

            editedIngredient.Amount = newAmount;
            Sql.SetToppingAmount(selectedPizza.ID, editedIngredient.Ingredient.ID, newAmount);
        }

        private void btnPizzaAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            if (cbIngredient.SelectedIndex == -1)
            {
                return;
            }

            Ingredient ingredient = cbIngredient.SelectedItem as Ingredient;
            PizzaItem selectedPizza = cbPizza.SelectedItem as PizzaItem;
            Sql.CreateTopping(selectedPizza.ID, ingredient.ID);

            UpdatePizza();
        }

        private void btnPizzaDeleteIngredient_Click(object sender, RoutedEventArgs e)
        {
            if (dgPizzaIngredients.SelectedIndex == -1)
            {
                return;
            }

            PizzaIngredientView selected = dgPizzaIngredients.SelectedItem as PizzaIngredientView;
            PizzaItem selectedPizza = cbPizza.SelectedItem as PizzaItem;

            Sql.DeleteTopping(selectedPizza.ID, selected.Ingredient.ID);
            UpdatePizza();
        }
    }

    public class PizzaIngredientView
    {
        public Ingredient Ingredient { get; set; }
        public int Amount { get; set; }
    }
}
