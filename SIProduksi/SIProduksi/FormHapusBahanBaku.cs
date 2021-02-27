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
    public partial class FormHapusBahanBaku : Form
    {
        FormDaftarBahanBaku frmDaftar;
        List<BahanBaku> listHasilData = new List<BahanBaku>();

        public FormHapusBahanBaku()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormHapusBahanBaku_Load(object sender, EventArgs e)
        {
            frmDaftar = (FormDaftarBahanBaku)this.Owner;

            textBoxID.Text = "";
            textBoxNama.Text = "";
            textBoxBagian.Text = "";
            textBoxUkuranMentah.Text = "";
            textBoxUkuranLuasan.Text = "";
            textBoxUkuranJadi.Text = "";
            textBoxSupplier.Text = "";

            textBoxNama.Enabled = false;
            textBoxBagian.Enabled = false;
            textBoxUkuranMentah.Enabled = false;
            textBoxUkuranLuasan.Enabled = false;
            textBoxUkuranJadi.Enabled = false;
            textBoxSupplier.Enabled = false;

            numericUpDownStok.Value = 0;
            numericUpDownStok.Enabled = false;

            numericUpDownHargaSatuan.Value = 0;         
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
                        pictureBoxGambar.BackgroundImage = new Bitmap(Application.StartupPath + "\\Images\\BahanBaku\\" + textBoxID.Text + ".jpg");
                    }
                    textBoxSupplier.Text = listHasilData[0].Supplier.IdSupplier + " - " + listHasilData[0].Supplier.Nama;
                }
                else
                {
                    textBoxID.Text = "";
                    textBoxNama.Text = "";
                    textBoxBagian.Text = "";
                    textBoxUkuranMentah.Text = "";
                    textBoxUkuranLuasan.Text = "";
                    textBoxUkuranJadi.Text = "";
                    textBoxSupplier.Text = "";

                    numericUpDownStok.Value = 0;
                    numericUpDownStok.Enabled = false;

                    numericUpDownHargaSatuan.Value = 0;
                }
            }
            catch(Exception exc)
            {
                
            }
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            try
            {
                string hasil = BahanBaku.HapusData(textBoxID.Text);
                if (hasil == "1")
                {
                    MessageBox.Show("Barang telah dihapus");

                    FormHapusBahanBaku_Load(sender, e);
                    frmDaftar.FormDaftarBahanBaku_Load(sender, e);                   
                }
                else
                {
                    MessageBox.Show("Barang gagal dihapus. Pesan : " + hasil);
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
