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
    
    public partial class FormTambahJadwal : Form
    {
        FormDaftarJadwal frmDaftar;
        List<Spk> listhasildata = new List<Spk>();
        public FormTambahJadwal()
        {
            InitializeComponent();
            frmDaftar = (FormDaftarJadwal)this.Owner;
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormTambahJadwal_Load(object sender, EventArgs e)
        {
            string codebaru;
            string hasilgen = Jadwal.GenerateCode(out codebaru);
            if (hasilgen == "1")
            {
                textBoXid.Text = codebaru;
                textBoXid.Enabled = false;

            }
            else
            {
                MessageBox.Show("Gagal melakukan generate code. Pesan kesalahan: " + hasilgen);
            }
            listhasildata.Clear();
            string hasilBaca1 = Spk.BacaData("", "", listhasildata);

            if (hasilBaca1 == "1")
            {
                comboBoxSPK.Items.Clear();
                for (int i = 0; i < listhasildata.Count; i++)
                {
                    comboBoxSPK.Items.Add(listhasildata[i].NoSPK);
                }
            }
            else
            {
                MessageBox.Show("Data SPK gagal ditampilkan. Pesan kesalahan: " + hasilBaca1);
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxkET.Text = "";
        }

        private void buttonBuat_Click(object sender, EventArgs e)
        {
            try
            {
                int indexSPK = comboBoxSPK.SelectedIndex;

                Spk op = listhasildata[indexSPK];

                Jadwal J = new Jadwal(textBoXid.Text,op,dateTimePickerTanggalMulai.Value,dateTimePickerTanggalSelesai.Value,textBoxkET.Text);

                string hasilTambah = Jadwal.TambahData(J);

                if (hasilTambah == "1")
                {
                    MessageBox.Show("Jadwal telah tersimpan.", "Informasi");

                    buttonKosongi_Click(sender, e);
                    frmDaftar.FormDaftarJadwal_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Gagal menambah Jadwal. Pesan kesalahan: " + hasilTambah);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Data telah tersimpan silahkan Refresh");
            }
        }
    }
}
