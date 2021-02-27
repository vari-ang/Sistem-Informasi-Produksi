using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Produksi_LIB;
using MySql.Data.MySqlClient;

namespace Produksi_LIB
{
    public class Jadwal
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private Spk noSPK;

        public Spk NoSPK
        {
            get { return noSPK; }
            set { noSPK = value; }
        }
        private DateTime tglMulai;

        public DateTime TglMulai
        {
            get { return tglMulai; }
            set { tglMulai = value; }
        }
        private DateTime tglSelesai;

        public DateTime TglSelesai
        {
            get { return tglSelesai; }
            set { tglSelesai = value; }
        }
        private string keterangan;

        public string Keterangan
        {
            get { return keterangan; }
            set { keterangan = value; }
        }

        #region CONSTRUCTORS
        public Jadwal()
        {
            Id = "";
            TglMulai = DateTime.Now;
            TglSelesai = DateTime.Now;
            Keterangan = "";
        }
        public Jadwal(string pid,Spk pnospk,DateTime ptglmulai,DateTime ptglselesai,string ket)
        {
            id = pid;
            NoSPK = pnospk;
            TglMulai = ptglmulai;
            TglSelesai = ptglselesai;
            Keterangan = ket;
        }
        #endregion

        #region METHODS
        public static string GenerateCode(out string pHasilId)
        {
            string sql = "SELECT COUNT(*) FROM penjadwalan";
            pHasilId = "";

            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

                if (hasilData.Read() == true)
                {
                    if (hasilData.GetValue(0).ToString() != "")
                    {
                        int idTerbaru = int.Parse(hasilData.GetValue(0).ToString()) + 1;


                        pHasilId = "JA" + idTerbaru.ToString();
                    }
                    else
                    {
                        pHasilId = "JA1";
                    }
                }
                return "1";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string TambahData(Jadwal pjad)
        {
            string sql = "INSERT INTO penjadwalan VALUES ('" +
                              pjad.Id + "','" +
                              pjad.NoSPK.NoSPK + "','" +
                              pjad.TglMulai.ToString("yyyy-MM-dd hh:mm:ss") + "','" +
                              pjad.TglSelesai.ToString("yyyy-MM-dd hh:mm:ss") + "','" +
                              pjad.Keterangan + "')";

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

        public static string UbahData(Jadwal pjad)
        {
            string sql = "UPDATE penjadwalan SET id = '" + pjad.Id +               
                         "', tanggal_mulai = '" + pjad.TglMulai.ToString("yyyy-MM-dd hh:mm:ss") +
                         "', tanggal_selesai = '" + pjad.TglSelesai.ToString("yyyy-MM-dd hh:mm:ss") +
                         "', keterangan = '" + pjad.Keterangan +
                         "' WHERE id = '" + pjad.Id + "'";

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

        public static string HapusData(string pjad)
        {
            string sql = "DELETE FROM penjadwalan WHERE id = '" + pjad + "'";

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

        public static string BacaData(string kriteria, string nilaiKriteria, List<Jadwal> listHasilData)
        {
            string sql = "";

            
            if (kriteria == "")
            {
                sql = "SELECT p.id,s.nomor,p.tanggal_mulai,p.tanggal_selesai,p.keterangan "
                    + "FROM spk s inner join penjadwalan p on s.nomor = p.nomor_spk";
            }
            else
            {
                sql = "SELECT p.id,s.nomor,p.tanggal_mulai,p.tanggal_selesai,p.keterangan "
                    + "FROM spk s inner join penjadwalan p on s.nomor = p.nomor_spk WHERE " 
                    + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

                while (hasilData.Read() == true) 
                {

                    Jadwal j = new Jadwal();
                    j.Id = hasilData.GetValue(0).ToString();
                    j.TglMulai = DateTime.Parse(hasilData.GetValue(2).ToString());
                    j.TglSelesai = DateTime.Parse(hasilData.GetValue(3).ToString());
                    j.Keterangan = hasilData.GetValue(4).ToString();

                    Spk s = new Spk(hasilData.GetValue(1).ToString());
                    j.NoSPK = s;
                    listHasilData.Add(j);
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
