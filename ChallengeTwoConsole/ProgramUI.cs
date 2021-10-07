using ChallengeTwoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoConsole
{
    class ProgramUI
    {
        private ClaimRepository _claimRepo = new ClaimRepository();
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
                Console.WriteLine("Welcome to the claims application\n" +
                "Please select a menu option:\n" +
                " \n" +
                "1. View Claims\n" +
                "2. Work On Next Claim\n" +
                "3. Create New Claim\n" +
                "4. End\n" +
                " ");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ViewClaims();
                        break;
                    case "2":
                        WorkOnNextClaim();
                        break;
                    case "3":
                        CreateNewClaim();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Bye.");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Enter a valid number");
                        break;
                }
                Console.WriteLine("press any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void ViewClaims()
        {
            Console.Clear();
            Queue<Claim> ClaimQueues = _claimRepo.ViewAllClaims();
            string ClaimsDisplay = string.Format("{0,-15} {1,-15} {2,-15} {3,-15} {4,-25} {5,-20} {6,-17}", "Claim ID", "Claim Type", "Description", "Amount", "Date Of Incident", "Date Of Claim", "Is Valid");
            Console.WriteLine(ClaimsDisplay);

            foreach (Claim claim in ClaimQueues)
            {
                string ClaimsOutput = string.Format("{0,-15} {1,-15} {2,-15} {3,-15} {4,-25} {5,-20} {6,-17}", claim.ClaimID, claim.ClaimType, claim.Description, claim.ClaimAmount,claim.DateOfIncident, claim.DateOfClaim, claim.IsValid);
                Console.WriteLine(ClaimsOutput);
            }
        }
        private void CreateNewClaim()
        {
            Console.Clear();
            Claim newClaim = new Claim();

            Console.WriteLine("Enter the Claim ID:");
            newClaim.ClaimID = Console.ReadLine();
            
            Console.WriteLine("Enter the claim type:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");
            string claimTypeString = Console.ReadLine();
            int claimTypeInt = int.Parse(claimTypeString);
            newClaim.ClaimType = (ClaimType)claimTypeInt;

            Console.WriteLine("Enter a claim description:");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Amount of Damage:");
            newClaim.ClaimAmount = Console.ReadLine();

            Console.WriteLine("Date Of Accident");
            DateTime AccidentDate = DateTime.Parse(Console.ReadLine());
            newClaim.DateOfIncident = AccidentDate;

            Console.WriteLine("Enter date of claim");
            DateTime inputClaimDate = DateTime.Parse(Console.ReadLine());
            newClaim.DateOfClaim = inputClaimDate;
            TimeSpan AccidentToClaimTime = new TimeSpan();
            AccidentToClaimTime = newClaim.DateOfClaim - newClaim.DateOfIncident;
            if (AccidentToClaimTime.Days > 30)
            {
                Console.WriteLine("Invalid claim.");
                newClaim.IsValid = false;
            }
            else if (AccidentToClaimTime.Days <= 30)
            {
                Console.WriteLine("Valid Claim.");
                newClaim.IsValid = true;
            }
            _claimRepo.CreateNewClaim(newClaim);
        }
        private void WorkOnNextClaim()
        {
            Console.Clear();
            Claim ViewFirstClaim = _claimRepo.ViewFirstItem();
            Console.WriteLine($"Claim ID: { ViewFirstClaim.ClaimID}\n" +
                $"Claim Type: {ViewFirstClaim.ClaimType}\n" +
                $"Description: {ViewFirstClaim.Description}\n" +
                $"Amount: {ViewFirstClaim.ClaimAmount}\n" +
                $"Accident Date: {ViewFirstClaim.DateOfIncident}\n" +
                $"Claim Date: {ViewFirstClaim.DateOfClaim}\n" +
                $"Is Valid: {ViewFirstClaim.IsValid}\n" +
                $" ");
            Console.WriteLine("Do you want to work with this claim now? (y/n)");
            string userInput = Console.ReadLine().ToLower();
            switch (userInput)
            {
                case "y":
                    _claimRepo.DequeueClaim();
                    Console.WriteLine("Claim was removed, get to work i dont pay you to sit.");
                    break;
                case "n":
                    Console.Clear();
                    Menu();
                    break;
            }
        }
        private void SeedList()
        {
            DateTime claim1ClaimDate = new DateTime(2021, 10, 01);
            DateTime claim1IncidentDate = new DateTime(2020, 10, 07);

            DateTime claim2ClaimDate = new DateTime(2020, 04, 05);
            DateTime claim2IncidentDate = new DateTime(2020, 04, 20);

            DateTime claim3ClaimDate = new DateTime(1995, 06, 20);
            DateTime claim3IncidentDate = new DateTime(1995, 06, 21);

            Claim claim1 = new Claim("17", ClaimType.Home, "fire", "$15000.00", claim1IncidentDate, claim1ClaimDate, true);
            Claim claim2 = new Claim("28", ClaimType.Car, "Added water to oil", "$3500.00", claim2IncidentDate, claim2ClaimDate, true);
            Claim claim3 = new Claim("31", ClaimType.Theft, "drone stolen", "$988.00", claim3IncidentDate, claim3ClaimDate, true);

            _claimRepo.CreateNewClaim(claim1);
            _claimRepo.CreateNewClaim(claim2);
            _claimRepo.CreateNewClaim(claim3);
        }
    }
}
       
     

