using System.Collections.Generic;

namespace Test_of_Basic_C__training
{
    #region  class Train
    /// <summary>
    /// Represents a train in the Train Management System.
    /// </summary>
    class Train
    {
        #region public Property
        /// <summary>
        /// Gets or sets the train number.
        /// </summary>
        public int TrainNumber { get; set; }

        /// <summary>
        /// Gets or sets the source city of the train journey.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the destination city of the train journey.
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// Gets or sets the distance of the train journey.
        /// </summary>
        public int Distance { get; set; }

        /// <summary>
        /// Gets or sets the coach configurations of the train, represented as a dictionary.
        /// Key: Coach type (e.g., SL, 3A, 2A, 1A)
        /// Value: Number of seats available in that coach type.
        /// </summary>
        public Dictionary<string, int> CoachConfigurations { get; set; }
        #endregion
    }
    #endregion
}
