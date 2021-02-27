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
    public partial class FormTambahPenerimaan : Form
    {
        public FormTambahPenerimaan()
        {
            InitializeComponent();
        }
        List<Pengiriman> listHasilData = new List<Pengiriman>();
        FormDaftarPenerimaan frmDaftar;

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxNomor.Text = "";
            textBoxNama.Text = "";
            textBoxAlamat.Text = "";
            richTextBoxKeterangan.Text = "";
            comboBoxNomorPengiriman.SelectedIndex = -1;
        }


        private void buttonTambahBarang_Click(object sender, EventArgs e)
        {
            int indexDipilihUser = comboBoxNomorPengiriman.SelectedIndex;
            Pengiriman p = listHasilData[indexDipilihUser];

            Penerimaan PT = new Penerimaan(textBoxNomor.Text, p, dateTimePickerTanggal.Value, textBoxNama.Text, textBoxAlamat.Text, richTextBoxKeterangan.Text);

            string hasilTambah = Penerimaan.TambahData(PT);

            if (hasilTambah == "1")
            {
                if (pictureBoxGambar.BackgroundImage != null)
                {
                    pictureBoxGambar.BackgroundImage.Save(Application.StartupPath + "\\Images\\Penerimaan\\" + textBoxNomor.Text + ".jpg");
                }
                MessageBox.Show("Jabatan telah tersimpan.", "Informasi");

                frmDaftar.FormDaftarPenerimaan_Load_1(sender, e);
                buttonKosongi_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Gagal menambah jabatan. Pesan kesalahan: " + hasilTambah);
            }
        }

        private void FormTambahPenerimaan_Load_1(object sender, EventArgs e)
        {
            frmDaftar = (FormDaftarPenerimaan)this.Owner;

            listHasilData.Clear();
            string hasilBaca = Pengiriman.BacaData("", "", listHasilData);

            if (hasilBaca == "1")
            {
                comboBoxNomorPengiriman.Items.Clear();
                for (int i = 0; i < listHasilData.Count; i++)
                {
                    comboBoxNomorPengiriman.Items.Add(listHasilData[i].NomorDokumen);
                }
            }
            else
            {
                MessageBox.Show("Data Jabatan gagal ditampilkan. Pesan kesalahan: " + hasilBaca);
            }
        }

        private void pictureBoxGambar_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pictureBoxGambar.BackgroundImage = new Bitmap(opnfd.FileName);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pictureBoxGambar.BackgroundImage = new Bitmap(opnfd.FileName);

            }
        }
    }
}
