using System;

namespace _7._1_Class_Object
{
    /// <summary>
    /// class Person
    ///         Fields
    ///         private string firstName;
    ///         private string lastName;
    ///     Person()
    ///         <param>string firstName</param>
    ///         <param>string lastName</param>
    ///     DisplayFullName() 
    ///         <param></param>
    /// </summary>
    #region regular class

    // Regular Class
    public class Person
    {
        // Fields
        private string firstName;
        private string lastName;

        // Properties
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        // Constructor
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        // Method
        public void DisplayFullName()
        {
            Console.WriteLine($"Full Name: {FirstName} {LastName}");
        }
    }

    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {

            #region regular class
            // Regular Class
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();

            Person objofPerson = new Person(firstName, lastName);
            objofPerson.DisplayFullName();

            #endregion

        }
    }
}
