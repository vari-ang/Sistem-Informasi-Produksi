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
    public partial class FormDaftarJabatan : Form
    {
        private List<Jabatan> listHasilData = new List<Jabatan>();

        public FormDaftarJabatan()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void FormDaftarJabatan_Load(object sender, EventArgs e)
        {
            // Tampilkan semua data kategori
            listHasilData.Clear();
            string hasilBaca = Jabatan.BacaData("", "", listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewJabatan.DataSource = null;

                // Tampilkan hasil data di dataGridView
                dataGridViewJabatan.DataSource = listHasilData;
            }
            else
            {
                // Kosongi dataGridView
                dataGridViewJabatan.DataSource = null;
            }
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahJabatan frm = new FormTambahJabatan();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahJabatan frm = new FormUbahJabatan();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusJabatan frm = new FormHapusJabatan();
            frm.Owner = this;
            frm.Show();
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            string kriteria = "";

            if (comboBoxCari.Text == "Id Jabatan")
            {
                kriteria = "Id";
            }
            else if (comboBoxCari.Text == "Nama Jabatan")
            {
                kriteria = "Nama";
            }

            // Kosongi isi list
            listHasilData.Clear();

            // Tampilkan data kategori sesuai kriteria
            string hasilBaca = Jabatan.BacaData(kriteria, textBoxCari.Text, listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewJabatan.DataSource = null;
                dataGridViewJabatan.DataSource = listHasilData;
            }
        }
    }
}
