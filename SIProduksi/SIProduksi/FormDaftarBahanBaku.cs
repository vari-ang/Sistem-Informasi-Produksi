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
    public partial class FormDaftarBahanBaku : Form
    {
        List<BahanBaku> listHasilData = new List<BahanBaku>();
        public FormDaftarBahanBaku()
        {
            InitializeComponent();
        }

        private void FormatDataGrid()
        {
            dataGridViewBahanBaku.Columns.Clear();

            dataGridViewBahanBaku.Columns.Add("IdBahanBaku", "Id Bahan Baku");
            dataGridViewBahanBaku.Columns.Add("Nama", "Nama Bahan Baku");

            DataGridViewImageColumn dg = new DataGridViewImageColumn();
            dg.HeaderText = "Foto";
            dg.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridViewBahanBaku.Columns.Add(dg);
            dataGridViewBahanBaku.AllowUserToAddRows = false;
            dataGridViewBahanBaku.RowTemplate.Height = 100;

            dataGridViewBahanBaku.Columns.Add("Bagian", "Bagian");
            dataGridViewBahanBaku.Columns.Add("UkuranMentah", "Ukuran Mentah");
            dataGridViewBahanBaku.Columns.Add("UkuranLuasan", "Ukuran Luasan");
            dataGridViewBahanBaku.Columns.Add("UkuranJadi", "Ukuran Jadi");
            dataGridViewBahanBaku.Columns.Add("Stok", "Stok");
            dataGridViewBahanBaku.Columns.Add("HargaSatuan", "Harga Satuan");
            dataGridViewBahanBaku.Columns.Add("IdSupplier", "Id Supplier");
            dataGridViewBahanBaku.Columns.Add("NamaSupplier", "Nama Supplier");
            
            dataGridViewBahanBaku.Columns["UkuranMentah"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBahanBaku.Columns["UkuranLuasan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBahanBaku.Columns["UkuranJadi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBahanBaku.Columns["Stok"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBahanBaku.Columns["HargaSatuan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;     
        }
        private Image GetCopyImage(string path)
        {
            using (Image im = Image.FromFile(path))
            {
                Bitmap bm = new Bitmap(im);
                return bm;
            }
        }
        public void FormDaftarBahanBaku_Load(object sender, EventArgs e)
        {
            try
            {
                FormatDataGrid();

                listHasilData.Clear();
                string hasilBaca = BahanBaku.BacaData("", "", listHasilData);

                if (hasilBaca == "1")
                {
                    dataGridViewBahanBaku.Rows.Clear();

                    for (int i = 0; i < listHasilData.Count; i++)
                    {
                        if(File.Exists(Application.StartupPath + "\\Images\\BahanBaku\\" + listHasilData[i].Id + ".jpg"))
                        {
                            Image m = GetCopyImage(Application.StartupPath + "\\Images\\BahanBaku\\" + listHasilData[i].Id + ".jpg");
                            dataGridViewBahanBaku.Rows.Add(listHasilData[i].Id, listHasilData[i].Nama,m, 
                                listHasilData[i].Bagian, listHasilData[i].UkuranMentah, listHasilData[i].UkuranLuasan, listHasilData[i].UkuranJadi,
                                listHasilData[i].Stok, listHasilData[i].HargaSatuan, listHasilData[i].Supplier.IdSupplier, listHasilData[i].Supplier.Nama);
                        }
                        else
                        {
                            dataGridViewBahanBaku.Rows.Add(listHasilData[i].Id, listHasilData[i].Nama, null, listHasilData[i].Bagian,
                                listHasilData[i].UkuranMentah, listHasilData[i].UkuranLuasan, listHasilData[i].UkuranJadi,
                                listHasilData[i].Stok, listHasilData[i].HargaSatuan, listHasilData[i].Supplier.IdSupplier, listHasilData[i].Supplier.Nama);
                        }                       
                    }
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

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            string kriteria = "";
            if (comboBoxCari.Text == "Id Bahan Baku")
            {
                kriteria = "BB.id";
            }
            else if (comboBoxCari.Text == "Bagian")
            {
                kriteria = "BB.bagian";
            }
            else if (comboBoxCari.Text == "Stok")
            {
                kriteria = "BB.stok";
            }
            else if (comboBoxCari.Text == "Harga")
            {
                kriteria = "BB.harga_satuan";
            }
            else if (comboBoxCari.Text == "Id Supplier")
            {
                kriteria = "S.id";
            }
            else if (comboBoxCari.Text == "Nama Supplier")
            {
                kriteria = "S.Nama";
            }

            listHasilData.Clear();

            // Tampilkan data kategori sesuai kriteria
            string hasilBaca = BahanBaku.BacaData(kriteria, textBoxCari.Text, listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewBahanBaku.DataSource = null;
                dataGridViewBahanBaku.DataSource = listHasilData;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormPemesananBahanBaku form = new FormPemesananBahanBaku();
            form.Owner = this;
            form.Show();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahBahanBaku form = new FormTambahBahanBaku();
            form.Owner = this;
            form.Show();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahBahanBaku form = new FormUbahBahanBaku();
            form.Owner = this;
            form.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusBahanBaku form = new FormHapusBahanBaku();
            form.Owner = this;
            form.Show();
        }
    }
}
