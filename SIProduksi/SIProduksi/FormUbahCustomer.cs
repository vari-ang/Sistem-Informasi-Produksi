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
    public partial class FormUbahCustomer : Form
    {
        FormDaftarCustomer frmDaftar;
        List<Customer> listHasilData = new List<Customer>();

        public FormUbahCustomer()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormUbahCustomer_Load(object sender, EventArgs e)
        {
            frmDaftar = (FormDaftarCustomer)this.Owner;
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxIdCustomer.Text = "";
            textBoxNama.Text = "";
            textBoxAlamat.Text = "";
            textBoxNomerHp.Text = "";
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxIdCustomer.Text != "" && textBoxNama.Text != "" && textBoxAlamat.Text != "" && textBoxNomerHp.Text != "")
                {
                    int jumHurufNoHP = Regex.Matches(textBoxNomerHp.Text, @"[a-zA-Z]").Count;
                    if (jumHurufNoHP > 0) { MessageBox.Show("Nilai Nomer HP Tidak Boleh Ada Huruf"); }
                    else
                    {
                        Customer c = new Customer(int.Parse(textBoxIdCustomer.Text), textBoxNama.Text, textBoxAlamat.Text, textBoxNomerHp.Text);

                        // Panggil static method UbahData di class kategori
                        string hasilUbah = Customer.UbahData(c);

                        if (hasilUbah == "1")
                        {
                            MessageBox.Show("Data Customer telah diubah.", "Informasi");

                            buttonKosongi_Click(sender, e);
                            frmDaftar.FormDaftarCustomer_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Gagal mengubah Customer. Pesan kesalahan: " + hasilUbah);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Tolong isi semua nilai pada text box");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void textBoxIdCustomer_TextChanged(object sender, EventArgs e)
        {
            listHasilData.Clear();

            string hasilBaca = Customer.BacaData("Id", textBoxIdCustomer.Text, listHasilData);
            if (hasilBaca == "1")
            {
                if (listHasilData.Count > 0)
                {
                    textBoxNama.Text = listHasilData[0].Nama;
                    textBoxAlamat.Text = listHasilData[0].Alamat;
                    textBoxNomerHp.Text = listHasilData[0].NomerHp;

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
    }
}
