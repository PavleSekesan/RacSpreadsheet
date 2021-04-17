using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadSheetCalculator
{
    class AvgFunction : MathFunction
    {
        public override object Execute(string[] args)
        {
            var sumFunc = new SumFunction();
            double sum = Convert.ToDouble(sumFunc.Execute(args));
            return sum / args.Length;
        }
    }
}
