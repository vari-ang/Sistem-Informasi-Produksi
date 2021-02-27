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
    public partial class FormUbahBahanBaku : Form
    {
        FormDaftarBahanBaku frmDaftar;
        List<BahanBaku> listHasilData = new List<BahanBaku>();
        List<Supplier> listHasilDataSupplier = new List<Supplier>();

        public FormUbahBahanBaku()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormUbahBahanBaku_Load(object sender, EventArgs e)
        {
            frmDaftar = (FormDaftarBahanBaku)this.Owner;

            textBoxID.Text = "";
            textBoxNama.Text = "";
            textBoxBagian.Text = "";
            textBoxUkuranMentah.Text = "";
            textBoxUkuranLuasan.Text = "";
            textBoxUkuranJadi.Text = "";

            numericUpDownStok.Value = 0;
            numericUpDownStok.Enabled = false;

            numericUpDownHargaSatuan.Value = 0;
            comboBoxSupplier.SelectedIndex = -1;
            comboBoxSupplier.Items.Clear();

            string hasil = Supplier.BacaData("", "", listHasilDataSupplier);
            if (hasil == "1")
            {
                for (int i = 0; i < listHasilDataSupplier.Count; i++)
                {
                    comboBoxSupplier.Items.Add(listHasilDataSupplier[i].IdSupplier + " - " + listHasilDataSupplier[i].Nama);
                }
            }
            else
            {
                MessageBox.Show(hasil, "Error");
            }
        }

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                listHasilData.Clear();
                string hasil = BahanBaku.BacaData("BB.Id", textBoxID.Text, listHasilData);
                if (hasil == "1")
                {
                    textBoxNama.Text = listHasilData[0].Nama;
                    textBoxBagian.Text = listHasilData[0].Bagian;
                    numericUpDownHargaSatuan.Value = listHasilData[0].HargaSatuan;
                    numericUpDownStok.Value = listHasilData[0].Stok;
                    textBoxUkuranJadi.Text = listHasilData[0].UkuranJadi;
                    textBoxUkuranLuasan.Text = listHasilData[0].UkuranLuasan;
                    textBoxUkuranMentah.Text = listHasilData[0].UkuranMentah;
                    if (File.Exists(Application.StartupPath + "\\Images\\BahanBaku\\" + textBoxID.Text + ".jpg"))
                    {
                        Image i = GetCopyImage(Application.StartupPath + "\\Images\\BahanBaku\\" + textBoxID.Text + ".jpg");
                        pictureBox1.BackgroundImage = i;
                    }
                    comboBoxSupplier.Text = listHasilData[0].Supplier.IdSupplier + " - " + listHasilData[0].Supplier.Nama;
                }
                else
                {
                    textBoxID.Text = "";
                    textBoxNama.Text = "";
                    textBoxBagian.Text = "";
                    textBoxUkuranMentah.Text = "";
                    textBoxUkuranLuasan.Text = "";
                    textBoxUkuranJadi.Text = "";

                    numericUpDownStok.Value = 0;
                    numericUpDownStok.Enabled = false;

                    numericUpDownHargaSatuan.Value = 0;
                    comboBoxSupplier.SelectedIndex = -1;
                    comboBoxSupplier.Items.Clear();
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        private Image GetCopyImage(string path)
        {
            using (Image im = Image.FromFile(path))
            {
                Bitmap bm = new Bitmap(im);
                return bm;
            }
        }
        
        private void buttonUbah_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxID.Text != "" && textBoxNama.Text != "" && textBoxBagian.Text != "" &&
                textBoxUkuranMentah.Text != "" && textBoxUkuranLuasan.Text != "" && textBoxUkuranJadi.Text != "" && numericUpDownHargaSatuan.Value != 0)
                {
                    int indexDipilihUser = comboBoxSupplier.SelectedIndex;
                    Supplier s = listHasilDataSupplier[indexDipilihUser];

                    BahanBaku bahan = new BahanBaku(textBoxID.Text, textBoxNama.Text, textBoxBagian.Text, textBoxUkuranMentah.Text
                    , textBoxUkuranLuasan.Text, textBoxUkuranJadi.Text, 0, (int)numericUpDownHargaSatuan.Value, s);

                    string hasil = BahanBaku.UbahData(bahan);
                    if (hasil == "1")
                    {
                        MessageBox.Show("Bahan Baku telah berhasil diubah");
                        if(pictureBox1.BackgroundImage != null)
                        {
                            pictureBox1.BackgroundImage.Save(Application.StartupPath + "\\Images\\BahanBaku\\" + textBoxID.Text + ".jpg");
                        }
                        FormUbahBahanBaku_Load(sender, e);
                        frmDaftar.FormDaftarBahanBaku_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Bahan baku gagal diubah. Pesan: " + hasil);
                    }
                }
                else
                {
                    MessageBox.Show("Pastikan Anda menginputkan semua nilai yang ada ", "Kesalahan");
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
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

        private void button1_Click(object sender, EventArgs e)
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
