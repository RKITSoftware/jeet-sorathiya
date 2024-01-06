using System;
namespace _13_Interface
{
    #region interface IPhone
    /// <summary>
    /// Interface IPhone
    /// </summary>
    public interface IPhone
    {
        void MakeCall(string phoneNumber);
        void ReceiveCall();
    }
    #endregion

    #region interface ICamera
    /// <summary>
    /// Interface ICamera
    /// </summary>
    public interface ICamera
    {
        void TakePhoto();
    }
    #endregion

    #region class Smartphone
    /// <summary>
    /// Class Smartphone implementing IPhone, ICamera, and IMessage interfaces.
    /// </summary>
    public class Smartphone : IPhone, ICamera
    {
        #region method
        /// <summary>
        /// Makesacall Method
        /// </summary>
        public void MakeCall(string phoneNumber)
        {
            Console.WriteLine($"Calling {phoneNumber}");
        }

        /// <summary>
        /// Receives a call method
        /// </summary>
        public void ReceiveCall()
        {
            Console.WriteLine("Receiving a call");
        }

        /// <summary>
        /// Takes a photo method
        /// </summary>
        public void TakePhoto()
        {
            Console.WriteLine("Taking a photo");
        }

        /// <summary>
        /// Sends a message method
        /// </summary>
        public void SendMessage(string contact, string message)
        {
            Console.WriteLine($"Sending a message to {contact}: {message}");
        }

        /// <summary>
        /// Receives a message method
        /// </summary>
        public void ReceiveMessage()
        {
            Console.WriteLine("Receiving a message");
        }
        #endregion
    }
    #endregion

    #region Class Program 
    /// <summary>
    /// Class program
    /// </summary>
    class Program
    {
        #region Main method
        /// <summary>
        /// Main Method
        /// </summary>
        static void Main()
        {
            Smartphone smartphone = new Smartphone();

            smartphone.MakeCall("+91 1122334455");
            smartphone.ReceiveCall();
            smartphone.TakePhoto();
            smartphone.SendMessage("Friend", "Hello!");

        }
        #endregion
    }
    #endregion

}
