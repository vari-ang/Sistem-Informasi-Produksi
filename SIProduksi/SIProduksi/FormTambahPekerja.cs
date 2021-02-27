using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using Produksi_LIB;

namespace SIProduksi
{
    public partial class FormTambahPekerja : Form
    {
        FormDaftarPekerja frmDaftar;
        private List<Jabatan> listDataJabatan = new List<Jabatan>();

        public FormTambahPekerja()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormTambahPekerja_Load(object sender, EventArgs e)
        {
            frmDaftar = (FormDaftarPekerja)this.Owner;

            pictureBox1.BackgroundImage = null;
            textBoxIdPekerja.Enabled = false;
            textBoxNama.MaxLength = 45;
            textBoxAlamat.MaxLength = 250;
       
            textBoxNama.Text = "";
            textBoxAlamat.Text = "";
            textBoxNomerHp.Text = "";
            comboBoxJabatan.SelectedIndex = -1;

            string kodeTerbaru;
            string hasilGenerate = Pekerja.GenerateCode(out kodeTerbaru);

            if (hasilGenerate == "1")
            {
                textBoxIdPekerja.Text = kodeTerbaru;
                textBoxIdPekerja.Enabled = false;
                textBoxNama.Focus();
            }
            else
            {
                MessageBox.Show("Gagal melakukan generate code. Pesan kesalahan: " + hasilGenerate);
            }

            listDataJabatan.Clear();
            string hasilBaca = Jabatan.BacaData("", "", listDataJabatan);

            if (hasilBaca == "1")
            {
                comboBoxJabatan.Items.Clear();
                for (int i = 0; i < listDataJabatan.Count; i++)
                {
                    // Tampilkan dengan format kode kategori - nama kategori
                    comboBoxJabatan.Items.Add(listDataJabatan[i].IdJabatan + " . " + listDataJabatan[i].NamaJabatan);
                }
            }
            else
            {
                MessageBox.Show("Data Jabatan gagal ditampilkan. Pesan kesalahan: " + hasilBaca);
            }
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {              
                if (textBoxIdPekerja.Text != "" && textBoxNama.Text != "" && textBoxAlamat.Text != "" && 
                    textBoxNomerHp.Text != "" && comboBoxJabatan.SelectedIndex != -1)
                {
                    int indexDipilihUser = comboBoxJabatan.SelectedIndex;
                    Jabatan j = listDataJabatan[indexDipilihUser];

                    int jumHurufNoHP = Regex.Matches(textBoxNomerHp.Text, @"[a-zA-Z]").Count;
                    if (jumHurufNoHP > 0) { MessageBox.Show("Nilai Nomer HP Tidak Boleh Ada Huruf"); }
                    else
                    {
                        int idPekerja = int.Parse(textBoxIdPekerja.Text);
                        Pekerja p = new Pekerja(idPekerja, textBoxNama.Text, textBoxAlamat.Text, textBoxNomerHp.Text, j, "", "");

                        string hasilTambah = Pekerja.TambahData(p);

                        if (hasilTambah == "1")
                        {
                            if (pictureBox1.BackgroundImage != null)
                            {
                                pictureBox1.BackgroundImage.Save(Application.StartupPath + "\\Images\\Pekerja\\" + textBoxIdPekerja.Text + ".jpg");
                            }
                            MessageBox.Show("Pekerja telah tersimpan.", "Informasi");

                            FormTambahPekerja_Load(sender, e);
                            frmDaftar.FormDaftarPekerja_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Gagal menambah pekerja. Pesan kesalahan: " + hasilTambah);
                        }
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

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            FormTambahPekerja_Load(sender, e);
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
