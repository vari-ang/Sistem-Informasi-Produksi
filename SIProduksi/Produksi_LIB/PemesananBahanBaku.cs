using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using System.Transactions;
using Produksi_LIB;
namespace Produksi_LIB
{
   public class PemesananBahanBaku
    {
        private List<DetailPemesananBahanBaku> listpemesanan;

        public List<DetailPemesananBahanBaku> Listpemesanan
        {
            get { return listpemesanan; }
            set { listpemesanan = value; }
        }
        private string kode;

        public string Kode
        {
            get { return kode; }
            set { kode = value; }
        }
       
        private Spk sPK;

        public Spk SPK
        {
            get { return sPK; }
            set { sPK = value; }
        }

        private DateTime tanggal;

        public DateTime Tanggal
        {
            get { return tanggal; }
            set { tanggal = value; }
        }
        private int totalHarga;

        public int TotalHarga
        {
            get { return totalHarga; }
            set { totalHarga = value; }
        }

        public PemesananBahanBaku()
        {
            Kode = "";
            Tanggal = DateTime.Now;
            TotalHarga = 0;
            Listpemesanan = new List<DetailPemesananBahanBaku>();
        }
        public PemesananBahanBaku(string pKode, Spk pSPK, DateTime ptanggal, int ptotalHarga)
        {
            Kode = pKode;
            SPK = pSPK;
            Tanggal = ptanggal;
            TotalHarga = ptotalHarga;
            Listpemesanan = new List<DetailPemesananBahanBaku>();
        }
        public void TambahPemesanan(DetailPemesananBahanBaku k){
            DetailPemesananBahanBaku b = new DetailPemesananBahanBaku(k.Id, k.KodePBB, k.IDbahan, k.Jenis, k.Jumlah, k.HargaSatuan, k.SubTotalHarga, "", k.Keterangan);
            listpemesanan.Add(b);
            
        }
        public static string TambahData(PemesananBahanBaku c)
        {
            using (var tranScope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                string sql = "INSERT INTO pemesanan_bahan_baku (kode,nomor_spk,tanggal,total_harga) VALUES ('" +
                    c.Kode + "', '" + c.SPK.NoSPK + "', '" + c.Tanggal.ToString("yyyy-MM-dd hh:mm:ss") + "','" + c.TotalHarga + "')";

                try
                {
                    Koneksi.JalankanPerintahDML(sql);
                    for (int i = 0; i < c.Listpemesanan.Count; i++)
                    {
                        //string sql2 = "INSERT INTO detail_pemesanan_bahan_baku VALUES('" + c.Listpemesanan[i].Id + "','" + c.Listpemesanan[i].KodePBB.Kode + "','" + c.Listpemesanan[i].IDbahan.Id +
                        //    "','" + c.Listpemesanan[i].Jenis + "','" + c.Listpemesanan[i].Jumlah + "','" + c.Listpemesanan[i].HargaSatuan +
                        //    "','" + c.Listpemesanan[i].SubTotalHarga + "','" + c.Listpemesanan[i].TanggalTerima.ToString("yyyy-MM-dd hh:mm:ss") + "','" + c.Listpemesanan[i].Keterangan + "')";
                        //Koneksi.JalankanPerintahDML(sql2);
                        string hass = DetailPemesananBahanBaku.TambahData(c.Listpemesanan[i]);
                    }
                    tranScope.Complete();
                    return "1";
                }
                catch (MySqlException exc)
                {
                    tranScope.Dispose();
                    return exc.Message + ". Perintah SQL: " + sql;
                }
            }
        }

        public static string BacaData(string kriteria, string nilaiKriteria, List<PemesananBahanBaku> listHasilData)
        {
            string sql = "";

            // JIka tidak ada kriteria yang diisikan
            if (kriteria == "")
            {
                sql = "SELECT p.kode, s.nomor, p.tanggal, p.total_harga FROM pemesanan_bahan_baku p inner join spk s on p.nomor_spk = s.nomor";
            }
            else
            {
                sql = "SELECT p.kode, s.nomor, p.tanggal, p.total_harga FROM pemesanan_bahan_baku p inner join spk s on p.nomor_spk = s.nomor WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

                while (hasilData.Read() == true) // selama masih ada data atau selama masih bisa membaca data
                {
                    // Baca hasil dari MySqlDataReader dan simpan di objek
                    PemesananBahanBaku c = new PemesananBahanBaku();
                    c.Kode = hasilData.GetValue(0).ToString();
                    Spk s = new Spk();
                    s.NoSPK = hasilData.GetValue(1).ToString();
                    c.SPK = s;
                    c.Tanggal = DateTime.Parse(hasilData.GetValue(2).ToString());
                    c.TotalHarga = int.Parse(hasilData.GetValue(3).ToString());
                    
                        string hasis = DetailPemesananBahanBaku.BacaData("kode_pemesanan_bahan_baku", c.Kode, c.Listpemesanan);
                    

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
    }
}
