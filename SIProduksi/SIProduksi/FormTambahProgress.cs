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
    public partial class FormTambahProgress : Form
    {
        List<Mesin> listaftarmesin = new List<Mesin>();
        List<Spk> listaftarspk = new List<Spk>();
        List<Pekerja> listdaftarpekerja = new List<Pekerja>();
        FormDaftarProgress frmDaftar;
        public FormTambahProgress()
        {
            InitializeComponent();
        }

        private void FormTambahProgress_Load(object sender, EventArgs e)
        {
            frmDaftar = (FormDaftarProgress)this.Owner;

            listaftarmesin.Clear();
            listaftarspk.Clear();
            listdaftarpekerja.Clear();

            string bacamesin = Mesin.BacaData("", "", listaftarmesin);
            if (bacamesin == "1")
            {
                comboBoxMesin.Items.Clear();
                for(int i =0;i<listaftarmesin.Count;i++){
                    comboBoxMesin.Items.Add(listaftarmesin[i].IdMesin  + " - " + listaftarmesin[i].Nama);
                }
                
            }

            string bacaspk = Spk.BacaData("","",listaftarspk);
            if (bacaspk == "1")
            {
                comboBoxSPK.Items.Clear();
                for (int i = 0; i < listaftarspk.Count; i++)
                {
                    comboBoxSPK.Items.Add(listaftarspk[i].NoSPK);
                }
            }

            string bacapekerja = Pekerja.BacaData("","",listdaftarpekerja);
            if (bacapekerja == "1")
            {
                comboBoxPekerja.Items.Clear();
                for (int i = 0; i < listdaftarpekerja.Count; i++)
                {
                    comboBoxPekerja.Items.Add(listdaftarpekerja[i].IdPekerja + " - " + listdaftarpekerja[i].Nama);
                }
            }
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                int selectindexspk = comboBoxSPK.SelectedIndex;
                int selectindexmesin = comboBoxMesin.SelectedIndex;
                int selectindexpekerja = comboBoxPekerja.SelectedIndex;

                Pekerja p = listdaftarpekerja[selectindexpekerja];
                Mesin m = listaftarmesin[selectindexmesin];
                Spk s = listaftarspk[selectindexspk];

                ProgresProduksi pk = new ProgresProduksi(textBoxNoDokumen.Text, s, m, p, dateTimePickerTglMulai.Value, dateTimePickerTglSelesai.Value, comboBoxStatus.Text, textBoxKeterengan.Text);
                //ProgresProduksi pk = new ProgresProduksi(textBoxNoDokumen.Text, comboBoxStatus.Text);
                string hasil = ProgresProduksi.TambahData(pk);
                if (hasil == "1")
                {
                    MessageBox.Show("Data Telah ditambahkan");
                    
                    frmDaftar.FormDaftarProgress_Load(sender, e);
                    buttonKosongi_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Error tidak bisa menambahkan data :" + hasil);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
            
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxKeterengan.Text = "";
            textBoxNoDokumen.Text = "";
            
        }

        private void textBoxStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
