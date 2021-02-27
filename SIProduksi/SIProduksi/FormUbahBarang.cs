using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Produksi_LIB;

namespace SIProduksi
{
    public partial class FormUbahBarang : Form
    {
        FormDaftarBarang frmDaftar;
        List<Barang> listHasilData = new List<Barang>();
        public FormUbahBarang()
        {
            InitializeComponent();
        }

        private void buttonUbahData_Click(object sender, EventArgs e)
        {
            try
            {
                Barang b = new Barang(comboBoxKodeBarang.Text, textBoxNama.Text, (int)numericUpDownJumlah.Value, textBoxSatuan.Text, (int)numericUpDownHargaSatuan.Value, textBoxKeterangan.Text, new OrderPenjualan());

                string hasil = Barang.UbahData(b);
                if (hasil == "1")
                {
                    MessageBox.Show("Barang telah diubah");
                    if (pictureBox1.BackgroundImage != null)
                    {
                        pictureBox1.BackgroundImage.Save(Application.StartupPath + "\\Images\\Barang\\" + comboBoxKodeBarang.Text + ".jpg");
                    }
                    textBoxIdOrder.Text = "";
                    textBoxKeterangan.Text = "";
                    textBoxSatuan.Text = "";
                    textBoxNama.Text = "";
                    numericUpDownJumlah.Value = 0;
                    numericUpDownHargaSatuan.Value = 0;

                    frmDaftar.FormDaftarBarang_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Barang gagal diubah. Pesan : " + hasil);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public void FormUbahBarang_Load(object sender, EventArgs e)
        {
            frmDaftar = (FormDaftarBarang)this.Owner;

            listHasilData.Clear();

            string hasil = Barang.BacaData("", "", listHasilData);
            if (hasil == "1")
            {
                for (int i = 0; i < listHasilData.Count; i++)
                {
                    comboBoxKodeBarang.Items.Add(listHasilData[i].Kode);
                }
            }

            //textBoxIdOrder.Enabled = false;
            //textBoxKeterangan.Enabled = false;
            //textBoxSatuan.Enabled = false;
            //textBoxNama.Enabled = false;
            //numericUpDownJumlah.Enabled = false;
            //numericUpDownHargaSatuan.Enabled = false;
        }

        private void textBoxIdPekerja_TextChanged(object sender, EventArgs e)
        {
           
        }
        private Image GetCopyImage(string path)
        {
            using (Image im = Image.FromFile(path))
            {
                Bitmap bm = new Bitmap(im);
                return bm;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listHasilData.Clear();
                string hasil = Barang.BacaData("kode", comboBoxKodeBarang.Text, listHasilData);
                if (hasil == "1")
                {
                    if (listHasilData.Count > 0)
                    {
                        textBoxNama.Text = listHasilData[0].Nama;
                        textBoxSatuan.Text = listHasilData[0].Satuan;
                        numericUpDownJumlah.Value = listHasilData[0].Jumlah;
                        numericUpDownHargaSatuan.Value = listHasilData[0].HargaSatuan;
                        textBoxKeterangan.Text = listHasilData[0].Keterangan;
                        if (File.Exists(Application.StartupPath + "\\Images\\Barang\\" + comboBoxKodeBarang.Text + ".jpg"))
                        {
                            Image s = GetCopyImage(Application.StartupPath + "\\Images\\Barang\\" + comboBoxKodeBarang.Text + ".jpg");
                            pictureBox1.BackgroundImage = s;
                        }
                        //textBoxIdOrder.Text = listHasilData[0].OrderPenjualan.NoOrder;
                        textBoxNama.Focus();
                    }
                }
                else
                {
                    textBoxIdOrder.Text = "";
                    textBoxKeterangan.Text = "";
                    textBoxSatuan.Text = "";
                    textBoxNama.Text = "";
                    numericUpDownJumlah.Value = 0;
                    numericUpDownHargaSatuan.Value = 0;
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackgroundImage = new Bitmap(opnfd.FileName);

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackgroundImage = new Bitmap(opnfd.FileName);

            }
        }
    }
}
