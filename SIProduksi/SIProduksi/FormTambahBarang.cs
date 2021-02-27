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
    public partial class FormTambahBarang : Form
    {
        FormDaftarBarang frmDaftar;
        List<OrderPenjualan> listHasilData = new List<OrderPenjualan>();

        public FormTambahBarang()
        {
            InitializeComponent();
        }

        private void buttonTambahBarang_Click(object sender, EventArgs e)
        {
            try
            {
                Barang b;
                if (comboBoxPO.Text != "")
                {
                    OrderPenjualan o = listHasilData[comboBoxPO.SelectedIndex];
                    b = new Barang(textBoxKodeBarang.Text, textBoxNamaBarang.Text, (int)numericUpDownJumlah.Value, textBoxSatuanBarang.Text, (int)numericUpDownHargaSatuan.Value, richTextBoxKeterangan.Text, o);
                }
                else
                {
                    b = new Barang(textBoxKodeBarang.Text, textBoxNamaBarang.Text, (int)numericUpDownJumlah.Value, textBoxSatuanBarang.Text, (int)numericUpDownHargaSatuan.Value, richTextBoxKeterangan.Text, null);
                }
                string hasil = Barang.TambahData(b);
                if (hasil == "1")
                {
                    if (pictureBoxGambar.BackgroundImage != null)
                    {
                        pictureBoxGambar.BackgroundImage.Save(Application.StartupPath + "\\Images\\Barang\\" + textBoxKodeBarang.Text + ".jpg");
                    }

                    MessageBox.Show("Barang telah ditambahkan");

                    FormTambahBarang_Load(sender, e);
                    frmDaftar.FormDaftarBarang_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Gagal menambahkan barang. Pesan: Kode Barang telah digunakan");
                }
            }
            catch(Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void FormTambahBarang_Load(object sender, EventArgs e)
        {
            frmDaftar = (FormDaftarBarang)this.Owner;

            listHasilData.Clear();
            textBoxKodeBarang.Text = "";
            textBoxNamaBarang.Text = "";
            textBoxSatuanBarang.Text = "";
            numericUpDownHargaSatuan.Value = 0;
            numericUpDownJumlah.Value = 0;
            numericUpDownJumlah.Enabled = false;
            comboBoxPO.Text = "";
            pictureBoxGambar.BackgroundImage = null;
            richTextBoxKeterangan.Text = "";
            string hasil = OrderPenjualan.BacaData("", "", listHasilData);
            if (hasil == "1")
            {
                for (int i = 0; i < listHasilData.Count; i++)
                {
                    comboBoxPO.Items.Add(listHasilData[i].NoOrder + " - " + listHasilData[i].Customer.Nama);
                }
            }
            else
            {
                MessageBox.Show("ERROR");
            }
            
        }

        private void pictureBoxGambar_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pictureBoxGambar.BackgroundImage = new Bitmap(opnfd.FileName);

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pictureBoxGambar.BackgroundImage = new Bitmap(opnfd.FileName);

            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
