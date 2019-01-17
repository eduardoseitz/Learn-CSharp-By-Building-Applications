using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        #region Main Methods

        static void Main(string[] args)
        {
            bool inLoop = true;

            while (inLoop)
            {
                Console.Clear();
                Console.WriteLine("---------------------------------");
                Console.WriteLine("| Welcome to Console Calculator |");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("\n[+] Add \n[-] Sub \n[*] Multi \n[/] Div \n[!] Fac \n[P] Pow \n[S] Sqrt \n[Q] Quit");
                Console.Write("\n \nChoose an option: ");
                string choice = Console.ReadLine().ToLower();

                if (choice.Equals("q") || choice.Equals("quit")) {
                    inLoop = false;
                }else{
                    if (choice.Equals("+") || choice.Equals("add"))
                    {
                        double x = ReadNumber();
                        double y = ReadNumber();
                        Console.WriteLine("\nThe resut of {0} + {1} = {2}", x.ToString(), y.ToString(), (y + x).ToString());
                    }
                    else if (choice.Equals("-") || choice.Equals("sub"))
                    {
                        double x = ReadNumber();
                        double y = ReadNumber();
                        Console.WriteLine("\nThe resut of {0} - {1} = {2}", x.ToString(), y.ToString(), (y - x).ToString());
                    }
                    else if (choice.Equals("*") || choice.Equals("multi"))
                    {
                        double x = ReadNumber();
                        double y = ReadNumber();
                        Console.WriteLine("\nThe resut of {0} * {1} = {2}", x.ToString(), y.ToString(), (y * x).ToString());
                    }
                    else if (choice.Equals("/") || choice.Equals("div"))
                    {
                        double x = ReadNumber();
                        double y = ReadNumber();
                        Console.WriteLine("\nThe resut of {0} / {1} = {2}", x.ToString(), y.ToString(), (y / x).ToString());
                    }
                    else if (choice.Equals("!") || choice.Equals("fac"))
                    {
                        double x = ReadNumber();
                        Console.WriteLine("\nThe resut of fac({0}) = {1}", x.ToString(), Factor(x).ToString());
                    }
                    else if (choice.Equals("p") || choice.Equals("pow"))
                    {
                        double x = ReadNumber();
                        double y = ReadNumber();
                        Console.WriteLine("\nThe resut of {0} power {1} = {2}", x.ToString(), y.ToString(), Power(x, y).ToString());
                    }
                    else if (choice.Equals("s") || choice.Equals("sqrt"))
                    {
                        double x = ReadNumber();
                        if (x <= 0)
                            Console.WriteLine("\nInvalid Value");
                        else
                            Console.WriteLine("\nThe resut of sqrt({0}) = {1}", x.ToString(), SquareRoot(x).ToString(".00"));
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid Option");
                    }
                }
                Console.Write("\nPress [ENTER] to continue...");
                Console.ReadKey();
            }
        }

        #endregion

        #region Helper Methods

        public static double ReadNumber()
        {
            string input;
            double number;
            bool isValid;

            do
            {
                Console.Write("\nType in a valid number: ");
                input = Console.ReadLine();
                isValid = double.TryParse(input, out number);
                if (!isValid)
                    Console.WriteLine("\nInvalid number!");
            }
            while (!isValid);

            return number;
        }

        public static double Factor(double x)
        {
            for (int i = (int) x-1; i != 1; i--)
            {
                x *= i; 
            }
            return x;
        }

        public static double Power(double x, double y)
        {
            double result = x;
            for (double i = y; i != 1; i--)
            {
                result *= x; 
            }
            return result;
        }

        public static double SquareRoot(double x)
        {
            double increment = 0.0001;
            double res;
            for (res = increment; res * res < x; res += increment) { }
            return res;
        }

        #endregion

    }
}