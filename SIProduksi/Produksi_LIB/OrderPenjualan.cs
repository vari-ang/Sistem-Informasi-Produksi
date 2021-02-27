using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Transactions;

namespace Produksi_LIB
{
    public class OrderPenjualan
    {
        private string noOrder;      
        private DateTime tanggal;
        private string unit;
        private Customer customer; // aggregation
        private List<Barang> listBarang; // composition

        #region CONSTRUCTORS
        public OrderPenjualan()
        {
            this.NoOrder = "";
            this.Tanggal = DateTime.Now;
            this.Unit = "";
            this.ListBarang = new List<Barang>();
        }

        public OrderPenjualan(string pNoOrder, DateTime pTanggal, string pUnit, Customer pC)
        {
            this.NoOrder = pNoOrder;
            this.Tanggal = pTanggal;
            this.Unit = pUnit;
            this.Customer = pC;
            this.ListBarang = new List<Barang>();
        }
        #endregion

        #region PROPERTIES
        public string NoOrder
        {
            get { return noOrder; }
            set { noOrder = value; }
        }

        public DateTime Tanggal
        {
            get { return tanggal; }
            set { tanggal = value; }
        }

        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        public List<Barang> ListBarang
        {
            get { return listBarang; }
            set { listBarang = value; }
        }
        
        #endregion

        #region METHODS
        public void TambahBarang(Barang pBarang)
        {
            Barang b = new Barang(pBarang.Kode, pBarang.Nama, pBarang.Jumlah, pBarang.Satuan, pBarang.HargaSatuan, pBarang.Keterangan, this);
            this.ListBarang.Add(b);
        }

        public static string HapusData(OrderPenjualan OP)
        {
            using (var tranScope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                string sql1 = "DELETE FROM barang WHERE id_order_penjualan = '" + OP.NoOrder + "'";

                try
                {
                    Koneksi.JalankanPerintahDML(sql1);

                    string sql2 = "DELETE FROM order_penjualan WHERE Id = '" + OP.NoOrder + "'";

                    Koneksi.JalankanPerintahDML(sql2);

                    // jika semua perintah DML berhasil dijalankan
                    tranScope.Complete();

                    return "1";                   
                }
                catch (Exception exc)
                {
                    tranScope.Dispose();

                    return exc.Message;
                }
            }                         
        }

        public static string GenerateNoNota(out string pHasilNoNota)
        {
            // sql untuk mendapatkan nomor urut transaksi terakhir di tanggal hari ini (tanggal komputer)
            string sql = "SELECT SUBSTRING(id, 13, 3) AS noUrutTransaksi " +
                         "FROM order_penjualan WHERE Date(Tanggal) = Date(CURRENT_DATE) " +
                         "ORDER BY id DESC LIMIT 1";

            pHasilNoNota = "";

            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);

                string noUrutTransTerbaru = "";

                if (hasilData.Read() == true)
                {
                    int noUrutTrans = int.Parse(hasilData.GetValue(0).ToString()) + 1;
                    noUrutTransTerbaru = noUrutTrans.ToString().PadLeft(3, '0'); // jika noUrutTrans < 3
                }
                else
                {
                    noUrutTransTerbaru = "001";
                }

                string tahun = DateTime.Now.Year.ToString();
                string bulan = DateTime.Now.Month.ToString().PadLeft(2, '0');
                string tanggal = DateTime.Now.Day.ToString().PadLeft(2, '0');

                pHasilNoNota = "PO/" + tahun + bulan + tanggal + "/" + noUrutTransTerbaru.ToString();

                return "1";
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        public static string TambahData(OrderPenjualan pOP)
        {
            using (var tranScope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                // tuliskan perintah sql 1: menambahkan data order penjualan
                string sql1 = "INSERT INTO order_penjualan(id, tanggal, unit,  id_customer) VALUES ('" + pOP.NoOrder + "','" +
                               pOP.Tanggal.ToString("yyyy-MM-dd hh:mm:ss") + "','" + pOP.Unit + "','" + 
                               pOP.Customer.IdCustomer + "')";

                try
                {
                    // jalankan perintah untuk menambahkan ke tabel NotaJual
                    Koneksi.JalankanPerintahDML(sql1);

                    //mendapatkan semua barang yg terjual dalam order penjualan
                    for (int i = 0; i < pOP.ListBarang.Count; i++)
                    {
                        // perintah sql 2: menambahkan barang2 yg terjual ke tabel barang
                        string sql2 = "INSERT INTO barang(kode, nama, jumlah, satuan, harga_satuan, keterangan, id_order_penjualan) VALUES ('" + pOP.ListBarang[i].Kode + "','" +
                                      pOP.ListBarang[i].Nama + "','" + pOP.ListBarang[i].Jumlah + "','" + pOP.ListBarang[i].Satuan + "','" + pOP.ListBarang[i].HargaSatuan + "','" +
                                      pOP.ListBarang[i].Keterangan + "','" + pOP.ListBarang[i].OrderPenjualan.NoOrder + "')";

                        Koneksi.JalankanPerintahDML(sql2);
                    }

                    // jika semua perintah DML berhasil dijalankan
                    tranScope.Complete();

                    return "1";
                }
                catch (Exception exc)
                {
                    tranScope.Dispose();

                    return exc.Message;
                }
            }
        }

        public static string BacaData(string pKriteria, string pNilaiKriteria, List<OrderPenjualan> listHasilData)
        {
            string sql = "";
            if (pKriteria == "")
            {
                sql = "SELECT OP.Id, OP.Tanggal, C.Id, C.Nama, OP.Unit, B.Kode, B.Nama, B.Jumlah, B.Satuan, B.harga_satuan, B.keterangan" +
                      " FROM order_penjualan OP INNER JOIN Customer C ON OP.id_customer = C.id" +
                      " INNER JOIN Barang B ON OP.id = B.id_order_penjualan";
            }
            else
            {
                sql = "SELECT OP.Id, OP.Tanggal, C.Id, C.Nama, OP.Unit, B.Kode, B.Nama, B.Jumlah, B.Satuan, B.harga_satuan, B.keterangan" +
                      " FROM order_penjualan OP INNER JOIN Customer C ON OP.id_customer = C.id" +
                      " INNER JOIN Barang B ON OP.id = B.id_order_penjualan" +
                      " WHERE " + pKriteria + " LIKE '%" + pNilaiKriteria + "%'";
            }

            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);
                listHasilData.Clear();
                while (hasilData.Read() == true)
                {
                    OrderPenjualan op = new OrderPenjualan();
                    op.NoOrder = hasilData.GetValue(0).ToString();
                    op.Tanggal = DateTime.Parse(hasilData.GetValue(1).ToString());
                    op.Unit = hasilData.GetValue(4).ToString();

                    Customer c = new Customer();
                    c.IdCustomer = int.Parse(hasilData.GetValue(2).ToString());
                    c.Nama = hasilData.GetValue(3).ToString();

                    op.Customer = c;           

                    Barang b = new Barang();
                    b.Kode = hasilData.GetValue(5).ToString();
                    b.Nama = hasilData.GetValue(6).ToString();
                    b.Jumlah = int.Parse(hasilData.GetValue(7).ToString());
                    b.Satuan = hasilData.GetValue(8).ToString();
                    b.HargaSatuan = int.Parse(hasilData.GetValue(9).ToString());
                    b.Keterangan = hasilData.GetValue(10).ToString();

                    op.TambahBarang(b);

                    listHasilData.Add(op);
                }
                return "1";
            }
            catch (MySqlException exc)
            {
                return exc.Message + ". Perintah sql : " + sql;
            }
        }

        public static string TotalPenjualanBulanan(int pBulan, List<OrderPenjualan> listHasilData)
        {
            // Mencari total penjualan bulan lalu dan bulan ini
            string sql = "SELECT MONTH(a.tanggal) AS bulan, SUM(a.jumlah * a.harga_satuan) AS total_penjualan " +
                         "FROM(SELECT OP.id, OP.tanggal, OP.unit, B.Kode, B.nama, B.jumlah, B.satuan, B.harga_satuan, B.keterangan " +
                         "FROM order_penjualan OP " +
                         "INNER JOIN Barang B ON OP.id = B.id_order_penjualan) a " +
                         "WHERE MONTH(a.tanggal) = '" + pBulan + "' OR MONTH(a.tanggal) = '" + (pBulan - 1) + "' " +
                         "GROUP BY bulan ORDER BY bulan";

            try
            {             
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);
                listHasilData.Clear();
                while (hasilData.Read() == true)
                {
                    OrderPenjualan op = new OrderPenjualan();
                    op.NoOrder = hasilData.GetValue(0).ToString(); // bulan

                    Barang b = new Barang();                   
                    b.HargaSatuan = int.Parse(hasilData.GetValue(1).ToString()); // total penjualan

                    op.TambahBarang(b);

                    listHasilData.Add(op);
                }
                return "1";
            }
            catch (MySqlException exc)
            {
                return exc.Message + ". Perintah sql : " + sql;
            }
        }

        public static double PersenPenjualan(int pNominalLalu, int pNominalIni)
        {
            return ((pNominalIni - pNominalLalu)*100) / pNominalLalu*1.0;
        }
        #endregion
    }
}
