using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;

namespace Produksi_LIB
{
   public class Print
    {
        private Font jenisFont;

        public Font JenisFont
        {
            get { return jenisFont; }
            set { jenisFont = value; }
        }
        private StreamReader filePrint;

        public StreamReader FilePrint
        {
            get { return filePrint; }
            set { filePrint = value; }
        }
        private float marginKiri, marginKanan, marginAtas, marginBawah;

        public float MarginBawah
        {
            get { return marginBawah; }
            set { marginBawah = value; }
        }
        public float MarginKiri
        {
            get { return marginKiri; }
            set { marginKiri = value; }
        }
        public float MarginAtas
        {
            get { return marginAtas; }
            set { marginAtas = value; }
        }
        public float MarginKanan
        {
            get { return marginKanan; }
            set { marginKanan = value; }
        }
        public Print(string namaFile)
        {
            FilePrint = new StreamReader(namaFile);
            JenisFont = new Font("Arial", 10);
            MarginAtas = (float)10.5;
            MarginBawah = (float)10.5;
            MarginKiri = (float)10.5;
            MarginKanan = (float)10.5;
            MarginAtas = (float)10.5;
        }
       private void PrintLine(object sender, PrintPageEventArgs e)
        {
            int totalrowsperpage = (int)((e.MarginBounds.Height - MarginBawah) / JenisFont.GetHeight(e.Graphics));
            float y = MarginAtas;
            int totalrows = 0;
            string Line = FilePrint.ReadLine();
           while(totalrows < totalrowsperpage && Line != null)
           {
               y = MarginAtas + (totalrows * JenisFont.GetHeight(e.Graphics));
               e.Graphics.DrawString(Line, JenisFont, Brushes.Black, MarginKiri, y);
               totalrows++;
               Line = FilePrint.ReadLine();
           }
           if(Line != null)
           {
               e.HasMorePages = true;
           }
           else
           {
               e.HasMorePages = false;
           }
        }
       public string PrinttoPrinter(string Type)
       {
           try
           {
               PrintDocument p = new PrintDocument();
               if(Type == "text")
               {
                   p.PrintPage += new PrintPageEventHandler(PrintLine);

               }
               p.Print();
               FilePrint.Close();
               return "1";
           }
           catch(Exception e)
           {
               return "cetak gagal. " + e.Message;
           }
       }

    

    }
}
