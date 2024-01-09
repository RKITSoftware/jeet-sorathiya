using System;
using System.Collections.Generic;

namespace Test_of_Basic_C__training
{
    class TrainManager
    {
        private List<Train> trains;

        public TrainManager()
        {
            trains = new List<Train>();
            LoadTrainsFromFile(); // Load trains from file on initialization
        }

        public void AddTrain(Train train)
        {
            trains.Add(train);
            SaveTrainsToFile();
        }

        public void DisplayTrains()
        {
            foreach (var train in trains)
            {
                Console.WriteLine($"Train {train.TrainNumber}: {train.Source} to {train.Destination}");
            }
        }

        public Train SearchTrain(string source, string destination)
        {
            return trains.Find(train => train.Source.ToLower() == source.ToLower() && train.Destination.ToLower() == destination.ToLower());
        }
        public Train GetTrainByNumber(int trainNumber)
        {
            return trains.Find(train => train.TrainNumber == trainNumber);
        }


        private void LoadTrainsFromFile()
        {
            // Load train data from a file (implement later)
        }

        private void SaveTrainsToFile()
        {
            // Save train data to a file (implement later)
        }
    }
}

