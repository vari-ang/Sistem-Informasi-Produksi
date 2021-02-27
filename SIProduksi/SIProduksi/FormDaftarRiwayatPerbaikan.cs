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
    public partial class FormDaftarRiwayatPerbaikan : Form
    {
        List<RiwayatPerbaikan> ListdaftarRiwayat = new List<RiwayatPerbaikan>();
        
        public FormDaftarRiwayatPerbaikan()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahRiwayat frm = new FormTambahRiwayat();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahRiwayat frm = new FormUbahRiwayat();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusRiwayatperbaikan frm = new FormHapusRiwayatperbaikan();
            frm.Owner = this;
            frm.Show();
        }
        private void FormatDataGrid()
        {
            dataGridViewRiwayat.Columns.Clear();
            dataGridViewRiwayat.Columns.Add("idriwayat", "id");
            dataGridViewRiwayat.Columns.Add("idmesin", "id Mesin");
            dataGridViewRiwayat.Columns.Add("Tanggal", "Tanggal");
            dataGridViewRiwayat.Columns.Add("keterangan", "Keterangan");

            dataGridViewRiwayat.Columns["Tanggal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewRiwayat.Columns["keterangan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        public void FormDaftarRiwayatPerbaikan_Load(object sender, EventArgs e)
        {
                FormatDataGrid();
                ListdaftarRiwayat.Clear();
                string bacadata = RiwayatPerbaikan.BacaData("", "", ListdaftarRiwayat);
                if (bacadata == "1")
                {
                    dataGridViewRiwayat.Rows.Clear();
                    for(int i = 0; i < ListdaftarRiwayat.Count; i++)
                    {
                        dataGridViewRiwayat.Rows.Add(ListdaftarRiwayat[i].Id,ListdaftarRiwayat[i].IdMesin.IdMesin,ListdaftarRiwayat[i].Tanggal,ListdaftarRiwayat[i].Keterangan);
                    }
                    
            
                }
                else
                {
                    MessageBox.Show("Error Data Tidak dapat ditampilkan " + bacadata);
                }
            
        }       
    }
}
