using System;
using System.Collections.Generic;

namespace Test_of_Basic_C__training
{
    #region  class Program
    /// <summary>
    /// Console application for managing a Train Management System.
    /// Allows users to display trains, search for trains, add new trains, and book train tickets.
    /// </summary>
    class Program
    {

        static ITrainManager trainManager = new TrainManager();
        static int pnrCounter = 1000000001; // Counter for generating PNR numbers

        #region Main Method
        /// <summary>
        /// Displays a menu and allows users to interact with the Train Management System.
        /// </summary>
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

        #endregion

        #region Methods
        /// <summary>
        /// Searches for trains based on source and destination cities.
        /// </summary>
        static void SearchTrain()
        {
            Console.Write("Enter source city: ");
            string source = Console.ReadLine();
            Console.Write("Enter destination city: ");
            string destination = Console.ReadLine();

            List<Train> searchedTrain = trainManager.SearchTrain(source, destination);
            if (searchedTrain.Count != 0)
            {
                foreach (Train train in searchedTrain)
                {
                    Console.WriteLine($"Train found: {train.TrainNumber}");
                }
            }
            else
            {
                Console.WriteLine("Train not found.");
            }
        }

        /// <summary>
        /// Adds a new train to the system with details.
        /// </summary>
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

            Console.Write("Enter Coach Configurations (e.g., SL-72, 3A-60, 2A-50, 1A-68): ");
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

        /// <summary>
        /// Books tickets for a selected train based on user input.
        /// </summary>
        static void BookTrain()
        {
            Console.Write("Enter Train Number to book: ");
            int trainNumber = int.Parse(Console.ReadLine());

            Train selectedTrain = trainManager.GetTrainByNumber(trainNumber);

            if (selectedTrain != null)
            {
                Console.Write("Enter Class (e.g., SL, 3A, 2A, 1A): ");
                string coachType = Console.ReadLine().ToUpper();

                Console.Write("Enter Number of Passengers: ");
                int totalPassengers = int.Parse(Console.ReadLine());

                int distance = selectedTrain.Distance;
                int fare = CalculateFare(coachType, distance, totalPassengers);

                Dictionary<string, int> availableSeats = selectedTrain.CoachConfigurations;

                if (fare > 0 && CheckAvailability(availableSeats, coachType, totalPassengers))
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

        /// <summary>
        /// Parses coach configurations input provided by the user.
        /// </summary>
        /// <param name="input">Input string containing coach configurations.</param>
        /// <returns>A dictionary representing coach configurations.</returns>
        public static Dictionary<string, int> ParseCoachConfigurations(string input)
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

        /// <summary>
        /// Calculates the fare for booking train tickets based on coach type, distance, and total passengers.
        /// </summary>
        /// <param name="coachType">Type of the coach (e.g., SL, 3A, 2A, 1A).</param>
        /// <param name="distance">Distance of the journey.</param>
        /// <param name="totalPassengers">Number of passengers to book for.</param>
        /// <returns>The calculated fare or -1 if invalid coach type.</returns>
        static int CalculateFare(string coachType, int distance, int totalPassengers)
        {
            int farePerKM = -1;

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
                    Console.WriteLine("Enter Valid Coach Type");
                    break;
            }
            return farePerKM > 0 ? (distance * farePerKM * totalPassengers) : (-1);
        }

        /// <summary>
        /// Checks the availability of seats for a specific coach type and number of passengers.
        /// </summary>
        /// <param name="availableSeats">Dictionary representing available seats for each coach type.</param>
        /// <param name="coachType">Type of the coach (e.g., SL, 3A, 2A, 1A).</param>
        /// <param name="totalPassengers">Number of passengers to book for.</param>
        /// <returns>True if seats are available, false otherwise.</returns>
        static bool CheckAvailability(Dictionary<string, int> availableSeats, string coachType, int totalPassengers)
        {
            if (availableSeats != null && availableSeats.ContainsKey(coachType))
            {
                int availableSeatsForCoach = availableSeats[coachType];
                return availableSeatsForCoach >= totalPassengers;
            }

            return false;
        }

        /// <summary>
        /// Books tickets for a selected train and updates available seats.
        /// </summary>
        /// <param name="train">Selected train.</param>
        /// <param name="coachType">Type of the coach (e.g., SL, 3A, 2A, 1A).</param>
        /// <param name="totalPassengers">Number of passengers to book for.</param>
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

        #endregion
    }
    #endregion
}
