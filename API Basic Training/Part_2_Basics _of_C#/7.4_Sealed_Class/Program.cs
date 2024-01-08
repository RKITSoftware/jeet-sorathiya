using System;

namespace _7._4_Sealed_Class
{
    /// <summary>
    /// Demonstrates the use of a sealed class in C#
    /// </summary>
    #region Sealed Class

    // Sealed Class
    public sealed class SealedClass
    {
        #region public method
        /// <summary>
        /// Displays a message 
        /// </summary>
        public void DisplayMessage()
        {
            Console.WriteLine("This is a sealed class.");
        }
        #endregion
    }

    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            #region Sealed Class

            // Sealed Class
            SealedClass sealedInstance = new SealedClass();
            sealedInstance.DisplayMessage();

            #endregion
        }
    }

}
