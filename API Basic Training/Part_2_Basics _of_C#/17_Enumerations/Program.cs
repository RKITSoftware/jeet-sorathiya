using System;

namespace _17_Enumerations
{
    public class Leave
    {

        #region Enum
        /// <summary>
        /// EnumWeek defines the days of the week.
        /// </summary>
        public enum EnumWeek
        {
            Mon,
            Tue,
            Wed,
            Thu,
            Fri,
            Sat,
            Sun
        }
        #endregion
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Leave leave = new Leave();

            // Display the value Mon
            Console.WriteLine(Leave.EnumWeek.Mon);

            // Display the integer value of the Mon
            Console.WriteLine((int)(Leave.EnumWeek.Mon));
        }
    }
}
