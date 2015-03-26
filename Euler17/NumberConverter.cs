using System;
using System.Collections.Generic;

namespace Euler17
{
    public class NumberConverter
    {
        private readonly IDictionary<int, string> comparisonDictionary = new
            Dictionary<int, string>
        {
            {1, "One"},
            {2, "Two"},
            {3, "Three"},
            {4, "Four"},
            {5, "Five"},
            {6, "Six"},
            {7, "Seven"},
            {8, "Eight"},
            {9, "Nine"},
            {10, "Ten"},
            {11, "Eleven"},
            {12, "Twelve"},
            {13, "Thirteen"},
            {14, "Fourteen"},
            {15, "Fifteen"},
            {16, "Sixteen"},
            {17, "Seventeen"},
            {18, "Eighteen"},
            {19, "Nineteen"},
            {20, "Twenty"},
            {30, "Thirty"},
            {40, "Forty"},
            {50, "Fifty"},
            {60, "Sixty"},
            {70, "Seventy"},
            {80, "Eighty"},
            {90, "Ninety"}
        };

        public string Convert(int integer)
        {
            if (integer == 1000)
            {
                return "One Thousand";
            }

            var isDivisibleByTen = integer%10 == 0;

            var isLessThanOneHundred = integer < 100;

            if (integer < 20 || (isDivisibleByTen && isLessThanOneHundred))
            {
                return comparisonDictionary[integer];
            }

            if (isLessThanOneHundred)
            {
                return CalculateLessThanOneHundred(integer);
            }

            var isDivisibleByOneHundred = (integer%100) == 100;
            
            if (isDivisibleByOneHundred)
            {
                return Convert(integer/100) + " Hundred";
            }

            var nearestHundred = (int) Math.Floor(integer/100M)*100;
            var remaining = integer - nearestHundred;
            return Convert(nearestHundred) + " And " + Convert(remaining);
        }

        private string CalculateLessThanOneHundred(int integer)
        {
            var nearestTen = (int) Math.Floor(integer/10M)*10;
            var remaining = integer - nearestTen;
            return Convert(nearestTen) + " " + Convert(remaining);
        }
    }
}