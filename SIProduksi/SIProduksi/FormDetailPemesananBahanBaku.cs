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
    
    public partial class FormDetailPemesananBahanBaku : Form
    {
        List<DetailPemesananBahanBaku> listHasilData = new List<DetailPemesananBahanBaku>();
        public FormDetailPemesananBahanBaku()
        {
            InitializeComponent();
        }
        private void FormatDataGrid()
        {
            dataGridViewBahanBaku.Columns.Clear();

            dataGridViewBahanBaku.Columns.Add("Id", "Id");
            dataGridViewBahanBaku.Columns.Add("Kode", "Kode Pemesanan");
            dataGridViewBahanBaku.Columns.Add("Nama", "Bahan Baku");
            dataGridViewBahanBaku.Columns.Add("Jenis", "Jenis");
            dataGridViewBahanBaku.Columns.Add("Jumlah", "Jumlah");
            dataGridViewBahanBaku.Columns.Add("HargaSatuan", "Harga Satuan");
            dataGridViewBahanBaku.Columns.Add("SubTotal", "Sub Total Harga");
            dataGridViewBahanBaku.Columns.Add("Keterangan", "Keterangan");
            dataGridViewBahanBaku.Columns.Add("Status", "Status");

            dataGridViewBahanBaku.Columns["HargaSatuan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBahanBaku.Columns["SubTotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBahanBaku.Columns["Jumlah"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBahanBaku.Columns["Kode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBahanBaku.Columns["Keterangan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBahanBaku.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        public void FormDetailPemesananBahanBaku_Load(object sender, EventArgs e)
        {
            listHasilData.Clear();
            FormatDataGrid();
            string hasil = DetailPemesananBahanBaku.BacaData("", "", listHasilData);
            if(hasil == "1")
            {
                dataGridViewBahanBaku.DataSource = null;
                for(int i=0; i<listHasilData.Count; i++)
                {
                    if(listHasilData[i].Kedatangan == "1")
                    {
                        dataGridViewBahanBaku.Rows.Add(listHasilData[i].Id, listHasilData[i].KodePBB.Kode, listHasilData[i].IDbahan.Nama, listHasilData[i].Jenis,
                        listHasilData[i].Jumlah, listHasilData[i].HargaSatuan, listHasilData[i].SubTotalHarga, listHasilData[i].Keterangan, listHasilData[i].TanggalTerima);
                    }
                    else
                    {
                        dataGridViewBahanBaku.Rows.Add(listHasilData[i].Id, listHasilData[i].KodePBB.Kode, listHasilData[i].IDbahan.Nama, listHasilData[i].Jenis,
                        listHasilData[i].Jumlah, listHasilData[i].HargaSatuan, listHasilData[i].SubTotalHarga, listHasilData[i].Keterangan, "Bahan Baku belom sampai");
                    }
                    
                }
            }
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahPemesananBahanBaku f = new FormUbahPemesananBahanBaku();
            f.Owner = this;
            f.Show();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
