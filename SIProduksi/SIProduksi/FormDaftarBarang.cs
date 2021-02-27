using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Produksi_LIB;

namespace SIProduksi
{
    public partial class FormDaftarBarang : Form
    {
        List<Barang> listHasilData = new List<Barang>();
        public FormDaftarBarang()
        {
            InitializeComponent();
        }
        private void FormatDataGrid()
        {
            dataGridViewBahanBaku.Columns.Clear();

            dataGridViewBahanBaku.Columns.Add("KodeBarang", "Kode");
            dataGridViewBahanBaku.Columns.Add("Nama", "Nama Barang");

            DataGridViewImageColumn dg = new DataGridViewImageColumn();
            dg.HeaderText = "Foto";
            dg.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridViewBahanBaku.Columns.Add(dg);
            dataGridViewBahanBaku.AllowUserToAddRows = false;
            dataGridViewBahanBaku.RowTemplate.Height = 100;

            dataGridViewBahanBaku.Columns.Add("Jumlah", "Jumlah");
            dataGridViewBahanBaku.Columns.Add("Satuan", "Satuan");
            dataGridViewBahanBaku.Columns.Add("HargaSatuan", "Harga Satuan");
            dataGridViewBahanBaku.Columns.Add("Keterangan", "Keterangan");
            dataGridViewBahanBaku.Columns.Add("IdOrder", "Id Order Penjualan");
            
            dataGridViewBahanBaku.Columns["Keterangan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBahanBaku.Columns["Jumlah"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBahanBaku.Columns["Satuan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBahanBaku.Columns["HargaSatuan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        private Image GetCopyImage(string path)
        {
            using (Image im = Image.FromFile(path))
            {
                Bitmap bm = new Bitmap(im);
                return bm;
            }
        }
        public void FormDaftarBarang_Load(object sender, EventArgs e)
        {
            try
            {
                FormatDataGrid();
                listHasilData.Clear();

                string hasilBaca = Barang.BacaData("", "", listHasilData);

                if (hasilBaca == "1")
                {
                    dataGridViewBahanBaku.Rows.Clear();

                    for (int i = 0; i < listHasilData.Count; i++)
                    {
                        if (File.Exists(Application.StartupPath + "\\Images\\Barang\\" + listHasilData[i].Kode + ".jpg"))
                        {
                            Image m = GetCopyImage(Application.StartupPath + "\\Images\\Barang\\" + listHasilData[i].Kode + ".jpg");
                            dataGridViewBahanBaku.Rows.Add(listHasilData[i].Kode, listHasilData[i].Nama,
                               m, listHasilData[i].Jumlah,
                                listHasilData[i].Satuan, listHasilData[i].HargaSatuan, listHasilData[i].Keterangan, listHasilData[i].OrderPenjualan.NoOrder);
                        }
                        else
                        {
                            dataGridViewBahanBaku.Rows.Add(listHasilData[i].Kode, listHasilData[i].Nama, null, listHasilData[i].Jumlah,
                                listHasilData[i].Satuan, listHasilData[i].HargaSatuan, listHasilData[i].Keterangan, listHasilData[i].OrderPenjualan.NoOrder);
                        }
                    }
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            string kriteria = "";

            if (comboBoxCari.Text == "Kode Barang")
            {
                kriteria = "kode";
            }
            else if (comboBoxCari.Text == "Nama")
            {
                kriteria = "Nama";
            }
            else if (comboBoxCari.Text == "Satuan")
            {
                kriteria = "satuan";
            }
            else if (comboBoxCari.Text == "Harga Satuan")
            {
                kriteria = "harga_satuan";
            }
            else if (comboBoxCari.Text == "ID Order Penjualan")
            {
                kriteria = "id_order_penjualan";
            }

            // Kosongi isi list
            listHasilData.Clear();

            // Tampilkan data kategori sesuai kriteria
            string hasilBaca = Barang.BacaData(kriteria, textBoxCari.Text, listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewBahanBaku.DataSource = null;
                dataGridViewBahanBaku.DataSource = listHasilData;
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormUbahBarang f = new FormUbahBarang();
            f.Owner = this;
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormHapusBarang f = new FormHapusBarang();
            f.Owner = this;
            f.Show();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahBarang f = new FormTambahBarang();
            f.Owner = this;
            f.Show();
        }

        private void dataGridViewBahanBaku_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
