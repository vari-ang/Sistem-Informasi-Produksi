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
    public partial class FormBatalOrderPenjualan : Form
    {
        FormDaftarOrderPenjualan frmDaftar;
        private List<OrderPenjualan> listDataOP = new List<OrderPenjualan>();
        private List<OrderPenjualan> lists = new List<OrderPenjualan>();
        private List<Barang> listDataBarang = new List<Barang>();

        public FormBatalOrderPenjualan()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        public void FormBatalOrderPenjualan_Load(object sender, EventArgs e)
        {
            try
            {
                frmDaftar = (FormDaftarOrderPenjualan)this.Owner;

                FormatDataGrid();

                listDataOP.Clear();

                dateTimePickerTanggal.Value = DateTime.Now;
                textBoxCustomer.Text = "";
                textBoxUnit.Text = "";
                dateTimePickerTanggal.Enabled = false;
                textBoxCustomer.Enabled = false;
                textBoxUnit.Enabled = false;

                string hasilBaca = OrderPenjualan.BacaData("", "", lists);

                bool idSama = false;
                if (hasilBaca == "1")
                {
                    comboBoxNoOrderPenjualan.Items.Clear();
                    for (int i = 0; i < lists.Count; i++)
                    {        
                        for(int j = 0; j < comboBoxNoOrderPenjualan.Items.Count; j++)
                        {
                            if (comboBoxNoOrderPenjualan.GetItemText(comboBoxNoOrderPenjualan.Items[j]) == lists[i].NoOrder)
                            {
                                idSama = true;
                                break;
                            }
                        }    
                        
                        if(!idSama) { comboBoxNoOrderPenjualan.Items.Add(lists[i].NoOrder); }
                    }
                }
                else
                {
                    MessageBox.Show("Data Order Penjualan gagal ditampilkan. Pesan kesalahan: " + hasilBaca);
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void comboBoxNoOrderPenjualan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listDataOP.Clear();
                string hasilBaca = OrderPenjualan.BacaData("OP.Id", comboBoxNoOrderPenjualan.Text, listDataOP);
                if (hasilBaca == "1")
                {
                    if (listDataOP.Count > 0)
                    {
                        dateTimePickerTanggal.Value = listDataOP[0].Tanggal;
                        textBoxCustomer.Text = listDataOP[0].Customer.IdCustomer + " - " + listDataOP[0].Customer.Nama;
                        textBoxUnit.Text = listDataOP[0].Unit;

                        // Ambil data barang
                        listDataBarang.Clear();
                        string hasilBacaBarang = Barang.BacaData("id_order_penjualan", comboBoxNoOrderPenjualan.Text, listDataBarang);

                        if (hasilBacaBarang == "1")
                        {
                            dataGridViewBarang.Rows.Clear();

                            for (int i = 0; i < listDataBarang.Count; i++)
                            {
                                dataGridViewBarang.Rows.Add(listDataBarang[i].Kode, listDataBarang[i].Nama,
                                     listDataBarang[i].Jumlah, listDataBarang[i].Satuan, listDataBarang[i].HargaSatuan, listDataBarang[i].Keterangan);
                            }
                        }
                    }
                }
                else
                {
                    dateTimePickerTanggal.Value = DateTime.Now;
                    textBoxCustomer.Text = "";
                    textBoxUnit.Text = "";
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void buttonBatal_Click(object sender, EventArgs e)
        {
            string hasil = OrderPenjualan.HapusData(lists[comboBoxNoOrderPenjualan.SelectedIndex]);
            if(hasil == "1")
            {
                MessageBox.Show("Order penjualan telah dibatalkan");
            }
            else
            {
                MessageBox.Show("Gagal. Pesan: " + hasil);
            }
            frmDaftar.FormDaftarOrderPenjualan_Load(sender, e);
            FormBatalOrderPenjualan_Load(sender, e);
        }

        private void dataGridViewBarang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }       
    }
}
