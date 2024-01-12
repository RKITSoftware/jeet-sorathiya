using System;

namespace Test_of_Basic_C__training
{
    #region  class Program
    /// <summary>
    /// Console application for managing a Train Management System.
    /// Allows users to display trains, search for trains, add new trains, and book train tickets.
    /// </summary>
    class Program : Train
    {
        static ITrainManager trainManager = new TrainManager();
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
                        TrainLogic.SearchTrain();
                        break;
                    case 3:
                        TrainLogic.AddNewTrain();
                        break;
                    case 4:
                        TrainLogic.BookTrain();
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


    }
    #endregion
}
