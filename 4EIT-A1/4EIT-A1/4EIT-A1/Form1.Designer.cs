namespace _4EIT_A1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtadr = new System.Windows.Forms.TextBox();
            this.txtprez = new System.Windows.Forms.TextBox();
            this.txtime = new System.Windows.Forms.TextBox();
            this.txtjmbg = new System.Windows.Forms.TextBox();
            this.txtcid = new System.Windows.Forms.TextBox();
            this.lvcitaoci = new System.Windows.Forms.ListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.chartbox1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgcitaoci = new System.Windows.Forms.DataGridView();
            this.cbcitalac = new System.Windows.Forms.ComboBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartbox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgcitaoci)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(763, 391);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.txtadr);
            this.tabPage1.Controls.Add(this.txtprez);
            this.tabPage1.Controls.Add(this.txtime);
            this.tabPage1.Controls.Add(this.txtjmbg);
            this.tabPage1.Controls.Add(this.txtcid);
            this.tabPage1.Controls.Add(this.lvcitaoci);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(755, 365);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Čitaoci";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(83, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Adresa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(83, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Prezime";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Ime";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Maticni Broj";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "CitalacID";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(72, 329);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 22);
            this.button2.TabIndex = 7;
            this.button2.Text = "Izađi";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(72, 291);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Upiši Čitaoca";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtadr
            // 
            this.txtadr.Location = new System.Drawing.Point(189, 258);
            this.txtadr.Name = "txtadr";
            this.txtadr.Size = new System.Drawing.Size(100, 20);
            this.txtadr.TabIndex = 5;
            this.txtadr.Validated += new System.EventHandler(this.txtime_Validated);
            // 
            // txtprez
            // 
            this.txtprez.Location = new System.Drawing.Point(189, 209);
            this.txtprez.Name = "txtprez";
            this.txtprez.Size = new System.Drawing.Size(100, 20);
            this.txtprez.TabIndex = 4;
            this.txtprez.Validated += new System.EventHandler(this.txtime_Validated);
            // 
            // txtime
            // 
            this.txtime.Location = new System.Drawing.Point(187, 153);
            this.txtime.Name = "txtime";
            this.txtime.Size = new System.Drawing.Size(100, 20);
            this.txtime.TabIndex = 3;
            this.txtime.Validated += new System.EventHandler(this.txtime_Validated);
            // 
            // txtjmbg
            // 
            this.txtjmbg.Location = new System.Drawing.Point(189, 96);
            this.txtjmbg.Name = "txtjmbg";
            this.txtjmbg.Size = new System.Drawing.Size(100, 20);
            this.txtjmbg.TabIndex = 2;
            this.txtjmbg.Validated += new System.EventHandler(this.txtime_Validated);
            // 
            // txtcid
            // 
            this.txtcid.Location = new System.Drawing.Point(188, 48);
            this.txtcid.Name = "txtcid";
            this.txtcid.Size = new System.Drawing.Size(100, 20);
            this.txtcid.TabIndex = 1;
            this.txtcid.Validated += new System.EventHandler(this.txtcid_Validated);
            // 
            // lvcitaoci
            // 
            this.lvcitaoci.HideSelection = false;
            this.lvcitaoci.Location = new System.Drawing.Point(349, 19);
            this.lvcitaoci.MultiSelect = false;
            this.lvcitaoci.Name = "lvcitaoci";
            this.lvcitaoci.Size = new System.Drawing.Size(385, 325);
            this.lvcitaoci.TabIndex = 0;
            this.lvcitaoci.UseCompatibleStateImageBehavior = false;
            this.lvcitaoci.SelectedIndexChanged += new System.EventHandler(this.lvcitaoci_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.chartbox1);
            this.tabPage2.Controls.Add(this.dgcitaoci);
            this.tabPage2.Controls.Add(this.cbcitalac);
            this.tabPage2.Controls.Add(this.numericUpDown2);
            this.tabPage2.Controls.Add(this.numericUpDown1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(755, 365);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Pregled Iznajmljivanja";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(500, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Do";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(372, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Od";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(145, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Vremenski period";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(66, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Čitalac";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(267, 326);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(118, 328);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 21);
            this.button3.TabIndex = 5;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // chartbox1
            // 
            chartArea1.Name = "ChartArea1";
            this.chartbox1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartbox1.Legends.Add(legend1);
            this.chartbox1.Location = new System.Drawing.Point(447, 128);
            this.chartbox1.Name = "chartbox1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartbox1.Series.Add(series1);
            this.chartbox1.Size = new System.Drawing.Size(279, 201);
            this.chartbox1.TabIndex = 4;
            this.chartbox1.Text = "chart1";
            // 
            // dgcitaoci
            // 
            this.dgcitaoci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgcitaoci.Location = new System.Drawing.Point(55, 138);
            this.dgcitaoci.Name = "dgcitaoci";
            this.dgcitaoci.Size = new System.Drawing.Size(270, 167);
            this.dgcitaoci.TabIndex = 3;
            // 
            // cbcitalac
            // 
            this.cbcitalac.FormattingEnabled = true;
            this.cbcitalac.Location = new System.Drawing.Point(129, 91);
            this.cbcitalac.Name = "cbcitalac";
            this.cbcitalac.Size = new System.Drawing.Size(196, 21);
            this.cbcitalac.TabIndex = 2;
            this.cbcitalac.SelectedIndexChanged += new System.EventHandler(this.cbcitalac_SelectedIndexChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(541, 45);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(62, 20);
            this.numericUpDown2.TabIndex = 1;
            this.numericUpDown2.Value = new decimal(new int[] {
            2023,
            0,
            0,
            0});
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(413, 45);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(61, 20);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.Value = new decimal(new int[] {
            2013,
            0,
            0,
            0});
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.axAcroPDF1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(755, 365);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "O Aplikaciji";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // axAcroPDF1
            // 
            this.axAcroPDF1.Enabled = true;
            this.axAcroPDF1.Location = new System.Drawing.Point(53, 15);
            this.axAcroPDF1.Name = "axAcroPDF1";
            this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
            this.axAcroPDF1.Size = new System.Drawing.Size(669, 323);
            this.axAcroPDF1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartbox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgcitaoci)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtadr;
        private System.Windows.Forms.TextBox txtprez;
        private System.Windows.Forms.TextBox txtime;
        private System.Windows.Forms.TextBox txtjmbg;
        private System.Windows.Forms.TextBox txtcid;
        private System.Windows.Forms.ListView lvcitaoci;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartbox1;
        private System.Windows.Forms.DataGridView dgcitaoci;
        private System.Windows.Forms.ComboBox cbcitalac;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
    }
}

