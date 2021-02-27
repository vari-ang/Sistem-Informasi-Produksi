namespace SIProduksi
{
    partial class FormUbahBarang
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
            this.buttonUbahData = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.numericUpDownHargaSatuan = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownJumlah = new System.Windows.Forms.NumericUpDown();
            this.textBoxIdOrder = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxKodeBarang = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxKeterangan = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxSatuan = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNama = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonUbah = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonKeluar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHargaSatuan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownJumlah)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonUbahData
            // 
            this.buttonUbahData.BackColor = System.Drawing.Color.Indigo;
            this.buttonUbahData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUbahData.ForeColor = System.Drawing.Color.White;
            this.buttonUbahData.Location = new System.Drawing.Point(84, 669);
            this.buttonUbahData.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonUbahData.Name = "buttonUbahData";
            this.buttonUbahData.Size = new System.Drawing.Size(176, 65);
            this.buttonUbahData.TabIndex = 38;
            this.buttonUbahData.Text = "UBAH";
            this.buttonUbahData.UseVisualStyleBackColor = false;
            this.buttonUbahData.Click += new System.EventHandler(this.buttonUbahData_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.numericUpDownHargaSatuan);
            this.panel1.Controls.Add(this.numericUpDownJumlah);
            this.panel1.Controls.Add(this.textBoxIdOrder);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.comboBoxKodeBarang);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxKeterangan);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBoxSatuan);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxNama);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.buttonUbah);
            this.panel1.Location = new System.Drawing.Point(12, 112);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1094, 527);
            this.panel1.TabIndex = 36;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(858, 239);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(202, 44);
            this.button1.TabIndex = 76;
            this.button1.Text = "Ubah Gambar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(858, 39);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(198, 175);
            this.pictureBox1.TabIndex = 75;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // numericUpDownHargaSatuan
            // 
            this.numericUpDownHargaSatuan.Location = new System.Drawing.Point(278, 313);
            this.numericUpDownHargaSatuan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownHargaSatuan.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numericUpDownHargaSatuan.Name = "numericUpDownHargaSatuan";
            this.numericUpDownHargaSatuan.Size = new System.Drawing.Size(130, 31);
            this.numericUpDownHargaSatuan.TabIndex = 60;
            // 
            // numericUpDownJumlah
            // 
            this.numericUpDownJumlah.Location = new System.Drawing.Point(278, 192);
            this.numericUpDownJumlah.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownJumlah.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownJumlah.Name = "numericUpDownJumlah";
            this.numericUpDownJumlah.Size = new System.Drawing.Size(130, 31);
            this.numericUpDownJumlah.TabIndex = 59;
            // 
            // textBoxIdOrder
            // 
            this.textBoxIdOrder.Location = new System.Drawing.Point(278, 88);
            this.textBoxIdOrder.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxIdOrder.Name = "textBoxIdOrder";
            this.textBoxIdOrder.Size = new System.Drawing.Size(196, 31);
            this.textBoxIdOrder.TabIndex = 58;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(108, 88);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 30);
            this.label7.TabIndex = 57;
            this.label7.Text = "ID Order :";
            // 
            // comboBoxKodeBarang
            // 
            this.comboBoxKodeBarang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKodeBarang.FormattingEnabled = true;
            this.comboBoxKodeBarang.Location = new System.Drawing.Point(278, 33);
            this.comboBoxKodeBarang.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.comboBoxKodeBarang.Name = "comboBoxKodeBarang";
            this.comboBoxKodeBarang.Size = new System.Drawing.Size(238, 33);
            this.comboBoxKodeBarang.TabIndex = 56;
            this.comboBoxKodeBarang.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBoxKodeBarang.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(48, 313);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 30);
            this.label4.TabIndex = 54;
            this.label4.Text = "Harga Satuan :";
            // 
            // textBoxKeterangan
            // 
            this.textBoxKeterangan.Location = new System.Drawing.Point(278, 377);
            this.textBoxKeterangan.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxKeterangan.Multiline = true;
            this.textBoxKeterangan.Name = "textBoxKeterangan";
            this.textBoxKeterangan.Size = new System.Drawing.Size(502, 114);
            this.textBoxKeterangan.TabIndex = 53;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(72, 377);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 30);
            this.label5.TabIndex = 52;
            this.label5.Text = "Keterangan :";
            // 
            // textBoxSatuan
            // 
            this.textBoxSatuan.Location = new System.Drawing.Point(278, 246);
            this.textBoxSatuan.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxSatuan.Name = "textBoxSatuan";
            this.textBoxSatuan.Size = new System.Drawing.Size(344, 31);
            this.textBoxSatuan.TabIndex = 51;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(130, 246);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 30);
            this.label10.TabIndex = 50;
            this.label10.Text = "Satuan :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(136, 192);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 30);
            this.label6.TabIndex = 42;
            this.label6.Text = "Jumlah :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(146, 140);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 30);
            this.label3.TabIndex = 37;
            this.label3.Text = "Nama :";
            // 
            // textBoxNama
            // 
            this.textBoxNama.Location = new System.Drawing.Point(278, 140);
            this.textBoxNama.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxNama.Name = "textBoxNama";
            this.textBoxNama.Size = new System.Drawing.Size(502, 31);
            this.textBoxNama.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 30);
            this.label2.TabIndex = 35;
            this.label2.Text = "Kode Barang :";
            // 
            // buttonUbah
            // 
            this.buttonUbah.BackColor = System.Drawing.Color.Indigo;
            this.buttonUbah.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUbah.ForeColor = System.Drawing.Color.White;
            this.buttonUbah.Location = new System.Drawing.Point(140, 754);
            this.buttonUbah.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonUbah.Name = "buttonUbah";
            this.buttonUbah.Size = new System.Drawing.Size(176, 65);
            this.buttonUbah.TabIndex = 43;
            this.buttonUbah.Text = "UBAH";
            this.buttonUbah.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Indigo;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1122, 75);
            this.label1.TabIndex = 35;
            this.label1.Text = "UBAH BARANG";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.Indigo;
            this.buttonKeluar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeluar.ForeColor = System.Drawing.Color.White;
            this.buttonKeluar.Location = new System.Drawing.Point(870, 669);
            this.buttonKeluar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(176, 65);
            this.buttonKeluar.TabIndex = 37;
            this.buttonKeluar.Text = "KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            this.buttonKeluar.Click += new System.EventHandler(this.buttonKeluar_Click);
            // 
            // FormUbahBarang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 750);
            this.Controls.Add(this.buttonUbahData);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonKeluar);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "FormUbahBarang";
            this.Text = "FormUbahBarang";
            this.Load += new System.EventHandler(this.FormUbahBarang_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHargaSatuan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownJumlah)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonUbahData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxKeterangan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxSatuan;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNama;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonUbah;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.ComboBox comboBoxKodeBarang;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxIdOrder;
        private System.Windows.Forms.NumericUpDown numericUpDownJumlah;
        private System.Windows.Forms.NumericUpDown numericUpDownHargaSatuan;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}