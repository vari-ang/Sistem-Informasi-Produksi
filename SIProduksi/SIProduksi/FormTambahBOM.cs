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
using System.Threading;
namespace SIProduksi
{
    public partial class FormTambahBOM : Form
    {
        FormDaftarBOM frmDaftar;
        List<Barang> listBarang = new List<Barang>();
        List<BahanBaku> listBahanBaku = new List<BahanBaku>();
        Barang b = new Barang();
        BahanBaku bb = new BahanBaku();
        public FormTambahBOM()
        {
            InitializeComponent();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            BOM bom = new BOM(comboBoxBahan.Text,comboBoxKodeBarang.Text,((int)
                numericUpDownJumlahBagian.Value).ToString(),((int)numericUpDownJumlahSpesifik.Value).ToString(),
                (int)numericUpDownTotalBiaya.Value,(int)numericUpDownBiayaOperasional.Value,
                (int)numericUpDownBiayaTukang.Value, (int)numericUpDownPengajuanHarga.Value);

            string hasil = BOM.TambahData(bom);
            if(hasil == "1")
            {
                MessageBox.Show("BOM telah ditambahkan");
            }
            else
            {
                MessageBox.Show("BOM gagal ditambahkan. Pesan error: " + hasil);
            }

            FormTambahBOM_Load(sender, e);
            frmDaftar.FormDaftarBOM_Load(sender, e);
        }
     
        private void FormTambahBOM_Load(object sender, EventArgs e)
        {
            try
            {
                frmDaftar = (FormDaftarBOM)this.Owner;
                FormatDataGrid();
                listBahanBaku.Clear();
                listBarang.Clear();
                comboBoxBahan.Items.Clear();
                comboBoxKodeBarang.Items.Clear();
                comboBoxKodeBarang.Enabled = true;
                groupBox1.Enabled = false;

                numericUpDownBiayaTukang.Value = 0;
                numericUpDownBiayaOperasional.Value = 0;
                numericUpDownPengajuanHarga.Value = 0;
                numericUpDownJumlahBagian.Value = 0;
                numericUpDownJumlahSpesifik.Value = 0;
                numericUpDownTotalBiaya.Value = 0;

                numericUpDownBiayaTukang.Enabled = false;
                numericUpDownBiayaOperasional.Enabled = false;
                numericUpDownPengajuanHarga.Enabled = false;
                numericUpDownJumlahBagian.Enabled = false;
                numericUpDownJumlahSpesifik.Enabled = false;
                numericUpDownTotalBiaya.Enabled = false;

                string hasil = BahanBaku.BacaData("", "", listBahanBaku);
                if (hasil == "1")
                {
                    for (int i = 0; i < listBahanBaku.Count; i++)
                    {
                        comboBoxBahan.Items.Add(listBahanBaku[i].Id + " - " + listBahanBaku[i].Nama);
                    }
                }
                else
                {
                    MessageBox.Show(hasil, "Error");
                }
                string hasil1 = Barang.BacaData("", "", listBarang);
                if (hasil1 == "1")
                {
                    for (int i = 0; i < listBarang.Count; i++)
                    {
                        comboBoxKodeBarang.Items.Add(listBarang[i].Kode + " - " + listBarang[i].Nama);
                    }
                }
                else
                {
                    MessageBox.Show(hasil1, "Error");
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            numericUpDownBiayaTukang.Value = 0;
            numericUpDownBiayaOperasional.Value = 0;
            numericUpDownPengajuanHarga.Value = 0;
            numericUpDownJumlahBagian.Value = 0;
            numericUpDownJumlahSpesifik.Value = 0;
            numericUpDownTotalBiaya.Value = 0;
            comboBoxBahan.Text = "";
            comboBoxKodeBarang.Enabled = false;
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxKodeBarang_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDownBiayaTukang.Enabled = false;
            numericUpDownBiayaOperasional.Enabled = true;
            numericUpDownPengajuanHarga.Enabled = true;
            numericUpDownJumlahBagian.Enabled = true;
            numericUpDownJumlahSpesifik.Enabled = true;
            numericUpDownTotalBiaya.Enabled = false;
        }

        private void comboBoxBahan_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxKodeBarang.Enabled = true;
        }

        private void buttonSimpan_Click_1(object sender, EventArgs e)
        {
            string worked = "1";
            if (dataGridViewBahanBaku.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridViewBahanBaku.Rows.Count - 1; i++)
                {
                    BOM bom = new BOM(dataGridViewBahanBaku.Rows[i].Cells["Bahan"].Value.ToString(),
                        dataGridViewBahanBaku.Rows[i].Cells["Barang"].Value.ToString(),
                        dataGridViewBahanBaku.Rows[i].Cells["Jumlah"].Value.ToString(),
                        dataGridViewBahanBaku.Rows[i].Cells["JumlahSpes"].Value.ToString(),
                        int.Parse(dataGridViewBahanBaku.Rows[i].Cells["TotalBiaya"].Value.ToString()),
                        int.Parse(dataGridViewBahanBaku.Rows[i].Cells["BiayaOperasional"].Value.ToString()),
                        int.Parse(dataGridViewBahanBaku.Rows[i].Cells["BiayaTukang"].Value.ToString()),
                        int.Parse(dataGridViewBahanBaku.Rows[i].Cells["PengajuanHarga"].Value.ToString()));
                    string hasil = BOM.TambahData(bom);
                    if (hasil != "1")
                    {
                        worked = hasil;
                        break;
                    }
                }
            }

            if (worked == "1")
            {
                MessageBox.Show("BOM telah ditambahkan");
            }
            else
            {
                MessageBox.Show("BOM gagal ditambahkan. Pesan error: " + worked);
            }
            comboBoxKodeBarang.Enabled = true;
            dataGridViewBahanBaku.Rows.Clear();
            FormTambahBOM_Load(sender, e);
            frmDaftar.FormDaftarBOM_Load(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxBahan.Text != "" && numericUpDownBiayaOperasional.Value != 0 && numericUpDownBiayaTukang.Value != 0 && 
                numericUpDownJumlahBagian.Value != 0 && numericUpDownPengajuanHarga.Value != 0 && numericUpDownTotalBiaya.Value != 0)
            {
                
                dataGridViewBahanBaku.Rows.Add(listBarang[comboBoxKodeBarang.SelectedIndex].Kode, listBahanBaku[comboBoxBahan.SelectedIndex].Id, listBahanBaku[comboBoxBahan.SelectedIndex].Bagian, listBahanBaku[comboBoxBahan.SelectedIndex].UkuranMentah,
                            listBahanBaku[comboBoxBahan.SelectedIndex].UkuranLuasan, listBahanBaku[comboBoxBahan.SelectedIndex].UkuranJadi, ((int)numericUpDownJumlahBagian.Value).ToString(), ((int)numericUpDownJumlahSpesifik .Value).ToString(),
                            ((int)numericUpDownTotalBiaya.Value).ToString(),
                            ((int)numericUpDownBiayaOperasional.Value).ToString(), ((int)numericUpDownBiayaTukang.Value).ToString(),
                            ((int)numericUpDownPengajuanHarga.Value).ToString());
                
                numericUpDownJumlahBagian.Value = 0;
                numericUpDownJumlahSpesifik.Value = 0;
                comboBoxBahan.Text = "";
                comboBoxKodeBarang.Enabled = false;
             
            }
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

        private void comboBoxKodeBarang_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            numericUpDownBiayaOperasional.Enabled = true;
            numericUpDownBiayaTukang.Enabled = true;
            numericUpDownPengajuanHarga.Enabled = true;
            numericUpDownJumlahBagian.Enabled = true;
            numericUpDownJumlahSpesifik.Enabled = true;
            numericUpDownTotalBiaya.Enabled = false;
        }

        private void buttonKeluar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

     
        private void numericUpDownBiayaOperasional_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void numericUpDownBiayaTukang_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void numericUpDownTotalBiaya_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void numericUpDownBiayaTukang_ValueChanged_1(object sender, EventArgs e)
        {
            numericUpDownTotalBiaya.Value = numericUpDownBiayaOperasional.Value + numericUpDownBiayaTukang.Value;
        }

        private void numericUpDownBiayaOperasional_ValueChanged_1(object sender, EventArgs e)
        {
            numericUpDownTotalBiaya.Value = numericUpDownBiayaOperasional.Value + numericUpDownBiayaTukang.Value;
        }

    
    }
}
