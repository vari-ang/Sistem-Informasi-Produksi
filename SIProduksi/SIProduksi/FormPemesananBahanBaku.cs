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
    public partial class FormPemesananBahanBaku : Form
    {
        List<BahanBaku> listHasilData = new List<BahanBaku>();
        List<Spk> listspk = new List<Spk>();
        List<DetailPemesananBahanBaku> dc = new List<DetailPemesananBahanBaku>();
        public int subharga = 0;
        public int harga = 0;
        public int jumlah = 0;
        int hrg = 0;
        public FormPemesananBahanBaku()
        {
            InitializeComponent();
        }

        private void buttonBuat_Click(object sender, EventArgs e)
        {
            try
            {
                Spk k = listspk[comboBoxNomorSPK.SelectedIndex];
                    PemesananBahanBaku p = new PemesananBahanBaku(textBoxKode.Text,k,DateTime.Now,hrg);
                    string has = DetailPemesananBahanBaku.BacaData("", "", dc);
                    if (dataGridViewBarang.Rows.Count != 0)
                    {
                        int id = dc.Count + 1;
                        // data barang diperoleh dari dataGridView
                        for (int i = 0; i < dataGridViewBarang.Rows.Count; i++)
                        {

                            DetailPemesananBahanBaku brg = new DetailPemesananBahanBaku();
                            string code =DetailPemesananBahanBaku.GenerateCode(out code);
                            brg.Id = id;
                            brg.IDbahan = listHasilData[comboBoxID.SelectedIndex];
                            brg.KodePBB = p;
                            brg.TanggalTerima = DateTime.Now;
                            brg.Jenis = dataGridViewBarang.Rows[i].Cells["Jenis"].Value.ToString();
                            brg.HargaSatuan = int.Parse(dataGridViewBarang.Rows[i].Cells["HargaSatuan"].Value.ToString());
                            brg.Jumlah = int.Parse(dataGridViewBarang.Rows[i].Cells["Jumlah"].Value.ToString());
                            brg.SubTotalHarga = int.Parse(dataGridViewBarang.Rows[i].Cells["SubTotal"].Value.ToString());
                            brg.Keterangan = dataGridViewBarang.Rows[i].Cells["Keterangan"].Value.ToString();

                            // simpan detil barang ke nota
                            p.TambahPemesanan(brg);
                            id++;
                        }

                        string hasilTambah = PemesananBahanBaku.TambahData(p);
                        if (hasilTambah == "1")
                        {
                            MessageBox.Show("Data Pemesanan Bahan Baku telah tersimpan", "Info");
                            FormPemesananBahanBaku_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Data Pemesanan Bahan Baku gagal tersimpan. Pesan kesalahan: " + hasilTambah, "Kesalahan");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Anda belum menambahkan bahan baku apa pun pada", "Kesalahan");
                    }
                }
            
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }            
        }

        public void FormPemesananBahanBaku_Load(object sender, EventArgs e)
        {
            hrg = 0;
            labelHarga.Text = hrg.ToString();
            dataGridViewBarang.Rows.Clear();
            FormatDataGrid();
            listHasilData.Clear();
            comboBoxID.Items.Clear();
            comboBoxNomorSPK.Items.Clear();
            textBoxsub.Text = "";
            textBoxharga.Text = "";
            textBoxjenis.Text = "";
            textBoxjumlah.Text = "";
            comboBoxID.Text = "";
            richTextBoxkete.Text = "";
            textBoxsub.Enabled = false;
            textBoxharga.Enabled = false;
            textBoxjenis.Enabled = false;
            textBoxjumlah.Enabled = false;
            richTextBoxkete.Enabled = false;
            string hasil = BahanBaku.BacaData("", "", listHasilData);
            if (hasil == "1")
            {
                for(int i=0; i<listHasilData.Count; i++)
                {
                    comboBoxID.Items.Add(listHasilData[i].Id + " - " + listHasilData[i].Nama);
                }
            }
            string spk = Spk.BacaData("","",listspk);
            if(spk == "1")
            {
                for(int i=0; i<listspk.Count; i++)
                {
                    comboBoxNomorSPK.Items.Add(listspk[i].NoSPK);
                }
            }
        }
        private void FormatDataGrid()
        {
            dataGridViewBarang.Columns.Clear();

            // menambah kolom di datagridview
            dataGridViewBarang.Columns.Add("Nama", "Nama");
            dataGridViewBarang.Columns.Add("Jenis", "Jenis");
            dataGridViewBarang.Columns.Add("HargaSatuan", "Harga Satuan");
            dataGridViewBarang.Columns.Add("Jumlah", "Jumlah");
            dataGridViewBarang.Columns.Add("SubTotal", "Sub Total");
            dataGridViewBarang.Columns.Add("Keterangan", "Keterangan");

            // agar lebar dapat menyesuaikan panjang/ isi data
            dataGridViewBarang.Columns["Nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Jenis"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Jumlah"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["HargaSatuan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Keterangan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // agar harga jual dan sub total rata kanan
            dataGridViewBarang.Columns["Jumlah"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewBarang.Columns["HargaSatuan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // agar harga jual dan sub total ditampilkan dengan format pemisah ribuan (1000 delimiter)
            dataGridViewBarang.Columns["HargaSatuan"].DefaultCellStyle.Format = "0,###";
            dataGridViewBarang.Columns["SubTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // agar harga jual dan sub total ditampilkan dengan format pemisah ribuan (1000 delimiter)
            dataGridViewBarang.Columns["SubTotal"].DefaultCellStyle.Format = "0,###";

            // agar user tidak bisa menambahkan data langsung di datagridview (harus melalui tombol Tambah)
            dataGridViewBarang.AllowUserToAddRows = false;
        }
        private void textBoxKode_TextChanged(object sender, EventArgs e)
        {
            comboBoxNomorSPK.Enabled = true;
        }

        private void comboBoxNomorSPK_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
        }

        private void textBoxjumlah_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(textBoxjumlah.Text, out jumlah);
            subharga = harga * jumlah;
            textBoxsub.Text = subharga.ToString();
            
        }

        private void textBoxharga_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(textBoxharga.Text,out harga);
            subharga = harga * jumlah;
            textBoxsub.Text = subharga.ToString();
        }

        private void buttonTambahBarang_Click(object sender, EventArgs e)
        {
            Spk a = listspk[comboBoxNomorSPK.SelectedIndex];
            PemesananBahanBaku k = new PemesananBahanBaku(textBoxKode.Text, a, DateTime.Now, int.Parse(labelHarga.Text));
            string code = "";
            if(textBoxharga.Text != "" && textBoxKode.Text != "" && textBoxjenis.Text != "" &&textBoxsub.Text != "" &&textBoxjumlah.Text != "" && comboBoxID.Text != "" && richTextBoxkete.Text != "")
            {
                code = DetailPemesananBahanBaku.GenerateCode(out code);
                BahanBaku b = listHasilData[comboBoxID.SelectedIndex];
              
                DetailPemesananBahanBaku s = new DetailPemesananBahanBaku(int.Parse(code), k, b, textBoxjenis.Text, int.Parse(textBoxjumlah.Text)
                    , int.Parse(textBoxharga.Text), subharga, "", richTextBoxkete.Text);
                dataGridViewBarang.Rows.Add(listHasilData[comboBoxID.SelectedIndex].Nama, textBoxjenis.Text, textBoxharga.Text, textBoxjumlah.Text, textBoxsub.Text, richTextBoxkete.Text);
                int sub = int.Parse(textBoxsub.Text);
                hrg += sub;
                labelHarga.Text = hrg.ToString();
                subharga = 0;
                harga = 0;
                jumlah = 0;
                textBoxsub.Text = "";
                textBoxharga.Text = "";
                textBoxjenis.Text = "";
                textBoxjumlah.Text = "";
                comboBoxID.Text = "";
                richTextBoxkete.Text = "";
                textBoxsub.Enabled = false;
                textBoxharga.Enabled = false;
                textBoxjenis.Enabled = false;
                textBoxjumlah.Enabled = false;
                richTextBoxkete.Enabled = false;
            }
            
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxID_SelectedIndexChanged(object sender, EventArgs e)
        {

            textBoxharga.Enabled = true;
            textBoxjenis.Enabled = true;
            textBoxjumlah.Enabled = true;
            richTextBoxkete.Enabled = true;
        }
    }
}
