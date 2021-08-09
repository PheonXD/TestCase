using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCase
{
    class Program
    {
        internal static long summ = 0;
        internal static int _incriment = 3; 
        internal static int _incrimentForSS = 3; //3 - 13-ричная       0 - 10-ричная
        internal static int _systemS = 12; //      12 - 13-ричная       9 - 10-ричная

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите кол-во цифр");
                var countOfNumber = Console.ReadLine();
                start(Convert.ToInt32(countOfNumber));
            }
        }

        static void start(int countOfNumber)
        {
            var rank = (countOfNumber / 2) * _systemS / 2; //количество цифр в одной половине умножается на максимально число в СС и делится на два для поиска только половины
            for (int i = 0; i <= rank; i++)
            {
                if (i == 0) summ = 1; // сочетание с повторением для 0 только 1 возможная при любой СС
                else if (i > 0)
                    summ += getSumOfСombinations(i);
            }
            Console.WriteLine("кол-во красивых чисел: " + (summ * 2).ToString());
        }

        static long getSumOfСombinations(int rank)
        {
            rank += 2; // сочетания с повтореием от С^2(3)
            var combinations = (rank * (rank - 1)) / (2); //расчет сочетания с повторением
            if (rank >= _systemS + _incriment) // если rank - 2 > чем СС То нужно исключить из сочетания цифры которых нет в СС
            {   
                var rankDevider = (rank / 10 * 10) + _incrimentForSS; //расчет ранга исключения для СС
                var ten = (3 * ((rank - rankDevider) * (rank - rankDevider - 1)) / (2)); // Расчет сочетания с повторением для чисел больших чем СС
                combinations = combinations - ten; //Расчет сочетания с повторением, с учетом максимального числа из СС
            }
            return combinations * combinations; //Возведение в степень так как число после половины зеркальное
        }
    }
}
