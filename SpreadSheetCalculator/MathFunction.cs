using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpreadSheetCalculator
{
    abstract class MathFunction : Function
    {
        protected double[] ConvertArgsToDouble(string[] args)
        {
            List<double> newArgs = new List<double>();
            for (int i = 0; i < args.Length; i++)
            {
                if (Regex.IsMatch(args[i], @"^[0-9]+$"))
                {
                    newArgs.Add(Convert.ToDouble(args[i]));
                }
            }
            return newArgs.ToArray();
        }
    }
}
