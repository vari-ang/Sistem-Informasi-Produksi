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
using System.Text.RegularExpressions;

namespace SIProduksi
{
    public partial class FormTambahCustomer : Form
    {
        FormDaftarCustomer frmDaftar;

        public FormTambahCustomer()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormTambahCustomer_Load(object sender, EventArgs e)
        {
            frmDaftar = (FormDaftarCustomer)this.Owner;

            string kodeTerbaru;
            string hasilGenerate = Customer.GenerateCode(out kodeTerbaru);

            if (hasilGenerate == "1")
            {
                textBoxIdCustomer.Text = kodeTerbaru;

                // buat agar textBoxKodePegawai tidak bisa diakses
                textBoxIdCustomer.Enabled = false;

                // arahkan cursor ke textBoxNamaPegawai
                textBoxNama.Focus();
            }
            else
            {
                MessageBox.Show("Gagal melakukan generate code. Pesan kesalahan: " + hasilGenerate);
            }

            textBoxNama.Text = "";
            textBoxAlamat.Text = "";
            textBoxNomerHp.Text = "";
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            FormTambahCustomer_Load(sender, e);
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxIdCustomer.Text != "" && textBoxNama.Text != "" && textBoxAlamat.Text != "" && textBoxNomerHp.Text != "")
                {
                    int jumHurufNoHP = Regex.Matches(textBoxNomerHp.Text, @"[a-zA-Z]").Count;
                    if (jumHurufNoHP > 0) { MessageBox.Show("Nilai Nomer HP Tidak Boleh Ada Huruf"); }
                    else
                    {
                        // Ciptakan objek yg akan ditambahkan
                        Customer c = new Customer(int.Parse(textBoxIdCustomer.Text), textBoxNama.Text, textBoxAlamat.Text, textBoxNomerHp.Text);

                        // Panggil static method TambahData di class kategori
                        string hasilTambah = Customer.TambahData(c);

                        if (hasilTambah == "1")
                        {
                            MessageBox.Show("Customer telah tersimpan.", "Informasi");

                            frmDaftar.FormDaftarCustomer_Load(sender, e);
                            FormTambahCustomer_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Gagal menambah Customer. Pesan kesalahan: " + hasilTambah);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Tolong isi semua nilai pada text box");
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
