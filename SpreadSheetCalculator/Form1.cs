using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpreadSheetCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GridSetup();
        }

        private void SetRowIndicies()
        {
            foreach (DataGridViewRow row in mainDataGrid.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }
        private void SetColumnHeaders()
        {
            for (int i = 0; i < mainDataGrid.ColumnCount; i++)
            {
                // Convert header index to alphabet string
                int temp = i + 1;
                string headerText = "";
                while (temp > 0)
                {
                    int currentLetterCode = (temp - 1) % 26;
                    headerText = Convert.ToChar(currentLetterCode + 65) + headerText;
                    temp = (temp - currentLetterCode - 1) / 26;
                }

                mainDataGrid.Columns[i].HeaderText = headerText;
            }
        }
        private void GridSetup()
        {
            const int COLUMN_NUMBER = 26;
            const int ROW_NUMBER = 128;

            mainDataGrid.ColumnCount = COLUMN_NUMBER;
            mainDataGrid.RowCount = ROW_NUMBER;
            
            SetColumnHeaders();
            SetRowIndicies();

            mainDataGrid.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }
    }
}
