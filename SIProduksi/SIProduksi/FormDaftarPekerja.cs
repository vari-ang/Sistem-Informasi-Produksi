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
    public partial class FormDaftarPekerja : Form
    {
        private List<Pekerja> listHasilData = new List<Pekerja>();

        public FormDaftarPekerja()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormatDataGrid()
        {
            dataGridViewPegawai.Columns.Clear();

            dataGridViewPegawai.Columns.Add("IdPekerja", "Id Pekerja");
            dataGridViewPegawai.Columns.Add("Nama", "Nama");
            DataGridViewImageColumn dg = new DataGridViewImageColumn();
            dg.HeaderText = "Foto";
            dg.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridViewPegawai.Columns.Add(dg);
            dataGridViewPegawai.AllowUserToAddRows = false;
            dataGridViewPegawai.RowTemplate.Height = 100;

            dataGridViewPegawai.Columns.Add("Alamat", "Alamat");
            dataGridViewPegawai.Columns.Add("NomerHP", "Nomer HP");
            dataGridViewPegawai.Columns.Add("IdJabatan", "Id Jabatan");
            dataGridViewPegawai.Columns.Add("NamaJabatan", "Nama Jabatan");

            dataGridViewPegawai.Columns["IdPekerja"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPegawai.Columns["Nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;    
            dataGridViewPegawai.Columns["Alamat"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPegawai.Columns["NomerHP"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;     
            dataGridViewPegawai.Columns["IdJabatan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewPegawai.Columns["NamaJabatan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        private Image GetCopyImage(string path)
        {
            using (Image im = Image.FromFile(path))
            {
                Bitmap bm = new Bitmap(im);
                return bm;
            }
        }
        public void FormDaftarPekerja_Load(object sender, EventArgs e)
        {
            try
            {
                comboBoxCari.DropDownStyle = ComboBoxStyle.DropDownList;

                FormatDataGrid();

                listHasilData.Clear();
                string hasilBaca = Pekerja.BacaData("", "", listHasilData);
                
                if (hasilBaca == "1")
                {
                    dataGridViewPegawai.Rows.Clear();

                    for (int i = 0; i < listHasilData.Count; i++)
                    {
                        if (File.Exists(Application.StartupPath + "\\Images\\Pekerja\\" + listHasilData[i].IdPekerja + ".jpg"))
                        {
                            Image s = GetCopyImage(Application.StartupPath + "\\Images\\Pekerja\\" + listHasilData[i].IdPekerja + ".jpg");
                            
                            dataGridViewPegawai.Rows.Add(listHasilData[i].IdPekerja, listHasilData[i].Nama,s,
                             listHasilData[i].Alamat, listHasilData[i].NomerHp, listHasilData[i].Jabatan.IdJabatan, listHasilData[i].Jabatan.NamaJabatan);
                            
                        }
                        else
                        {
                            dataGridViewPegawai.Rows.Add(listHasilData[i].IdPekerja, listHasilData[i].Nama,
                             null, listHasilData[i].Alamat, listHasilData[i].NomerHp, listHasilData[i].Jabatan.IdJabatan, 
                             listHasilData[i].Jabatan.NamaJabatan);
                        }
                    }
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }           
        }

        private void textBoxCari_TextChanged(object sender, EventArgs e)
        {
            string kriteria = "";
            if (comboBoxCari.Text == "Id Pekerja")
            {
                kriteria = "P.Id";
            }
            else if (comboBoxCari.Text == "Nama")
            {
                kriteria = "P.Nama";
            }
            else if (comboBoxCari.Text == "Alamat")
            {
                kriteria = "P.Alamat";
            }
            else if (comboBoxCari.Text == "Id Jabatan")
            {
                kriteria = "J.Id";
            }
            else if (comboBoxCari.Text == "Nama Jabatan")
            {
                kriteria = "J.Nama";
            }

            string hasilBaca = Pekerja.BacaData(kriteria, textBoxCari.Text, listHasilData);

            if (hasilBaca == "1")
            {
                dataGridViewPegawai.Rows.Clear();

                for (int i = 0; i < listHasilData.Count; i++)
                {
                    dataGridViewPegawai.Rows.Add(listHasilData[i].IdPekerja, listHasilData[i].Nama, listHasilData[i].Alamat,
                        listHasilData[i].NomerHp, listHasilData[i].Jabatan.IdJabatan,
                        listHasilData[i].Jabatan.NamaJabatan);
                }
            }
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahPekerja frm = new FormTambahPekerja();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahPekerja frm = new FormUbahPekerja();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusPekerja frm = new FormHapusPekerja();
            frm.Owner = this;
            frm.Show();
        }
    }
}
