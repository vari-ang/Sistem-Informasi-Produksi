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
    public partial class FormUbahJadwal : Form
    {
        FormDaftarJadwal frmdaftar;
        List<Spk> hasildataspk = new List<Spk>();
        List<Jadwal> hasildatajadwal = new List<Jadwal>();
        public FormUbahJadwal()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormUbahJadwal_Load(object sender, EventArgs e)
        {
            hasildataspk.Clear();
            string hasilBaca1 = Spk.BacaData("", "", hasildataspk);

            if (hasilBaca1 == "1")
            {
                comboBoxSPK.Items.Clear();
                for (int i = 0; i < hasildataspk.Count; i++)
                {
                    comboBoxSPK.Items.Add(hasildataspk[i].NoSPK);
                }
            }
            else
            {
                MessageBox.Show("Data SPK gagal ditampilkan. Pesan kesalahan: " + hasilBaca1);
            }
        }

        private void textBoXid_TextChanged(object sender, EventArgs e)
        {
            if (textBoXid.Text.Length == textBoXid.MaxLength)
            {
                hasildatajadwal.Clear();

                string hasilBaca = Jadwal.BacaData("p.id", textBoXid.Text, hasildatajadwal);
                if (hasilBaca == "1")
                {
                    if (hasildatajadwal.Count > 0)
                    {
                        textBoxkET.Text = hasildatajadwal[0].Keterangan;
                        dateTimePickerTanggalMulai.Value = hasildatajadwal[0].TglMulai;
                        dateTimePickerTanggalSelesai.Value = hasildatajadwal[0].TglSelesai;
                        comboBoxSPK.Text = hasildatajadwal[0].NoSPK.NoSPK;

                    }
                }
                else
                {
                    MessageBox.Show("Data Tidak ditemukan");
                }
            }
        }

        private void buttonBuat_Click(object sender, EventArgs e)
        {
            try
            {
                    int indexDipilihUser = comboBoxSPK.SelectedIndex;
                    Spk spk = hasildataspk[indexDipilihUser];


                    Jadwal J = new Jadwal(textBoXid.Text, spk, dateTimePickerTanggalMulai.Value, dateTimePickerTanggalSelesai.Value, textBoxkET.Text);

                        string hasilUbah = Jadwal.UbahData(J);

                        if (hasilUbah == "1")
                        {
                            MessageBox.Show("Data Jadwal telah terubah", "Informasi");


                            frmdaftar.FormDaftarJadwal_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Gagal mengubah data Jadwal. Pesan kesalahan: " + hasilUbah);
                        }
                    
                
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }            
        }
    }
}
