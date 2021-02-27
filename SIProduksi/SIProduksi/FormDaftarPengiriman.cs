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
    public partial class FormDaftarPengiriman : Form
    {
        public FormDaftarPengiriman()
        {
            InitializeComponent();
        }

        List<Pengiriman> listHasilData = new List<Pengiriman>();

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahPengiriman frm = new FormTambahPengiriman();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusPengiriman frm = new FormHapusPengiriman();
            frm.Owner = this;
            frm.Show();
        }

        private void FormatDataGrid()
        {
            dataGridViewPengiriman.Columns.Clear();

            dataGridViewPengiriman.Columns.Add("nomor_dokumen", "Nomor Dokumen");
            dataGridViewPengiriman.Columns.Add("nomor_spk", "Nomor SPK");
            dataGridViewPengiriman.Columns.Add("tanggal_pengiriman", "Tanggal Pengiriman");    

            dataGridViewPengiriman.Columns["nomor_dokumen"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPengiriman.Columns["nomor_spk"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPengiriman.Columns["tanggal_pengiriman"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        public void FormDaftarPengiriman_Load(object sender, EventArgs e)
        {
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

            FormatDataGrid();

            listHasilData.Clear();
            string hasilBaca = Pengiriman.BacaData("", "", listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewPengiriman.Rows.Clear();

                for (int i = 0; i < listHasilData.Count; i++)
                {
                    dataGridViewPengiriman.Rows.Add(listHasilData[i].NomorDokumen, listHasilData[i].NomorSPK.NoSPK, listHasilData[i].TanggalKirim);
                }
            }
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            string kriteria = "";
            if (comboBoxCari.Text == "Nomor Dokumen")
            {
                kriteria = "P.nomor_dokumen";
            }
            else if (comboBoxCari.Text == "Nomor Spk")
            {
                kriteria = "P.nomor_spk";
            }

            string hasilBaca = Pengiriman.BacaData(kriteria, textBoxCari.Text, listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewPengiriman.Rows.Clear();

                for (int i = 0; i < listHasilData.Count; i++)
                {
                    dataGridViewPengiriman.Rows.Add(listHasilData[i].NomorDokumen, listHasilData[i].NomorSPK.NoSPK, listHasilData[i].TanggalKirim);
                }
            }
        }
    }
}
