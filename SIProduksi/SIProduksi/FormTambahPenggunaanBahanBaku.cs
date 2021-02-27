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
    public partial class FormTambahPenggunaanBahanBaku : Form
    {
        List<Barang> listBarang = new List<Barang>();
        List<BOM> listBom = new List<BOM>();
        List<BahanBaku> listBahanBaku = new List<BahanBaku>();
        List<Spk> listSpk = new List<Spk>();
        List<Spk> listChosenSpk = new List<Spk>();
        List<BahanBaku> listChosenBahanBaku = new List<BahanBaku>();
        public FormTambahPenggunaanBahanBaku()
        {
            InitializeComponent();
        }
        private void KeyChecker()
        {
            
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

        }
        public void FormTambahPenggunaanBahanBaku_Load(object sender, EventArgs e)
        {
            FormatDataGrid();
            dataGridViewBarang.Rows.Clear();
            comboBox1.Text = "";
            comboBoxSpk.Text = "";
            comboBoxBahanBaku.Text = "";
            textBoxJenis.Text = "";
            textBoxStok.Text = "0";
            stok = 0;
            textBoxKodeBarang.Text = "0";
            textBox1.Text = "0";
            keluar = 0;
            masuk = 0;
            groupBox2.Enabled = false;
            comboBoxBahanBaku.Enabled = false;
            comboBoxSpk.Enabled = true;
            listBahanBaku.Clear();
            listSpk.Clear();
            comboBoxBahanBaku.Items.Clear();
            listBarang.Clear();
            comboBoxSpk.Items.Clear();
            comboBox1.Items.Clear();
            //string b = BahanBaku.BacaData("", "", listBahanBaku);
            //if (b == "1")
            //{
            //    for (int i = 0; i < listBahanBaku.Count; i++)
            //    {
            //        comboBoxBahanBaku.Items.Add(listBahanBaku[i].Id + " - " + listBahanBaku[i].Nama);
            //    }
            //}
            string hasil = Barang.BacaData("", "", listBarang);
            if (hasil == "1")
            {
                for (int i = 0; i < listBarang.Count; i++)
                {
                    comboBox1.Items.Add(listBarang[i].Kode + " - " + listBarang[i].Nama);
                }
            }

        }

        private void buttonTambahBarang_Click(object sender, EventArgs e)
        {
            if (dataGridViewBarang.Rows.Count <2)
            {
                MessageBox.Show("Harap mengisi paling tidak satu data");
            }
            else
            {
                string hasil = "1";
                for(int i=0; i<dataGridViewBarang.Rows.Count - 1; i++)
                {
                    PenggunaanBahanBaku p = new PenggunaanBahanBaku();
                    p.BahanBaku = listChosenBahanBaku[i];
                    p.Spk = listChosenSpk[i];
                    p.JumlahMasuk = int.Parse(dataGridViewBarang.Rows[i].Cells["JumlahMasuk"].Value.ToString());
                    p.JumlahKeluar = int.Parse(dataGridViewBarang.Rows[i].Cells["JumlahKeluar"].Value.ToString());
                    p.TanggalKeluar = DateTime.Parse(dataGridViewBarang.Rows[i].Cells["Tanggal"].Value.ToString());
                    p.SisaStok = int.Parse(dataGridViewBarang.Rows[i].Cells["Stok"].Value.ToString());
                    p.StokOpnameTanggal = dataGridViewBarang.Rows[i].Cells["StokOpname"].Value.ToString();
                    p.Jenis = dataGridViewBarang.Rows[i].Cells["Jenis"].Value.ToString();
                    hasil = PenggunaanBahanBaku.TambahData(p);
                    hasil = BahanBaku.SetStok(p.BahanBaku.Id, p.SisaStok);
                }
                if(hasil =="1")
                {
                    MessageBox.Show("Penggunaan bahan baku telah ditambah");
                    FormDaftarPenggunaanBahanBaku form = (FormDaftarPenggunaanBahanBaku)this.Owner;
                    form.FormDaftarPenggunaanBahanBaku_Load(sender, e);
                    FormTambahPenggunaanBahanBaku_Load(sender,e);
                }
                else
                {
                    MessageBox.Show("Penggunaan Bahan Baku gagal ditambah. pesan : " + hasil);
                }
                //BahanBaku b = listBahanBaku[comboBoxBahanBaku.SelectedIndex];
                //Spk s = listSpk[comboBoxSpk.SelectedIndex];
                //PenggunaanBahanBaku p = new PenggunaanBahanBaku(b, s, masuk, keluar, dateTimePickerTanggal.Value, dateTimePickerTanggal.Value.ToString("ddMMMMyyyy") + " | " + textBoxStok.Text, int.Parse(textBoxStok.Text), textBoxJenis.Text);
                //string hasil = PenggunaanBahanBaku.TambahData(p);
                //if (hasil == "1")
                //{
                //    MessageBox.Show("Penggunaan Bahan Baku telah ditambah");
                //    comboBoxBahanBaku.Text = "";
                //    comboBoxBahanBaku.Enabled = false;
                //    textBox1.Text = "";
                //    textBoxKodeBarang.Text = "";
                //    textBoxStok.Text = "";
                //    comboBoxSpk.Text = "";
                //    textBoxJenis.Text = "";
                //    FormDaftarPenggunaanBahanBaku form = (FormDaftarPenggunaanBahanBaku)this.Owner;
                //    form.FormDaftarPenggunaanBahanBaku_Load(sender, e);
                //}
                //else
                //{
                //    MessageBox.Show("Penggunaan Bahan Baku gagal ditambah. Pesan kesalahan : " + hasil);
                //}
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBahanBaku.Clear();
            listSpk.Clear();
            listBom.Clear();
            Barang b = listBarang[comboBox1.SelectedIndex];
            comboBoxBahanBaku.Items.Clear();
            string hasilBom = BOM.BacaData("kode_barang", b.Kode, listBom);
            if(hasilBom == "1")
            {
                for(int i=0; i<listBom.Count; i++)
                {
                    List<BahanBaku> lbb = new List<BahanBaku>();
                    string hasilBahan = BahanBaku.BacaData("BB.Id", listBom[i].IdbahanBaku, lbb);
                    comboBoxBahanBaku.Items.Add(lbb[0].Id + " - " + lbb[0].Nama);
                    listBahanBaku.Add(lbb[0]);
                }
            }
            comboBoxSpk.Items.Clear();
            string hasil = Spk.BacaData("kode_barang", b.Kode, listSpk);
            if (hasil == "1")
            {
                for (int i = 0; i < listSpk.Count; i++)
                {
                    comboBoxSpk.Items.Add(listSpk[i].NoSPK + " - " + listSpk[i].IdPekerja.Nama);
                }
                comboBoxSpk.Enabled = true;
                comboBoxBahanBaku.Text = "";
                comboBoxBahanBaku.Enabled = false;
            }
        }

        private void comboBoxSpk_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxBahanBaku.Enabled = true;
        }
        public int stok = 0;
        public int masuk = 0;
        public int keluar = 0;
        private void comboBoxBahanBaku_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<BOM> liss = new List<BOM>();
            groupBox2.Enabled = true;
            Barang b = listBarang[comboBox1.SelectedIndex];
            BahanBaku d = listBahanBaku[comboBox1.SelectedIndex];
            string hasils = BOM.BacaData("id_bahan_baku", "kode_barang", d.Id, b.Kode, liss);
            int jumlah = int.Parse(liss[0].JumlahBijiLembarBatang);
            masuk = jumlah;
            textBoxKodeBarang.Text = masuk.ToString();
            stok = listBahanBaku[comboBoxBahanBaku.SelectedIndex].Stok;
            stok -= masuk;
            textBoxJenis.Text = listBahanBaku[comboBoxBahanBaku.SelectedIndex].Nama;
            textBoxStok.Text = stok.ToString();
        }

        private void textBoxJenis_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxKodeBarang_TextChanged(object sender, EventArgs e)
        {
            textBoxStok.Text = stok.ToString();
            int.TryParse(textBoxKodeBarang.Text, out masuk);
            
            int diff = masuk - keluar;
            
            textBoxStok.Text = (stok - masuk + diff).ToString();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBoxStok.Text = stok.ToString();
            int.TryParse(textBox1.Text, out keluar);
            if (keluar > masuk)
            {
                textBox1.Text = masuk.ToString();
            }
            else if(keluar<=0 && textBox1.Text != "")
            {
                textBox1.Text = "0";
            }
            else if(textBox1.Text == "")
            {
            }
            textBoxStok.Text = (stok + keluar).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxKodeBarang.Text == "" && textBox1.Text == "")
            {
                MessageBox.Show("Harap mengisi semua kolom yang ada");
            }
            else if (masuk == 0)
            {
                //g guna tapi biar lebih panjang aja
                MessageBox.Show("Jumlah masuk ataupun Keluar tidak boleh 0");
            }
            else
            {
                BahanBaku b = listBahanBaku[comboBoxBahanBaku.SelectedIndex];
                dataGridViewBarang.Rows.Add(listBarang[comboBox1.SelectedIndex].Kode, listSpk[comboBoxSpk.SelectedIndex].NoSPK, textBoxJenis.Text,
                    masuk, keluar, dateTimePickerTanggal.Value, textBoxStok.Text, listBahanBaku[comboBoxBahanBaku.SelectedIndex].Nama + listBahanBaku[comboBoxBahanBaku.SelectedIndex].UkuranMentah + dateTimePickerTanggal.Value.ToString("ddMMMMyyyy"));
                comboBoxBahanBaku.Text = "";
                textBoxJenis.Text = "";
                listChosenBahanBaku.Add(b);
                listChosenSpk.Add(listSpk[comboBoxSpk.SelectedIndex]);
                textBoxStok.Text = "0";
                stok = 0;
                textBoxKodeBarang.Text = "0";
                textBox1.Text = "0";
                keluar = 0;
                masuk = 0;
                
                
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
