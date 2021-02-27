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
    public partial class FormDaftarMesin : Form
    {
        private List<Mesin> listHasilData = new List<Mesin>();
        public FormDaftarMesin()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormatDataGrid()
        {
            dataGridViewMesin.Columns.Clear();

            dataGridViewMesin.Columns.Add("idmesin", "ID Mesin");
            dataGridViewMesin.Columns.Add("nama", "Nama Mesin");
            dataGridViewMesin.Columns.Add("harga", "Harga Beli");
           
            DataGridViewImageColumn dg = new DataGridViewImageColumn();
            dg.HeaderText = "Foto";
            dg.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridViewMesin.Columns.Add(dg);
            dataGridViewMesin.AllowUserToAddRows = false;
            dataGridViewMesin.RowTemplate.Height = 100;
            dataGridViewMesin.Columns["harga"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;          
        }
        private Image GetCopyImage(string path)
        {
            using (Image im = Image.FromFile(path))
            {
                Bitmap bm = new Bitmap(im);
                return bm;
            }
        }
        public void FormDaftarMesin_Load(object sender, EventArgs e)
        {
            try
            {
                FormatDataGrid();
                listHasilData.Clear();

                string hasilBaca = Mesin.BacaData("", "", listHasilData);

                if (hasilBaca == "1")
                {
                    dataGridViewMesin.Rows.Clear();
                    for (int i = 0; i < listHasilData.Count; i++)
                    {
                        if (File.Exists(Application.StartupPath + "\\Images\\Mesin\\" + listHasilData[i].IdMesin + ".jpg"))
                        {
                            Image s = GetCopyImage(Application.StartupPath + "\\Images\\Mesin\\" + listHasilData[i].IdMesin + ".jpg");

                            dataGridViewMesin.Rows.Add(listHasilData[i].IdMesin, listHasilData[i].Nama,
                                listHasilData[i].HargaBeli, s);
                        }
                        else
                        {
                            dataGridViewMesin.Rows.Add(listHasilData[i].IdMesin, listHasilData[i].Nama,
                           listHasilData[i].HargaBeli, null);
                        }
                        
                    }

                }
                else
                {
                    // Kosongi dataGridView
                    dataGridViewMesin.DataSource = null;
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahMesin frm = new FormTambahMesin();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahMesin frm = new FormUbahMesin();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusMesin frm = new FormHapusMesin();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonRiwayatMesin_Click(object sender, EventArgs e)
        {
            FormDaftarRiwayatPerbaikan frm = new FormDaftarRiwayatPerbaikan();
            frm.Owner = this;
            frm.Show();
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            string kriteria = "";

            if (comboBoxCari.Text == "Nama")
            {
                kriteria = "nama";
            }
            

            // Kosongi isi list
            listHasilData.Clear();

            // Tampilkan data kategori sesuai kriteria
            string hasilBaca = Mesin.BacaData(kriteria, textBoxCari.Text, listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewMesin.DataSource = null;
                dataGridViewMesin.DataSource = listHasilData;
            }
        }
    }
}
