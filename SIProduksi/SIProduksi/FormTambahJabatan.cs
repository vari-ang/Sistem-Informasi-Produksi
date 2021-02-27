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
    public partial class FormTambahJabatan : Form
    {
        FormDaftarJabatan frmDaftar;
        private List<Jabatan> listDataJabatan = new List<Jabatan>();
        

        public FormTambahJabatan()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormTambahJabatan_Load(object sender, EventArgs e)
        {
            
            frmDaftar = (FormDaftarJabatan)this.Owner;

            string idTerbaru;
            string hasilGenerate = Jabatan.GenerateCode(out idTerbaru);

            if (hasilGenerate == "1")
            {
                textBoxIdJabatan.Text = idTerbaru;

                // buat agar textBoxIdJabatan tidak bisa diakses
                textBoxIdJabatan.Enabled = false;

                // arahkan cursor ke textBoxNamaKategori
                textBoxNamaJabatan.Focus();
            }
            else
            {
                MessageBox.Show("Gagal melakukan generate code. Pesan kesalahan: " + hasilGenerate);
            }
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxNamaJabatan.Text != "")
                {
                    // Ciptakan objek yg akan ditambahkan
                    Jabatan j = new Jabatan(textBoxIdJabatan.Text, textBoxNamaJabatan.Text);

                    // Panggil static method TambahData di class kategori
                    string hasilTambah = Jabatan.TambahData(j);

                    if (hasilTambah == "1")
                    {
                        MessageBox.Show("Jabatan telah tersimpan.", "Informasi");

                        buttonKosongi_Click(sender, e);
                        frmDaftar.FormDaftarJabatan_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Gagal menambah jabatan. Pesan kesalahan: " + hasilTambah);
                    }
                }
                else
                {
                    MessageBox.Show("Nama jabatan harus diisi");
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxIdJabatan.Text = "";
            textBoxNamaJabatan.Text = "";
        }
    }
}
