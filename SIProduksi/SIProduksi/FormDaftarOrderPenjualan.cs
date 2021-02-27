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
    public partial class FormDaftarOrderPenjualan : Form
    {
        private List<OrderPenjualan> listHasilData = new List<OrderPenjualan>();

        public FormDaftarOrderPenjualan()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormatDataGrid()
        {
            dataGridViewBarang.Columns.Clear();

            dataGridViewBarang.Columns.Add("NoOrder", "No Order Penjualan");
            dataGridViewBarang.Columns.Add("Tanggal", "Tanggal");
            dataGridViewBarang.Columns.Add("IdCustomer", "Id Customer");
            dataGridViewBarang.Columns.Add("NamaCustomer", "Nama Customer");
            dataGridViewBarang.Columns.Add("Unit", "Unit");
            dataGridViewBarang.Columns.Add("KodeBarang", "Kode Barang");
            dataGridViewBarang.Columns.Add("NamaBarang", "Nama Barang");
            dataGridViewBarang.Columns.Add("Jumlah", "Jumlah");
            dataGridViewBarang.Columns.Add("HargaSatuan", "Harga Satuan");
            dataGridViewBarang.Columns.Add("Keterangan", "Keterangan");

            dataGridViewBarang.Columns["NoOrder"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Tanggal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["IdCustomer"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["NamaCustomer"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Unit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["KodeBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["NamaBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Jumlah"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["HargaSatuan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Keterangan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewBarang.Columns["NoOrder"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; ;
            dataGridViewBarang.Columns["KodeBarang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewBarang.Columns["HargaSatuan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewBarang.Columns["IdCustomer"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        public void FormDaftarOrderPenjualan_Load(object sender, EventArgs e)
        {
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

            FormatDataGrid();
            listHasilData.Clear();

            string hasilBaca = OrderPenjualan.BacaData("", "", listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewBarang.Rows.Clear();

                for (int i = 0; i < listHasilData.Count; i++)
                {
                    for (int j = 0; j < listHasilData[i].ListBarang.Count; j++)
                    {
                        dataGridViewBarang.Rows.Add(listHasilData[i].NoOrder, listHasilData[i].Tanggal, listHasilData[i].Customer.IdCustomer,
                        listHasilData[i].Customer.Nama, listHasilData[i].Unit ,listHasilData[i].ListBarang[j].Kode,
                        listHasilData[i].ListBarang[j].Nama, listHasilData[i].ListBarang[j].Jumlah, listHasilData[i].ListBarang[j].HargaSatuan,
                        listHasilData[i].ListBarang[j].Keterangan);
                    }
                }
            }
        }

        private void buttonKeluar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTambah_Click_1(object sender, EventArgs e)
        {
            FormTambahOrderPenjualan frm = new FormTambahOrderPenjualan();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonBatal_Click(object sender, EventArgs e)
        {
            FormBatalOrderPenjualan frm = new FormBatalOrderPenjualan();
            frm.Owner = this;
            frm.Show();
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            string kriteria = "";
            if (comboBoxCari.Text == "No Order Penjualan")
            {
                kriteria = "OP.id";
            }
            else if (comboBoxCari.Text == "Id Customer")
            {
                kriteria = "C.Id";
            }
            else if (comboBoxCari.Text == "Nama Customer")
            {
                kriteria = "C.Nama";
            }
            else if (comboBoxCari.Text == "Kode Barang")
            {
                kriteria = "B.Kode";
            }
            else if (comboBoxCari.Text == "Nama Barang")
            {
                kriteria = "B.Nama";
            }
            else if (comboBoxCari.Text == "Jumlah")
            {
                kriteria = "B.Jumlah";
            }
            else if (comboBoxCari.Text == "Harga Satuan")
            {
                kriteria = "B.harga_satuan";
            }

            listHasilData.Clear();

            // Tampilkan data kategori sesuai kriteria
            string hasilBaca = OrderPenjualan.BacaData(kriteria, textBoxCari.Text, listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewBarang.DataSource = null;
                dataGridViewBarang.DataSource = listHasilData;
            }
        }
    }
}
