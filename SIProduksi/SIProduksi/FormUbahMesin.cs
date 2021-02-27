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
    public partial class FormUbahMesin : Form
    {
        FormDaftarMesin frmDaftar;
        private List<Mesin> listHasilData = new List<Mesin>();
        public FormUbahMesin()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Mesin j = new Mesin(comboBoxidMesin.Text, textBoxNama.Text, int.Parse(textBoxHarga.Text));

                // Panggil static method UbahData di class kategori
                string hasilUbah = Mesin.UbahData(j);

                if (hasilUbah == "1")
                {
                    MessageBox.Show("Data Mesin telah diubah.", "Informasi");
                    if (pictureBoxGambar.BackgroundImage != null)
                    {
                        pictureBoxGambar.BackgroundImage.Save(Application.StartupPath + "\\Images\\Mesin\\" + comboBoxidMesin.Text + ".jpg");
                    }

                    buttonKosongi_Click(sender, e);
                    frmDaftar.FormDaftarMesin_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Gagal mengubah Mesin. Pesan kesalahan: " + hasilUbah);
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxHarga.Text = "";
            
            textBoxNama.Text = "";
        }

        private void FormUbahMesin_Load(object sender, EventArgs e)
        {
            frmDaftar = (FormDaftarMesin)this.Owner;

            listHasilData.Clear();
            string hasil = Mesin.BacaData("","",listHasilData);
            if (hasil == "1")
            {
                comboBoxidMesin.Items.Clear();
                for (int i = 0; i < listHasilData.Count; i++)
                {
                    comboBoxidMesin.Items.Add(listHasilData[i].IdMesin);
                }
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
        private void comboBoxidMesin_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listHasilData.Clear();


                string hasilBaca = Mesin.BacaData("Id", comboBoxidMesin.Text, listHasilData);

                if (hasilBaca == "1")
                {
                    if (listHasilData.Count > 0)
                    {

                        textBoxNama.Text = listHasilData[0].Nama;
                        textBoxHarga.Text = listHasilData[0].HargaBeli.ToString();
                        if (File.Exists(Application.StartupPath + "\\Images\\Mesin\\" + comboBoxidMesin.Text + ".jpg"))
                        {
                            Image s = GetCopyImage(Application.StartupPath + "\\Images\\Mesin\\" + comboBoxidMesin.Text + ".jpg");
                            pictureBoxGambar.BackgroundImage = s;
                        }

                        textBoxNama.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Id Mesin tidak ditemukan. Proses Ubah Data tidak bisa dilakukan.");
                        textBoxNama.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Perintah SQL gagal dijalankan. Pesan kesalahan = " + hasilBaca);
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void buttonUbahFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pictureBoxGambar.BackgroundImage = new Bitmap(opnfd.FileName);

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
    }
}
