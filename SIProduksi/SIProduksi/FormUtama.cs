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
    public partial class FormUtama : Form
    {
        List<BahanBaku> listBahanBaku = new List<BahanBaku>();
        List<String> listNotifcompare = new List<string>();
        List<String> listNotif = new List<string>();
        List<OrderPenjualan> listPenjualan = new List<OrderPenjualan>();
        
        public bool clicked = false;
        public bool getnotified = false;
        public bool showed = false;

        public FormUtama()
        {
            InitializeComponent();
        }

        public void getNotif()
        {
            listBahanBaku.Clear();
            
            string bahanbaku = BahanBaku.BacaData("","",listBahanBaku);
            if(bahanbaku != "1")
            {
                MessageBox.Show(bahanbaku);
            }
            else
            {
                listNotif.Clear();
                panel1.Controls.Clear();
                int pointY = 0;
                int panelheight = 20;
                for(int i=0; i<listBahanBaku.Count; i++)
                {
                    if(listBahanBaku[i].Stok <= 5)
                    {
                        try
                        {

                            this.panel1.Size = new System.Drawing.Size(panel1.Size.Width, panelheight);
                            TextBox a = new TextBox();
                            a.Enabled = false;
                            if(listBahanBaku[i].Stok == 0)
                            {
                                a.Text = "Stok Bahan Baku '" + listBahanBaku[i].Nama + "' telah habis";
                            }
                            else
                            {
                                a.Text = "Stok Bahan Baku '" + listBahanBaku[i].Nama + "' Hanya tersisa " + listBahanBaku[i].Stok.ToString();
                            }
                            a.Size = new System.Drawing.Size(panel1.Size.Width,20);
                            a.Location = new Point(0, pointY);
                            a.Font = new System.Drawing.Font("Arial", 15);
                            listNotif.Add(listBahanBaku[i].Id);
                            panel1.Controls.Add(a);
                            panel1.Show();
                            panel1.Visible = true;
                            pointY += 35;
                            panelheight += 60;
                            
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.ToString());
                        }
                    }
                }
                if(listNotif.Count == listNotifcompare.Count)
                {
                    for (int i = 0; i < listNotif.Count; i++ )
                    {
                        if (i != listNotifcompare.Count)
                        {
                            if (listNotif[i] != listNotifcompare[i])
                            {
                                break;
                            }
                        }
                    }
                        
                }
                else
                {
                    listNotifcompare = listNotif;
                }
            }
        }

        public void tampilTotalPenjuatan()
        {
            try
            {
                listPenjualan.Clear();

                int bulan = DateTime.Now.Month;
                string penjualan = OrderPenjualan.TotalPenjualanBulanan(bulan, listPenjualan);
                if (penjualan == "1")
                {
                    int penjualanLalu = 0; int penjualanIni = 0;

                    labelPenjualanBulanLalu.Text = (bulan - 1).ToString();
                    labelPenjualanBulanIni.Text = bulan.ToString();
                   
                    if(listPenjualan.Count > 0)
                    {
                        if(int.Parse(listPenjualan[0].NoOrder) == (bulan-1))
                        {
                            penjualanLalu = listPenjualan[0].ListBarang[0].HargaSatuan;
                            if(listPenjualan.Count > 1)
                            {
                                penjualanIni = listPenjualan[1].ListBarang[0].HargaSatuan;
                            }                           
                        }
                        else
                        {
                            penjualanIni = listPenjualan[0].ListBarang[0].HargaSatuan;
                        }
                    }

                    labelTotalPenjualanLalu.Text = penjualanLalu.ToString("0,###");
                    labelTotalPenjualanIni.Text = penjualanIni.ToString("0,###");

                    // tampilkan persentasi kenaikan/ penuruan penjualan dari bulan sebelumnya
                    double persen = OrderPenjualan.PersenPenjualan(penjualanLalu, penjualanIni);
                    labelPersenPenjualan.Text = persen.ToString();
                }
                else
                {
                    MessageBox.Show("Gagal menampilkan Total Penjualan. Pesan kesalahan: " + penjualan);
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void FormUtama_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            // Ubah form ini (FormUtama) menjadi fullscreen
            this.WindowState = FormWindowState.Maximized;

            // Ubah form utama menjadi MdiParent (MdiContainer)
            this.IsMdiContainer = true;

            // Agar FromUtama tidak bisa diakses sebelum proses login dilakukan
            this.Enabled = false;

            MdiClient ctlMDI;

            // Loop through all of the form's controls looking
            // for the control of type MdiClient.
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    if (ctl is MdiClient)
                    {
                        // Attempt to cast the control to type MdiClient.
                        ctlMDI = (MdiClient)ctl;

                        // Set the BackColor of the MdiClient control.
                        ctlMDI.BackColor = this.BackColor;
                    }
                }
                catch (InvalidCastException exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }

            // tampilkan FormLogin terlebih dahulu sebelum bisa mengakses sistem
            FormLogin frmLogin = new FormLogin();
            frmLogin.Owner = this; // FormLogin bukan MdiChild dari FormUtama
            frmLogin.Show();
        }

        private void bahanBakuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarBahanBaku"];

            if (form == null)
            {
                FormDaftarBahanBaku frm = new FormDaftarBahanBaku();
                frm.Owner = this;
                frm.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void barangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarBarang"];

            if (form == null)
            {
                FormDaftarBarang frm = new FormDaftarBarang();
                frm.Owner = this;
                frm.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void penjadwalanToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarCustomer"];

            if (form == null)
            {
                FormDaftarCustomer frm = new FormDaftarCustomer();
                frm.Owner = this;
                frm.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarSupplier"];

            if (form == null)
            {
                FormDaftarSupplier frm = new FormDaftarSupplier();
                frm.Owner = this;
                frm.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void pekerjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarPekerja"];

            if (form == null)
            {
                FormDaftarPekerja frm = new FormDaftarPekerja();
                frm.Owner = this;
                frm.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void jabatanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarJabatan"];

            if (form == null)
            {
                FormDaftarJabatan frm = new FormDaftarJabatan();
                frm.Owner = this;
                frm.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void listMesinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarMesin"];

            if (form == null)
            {
                FormDaftarMesin frm = new FormDaftarMesin();
                frm.Owner = this;
                frm.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void orderPenjualanToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarOrderPenjualan"];

            if (form == null)
            {
                FormDaftarOrderPenjualan frm = new FormDaftarOrderPenjualan();
                frm.Owner = this;
                frm.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void pemesananBahanBakuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarPemesananBahanBaku"];

            if (form == null)
            {
                FormDaftarPemesananBahanBaku frm = new FormDaftarPemesananBahanBaku();
                frm.Owner = this;
                frm.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void bOMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarBOM"];

            if (form == null)
            {
                FormDaftarBOM frm = new FormDaftarBOM();
                frm.Owner = this;
                frm.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void sPKToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarSPK"];

            if (form == null)
            {
                FormDaftarSPK frm = new FormDaftarSPK();
                frm.Owner = this;
                frm.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void penjadwalanToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarJadwal"];

            if (form == null)
            {
                FormDaftarJadwal frm = new FormDaftarJadwal();
                frm.Owner = this;
                frm.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void pengirimanToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarPengiriman"];

            if (form == null)
            {
                FormDaftarPengiriman frm = new FormDaftarPengiriman();
                frm.Owner = this;
                frm.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void progressProduksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarProgress"];

            if (form == null)
            {
                FormDaftarProgress frm = new FormDaftarProgress();
                frm.Owner = this;
                frm.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void keluarSistemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (showed == false)
            {
                panel1.Visible = true;
                showed = true;
            }
            else
            {
                
                panel1.Visible = false;
                showed = false;
            }

        }

        private void penggunaanBahanBakuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarPenggunaanBahanBaku"];

            if (form == null)
            {
                FormDaftarPenggunaanBahanBaku frm = new FormDaftarPenggunaanBahanBaku();
                frm.Owner = this;
                frm.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void penerimaanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarPenerimaan"];

            if (form == null)
            {
                FormDaftarPenerimaan frm = new FormDaftarPenerimaan();
                frm.Owner = this;
                frm.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }
    }
}
