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
    public partial class FormDaftarSupplier : Form
    {
        List<Supplier> listHasilData = new List<Supplier>();

        public FormDaftarSupplier()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahSupplier frm = new FormTambahSupplier();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahSupplier frm = new FormUbahSupplier();
            frm.Owner = this;
            frm.Show();
        }

        public void FormDaftarSupplier_Load(object sender, EventArgs e)
        {
            // Tampilkan semua data Supplier
            listHasilData.Clear();
            string hasilBaca = Supplier.BacaData("", "", listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewSupplier.DataSource = null;

                // Tampilkan hasil data di dataGridView
                dataGridViewSupplier.DataSource = listHasilData;
            }
            else
            {
                // Kosongi dataGridView
                dataGridViewSupplier.DataSource = null;
            }
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            string kriteria = "";

            if (comboBoxCari.Text == "Kode Supplier")
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

            // Kosongi isi list
            listHasilData.Clear();

            // Tampilkan data kategori sesuai kriteria
            string hasilBaca = Supplier.BacaData(kriteria, textBoxCari.Text, listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewSupplier.DataSource = null;
                dataGridViewSupplier.DataSource = listHasilData;
            }
        }
    }
}
