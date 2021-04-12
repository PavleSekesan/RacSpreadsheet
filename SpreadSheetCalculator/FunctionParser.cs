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
        private static string[] functions = new string[] { "SUM", "AVG" };
        private static object GetCellValue(int row, int col)
        {
            return dataGrid.Rows[row].Cells[col].Value;
        }

        private static double ExecuteFunction(string function, string[] args)
        {
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

        private static bool ArgIsFunction(string arg)
        {
            foreach (var function in functions)
            {
                if (arg.Contains(function))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool ArgIsCell(string arg)
        {
            // Check if arg contains letters
            return Regex.IsMatch(arg, @"^[a-zA-Z]");
        }
        private static double[] ConvertArgsToDouble(string[] args)
        {
            double[] values = new double[args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                string arg = args[i];
               
                if (ArgIsFunction(arg))
                    arg = Parse(arg, dataGrid).ToString();

                if (ArgIsCell(arg))
                {
                    string letter = Regex.Match(arg, @"^[^0-9]*").Value;
                    int col = CellIndexConverter.LetterToNumber(letter) - 1;
                    int row = Convert.ToInt32(Regex.Match(arg, @"\d+").Value) - 1;
                    values[i] = Convert.ToDouble(GetCellValue(row, col));
                }
                else
                    values[i] = Convert.ToDouble(arg);
                
            }
            return values;
        }
        
        public static double Parse(string text, DataGridView mainDataGrid)
        {
            dataGrid = mainDataGrid;
            try
            {
                string function = text.Split('(')[0];
                int openParenthesesIndex = text.IndexOf('(') + 1;
                int closedParenthesesIndex = text.LastIndexOf(')');

                // Split into args
                bool insideAnotherFunction = false;
                List<string> argsList = new List<string>();
                string currentArg = "";
                foreach (char c in text.Substring(openParenthesesIndex, closedParenthesesIndex - openParenthesesIndex))
                {
                    if (c == ',' && !insideAnotherFunction)
                    {
                        argsList.Add(currentArg);
                        currentArg = "";
                    }
                    else
                       currentArg += c.ToString(); 

                    if (c == '(')
                        insideAnotherFunction = true;
                    if (c == ')')
                        insideAnotherFunction = false;
                }
                argsList.Add(currentArg);
                string[] args = argsList.ToArray();

                return ExecuteFunction(function, args);
            }
            catch
            {
                return Double.NaN;
            }
        }
    }
}
