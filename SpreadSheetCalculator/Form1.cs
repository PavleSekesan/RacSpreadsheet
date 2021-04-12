﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

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
            tabPage1.Text = "Import";
            tabPage2.Text = "Export";
            tx_sheet.Text = "Sheet1";
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
                mainDataGrid.Columns[i].HeaderText = CellIndexConverter.NumberToLetter(i);
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

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //MessageBox.Show(FunctionParser.Parse(textBox1.Text).ToString());
                mainDataGrid.SelectedCells[0].Value = FunctionParser.Parse(textBox1.Text, mainDataGrid);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"Documents",
                Title = "Browse Excel Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "xlsx",
                Filter = "xlsx files (*.xlsx)|*.xlsx",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.tx_path.Text = openFileDialog1.FileName;
            }
        }

        private void bt_load_Click(object sender, EventArgs e)
        {
            string PathConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + tx_path.Text + ";Extended Properties = \"Excel 12.0 Xml;HDR=YES\"; ";
            OleDbConnection conn = new OleDbConnection(PathConn);
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter("Select * from [" + tx_sheet.Text + "$]", conn);
            DataTable dt = new DataTable();
            myDataAdapter.Fill(dt);
            mainDataGrid.Columns.Clear();
            mainDataGrid.DataSource = dt;

        }
    }
}
