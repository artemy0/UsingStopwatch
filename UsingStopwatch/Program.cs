using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingStopwatch
{
    class Program
    {
        static void Main(string[] args)
        {
            //display the number of elements and create an array based on these elements
            Console.Write("enter amount of number (more than 2): ");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] numbers = new int[size];
            for (int i = 0; i < size; i++)
            {
                Console.Write($"enter {i + 1}th number: ");
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }

            //testing algorithm
            Console.WriteLine();
            (int GUD, TimeSpan executionTime) res;

            //1th gcd algorithm
            res = AlgorithmDiagnostics(numbers, GetGCD);
            Console.WriteLine($"GetGCD = {res.GUD} time = {res.executionTime}");

            //2th gcd algorithm
            res = AlgorithmDiagnostics(numbers, GetGCDRational);
            Console.WriteLine($"GetGCDRational = {res.GUD} time = {res.executionTime}");

            //3th gcd algorithm
            res = AlgorithmDiagnostics(numbers, GetGCDRemainder);
            Console.WriteLine($"GetGCDRemainder = {res.GUD} time = {res.executionTime}");


            Console.ReadKey();
        }

        static (int GUD, TimeSpan executionTime) AlgorithmDiagnostics(int[] numbers, Func<int, int, int> GCDAlgorithm)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();
            int result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                result = GCDAlgorithm(result, numbers[i]);
            }
            sw.Stop();

            //return of result
            return (result, sw.Elapsed);
        }

        //1th GCD
        static int GetGCDRational(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a == 0 ? b : a;
        }

        //2th GCD
        static int GetGCD(int a, int b)
        {
            for (int i = a; i > 1; i--)
            {
                if (a % i == 0 && b % i == 0)
                {
                    return i;
                }
            }

            return 1;
        }

        //3th GCD
        static int GetGCDRemainder(int a, int b)
        {
            int Remainder;

            while (b != 0)
            {
                Remainder = a % b;
                a = b;
                b = Remainder;
            }

            return a;
        }
    }
}
