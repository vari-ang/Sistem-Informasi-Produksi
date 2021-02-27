namespace SIProduksi
{
    partial class FormPemesananBahanBaku
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
            this.buttonKeluar = new System.Windows.Forms.Button();
            this.buttonBuat = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelHarga = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxKode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxID = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxjenis = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxharga = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxjumlah = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxsub = new System.Windows.Forms.TextBox();
            this.richTextBoxkete = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonTambahBarang = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewBarang = new System.Windows.Forms.DataGridView();
            this.comboBoxNomorSPK = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBarang)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.Indigo;
            this.buttonKeluar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeluar.ForeColor = System.Drawing.Color.White;
            this.buttonKeluar.Location = new System.Drawing.Point(429, 443);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(134, 34);
            this.buttonKeluar.TabIndex = 40;
            this.buttonKeluar.Text = "KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            this.buttonKeluar.Click += new System.EventHandler(this.buttonKeluar_Click);
            // 
            // buttonBuat
            // 
            this.buttonBuat.BackColor = System.Drawing.Color.Indigo;
            this.buttonBuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBuat.ForeColor = System.Drawing.Color.White;
            this.buttonBuat.Location = new System.Drawing.Point(25, 443);
            this.buttonBuat.Name = "buttonBuat";
            this.buttonBuat.Size = new System.Drawing.Size(134, 34);
            this.buttonBuat.TabIndex = 39;
            this.buttonBuat.Text = "SIMPAN";
            this.buttonBuat.UseVisualStyleBackColor = false;
            this.buttonBuat.Click += new System.EventHandler(this.buttonBuat_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.labelHarga);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.comboBoxNomorSPK);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxKode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(25, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(538, 370);
            this.panel1.TabIndex = 38;
            // 
            // labelHarga
            // 
            this.labelHarga.AutoSize = true;
            this.labelHarga.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHarga.Location = new System.Drawing.Point(359, 46);
            this.labelHarga.Name = "labelHarga";
            this.labelHarga.Size = new System.Drawing.Size(0, 20);
            this.labelHarga.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nomor SPK :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Kode :";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Indigo;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(566, 39);
            this.label1.TabIndex = 37;
            this.label1.Text = "Tambah Pemesanan Bahan Baku";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxKode
            // 
            this.textBoxKode.Location = new System.Drawing.Point(127, 20);
            this.textBoxKode.Name = "textBoxKode";
            this.textBoxKode.Size = new System.Drawing.Size(121, 20);
            this.textBoxKode.TabIndex = 4;
            this.textBoxKode.TextChanged += new System.EventHandler(this.textBoxKode_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(264, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 16);
            this.label10.TabIndex = 13;
            this.label10.Text = "Total Harga :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(85, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Id Bahan Baku :";
            // 
            // comboBoxID
            // 
            this.comboBoxID.FormattingEnabled = true;
            this.comboBoxID.Location = new System.Drawing.Point(207, 16);
            this.comboBoxID.Name = "comboBoxID";
            this.comboBoxID.Size = new System.Drawing.Size(121, 21);
            this.comboBoxID.TabIndex = 23;
            this.comboBoxID.SelectedIndexChanged += new System.EventHandler(this.comboBoxID_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = "Jenis :";
            // 
            // textBoxjenis
            // 
            this.textBoxjenis.Location = new System.Drawing.Point(71, 54);
            this.textBoxjenis.Name = "textBoxjenis";
            this.textBoxjenis.Size = new System.Drawing.Size(135, 20);
            this.textBoxjenis.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(234, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 16);
            this.label6.TabIndex = 26;
            this.label6.Text = "Harga Satuan :";
            // 
            // textBoxharga
            // 
            this.textBoxharga.Location = new System.Drawing.Point(351, 52);
            this.textBoxharga.Name = "textBoxharga";
            this.textBoxharga.Size = new System.Drawing.Size(135, 20);
            this.textBoxharga.TabIndex = 27;
            this.textBoxharga.TextChanged += new System.EventHandler(this.textBoxharga_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(2, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 16);
            this.label7.TabIndex = 28;
            this.label7.Text = "Jumlah :";
            // 
            // textBoxjumlah
            // 
            this.textBoxjumlah.Location = new System.Drawing.Point(71, 80);
            this.textBoxjumlah.Name = "textBoxjumlah";
            this.textBoxjumlah.Size = new System.Drawing.Size(135, 20);
            this.textBoxjumlah.TabIndex = 29;
            this.textBoxjumlah.TextChanged += new System.EventHandler(this.textBoxjumlah_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(262, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 16);
            this.label8.TabIndex = 30;
            this.label8.Text = "Sub Total :";
            // 
            // textBoxsub
            // 
            this.textBoxsub.Enabled = false;
            this.textBoxsub.Location = new System.Drawing.Point(351, 78);
            this.textBoxsub.Name = "textBoxsub";
            this.textBoxsub.Size = new System.Drawing.Size(135, 20);
            this.textBoxsub.TabIndex = 31;
            // 
            // richTextBoxkete
            // 
            this.richTextBoxkete.Location = new System.Drawing.Point(98, 106);
            this.richTextBoxkete.Name = "richTextBoxkete";
            this.richTextBoxkete.Size = new System.Drawing.Size(247, 48);
            this.richTextBoxkete.TabIndex = 32;
            this.richTextBoxkete.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(-3, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 16);
            this.label9.TabIndex = 33;
            this.label9.Text = "Keterangan :";
            // 
            // buttonTambahBarang
            // 
            this.buttonTambahBarang.BackColor = System.Drawing.Color.Indigo;
            this.buttonTambahBarang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTambahBarang.ForeColor = System.Drawing.Color.White;
            this.buttonTambahBarang.Location = new System.Drawing.Point(377, 105);
            this.buttonTambahBarang.Name = "buttonTambahBarang";
            this.buttonTambahBarang.Size = new System.Drawing.Size(109, 49);
            this.buttonTambahBarang.TabIndex = 35;
            this.buttonTambahBarang.Text = "TAMBAH PESANAN";
            this.buttonTambahBarang.UseVisualStyleBackColor = false;
            this.buttonTambahBarang.Click += new System.EventHandler(this.buttonTambahBarang_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonTambahBarang);
            this.groupBox1.Controls.Add(this.dataGridViewBarang);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.richTextBoxkete);
            this.groupBox1.Controls.Add(this.textBoxsub);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBoxjumlah);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBoxharga);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxjenis);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboBoxID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(3, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(532, 276);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BahanBaku";
            // 
            // dataGridViewBarang
            // 
            this.dataGridViewBarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBarang.Location = new System.Drawing.Point(0, 160);
            this.dataGridViewBarang.Name = "dataGridViewBarang";
            this.dataGridViewBarang.Size = new System.Drawing.Size(526, 112);
            this.dataGridViewBarang.TabIndex = 34;
            // 
            // comboBoxNomorSPK
            // 
            this.comboBoxNomorSPK.FormattingEnabled = true;
            this.comboBoxNomorSPK.Location = new System.Drawing.Point(127, 46);
            this.comboBoxNomorSPK.Name = "comboBoxNomorSPK";
            this.comboBoxNomorSPK.Size = new System.Drawing.Size(121, 21);
            this.comboBoxNomorSPK.TabIndex = 11;
            this.comboBoxNomorSPK.SelectedIndexChanged += new System.EventHandler(this.comboBoxNomorSPK_SelectedIndexChanged);
            // 
            // FormPemesananBahanBaku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 483);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.buttonBuat);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "FormPemesananBahanBaku";
            this.Text = "FormPemesananBahanBaku";
            this.Load += new System.EventHandler(this.FormPemesananBahanBaku_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBarang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.Button buttonBuat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelHarga;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonTambahBarang;
        private System.Windows.Forms.DataGridView dataGridViewBarang;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox richTextBoxkete;
        private System.Windows.Forms.TextBox textBoxsub;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxjumlah;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxharga;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxjenis;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxKode;
        private System.Windows.Forms.ComboBox comboBoxNomorSPK;
    }
}