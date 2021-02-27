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
    public partial class FormTambahSPK : Form
    {
        FormDaftarSPK frmDaftar;
        List<Pekerja> ListDatapeg = new List<Pekerja>();
        List<Barang> listdatabarang = new List<Barang>();
        List<OrderPenjualan> listorderpenjualan = new List<OrderPenjualan>();
   
        public FormTambahSPK()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormTambahSPK_Load(object sender, EventArgs e)
        {
            frmDaftar = (FormDaftarSPK)this.Owner;

            try
            {
                string codebaru;
                string hasilgen = Spk.GenerateCode(out codebaru);
                if (hasilgen == "1")
                {
                    textBoxNoSPK.Text = codebaru;
                    textBoxNoSPK.Enabled = false;

                }
                else
                {
                    MessageBox.Show("Gagal melakukan generate code. Pesan kesalahan: " + hasilgen);
                }

                ListDatapeg.Clear();
                listdatabarang.Clear();

                string hasilbaca2 = OrderPenjualan.BacaData("", "", listorderpenjualan);
                if(hasilbaca2 == "1")
                {
                    comboBox1.Items.Clear();
                    for(int i = 0; i < listorderpenjualan.Count; i++)
                    {
                        comboBox1.Items.Add(listorderpenjualan[i].NoOrder);
                    }
                }
                
                string hasilBaca3 = Pekerja.BacaData("", "", ListDatapeg);
  

                if (hasilBaca3 == "1")
                {
                    comboBoxPekerja.Items.Clear();
                    for (int i = 0; i < ListDatapeg.Count; i++)
                    {
                        comboBoxPekerja.Items.Add(ListDatapeg[i].IdPekerja + " . " + ListDatapeg[i].Nama);
                    }
                }
                else
                {
                    MessageBox.Show("Data Pekerja gagal ditampilkan. Pesan kesalahan: " + hasilBaca3);
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        Barang op;
        private void buttonSimpan_Click(object sender, EventArgs e)
        {

            try
            {
                int indexpeg = comboBoxPekerja.SelectedIndex;
                //int indexDipilihUser = comboBoxNoPo.SelectedIndex;
                for(int i = 0; i < listdatabarang.Count; i++)
                {
                    if (comboBoxNoPo.Text == (listdatabarang[i].Kode + " - " + listdatabarang[i].Nama))
                    {
                        op = listdatabarang[i];
                    }
                }
              
                Pekerja p = ListDatapeg[indexpeg];

                Spk s = new Spk(textBoxNoSPK.Text, dateTimePickerdt.Value, op, p, textBoxPekerjaan.Text, textBoxLokasi.Text, int.Parse(textBoxBiaya.Text), textBoxLamaKerja.Text, textBoxSyarat.Text, comboBoxMetode.Text);
                string hasilTambah = Spk.TambahData(s);

                if (hasilTambah == "1")
                {
                    MessageBox.Show("SPK telah tersimpan.", "Informasi");

                    frmDaftar.FormDaftarSPK_Load(sender, e);
                    buttonKosongi_Click(sender, e);

                }
                else
                {
                    MessageBox.Show("Gagal menambah SPK. Pesan kesalahan: " + hasilTambah);
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxBiaya.Text = "";
            textBoxLamaKerja.Text = "";
            textBoxLokasi.Text = "";
            textBoxPekerjaan.Text = "";
            textBoxSyarat.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bc = comboBox1.Text;
            listdatabarang.Clear();
            string hasilBaca2 = Barang.BacaData("id_order_penjualan", bc, listdatabarang);
            if (hasilBaca2 == "1")
            {
                comboBoxNoPo.Items.Clear();
                for (int i = 0; i < listdatabarang.Count; i++)
                {
                    comboBoxNoPo.Items.Add(listdatabarang[i].Kode + " - " + listdatabarang[i].Nama);
                }
            }
            else
            {
                MessageBox.Show("Data Barang gagal ditampilkan. Pesan kesalahan: " + hasilBaca2);
            }
        }
    }
}
