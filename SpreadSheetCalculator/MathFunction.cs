using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadSheetCalculator
{
    abstract class MathFunction : Function
    {
        protected double[] ConvertArgsToDouble(string[] args)
        {
            double[] newArgs = new double[args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                newArgs[i] = Convert.ToDouble(args[i]);
            }
            return newArgs;
        }
    }
}
