using ChallengeThreeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeConsole
{
    class ProgramUI
    {
        private BadgeRepository _badgeRepository = new BadgeRepository();
        public void Run()
        {
            SeedList();
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Welcome to Badge App!\n" +
                    "What would you like to do?\n" +
                    " \n" +
                    "1. Create Badge\n" +
                    "2. Edit Badge\n" +
                    "3. View All Badges\n" +
                    "4. Delete Badge\n" +
                    "5. Exit\n" +
                    " ");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        CreateNewBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ViewAllBadges();
                        break;
                    case "4":
                        DeleteABadge();
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Dueces!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter valid number.");
                        break;
                }
                Console.WriteLine("Please press any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void CreateNewBadge()
        {
            Console.Clear();
            Badge newBadge = new Badge();

            Console.WriteLine("What is the Badge ID Number?");
            newBadge.BadgeID = int.Parse(Console.ReadLine());
            bool runDoorAccess = true;
            while (runDoorAccess)
            {
                Console.WriteLine("list a door that it needs access to:");
                string door = Console.ReadLine();
                newBadge.DoorNames.Add(door);
                System.Console.WriteLine("Any other doors? (y/n)");
                string userInput = Console.ReadLine().ToLower();
                switch (userInput)
                {
                    case "y":
                        runDoorAccess = true;
                        break;
                    case "n":
                        runDoorAccess = false;
                        Console.Clear();
                        _badgeRepository.CreateNewBadge(newBadge);
                        Menu();
                        break;
                }
            }
        }
        private void EditBadge()
        {
            Console.Clear();
            Console.WriteLine("What is the badge number to update?");
            string idString = Console.ReadLine();
            int idInt = int.Parse(idString);
            Console.WriteLine("What would you like to do?\n" +
                "1. Remove A Door\n" +
                "2. Add A Door");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    List<string> RemoveDoors = new List<string>();
                    Dictionary<int, List<string>> newDictionary = new Dictionary<int, List<string>>();
                    newDictionary = _badgeRepository.ViewAllBadgesAndDoorAccess();
                    foreach (KeyValuePair<int, List<string>> dictionary in newDictionary)
                    {
                        if (dictionary.Key == idInt)
                        {
                            RemoveDoors = dictionary.Value;
                        }
                    }
                    RemoveDoor(idInt, RemoveDoors);
                    break;
                case "2":
                    List<string> AddDoors = new List<string>();
                    Dictionary<int, List<string>> newDictionary2 = new Dictionary<int, List<string>>();
                    newDictionary = _badgeRepository.ViewAllBadgesAndDoorAccess();
                    foreach (KeyValuePair<int, List<string>> dictionary in newDictionary)
                    {
                        if (dictionary.Key == idInt)
                        {
                            AddDoors = dictionary.Value;
                        }
                    }
                    AddDoor(idInt, AddDoors);
                    break;
            }
        }
        private void AddDoor(int badge, List<string> doors)
        {
            Console.WriteLine("What door do you want to add");
            string input = Console.ReadLine();
            doors.Add(input);
            _badgeRepository.UpdateBadge(badge, doors);
        }
        private void RemoveDoor(int badge, List<string> doors)
        {
            Console.WriteLine("Enter a door you want to remove:");
            string input = Console.ReadLine();
            doors.Remove(input);
            _badgeRepository.UpdateBadge(badge, doors);
        }
        private void ViewAllBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> listOfBadges = _badgeRepository.ViewAllBadgesAndDoorAccess();
            Console.WriteLine("Badge ID Door Access");
            foreach (KeyValuePair<int, List<string>> dictionary in listOfBadges)
            {
                Console.WriteLine($" \n" +
                    $"{dictionary.Key}");
                foreach (string door in dictionary.Value)
                {
                    Console.WriteLine($"{door}");
                }
            }
        }
        private void DeleteABadge()
        {
            ViewAllBadges();
            Console.WriteLine(" \n" +
                "What badge do you want to remove? enter id");
            string idString = Console.ReadLine();
            int idInt = int.Parse(idString);
            bool badgeWasDeleted = _badgeRepository.RemoveBadge(idInt);
            if (badgeWasDeleted)
            {
                Console.WriteLine("Badge deleted");
            }
            else
            {
                Console.WriteLine("Badge not deleted");
            }
        }
        private void SeedList()
        {
            Badge badge1 = new Badge(2525, new List<string>() { "A1", "A5", "A2" });
            Badge badge2 = new Badge(6445, new List<string>() { "B3" });
            Badge badge3 = new Badge(1212, new List<string>() { "A1", "A3", "C4" });
            
            _badgeRepository.CreateNewBadge(badge1);
            _badgeRepository.CreateNewBadge(badge2);
            _badgeRepository.CreateNewBadge(badge3);
        }
    }
}
