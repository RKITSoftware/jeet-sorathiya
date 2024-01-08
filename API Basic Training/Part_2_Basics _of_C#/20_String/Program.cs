using System;

namespace _20_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating a string
            string myString = "Hello, Jeet Sorathiya";

            // Length property
            int length = myString.Length;
            Console.WriteLine($"Length of the string: {length}");

            // ToUpper and ToLower methods
            string upperCase = myString.ToUpper();
            string lowerCase = myString.ToLower();
            Console.WriteLine($"Uppercase: {upperCase}");
            Console.WriteLine($"Lowercase: {lowerCase}");

            // Substring method
            string substring = myString.Substring(7); // Starting from index 7 to the end
            Console.WriteLine($"Substring: {substring}");
            substring = myString.Substring(2, 6);
            Console.WriteLine($"Substring: {substring}");

            // CompareTo Method
            int result = substring.CompareTo(myString);
            Console.WriteLine($"CompareTo Method : {result}");
            result = myString.CompareTo(substring);
            Console.WriteLine($"CompareTo Method : {result}");
            result = substring.CompareTo(substring);
            Console.WriteLine($"CompareTo Method : {result}");

            // Equals Method
            bool isEquals = myString.Equals(substring);
            Console.WriteLine($"isEquals : {isEquals}");

            // IndexOf method
            int indexOf = myString.IndexOf(",");
            Console.WriteLine($"Index of ',' : {indexOf}");

            // LastIndexOf method
            int lastIndexOf = myString.LastIndexOf("e");
            Console.WriteLine($"Last Index of ',' : {lastIndexOf}");


            // Contains method
            bool containsWorld = myString.Contains("jeet");
            Console.WriteLine($"Contains 'World': {containsWorld}");

            // StartsWith method
            bool isStartsWith = myString.StartsWith("H");
            Console.WriteLine($"isStartWith : {isStartsWith}");

            // EndsWith method
            bool isEndWith = myString.EndsWith("A");
            Console.WriteLine($"isEndWith : {isEndWith}");

            // Replace method
            string replacedString = myString.Replace("Hello", "Hi");
            Console.WriteLine($"After replacement: {replacedString}");

            // Split method
            string[] words = myString.Split(' '); // Splitting by space
            Console.WriteLine("Split words:");
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }

            // Join method
            string joinedString = string.Join("-", words);
            Console.WriteLine($"Joined string: {joinedString}");

            // Trim method
            string spaceString = "   Good Morning    ";
            string trimmedString = spaceString.Trim();
            Console.WriteLine($"Trimmed string: {trimmedString}");

            // Concatenation
            string firstName = "Tony";
            string lastName = "Stark";
            string fullName = string.Concat(firstName, " ", lastName);
            Console.WriteLine($"Full name: {fullName}");
            Console.WriteLine($"Full name: {fullName}");

            // Remove method
            string modifiedString = fullName.Remove(0, 3);
            Console.WriteLine($"string after remove : {modifiedString}");

        }
    }
}
