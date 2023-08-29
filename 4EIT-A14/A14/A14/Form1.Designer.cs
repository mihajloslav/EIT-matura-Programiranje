namespace A14
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.brisi = new System.Windows.Forms.ToolStripButton();
            this.analiza = new System.Windows.Forms.ToolStripButton();
            this.oaplikaciji = new System.Windows.Forms.ToolStripButton();
            this.izlaz = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbLek = new System.Windows.Forms.TextBox();
            this.tbProizvodjac = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(30, 50);
            this.toolStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.brisi,
            this.analiza,
            this.oaplikaciji,
            this.izlaz});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 69);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // brisi
            // 
            this.brisi.AutoSize = false;
            this.brisi.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.brisi.Image = ((System.Drawing.Image)(resources.GetObject("brisi.Image")));
            this.brisi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.brisi.Name = "brisi";
            this.brisi.Size = new System.Drawing.Size(60, 60);
            this.brisi.Text = "Brisi";
            this.brisi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.brisi.Click += new System.EventHandler(this.brisi_Click);
            // 
            // analiza
            // 
            this.analiza.AutoSize = false;
            this.analiza.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.analiza.Image = ((System.Drawing.Image)(resources.GetObject("analiza.Image")));
            this.analiza.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.analiza.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.analiza.Name = "analiza";
            this.analiza.Size = new System.Drawing.Size(70, 60);
            this.analiza.Text = "Analiza";
            this.analiza.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.analiza.Click += new System.EventHandler(this.analiza_Click);
            // 
            // oaplikaciji
            // 
            this.oaplikaciji.AutoSize = false;
            this.oaplikaciji.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.oaplikaciji.Image = ((System.Drawing.Image)(resources.GetObject("oaplikaciji.Image")));
            this.oaplikaciji.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.oaplikaciji.Name = "oaplikaciji";
            this.oaplikaciji.Size = new System.Drawing.Size(110, 60);
            this.oaplikaciji.Text = "O aplikaciji";
            this.oaplikaciji.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // izlaz
            // 
            this.izlaz.AutoSize = false;
            this.izlaz.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.izlaz.Image = ((System.Drawing.Image)(resources.GetObject("izlaz.Image")));
            this.izlaz.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.izlaz.Name = "izlaz";
            this.izlaz.Size = new System.Drawing.Size(60, 60);
            this.izlaz.Text = "Izlaz";
            this.izlaz.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Brisanje izabranog leka:\r\n";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Naziv leka";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(388, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Proizvodjac";
            // 
            // tbLek
            // 
            this.tbLek.Location = new System.Drawing.Point(169, 165);
            this.tbLek.Name = "tbLek";
            this.tbLek.ReadOnly = true;
            this.tbLek.Size = new System.Drawing.Size(145, 20);
            this.tbLek.TabIndex = 4;
            // 
            // tbProizvodjac
            // 
            this.tbProizvodjac.Location = new System.Drawing.Point(506, 165);
            this.tbProizvodjac.Name = "tbProizvodjac";
            this.tbProizvodjac.ReadOnly = true;
            this.tbProizvodjac.Size = new System.Drawing.Size(145, 20);
            this.tbProizvodjac.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 224);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 214);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tbProizvodjac);
            this.Controls.Add(this.tbLek);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton brisi;
        private System.Windows.Forms.ToolStripButton analiza;
        private System.Windows.Forms.ToolStripButton oaplikaciji;
        private System.Windows.Forms.ToolStripButton izlaz;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbLek;
        private System.Windows.Forms.TextBox tbProizvodjac;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

