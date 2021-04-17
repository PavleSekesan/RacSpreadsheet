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
        private static Dictionary<string, Function> functionsDict = new Dictionary<string, Function>()
        {
            { "SUM", new SumFunction() },
            { "AVG", new AvgFunction() }
        };

        private static bool ArgIsGroupOfCells(string arg)
        {
            string[] cells = arg.Split(':');
            try
            {
                return ArgIsCell(cells[0]) && ArgIsCell(cells[1]);
            }
            catch
            {
                return false;
            }
        }

        private static bool ArgIsCell(string arg)
        {
            // Check if arg contains letters and doesn't contain a bracket
            //return Regex.IsMatch(arg, @"^[a-zA-Z]") && !arg.Contains('(');
            return Regex.IsMatch(arg, "^[a-zA-Z]+[0-9]+$");
        }

        private static bool ArgIsNumber(string arg)
        {
            return Regex.IsMatch(arg, @"^[0-9]+$");
        }

        private static SpreadsheetCell ConvertIndexToCell(string index)
        {
            string letter = Regex.Match(index, @"^[^0-9]*").Value;
            int col = CellIndexConverter.LetterToNumber(letter) - 1;
            int row = Convert.ToInt32(Regex.Match(index, @"\d+").Value) - 1;
            return dataGrid.Rows[row].Cells[col] as SpreadsheetCell;
        }

        private static string UnravelGroupOfCells(string text)
        {
            var groups = Regex.Matches(text, @"[a-zA-Z]+[0-9]+[:][a-zA-Z]+[0-9]+");
            foreach (Match group in groups)
            {
                string groupStr = group.Value;
                string replacement = "";
                // ISUSE SREDI OVO
                ///////////////////
                string[] cells = groupStr.Split(':');
                string cell1 = cells[0];
                string cell2 = cells[1];
                int col1 = CellIndexConverter.LetterToNumber(Regex.Match(cell1, @"^[^0-9]*").Value) - 1;
                int row1 = Convert.ToInt32(Regex.Match(cell1, @"\d+").Value);
                int col2 = CellIndexConverter.LetterToNumber(Regex.Match(cell2, @"^[^0-9]*").Value) - 1;
                int row2 = Convert.ToInt32(Regex.Match(cell2, @"\d+").Value);
                if (row1 == row2)
                {
                    for (int i = col1; i <= col2; i++)
                    {
                        replacement += CellIndexConverter.NumberToLetter(i) + Convert.ToString(row1) + ",";
                    }
                }
                else if (col1 == col2)
                {
                    for (int i = row1; i <= row2; i++)
                    {
                        replacement += CellIndexConverter.NumberToLetter(col1) + Convert.ToString(i) + ",";
                    }
                }
                text = text.Replace(groupStr, replacement);
                ///////////////////
            }
            return text;
        }
        
        public static object Parse(string text, DataGridView mainDataGrid)
        {
            dataGrid = mainDataGrid;
            text = UnravelGroupOfCells(text);
            try
            {
                if (text == "")
                    return text;
                if (ArgIsCell(text))
                {
                    return ConvertIndexToCell(text).Value;
                }
                if (ArgIsNumber(text))
                {
                    return Convert.ToDouble(text);
                }
                if (text[0] != '=')
                    return text;
                text = text.Substring(1);
                text.Trim();
                

                string function = text.Split('(')[0];
                int openParenthesesIndex = text.IndexOf('(') + 1;
                int closedParenthesesIndex = text.LastIndexOf(')');

                // Split into args
                int insideAnotherFunction = 0;
                List<string> argsList = new List<string>();
                string currentArg = "";
                foreach (char c in text.Substring(openParenthesesIndex, closedParenthesesIndex - openParenthesesIndex))
                {
                    if (c == ',' && insideAnotherFunction == 0)
                    {
                        currentArg = Parse(currentArg, dataGrid).ToString();
                        argsList.Add(currentArg);
                        currentArg = "";
                    }
                    else
                       currentArg += c.ToString();

                    if (c == '(')
                        insideAnotherFunction++;
                    if (c == ')')
                        insideAnotherFunction--;
                }
                currentArg = Parse(currentArg, dataGrid).ToString();
                argsList.Add(currentArg);
                string[] args = argsList.ToArray();

                return functionsDict[function].Execute(args);
            }
            catch
            {
                return null;
            }
        }

        public static List<SpreadsheetCell> extractDependencies(string text, DataGridView mainDataGrid)
        {
            var dependencies = new List<SpreadsheetCell>();
            text = UnravelGroupOfCells(text);
            text = text.Replace(")", "");
            string[] splitText = text.Split(new char[] { '(', ',' });
            foreach (string arg in splitText)
            {
                if (ArgIsCell(arg))
                    dependencies.Add(ConvertIndexToCell(arg));
            }

            return dependencies;
        }
    }
}
