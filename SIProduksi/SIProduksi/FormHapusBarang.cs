using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Produksi_LIB;
namespace SIProduksi
{
    public partial class FormHapusBarang : Form
    {
        List<Barang> listHasilData = new List<Barang>();
        public FormHapusBarang()
        {
            InitializeComponent();
        }

        private void FormHapusBarang_Load(object sender, EventArgs e)
        {
            listHasilData.Clear();
            string hasilBaca = Barang.BacaData("", "", listHasilData);

            if (hasilBaca == "1")
            {
                for(int i=0; i<listHasilData.Count; i++)
                {
                    comboBoxKodeBarang.Items.Add(listHasilData[i].Kode);
                }
            }
            else
            {
                MessageBox.Show("Error. Pesan: " + hasilBaca);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for(int i=0; i<listHasilData.Count; i++)
            {
                if(comboBoxKodeBarang.SelectedIndex == i)
                {
                    textBoxNamaBarang.Text = listHasilData[i].Nama;
                    if (File.Exists(Application.StartupPath + "\\Images\\Barang\\" + comboBoxKodeBarang.Text + ".jpg"))
                    {
                        pictureBoxGambar.BackgroundImage = new Bitmap(Application.StartupPath + "\\Images\\Barang\\" + comboBoxKodeBarang.Text + ".jpg");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string hasil = Barang.HapusData(comboBoxKodeBarang.Text);
                if (hasil == "1")
                {
                    MessageBox.Show("Barang telah dihapus");

                    FormDaftarBarang frm = (FormDaftarBarang)this.Owner;
                    frm.FormDaftarBarang_Load(sender, e);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error. Pesan : " + hasil);
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
