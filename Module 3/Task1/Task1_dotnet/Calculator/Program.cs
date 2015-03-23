using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        //static int num1, num2;
        static void Main(string[] args)
        {
            Console.WriteLine("Input the action you would like to perform with numbers: \n1. Addition - A\n2. Subtraction - S\n3. Multiplication - M\n4. Division - D");
            string action = Console.ReadLine().ToUpper();             
            //Console.WriteLine("Action=" + action);
            if ((action != "A") & (action != "S") & (action != "M") & (action != "D"))
            {
                Console.WriteLine("Action is incorrect");
            }

            Console.WriteLine("Input the first number (integer)");
            string num1 = Console.ReadLine();
            int num1int = Convert.ToInt32(num1);
            Console.WriteLine("Input the second number (integer)");
            string num2 = Console.ReadLine();
            int num2int = Convert.ToInt32(num2);
            switch (action)
            {
                case "A": Console.WriteLine("Result:" + (num1int + num2int)); Console.ReadLine(); break;
                case "S": Console.WriteLine("Result:" + (num1int - num2int)); Console.ReadLine(); break;
                case "M": Console.WriteLine("Result:" + (num1int * num2int)); Console.ReadLine(); break;
                case "D":
                    {
                        if (num2int == 0)
                        {
                            Console.WriteLine("Result: N/A");
                            Console.ReadLine();
                        }
                        else
                        {
                            float num1fl = num1int;
                            //int div = Math.DivRem(num1int, num2int, out remainder); ;
                            Console.WriteLine("Result:" + "{0:f5}", num1fl / num2int);                             
                            Console.ReadLine();
                        }
                        break;
                    }
                   

            }
        }
    }
}
