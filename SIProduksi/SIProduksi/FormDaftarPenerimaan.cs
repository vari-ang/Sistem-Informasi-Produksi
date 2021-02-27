using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Produksi_LIB;

namespace SIProduksi
{
    public partial class FormDaftarPenerimaan : Form
    {
        public FormDaftarPenerimaan()
        {
            InitializeComponent();
        }

        List<Penerimaan> listHasilData = new List<Penerimaan>();

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormatDataGrid()
        {
            dataGridViewPengiriman.Columns.Clear();

            dataGridViewPengiriman.Columns.Add("nomor", "Nomor Dokumen");
            dataGridViewPengiriman.Columns.Add("nomor_dokumen_pengiriman", "Nomor Dokumen Pengiriman");
            dataGridViewPengiriman.Columns.Add("tanggal", "Tanggal");
            dataGridViewPengiriman.Columns.Add("nama", "Nama");
            dataGridViewPengiriman.Columns.Add("alamat", "Alamat");
            dataGridViewPengiriman.Columns.Add("keterangan", "Keterangan");
            DataGridViewImageColumn dg = new DataGridViewImageColumn();
            dg.HeaderText = "Foto";
            dg.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridViewPengiriman.Columns.Add(dg);
            dataGridViewPengiriman.AllowUserToAddRows = false;
            dataGridViewPengiriman.RowTemplate.Height = 100;

            dataGridViewPengiriman.Columns["nomor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPengiriman.Columns["nomor_dokumen_pengiriman"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPengiriman.Columns["tanggal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPengiriman.Columns["nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPengiriman.Columns["alamat"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPengiriman.Columns["keterangan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            string kriteria = "";
            if (comboBoxCari.Text == "Nomor Dokumen")
            {
                kriteria = "PT.nomor";
            }
            else if (comboBoxCari.Text == "Nomor Dokumen Pengiriman")
            {
                kriteria = "PT.nomor_dokumen_pengiriman";
            }
            else if (comboBoxCari.Text == "Nama")
            {
                kriteria = "PT.nama";
            }
            else if (comboBoxCari.Text == "Alamat")
            {
                kriteria = "PT.Alamat";
            }

            string hasilBaca = Penerimaan.BacaData(kriteria, textBoxCari.Text, listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewPengiriman.Rows.Clear();

                for (int i = 0; i < listHasilData.Count; i++)
                {
                    dataGridViewPengiriman.Rows.Add(listHasilData[i].Nomor, listHasilData[i].NomorPengiriman.NomorDokumen, listHasilData[i].Tanggal,
                        listHasilData[i].Nama, listHasilData[i].Alamat, listHasilData[i].Keterangan);
                }
            }
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahPenerimaan frm = new FormTambahPenerimaan();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
           
        }
        private Image GetCopyImage(string path)
        {
            using (Image im = Image.FromFile(path))
            {
                Bitmap bm = new Bitmap(im);
                return bm;
            }
        }
        public void FormDaftarPenerimaan_Load_1(object sender, EventArgs e)
        {
            comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

            FormatDataGrid();

            listHasilData.Clear();
            string hasilBaca = Penerimaan.BacaData("", "", listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewPengiriman.Rows.Clear();

                for (int i = 0; i < listHasilData.Count; i++)
                {
                    if (File.Exists(Application.StartupPath + "\\Images\\Penerimaan\\" + listHasilData[i].Nomor + ".jpg"))
                    {
                        Image m = GetCopyImage(Application.StartupPath + "\\Images\\Penerimaan\\" + listHasilData[i].Nomor + ".jpg");
                        dataGridViewPengiriman.Rows.Add(listHasilData[i].Nomor, listHasilData[i].NomorPengiriman.NomorDokumen, listHasilData[i].Tanggal,
                        listHasilData[i].Nama, listHasilData[i].Alamat, listHasilData[i].Keterangan,m);
                    }
                    else
                    {
                        dataGridViewPengiriman.Rows.Add(listHasilData[i].Nomor, listHasilData[i].NomorPengiriman.NomorDokumen, listHasilData[i].Tanggal,
                       listHasilData[i].Nama, listHasilData[i].Alamat, listHasilData[i].Keterangan, null);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void buttonKeluar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
