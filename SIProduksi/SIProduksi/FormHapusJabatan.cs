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
    public partial class FormHapusJabatan : Form
    {
        FormDaftarJabatan frmDaftar;
        private List<Jabatan> listHasilData = new List<Jabatan>();

        public FormHapusJabatan()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormHapusJabatan_Load(object sender, EventArgs e)
        {
            frmDaftar = (FormDaftarJabatan)this.Owner;

            textBoxNamaJabatan.Enabled = false;
            textBoxIdJabatan.MaxLength = 2;
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            // Pastikan dulu kepada user apakah akan menghapus data
            DialogResult konfirmasi = MessageBox.Show("Data jabatan akan terhapus. Apakah Anda yakin ? ", "Konfirmasi", MessageBoxButtons.YesNo);

            if (konfirmasi == System.Windows.Forms.DialogResult.Yes) // Jika user yakin menghapus data
            {
                try
                {
                    // Ciptakan objek yg akan dihapus
                    Jabatan j = new Jabatan(textBoxIdJabatan.Text, textBoxNamaJabatan.Text);

                    // Panggil static method HapusData di class kategori
                    string hasilHapus = Jabatan.HapusData(j);

                    if (hasilHapus == "1")
                    {
                        MessageBox.Show("Jabatan telah dihapus.", "Informasi");

                        buttonKosongi_Click(sender, e);
                        frmDaftar.FormDaftarJabatan_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Gagal menghapus jabatan. Pesan kesalahan : " + hasilHapus);
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
            textBoxIdJabatan.Text = "";
            textBoxNamaJabatan.Text = "";
        }

        private void textBoxIdJabatan_TextChanged(object sender, EventArgs e)
        {
            // Jika user telah mengetik sesuai panjang karakter KodeKategori
            if (textBoxIdJabatan.Text.Length == textBoxIdJabatan.MaxLength)
            {
                listHasilData.Clear();

                // Cari nama kategori sesuai kode kategori yang diinputkan user
                string hasilBaca = Jabatan.BacaData("Id", textBoxIdJabatan.Text, listHasilData);

                if (hasilBaca == "1")
                {
                    // Jika kode kategori di database (jumlah data list hasil pembacaan lebih dari nol)
                    if (listHasilData.Count > 0)
                    {
                        textBoxNamaJabatan.Text = listHasilData[0].NamaJabatan;
                        textBoxNamaJabatan.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Id Jabatan tidak ditemukan. Proses Hapus Data tidak bisa dilakukan.");
                        textBoxNamaJabatan.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Perintah SQL gagal dijalankan. Pesan kesalahan = " + hasilBaca);
                }
            }
        }
    }
}
