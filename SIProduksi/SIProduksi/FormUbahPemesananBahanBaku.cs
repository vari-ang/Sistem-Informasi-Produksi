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
    public partial class FormUbahPemesananBahanBaku : Form
    {
        List<PemesananBahanBaku> listHasilData = new List<PemesananBahanBaku>();
        List<PemesananBahanBaku> s = new List<PemesananBahanBaku>();
        public FormUbahPemesananBahanBaku()
        {
            InitializeComponent();
        }
        private void FormatDataGrid()
        {
            dataGridViewBarang.Columns.Clear();

            dataGridViewBarang.Columns.Add("Id", "Id");
            dataGridViewBarang.Columns.Add("Kode", "Kode Pemesanan");
            dataGridViewBarang.Columns.Add("Nama", "Bahan Baku");
            dataGridViewBarang.Columns.Add("Jenis", "Jenis");
            dataGridViewBarang.Columns.Add("Jumlah", "Jumlah");
            dataGridViewBarang.Columns.Add("HargaSatuan", "Harga Satuan");
            dataGridViewBarang.Columns.Add("SubTotal", "Sub Total Harga");
            dataGridViewBarang.Columns.Add("TanggalTerima", "Tanggal Terima");
            dataGridViewBarang.Columns.Add("Keterangan", "Keterangan");

            dataGridViewBarang.Columns["HargaSatuan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["SubTotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Jumlah"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Kode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Keterangan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        public void FormUbahPemesananBahanBaku_Load(object sender, EventArgs e)
        {
            FormatDataGrid();
            listHasilData.Clear();
            comboBoxKode.Items.Clear();
            dataGridViewBarang.DataSource = null;
            string hasil = PemesananBahanBaku.BacaData("", "", listHasilData);
            if(hasil == "1")
            {
                for(int i=0; i<listHasilData.Count; i++)
                {
                    if(listHasilData[i].Listpemesanan[0].Kedatangan == "0")
                    {
                        comboBoxKode.Items.Add(listHasilData[i].Kode);
                    }
                    
                }
            }
        }

        private void comboBoxKode_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewBarang.Rows.Clear();
            s.Clear();
            string hasil = PemesananBahanBaku.BacaData("kode", comboBoxKode.Text, s);
            if(hasil == "1")
            {
                textBoxSPK.Text = s[0].SPK.NoSPK;
                for(int i=0; i<s[0].Listpemesanan.Count; i++)
                {
                    dataGridViewBarang.Rows.Add(s[0].Listpemesanan[i].Id,s[0].Listpemesanan[i].KodePBB.Kode,s[0].Listpemesanan[i].IDbahan.Nama, s[0].Listpemesanan[i].Jenis, 
                        s[0].Listpemesanan[i].Jumlah,s[0].Listpemesanan[i].HargaSatuan, s[0].Listpemesanan[i].SubTotalHarga,
                        s[0].Listpemesanan[i].TanggalTerima,s[0].Listpemesanan[i].Keterangan);
                }
            }
        }

        private void buttonBuat_Click(object sender, EventArgs e)
        {
            
            
            string hasils = "1";
            for(int i=0; i<listHasilData[comboBoxKode.SelectedIndex].Listpemesanan.Count; i++)
            {
                List<DetailPemesananBahanBaku> kk = new List<DetailPemesananBahanBaku>();
                int p = (int) dataGridViewBarang.Rows[i].Cells[0].Value;
                string hasil = DetailPemesananBahanBaku.Confirm(p, dateTimePicker1.Value);
                if(hasil != "1")
                {
                    MessageBox.Show("Pemesanan gagal dikonfirmasi. Pesan : " + hasil);
                    hasils = "0";
                    break;
                }
            }
            if(hasils == "1")
            {

                MessageBox.Show("Pemesanan telah berhasil di konfirmasi. Bahan Baku telah ditambah");
                for (int i = 0; i <s[0].Listpemesanan.Count; i++)
                {
                    BahanBaku.TambahStok(s[0].Listpemesanan[i].IDbahan.Id, s[0].Listpemesanan[i].Jumlah);
                }
                FormDetailPemesananBahanBaku k = (FormDetailPemesananBahanBaku)this.Owner;
                k.FormDetailPemesananBahanBaku_Load(sender, e);
                FormUbahPemesananBahanBaku_Load(sender, e);

            }
            
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }
    }
}
