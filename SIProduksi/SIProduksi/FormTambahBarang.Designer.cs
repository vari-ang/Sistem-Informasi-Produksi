namespace SIProduksi
{
    partial class FormTambahBarang
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
            this.comboBoxPO = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownHargaSatuan = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownJumlah = new System.Windows.Forms.NumericUpDown();
            this.buttonTambahBarang = new System.Windows.Forms.Button();
            this.richTextBoxKeterangan = new System.Windows.Forms.RichTextBox();
            this.textBoxSatuanBarang = new System.Windows.Forms.TextBox();
            this.textBoxNamaBarang = new System.Windows.Forms.TextBox();
            this.textBoxKodeBarang = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBoxGambar = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonKeluar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHargaSatuan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownJumlah)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGambar)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxPO
            // 
            this.comboBoxPO.FormattingEnabled = true;
            this.comboBoxPO.Location = new System.Drawing.Point(166, 146);
            this.comboBoxPO.Name = "comboBoxPO";
            this.comboBoxPO.Size = new System.Drawing.Size(112, 21);
            this.comboBoxPO.TabIndex = 84;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(170, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 16);
            this.label3.TabIndex = 81;
            this.label3.Text = "(Boleh Kosong)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(97, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 80;
            this.label2.Text = "Id PO  :";
            // 
            // numericUpDownHargaSatuan
            // 
            this.numericUpDownHargaSatuan.Location = new System.Drawing.Point(166, 119);
            this.numericUpDownHargaSatuan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDownHargaSatuan.Maximum = new decimal(new int[] {
            1661992960,
            1808227885,
            5,
            0});
            this.numericUpDownHargaSatuan.Name = "numericUpDownHargaSatuan";
            this.numericUpDownHargaSatuan.Size = new System.Drawing.Size(110, 20);
            this.numericUpDownHargaSatuan.TabIndex = 79;
            // 
            // numericUpDownJumlah
            // 
            this.numericUpDownJumlah.Location = new System.Drawing.Point(166, 67);
            this.numericUpDownJumlah.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDownJumlah.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownJumlah.Name = "numericUpDownJumlah";
            this.numericUpDownJumlah.Size = new System.Drawing.Size(110, 20);
            this.numericUpDownJumlah.TabIndex = 78;
            // 
            // buttonTambahBarang
            // 
            this.buttonTambahBarang.BackColor = System.Drawing.Color.Indigo;
            this.buttonTambahBarang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTambahBarang.ForeColor = System.Drawing.Color.White;
            this.buttonTambahBarang.Location = new System.Drawing.Point(46, 376);
            this.buttonTambahBarang.Name = "buttonTambahBarang";
            this.buttonTambahBarang.Size = new System.Drawing.Size(88, 35);
            this.buttonTambahBarang.TabIndex = 71;
            this.buttonTambahBarang.Text = "TAMBAH";
            this.buttonTambahBarang.UseVisualStyleBackColor = false;
            this.buttonTambahBarang.Click += new System.EventHandler(this.buttonTambahBarang_Click);
            // 
            // richTextBoxKeterangan
            // 
            this.richTextBoxKeterangan.Location = new System.Drawing.Point(72, 225);
            this.richTextBoxKeterangan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBoxKeterangan.Name = "richTextBoxKeterangan";
            this.richTextBoxKeterangan.Size = new System.Drawing.Size(272, 56);
            this.richTextBoxKeterangan.TabIndex = 77;
            this.richTextBoxKeterangan.Text = "";
            // 
            // textBoxSatuanBarang
            // 
            this.textBoxSatuanBarang.Location = new System.Drawing.Point(166, 96);
            this.textBoxSatuanBarang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxSatuanBarang.Name = "textBoxSatuanBarang";
            this.textBoxSatuanBarang.Size = new System.Drawing.Size(112, 20);
            this.textBoxSatuanBarang.TabIndex = 76;
            // 
            // textBoxNamaBarang
            // 
            this.textBoxNamaBarang.Location = new System.Drawing.Point(166, 43);
            this.textBoxNamaBarang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxNamaBarang.Name = "textBoxNamaBarang";
            this.textBoxNamaBarang.Size = new System.Drawing.Size(112, 20);
            this.textBoxNamaBarang.TabIndex = 75;
            // 
            // textBoxKodeBarang
            // 
            this.textBoxKodeBarang.Location = new System.Drawing.Point(166, 17);
            this.textBoxKodeBarang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxKodeBarang.Name = "textBoxKodeBarang";
            this.textBoxKodeBarang.Size = new System.Drawing.Size(112, 20);
            this.textBoxKodeBarang.TabIndex = 74;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(51, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 16);
            this.label4.TabIndex = 73;
            this.label4.Text = "Harga Satuan :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(105, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 68;
            this.label5.Text = "Kode :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(100, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 16);
            this.label8.TabIndex = 69;
            this.label8.Text = "Nama :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(92, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 16);
            this.label10.TabIndex = 72;
            this.label10.Text = "Jumlah :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(94, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 70;
            this.label9.Text = "Satuan :";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Indigo;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(574, 39);
            this.label1.TabIndex = 67;
            this.label1.Text = "TAMBAH BARANG";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Lavender;
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.pictureBoxGambar);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.richTextBoxKeterangan);
            this.groupBox1.Controls.Add(this.comboBoxPO);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxKodeBarang);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxNamaBarang);
            this.groupBox1.Controls.Add(this.numericUpDownHargaSatuan);
            this.groupBox1.Controls.Add(this.textBoxSatuanBarang);
            this.groupBox1.Controls.Add(this.numericUpDownJumlah);
            this.groupBox1.Location = new System.Drawing.Point(14, 47);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(548, 311);
            this.groupBox1.TabIndex = 86;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(61, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 16);
            this.label6.TabIndex = 87;
            this.label6.Text = "Keterangan  :";
            // 
            // pictureBoxGambar
            // 
            this.pictureBoxGambar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxGambar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxGambar.Location = new System.Drawing.Point(340, 27);
            this.pictureBoxGambar.Name = "pictureBoxGambar";
            this.pictureBoxGambar.Size = new System.Drawing.Size(100, 92);
            this.pictureBoxGambar.TabIndex = 86;
            this.pictureBoxGambar.TabStop = false;
            this.pictureBoxGambar.Click += new System.EventHandler(this.pictureBoxGambar_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(340, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 85;
            this.button1.Text = "Tambah Gambar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.Indigo;
            this.buttonKeluar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeluar.ForeColor = System.Drawing.Color.White;
            this.buttonKeluar.Location = new System.Drawing.Point(434, 377);
            this.buttonKeluar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(88, 34);
            this.buttonKeluar.TabIndex = 88;
            this.buttonKeluar.Text = "KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            this.buttonKeluar.Click += new System.EventHandler(this.buttonKeluar_Click);
            // 
            // FormTambahBarang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(573, 404);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonTambahBarang);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormTambahBarang";
            this.Text = "FormTambahBarang";
            this.Load += new System.EventHandler(this.FormTambahBarang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHargaSatuan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownJumlah)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGambar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxPO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownHargaSatuan;
        private System.Windows.Forms.NumericUpDown numericUpDownJumlah;
        private System.Windows.Forms.Button buttonTambahBarang;
        private System.Windows.Forms.RichTextBox richTextBoxKeterangan;
        private System.Windows.Forms.TextBox textBoxSatuanBarang;
        private System.Windows.Forms.TextBox textBoxNamaBarang;
        private System.Windows.Forms.TextBox textBoxKodeBarang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBoxGambar;
        private System.Windows.Forms.Button buttonKeluar;
    }
}