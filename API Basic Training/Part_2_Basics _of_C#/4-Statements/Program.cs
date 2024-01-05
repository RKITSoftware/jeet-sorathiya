using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Statements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // if..elseIf..else
            bool isActive = true;
            bool hasAccess = false;

            if(isActive)
            {
                Console.WriteLine("Is Active User");
            }
            else if(hasAccess)
            {
                Console.WriteLine("Have Access");
            }
            else
            {
                Console.WriteLine("Not Active and not have access");
            }

            // switch case
            Console.WriteLine("enter emp id");
            int id = int.Parse(Console.ReadLine());
            switch (id)
            {
                case 368:
                    Console.WriteLine("Hello Prince");
                    break;
                case 369:
                    Console.WriteLine("Hello Jeet");
                    break;
                case 370:
                    Console.WriteLine("Hello Harshil");
                    break;
                default: 
                    Console.WriteLine("Hello Trainee");
                    break;
            }
            // loops
            int[] empId = { 365, 366, 367, 368, 369, 370 };
            // for loop
            for(int i = 0; i < empId.Length; i++)
            {
                Console.WriteLine(empId[i]);
            }
            // do while
            int count = 0;
            do
            {
                Console.WriteLine("Count : " + (++count));
            }while (count < 5);

            //for each
            foreach(int item  in empId)
            {
                Console.WriteLine(item);
            }

            //while
            while(count < 10)
            {
                count++;
                if (count %2 == 0)
                {
                    Console.WriteLine("Count is " + count);
                }
                else
                {
                    continue;
                }
               
            }
        }
    }
}
