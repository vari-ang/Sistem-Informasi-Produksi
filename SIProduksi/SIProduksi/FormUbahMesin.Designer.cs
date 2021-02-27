namespace SIProduksi
{
    partial class FormUbahMesin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxidMesin = new System.Windows.Forms.ComboBox();
            this.textBoxHarga = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNama = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonKeluar = new System.Windows.Forms.Button();
            this.buttonKosongi = new System.Windows.Forms.Button();
            this.buttonSimpan = new System.Windows.Forms.Button();
            this.buttonUbahFoto = new System.Windows.Forms.Button();
            this.pictureBoxGambar = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGambar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.buttonUbahFoto);
            this.panel1.Controls.Add(this.comboBoxidMesin);
            this.panel1.Controls.Add(this.pictureBoxGambar);
            this.panel1.Controls.Add(this.textBoxHarga);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxNama);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(24, 102);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1150, 515);
            this.panel1.TabIndex = 30;
            // 
            // comboBoxidMesin
            // 
            this.comboBoxidMesin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxidMesin.FormattingEnabled = true;
            this.comboBoxidMesin.Location = new System.Drawing.Point(316, 42);
            this.comboBoxidMesin.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.comboBoxidMesin.Name = "comboBoxidMesin";
            this.comboBoxidMesin.Size = new System.Drawing.Size(238, 33);
            this.comboBoxidMesin.TabIndex = 8;
            this.comboBoxidMesin.SelectedIndexChanged += new System.EventHandler(this.comboBoxidMesin_SelectedIndexChanged);
            // 
            // textBoxHarga
            // 
            this.textBoxHarga.Location = new System.Drawing.Point(314, 437);
            this.textBoxHarga.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxHarga.Name = "textBoxHarga";
            this.textBoxHarga.Size = new System.Drawing.Size(502, 31);
            this.textBoxHarga.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(188, 437);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 30);
            this.label4.TabIndex = 5;
            this.label4.Text = "Harga :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(200, 92);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 30);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nama :";
            // 
            // textBoxNama
            // 
            this.textBoxNama.Location = new System.Drawing.Point(316, 94);
            this.textBoxNama.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxNama.Name = "textBoxNama";
            this.textBoxNama.Size = new System.Drawing.Size(502, 31);
            this.textBoxNama.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(250, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "Id :";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Indigo;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(2, -2);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1190, 75);
            this.label1.TabIndex = 29;
            this.label1.Text = "UBAH MESIN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.BackColor = System.Drawing.Color.Indigo;
            this.buttonKeluar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeluar.ForeColor = System.Drawing.Color.White;
            this.buttonKeluar.Location = new System.Drawing.Point(953, 652);
            this.buttonKeluar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(176, 65);
            this.buttonKeluar.TabIndex = 33;
            this.buttonKeluar.Text = "KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = false;
            this.buttonKeluar.Click += new System.EventHandler(this.buttonKeluar_Click);
            // 
            // buttonKosongi
            // 
            this.buttonKosongi.BackColor = System.Drawing.Color.Indigo;
            this.buttonKosongi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKosongi.ForeColor = System.Drawing.Color.White;
            this.buttonKosongi.Location = new System.Drawing.Point(337, 652);
            this.buttonKosongi.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonKosongi.Name = "buttonKosongi";
            this.buttonKosongi.Size = new System.Drawing.Size(176, 65);
            this.buttonKosongi.TabIndex = 32;
            this.buttonKosongi.Text = "KOSONGI";
            this.buttonKosongi.UseVisualStyleBackColor = false;
            this.buttonKosongi.Click += new System.EventHandler(this.buttonKosongi_Click);
            // 
            // buttonSimpan
            // 
            this.buttonSimpan.BackColor = System.Drawing.Color.Indigo;
            this.buttonSimpan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSimpan.ForeColor = System.Drawing.Color.White;
            this.buttonSimpan.Location = new System.Drawing.Point(127, 652);
            this.buttonSimpan.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonSimpan.Name = "buttonSimpan";
            this.buttonSimpan.Size = new System.Drawing.Size(176, 65);
            this.buttonSimpan.TabIndex = 31;
            this.buttonSimpan.Text = "UBAH";
            this.buttonSimpan.UseVisualStyleBackColor = false;
            this.buttonSimpan.Click += new System.EventHandler(this.buttonSimpan_Click);
            // 
            // buttonUbahFoto
            // 
            this.buttonUbahFoto.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.buttonUbahFoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUbahFoto.ForeColor = System.Drawing.Color.White;
            this.buttonUbahFoto.Location = new System.Drawing.Point(572, 243);
            this.buttonUbahFoto.Margin = new System.Windows.Forms.Padding(6);
            this.buttonUbahFoto.Name = "buttonUbahFoto";
            this.buttonUbahFoto.Size = new System.Drawing.Size(176, 81);
            this.buttonUbahFoto.TabIndex = 90;
            this.buttonUbahFoto.Text = "Ubah Foto";
            this.buttonUbahFoto.UseVisualStyleBackColor = false;
            this.buttonUbahFoto.Click += new System.EventHandler(this.buttonUbahFoto_Click);
            // 
            // pictureBoxGambar
            // 
            this.pictureBoxGambar.BackColor = System.Drawing.Color.LightGray;
            this.pictureBoxGambar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxGambar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxGambar.Location = new System.Drawing.Point(314, 153);
            this.pictureBoxGambar.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBoxGambar.Name = "pictureBoxGambar";
            this.pictureBoxGambar.Size = new System.Drawing.Size(244, 244);
            this.pictureBoxGambar.TabIndex = 89;
            this.pictureBoxGambar.TabStop = false;
            this.pictureBoxGambar.Click += new System.EventHandler(this.pictureBoxGambar_Click);
            // 
            // FormUbahMesin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 747);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.buttonKosongi);
            this.Controls.Add(this.buttonSimpan);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "FormUbahMesin";
            this.Text = "FormUbahMesin";
            this.Load += new System.EventHandler(this.FormUbahMesin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGambar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxHarga;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNama;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.Button buttonKosongi;
        private System.Windows.Forms.Button buttonSimpan;
        private System.Windows.Forms.ComboBox comboBoxidMesin;
        private System.Windows.Forms.Button buttonUbahFoto;
        private System.Windows.Forms.PictureBox pictureBoxGambar;
    }
}