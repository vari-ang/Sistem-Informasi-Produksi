using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace Produksi_LIB
{
    public class Pekerja
    {
        private int idPekerja;
        private string nama;
        private string alamat;
        private string nomerHp;
        private Jabatan jabatan;
        private string username;
        private string password;

        #region PROPERTIES
        public int IdPekerja
        {
            get { return idPekerja; }
            set { idPekerja = value; }
        }

        public string Nama
        {
            get { return nama; }
            set { nama = value; }
        }

        public string Alamat
        {
            get { return alamat; }
            set { alamat = value; }
        }

        public string NomerHp
        {
            get { return nomerHp; }
            set { nomerHp = value; }
        }

        public Jabatan Jabatan
        {
            get { return jabatan; }
            set { jabatan = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        #endregion

        #region CONSTRUCTORS
        public Pekerja()
        {
            this.IdPekerja = 0;
            this.Nama = "";
            this.Alamat = "";
            this.NomerHp = "";
            this.Username = "";
            this.Password = "";
        }
        public Pekerja(int pid,string pnama)
        {
            this.IdPekerja = pid;
            this.Nama = pnama;
        }
        public Pekerja(int pIdPekerja, string pNama, string pAlamat, string pNomerHp, Jabatan pJabatan, string pUsername, string pPassword)
        {
            this.IdPekerja = pIdPekerja;
            this.Nama = pNama;
            this.Alamat = pAlamat;
            this.NomerHp = pNomerHp;
            this.Jabatan = pJabatan;
            this.Username = pUsername;
            this.Password = pPassword;
        }
        #endregion

        #region METHODS
        public static string GenerateCode(out string pHasilId)
        {
            string sql = "SELECT COUNT(*) FROM Pekerja";
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

        public static string BacaData(string kriteria, string nilaiKriteria, List<Pekerja> listHasilData)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "SELECT P.Id, P.Nama, P.Alamat, P.nomer_hp, J.Id AS IdJabatan, J.Nama AS NamaJabatan, P.Username, P.Password" +
                      " FROM pekerja P INNER JOIN jabatan J ON P.id_jabatan = J.id";
            }
            else
            {
                sql = "SELECT P.Id, P.Nama, P.Alamat, P.nomer_hp, J.Id AS IdJabatan, J.Nama AS NamaJabatan, P.Username, P.Password" +
                      " FROM pekerja P INNER JOIN jabatan J ON P.id_jabatan = J.id" +
                      " WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);
                listHasilData.Clear();
                while (hasilData.Read() == true)
                {
                    Pekerja p = new Pekerja();
                    p.IdPekerja = int.Parse(hasilData.GetValue(0).ToString());
                    p.Nama = hasilData.GetValue(1).ToString();
                    p.Alamat = hasilData.GetValue(2).ToString();
                    p.NomerHp = hasilData.GetValue(3).ToString();
                    p.Username = hasilData.GetValue(6).ToString();
                    p.Password = hasilData.GetValue(7).ToString();

                    Jabatan jabatan = new Jabatan(hasilData.GetValue(4).ToString(), hasilData.GetValue(5).ToString());
                    p.Jabatan = jabatan;

                    listHasilData.Add(p);
                }
                return "1";
            }
            catch (MySqlException exc)
            {
                return exc.Message + ". Perintah sql : " + sql;
            }
        }

        public static string TambahData(Pekerja pPekerja)
        {
            string sql = "INSERT INTO Pekerja VALUES ('" +
                              pPekerja.IdPekerja + "','" +
                              pPekerja.Nama.Replace("'", "\\'") + "','" +
                              pPekerja.Alamat + "','" +
                              pPekerja.NomerHp + "','" +
                              pPekerja.Jabatan.IdJabatan + "','" +
                              pPekerja.Username + "','" +
                              pPekerja.Password + "')";

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

        public static string UbahData(Pekerja pPekerja)
        {
            string sql = "UPDATE Pekerja SET Nama = '" + pPekerja.Nama.Replace("'", "\\'") +
                         "', Alamat = '" + pPekerja.Alamat +
                         "', nomer_hp = '" + pPekerja.NomerHp +
                         "', id_jabatan = '" + pPekerja.Jabatan.IdJabatan +
                         //"', Username = '" + pPekerja.Username +
                         "', Password = '" + pPekerja.Password +
                         "' WHERE Id = '" + pPekerja.IdPekerja + "'";

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

        public static string HapusData(Pekerja pPekerja)
        {
            string sql = "DELETE FROM Pekerja WHERE Id = '" + pPekerja.IdPekerja + "'";

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
