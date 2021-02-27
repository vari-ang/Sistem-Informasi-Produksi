using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Produksi_LIB;
using System.IO;
using System.Transactions;

namespace Produksi_LIB
{
   public class BOM
    {
       
        private string idbahanBaku;      
        private string kodebarang;       
        private string jumlahBagian;
        private string jumlahBijiLembarBatang;
        private int totalBiaya;
        private int biayaTukang;
        private int biayaOperasional;
        private int pengajuanHarga;  

        #region CONSTRUCTORS
        public BOM()
        {
            IdbahanBaku = "";
            Kodebarang = "";
            JumlahBagian = "";
            JumlahBijiLembarBatang = "";
            TotalBiaya = 0;
            BiayaOperasional = 0;
            BiayaTukang = 0;
            PengajuanHarga = 0;
        }
        public BOM(string bb, string pbarang, string jml, string jbl, int tb, int bo, int bt, int ph)
        {
            IdbahanBaku = bb;
            Kodebarang = pbarang;
            JumlahBagian = jml;
            JumlahBijiLembarBatang = jbl;
            TotalBiaya = tb;
            BiayaOperasional = bo;
            BiayaTukang = bt;
            PengajuanHarga = ph;
        }
        #endregion

        #region PROPERTIES
        public string IdbahanBaku
        {
            get { return idbahanBaku; }
            set { idbahanBaku = value; }
        }
        public string Kodebarang
        {
            get { return kodebarang; }
            set { kodebarang = value; }
        }
        public int BiayaOperasional
        {
            get { return biayaOperasional; }
            set { biayaOperasional = value; }
        }
        public int BiayaTukang
        {
            get { return biayaTukang; }
            set { biayaTukang = value; }
        }
        public int PengajuanHarga
        {
            get { return pengajuanHarga; }
            set { pengajuanHarga = value; }
        }
        public int TotalBiaya
        {
            get { return totalBiaya; }
            set { totalBiaya = value; }
        }
        public string JumlahBijiLembarBatang
        {
            get { return jumlahBijiLembarBatang; }
            set { jumlahBijiLembarBatang = value; }
        }
        public string JumlahBagian
        {
            get { return jumlahBagian; }
            set { jumlahBagian = value; }
        }
        #endregion

        public static string HapusData(string kode, string id)
        {
            using (var tranScope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {              
                try
                {
                    string sql = "";
                    if(id == "")
                    {
                        sql = "DELETE FROM bill_of_materials WHERE kode_barang = '" + kode + "'";
                    }
                    else
                    {
                        sql = "DELETE FROM bill_of_materials WHERE id_bahan_baku = '" + id + "' && kode_barang = '" + kode + "'";
                    }

                    string namaServer = Koneksi.GetNamaServer();
                    Koneksi.JalankanPerintahDML(sql);
                    tranScope.Complete();

                    return "1";
                }
                catch (Exception exc)
                {
                    tranScope.Dispose();

                    return exc.Message;
                }
            }
            
        }
        
        public static string TambahData(BOM pspk)
        {
            string sql = "INSERT INTO bill_of_materials VALUES ('" +
                              pspk.IdbahanBaku + "','" +
                              pspk.Kodebarang + "','" +
                              pspk.JumlahBagian + "','" +
                              pspk.JumlahBijiLembarBatang + "','" +
                              pspk.TotalBiaya + "','" +
                              pspk.BiayaOperasional + "','" +
                              pspk.BiayaTukang + "','" +
                              pspk.PengajuanHarga + "')";

            try
            {
                Koneksi.JalankanPerintahDML(sql);
                return "1";
            }
            catch (MySqlException exc)
            {
                return exc.Message + ". Perintah sql : " + sql;
            }
        }
       public static string PrintBOM(string kriteria, string nilaiKriteria, string filename)
        {
            try
            {
                List<BOM> lb = new List<BOM>();
                List<Barang> brg = new List<Barang>();
                List<BahanBaku> bb = new List<BahanBaku>();
                string hasil = BOM.BacaData(kriteria, nilaiKriteria, lb);
                string barang = Barang.BacaData("kode",lb[0].Kodebarang,brg);
                
                StreamWriter file = new StreamWriter(filename);
                int totalbiayabom = 0;
                int totalpengajuanbom = 0;
                file.WriteLine("");
                    file.WriteLine("TEACHING INDUSTRY");
                    file.WriteLine("Jl. Tenggilis Mejoyo, Kali Rungkut, Rungkut, Surabaya.");
                    file.WriteLine("+62 812-9536-9977");
                    file.WriteLine("=".PadRight(50,'='));
                    file.WriteLine("DOKUMEN BILL OF MATERIALS");
                    file.WriteLine("Kode Barang : " + brg[0].Kode);
                    file.WriteLine("Nama Barang : " + brg[0].Nama);
                    file.WriteLine("Keterangan : " + brg[0].Keterangan);
                    file.WriteLine("=".PadRight(50, '='));
                for(int i=0; i<lb.Count; i++)
                {
                    string pnamaBahan = "";
                    string pbagian = "";
                    string pUkuranMentah = "";
                    string pUkuranJadi = "";
                    string pUkuranLuas = "";
                    string pjumlahbagian = lb[i].JumlahBagian;
                    string pjumlahspes = lb[i].JumlahBijiLembarBatang;
                    string ptotalbiaya = lb[i].TotalBiaya.ToString("0,###");
                    string pbiayaoperasional = lb[i].BiayaOperasional.ToString("0,###");
                    string ppengajuanHarga = lb[i].PengajuanHarga.ToString("0,###");
                    string bk = BahanBaku.BacaData("BB.id", lb[i].IdbahanBaku, bb);
                    for(int j=0; j<bb.Count; j++)
                    {
                        if(bb[j].Id == lb[i].IdbahanBaku)
                        {
                            pnamaBahan = bb[j].Nama;
                            pUkuranJadi = bb[j].UkuranJadi;
                            pbagian = bb[j].Bagian;
                            pUkuranLuas = bb[j].UkuranLuasan;
                            pUkuranMentah = bb[j].UkuranMentah;
                        }
                    }
                    if(pnamaBahan.Length > 25)
                    {
                        pnamaBahan = pnamaBahan.Substring(0, 25);
                    }
                    totalbiayabom += lb[i].TotalBiaya;
                    totalpengajuanbom += lb[i].PengajuanHarga;
                    file.Write(pnamaBahan.PadRight(25,' '));
                    file.Write(pbagian.PadRight(19,' '));
                    file.Write(pUkuranMentah.PadRight(14, ' '));
                    file.Write(pUkuranJadi.PadRight(14, ' '));
                    file.Write(pUkuranLuas.PadRight(14, ' '));
                    file.Write(pjumlahbagian.PadRight(5,' '));
                    file.Write(pjumlahspes.PadRight(5,' '));
                    file.Write(ptotalbiaya.PadLeft(15,' '));
                    file.Write(pbiayaoperasional.PadLeft(15, ' '));
                    file.Write(ppengajuanHarga.PadLeft(15, ' '));
                    file.WriteLine("");
                }
                file.WriteLine("=".PadRight(50, '='));
                file.WriteLine("TOTAL BIAYA : " + totalbiayabom.ToString());
                file.WriteLine("TOTAL PENGAJUAN HARGA : " + totalpengajuanbom.ToString());
                file.WriteLine("=".PadRight(50, '='));
                file.Close();
                Print p = new Print(filename);
                p.PrinttoPrinter("text");
                return "1";
            }
          catch(MySqlException e){
              return e.Message;
          }
        }
        public static string BacaData(string kriteria, string nilaiKriteria, List<BOM> listHasilData)
        {
            string sql = "";

            // JIka tidak ada kriteria yang diisikan
            if (kriteria == "")
            {
                sql = "SELECT * FROM bill_of_materials order by kode_barang";
            }
            else
            {
                sql = "SELECT * FROM bill_of_materials WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

                while (hasilData.Read() == true) // selama masih ada data atau selama masih bisa membaca data
                {
                    // Baca hasil dari MySqlDataReader dan simpan di objek
                    BOM b = new BOM();
                    b.IdbahanBaku = hasilData.GetValue(0).ToString();
                    b.Kodebarang = hasilData.GetValue(1).ToString();
                    b.JumlahBagian = hasilData.GetValue(2).ToString();
                    b.JumlahBijiLembarBatang = hasilData.GetValue(3).ToString();
                    b.TotalBiaya = int.Parse(hasilData.GetValue(4).ToString());
                    b.BiayaOperasional = int.Parse(hasilData.GetValue(5).ToString());
                    b.BiayaTukang = int.Parse(hasilData.GetValue(6).ToString());
                    b.PengajuanHarga = int.Parse(hasilData.GetValue(7).ToString());

                    // Simpan ke list
                    listHasilData.Add(b);
                }

                return "1";
            }
            catch (MySqlException exc)
            {
                return exc.Message + ". Perintah sql : " + sql;
            }
        }
        
        public static string BacaData(string kriteria,string kriteria2, string nilaiKriteria,string nilaikriteria2, List<BOM> listHasilData)
        {
            string sql = "";

            // JIka tidak ada kriteria yang diisikan
            
                sql = "SELECT * FROM bill_of_materials WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%' AND " + kriteria2 + " LIKE '%" + nilaikriteria2 + "%'";
            

            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

                while (hasilData.Read() == true) // selama masih ada data atau selama masih bisa membaca data
                {
                    // Baca hasil dari MySqlDataReader dan simpan di objek
                    BOM b = new BOM();
                    b.IdbahanBaku = hasilData.GetValue(0).ToString();
                    b.Kodebarang = hasilData.GetValue(1).ToString();
                    b.JumlahBagian = hasilData.GetValue(2).ToString();
                    b.JumlahBijiLembarBatang = hasilData.GetValue(3).ToString();
                    b.TotalBiaya = int.Parse(hasilData.GetValue(4).ToString());
                    b.BiayaOperasional = int.Parse(hasilData.GetValue(5).ToString());
                    b.BiayaTukang = int.Parse(hasilData.GetValue(6).ToString());
                    b.PengajuanHarga = int.Parse(hasilData.GetValue(7).ToString());

                    // Simpan ke list
                    listHasilData.Add(b);
                }

                return "1";
            }
            catch (MySqlException exc)
            {
                return exc.Message + ". Perintah sql : " + sql;
            }
        }

        public static string UbahData(BOM pC)
        {
            string sql = "UPDATE bill_of_materials SET jumlah_bagian = '" + pC.JumlahBagian +
                         "', jumlah_biji_lembar_batang = '" + pC.JumlahBijiLembarBatang +
                         "', total_biaya = '" + pC.TotalBiaya +
                         "', biaya_operasional = '" + pC.BiayaOperasional +
                         "', biaya_tukang = '" + pC.BiayaTukang +
                         "' WHERE id_bahan_baku = '" + pC.IdbahanBaku + "' && kode_barang = '" + pC.Kodebarang + "'";

            try
            {
                Koneksi.JalankanPerintahDML(sql);
                return "1";
            }
            catch (MySqlException exc)
            {
                return exc.Message + ". Perintah sql : " + sql;
            }
        }
    }
}
