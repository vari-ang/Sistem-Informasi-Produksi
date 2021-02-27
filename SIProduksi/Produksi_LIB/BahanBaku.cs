using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Produksi_LIB;
using MySql.Data.MySqlClient;
namespace Produksi_LIB
{
    public class BahanBaku
    {
        private string id;
        private string nama;
        private string bagian;
        private string ukuranMentah;
        private string ukuranLuasan;
        private string ukuranJadi;
        private int stok;
        private int hargaSatuan;
        private Supplier supplier;

        #region CONSTRUCTORS
        public BahanBaku()
        {
            Id = "";
            Nama = "";
            Bagian = "";
            UkuranMentah = "";
            UkuranLuasan = "";
            UkuranJadi = "";
            Stok = 0;
            HargaSatuan = 0;
        }
        public BahanBaku(string pid, string pNama, string pBagian, string pUkuranMentah, string pUkuranLuasan, string pUkuranJadi
            , int pStok, int pHargaSatuan, Supplier pSupplier)
        {
            Id = pid;
            Nama = pNama;
            Bagian = pBagian;
            UkuranMentah = pUkuranMentah;
            UkuranLuasan = pUkuranLuasan;
            UkuranJadi = pUkuranJadi;
            Stok = pStok;
            HargaSatuan = pHargaSatuan;
            Supplier = pSupplier;
        }
        #endregion

        #region PROPERTIES
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nama
        {
            get { return nama; }
            set { nama = value; }
        }

        public string Bagian
        {
            get { return bagian; }
            set { bagian = value; }
        }

        public string UkuranMentah
        {
            get { return ukuranMentah; }
            set { ukuranMentah = value; }
        }

        public string UkuranLuasan
        {
            get { return ukuranLuasan; }
            set { ukuranLuasan = value; }
        }

        public string UkuranJadi
        {
            get { return ukuranJadi; }
            set { ukuranJadi = value; }
        }
     
        public int Stok
        {
            get { return stok; }
            set { stok = value; }
        }

        public int HargaSatuan
        {
            get { return hargaSatuan; }
            set { hargaSatuan = value; }
        }

        public Supplier Supplier
        {
            get { return supplier; }
            set { supplier = value; }
        }
        #endregion

        #region METHODS
        public static string TambahData(BahanBaku b)
        {
            string sql = "INSERT INTO bahan_baku (id, nama, bagian,ukuran_mentah,ukuran_luasan,ukuran_jadi,stok,harga_satuan,id_supplier) VALUES ('" +
                b.Id + "', '" + b.Nama.Replace("'", "\\'") + "', '" + b.Bagian + "', '" + b.UkuranMentah + "','" +
            b.UkuranLuasan + "','" + b.UkuranJadi + "','" + b.Stok + "','" + b.HargaSatuan + "','" + b.Supplier.IdSupplier + "')";

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

        public static string BacaData(string kriteria, string nilaiKriteria, List<BahanBaku> listHasilData)
        {
            string sql = "";

            // JIka tidak ada kriteria yang diisikan
            if (kriteria == "")
            {
                sql = "SELECT BB.Id AS Id_Bahan_Baku, BB.Nama, BB.Bagian, BB.Ukuran_Mentah, BB.Ukuran_Luasan, BB.Ukuran_Jadi, BB.Stok, BB.Harga_Satuan, S.Id AS Id_Supplier, S.Nama AS Nama_Supplier" +
                      " FROM bahan_baku BB INNER JOIN supplier S ON BB.id_supplier = S.id order by Nama";
            }
            else
            {
                sql = "SELECT BB.Id AS Id_Bahan_Baku, BB.Nama, BB.Bagian, BB.Ukuran_Mentah, BB.Ukuran_Luasan, BB.Ukuran_Jadi, BB.Stok, BB.Harga_Satuan, S.Id AS Id_Supplier, S.Nama AS Nama_Supplier" +
                      " FROM bahan_baku BB INNER JOIN supplier S ON BB.id_supplier = S.id " +
                      " WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%' order by Nama"; ;
            }

            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

                while (hasilData.Read() == true) // selama masih ada data atau selama masih bisa membaca data
                {
                    // Baca hasil dari MySqlDataReader dan simpan di objek
                    BahanBaku c = new BahanBaku();
                    c.Id = hasilData.GetValue(0).ToString();
                    c.Nama = hasilData.GetValue(1).ToString();
                    c.Bagian = hasilData.GetValue(2).ToString();
                    c.UkuranMentah = hasilData.GetValue(3).ToString();
                    c.UkuranLuasan = hasilData.GetValue(4).ToString();
                    c.UkuranJadi = hasilData.GetValue(5).ToString();
                    c.Stok = int.Parse(hasilData.GetValue(6).ToString());
                    c.HargaSatuan = int.Parse(hasilData.GetValue(7).ToString());

                    Supplier s = new Supplier();
                    s.IdSupplier = hasilData.GetValue(8).ToString();
                    s.Nama = hasilData.GetValue(9).ToString();

                    c.Supplier = s;

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

        public static string UbahData(BahanBaku p)
        {
            string sql = "UPDATE bahan_baku SET Nama = '" + p.Nama.Replace("'", "\\'") +
                         "', bagian = '" + p.Bagian + "', ukuran_mentah = '" + p.UkuranMentah + "', ukuran_luasan = '" +
                         p.UkuranLuasan + "', ukuran_jadi = '" + p.UkuranJadi +
                         "', stok = '" + p.Stok + "', harga_satuan = '" + p.HargaSatuan + "'" + 
                         "WHERE id = '" + p.Id + "'";

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
        public static string TambahStok(string p, int jumlah)
        {
            string sql = "UPDATE bahan_baku SET stok = stok + " + jumlah + " WHERE id = '" + p + "'"; 

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
        public static string SetStok(string p, int jumlah)
        {
            string sql = "UPDATE bahan_baku SET stok = " + jumlah + " WHERE id = '" + p + "'";

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
        public static string HapusData(string kode)
        {
            string sql = "DELETE FROM bahan_baku WHERE id = '" + kode + "'";

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
        #endregion
    }
}
