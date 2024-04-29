using System;

namespace ClassDemo
{
    #region Staic API Class
    /// <summary>
    /// Static class representing an API with training-related functionalities.
    /// </summary>
    public static class API
    {
        /// <summary>
        /// Static property representing the ID of the API.
        /// </summary>
        public static int Id = 10;

        // Cannot create any non-static variable here
        // int Code = 1;

        #region static method
        /// <summary>
        /// Static constructor for the API class.
        /// </summary>
        static API()
        {
            Console.WriteLine("API Training Start");
        }

        /// <summary>
        /// Static method representing C# training.
        /// </summary>
        public static void Cb()
        {
            Console.WriteLine("C# Training Start");
        }

        // Cannot create any non-static method here
        // public void Db()
        // {
        //     Console.WriteLine("Db Training Start");
        // }
        #endregion

    }
    #endregion

    #region GUI
    /// <summary>
    /// Class representing a GUI with training-related functionalities.
    /// </summary>
    public class GUI
    {
        /// <summary>
        /// Instance variable representing the ID of the GUI.
        /// </summary>
        int id = 10;

        /// <summary>
        /// Static variable representing the code of the GUI.
        /// </summary>
        static int Code = 1;

        #region method
        /// <summary>
        /// Constructor for the GUI class.
        /// </summary>
        public GUI()
        {
            Console.WriteLine("GUI traing Start");
        }

        /// <summary>
        /// Method representing HTML training.
        /// </summary>
        public void HTML()
        {
            Console.WriteLine("HTML Training Done");
        }

        /// <summary>
        /// Static method representing JS training.
        /// </summary>
        public static void JS()
        {
            Console.WriteLine("JS Training Done");
        }
        #endregion
    }
    #endregion

    #region StaticClassTest
    public class StaticDemo
    {
        static void StaticClassTest(string[] args)
        {
            // Cannot create an object of a static class
            // API objofAPI = new API();

            GUI objofGUI = new GUI();
            objofGUI.HTML();
            GUI.JS();

            API.Cb();
            Console.WriteLine(API.Id);

        }
    }
    #endregion
}
