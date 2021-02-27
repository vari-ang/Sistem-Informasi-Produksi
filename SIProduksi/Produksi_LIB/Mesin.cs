using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Produksi_LIB;
using MySql.Data.MySqlClient;

namespace Produksi_LIB
{
    public class Mesin
    {
        private string idMesin;
        private string nama;
        private int hargaBeli;

        #region CONSTRUCTORS
        public Mesin()
        {
            IdMesin = "";
            Nama = "";
            HargaBeli = 0;
        }
        public Mesin(string pid,string pname)
        {
            IdMesin = pid;
            Nama = pname;
        }
        public Mesin(string pId, string pname, int pharga)
        {
            IdMesin = pId;
            Nama = pname;
            HargaBeli = pharga;
        }
        #endregion

        #region PROPERTIES
        public string IdMesin
        {
            get { return idMesin; }
            set { idMesin = value; }
        }

        public string Nama
        {
            get { return nama; }
            set { nama = value; }
        }

        public int HargaBeli
        {
            get { return hargaBeli; }
            set { hargaBeli = value; }
        }
        #endregion

        #region METHODS
        public static string GenerateCode(out string pHasilId)
        {
            string sql = "SELECT COUNT(*) FROM mesin";
            pHasilId = "";

            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

                if (hasilData.Read() == true)
                {
                    if (hasilData.GetValue(0).ToString() != "")
                    {
                        int idTerbaru = int.Parse(hasilData.GetValue(0).ToString()) + 1;
                        

                        pHasilId = "M" + idTerbaru.ToString();
                    }
                    else
                    {
                        pHasilId = "M1";
                    }
                }
                return "1";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string TambahData(Mesin pmesin)
        {
            string sql = "INSERT INTO mesin VALUES ('" +
                              pmesin.IdMesin + "','" +
                              pmesin.Nama.Replace("'", "\\'") + "','" +
                              pmesin.HargaBeli + "')";

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

        public static string UbahData(Mesin pmesin)
        {
            string sql = "UPDATE mesin SET id = '" + pmesin.IdMesin +
                         "', nama = '" + pmesin.Nama +
                         "', harga_beli = '" + pmesin.HargaBeli +
                
                         "' WHERE id = '" + pmesin.IdMesin + "'";

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

        public static string HapusData(Mesin pmesin)
        {
            string sql = "DELETE FROM mesin WHERE id = '" + pmesin.IdMesin + "'";

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

        public static string BacaData(string kriteria, string nilaiKriteria, List<Mesin> listHasilData)
        {
            string sql = "";

            // JIka tidak ada kriteria yang diisikan
            if (kriteria == "")
            {
                sql = "SELECT * FROM mesin";
            }
            else
            {
                sql = "SELECT * FROM mesin WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

                while (hasilData.Read() == true) // selama masih ada data atau selama masih bisa membaca data
                {
                    // Baca hasil dari MySqlDataReader dan simpan di objek
                    Mesin j = new Mesin();
                    j.IdMesin = hasilData.GetValue(0).ToString();
                    j.Nama = hasilData.GetValue(1).ToString();
                    j.HargaBeli = int.Parse(hasilData.GetValue(2).ToString());

                    // Simpan ke list
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
