using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIProduksi
{
    public partial class FormLoad : Form
    {
        public FormLoad()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 20;
            if (panel2.Width >= 700)
            {
                FormUtama frm = new FormUtama();
                frm.Owner = this;
                frm.Show();
                this.Hide();
                timer1.Stop();
                timer1.Enabled = false;

            }
        }
    }
}
