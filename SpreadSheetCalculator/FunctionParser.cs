using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpreadSheetCalculator
{
    static class FunctionParser
    {
        private static DataGridView dataGrid;
        private static object GetCellValue(int row, int col)
        {
            return dataGrid.Rows[row].Cells[col].Value;
        }
        private static double[] ConvertArgsToDouble(string[] args)
        {
            double[] values = new double[args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                string arg = args[i];
                bool hasLetters = !Regex.IsMatch(arg, @"^[a-zA-Z]+$");
                if (!hasLetters)
                    values[i] = Convert.ToDouble(arg);
                else
                {
                    string letter = Regex.Match(arg, @"^[^0-9]*").Value;
                    int col = CellIndexConverter.LetterToNumber(letter) - 1;
                    int row = Convert.ToInt32(Regex.Match(arg, @"\d+").Value) - 1;
                    values[i] = Convert.ToDouble(GetCellValue(row, col));
                }
            }
            return values;
        }
        private static double ExecuteSum(string[] args)
        {
            double[] values = ConvertArgsToDouble(args);
            double sum = 0;
            foreach (var value in values)
                sum += value;
            return sum;
        }

        private static double ExecuteAverage(string[] args)
        {
            double sum = ExecuteSum(args);
            return sum / args.Length;
        }
        public static double Parse(string text, DataGridView mainDataGrid)
        {
            dataGrid = mainDataGrid;
            try
            {
                string function = text.Split('(')[0];
                int openParenthesesIndex = text.IndexOf('(') + 1;
                int closedParenthesesIndex = text.LastIndexOf(')');
                string[] args = text.Substring(openParenthesesIndex, closedParenthesesIndex - openParenthesesIndex).Split(',');


                if (function == "SUM")
                {
                    return ExecuteSum(args);
                }
                else if (function == "AVG")
                {
                    return ExecuteAverage(args);
                }
                else
                    return Double.NaN;
            }
            catch
            {
                return Double.NaN;
            }
        }
    }
}
