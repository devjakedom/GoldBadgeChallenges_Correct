using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneRepository
{
    public class Menu
    {
        public string MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public List<string> Ingredients { get; set; }
        public string Price { get; set; }
        public Menu() { }
        public Menu(string mealNumber, string mealName, string mealDescription, List<string> ingredients, string price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
