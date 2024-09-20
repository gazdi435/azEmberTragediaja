using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza
{
    public class Ingredient
    {
        int id;
        string name;

        public Ingredient(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int Id => id;
        public string Name => name;

        public static List<Ingredient> GetIngredients()
        {
            // TEMP
            return [new Ingredient(1, "Ingredient 1"), new Ingredient(2, "Ingredient 2"), new Ingredient(3, "Ingredient 3")];
        }

        public override string ToString()
        {
            return name;
        }
    }
}
