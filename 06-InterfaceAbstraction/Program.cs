using System;

namespace CalculatorApp
{
    public interface ICalculation
    {
        double Calculate(double num1, double num2, char op);
    }

    public class Calculation : ICalculation
    {
        public double Calculate(double num1, double num2, char op)
        {
            double result = 0;

            switch (op)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        Console.WriteLine("Xeta: Sifira bölmek olmaz!");
                        return 0;
                    }
                    break;
                default:
                    Console.WriteLine("Xeta: Yanliş operator daxil edilib!");
                    break;
            }

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ICalculation myCalc = new Calculation();

            Console.WriteLine("--- Sade Kalkulyator ---");

            try
            {
                Console.Write("Birinci ededi daxil edin: ");
                double n1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Operatoru daxil edin (+, -, *, /): ");
                char operatorChar = Convert.ToChar(Console.ReadLine());

                Console.Write("İkinci ededi daxil edin: ");
                double n2 = Convert.ToDouble(Console.ReadLine());

                double finalResult = myCalc.Calculate(n1, n2, operatorChar);

                Console.WriteLine("\nNetice: " + finalResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Xeta baş verdi: " + ex.Message);
            }

            Console.WriteLine("\ncixmaq ucun her hansi bir duymeye basin...");
            Console.ReadKey();
        }
    }
}