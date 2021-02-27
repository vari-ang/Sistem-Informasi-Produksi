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
    public partial class FormDaftarSPK : Form
    {
        List<Spk> listHasilData = new List<Spk>();
        public FormDaftarSPK()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahSPK frm = new FormTambahSPK();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormatDataGrid()
        {
            dataGridViewJabatan.Columns.Clear();
            dataGridViewJabatan.Columns.Add("nospk", "No.SPK");
            dataGridViewJabatan.Columns.Add("Tanggal", "Tanggal");
            dataGridViewJabatan.Columns.Add("Barang", "Barang");
            dataGridViewJabatan.Columns.Add("Pekerja", "Pegawai");
            dataGridViewJabatan.Columns.Add("Pekerjaan", "Pekerjaan");
            dataGridViewJabatan.Columns.Add("Lokasi", "Lokasi");
            dataGridViewJabatan.Columns.Add("lamapengerjaan", "Lama Pengerjaan");
            dataGridViewJabatan.Columns.Add("biaya", "Biaya");
            dataGridViewJabatan.Columns.Add("syarat", "Syarat");
            dataGridViewJabatan.Columns.Add("metode", "Metode");


            dataGridViewJabatan.Columns["Pekerjaan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJabatan.Columns["lamapengerjaan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJabatan.Columns["biaya"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJabatan.Columns["syarat"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        public void FormDaftarSPK_Load(object sender, EventArgs e)
        {
            listHasilData.Clear();
            FormatDataGrid();

            listHasilData.Clear();
            string hasilBaca = Spk.BacaData("", "", listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewJabatan.Rows.Clear();

                for (int i = 0; i < listHasilData.Count; i++)
                {
                    dataGridViewJabatan.Rows.Add(listHasilData[i].NoSPK, listHasilData[i].Tanggal.ToShortDateString(), listHasilData[i].Brg.Nama
                        , listHasilData[i].IdPekerja.Nama, listHasilData[i].Pekerjaan, listHasilData[i].Lokasi, listHasilData[i].LamaPengerjaan + " Hari",
                        listHasilData[i].Biaya,listHasilData[i].Syarat,listHasilData[i].Metode);
                }
            }
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            string kriteria = "";

            if (comboBoxCari.Text == "No SPK")
            {
                kriteria = "S.nomor";
            }
            else if (comboBoxCari.Text == "Barang")
            {
                kriteria = "B.nama";
            }

            // Kosongi isi list
            listHasilData.Clear();

            // Tampilkan data kategori sesuai kriteria
            string hasilBaca = Spk.BacaData(kriteria, textBoxCari.Text, listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewJabatan.DataSource = null;
                dataGridViewJabatan.DataSource = listHasilData;
            }
        }
    }
}
