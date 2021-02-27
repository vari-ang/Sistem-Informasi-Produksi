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
    public partial class FormDaftarPemesananBahanBaku : Form
    {
        List<PemesananBahanBaku> listHasilData = new List<PemesananBahanBaku>();
        public FormDaftarPemesananBahanBaku()
        {
            InitializeComponent();
        }
        private void FormatDataGrid()
        {
            dataGridViewBarang.Columns.Clear();

            dataGridViewBarang.Columns.Add("Kode", "Kode Pemesanan");
            dataGridViewBarang.Columns.Add("NoSpk", "Nomor Spk");
            dataGridViewBarang.Columns.Add("Tanggal", "Tanggal Pesan");
            dataGridViewBarang.Columns.Add("TotalHarga", "TotalHarga");

            dataGridViewBarang.Columns["Kode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Tanggal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["NoSpk"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["TotalHarga"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        }
        public void FormDaftarPemesananBahanBaku_Load(object sender, EventArgs e)
        {
            try
            {
                listHasilData.Clear();
                FormatDataGrid();
                string hasilBaca = PemesananBahanBaku.BacaData("", "", listHasilData);

                if (hasilBaca == "1")
                {
                    dataGridViewBarang.DataSource = null;

                    for (int i = 0; i < listHasilData.Count; i++)
                    {
                        dataGridViewBarang.Rows.Add(listHasilData[i].Kode, listHasilData[i].SPK.NoSPK, listHasilData[i].Tanggal, listHasilData[i].TotalHarga);
                    }
                }
                else
                {
                    // Kosongi dataGridView
                    dataGridViewBarang.DataSource = null;
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show("Sedang memproses data pemesanan bahan baku.");
            }
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            string kriteria = "";

            if (comboBoxCari.Text == "Kode")
            {
                kriteria = "kode";
            }
            else if (comboBoxCari.Text == "Id Bahan Baku")
            {
                kriteria = "id_bahan_baku";
            }
            else if (comboBoxCari.Text == "Nomor SPK")
            {
                kriteria = "nomor_spk";
            }
            

            // Kosongi isi list
            listHasilData.Clear();

            // Tampilkan data kategori sesuai kriteria
            string hasilBaca = PemesananBahanBaku.BacaData(kriteria, textBoxCari.Text, listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewBarang.DataSource = null;
                dataGridViewBarang.DataSource = listHasilData;
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormDetailPemesananBahanBaku k = new FormDetailPemesananBahanBaku();
            k.Owner = this;
            k.Show();
        }
    }
}
