using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace Produksi_LIB
{
    public class Jabatan
    {
        private string idJabatan;
        private string namaJabatan;

        #region PROPERTIES
        public string IdJabatan
        {
            get { return idJabatan; }
            set { idJabatan = value; }
        }

        public string NamaJabatan
        {
            get { return namaJabatan; }
            set { namaJabatan = value; }
        }
        #endregion

        #region CONSTRUCTORS
        public Jabatan()
        {
            this.IdJabatan = "";
            this.NamaJabatan = "";
        }
        public Jabatan(string pIdJabatan, string pNamaJabatan)
        {
            this.IdJabatan = pIdJabatan;
            this.NamaJabatan = pNamaJabatan;
        }
        #endregion

        #region METHODS
        public static string GenerateCode(out string pHasilId)
        {
            string sql = "SELECT COUNT(*) FROM jabatan";
            pHasilId = "";

            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

                if (hasilData.Read() == true)
                {
                    if (hasilData.GetValue(0).ToString() != "")
                    {
                        int idTerbaru = int.Parse(hasilData.GetValue(0).ToString()) + 1;

                        pHasilId = "J" + idTerbaru.ToString();
                    }
                    else
                    {
                        // Jika tidak ditemukan data dengan kategori tertentu maka kode terbaru = "J1"
                        pHasilId = "J1";
                    }
                }
                return "1";
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        public static string TambahData(Jabatan j)
        {
            string sql = "INSERT INTO jabatan (Id, Nama) VALUES ('" + j.IdJabatan + "', '" + j.NamaJabatan.Replace("'", "\\'") + "')";

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

        public static string UbahData(Jabatan j)
        {
            string sql = "UPDATE jabatan SET Nama = '" + j.NamaJabatan.Replace("'", "\\'") + "' WHERE Id = '" + j.IdJabatan + "'";

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

        public static string HapusData(Jabatan j)
        {
            string sql = "DELETE FROM jabatan WHERE Id = '" + j.IdJabatan + "'";

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

        public static string BacaData(string kriteria, string nilaiKriteria, List<Jabatan> listHasilData)
        {
            string sql = "";

            // JIka tidak ada kriteria yang diisikan
            if (kriteria == "")
            {
                sql = "SELECT * FROM jabatan";
            }
            else
            {
                sql = "SELECT * FROM jabatan WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

                while (hasilData.Read() == true) // selama masih ada data atau selama masih bisa membaca data
                {
                    // Baca hasil dari MySqlDataReader dan simpan di objek
                    Jabatan j = new Jabatan();
                    j.IdJabatan = hasilData.GetValue(0).ToString();
                    j.NamaJabatan = hasilData.GetValue(1).ToString();

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
