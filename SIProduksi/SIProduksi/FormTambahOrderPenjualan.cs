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
    public partial class FormTambahOrderPenjualan : Form
    {
        FormDaftarOrderPenjualan frmDaftar;
        private List<Customer> listDataCustomer = new List<Customer>();
        //private List<Barang> listDaftarBarang = new List<Barang>();

        public FormTambahOrderPenjualan()
        {
            InitializeComponent();
        }

        private void FormatDataGrid()
        {
            dataGridViewBarang.Columns.Clear();

            // menambah kolom di datagridview
            dataGridViewBarang.Columns.Add("KodeBarang", "Kode Barang");
            dataGridViewBarang.Columns.Add("NamaBarang", "Nama Barang");
            dataGridViewBarang.Columns.Add("Jumlah", "Jumlah");
            dataGridViewBarang.Columns.Add("Satuan", "Satuan");
            dataGridViewBarang.Columns.Add("HargaSatuan", "Harga Satuan");
            dataGridViewBarang.Columns.Add("Keterangan", "Keterangan");

            // agar lebar dapat menyesuaikan panjang/ isi data
            dataGridViewBarang.Columns["KodeBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["NamaBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Satuan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["HargaSatuan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewBarang.Columns["Keterangan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // agar harga jual dan sub total rata kanan
            dataGridViewBarang.Columns["Jumlah"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewBarang.Columns["HargaSatuan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // agar harga jual dan sub total ditampilkan dengan format pemisah ribuan (1000 delimiter)
            dataGridViewBarang.Columns["HargaSatuan"].DefaultCellStyle.Format = "0,###";

            // agar user tidak bisa menambahkan data langsung di datagridview (harus melalui tombol Tambah)
            dataGridViewBarang.AllowUserToAddRows = false;
        }

        private void buttonTambahBarang_Click(object sender, EventArgs e)
        {
            dataGridViewBarang.Rows.Add(textBoxKodeBarang.Text, textBoxNamaBarang.Text, numericUpDownJumlah.Text, textBoxSatuanBarang.Text, numericUpDownHargaSatuan.Text, richTextBoxKeterangan.Text);

            textBoxKodeBarang.Text = "";
            textBoxNamaBarang.Text = "";
            numericUpDownJumlah.Text = "";
            textBoxSatuanBarang.Text = "";
            numericUpDownHargaSatuan.Text = "";
            richTextBoxKeterangan.Text = "";
        }

        private void FormTambahOrderPenjualan_Load(object sender, EventArgs e)
        { 
            frmDaftar = (FormDaftarOrderPenjualan)this.Owner;

            FormatDataGrid();

            string kodeTerbaru;
            string hasilGenerate = OrderPenjualan.GenerateNoNota(out kodeTerbaru);

            if (hasilGenerate == "1")
            {
                textBoxNoOrderPenjualan.Text = kodeTerbaru;
                textBoxNoOrderPenjualan.Enabled = false;
            }
            else
            {
                MessageBox.Show("Gagal melakukan generate code. Pesan kesalahan: " + hasilGenerate);
            }

            listDataCustomer.Clear();

            string hasilBaca = Customer.BacaData("", "", listDataCustomer);

            if (hasilBaca == "1")
            {
                comboBoxCustomer.Items.Clear();
                for (int i = 0; i < listDataCustomer.Count; i++)
                {
                    // Tampilkan dengan format kode kategori - nama kategori
                    comboBoxCustomer.Items.Add(listDataCustomer[i].IdCustomer + " -- " + listDataCustomer[i].Nama);
                }
            }
            else
            {
                MessageBox.Show("Data Customer gagal ditampilkan. Pesan kesalahan: " + hasilBaca);
            }
        }

        private void buttonKeluar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTambahBarang_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBoxKodeBarang.Text != "" && textBoxNamaBarang.Text != "" && numericUpDownJumlah.Text != "" && textBoxSatuanBarang.Text != "" && numericUpDownHargaSatuan.Text != "" && richTextBoxKeterangan.Text != "")
                {
                    dataGridViewBarang.Rows.Add(textBoxKodeBarang.Text, textBoxNamaBarang.Text, numericUpDownJumlah.Text, textBoxSatuanBarang.Text, numericUpDownHargaSatuan.Text, richTextBoxKeterangan.Text);

                    textBoxKodeBarang.Text = "";
                    textBoxNamaBarang.Text = "";
                    numericUpDownJumlah.Text = "";
                    textBoxSatuanBarang.Text = "";
                    numericUpDownHargaSatuan.Text = "";
                    richTextBoxKeterangan.Text = "";
                }
                else
                {
                    MessageBox.Show("Pastikan Anda menginputkan data barang", "Kesalahan");
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }           
        }

        private void buttonSimpan_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxCustomer.SelectedIndex != -1 && textBoxUnit.Text != "")
                {
                    int indexDipilihUser = comboBoxCustomer.SelectedIndex;
                    Customer c = listDataCustomer[indexDipilihUser];

                    OrderPenjualan op = new OrderPenjualan(textBoxNoOrderPenjualan.Text, dateTimePickerTanggal.Value, textBoxUnit.Text, c);

                    if (dataGridViewBarang.Rows.Count != 0)
                    {
                        // data barang diperoleh dari dataGridView
                        for (int i = 0; i < dataGridViewBarang.Rows.Count; i++)
                        {
                            Barang brg = new Barang();
                            brg.Kode = dataGridViewBarang.Rows[i].Cells["KodeBarang"].Value.ToString();
                            brg.Nama = dataGridViewBarang.Rows[i].Cells["NamaBarang"].Value.ToString();
                            brg.Jumlah = int.Parse(dataGridViewBarang.Rows[i].Cells["Jumlah"].Value.ToString());
                            brg.Satuan = dataGridViewBarang.Rows[i].Cells["Satuan"].Value.ToString();
                            brg.HargaSatuan = int.Parse(dataGridViewBarang.Rows[i].Cells["HargaSatuan"].Value.ToString());
                            brg.Keterangan = dataGridViewBarang.Rows[i].Cells["Keterangan"].Value.ToString();

                            // simpan detil barang ke nota
                            op.TambahBarang(brg);
                        }

                        string hasilTambah = OrderPenjualan.TambahData(op);
                        if (hasilTambah == "1")
                        {
                            MessageBox.Show("Data Order Penjualan telah tersimpan", "Info");

                            textBoxUnit.Text = "";

                            frmDaftar.FormDaftarOrderPenjualan_Load(sender, e);
                            FormTambahOrderPenjualan_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Data Order Penjualan gagal tersimpan. Pesan kesalahan: " + hasilTambah, "Kesalahan");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Anda belum menambahkan barang apa pun pada order penjualan ini", "Kesalahan");
                    }
                }
                else
                {
                    MessageBox.Show("Pastikan Anda menginputkan semua nilai yang ada ", "Kesalahan");
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }            
        }
    }
}
