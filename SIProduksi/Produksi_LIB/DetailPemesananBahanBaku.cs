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
    public class DetailPemesananBahanBaku
    {
        private string kedatangan;

        public string Kedatangan
        {
            get { return kedatangan; }
            set { kedatangan = value; }
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private PemesananBahanBaku kodePBB;

        public PemesananBahanBaku KodePBB
        {
            get { return kodePBB; }
            set { kodePBB = value; }
        }
        private BahanBaku iDbahan;

        public BahanBaku IDbahan
        {
            get { return iDbahan; }
            set { iDbahan = value; }
        }
        private string jenis;

        public string Jenis
        {
            get { return jenis; }
            set { jenis = value; }
        }
        private int jumlah;

        public int Jumlah
        {
            get { return jumlah; }
            set { jumlah = value; }
        }
        private int hargaSatuan;

        public int HargaSatuan
        {
            get { return hargaSatuan; }
            set { hargaSatuan = value; }
        }
        private int subTotalHarga;

        public int SubTotalHarga
        {
            get { return subTotalHarga; }
            set { subTotalHarga = value; }
        }
        private DateTime tanggalTerima;

        public DateTime TanggalTerima
        {
            get { return tanggalTerima; }
            set { tanggalTerima = value; }
        }
        private string keterangan;

        public string Keterangan
        {
            get { return keterangan; }
            set { keterangan = value; }
        }
        public DetailPemesananBahanBaku()
        {
            Id = 0;
            Jenis = "";
            Jumlah = 0;
            HargaSatuan = 0;
            SubTotalHarga = 0;
            TanggalTerima = DateTime.Now;
            Keterangan = "";
            Kedatangan = "0";
        }
        public DetailPemesananBahanBaku(int pId, PemesananBahanBaku pPBB,BahanBaku idb, string pJenis, int pjumlah, int phargasatuan, int psubtotal, string ptanggal, string pket)
        {
            Id = pId;
            IDbahan = idb;
            KodePBB = pPBB;
            Jenis = pJenis;
            Jumlah = pjumlah;
            HargaSatuan = phargasatuan;
            SubTotalHarga = psubtotal;
            TanggalTerima = DateTime.Now;
            Keterangan = pket;
            Kedatangan = "0";
        }
        public static string GenerateCode(out string pHasilId)
        {
            string sql = "SELECT COUNT(*) FROM detail_pemesanan_bahan_baku";
            pHasilId = "";

            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

                if (hasilData.Read() == true)
                {
                    if (hasilData.GetValue(0).ToString() != "")
                    {
                        int idTerbaru = int.Parse(hasilData.GetValue(0).ToString()) + 1;

                        pHasilId = idTerbaru.ToString();
                    }
                    else
                    {
                        // Jika tidak ditemukan data dengan kategori tertentu maka kode terbaru = "J1"
                        pHasilId = "1";
                    }
                }
                return "1";
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }
        public static string TambahData(DetailPemesananBahanBaku pspk)
        {
            string sql = "INSERT INTO detail_pemesanan_bahan_baku(id,kode_pemesanan_bahan_baku , id_bahan_baku, jenis, jumlah, harga_satuan, sub_total_harga, tanggal_terima, keterangan, kedatangan) VALUES ('" +
                              pspk.Id + "','" +                
                              pspk.KodePBB.Kode + "','" +
                              pspk.IDbahan.Id + "','" +
                              pspk.Jenis + "','" +
                              pspk.Jumlah + "','" +
                              pspk.HargaSatuan + "','" +
                              pspk.SubTotalHarga + "','" + pspk.TanggalTerima.ToString("yyyy-MM-dd hh:mm:ss") + "','" +
                              pspk.Keterangan +"','" + pspk.Kedatangan + "')";

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

        public static string UbahData(DetailPemesananBahanBaku pspk)
        {
            string sql = "UPDATE detail_pemesanan_bahan_baku SET jenis = '" + pspk.Jenis +
                         "', jumlah = '" + pspk.Jumlah +
                         "', harga_satuan = '" + pspk.HargaSatuan +
                         "', sub_total_harga = '" + pspk.SubTotalHarga +
                         "', tanggal_terima = '" + pspk.TanggalTerima.ToString("yyyy-MM-dd hh:mm:ss") +
                         "', keterangan = '" + pspk.Keterangan + "' kedatangan = '" + pspk.Kedatangan +
                         "' WHERE id = '" + pspk.Id + "'";

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
        public static string Confirm(int pspk,DateTime p)
        {
            string sql = "UPDATE detail_pemesanan_bahan_baku SET tanggal_terima = '" + p.ToString("yyyy-MM-dd hh:mm:ss") +
                         "' , kedatangan = '1' WHERE id = '" + pspk + "'";

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
        public static string BacaData(string kriteria, string nilaiKriteria, List<DetailPemesananBahanBaku> listHasilData)
        {
            string sql = "";

            // JIka tidak ada kriteria yang diisikan
            if (kriteria == "")
            {
                sql = "SELECT d.id, p.kode, b.id, b.nama, d.jenis, d.jumlah, d.harga_satuan, d.sub_total_harga, d.tanggal_terima, d.keterangan, d.kedatangan FROM detail_pemesanan_bahan_baku d inner join pemesanan_bahan_baku p on d.kode_pemesanan_bahan_baku = p.kode inner join bahan_baku b on d.id_bahan_baku = b.id";
            }
            else
            {
                sql = "SELECT d.id, p.kode, b.id, b.nama, d.jenis, d.jumlah, d.harga_satuan, d.sub_total_harga, d.tanggal_terima, d.keterangan, d.kedatangan FROM detail_pemesanan_bahan_baku d inner join pemesanan_bahan_baku p on d.kode_pemesanan_bahan_baku = p.kode inner join bahan_baku b on d.id_bahan_baku = b.id WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

                while (hasilData.Read() == true) // selama masih ada data atau selama masih bisa membaca data
                {
                    
                    // Baca hasil dari MySqlDataReader dan simpan di objek
                    DetailPemesananBahanBaku b = new DetailPemesananBahanBaku();
                    b.Id = int.Parse(hasilData.GetValue(0).ToString());
                    PemesananBahanBaku c = new PemesananBahanBaku();
                    c.Kode = hasilData.GetValue(1).ToString();
                    b.KodePBB = c;
                    BahanBaku s = new BahanBaku();
                    s.Id = hasilData.GetValue(2).ToString();
                    s.Nama = hasilData.GetValue(3).ToString();
                    b.IDbahan = s;
                    b.Jenis = hasilData.GetValue(4).ToString();
                    b.Jumlah = int.Parse(hasilData.GetValue(5).ToString());
                    b.HargaSatuan = int.Parse(hasilData.GetValue(6).ToString());
                    b.SubTotalHarga = int.Parse(hasilData.GetValue(7).ToString());
                    b.TanggalTerima = DateTime.Parse(hasilData.GetValue(8).ToString());
                    b.Keterangan = hasilData.GetValue(9).ToString();
                    b.Kedatangan = hasilData.GetValue(10).ToString();
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
    }
}
