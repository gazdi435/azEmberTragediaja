using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Pizza
{
    public class PizzaItem
    {
        int id;
        string name, description, size;
        double price;

        public PizzaItem(int id, string name, string description, string size, double price)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.size = size;
            this.price = price;
        }

        public int Id => id;
        public string Name => name;
        public string Description => description;
        public string Size => size;
        public double Price => price;

        public static List<PizzaItem> GetPizzas()
        {
            // TEMP
            return [new PizzaItem(1, "Example 1", "asd asd asd asd asd", "24", 1200),
                new PizzaItem(2, "Example 2", "dfgdfg g hdgdfg dgdsg dfgdf dfhdfgdfgdf", "32", 3000),
                new PizzaItem(3, "Example 3", "hgfh dhfh dre sgd shdfh sdfds", "16", 1000)];
        }

        public Dictionary<Ingredient, int> GetIngredients()
        {
            Dictionary<Ingredient, int> ingredients = new();

            // TEMP
            foreach (Ingredient ingredient in Ingredient.GetIngredients())
            {
                ingredients[ingredient] = 2;
            }

            return ingredients;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
