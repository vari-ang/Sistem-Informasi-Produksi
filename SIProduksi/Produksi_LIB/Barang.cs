using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Produksi_LIB;

namespace Produksi_LIB
{
    public class Barang
    {
        private string kode;
        private string nama;
        private int jumlah;
        private string satuan;
        private int hargaSatuan;
        private string keterangan;
        private OrderPenjualan orderPenjualan;

        #region CONSTRUCTORS
        public Barang()
        {
            Kode = "";
            Nama = "";
            Jumlah = 0;
            Satuan = "";
            HargaSatuan = 0;
            Keterangan = "";
        }
        public Barang(string pKode, string pNama, int pJumlah, string pSatuan, int pHargaSatuan, string pKeterangan, OrderPenjualan pOrderPenjualan)
        {
            Kode = pKode;
            Nama = pNama;
            Jumlah = pJumlah;
            Satuan = pSatuan;
            HargaSatuan = pHargaSatuan;
            Keterangan = pKeterangan;
            OrderPenjualan = pOrderPenjualan;
        }
        #endregion

        #region PROPERTIES
        public string Kode
        {
            get { return kode; }
            set { kode = value; }
        }

        public string Nama
        {
            get { return nama; }
            set { nama = value; }
        }

        public int Jumlah
        {
            get { return jumlah; }
            set { jumlah = value; }
        }

        public string Satuan
        {
            get { return satuan; }
            set { satuan = value; }
        }

        public int HargaSatuan
        {
            get { return hargaSatuan; }
            set { hargaSatuan = value; }
        }

        public string Keterangan
        {
            get { return keterangan; }
            set { keterangan = value; }
        }

        public OrderPenjualan OrderPenjualan
        {
            get { return orderPenjualan; }
            set { orderPenjualan = value; }
        }
        #endregion

        #region METHODS
        public static string BacaData(string kriteria, string nilaiKriteria, List<Barang> listHasilData)
       {
           string sql = "";

           // JIka tidak ada kriteria yang diisikan
           if (kriteria == "")
           {
               sql = "SELECT * FROM barang";
           }
           else
           {
               sql = "SELECT * FROM barang WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
           }

           try
           {
               MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

               while (hasilData.Read() == true) // selama masih ada data atau selama masih bisa membaca data
               {
                   // Baca hasil dari MySqlDataReader dan simpan di objek
                   Barang b = new Barang();
                   b.Kode = hasilData.GetValue(0).ToString();
                   b.Nama = hasilData.GetValue(1).ToString();
                   b.Jumlah = int.Parse(hasilData.GetValue(2).ToString());
                   b.Satuan = hasilData.GetValue(3).ToString();
                   b.HargaSatuan = int.Parse(hasilData.GetValue(4).ToString());
                   b.Keterangan = hasilData.GetValue(5).ToString();

                    OrderPenjualan op = new OrderPenjualan();
                    op.NoOrder = hasilData.GetValue(6).ToString();

                    b.OrderPenjualan = op;

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

       public static string UbahData(Barang pB)
       {
           string sql = "UPDATE barang SET nama = '" + pB.Nama +
                        "', jumlah = '" + pB.Jumlah + "', satuan = '" + pB.Satuan + "', harga_satuan = '" + pB.HargaSatuan + "', keterangan = '" + pB.Keterangan + 
                        "' WHERE kode = '" + pB.Kode + "'";

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
       public static string TambahData(Barang b)
       {
           string sql = "";
           if(b.OrderPenjualan != null)
           {
                sql = "INSERT INTO barang (kode,nama,jumlah,satuan,harga_satuan,keterangan,id_order_penjualan) values('" + b.Kode + "','" + b.Nama + "','" + b.Jumlah + "','" + b.Satuan
               + "','" + b.HargaSatuan + "','" + b.Jumlah + "','" + b.OrderPenjualan.NoOrder + "')";
           }
           else
           {
                sql = "INSERT INTO barang (kode,nama,jumlah,satuan,harga_satuan,keterangan) values('" + b.Kode + "','" + b.Nama + "','" + b.Jumlah + "','" + b.Satuan
               + "','" + b.HargaSatuan + "','" + b.Jumlah + "')";
           }
            
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
       public static string HapusData(string kode)
       {
           string sql = "DELETE FROM barang WHERE kode = '" + kode + "'";

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
