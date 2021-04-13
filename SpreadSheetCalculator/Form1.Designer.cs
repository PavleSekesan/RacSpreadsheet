
namespace SpreadSheetCalculator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainDataGrid = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bt_choose = new System.Windows.Forms.Button();
            this.tx_path = new System.Windows.Forms.TextBox();
            this.bt_load = new System.Windows.Forms.Button();
            this.tx_sheet = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.bt_export = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGrid)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainDataGrid
            // 
            this.mainDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainDataGrid.Location = new System.Drawing.Point(12, 136);
            this.mainDataGrid.Name = "mainDataGrid";
            this.mainDataGrid.Size = new System.Drawing.Size(797, 324);
            this.mainDataGrid.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 110);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(797, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // bt_choose
            // 
            this.bt_choose.Location = new System.Drawing.Point(6, 3);
            this.bt_choose.Name = "bt_choose";
            this.bt_choose.Size = new System.Drawing.Size(75, 23);
            this.bt_choose.TabIndex = 2;
            this.bt_choose.Text = "Choose file";
            this.bt_choose.UseVisualStyleBackColor = true;
            this.bt_choose.Click += new System.EventHandler(this.button1_Click);
            // 
            // tx_path
            // 
            this.tx_path.Location = new System.Drawing.Point(87, 6);
            this.tx_path.Name = "tx_path";
            this.tx_path.Size = new System.Drawing.Size(695, 20);
            this.tx_path.TabIndex = 3;
            // 
            // bt_load
            // 
            this.bt_load.Location = new System.Drawing.Point(6, 28);
            this.bt_load.Name = "bt_load";
            this.bt_load.Size = new System.Drawing.Size(75, 23);
            this.bt_load.TabIndex = 4;
            this.bt_load.Text = "Load";
            this.bt_load.UseVisualStyleBackColor = true;
            this.bt_load.Click += new System.EventHandler(this.bt_load_Click);
            // 
            // tx_sheet
            // 
            this.tx_sheet.Location = new System.Drawing.Point(87, 31);
            this.tx_sheet.Name = "tx_sheet";
            this.tx_sheet.Size = new System.Drawing.Size(695, 20);
            this.tx_sheet.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(801, 96);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.bt_choose);
            this.tabPage1.Controls.Add(this.tx_sheet);
            this.tabPage1.Controls.Add(this.tx_path);
            this.tabPage1.Controls.Add(this.bt_load);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(793, 70);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.bt_export);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(793, 70);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // bt_export
            // 
            this.bt_export.Location = new System.Drawing.Point(7, 7);
            this.bt_export.Name = "bt_export";
            this.bt_export.Size = new System.Drawing.Size(75, 23);
            this.bt_export.TabIndex = 0;
            this.bt_export.Text = "Export";
            this.bt_export.UseVisualStyleBackColor = true;
            this.bt_export.Click += new System.EventHandler(this.bt_export_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 477);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.mainDataGrid);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGrid)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView mainDataGrid;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button bt_choose;
        private System.Windows.Forms.TextBox tx_path;
        private System.Windows.Forms.Button bt_load;
        private System.Windows.Forms.TextBox tx_sheet;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button bt_export;
    }
}

