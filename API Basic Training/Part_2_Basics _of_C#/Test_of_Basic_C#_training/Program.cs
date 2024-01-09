using System;
using System.Collections.Generic;

namespace Test_of_Basic_C__training
{
    class Program
    {
        static TrainManager trainManager = new TrainManager();
        static int pnrCounter = 1000000001; // Counter for generating PNR numbers

        static void Main()
        {
            Console.WriteLine("Welcome to the Train Management System!");

            while (true)
            {
                Console.WriteLine("\n1. Display Trains\n2. Search Train\n3. Add New Train\n4. Book Train\n5. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        trainManager.DisplayTrains();
                        break;
                    case 2:
                        SearchTrain();
                        break;
                    case 3:
                        AddNewTrain();
                        break;
                    case 4:
                        BookTrain();
                        break;
                    case 5:
                        Console.WriteLine("Exiting the program. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        static void SearchTrain()
        {
            Console.Write("Enter source city: ");
            string source = Console.ReadLine();
            Console.Write("Enter destination city: ");
            string destination = Console.ReadLine();

            Train searchedTrain = trainManager.SearchTrain(source, destination);
            if (searchedTrain != null)
            {
                Console.WriteLine($"Train found: {searchedTrain.TrainNumber}");
            }
            else
            {
                Console.WriteLine("Train not found.");
            }
        }

        static void AddNewTrain()
        {
            Console.Write("Enter Train Number: ");
            int trainNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter Source: ");
            string source = Console.ReadLine();

            Console.Write("Enter Destination: ");
            string destination = Console.ReadLine();

            Console.Write("Enter Distance: ");
            int distance = int.Parse(Console.ReadLine());

            Console.Write("Enter Coach Configurations (e.g., S1-72,S2-72,B1-72): ");
            string coachConfigurationsInput = Console.ReadLine();
            Dictionary<string, int> coachConfigurations = ParseCoachConfigurations(coachConfigurationsInput);

            Train newTrain = new Train
            {
                TrainNumber = trainNumber,
                Source = source,
                Destination = destination,
                Distance = distance,
                CoachConfigurations = coachConfigurations
            };

            trainManager.AddTrain(newTrain);
            Console.WriteLine("Train added successfully!");
        }

        static void BookTrain()
        {
            Console.Write("Enter Train Number to book: ");
            int trainNumber = int.Parse(Console.ReadLine());

            Train selectedTrain = trainManager.GetTrainByNumber(trainNumber);

            if (selectedTrain != null)
            {
                Console.Write("Enter Travel Date (yyyy-MM-dd): ");
                DateTime travelDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Enter Class (e.g., SL, 3A, 2A, 1A): ");
                string coachType = Console.ReadLine().ToUpper();

                Console.Write("Enter Number of Passengers: ");
                int totalPassengers = int.Parse(Console.ReadLine());

                int distance = selectedTrain.Distance;
                int fare = CalculateFare(coachType, distance, totalPassengers);

                Dictionary<string, int> availableSeats = selectedTrain.CoachConfigurations;

                if (CheckAvailability(availableSeats, totalPassengers))
                {
                    BookTickets(selectedTrain, coachType, totalPassengers);
                    Console.WriteLine($"PNR: {pnrCounter++}, Fare: {fare}");
                }
                else
                {
                    Console.WriteLine("No Seats Available");
                }
            }
            else
            {
                Console.WriteLine("Train not found.");
            }
        }

        static Dictionary<string, int> ParseCoachConfigurations(string input)
        {
            Dictionary<string, int> configurations = new Dictionary<string, int>();

            string[] parts = input.Split(',');
            foreach (var part in parts)
            {
                string[] coachInfo = part.Split('-');
                if (coachInfo.Length == 2)
                {
                    string coachType = coachInfo[0];
                    int numberOfSeats = int.Parse(coachInfo[1]);

                    configurations.Add(coachType, numberOfSeats);
                }
                else
                {
                    Console.WriteLine($"Invalid coach configuration: {part}");
                }
            }

            return configurations;
        }

        static int CalculateFare(string coachType, int distance, int totalPassengers)
        {
            int farePerKM;

            switch (coachType)
            {
                case "SL":
                    farePerKM = 1;
                    break;
                case "3A":
                    farePerKM = 2;
                    break;
                case "2A":
                    farePerKM = 3;
                    break;
                case "1A":
                    farePerKM = 4;
                    break;
                default:
                    farePerKM = 1;
                    break;
            }

            return distance * farePerKM * totalPassengers;
        }

        static bool CheckAvailability(Dictionary<string, int> availableSeats, int totalPassengers)
        {
            if (availableSeats != null)
            {
                foreach (var seats in availableSeats)
                {
                    if (seats.Value >= totalPassengers)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        static void BookTickets(Train train, string coachType, int totalPassengers)
        {
            foreach (var seats in train.CoachConfigurations)
            {
                if (seats.Key == coachType)
                {
                    train.CoachConfigurations[seats.Key] -= totalPassengers;
                    return;
                }
            }
        }
    }
}







