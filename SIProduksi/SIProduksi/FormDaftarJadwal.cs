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
    public partial class FormDaftarJadwal : Form
    {
        List<Jadwal> listhasildata = new List<Jadwal>();
        public FormDaftarJadwal()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormatDataGrid()
        {
            dataGridViewJadwal.Columns.Clear();

            dataGridViewJadwal.Columns.Add("nomorspk", "noSPK");
            dataGridViewJadwal.Columns.Add("id", "ID");
            dataGridViewJadwal.Columns.Add("tanggalmulai", "Tanggal Mulai");
            dataGridViewJadwal.Columns.Add("tanggalselesai", "Tanggal Selesai");
            dataGridViewJadwal.Columns.Add("keterangan", "Keterangan");

            dataGridViewJadwal.Columns["nomorspk"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJadwal.Columns["tanggalmulai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJadwal.Columns["tanggalselesai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewJadwal.Columns["keterangan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        public void FormDaftarJadwal_Load(object sender, EventArgs e)
        {
            FormatDataGrid();
            listhasildata.Clear();

            string hasilbaca = Jadwal.BacaData("","",listhasildata);
            if (hasilbaca == "1")
            {
                string no = "";
                string divider = "";
                for (int i = 0; i < listhasildata.Count; i++)
                {
                    if (divider != listhasildata[i].NoSPK.NoSPK)
                    {
                        divider = listhasildata[i].NoSPK.NoSPK;
                        no = listhasildata[i].NoSPK.NoSPK;
                    }
                    else
                    {
                        no = "";
                    }

                    dataGridViewJadwal.Rows.Add(no, listhasildata[i].Id, listhasildata[i].TglMulai, listhasildata[i].TglSelesai, listhasildata[i].Keterangan);
                }
            }
            else
            {
                
                dataGridViewJadwal.DataSource = null;
            }

        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahJadwal frm = new FormTambahJadwal();
            frm.Owner = this;
            frm.Show();

        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahJadwal frm = new FormUbahJadwal();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusJadwal frm = new FormHapusJadwal();
            frm.Owner = this;
            frm.Show();
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            string kriteria = "";

            if (comboBoxCari.Text == "No SPK")
            {
                kriteria = "s.nomor";
            }
            else if (comboBoxCari.Text == "Keterangan")
            {
                kriteria = "p.keterangan";
            }
            

            // Kosongi isi list
            listhasildata.Clear();

            // Tampilkan data kategori sesuai kriteria
            string hasilBaca = Jadwal.BacaData(kriteria, textBoxCari.Text, listhasildata);

            if (hasilBaca == "1")
            {
                dataGridViewJadwal.DataSource = null;
                dataGridViewJadwal.DataSource = listhasildata;
            }
        }
    }
}
