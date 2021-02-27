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
    public partial class FormUbahRiwayat : Form
    {
        
        List<Mesin> ListdaftarMesin = new List<Mesin>();
        List<RiwayatPerbaikan> ListRiwayat = new List<RiwayatPerbaikan>();
        public FormUbahRiwayat()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormUbahRiwayat_Load(object sender, EventArgs e)
        {
            ListRiwayat.Clear();
            string bacaan = RiwayatPerbaikan.BacaData("","",ListRiwayat);
            if(bacaan == "1"){
                for (int i = 0; i < ListRiwayat.Count; i++)
                {
                    comboBoxID.Items.Add(ListRiwayat[i].Id);
                }
            }
               
            ListdaftarMesin.Clear();
            string bacaha = Mesin.BacaData("", "", ListdaftarMesin);
            if(bacaha == "1"){
                for (int i = 0; i < ListdaftarMesin.Count;i++ ){
                    comboBoxMesin.Items.Add(ListdaftarMesin[i].IdMesin + " - " + ListdaftarMesin[i].Nama);

                }

            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void comboBoxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
                
            //            textBoxKeterangan.Text = ListRiwayat[i].Keterangan;
            //            comboBoxMesin.Text = ListRiwayat[i].IdMesin.IdMesin;
            //            dateTimePicker1.Value = ListRiwayat[i].Tanggal;
                  
            //}
            //catch(Exception exc)
            //{
            //    MessageBox.Show(exc.Message);
            //}
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxKeterangan.Text = "";
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                int indexDipilihUser = comboBoxMesin.SelectedIndex;
                Mesin m = ListdaftarMesin[indexDipilihUser];
                RiwayatPerbaikan rp = new RiwayatPerbaikan(int.Parse(comboBoxID.Text), m, dateTimePicker1.Value, textBoxKeterangan.Text);
                string hasil = RiwayatPerbaikan.UbahData(rp);
                if (hasil == "1")
                {
                    MessageBox.Show("Data Telah di ubah");

                }
                else
                {
                    MessageBox.Show("Data gagal diubah. Pesan : " + hasil);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hasil : " + ex);
            }
            
        }

        
    }
}
