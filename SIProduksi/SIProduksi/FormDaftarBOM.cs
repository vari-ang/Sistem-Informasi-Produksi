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
    public partial class FormDaftarBOM : Form
    {
        List<BOM> listBOM = new List<BOM>();
        List<BahanBaku> listBahanBaku = new List<BahanBaku>();
        List<Barang> listbarang = new List<Barang>();
        public FormDaftarBOM()
        {
            InitializeComponent();
        }
        private void FormatDataGrid()
        {
            dataGridViewBahanBaku.Columns.Clear();

            dataGridViewBahanBaku.Columns.Add("Barang", "Barang");
            dataGridViewBahanBaku.Columns.Add("Bahan", "Bahan/Material Pendukung");
            dataGridViewBahanBaku.Columns.Add("Bagian", "Bagian");
            dataGridViewBahanBaku.Columns.Add("UkuranMentah", "Ukuran Mentah PxLxT");
            dataGridViewBahanBaku.Columns.Add("UkuranJadi", "Ukuran Jadi PxL");
            dataGridViewBahanBaku.Columns.Add("UkuranLuasan", "Ukuran Luasan");
            dataGridViewBahanBaku.Columns.Add("Jumlah", "Jumlah (Bagian)");
            dataGridViewBahanBaku.Columns.Add("JumlahSpes", "Jumlah (Biji/Lembar/Batang)");
            dataGridViewBahanBaku.Columns.Add("TotalBiaya", "Total Biaya");
            dataGridViewBahanBaku.Columns.Add("BiayaOperasional", "Biaya Operasional");
            dataGridViewBahanBaku.Columns.Add("BiayaTukang", "Biaya Tukang");
            dataGridViewBahanBaku.Columns.Add("PengajuanHarga", "Pengajuan Harga");

            dataGridViewBahanBaku.Columns["UkuranMentah"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBahanBaku.Columns["UkuranLuasan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBahanBaku.Columns["UkuranJadi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBahanBaku.Columns["JumlahSpes"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBahanBaku.Columns["Jumlah"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBahanBaku.Columns["PengajuanHarga"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        public void FormDaftarBOM_Load(object sender, EventArgs e)
        {
            listBOM.Clear();
            FormatDataGrid();
            string hasilBaca = BOM.BacaData("", "", listBOM);
            if (hasilBaca == "1")
            {
                string no = "";
                int display = 0;
                string divider = "";
                string tb = "";
                string bt = "";
                string bo = "";
                string bp = "";
                dataGridViewBahanBaku.DataSource = null;
                for(int i=0; i<listBOM.Count; i++)
                {
                    listbarang.Clear();
                    if(divider != listBOM[i].Kodebarang)
                    {
                        divider = listBOM[i].Kodebarang;
                        string hasis = Barang.BacaData("kode", listBOM[i].Kodebarang, listbarang);
                        no = listBOM[i].Kodebarang + " - " + listbarang[0].Nama;
                        tb = listBOM[i].TotalBiaya.ToString();
                        bt = listBOM[i].BiayaTukang.ToString();
                        bo = listBOM[i].BiayaOperasional.ToString();
                        bp = listBOM[i].PengajuanHarga.ToString();

                    }
                    else
                    {
                        no = "";
                        tb = "";
                         bt = "";
                         bo = "";
                         bp = "";
                    }

                    divider = listBOM[i].Kodebarang;
                    listBahanBaku.Clear();

                    string hasilbbs = BahanBaku.BacaData("BB.Id", listBOM[i].IdbahanBaku, listBahanBaku);
                    if(hasilbbs == "1")
                    {
                        dataGridViewBahanBaku.Rows.Add(no, listBahanBaku[0].Nama, listBahanBaku[0].Bagian, listBahanBaku[0].UkuranMentah,
                            listBahanBaku[0].UkuranLuasan, listBahanBaku[0].UkuranJadi, listBOM[i].JumlahBagian, listBOM[i].JumlahBijiLembarBatang,
                            tb, bo, bt, bp);
                    }
                    else
                    {
                        MessageBox.Show("gagal");
                    }
                    
                    
                }
            }
            else
            {
                // Kosongi dataGridView
                dataGridViewBahanBaku.DataSource = null;
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            FormUtama frmUtama = (FormUtama)this.Owner;
            frmUtama.getNotif();
            this.Close();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahBOM form = new FormTambahBOM();
            form.Owner = this;
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormUbahBOM f = new FormUbahBOM();
            f.Owner = this;
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormHapusBOM f = new FormHapusBOM();
            f.Owner = this;
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBoxCari.Text == "")
            {
                MessageBox.Show("Tolong spesifikasikan BOM dengan kode barang apa yang ingin dicetak");
            }
            else
            {
                string hasil = BOM.PrintBOM("kode_barang", textBoxCari.Text, "BOM");
                if (hasil == "1")
                {
                    MessageBox.Show("berhasil");
                }
                else
                {
                    MessageBox.Show("gagal");
                }
            }
            FormDaftarBOM_Load(sender, e);
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            dataGridViewBahanBaku.DataSource = null;
            dataGridViewBahanBaku.Rows.Clear();
            string kriteria = "kode_barang";

            // Kosongi isi list
            listBOM.Clear();

            // Tampilkan data kategori sesuai kriteria
            string hasilBaca = BOM.BacaData(kriteria, textBoxCari.Text, listBOM);

            if (hasilBaca == "1")
            {
                string no = "";
                int display = 0;
                string divider = "";

                
                for (int i = 0; i < listBOM.Count; i++)
                {
                    listbarang.Clear();
                    if (divider != listBOM[i].Kodebarang)
                    {
                        divider = listBOM[i].Kodebarang;
                        string hasis = Barang.BacaData("kode", listBOM[i].Kodebarang, listbarang);
                        no = listBOM[i].Kodebarang + " - " + listbarang[0].Nama;
                    }
                    else
                    {
                        no = "";
                    }

                    divider = listBOM[i].Kodebarang;
                    listBahanBaku.Clear();

                    string hasilbbs = BahanBaku.BacaData("BB.Id", listBOM[i].IdbahanBaku, listBahanBaku);
                    if (hasilbbs == "1")
                    {
                        dataGridViewBahanBaku.Rows.Add(no, listBahanBaku[0].Nama, listBahanBaku[0].Bagian, listBahanBaku[0].UkuranMentah,
                            listBahanBaku[0].UkuranLuasan, listBahanBaku[0].UkuranJadi, listBOM[i].JumlahBagian, listBOM[i].JumlahBijiLembarBatang,
                            listBOM[i].TotalBiaya, listBOM[i].BiayaOperasional, listBOM[i].BiayaTukang, listBOM[i].PengajuanHarga);
                    }
                    else
                    {
                        MessageBox.Show("gagal");
                    }


                }
            }
        }
    }
}
