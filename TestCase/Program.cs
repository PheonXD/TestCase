using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCase
{
    class Program
    {
        internal static long summ = 0;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите кол-во цифр");
                var countOfNumber = Console.ReadLine();
                Start(Convert.ToInt32(countOfNumber));
            }
        }

        static void Start(int countOfNumber)
        {
            var rank = (countOfNumber / 2) * 9 / 2;
            for (int i = 0; i <= rank; i++)
            {
                if (i == 0) summ = 1;
                else if (i > 0)
                    summ += getSumOfСombinations(i);
            }
            Console.WriteLine("кол-во красивых чисел: " + (summ * 2).ToString());
        }

        static long getSumOfСombinations(int rank)
        {
            rank += 2;
            var combinations = (rank * (rank - 1)) / (2);
            if (rank >= 12)
            {   
                var rankDevider = (rank / 10 * 10) + 3;
                var ten = (3 * ((rank - rankDevider) * (rank - rankDevider - 1)) / (2));
                combinations = combinations - ten;
            }
            return combinations * combinations;
        }
    }
}
