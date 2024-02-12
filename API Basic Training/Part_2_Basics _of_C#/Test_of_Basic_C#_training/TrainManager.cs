﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Test_of_Basic_C__training
{
    #region interface ITrainManager
    /// <summary>
    /// Interface for managing trains.
    /// </summary>
    interface ITrainManager 
    {
        /// <summary>
        /// Adds a new train to the system.
        /// </summary>
        /// <param name="train">The train object to be added.</param>
        void AddTrain(Train train);

        /// <summary>
        /// Displays information about all trains in the system.
        /// </summary>
        void DisplayTrains();

        /// <summary>
        /// Searches for trains based on source and destination.
        /// </summary>
        /// <param name="source">The source station.</param>
        /// <param name="destination">The destination station.</param>
        /// <returns>A list of trains matching the search criteria.</returns>
        List<Train> SearchTrain(string source, string destination);

        /// <summary>
        /// Retrieves a train based on its unique number.
        /// </summary>
        /// <param name="trainNumber">The unique number of the train.</param>
        /// <returns>The train object corresponding to the given number.</returns>
        Train GetTrainByNumber(int trainNumber);
    }
    #endregion

    #region class TrainManager
    /// <summary>
    /// Implementation of the train management system.
    /// Manages the addition, display, searching, and retrieval of train information.
    /// </summary>
    class TrainManager : ITrainManager
    {
        #region private property
        private static List<Train> _trains;
        #endregion

        #region private method
        /// <summary>
        /// Saves train data to a file.
        /// </summary>
        private static void SaveTrainsToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("TrainData.txt"))
                {
                    foreach (Train train in _trains)
                    {
                        string coachConfigurations = string.Join(",", train.CoachConfigurations.Select(kv => $"{kv.Key}-{kv.Value}"));
                        writer.WriteLine($"{train.TrainNumber};{train.Source};{train.Destination};{train.Distance};{coachConfigurations}");
                    }
                }

                Console.WriteLine("Train data saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving train data: {ex.Message}");
            }
        }
        #endregion

        #region public method
        /// <summary>
        /// Constructor to initialize the TrainManager and load trains from a file.
        /// </summary>
        static TrainManager()
        {
            _trains = new List<Train>();
            LoadTrainsFromFile(); // Load trains from file on initialization
        }

        /// <summary>
        /// Adds a train to the list and saves it to the file.
        /// </summary>
        /// <param name="train">Train object to be added.</param>
        public void AddTrain(Train train)
        {
            _trains.Add(train);
            SaveTrainsToFile();
        }

        /// <summary>
        /// Displays information about all the trains in the list.
        /// </summary>
        public void DisplayTrains()
        {
            if (_trains.Count > 0)
            {
                foreach (Train train in _trains)
                {
                    Console.WriteLine($"Train {train.TrainNumber}: {train.Source} to {train.Destination}");
                }
            }
            else
            {
                Console.WriteLine("No Train Data Found");
            }

        }

        /// <summary>
        /// Searches for trains based on source and destination cities.
        /// </summary>
        /// <param name="source">Source city for the train journey.</param>
        /// <param name="destination">Destination city for the train journey.</param>
        /// <returns>List of trains matching the search criteria.</returns>

        public List<Train> SearchTrain(string source, string destination)
        {
            return (_trains.FindAll(train => train.Source.ToLower() == source.ToLower() && train.Destination.ToLower() == destination.ToLower()));
        }

        /// <summary>
        /// Gets a train by its train number.
        /// </summary>
        /// <param name="trainNumber">Train number to search for.</param>
        /// <returns>The train object with the specified train number.</returns>
        public Train GetTrainByNumber(int trainNumber)
        {
            return _trains.Find(train => train.TrainNumber == trainNumber);
        }


        /// <summary>
        /// Loads train data from a file.
        /// </summary>
        private static void LoadTrainsFromFile()
        {
            try
            {
                string[] lines = File.ReadAllLines("TrainData.txt");

                foreach (string line in lines)
                {
                    string[] data = line.Split(';');

                    if (data.Length == 5)
                    {
                        int trainNumber = int.Parse(data[0]);
                        string source = data[1];
                        string destination = data[2];
                        int distance = int.Parse(data[3]);
                        TrainLogic objTrainLogic = new TrainLogic();
                        Dictionary<string, int> coachConfigurations = objTrainLogic.ParseCoachConfigurations(data[4]);

                        Train loadedTrain = new Train
                        {
                            TrainNumber = trainNumber,
                            Source = source,
                            Destination = destination,
                            Distance = distance,
                            CoachConfigurations = coachConfigurations
                        };

                        _trains.Add(loadedTrain);
                    }
                }

                Console.WriteLine("Train data loaded successfully.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Train data file not found. Creating a new one.");
                SaveTrainsToFile();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading train data: {ex.Message}");
            }
        }
        #endregion
    }
    #endregion
}

