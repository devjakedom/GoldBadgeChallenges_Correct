using ChallengeOneRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneConsole
{
    class ProgramUI
    {
        private MenuRepository _menuItems = new MenuRepository();
        public void Run()
        {
            RunMenu();
        }
        private void RunMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select an option below: \n" +
                   "1. Create Menu Item \n" +
                   "2. Delete Menu Item \n" +
                   "3. List Of Menu Items \n" +
                   "10. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        CreateMenuItems();
                        break;
                    case "2":
                        DeleteMenuItem();
                        break;
                    case "3":
                        ListOfMenuItems();
                        break;
                    case "10":
                        Console.WriteLine("Have a great day!!!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid response please try again.");
                        break;
                }
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void CreateMenuItems()
        {
            Console.Clear();
            Menu newMenuItem = new Menu();

            Console.WriteLine("What is the name of the meal you would like to add:");
            newMenuItem.MealName = Console.ReadLine();

            Console.WriteLine("What number is the meal:");
            newMenuItem.MealNumber = Console.ReadLine();
            Console.WriteLine("Describe the meal:");
            newMenuItem.MealDescription = Console.ReadLine();
            Console.WriteLine("What is the price of the meal:");
            newMenuItem.Price = Console.ReadLine();
            Console.WriteLine("List the ingredients for the meal items:\n" +
                "()");
            List<string> listOfIngredients = AddListOfIngredients();
            newMenuItem.Ingredients = listOfIngredients;
            _menuItems.CreateMenuItems(newMenuItem);
        }
        private void DeleteMenuItem()
        {
            Console.Clear();
            Console.WriteLine("Enter the meal number you would like to remove:");
            string mealNumber = Console.ReadLine();
            bool mealRemoved = _menuItems.DeleteMenuItems(mealNumber);
            if (mealRemoved)
            {
                Console.WriteLine("The meal has been removed from the menu!");
            }
            else
            {
                Console.WriteLine("Sorry... The meal was not removed. Please try again.");
            }
        }
        private void ListOfMenuItems()
        {
            Console.Clear();
            List<Menu> listOfMenuItems = _menuItems.GetMenuList();
            foreach (Menu menuItem in listOfMenuItems)
            {
                Console.WriteLine($"Meal Name: {menuItem.MealName} \n" +
                    $"Meal Number: {menuItem.MealNumber} \n" +
                    $"Meal Price: {menuItem.Price} \n" +
                    $"Meal Description: {menuItem.MealDescription}\n");
                foreach (string ingredients in menuItem.Ingredients)
                {
                    Console.WriteLine($"Meal Ingredients: {ingredients}\n");
                }
            }
        }
        public List<string> AddListOfIngredients()
        {
            List<string> listOfIngredients = new List<string>();
            bool addingIngredients = true;
            while (addingIngredients)
            {
                string userInput = Console.ReadLine();
                if (userInput != "")
                {
                    listOfIngredients.Add(userInput);
                }
                else
                {
                    addingIngredients = false;
                }
            }
            return listOfIngredients;
        }
    }
}
