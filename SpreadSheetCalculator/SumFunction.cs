using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadSheetCalculator
{
    class SumFunction : MathFunction
    {
        public override object Execute(string[] args)
        {
            double[] values = ConvertArgsToDouble(args);
            double sum = 0;
            foreach (var value in values)
                sum += value;
            return sum;
        }
    }
}
