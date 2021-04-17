using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpreadSheetCalculator
{
    class SpreadsheetCell : DataGridViewTextBoxCell
    {
        private string command;
        List<SpreadsheetCell> dependencies;

        public SpreadsheetCell() : base()
        {
            this.command = "";
            this.dependencies = new List<SpreadsheetCell>();
        }
        public string Command
        {
            get { return command; }
            set
            {
                command = value;
                Update();
            }
        }

        public void AddDependency(SpreadsheetCell cell)
        {
            if (!dependencies.Contains(cell))
                dependencies.Add(cell);
        }

        public void Update()
        {
            this.Value = FunctionParser.Parse(command, this.DataGridView);
            foreach (var cell in FunctionParser.extractDependencies(Command, this.DataGridView))
            {
                cell.AddDependency(this);
            }
            foreach (var dependentCell in dependencies)
            {
                dependentCell.Update();
            }
        }
    }
}
