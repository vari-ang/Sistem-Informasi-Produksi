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
    public partial class FormHapusJadwal : Form
    {
        List<Jadwal> listdatajadwal = new List<Jadwal>();
        public FormHapusJadwal()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormHapusJadwal_Load(object sender, EventArgs e)
        {
            listdatajadwal.Clear();

            string baca = Jadwal.BacaData("","",listdatajadwal);
            if (baca == "1")
            {
                for (int i = 0; i < listdatajadwal.Count; i++)
                {
                    comboBoxID.Items.Add(listdatajadwal[i].Id);
                }
            }
            else
            {
                MessageBox.Show("Data Error Tidak Ditemukan");
            }
        }

        private void comboBoxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listdatajadwal.Count; i++)
            {
                if (comboBoxID.SelectedIndex == i)
                {
                    textBoxNamaCustomer.Text = listdatajadwal[i].Keterangan;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string hasil = Jadwal.HapusData(comboBoxID.Text);
            if (hasil == "1")
            {
                MessageBox.Show("Jadwal telah dihapus");

                FormDaftarJadwal frm = (FormDaftarJadwal)this.Owner;
                frm.FormDaftarJadwal_Load(sender, e);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error. Pesan : " + hasil);
            }
        }
    }
}
