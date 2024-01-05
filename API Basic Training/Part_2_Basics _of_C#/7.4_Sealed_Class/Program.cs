using System;

namespace _7._4_Sealed_Class
{
    /// <summary>
    /// class SealedClass
    ///         type : sealed
    ///         
    ///         DisplayMessage()
    ///             type : void
    ///             <param></param>
    /// 
    /// </summary>
    #region Sealed Class
    // Sealed Class
    public sealed class SealedClass
    {
        public void DisplayMessage()
        {
            Console.WriteLine("This is a sealed class.");
        }
    }

    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            #region  Sealed Class
            // Sealed Class
            SealedClass sealedInstance = new SealedClass();
            sealedInstance.DisplayMessage();
            #endregion
        }
    }
}
