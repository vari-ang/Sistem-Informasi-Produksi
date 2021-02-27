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
    public partial class FormHapusBOM : Form
    {
        List<BOM> listHasilData = new List<BOM>();
        public FormHapusBOM()
        {
            InitializeComponent();
        }

        public void FormHapusBOM_Load(object sender, EventArgs e)
        {
            listHasilData.Clear();
            comboBox1.Items.Clear();
            string jasil = BOM.BacaData("", "", listHasilData);
            if(jasil == "1")
            {
                for(int i=0; i<listHasilData.Count; i++)
                {
                    comboBox1.Items.Add(listHasilData[i].Kodebarang);
                }
            }
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            string h = "";
            if(checkBox1.Checked == true)
            {
                h = BOM.HapusData(comboBox1.Text,"");
            }
            else
            {
                h = BOM.HapusData(comboBox1.Text, comboBox2.Text);
            }
            if(h == "1")
            {
                MessageBox.Show("BOM telah dihapus");
                FormDaftarBOM f = (FormDaftarBOM)this.Owner;
                f.FormDaftarBOM_Load(sender, e);
                textBoxbahan.Text = "";
                textBoxNamaJabatan.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                FormHapusBOM_Load(sender, e);
            }
            else
            {
                MessageBox.Show("BOM gagal dihapus. Pesan: " + h);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Barang>li = new List<Barang>();
            li.Clear();
            string hasil = Barang.BacaData("kode", comboBox1.Text,li );
            if(hasil == "1")
            {
                textBoxNamaJabatan.Text = li[0].Nama;
            }
            for(int i=0; i<listHasilData.Count; i++)
            {
                if(listHasilData[i].Kodebarang == li[0].Kode)
                {
                    comboBox2.Items.Add(listHasilData[i].IdbahanBaku);
                }
            }
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<BahanBaku> li = new List<BahanBaku>();
            li.Clear();
            string hasil = BahanBaku.BacaData("BB.id", comboBox2.Text, li);
            if (hasil == "1")
            {
                textBoxbahan.Text = li[0].Nama;
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox2.Text = "";
            comboBox2.Enabled = false;
            textBoxbahan.Text = "";
            textBoxbahan.Enabled = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
