using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Produksi_LIB
{
    public class Penerimaan
    {
        private string nomor;
        private Pengiriman nomorPengiriman;
        private DateTime tanggal;
        private string nama;
        private string alamat;
        private string keterangan;

        #region CONS
        public Penerimaan()
        {
            Nomor = "";
            NomorPengiriman = null;
            Tanggal = DateTime.Now;
            Nama = "";
            Alamat = "";
            Keterangan = "";
        }
        public Penerimaan(string pNomor, Pengiriman p, DateTime pTanggal, string pNama, string pAlamat, string pKeterangan)
        {
            Nomor = pNomor;
            NomorPengiriman = p;
            Tanggal = pTanggal;
            Nama = pNama;
            Alamat = pAlamat;
            Keterangan = pKeterangan;
        }
        #endregion

        #region PROP
        public string Nomor { get; set; }
        public Pengiriman NomorPengiriman { get; set; }
        public DateTime Tanggal { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }
        public string Keterangan { get; set; }
        #endregion

        #region METH
        public static string TambahData(Penerimaan pPenerimaan)
        {
            string sql = "INSERT INTO nota_penerimaan (nomor, nomor_dokumen_pengiriman, tanggal, nama, alamat, keterangan)VALUES ('" +
                              pPenerimaan.Nomor + "','" +
                              pPenerimaan.NomorPengiriman.NomorDokumen + "','" +
                              pPenerimaan.Tanggal.ToString("yyyy-MM-dd hh:mm:ss") + "','" + 
                              pPenerimaan.Nama + "','" +
                              pPenerimaan.Alamat + "','" +
                              pPenerimaan.Keterangan + "')";

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

        public static string UbahData(Penerimaan pPenerimaan)
        {
            string sql = "UPDATE INTO nota_penerimaan SET tanggal ='" + pPenerimaan.Tanggal.ToString("yyyy-MM-dd hh:mm:ss")
                + "', nomor_dokumen_pengiriman=" + pPenerimaan.NomorPengiriman.NomorDokumen
                + "', nama='" + pPenerimaan.Nama
                + "', alamat='" + pPenerimaan.Alamat
                + "', keterangan='" + pPenerimaan.keterangan
                + "' WHERE nomor = '" + pPenerimaan.Nomor + "'";

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

        public static string HapusData(Penerimaan pPenerimaan)
        {
            string sql = "DELETE FROM nota_penerimaan WHERE nomor = '" + pPenerimaan.Nomor + "'";

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

        public static string BacaData(string kriteria, string nilaiKriteria, List<Penerimaan> listHasilData)
        {
            string sql = "";

            if (kriteria == "")
            {
                sql = "SELECT PT.nomor, PT.nomor_dokumen_pengiriman, PT.tanggal, PT.nama, PT.alamat, PT.keterangan FROM nota_penerimaan PT";
            }
            else
            {
                sql = "SELECT PT.nomor, PT.nomor_dokumen_pengiriman, PT.tanggal, PT.nama, PT.alamat, PT.keterangan FROM nota_penerimaan PT WHERE "
                + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

                while (hasilData.Read() == true)
                {

                    Pengiriman p = new Pengiriman();
                    p.NomorDokumen = hasilData.GetValue(1).ToString();

                    Penerimaan PT = new Penerimaan();
                    PT.Nomor = hasilData.GetValue(0).ToString();
                    PT.Tanggal = DateTime.Parse(hasilData.GetValue(2).ToString());
                    PT.Nama = hasilData.GetValue(3).ToString();
                    PT.Alamat = hasilData.GetValue(4).ToString();
                    PT.Keterangan = hasilData.GetValue(5).ToString();
                    PT.NomorPengiriman = p;


                    listHasilData.Add(PT);
                }

                return "1";
            }
            catch (MySqlException exc)
            {
                return exc.Message + ". Perintah sql : " + sql;
            }
            return "1";
        }
        #endregion

    }
}
