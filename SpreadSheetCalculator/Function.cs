using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadSheetCalculator
{
    abstract class Function
    {
        public abstract object Execute(string[] args);
    }
}
