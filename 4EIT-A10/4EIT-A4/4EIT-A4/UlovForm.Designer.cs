namespace _4EIT_A4
{
    partial class UlovForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbpecaros = new System.Windows.Forms.ComboBox();
            this.dtpod = new System.Windows.Forms.DateTimePicker();
            this.dtpdo = new System.Windows.Forms.DateTimePicker();
            this.dgvulov = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btprikazi = new System.Windows.Forms.Button();
            this.btizadji = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chartulov = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dgvulov)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartulov)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pecaros";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Od datuma";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Do datuma";
            // 
            // cbpecaros
            // 
            this.cbpecaros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbpecaros.FormattingEnabled = true;
            this.cbpecaros.Location = new System.Drawing.Point(108, 22);
            this.cbpecaros.Name = "cbpecaros";
            this.cbpecaros.Size = new System.Drawing.Size(170, 24);
            this.cbpecaros.TabIndex = 3;
            // 
            // dtpod
            // 
            this.dtpod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpod.Location = new System.Drawing.Point(108, 59);
            this.dtpod.Name = "dtpod";
            this.dtpod.Size = new System.Drawing.Size(202, 22);
            this.dtpod.TabIndex = 4;
            // 
            // dtpdo
            // 
            this.dtpdo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpdo.Location = new System.Drawing.Point(108, 98);
            this.dtpdo.Name = "dtpdo";
            this.dtpdo.Size = new System.Drawing.Size(200, 22);
            this.dtpdo.TabIndex = 5;
            // 
            // dgvulov
            // 
            this.dgvulov.AllowUserToAddRows = false;
            this.dgvulov.AllowUserToDeleteRows = false;
            this.dgvulov.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvulov.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvulov.Location = new System.Drawing.Point(29, 143);
            this.dgvulov.Name = "dgvulov";
            this.dgvulov.ReadOnly = true;
            this.dgvulov.Size = new System.Drawing.Size(318, 295);
            this.dgvulov.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btizadji);
            this.panel1.Controls.Add(this.btprikazi);
            this.panel1.Location = new System.Drawing.Point(353, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 79);
            this.panel1.TabIndex = 7;
            // 
            // btprikazi
            // 
            this.btprikazi.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btprikazi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btprikazi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btprikazi.Location = new System.Drawing.Point(134, 10);
            this.btprikazi.Name = "btprikazi";
            this.btprikazi.Size = new System.Drawing.Size(130, 48);
            this.btprikazi.TabIndex = 0;
            this.btprikazi.Text = "Prikazi";
            this.btprikazi.UseVisualStyleBackColor = false;
            this.btprikazi.Click += new System.EventHandler(this.btprikazi_Click);
            // 
            // btizadji
            // 
            this.btizadji.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btizadji.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btizadji.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btizadji.Location = new System.Drawing.Point(280, 10);
            this.btizadji.Name = "btizadji";
            this.btizadji.Size = new System.Drawing.Size(130, 48);
            this.btizadji.TabIndex = 1;
            this.btizadji.Text = "Izadji";
            this.btizadji.UseVisualStyleBackColor = false;
            this.btizadji.Click += new System.EventHandler(this.btizadji_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.chartulov);
            this.panel2.Location = new System.Drawing.Point(353, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(435, 339);
            this.panel2.TabIndex = 8;
            // 
            // chartulov
            // 
            chartArea1.Name = "ChartArea1";
            this.chartulov.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartulov.Legends.Add(legend1);
            this.chartulov.Location = new System.Drawing.Point(4, 4);
            this.chartulov.Name = "chartulov";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartulov.Series.Add(series1);
            this.chartulov.Size = new System.Drawing.Size(424, 333);
            this.chartulov.TabIndex = 0;
            this.chartulov.Text = "chart1";
            // 
            // UlovForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvulov);
            this.Controls.Add(this.dtpdo);
            this.Controls.Add(this.dtpod);
            this.Controls.Add(this.cbpecaros);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UlovForm";
            this.Text = "Ulov pecaroša";
            this.Load += new System.EventHandler(this.UlovForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvulov)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartulov)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbpecaros;
        private System.Windows.Forms.DateTimePicker dtpod;
        private System.Windows.Forms.DateTimePicker dtpdo;
        private System.Windows.Forms.DataGridView dgvulov;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btizadji;
        private System.Windows.Forms.Button btprikazi;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartulov;
    }
}