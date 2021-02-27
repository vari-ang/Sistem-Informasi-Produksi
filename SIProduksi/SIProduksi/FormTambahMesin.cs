using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Produksi_LIB;

namespace SIProduksi
{
    public partial class FormTambahMesin : Form
    {
        FormDaftarMesin frmDaftar;
        public FormTambahMesin()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxNama.Text = "";
            textBoxIdMesin.Text = "";
            textBoxHarga.Text = "";

        }

        private void FormTambahMesin_Load(object sender, EventArgs e)
        {
            frmDaftar = (FormDaftarMesin)this.Owner;

            string idTerbaru;
            string hasilGenerate = Mesin.GenerateCode(out idTerbaru);

            if (hasilGenerate == "1")
            {
                textBoxIdMesin.Text = idTerbaru;

                // buat agar textBoxIdJabatan tidak bisa diakses
                textBoxIdMesin.Enabled = false;

                // arahkan cursor ke textBoxNamaKategori
                textBoxNama.Focus();
            }
            else
            {
                MessageBox.Show("Gagal melakukan generate code. Pesan kesalahan: " + hasilGenerate);
            }
            
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                // Ciptakan objek yg akan ditambahkan
                Mesin j = new Mesin(textBoxIdMesin.Text, textBoxNama.Text, int.Parse(textBoxHarga.Text));

                // Panggil static method TambahData di class kategori
                string hasilTambah = Mesin.TambahData(j);

                if (hasilTambah == "1")
                {
                    if (pictureBoxGambar.BackgroundImage != null)
                    {
                        pictureBoxGambar.BackgroundImage.Save(Application.StartupPath + "\\Images\\Mesin\\" + textBoxIdMesin.Text + ".jpg");
                    }
                    MessageBox.Show("Mesin telah tersimpan.", "Informasi");

                    buttonKosongi_Click(sender, e);
                    frmDaftar.FormDaftarMesin_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Gagal menambah Mesin. Pesan kesalahan: " + hasilTambah);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opnfd = new OpenFileDialog();
                opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
                if (opnfd.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxGambar.BackgroundImage = new Bitmap(opnfd.FileName);

                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void pictureBoxGambar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opnfd = new OpenFileDialog();
                opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
                if (opnfd.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxGambar.BackgroundImage = new Bitmap(opnfd.FileName);

                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        
    }
}
