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
    public partial class FormTambahRiwayat : Form
    {
        FormDaftarRiwayatPerbaikan frmDaftar;
        List<Mesin> ListdaftarMesin = new List<Mesin>();
        public FormTambahRiwayat()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormTambahRiwayat_Load(object sender, EventArgs e)
        {
            frmDaftar = (FormDaftarRiwayatPerbaikan)this.Owner;

            ListdaftarMesin.Clear();
            string bacaha = Mesin.BacaData("", "", ListdaftarMesin);
            if (bacaha == "1")
            {
                for (int i = 0; i < ListdaftarMesin.Count; i++)
                {
                    comboBoxMesin.Items.Add(ListdaftarMesin[i].IdMesin + " - " + ListdaftarMesin[i].Nama);

                }

            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                int indexDipilihUser = comboBoxMesin.SelectedIndex;
                Mesin m = ListdaftarMesin[indexDipilihUser];
                RiwayatPerbaikan rp = new RiwayatPerbaikan(int.Parse(textBoxId.Text), m, dateTimePicker1.Value, textBoxKeterangan.Text);
                string hasil = RiwayatPerbaikan.TambahData(rp);
                if (hasil == "1")
                {
                    MessageBox.Show("Data Telah disimpan");

                    frmDaftar.FormDaftarRiwayatPerbaikan_Load(sender, e);
                    FormTambahRiwayat_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Data gagal disimpan. Pesan : " + hasil);
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
