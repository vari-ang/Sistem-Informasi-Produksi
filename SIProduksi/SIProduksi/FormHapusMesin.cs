using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Produksi_LIB;

namespace SIProduksi
{
    public partial class FormHapusMesin : Form
    {
        FormDaftarMesin frmDaftar;
        private List<Mesin> listHasilData = new List<Mesin>();
        public FormHapusMesin()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult konfirmasi = MessageBox.Show("Data Mesin akan terhapus. Apakah Anda yakin ? ", "Konfirmasi", MessageBoxButtons.YesNo);

                if (konfirmasi == System.Windows.Forms.DialogResult.Yes) // Jika user yakin menghapus data
                {
                    // Ciptakan objek yg akan dihapus
                    Mesin j = new Mesin(textBoxIdMesin.Text, textBoxNama.Text, int.Parse(textBoxHarga.Text));

                    // Panggil static method HapusData di class kategori
                    string hasilHapus = Mesin.HapusData(j);

                    if (hasilHapus == "1")
                    {
                        MessageBox.Show("Mesin telah dihapus.", "Informasi");

                        buttonKosongi_Click(sender, e);
                        frmDaftar.FormDaftarMesin_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Gagal menghapus jabatan. Pesan kesalahan : " + hasilHapus);
                    }
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void textBoxIdMesin_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBoxIdMesin.TextLength == 2)
                {
                    listHasilData.Clear();

                    string hasilBaca = Mesin.BacaData("Id", textBoxIdMesin.Text, listHasilData);

                    if (hasilBaca == "1")
                    {

                        if (listHasilData.Count > 0)
                        {
                            textBoxNama.Text = listHasilData[0].Nama;
                            if (File.Exists(Application.StartupPath + "\\Images\\Mesin\\" + textBoxIdMesin.Text + ".jpg"))
                            {
                                pictureBoxGambar.BackgroundImage = new Bitmap(Application.StartupPath + "\\Images\\Mesin\\" + textBoxIdMesin.Text + ".jpg");
                            }
                            textBoxHarga.Text = listHasilData[0].HargaBeli.ToString();
                            textBoxIdMesin.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Id Mesin tidak ditemukan. Proses Ubah Data tidak bisa dilakukan.");
                            textBoxNama.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Perintah SQL gagal dijalankan. Pesan kesalahan = " + hasilBaca);
                    }
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxHarga.Text = "";
            textBoxIdMesin.Text = "";
            textBoxNama.Text = "";
        }

        private void FormHapusMesin_Load(object sender, EventArgs e)
        {
            frmDaftar = (FormDaftarMesin)this.Owner;

            textBoxNama.Enabled = false;
            textBoxHarga.Enabled = false;
        }
    }
}
