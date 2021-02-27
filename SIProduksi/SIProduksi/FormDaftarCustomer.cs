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
    public partial class FormDaftarCustomer : Form
    {
        List<Customer> listHasilData = new List<Customer>();

        public FormDaftarCustomer()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahCustomer frm = new FormTambahCustomer();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahCustomer frm = new FormUbahCustomer();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusCustomer frm = new FormHapusCustomer();
            frm.Owner = this;
            frm.Show();
        }

        public void FormDaftarCustomer_Load(object sender, EventArgs e)
        {
            // Tampilkan semua data pelanggan
            listHasilData.Clear();
            string hasilBaca = Customer.BacaData("", "", listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewPelanggan.DataSource = null;

                // Tampilkan hasil data di dataGridView
                dataGridViewPelanggan.DataSource = listHasilData;
            }
            else
            {
                // Kosongi dataGridView
                dataGridViewPelanggan.DataSource = null;
            }
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            string kriteria = "";

            if (comboBoxCari.Text == "Id Pelanggan")
            {
                kriteria = "Id";
            }
            else if (comboBoxCari.Text == "Nama")
            {
                kriteria = "Nama";
            }
            else if (comboBoxCari.Text == "Alamat")
            {
                kriteria = "Alamat";
            }
            else if (comboBoxCari.Text == "Nomer HP")
            {
                kriteria = "nomer_hp";
            }

            // Kosongi isi list
            listHasilData.Clear();

            // Tampilkan data kategori sesuai kriteria
            string hasilBaca = Customer.BacaData(kriteria, textBoxCari.Text, listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewPelanggan.DataSource = null;
                dataGridViewPelanggan.DataSource = listHasilData;
            }
        }
    }
}
