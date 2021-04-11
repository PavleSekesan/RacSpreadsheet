using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadSheetCalculator
{
    static class CellIndexConverter
    {
        public static string NumberToLetter(int i)
        {
            // Convert header index to alphabet string
            int temp = i + 1;
            string letter = "";
            while (temp > 0)
            {
                int currentLetterCode = (temp - 1) % 26;
                letter = Convert.ToChar(currentLetterCode + 65) + letter;
                temp = (temp - currentLetterCode - 1) / 26;
            }

            return letter;
        }

        public static int LetterToNumber(string colAdress)
        {
            int[] digits = new int[colAdress.Length];
            for (int i = 0; i < colAdress.Length; ++i)
            {
                digits[i] = Convert.ToInt32(colAdress[i]) - 64;
            }
            int mul = 1; int res = 0;
            for (int pos = digits.Length - 1; pos >= 0; --pos)
            {
                res += digits[pos] * mul;
                mul *= 26;
            }
            return res;
        }
    }
}
