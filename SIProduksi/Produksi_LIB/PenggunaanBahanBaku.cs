using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Produksi_LIB;

namespace Produksi_LIB
{
   public class PenggunaanBahanBaku
   {
        private Spk spk;
        private BahanBaku bahanBaku;
        private int jumlahMasuk;
        private int jumlahKeluar;
        private DateTime tanggalKeluar;
        private string stokOpnameTanggal;
        private int sisaStok;

        public int SisaStok
        {
            get { return sisaStok; }
            set { sisaStok = value; }
        }
        private string jenis;

        public string Jenis
        {
            get { return jenis; }
            set { jenis = value; }
        }

        #region CONSTRUCTORS
        public PenggunaanBahanBaku()
        {
            BahanBaku = new BahanBaku();
            Spk = new Spk();
            JumlahMasuk = 0;
            JumlahKeluar = 0;
            TanggalKeluar = DateTime.Now;
            StokOpnameTanggal = "";
            SisaStok = 0;
            Jenis = "";
        }
        public PenggunaanBahanBaku(BahanBaku pBahanBaku, Spk pSpk, int pJumlahMasuk, int pJumlahKeluar, DateTime pTanggalKeluar, string pStok, int pSisa, string pJenis)
        {
            Spk = pSpk;
            BahanBaku = pBahanBaku;
            JumlahMasuk = pJumlahMasuk;
            JumlahKeluar = pJumlahKeluar;
            TanggalKeluar = pTanggalKeluar;
            StokOpnameTanggal = pStok;
            SisaStok = pSisa;
            Jenis = pJenis;
        }
        #endregion

        #region PROPERTIES
        public Spk Spk
        {
            get { return spk; }
            set { spk = value; }
        }

        public BahanBaku BahanBaku
        {
            get { return bahanBaku; }
            set { bahanBaku = value; }
        }

        public int JumlahMasuk
        {
            get { return jumlahMasuk; }
            set { jumlahMasuk = value; }
        }

        public int JumlahKeluar
        {
            get { return jumlahKeluar; }
            set { jumlahKeluar = value; }
        }

        public DateTime TanggalKeluar
        {
            get { return tanggalKeluar; }
            set { tanggalKeluar = value; }
        }

        public string StokOpnameTanggal
        {
            get { return stokOpnameTanggal; }
            set { stokOpnameTanggal = value; }
        }
        #endregion

        #region METHODS
        public static string TambahData(PenggunaanBahanBaku c)
       {
           string sql = "INSERT INTO penggunaan_bahan_baku (id_bahan_baku, nomor_spk, jumlah_masuk, jumlah_keluar, tanggal_keluar, stok_opname_tanggal,sisa_stok, jenis) VALUES ('"
               + c.BahanBaku.Id + "', '" + c.Spk.NoSPK + "', '" + c.JumlahMasuk + "', '" + c.JumlahKeluar + "','" + c.TanggalKeluar.ToString("yyyy-MM-dd hh:mm:ss") + "','" + c.StokOpnameTanggal + "','" + c.SisaStok + "','" + c.Jenis + "')";

           try
           {
               Koneksi.JalankanPerintahDML(sql);
               return "1";
           }
           catch (MySqlException exc)
           {
               return exc.Message + ". Perintah SQL: " + sql;
           }
       }

        public static string BacaData(string kriteria, string nilaiKriteria, List<PenggunaanBahanBaku> listHasilData)
       {
           string sql = "";

           // JIka tidak ada kriteria yang diisikan
           if (kriteria == "")
           {
               sql = "SELECT b.id,b.nama,b.stok" +
                   ",s.nomor,ba.kode,b.nama,p.id,p.nama,d.jumlah_masuk,d.jumlah_keluar,d.tanggal_keluar,d.stok_opname_tanggal, d.sisa_stok, d.jenis,s.kode_barang from bahan_baku b inner join penggunaan_bahan_baku d on b.id = d.id_bahan_baku inner join spk s on d.nomor_spk = s.nomor inner join barang ba on s.kode_barang = ba.kode inner join pekerja p on s.id_kepala_pekerja = p.id order by s.kode_barang";
           }
           else
           {
               sql = "SELECT b.id,b.nama,b.stok" +
                   ",s.nomor,ba.kode,ba.nama,p.id,p.nama,d.jumlah_masuk,d.jumlah_keluar,d.tanggal_keluar,d.stok_opname_tanggal, d.sisa_stok, d.jenis,s.kode_barang from bahan_baku b inner join penggunaan_bahan_baku d on b.id = d.id_bahan_baku inner join spk s on d.nomor_spk = s.nomor inner join barang ba on s.kode_barang = ba.kode inner join pekerja p on s.id_kepala_pekerja = p.id WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
           }

           try
           {
               MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);
               while (hasilData.Read() == true) // selama masih ada data atau selama masih bisa membaca data
               {
                   BahanBaku b = new BahanBaku();
                   b.Id = hasilData.GetValue(0).ToString();
                   b.Nama = hasilData.GetValue(1).ToString();
                   b.Stok = int.Parse(hasilData.GetValue(2).ToString());
                   Spk s = new Spk();
                   s.NoSPK = hasilData.GetValue(3).ToString();
                   Barang ba = new Barang();
                   ba.Kode = hasilData.GetValue(4).ToString();
                   ba.Nama = hasilData.GetValue(5).ToString();
                   s.Brg = ba;
                   Pekerja p = new Pekerja();
                   p.IdPekerja = int.Parse(hasilData.GetValue(6).ToString());
                   p.Nama = hasilData.GetValue(7).ToString();
                   PenggunaanBahanBaku c = new PenggunaanBahanBaku();
                   c.BahanBaku = b;
                   c.Spk = s;
                   c.JumlahMasuk = int.Parse(hasilData.GetValue(8).ToString());
                   c.JumlahKeluar = int.Parse(hasilData.GetValue(9).ToString());
                   c.TanggalKeluar = DateTime.Parse(hasilData.GetValue(10).ToString());
                   c.StokOpnameTanggal = hasilData.GetValue(11).ToString();
                   c.SisaStok = int.Parse(hasilData.GetValue(12).ToString());
                   c.Jenis = hasilData.GetValue(13).ToString();
                   // Simpan ke list
                   listHasilData.Add(c);
               }

               return "1";
           }
           catch (MySqlException exc)
           {
               return exc.Message + ". Perintah sql : " + sql;
           }
       }
        #endregion
    }
}
