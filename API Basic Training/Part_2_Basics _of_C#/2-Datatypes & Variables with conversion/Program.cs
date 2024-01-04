using System;

namespace _2_Datatypes___Variables_with_conversion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // numaric type
            int id = 369;
            Console.WriteLine("id "+id);
            long accountNo = 200540107143;
            Console.WriteLine("accountNo "+accountNo);
            float balance = 18598.54867856f;
            Console.WriteLine("balance "+balance);
            double sale = 63894327.3584796;
            Console.WriteLine("sale "+sale);

            // character type
            char nameCode = 'J';
            Console.WriteLine("nameCode "+nameCode);
            string password = "12345";
            Console.WriteLine("password "+password);

            //boolean type
            bool hasAccess = false;
            Console.WriteLine("hasAccess "+hasAccess);

            // type conversion

            //implicit
            long empCode = id;
            Console.WriteLine("empCode "+empCode);

            //explicit
            int expValue = (int)sale;
            Console.WriteLine("expValue "+expValue);
            int asciiCode = (int)nameCode;
            Console.WriteLine("asciiCode "+asciiCode);

            //Converting a string to another data type.
            int num = int.Parse(password);
            Console.WriteLine("num "+num);

            //TryParse
            if (int.TryParse(password, out int tryNum))
            {
                Console.WriteLine("tryNum "+tryNum);
            }
            else
            {
                Console.WriteLine("Error : Parsing Not Done");
            }

            //Convert Class
            string lastPassword = Convert.ToString(password);
            Console.WriteLine("lastPassword "+lastPassword);

            // Boxing UnBoxing
            object boxPassword = num; // boxing
            Console.WriteLine("boxPassword "+boxPassword);
            int unBoxPassword = (int)boxPassword; // Unboxing
            Console.WriteLine("unBoxPassword "+unBoxPassword);
        }
    }
}
