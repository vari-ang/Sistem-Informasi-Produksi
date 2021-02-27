using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace Produksi_LIB
{
    public class Supplier
    {
        private string idSupplier;
        private string nama;
        private string alamat;

        #region CONSTRUCTORS
        public Supplier()
        {
            this.IdSupplier = "";
            this.Nama = "";
            this.Alamat = "";
        }

        public Supplier(string pId, string pNama, string pAlamat)
        {
            this.IdSupplier = pId;
            this.Nama = pNama;
            this.Alamat = pAlamat;
        }
        #endregion

        #region PROPERTIES
        public string IdSupplier
        {
            get { return idSupplier; }
            set { idSupplier = value; }
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
        #endregion

        #region METHODS
        public static string GenerateCode(out string pHasilId)
        {
            string sql = "SELECT COUNT(*) FROM supplier";
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

        public static string TambahData(Supplier sup)
        {
            string sql = "INSERT INTO supplier (Id, Nama, Alamat) VALUES ('" + sup.IdSupplier + "', '" + sup.Nama.Replace("'", "\\'") + "', '" + sup.Alamat + "')";

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

        public static string BacaData(string kriteria, string nilaiKriteria, List<Supplier> listHasilData)
        {
            string sql = "";

            // JIka tidak ada kriteria yang diisikan
            if (kriteria == "")
            {
                sql = "SELECT * FROM supplier";
            }
            else
            {
                sql = "SELECT * FROM supplier WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

                while (hasilData.Read() == true) // selama masih ada data atau selama masih bisa membaca data
                {
                    // Baca hasil dari MySqlDataReader dan simpan di objek
                    Supplier sup = new Supplier();
                    sup.IdSupplier = hasilData.GetValue(0).ToString();
                    sup.Nama = hasilData.GetValue(1).ToString();
                    sup.Alamat = hasilData.GetValue(2).ToString();

                    // Simpan ke list
                    listHasilData.Add(sup);
                }

                return "1";
            }
            catch (MySqlException exc)
            {
                return exc.Message + ". Perintah sql : " + sql;
            }
        }

        public static string UbahData(Supplier pSupplier)
        {
            string sql = "UPDATE supplier SET Nama = '" + pSupplier.Nama.Replace("'", "\\'") +
                         "', Alamat = '" + pSupplier.Alamat +
                         "' WHERE Id = '" + pSupplier.IdSupplier + "'";

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
