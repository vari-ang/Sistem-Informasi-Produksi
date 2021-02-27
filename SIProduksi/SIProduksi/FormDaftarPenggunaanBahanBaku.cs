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
    public partial class FormDaftarPenggunaanBahanBaku : Form
    {
        List<PenggunaanBahanBaku> listHasilData = new List<PenggunaanBahanBaku>();
        public FormDaftarPenggunaanBahanBaku()
        {
            InitializeComponent();
        }
        private void FormatDataGrid()
        {
            dataGridViewBarang.Columns.Clear();
            dataGridViewBarang.Columns.Add("Produk", "Produk");
            dataGridViewBarang.Columns.Add("NoSpk", "Nomor Spk");
            dataGridViewBarang.Columns.Add("Jenis", "Jenis");
            dataGridViewBarang.Columns.Add("JumlahMasuk", "Jumlah Masuk");
            dataGridViewBarang.Columns.Add("JumlahKeluar", "Jumlah Keluar");
            dataGridViewBarang.Columns.Add("Tanggal", "Tanggal Keluar");
            dataGridViewBarang.Columns.Add("Stok", "Sisa Stok");
            dataGridViewBarang.Columns.Add("StokOpname", "Stok Opname Tanggal");

            dataGridViewBarang.Columns["StokOpname"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Tanggal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        public void FormDaftarPenggunaanBahanBaku_Load(object sender, EventArgs e)
        {
            listHasilData.Clear();
            FormatDataGrid();
            string hasil = PenggunaanBahanBaku.BacaData("", "", listHasilData);
            if (hasil == "1")
            {
                dataGridViewBarang.Rows.Clear();
                for (int i = 0; i < listHasilData.Count; i++)
                {
                    dataGridViewBarang.Rows.Add(listHasilData[i].Spk.Brg.Kode + " - " + listHasilData[i].Spk.Brg.Nama, listHasilData[i].Spk.NoSPK,
                        listHasilData[i].Jenis, listHasilData[i].JumlahMasuk, listHasilData[i].JumlahKeluar, listHasilData[i].TanggalKeluar, listHasilData[i].SisaStok, listHasilData[i].StokOpnameTanggal);
                }
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormUtama frmUtama = (FormUtama)this.Owner;
            frmUtama.getNotif();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormTambahPenggunaanBahanBaku form = new FormTambahPenggunaanBahanBaku();
            form.Owner = this;
            form.Show();
        }
    }
}
