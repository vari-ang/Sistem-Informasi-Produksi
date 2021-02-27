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
using System.Text.RegularExpressions;

using Produksi_LIB;

namespace SIProduksi
{
    public partial class FormUbahPekerja : Form
    {
        FormDaftarPekerja frmDaftar;
        private List<Pekerja> listHasilData = new List<Pekerja>();
        private List<Jabatan> listHasilDataJabatan = new List<Jabatan>();

        public FormUbahPekerja()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormUbahPekerja_Load(object sender, EventArgs e)
        {
            frmDaftar = (FormDaftarPekerja)this.Owner;
            
            textBoxNama.MaxLength = 45;
            textBoxAlamat.MaxLength = 150;

            textBoxIdPekerja.Text = "";
            textBoxNama.Text = "";
            textBoxAlamat.Text = "";
            textBoxNomerHp.Text = "";
            comboBoxJabatan.SelectedIndex = -1;

            textBoxIdPekerja.Focus();

            string hasil = Jabatan.BacaData("", "", listHasilDataJabatan);
            if (hasil == "1")
            {
                for (int i = 0; i < listHasilDataJabatan.Count; i++)
                {
                    comboBoxJabatan.Items.Add(listHasilDataJabatan[i].IdJabatan + " - " + listHasilDataJabatan[i].NamaJabatan);
                }
            }
            else
            {
                MessageBox.Show(hasil, "Error");
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            FormUbahPekerja_Load(sender, e);
        }
        private Image GetCopyImage(string path)
        {
            using (Image im = Image.FromFile(path))
            {
                Bitmap bm = new Bitmap(im);
                return bm;
            }
        }
        private void textBoxIdPekerja_TextChanged(object sender, EventArgs e)
        {
            listHasilData.Clear();

            string hasilBaca = Pekerja.BacaData("P.Id", textBoxIdPekerja.Text, listHasilData);
            if (hasilBaca == "1")
            {
                if (listHasilData.Count > 0)
                {
                    textBoxNama.Text = listHasilData[0].Nama;
                    textBoxAlamat.Text = listHasilData[0].Alamat;
                    textBoxNomerHp.Text = listHasilData[0].NomerHp.ToString();
                    if (File.Exists(Application.StartupPath + "\\Images\\Pekerja\\" + textBoxIdPekerja.Text + ".jpg"))
                    {
                        Image m = GetCopyImage(Application.StartupPath + "\\Images\\Pekerja\\" + textBoxIdPekerja.Text + ".jpg");
                        pictureBox1.BackgroundImage = m;
                    }
                    comboBoxJabatan.Text = listHasilData[0].Jabatan.IdJabatan + " - " + listHasilData[0].Jabatan.NamaJabatan;
                    textBoxNama.Focus();
                }
            }
            else
            {
                textBoxNama.Text = "";
                textBoxAlamat.Text = "";
                textBoxNomerHp.Text = "";
            }
        }

        private void buttonUbahData_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxIdPekerja.Text != "" && textBoxNama.Text != "" && textBoxAlamat.Text != "" &&
                    textBoxNomerHp.Text != "" && comboBoxJabatan.SelectedIndex != -1)
                {
                    int indexDipilihUser = comboBoxJabatan.SelectedIndex;
                    Jabatan jabatan = listHasilDataJabatan[indexDipilihUser];

                    int jumHurufNoHP = Regex.Matches(textBoxNomerHp.Text, @"[a-zA-Z]").Count;
                    if (jumHurufNoHP > 0) { MessageBox.Show("Nilai Nomer HP Tidak Boleh Ada Huruf"); }
                    else
                    {
                        Pekerja p = new Pekerja(int.Parse(textBoxIdPekerja.Text), textBoxNama.Text, textBoxAlamat.Text, textBoxNomerHp.Text, jabatan, "", "");

                        string hasilUbah = Pekerja.UbahData(p);

                        if (hasilUbah == "1")
                        {
                            MessageBox.Show("Data pekerja telah terubah", "Informasi");
                            if (pictureBox1.BackgroundImage != null)
                            {
                                pictureBox1.BackgroundImage.Save(Application.StartupPath + "\\Images\\Pekerja\\" + textBoxIdPekerja.Text + ".jpg");
                            }
                            FormUbahPekerja_Load(sender, e);
                            frmDaftar.FormDaftarPekerja_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Gagal mengubah data pekerja. Pesan kesalahan: " + hasilUbah);
                        }
                    }
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
