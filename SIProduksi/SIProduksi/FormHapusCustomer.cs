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
    public partial class FormHapusCustomer : Form
    {
        FormDaftarCustomer frmDaftar;
        List<Customer> listHasilData = new List<Customer>();

        public FormHapusCustomer()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormHapusCustomer_Load(object sender, EventArgs e)
        {
            frmDaftar = (FormDaftarCustomer)this.Owner;

            textBoxIdCustomer.Enabled = true;
            textBoxNama.Enabled = false;
            textBoxAlamat.Enabled = false;
            textBoxNomerHp.Enabled = false;
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

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            // Pastikan dulu kepada user apakah akan menghapus data
            DialogResult konfirmasi = MessageBox.Show("Data customer akan terhapus. Apakah Anda yakin ? ", "Konfirmasi", MessageBoxButtons.YesNo);

            if (konfirmasi == System.Windows.Forms.DialogResult.Yes) // Jika user yakin menghapus data
            {
                try
                {
                    int id = int.Parse(textBoxIdCustomer.Text);
                    string nama = textBoxNama.Text;
                    string alamat = textBoxAlamat.Text;
                    string nomerHp = textBoxNomerHp.Text;

                    Customer c = new Customer(id, nama, alamat, nomerHp);

                    // Panggil static method HapusData di class kategori
                    string hasilHapus = Customer.HapusData(c);

                    if (hasilHapus == "1")
                    {
                        MessageBox.Show("Customer telah dihapus.", "Informasi");

                        buttonKosongi_Click(sender, e);
                        frmDaftar.FormDaftarCustomer_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Gagal menghapus pelanggan. Pesan kesalahan : " + hasilHapus);
                    }
                }
                catch(Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }            
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {

        }
    }
}
