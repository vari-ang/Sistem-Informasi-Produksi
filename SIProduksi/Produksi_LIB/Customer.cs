using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace Produksi_LIB
{
    public class Customer
    {
        private int idCustomer;
        private string nama;
        private string alamat;
        private string nomerHp;

        #region CONSTRUCTORS
        public Customer()
        {
            this.IdCustomer = 0;
            this.Nama = "";
            this.Alamat = "";
            this.NomerHp = "";
        }

        public Customer(int pKode, string pNama, string pAlamat, string pNomerHp)
        {
            this.IdCustomer = pKode;
            this.Nama = pNama;
            this.Alamat = pAlamat;
            this.NomerHp = pNomerHp;
        }
        #endregion

        #region PROPERTIES
        public int IdCustomer
        {
            get { return idCustomer; }
            set { idCustomer = value; }
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
        #endregion

        #region METHODS
        public static string GenerateCode(out string pHasilId)
        {
            string sql = "SELECT COUNT(*) FROM customer";
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

        public static string TambahData(Customer c)
        {
            string sql = "INSERT INTO customer (Id, Nama, Alamat, nomer_hp) VALUES ('" + c.IdCustomer + "', '" + c.Nama.Replace("'", "\\'") + "', '" + c.Alamat + "', '" + c.NomerHp + "')";

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

        public static string BacaData(string kriteria, string nilaiKriteria, List<Customer> listHasilData)
        {
            string sql = "";

            // JIka tidak ada kriteria yang diisikan
            if (kriteria == "")
            {
                sql = "SELECT * FROM customer";
            }
            else
            {
                sql = "SELECT * FROM customer WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

                while (hasilData.Read() == true) // selama masih ada data atau selama masih bisa membaca data
                {
                    // Baca hasil dari MySqlDataReader dan simpan di objek
                    Customer c = new Customer();
                    c.IdCustomer = int.Parse(hasilData.GetValue(0).ToString());
                    c.Nama = hasilData.GetValue(1).ToString();
                    c.Alamat = hasilData.GetValue(2).ToString();
                    c.NomerHp = hasilData.GetValue(3).ToString();

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

        public static string UbahData(Customer pC)
        {
            string sql = "UPDATE customer SET Nama = '" + pC.Nama.Replace("'", "\\'") +
                         "', Alamat = '" + pC.Alamat +
                         "', nomer_hp = '" + pC.NomerHp +
                         "' WHERE Id = '" + pC.IdCustomer + "'";

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

        public static string HapusData(Customer pC)
        {
            string sql = "DELETE FROM customer WHERE Id = '" + pC.IdCustomer + "'";

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
