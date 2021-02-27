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
    public partial class FormHapusPengiriman : Form
    {
        public FormHapusPengiriman()
        {
            InitializeComponent();
        }

        FormDaftarPengiriman frmDaftar;
        List<Pengiriman> listHasilData = new List<Pengiriman>();

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxNomerDokumen.Text = "";
            textBoxTanggal.Text = "";
            textBoxSPK.Text = "";

        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            // Pastikan dulu kepada user apakah akan menghapus data
            DialogResult konfirmasi = MessageBox.Show("Data Pengiriman akan terhapus. Apakah Anda yakin ? ", "Konfirmasi", MessageBoxButtons.YesNo);

            if (konfirmasi == System.Windows.Forms.DialogResult.Yes) // Jika user yakin menghapus data
            {
                Spk s = new Spk();
                s.NoSPK = textBoxSPK.Text;


                Pengiriman P = new Pengiriman(textBoxNomerDokumen.Text, s, DateTime.Now);

                // Panggil static method HapusData di class kategori
                string hasilHapus = Pengiriman.HapusData(P);

                if (hasilHapus == "1")
                {
                    MessageBox.Show("Data Pengiriman telah dihapus.", "Informasi");

                    buttonKosongi_Click(sender, e);
                    frmDaftar.FormDaftarPengiriman_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Gagal menghapus pelanggan. Pesan kesalahan : " + hasilHapus);
                }
            }
        }

        private void FormHapusPengiriman_Load(object sender, EventArgs e)
        {
            frmDaftar = (FormDaftarPengiriman)this.Owner;
            textBoxSPK.Enabled = false;
            textBoxTanggal.Enabled = false;

        }

        private void textBoxNomerDokumen_TextChanged(object sender, EventArgs e)
        {
            listHasilData.Clear();

            string hasilBaca = Pengiriman.BacaData("P.nomor_dokumen", textBoxNomerDokumen.Text, listHasilData);
            if (hasilBaca == "1")
            {
                if (listHasilData.Count > 0)
                {
                    textBoxSPK.Text = listHasilData[0].NomorSPK.NoSPK;
                    textBoxTanggal.Text = listHasilData[0].TanggalKirim.ToString();
                }
            }
            else
            {
                textBoxSPK.Text = "";
                textBoxTanggal.Text = "";
            }

        }
    }
}
