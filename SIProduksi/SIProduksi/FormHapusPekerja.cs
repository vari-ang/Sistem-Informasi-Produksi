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
    public partial class FormHapusPekerja : Form
    {
        FormDaftarPekerja frmDaftar;
        private List<Pekerja> listHasilData = new List<Pekerja>();

        public FormHapusPekerja()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormHapusPekerja_Load(object sender, EventArgs e)
        {
            frmDaftar = (FormDaftarPekerja)this.Owner;

            textBoxIdPekerja.Enabled = true;
            textBoxNama.Enabled = false;
            textBoxNomerHp.Enabled = false;
            textBoxAlamat.Enabled = false;
            textBoxJabatan.Enabled = false;
        }

        private void textBoxIdPekerja_TextChanged(object sender, EventArgs e)
        {
            listHasilData.Clear();

            string hasilBaca = Pekerja.BacaData("P.Id", textBoxIdPekerja.Text, listHasilData);
            if (hasilBaca == "1")
            {
                if (listHasilData.Count > 0)
                {
                    if (File.Exists(Application.StartupPath + "\\Images\\Pekerja\\" + textBoxIdPekerja.Text + ".jpg"))
                    {
                        pictureBoxGambar.BackgroundImage = new Bitmap(Application.StartupPath + "\\Images\\Pekerja\\" + textBoxIdPekerja.Text + ".jpg");
                    }
                    textBoxNama.Text = listHasilData[0].Nama;
                    textBoxAlamat.Text = listHasilData[0].Alamat;
                    textBoxNomerHp.Text = listHasilData[0].NomerHp;
               
                    textBoxJabatan.Text = listHasilData[0].Jabatan.IdJabatan + " - " + listHasilData[0].Jabatan.NamaJabatan;
                    textBoxNama.Focus();
                }
            }
            else
            {
                textBoxNama.Text = "";
                textBoxAlamat.Text = "";
                textBoxNomerHp.Text = "";
            }
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            // Pastikan dulu kepada user apakah akan menghapus data
            DialogResult konfirmasi = MessageBox.Show("Data pekerja akan terhapus. Apakah Anda yakin ? ", "Konfirmasi", MessageBoxButtons.YesNo);

            if (konfirmasi == System.Windows.Forms.DialogResult.Yes) // Jika user yakin menghapus data
            {
                try
                {
                    string idJabatan = textBoxJabatan.Text.Substring(1, 2);
                    string namaJabatan = textBoxJabatan.Text.Substring(6, textBoxJabatan.Text.Length - 6);

                    Jabatan jabatan = new Jabatan(idJabatan, namaJabatan);

                    Pekerja p = new Pekerja(int.Parse(textBoxIdPekerja.Text), textBoxNama.Text, textBoxAlamat.Text,
                        textBoxNomerHp.Text, jabatan, "", "");

                    // Panggil static method HapusData di class kategori
                    string hasilHapus = Pekerja.HapusData(p);

                    if (hasilHapus == "1")
                    {
                        MessageBox.Show("Pekerja telah dihapus.", "Informasi");
                        pictureBoxGambar.BackgroundImage = null;
                        buttonKosongi_Click(sender, e);
                        frmDaftar.FormDaftarPekerja_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Gagal menghapus pegawai. Pesan kesalahan : " + hasilHapus);
                    }
                }
                catch(Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }               
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            pictureBoxGambar.BackgroundImage = null;
            textBoxIdPekerja.Text = "";
            textBoxNama.Text = "";
            textBoxNomerHp.Text = "";
            textBoxAlamat.Text = "";
            textBoxJabatan.Text = "";
        }

        private void pictureBoxGambar_Click(object sender, EventArgs e)
        {

        }
    }
}
