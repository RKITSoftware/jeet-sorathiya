using System;

namespace _9_Encapsulation
{
    /// <summary>
    /// Class Person with private properties for name, age, and date of birth.
    /// </summary>

    #region Class Person
    class Person
    {
        #region Fields
        // Private fields
        private string name;
        private int age;
        private DateTime dateOfBirth;
        #endregion

        #region methods
        // Public properties to access private fields

        /// <summary>
        /// Gets or sets the Name of the person.
        /// <return>Name</return>
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name = value;
                }
                else
                {
                    Console.WriteLine("Name cannot be empty.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Age of the person.
        /// <return>Age</return>
        /// </summary>

        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 0)
                {
                    age = value;
                }
                else
                {
                    Console.WriteLine("Age cannot be negative.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the date of birth of the person.
        /// </summary>
        /// <returns>The date of birth.</returns>
        public DateTime DobGetter()
        {
            return dateOfBirth;
        }

        /// <summary>
        /// Sets the date of birth of the person, validating that it is not in the future.
        /// </summary>
        /// <param name="value">The date of birth to set.</param>
        public void DobSetter(DateTime value)
        {
            if (value <= DateTime.Now)
            {
                dateOfBirth = value;
            }
            else
            {
                Console.WriteLine("Invalid date of birth");
            }
        }

        // Public method to display
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, DateOfBirth: {dateOfBirth}");
        }

        #endregion
    }
    #endregion

    #region Class Program
    internal class Program
    {

        #region Main Method
        static void Main()
        {
            // Creating an object of the Person class
            Person objofPerson = new Person();

            Console.WriteLine("Enter Name");
            objofPerson.Name = Console.ReadLine();
            Console.WriteLine("Enter Age");
            objofPerson.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter DateOfBirth");

            DateTime objofDateTime = new DateTime();
            objofDateTime = DateTime.Parse(Console.ReadLine());
            objofPerson.DobSetter(objofDateTime);

            objofPerson.DisplayInfo();


        }
        #endregion
    }
    #endregion
}
