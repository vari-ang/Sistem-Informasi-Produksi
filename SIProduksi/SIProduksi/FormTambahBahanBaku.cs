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
    public partial class FormTambahBahanBaku : Form
    {
        FormDaftarBahanBaku frmDaftar;
        List<BahanBaku> listHasilData = new List<BahanBaku>();
        List<Supplier> listHasilDataSupplier = new List<Supplier>();

        public FormTambahBahanBaku()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void FormTambahBahanBaku_Load(object sender, EventArgs e)
        {
            frmDaftar = (FormDaftarBahanBaku)this.Owner;
            pictureBox1.BackgroundImage = null;
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

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            FormTambahBahanBaku_Load(sender, e);
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxID.Text != "" && textBoxNama.Text != "" && textBoxBagian.Text != "" &&
                textBoxUkuranMentah.Text != "" && textBoxUkuranLuasan.Text != "" && textBoxUkuranJadi.Text != "" &&
                numericUpDownHargaSatuan.Value != 0 && comboBoxSupplier.SelectedIndex != -1 && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
                {
                    int indexDipilihUser = comboBoxSupplier.SelectedIndex;
                    Supplier s = listHasilDataSupplier[indexDipilihUser];
                    string ukuranmentah = textBoxUkuranLuasan.Text + " " + comboBox2.Text;
                    string ukuranluasan = textBoxUkuranJadi.Text + " " + comboBox3.Text;
                    string ukuranjadi = textBoxUkuranMentah.Text + " " + comboBox1.Text;
                    BahanBaku bahan = new BahanBaku(textBoxID.Text, textBoxNama.Text.ToUpper(), textBoxBagian.Text, ukuranmentah
                    , ukuranluasan, ukuranjadi, 0, (int)numericUpDownHargaSatuan.Value, s);

                    string hasil = BahanBaku.TambahData(bahan);
                    if (hasil == "1")
                    {
                        if(pictureBox1.BackgroundImage != null)
                        {
                            pictureBox1.BackgroundImage.Save(Application.StartupPath + "\\Images\\BahanBaku\\" + textBoxID.Text + ".jpg");
                        }
                        MessageBox.Show("Bahan Baku telah berhasil ditambah");

                        FormTambahBahanBaku_Load(sender, e);
                        frmDaftar.FormDaftarBahanBaku_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Bahan baku gagal ditambahkan. Pesan: ID telah digunakan");
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
