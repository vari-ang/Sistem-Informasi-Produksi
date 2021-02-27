using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Produksi_LIB;
using MySql.Data.MySqlClient;

namespace Produksi_LIB
{
    public class ProgresProduksi
    {
        // Data Member
        private string nomorDokumen;
        private Spk nomerSPK;
        private Mesin idMesin;
        private Pekerja pekerjatuk;
        private DateTime tglmulai;
        private DateTime tglselesai;
        private string status;
        private string keterangan;

        #region CONSTRUCTORS
        public ProgresProduksi()
        {
            NomorDokumen = "";
            Keterangan = "";
            Status = "";
            Tglmulai = DateTime.Now;
            Tglselesai = DateTime.Now;
        }
        public ProgresProduksi(string nodok, string status)
        {
            NomorDokumen = nodok;
            Status = status;
        }

        public ProgresProduksi(string nomorDokumen, Spk nomerSPK, Mesin idMesin, Pekerja pekerjatuk, DateTime tglmulai, DateTime tglselesai, string status, string keterangan)
        {
            this.NomorDokumen = nomorDokumen;
            this.NomerSPK = nomerSPK;
            this.IdMesin = idMesin;
            this.Pekerjatuk = pekerjatuk;
            this.Tglmulai = tglmulai;
            this.Tglselesai = tglselesai;
            this.Status = status;
            this.Keterangan = keterangan;
        }

        #endregion

        #region PROPERTIES
        public string NomorDokumen
        {
            get { return nomorDokumen; }
            set { nomorDokumen = value; }
        }
        public Spk NomerSPK
        {
            get { return nomerSPK; }
            set { nomerSPK = value; }
        }
        public Mesin IdMesin
        {
            get { return idMesin; }
            set { idMesin = value; }
        }
        public Pekerja Pekerjatuk
        {
            get { return pekerjatuk; }
            set { pekerjatuk = value; }
        }
        public DateTime Tglmulai
        {
            get { return tglmulai; }
            set { tglmulai = value; }
        }
        public DateTime Tglselesai
        {
            get { return tglselesai; }
            set { tglselesai = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        public string Keterangan
        {
            get { return keterangan; }
            set { keterangan = value; }
        }
        #endregion

        #region METHODS       
        public static string BacaData(string kriteria, string nilaiKriteria, List<ProgresProduksi> listHasilData)
        {
            string sql = "";
            if (kriteria == "")
            {
                sql = "SELECT s.nomor, p.id,p.nama,pk.nomer_dokumen,pk.tanggal_mulai,pk.tanggal_selesai,m.id,m.nama,pk.status,pk.keterangan" +
                      " from spk s inner join progress_produksi pk on s.nomor = pk.nomor_spk inner join mesin m on pk.id_mesin = m.id inner join pekerja p on pk.id_pekerja_tukang = p.id";
            }
            else
            {
                sql = "SELECT s.nomor, p.id,p.nama,pk.nomer_dokumen,pk.tanggal_mulai,pk.tanggal_selesai,m.id,m.nama,pk.status,pk.keterangan" +
                      " from spk s inner join progress_produksi pk on s.nomor = pk.nomor_spk inner join mesin m on pk.id_mesin = m.id inner join pekerja p on pk.id_pekerja_tukang = p.id" +
                      " WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            try
            {
                MySqlDataReader hasilData = Koneksi.JalankanPerintahQuery(sql);
                listHasilData.Clear();
                while (hasilData.Read() == true)
                {
                    ProgresProduksi p = new ProgresProduksi();
                    p.NomorDokumen = hasilData.GetValue(3).ToString();

                    p.Tglmulai = DateTime.Parse(hasilData.GetValue(4).ToString());
                    p.Tglselesai = DateTime.Parse(hasilData.GetValue(5).ToString());
                    p.Status = hasilData.GetValue(8).ToString();
                    p.Keterangan = hasilData.GetValue(9).ToString();

                    Spk sp = new Spk(hasilData.GetValue(0).ToString());
                    p.NomerSPK = sp;

                    Pekerja pk = new Pekerja(int.Parse(hasilData.GetValue(1).ToString()),hasilData.GetValue(2).ToString());
                    Mesin m = new Mesin(hasilData.GetValue(6).ToString(),hasilData.GetValue(7).ToString());
              
                    p.IdMesin = m;
                    p.Pekerjatuk = pk;
                    

                    listHasilData.Add(p);
                }
                return "1";
            }
            catch (MySqlException exc)
            {
                return exc.Message + ". Perintah sql : " + sql;
            }
        }

        public static string TambahData(ProgresProduksi pPekerja)
        {
            string sql = "INSERT INTO progress_produksi VALUES ('" +
                              pPekerja.NomorDokumen + "','" +
                              pPekerja.NomerSPK.NoSPK + "','" +
                              pPekerja.IdMesin.IdMesin + "','" +
                              pPekerja.Pekerjatuk.IdPekerja + "','" +
                              pPekerja.Tglmulai.ToString("yyyy-MM-dd hh:mm:ss") + "','" +
                              pPekerja.Tglselesai.ToString("yyyy-MM-dd hh:mm:ss") + "','" +
                              pPekerja.Status + "','" +
                              pPekerja.Keterangan + "')";

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

        public static string UbahData(ProgresProduksi pPekerja)
        {
            string sql = "UPDATE progress_produksi SET status = '" + pPekerja.Status +
                         "' WHERE nomer_dokumen = '" + pPekerja.NomorDokumen + "'";

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

        public static string HapusData(string pp)
        {
            string sql = "DELETE FROM progress_produksi WHERE nomer_dokumen = '" + pp + "'";

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
