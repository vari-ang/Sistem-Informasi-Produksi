using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Produksi_LIB
{
    public class Pengiriman
    {
        private string nomorDokumen;
        private Spk nomorSPK;
        private DateTime tanggalKirim;

        #region CONSTRUCTOR
        public Pengiriman()
        {
            NomorDokumen = "";
            NomorSPK = new Spk();
            TanggalKirim = DateTime.Now;
        }
        public Pengiriman(string pNomorDokumen, Spk pNomorSPK, DateTime pTanggalKirim)
        {
            NomorDokumen = pNomorDokumen;
            NomorSPK = pNomorSPK;
            TanggalKirim = pTanggalKirim;
        }
        #endregion

        #region PROPERTIES
        public string NomorDokumen
        {
            get { return nomorDokumen; }
            set { nomorDokumen = value; }
        }
        public Spk NomorSPK
        {
            get { return nomorSPK; }
            set { nomorSPK = value; }
        }
        public DateTime TanggalKirim
        {
            get { return tanggalKirim; }
            set { tanggalKirim = value; }
        }
        #endregion

        #region METHOD
        public static string TambahData(Pengiriman pPengiriman)
        {
            string sql = "INSERT INTO pengiriman VALUES ('" +
                              pPengiriman.NomorDokumen + "','" +
                              pPengiriman.NomorSPK.NoSPK + "','" +
                              pPengiriman.TanggalKirim.ToString("yyyy-MM-dd hh:mm:ss") + "')";

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

        public static string UbahData(Pengiriman pPengiriman)
        {
            string sql = "UPDATE INTO pengiriman SET tanggal_pengiriman ='" + pPengiriman.TanggalKirim.ToString("yyyy-MM-dd hh:mm:ss")
                + "' WHERE nomor_dokumen = '" + pPengiriman.NomorDokumen + "'";

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

        public static string HapusData(Pengiriman pPengiriman)
        {
            string sql = "DELETE FROM pengiriman WHERE nomor_dokumen = '" + pPengiriman.NomorDokumen + "'";

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

        public static string BacaData(string kriteria, string nilaiKriteria, List<Pengiriman> listHasilData)
        {
            string sql = "";

            if (kriteria == "")
            {
                sql = "SELECT P.nomor_dokumen, P.tanggal_pengiriman, S.nomor FROM pengiriman P INNER JOIN spk S ON P.nomor_spk=S.nomor";
            }
            else
            {
                sql = "SELECT P.nomor_dokumen, P.tanggal_pengiriman, S.nomor FROM pengiriman P INNER JOIN spk S ON P.nomor_spk=S.nomor WHERE "
                    + kriteria + " LIKE '%" + nilaiKriteria + "%'";

            }

            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

                while (hasilData.Read() == true) 
                {
                    
                    Pengiriman p = new Pengiriman();
                    p.NomorDokumen = hasilData.GetValue(0).ToString();
                    p.TanggalKirim = DateTime.Parse(hasilData.GetValue(1).ToString());
                    Spk s = new Spk();
                    s.NoSPK = hasilData.GetValue(2).ToString();
                    p.NomorSPK = s;
                    listHasilData.Add(p);
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
