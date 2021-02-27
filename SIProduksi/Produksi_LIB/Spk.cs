using Produksi_LIB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Produksi_LIB
{
    public class Spk
    {
        private string noSPK;
        private DateTime tanggal;
        private Barang brg;
        private Pekerja idPekerja;
        private string pekerjaan;
        private string lokasi;
        private int biaya;
        private string lamaPengerjaan;
        private string syarat;
        private string metode;

        #region PROPERTIES
        public string NoSPK
        {
            get { return noSPK; }
            set { noSPK = value; }
        }

        public DateTime Tanggal
        {
            get { return tanggal; }
            set { tanggal = value; }
        }
        public Barang Brg
        {
            get { return brg; }
            set { brg = value; }
        }
        public Pekerja IdPekerja
        {
            get { return idPekerja; }
            set { idPekerja = value; }
        }
        

        public string Pekerjaan
        {
            get { return pekerjaan; }
            set { pekerjaan = value; }
        }
        

        public string Lokasi
        {
            get { return lokasi; }
            set { lokasi = value; }
        }
        

        public int Biaya
        {
            get { return biaya; }
            set { biaya = value; }
        }
        

        public string LamaPengerjaan
        {
            get { return lamaPengerjaan; }
            set { lamaPengerjaan = value; }
        }
        

        public string Syarat
        {
            get { return syarat; }
            set { syarat = value; }
        }
        public string Metode
        {
            get { return metode; }
            set { metode = value; }
        }
        #endregion

        #region CONSTRUCTORS
        public Spk()
        {
            NoSPK = "";
            Tanggal = DateTime.Now;
            Pekerjaan = "";
            Lokasi = "";
            Biaya = 0;
            LamaPengerjaan = "";
            Syarat = "";
        }
        public Spk(string nos)
        {

            NoSPK = nos;
            Tanggal = DateTime.Now;
            Pekerjaan = "";
            Lokasi = "";
            Biaya = 0;
            LamaPengerjaan = "";
            Syarat = "";
        }
        public Spk(string nos, DateTime pTanggal, Barang porderpenjualan, 
             Pekerja spek, string spekerja, string slokasi, int sbiaya, 
            string slamapekerja, string psyarat)
        {
            NoSPK = nos;
            Tanggal = pTanggal;
            brg = porderpenjualan;
            
            IdPekerja = spek;
            Pekerjaan = spekerja;
            Lokasi = slokasi;
            Biaya = sbiaya;
            LamaPengerjaan = slamapekerja;
            Syarat = psyarat;
        }
        public Spk(string nos, DateTime pTanggal, Barang porderpenjualan,
             Pekerja spek, string spekerja, string slokasi, int sbiaya,
            string slamapekerja, string psyarat, string pMetode)
        {
            NoSPK = nos;
            Tanggal = pTanggal;
            brg = porderpenjualan;

            IdPekerja = spek;
            Pekerjaan = spekerja;
            Lokasi = slokasi;
            Biaya = sbiaya;
            LamaPengerjaan = slamapekerja;
            Syarat = psyarat;
            Metode = pMetode;
        }
        #endregion

        #region METHODS
        public static string GenerateCode(out string pHasilId)
        {
            string sql = "SELECT SUBSTRING(nomor, 13, 3) " +
                         "FROM spk WHERE Date(Tanggal) = Date(CURRENT_DATE) " +
                         "ORDER BY nomor DESC LIMIT 1";

            pHasilId = "";

            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

                string noUrutTransTerbaru = "";

                if (hasilData.Read() == true)
                {
                    int noUrutTrans = int.Parse(hasilData.GetValue(0).ToString()) + 1;
                    noUrutTransTerbaru = noUrutTrans.ToString().PadLeft(3, '0'); // jika noUrutTrans < 3
                }
                else
                {
                    noUrutTransTerbaru = "001";
                }

                string tahun = DateTime.Now.Year.ToString();
                string bulan = DateTime.Now.Month.ToString().PadLeft(2, '0');
                string tanggal = DateTime.Now.Day.ToString().PadLeft(2, '0');

                pHasilId = "SP/" + tahun + bulan + tanggal + "/" + noUrutTransTerbaru.ToString();

                return "1";
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }
        public static string TambahData(Spk pspk)
        {
            string sql = "INSERT INTO spk VALUES ('" +
                              pspk.NoSPK + "','" +
                              pspk.Tanggal.ToString("yyyy-MM-dd hh:mm:ss") + "','" +
                              pspk.Brg.Kode + "','" +
                              pspk.IdPekerja.IdPekerja + "','" +
                              pspk.Pekerjaan + "','" +
                              pspk.Lokasi + "','" +
                              pspk.Biaya + "','" +
                              pspk.LamaPengerjaan + "','" +
                              pspk.Syarat + "','" +
                              pspk.Metode +"')";

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

        public static string UbahData(Spk pspk)
        {
            string sql = "UPDATE spk SET nomor = '" + pspk.NoSPK +
                         "', tanggal = '" + pspk.Tanggal.ToString("yyyy-MM-dd hh:mm:ss") +
                         "', kode_barang = '" + pspk.Brg.Kode +
                       
                         "', id_pekerja = '" + pspk.IdPekerja.IdPekerja +
                         "', pekerjaan = '" + pspk.Pekerjaan +
                         "', lokasi = '" + pspk.Lokasi +
                         "', biaya_pekerjaan = '" + pspk.Biaya +
                         "', lama_pekerjaan = '" + pspk.LamaPengerjaan +
                         "', syarat = '" + pspk.Syarat +
                         "' WHERE nomor = '" + pspk.NoSPK + "'";

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

        public static string HapusData(string pspk)
        {
            string sql = "DELETE FROM spk WHERE nomor = '" + pspk + "'";

            string namaServer = Koneksi.GetNamaServer();

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

        public static string BacaData(string kriteria, string nilaiKriteria, List<Spk> ListHasilData)
        {

            ListHasilData.Clear();
            string sql = "";

            if (kriteria == "")
            {
                // s= spk, o=orde penjualan, c = customer, p = pekerja,b barang
                sql = "SELECT S.nomor, S.Tanggal, C.id, C.nama, P.id, P.nama, S.pekerjaan, S.lokasi, S.biaya_pekerjaan, S.lama_pekerjaan, S.syarat, B.kode, B.nama, B.jumlah, B.satuan, B.harga_satuan,B.keterangan, s.metode " +
                    " From customer C inner join order_penjualan O on C.id = O.id_customer inner join barang B on O.id = B.id_order_penjualan inner join spk S on B.kode = S.kode_barang inner join pekerja P on S.id_kepala_pekerja = P.id where B.id_order_penjualan is not null";
            }
            else
            {
                sql = "SELECT S.nomor, S.Tanggal, C.id, C.nama, P.id, P.nama, S.pekerjaan, S.lokasi, S.biaya_pekerjaan, S.lama_pekerjaan, S.syarat, B.kode, B.nama, B.jumlah, B.satuan, B.harga_satuan,B.keterangan, s.metode " +
                    " From customer C inner join order_penjualan O on C.id = O.id_customer inner join barang B on O.id = B.id_order_penjualan inner join spk S on B.kode = S.kode_barang inner join pekerja P on S.id_kepala_pekerja = P.id" +
                    " WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

                while (hasilData.Read() == true)
                {
                    Spk spk = new Spk();
                    spk.NoSPK = hasilData.GetValue(0).ToString();
                    spk.Tanggal = DateTime.Parse(hasilData.GetValue(1).ToString());
                    spk.Pekerjaan = hasilData.GetValue(6).ToString();
                    spk.Lokasi = hasilData.GetValue(7).ToString();
                    spk.Biaya = int.Parse(hasilData.GetValue(8).ToString());
                    spk.LamaPengerjaan = hasilData.GetValue(9).ToString();
                    spk.Syarat = hasilData.GetValue(10).ToString();
                    spk.Metode = hasilData.GetValue(17).ToString();

                    Barang b = new Barang();
                    b.Kode = hasilData.GetValue(11).ToString();
                    b.Nama = hasilData.GetValue(12).ToString();
                    b.Jumlah = int.Parse(hasilData.GetValue(13).ToString());
                    b.Satuan = hasilData.GetValue(14).ToString();
                    b.HargaSatuan = int.Parse(hasilData.GetValue(15).ToString());
                    b.Keterangan = hasilData.GetValue(16).ToString();
                    spk.Brg = b;
                    
                    Pekerja pkr = new Pekerja();
                    pkr.IdPekerja = int.Parse(hasilData.GetValue(4).ToString());
                    pkr.Nama = hasilData.GetValue(5).ToString();
                    spk.IdPekerja = pkr;
                    ListHasilData.Add(spk);
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
