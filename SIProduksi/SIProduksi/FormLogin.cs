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
    public partial class FormLogin : Form
    {
        public List<Pekerja> listHasilData = new List<Pekerja>();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.Height = 50 + panelLogin.Height;

            // Beri nilai awal server dan database
            textBoxServer.Text = "localhost";
            textBoxDatabase.Text = "si_produksi_ti";

            textBoxPassword.PasswordChar = Convert.ToChar("*");
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text != "")
            {
                // Create objek bertipe Koneksi dengan memanggil constructor berparameter milik class Koneksi
                Koneksi k = new Koneksi(textBoxServer.Text, textBoxDatabase.Text, textBoxUsername.Text, textBoxPassword.Text);

                string hasilConnect = k.Connect(); // panggil method Conenct milik class Koneksi

                if (hasilConnect == "sukses")
                {
                    FormUtama frmUtama = (FormUtama)this.Owner;
                    frmUtama.getNotif();
                    frmUtama.tampilTotalPenjuatan();
                    frmUtama.Enabled = true; // Agar form utama bisa diakses
                    MessageBox.Show("Selamat datang di Sistem Informasi Produksi Teaching Industry", "Info"); // tampilkan ucapan selamat datang

                    listHasilData.Clear();
                    string hasilCariPegawai = Pekerja.BacaData("username", textBoxUsername.Text, listHasilData);
                    if (hasilCariPegawai == "1")
                    {
                        Console.WriteLine(listHasilData);
                        if (listHasilData.Count > 0)
                        {
                            frmUtama.Enabled = true;

                            frmUtama.labelKodePegawai.Text = listHasilData[0].IdPekerja.ToString();
                            frmUtama.labelNamaPegawai.Text = listHasilData[0].Nama;
                            frmUtama.labelJabatanPegawai.Text = listHasilData[0].Jabatan.NamaJabatan;

                            this.Close(); // Tutup form login
                        }
                        else
                        {
                            MessageBox.Show("Username tidak ditemukan.");
                        }
                    }
                }
                else // Jika gagal
                {
                    MessageBox.Show("Koneksi gagal. Pesan kesalahan : " + hasilConnect, "Kesalahan");
                }
            }
            else
            {
                MessageBox.Show("Username tidak boleh dikosongi", "Kesalahan");
            }
        }

        private void linkLabelPengaturan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Height = 50 + panelLogin.Height + panelPengaturan.Height;
        }
    }
}
