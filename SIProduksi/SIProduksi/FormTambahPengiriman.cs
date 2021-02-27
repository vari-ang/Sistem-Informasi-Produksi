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
    public partial class FormTambahPengiriman : Form
    {
        public FormTambahPengiriman()
        {
            InitializeComponent();
        }
        public List<Spk> listDataSPK = new List<Spk>();

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxNomerDokumen.Text = "";
        }

        private void buttonBuat_Click(object sender, EventArgs e)
        {
            int indexDipilihUser = comboBoxSPK.SelectedIndex;
            Spk s = listDataSPK[indexDipilihUser];

            Pengiriman p = new Pengiriman(textBoxNomerDokumen.Text, s, dateTimePickerTanggal.Value);

            string hasilTambah = Pengiriman.TambahData(p);

            if (hasilTambah == "1")
            {
                MessageBox.Show("Pengiriman telah tersimpan.", "Informasi");

                buttonKosongi_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Gagal menambah jabatan. Pesan kesalahan: " + hasilTambah);
            }
        }

        private void FormPengiriman_Load(object sender, EventArgs e)
        {
            listDataSPK.Clear();
            string hasilBaca = Spk.BacaData("", "", listDataSPK);

            if (hasilBaca == "1")
            {
                comboBoxSPK.Items.Clear();
                for (int i = 0; i < listDataSPK.Count; i++)
                {
                    comboBoxSPK.Items.Add(listDataSPK[i].NoSPK);
                }
            }
            else
            {
                MessageBox.Show("Data Jabatan gagal ditampilkan. Pesan kesalahan: " + hasilBaca);
            }
        }
    }
}
