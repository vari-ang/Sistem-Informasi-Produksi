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
    public partial class FormHapusRiwayatperbaikan : Form
    {
        List<RiwayatPerbaikan> listdaftarriwayat = new List<RiwayatPerbaikan>();
        public FormHapusRiwayatperbaikan()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormHapusRiwayatperbaikan_Load(object sender, EventArgs e)
        {
            listdaftarriwayat.Clear();
            string hasil = RiwayatPerbaikan.BacaData("", "", listdaftarriwayat);
            if (hasil == "1")
            {
                comboBoxID.Items.Clear();
                for (int i = 0; i < listdaftarriwayat.Count; i++)
                {
                    comboBoxID.Items.Add(listdaftarriwayat[i].Id);
                }
            }
        }

        private void comboBoxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listdaftarriwayat.Count; i++)
            {
                if (comboBoxID.SelectedIndex == i)
                {
                    textBoxKeterangan.Text = listdaftarriwayat[i].Keterangan;
                }
            }
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                string hasilbaca = RiwayatPerbaikan.HapusData(comboBoxID.Text);
                if (hasilbaca == "1")
                {
                    MessageBox.Show("Data berhasil dihapus");
                }
                else
                {
                    MessageBox.Show("Erorr data tidak dapat dihapus : " + hasilbaca);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
            
        }
    }
}
