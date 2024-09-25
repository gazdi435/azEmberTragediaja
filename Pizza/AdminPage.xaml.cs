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

        public AdminPage()
        {
            InitializeComponent();

            ingredients = new(Sql.GetIngredients());

            dgIngredients.ItemsSource = ingredients;
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
            }
        }
    }
}
