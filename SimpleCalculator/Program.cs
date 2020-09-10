using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Class to convert user input
                InputConverter inputConverter = new InputConverter();

                // While loops to prevent user from continuing if invalid input is entered - Justin. M
                bool success = double.TryParse(Console.ReadLine(), out double firstNumber);
                while (success == false)
                {
                    Console.WriteLine("Detected non numeric input. Please try again by entering a number.");
                    success = double.TryParse(Console.ReadLine(), out firstNumber);
                }

                bool success2 = double.TryParse(Console.ReadLine(), out double secondNumber);
                while (success2 == false)
                {
                    Console.WriteLine("Detected non numeric input. Please try again by entering a number.");
                    success2 = double.TryParse(Console.ReadLine(), out secondNumber);
                }

                string operation = Console.ReadLine();
                while (operation != "+" && operation != "-" && operation != "*" && operation != "/" && operation != "^" &&
                   operation != "add" && operation != "subtract" && operation != "multiply" && operation != "divide" && operation != "exponent")
                {
                    Console.WriteLine("Specified operation is not recognized. " +
                        "Please try again by entering + or add, - or subtract, * or multiply and / or divide.");
                    operation = Console.ReadLine();
                }

                // Statement that calls the CalcEngine library as well as the static method it contains - Justin. M

                double result = CalcEngine.CalcEngine.Calculate(operation, firstNumber, secondNumber);

                // If statements and String.Format to display the results of the calculator in a readable format - Justin. M

                if (operation == "add" | operation == "+")
                {
                    operation = "plus";
                }
                if (operation == "subtract" | operation == "-")
                {
                    operation = "minus";
                }
                if (operation == "multiply" | operation == "*")
                {
                    operation = "multiplied by";
                }
                if (operation == "divide" | operation == "/")
                {
                    operation = "divided by";
                }
                if (operation == "exponent" | operation == "^") // Added exponent function - Justin A.
                {
                    operation = "to the power of";
                }

                String g = String.Format("The value of {0} {1} {2} is equal to {3,0:F2}", firstNumber, operation, secondNumber, result);

                Console.WriteLine(g);

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        

    }
}
