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
    public partial class FormHapusProgress : Form
    {
        List<ProgresProduksi> listdaftarprog = new List<ProgresProduksi>();
        public FormHapusProgress()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormHapusProgress_Load(object sender, EventArgs e)
        {
            listdaftarprog.Clear();
            string hasil = ProgresProduksi.BacaData("","",listdaftarprog);
            if (hasil == "1")
            {
                comboBoxNoDok.Items.Clear();
                for (int i = 0; i < listdaftarprog.Count; i++)
                {
                    comboBoxNoDok.Items.Add(listdaftarprog[i].NomorDokumen);
                }
            }
        }

        private void comboBoxNoDok_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listdaftarprog.Count; i++)
            {
                if (comboBoxNoDok.SelectedIndex == i)
                {
                    textBoxNamaCustomer.Text = listdaftarprog[i].Keterangan;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string hasil = ProgresProduksi.HapusData(comboBoxNoDok.Text);
                if (hasil == "1")
                {
                    MessageBox.Show("Data Berhasil Dihapus");
                    FormDaftarProgress frm = new FormDaftarProgress();
                    frm.FormDaftarProgress_Load(sender,e);
                }
                else
                {
                    MessageBox.Show("Error : " + hasil);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hasil : " + ex);
            }
            
        }
    }
}
