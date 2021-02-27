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
    public partial class FormUbahBOM : Form
    {
        List<BOM> listHasilData = new List<BOM>();
        List<Barang> listbarang = new List<Barang>();
        public FormUbahBOM()
        {
            InitializeComponent();
        }
        public void FormUbahBOM_Load(object sender, EventArgs e)
        {
            comboBox2.Enabled = false;
            comboBox2.Items.Clear();
            comboBox1.Items.Clear();
            listHasilData.Clear();

            numericUpDownTotalBiaya.Value = 0;
            numericUpDownBiayaOperasional.Value = 0;
            numericUpDownPengajuanHarga.Value = 0;
            numericUpDownJumlahBagian.Value = 0;
            numericUpDownJumlahSpesifik.Value = 0;

            string hasil = BOM.BacaData("", "", listHasilData);
            if(hasil =="1")
            {
                string previd = "";
                for(int i=0; i<listHasilData.Count; i++)
                {
                    if (listHasilData[i].Kodebarang != previd)
                    {
                        comboBox1.Items.Add(listHasilData[i].Kodebarang);
                    }
                    
                    previd = listHasilData[i].Kodebarang;
                }
            }

            numericUpDownTotalBiaya.Enabled = false;
            numericUpDownBiayaOperasional.Enabled = false;
            numericUpDownBiayaTukang.Enabled = false;
            numericUpDownPengajuanHarga.Enabled = false;
            numericUpDownJumlahBagian.Enabled = false;
            numericUpDownJumlahSpesifik.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = true;
            List<Barang> li = new List<Barang>();
            li.Clear();
            string hasils = Barang.BacaData("kode", comboBox1.Text, li);
            if (hasils == "1")
            {
                for (int i = 0; i < listHasilData.Count; i++)
                {
                    if (listHasilData[i].Kodebarang == li[0].Kode)
                    {
                        comboBox2.Items.Add(listHasilData[i].IdbahanBaku);
                    }
                }
            }
            
            if (comboBox2.Text != "")
            {
                List<BOM> l = new List<BOM>();
                l.Clear();
                string hasil = BOM.BacaData("kode_barang", "id_bahan_baku", comboBox1.Text, comboBox2.Text, l);
                if(hasil == "1")
                {
                    numericUpDownTotalBiaya.Enabled = false;
                    numericUpDownBiayaOperasional.Enabled = true;
                    numericUpDownBiayaTukang.Enabled = true;
                    numericUpDownPengajuanHarga.Enabled = true;
                    numericUpDownJumlahBagian.Enabled = true;
                    numericUpDownJumlahSpesifik.Enabled = true;

                    numericUpDownTotalBiaya.Value = (int)l[0].TotalBiaya;
                    numericUpDownPengajuanHarga.Value = l[0].PengajuanHarga;
                    numericUpDownJumlahBagian.Value = int.Parse(l[0].JumlahBagian);
                    numericUpDownBiayaTukang.Value = (int)l[0].BiayaTukang;
                    numericUpDownJumlahSpesifik.Value = int.Parse(l[0].JumlahBijiLembarBatang);
                    numericUpDownBiayaOperasional.Value = int.Parse(l[0].BiayaOperasional.ToString());
                    comboBox2.Enabled = false;
                    comboBox1.Enabled = false;
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                List<BOM> l = new List<BOM>();
                l.Clear();
                string hasil = BOM.BacaData("kode_barang", "id_bahan_baku", comboBox1.Text, comboBox2.Text, l);
                if (hasil == "1")
                {
                    comboBox2.Enabled = false;
                    comboBox1.Enabled = false;
             
                    numericUpDownBiayaOperasional.Enabled = true;
                    numericUpDownBiayaTukang.Enabled = true;
                    numericUpDownPengajuanHarga.Enabled = true;
                    numericUpDownJumlahBagian.Enabled = true;
                    numericUpDownJumlahSpesifik.Enabled = true;

                    numericUpDownTotalBiaya.Value = (int)l[0].TotalBiaya;
                    numericUpDownPengajuanHarga.Value = l[0].PengajuanHarga;
                    numericUpDownJumlahBagian.Value = int.Parse(l[0].JumlahBagian);
                    numericUpDownJumlahSpesifik.Value = int.Parse(l[0].JumlahBijiLembarBatang);
                    numericUpDownBiayaOperasional.Value = int.Parse(l[0].BiayaOperasional.ToString());
                    numericUpDownBiayaTukang.Value = int.Parse(l[0].BiayaTukang.ToString());
                }
            }
        }

        private void buttonUbahData_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text != "" && comboBox2.Text != "")
            {
                BOM b = new BOM(comboBox2.Text, comboBox1.Text, numericUpDownJumlahBagian.Value.ToString(), 
                    numericUpDownJumlahSpesifik.Value.ToString(), (int)numericUpDownTotalBiaya.Value, (int)numericUpDownBiayaOperasional.Value,
                    (int)numericUpDownBiayaTukang.Value, (int)numericUpDownPengajuanHarga.Value);

                string hasil = BOM.UbahData(b);
                if (hasil == "1")
                {
                    MessageBox.Show("BOM telah diubah");
                    FormDaftarBOM d = (FormDaftarBOM)this.Owner;
                    d.FormDaftarBOM_Load(sender, e);
                    comboBox2.Enabled = true;
                    comboBox1.Enabled = true;
                    comboBox1.Text = "";
                    comboBox2.Text = "";

                    numericUpDownTotalBiaya.Value = 0;
                    numericUpDownBiayaOperasional.Value = 0;
                    numericUpDownPengajuanHarga.Value = 0;
                    numericUpDownJumlahBagian.Value = 0;
                    numericUpDownJumlahSpesifik.Value = 0;

                    numericUpDownBiayaOperasional.Enabled = false;
                    numericUpDownBiayaTukang.Enabled = false;
                    numericUpDownPengajuanHarga.Enabled = false;
                    numericUpDownJumlahBagian.Enabled = false;
                    numericUpDownJumlahSpesifik.Enabled = false;
                    FormUbahBOM_Load(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Silahkan mengisi data yang dibutuhkan terlebih dahulu");
            }
            
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numericUpDownBiayaOperasional.Value = 0;
            numericUpDownBiayaTukang.Value = 0;
            numericUpDownPengajuanHarga.Value = 0;
            numericUpDownJumlahBagian.Value = 0;
            numericUpDownJumlahSpesifik.Value = 0;
            comboBox2.Enabled = true;
            comboBox1.Enabled = true;
            comboBox1.Text = "";
            comboBox2.Text = "";
          
            numericUpDownBiayaOperasional.Enabled = false;
            numericUpDownBiayaTukang.Enabled = false;
            numericUpDownPengajuanHarga.Enabled = false;
            numericUpDownJumlahBagian.Enabled = false;
            numericUpDownJumlahSpesifik.Enabled = false;
            FormUbahBOM_Load(sender, e);
        }

        private void numericUpDownBiayaOperasional_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownTotalBiaya.Value = numericUpDownBiayaOperasional.Value + numericUpDownBiayaTukang.Value;
        }


        private void numericUpDownBiayaTukang_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownTotalBiaya.Value = numericUpDownBiayaOperasional.Value + numericUpDownBiayaTukang.Value;
        }
    }
}
