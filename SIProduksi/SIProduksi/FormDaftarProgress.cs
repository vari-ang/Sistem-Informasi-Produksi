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
    public partial class FormDaftarProgress : Form
    {
        List<ProgresProduksi> listdataprogress = new List<ProgresProduksi>();
        public FormDaftarProgress()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormatDataGrid()
        {
            dataGridViewProgress.Columns.Clear();
            dataGridViewProgress.Columns.Add("nomorspk", "No.SPK");
            dataGridViewProgress.Columns.Add("nomerdokumen", "No");
            
            dataGridViewProgress.Columns.Add("mesin", "Mesin");
            dataGridViewProgress.Columns.Add("pekerja", "Pekerja");
            dataGridViewProgress.Columns.Add("tglmulai", "Tanggal Mulai");
            dataGridViewProgress.Columns.Add("tglselesai", "Tanggal Selesai");
            dataGridViewProgress.Columns.Add("status", "Status");
            dataGridViewProgress.Columns.Add("keterangan", "Keterangan");


            dataGridViewProgress.Columns["keterangan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewProgress.Columns["nomorspk"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewProgress.Columns["status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewProgress.Columns["nomerdokumen"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        public void FormDaftarProgress_Load(object sender, EventArgs e)
        {
            FormatDataGrid();
            listdataprogress.Clear();
            string hasil = ProgresProduksi.BacaData("","",listdataprogress);
            if (hasil == "1")
            {
                dataGridViewProgress.Rows.Clear();
                string no = "";
                string divider = "";
                for (int i = 0; i < listdataprogress.Count; i++)
                {
                    if (divider != listdataprogress[i].NomerSPK.NoSPK)
                    {
                        divider = listdataprogress[i].NomerSPK.NoSPK;
                        no = listdataprogress[i].NomerSPK.NoSPK;
                    }
                    else
                    {
                        no = "";
                    }

                    dataGridViewProgress.Rows.Add(no, listdataprogress[i].NomorDokumen,listdataprogress[i].IdMesin.Nama,listdataprogress[i].Pekerjatuk.Nama, listdataprogress[i].Tglmulai, listdataprogress[i].Tglselesai,listdataprogress[i].Status, listdataprogress[i].Keterangan);

                }
            }

            else
            {
                MessageBox.Show("Data tidak dapat ditemukan");
            }
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahProgress frm = new FormTambahProgress();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahProgress frm = new FormUbahProgress();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusProgress frm = new FormHapusProgress();
            frm.Owner = this;
            frm.Show();
        }
    }
}
