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
    public partial class FormUbahProgress : Form
    {
        List<ProgresProduksi> ListDaftarProgress = new List<ProgresProduksi>();
        List<Mesin> listaftarmesin = new List<Mesin>();
        List<Spk> listaftarspk = new List<Spk>();
        List<Pekerja> listdaftarpekerja = new List<Pekerja>();
        public FormUbahProgress()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormUbahProgress_Load(object sender, EventArgs e)
        {
            ListDaftarProgress.Clear();
            listaftarmesin.Clear();
            listaftarspk.Clear();
            listdaftarpekerja.Clear();
            string hasil = ProgresProduksi.BacaData("", "", ListDaftarProgress);
            if (hasil == "1")
            {
                comboBoxNoDokumen.Items.Clear();
                int hasilcount = ListDaftarProgress.Count;
                for (int i = 0; i < ListDaftarProgress.Count; i++)
                {
                    comboBoxNoDokumen.Items.Add(ListDaftarProgress[i].NomorDokumen);
                }

            }          
        }

        private void comboBoxNoDokumen_SelectedIndexChanged(object sender, EventArgs e)
        {
            string hasilBaca = ProgresProduksi.BacaData("pk.nomer_dokumen", comboBoxNoDokumen.Text, ListDaftarProgress);

            if (hasilBaca == "1")
            {
                if (ListDaftarProgress.Count > 0)
                {
                    comboBoxStatus.Text = ListDaftarProgress[0].Status;

                }
                else
                {
                    MessageBox.Show("Dokumen tidak ditemukan. Proses Ubah Data tidak bisa dilakukan.");
                    
                }
            }
            else
            {
                MessageBox.Show("Perintah SQL gagal dijalankan. Pesan kesalahan = " + hasilBaca);
            }
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                ProgresProduksi pp = new ProgresProduksi(comboBoxNoDokumen.Text, comboBoxStatus.Text);

                string hasil = ProgresProduksi.UbahData(pp);
                if (hasil == "1")
                {
                    MessageBox.Show("Data Berhasil diubah");
                    FormDaftarProgress frm = new FormDaftarProgress();
                    frm.FormDaftarProgress_Load(sender, e);
                    buttonKosongi_Click(sender,e);
                }
                else
                {
                    MessageBox.Show("Error : " + hasil);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hasil : " + ex);
            }
            
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
           
        }
    }
}
