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
        //class instance for diagnostics
        static Stopwatch sw = new Stopwatch();

        static void Main(string[] args)
        {
            //display the number of elements and create an array based on these elements
            Console.Write("enter amount of number (more than 2): ");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] numbers = FillArrayOfNumbers(size);

            //testing algorithm
            Console.WriteLine();

            //1th gcd algorithm
            AlgorithmDiagnostics(numbers, GetGCD);

            //2th gcd algorithm
            AlgorithmDiagnostics(numbers, GetGCDRational);

            //3th gcd algorithm
            AlgorithmDiagnostics(numbers, GetGCDRemainder);


            Console.ReadKey();
        }

        static int[] FillArrayOfNumbers(int size)
        {
            int[] numbers = new int[size];
            for (int i = 0; i < size; i++)
            {
                Console.Write($"enter {i + 1}th number: ");
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }
            return numbers;
        }

        static void AlgorithmDiagnostics(int[] numbers, Func<int, int, int> GCDAlgorithm)
        {
            sw.Start();
            int result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                result = GCDAlgorithm(result, numbers[i]);
            }
            sw.Stop();
            //output of result
            Console.WriteLine($"GetGCDRemainder = {result} time = {sw.Elapsed}");
            sw.Reset();
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
