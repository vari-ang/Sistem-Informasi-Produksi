using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Produksi_LIB;
using MySql.Data.MySqlClient;

namespace Produksi_LIB
{
    public class RiwayatPerbaikan
    {
        private int id;
        private Mesin idMesin;
        private DateTime tanggal;
        private string keterangan;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public Mesin IdMesin
        {
            get { return idMesin; }
            set { idMesin = value; }
        }
        public DateTime Tanggal
        {
            get { return tanggal; }
            set { tanggal = value; }
        }
        public string Keterangan
        {
            get { return keterangan; }
            set { keterangan = value; }
        }

        public RiwayatPerbaikan()
        {
            Id = 0;
            Tanggal = DateTime.Now;
            Keterangan = "";
        }
        public RiwayatPerbaikan(int pid, Mesin pmesin, DateTime ptgl, string pket)
        {
            Id = pid;
            IdMesin = pmesin;
            Tanggal = ptgl;
            Keterangan = pket;
        }

        public static string TambahData(RiwayatPerbaikan pRiw)
        {
            string sql = "INSERT INTO riwayat_perbaikan VALUES ('" +
                              pRiw.Id + "','" +
                              pRiw.IdMesin.IdMesin + "','" +
                              pRiw.Tanggal.ToString("yyyy-MM-dd hh:mm:ss") + "','" +
                              pRiw.Keterangan + "')";

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

        public static string UbahData(RiwayatPerbaikan pRiw)
        {
            string sql = "UPDATE riwayat_perbaikan SET id = '" + pRiw.Id +
                         "', id_mesin = '" + pRiw.IdMesin.IdMesin +
                         "', tanggal = '" + pRiw.Tanggal +
                         "', keterangan = '" + pRiw.Keterangan +
                         "' WHERE id = '" + pRiw.Id + "'";

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

        public static string HapusData(string pRiw)
        {
            string sql = "DELETE FROM riwayat_perbaikan WHERE id = '" + pRiw + "'";

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

        public static string BacaData(string kriteria, string nilaiKriteria, List<RiwayatPerbaikan> listHasilData)
        {
            string sql = "";


            if (kriteria == "")
            {
                sql = "SELECT r.id,m.id,r.tanggal,r.keterangan FROM riwayat_perbaikan r inner join mesin m on r.id_mesin = m.id";
            }
            else
            {
                sql = "SELECT r.id,m.id,r.tanggal,r.keterangan FROM riwayat_perbaikan r inner join mesin m on r.id_mesin = m.id WHERE" + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

                while (hasilData.Read() == true)
                {

                    RiwayatPerbaikan R = new RiwayatPerbaikan();
                    R.Id = int.Parse(hasilData.GetValue(0).ToString());
                    R.Tanggal = DateTime.Parse(hasilData.GetValue(2).ToString());
                    R.Keterangan = hasilData.GetValue(3).ToString();

                    Mesin m = new Mesin();
                    m.IdMesin = hasilData.GetValue(1).ToString();
                    R.IdMesin = m;
                    listHasilData.Add(R);
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
