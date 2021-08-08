using System;
using System.Collections.Generic;
using System.Linq;
namespace TestCase
{
    class Program
    {
        internal static string _minValue = "0000000000000";
        internal static string _maxValue = "CCCCCCCCCCCCC";
        static void Main(string[] args)
        {
            BruteForce();
        }

        static ulong HexToDec(string value)
        {
            UInt64 res = 0;
            UInt64 factor = 1;
            for (int i = value.Length - 1; i >= 0; i--, factor *= 13)
                if (value[i] >= '0' && value[i] <= '9') res += (UInt64)(value[i] - '0') * factor;
                else
                    if (value[i] >= 'A' && value[i] <= 'C') res += (UInt64)(value[i] - 55) * factor;
            return res;
        }

        static string DecToHex(ulong value)
        {
            string res = "";
            UInt64 factor = 1;
            var number = Convert.ToInt64(value);
            for (; number > 0; number /= 13)
            {
                factor = (ulong)(number % 13);
                res = (char)(factor < 10 ? factor + '0' : factor + 55) + res;
            }
            return res;
        }

        static void BruteForce()
        {
            var count = 0;
            var dec = HexToDec(_maxValue) / 2;
            var min = HexToDec(_minValue) / 2;
            Console.WriteLine($"Started calculation beautifuls number from {_minValue} to hex {_maxValue} (Dec: {dec})");

            for (var i = dec; i > min; i--)
            {
                var hex = DecToHex(i);
                var lastSix = hex.Remove(0, 7);
                var firstSix = hex.Remove(6, 7);
                if (CheckBeautifulNumber(lastSix, firstSix))
                {
                    count++;
                    Console.WriteLine($"finded number: {hex}");
                }
            }

            Console.WriteLine($"Count of beautifuls number: {count}");
        }

        static int[] GetIntArray(ulong num)
        {
            List<int> listOfInts = new List<int>();
            while (num > 0)
            {
                listOfInts.Add((int)num % 10);
                num = num / 10;
            }
            listOfInts.Reverse();
            return listOfInts.ToArray();
        }

        static bool CheckBeautifulNumber(string hexNumber1, string hexNumber2)
        {
            var firstArr = GetIntArray(HexToDec(hexNumber1));
            var secondArr = GetIntArray(HexToDec(hexNumber2));

            var summFirst = firstArr.Sum();
            var summSecond = secondArr.Sum();

            if (summFirst == summSecond) return true;
            else return false;
        }
    }
}
