-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Jun 24, 2019 at 03:00 AM
-- Server version: 5.7.17
-- PHP Version: 7.1.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `si_produksi_ti`
--

-- --------------------------------------------------------

--
-- Table structure for table `bahan_baku`
--

CREATE TABLE `bahan_baku` (
  `id` varchar(45) NOT NULL,
  `nama` varchar(45) DEFAULT NULL,
  `bagian` varchar(45) DEFAULT NULL,
  `ukuran_mentah` varchar(45) DEFAULT NULL,
  `ukuran_luasan` varchar(45) DEFAULT NULL,
  `ukuran_jadi` varchar(45) DEFAULT NULL,
  `stok` int(11) DEFAULT NULL,
  `harga_satuan` int(11) DEFAULT NULL,
  `id_supplier` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `bahan_baku`
--

INSERT INTO `bahan_baku` (`id`, `nama`, `bagian`, `ukuran_mentah`, `ukuran_luasan`, `ukuran_jadi`, `stok`, `harga_satuan`, `id_supplier`) VALUES
('BB001', 'Kayu Jati', 'Luar', '25 m2', '12 m2', '100 m2', 81, 55000, '1'),
('BB002', 'Kayu Pinus', 'Dalam', '5 cm2', '10 cm2', '40 cm2', 0, 2500, '2'),
('BB003', 'Kayu Putih', 'Atas', '35 m2', '5 m2', '80 m2', 0, 48000, '1'),
('BB004', 'BESI', 'Biji', '10 cm', '10 cm', '10 cm', 99, 10900, '1'),
('BB009', 'EMAS', 'Atas', '20 m²', '30 m²', '10 m²', 313, 20000, '2');

-- --------------------------------------------------------

--
-- Table structure for table `barang`
--

CREATE TABLE `barang` (
  `kode` varchar(45) NOT NULL,
  `nama` varchar(45) DEFAULT NULL,
  `jumlah` int(11) DEFAULT NULL,
  `satuan` varchar(45) DEFAULT NULL,
  `harga_satuan` int(11) DEFAULT NULL,
  `keterangan` varchar(45) DEFAULT NULL,
  `id_order_penjualan` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `barang`
--

INSERT INTO `barang` (`kode`, `nama`, `jumlah`, `satuan`, `harga_satuan`, `keterangan`, `id_order_penjualan`) VALUES
('B001', 'Meja', 0, 'Pcs', 400000, '0', NULL),
('B002', 'Lemari', 0, 'Pcs', 5000000, '0', NULL),
('B003', 'Kursi Lipat', 500, 'unit', 300000, 'wjias', 'PO/20190327/001'),
('B004', 'Lemari Lipat', 3, 'Pcs', 1000000, 'Lemari harus bisa dilipat', 'PO/20190522/001'),
('B005', 'Kursi Emas', 7, 'Buah', 900000, 'Kursi berwarna emas', 'PO/20190522/002'),
('B0100', 'Kursi', 10, 'Pcs', 10000, 'kursi', 'PO/20190523/001'),
('B0101', 'Meja', 100, 'Pcs', 20000, 'Meja', 'PO/20190523/001'),
('BB008', 'Meja Emas', 4, 'Biji', 50000000, 'Meja Emasssss', 'PO/20190624/001');

-- --------------------------------------------------------

--
-- Table structure for table `bill_of_materials`
--

CREATE TABLE `bill_of_materials` (
  `id_bahan_baku` varchar(45) NOT NULL,
  `kode_barang` varchar(45) NOT NULL,
  `jumlah_bagian` varchar(45) DEFAULT NULL,
  `jumlah_biji_lembar_batang` varchar(45) DEFAULT NULL,
  `total_biaya` int(11) DEFAULT NULL,
  `biaya_operasional` int(11) DEFAULT NULL,
  `biaya_tukang` int(11) DEFAULT NULL,
  `pengajuan_harga` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `bill_of_materials`
--

INSERT INTO `bill_of_materials` (`id_bahan_baku`, `kode_barang`, `jumlah_bagian`, `jumlah_biji_lembar_batang`, `total_biaya`, `biaya_operasional`, `biaya_tukang`, `pengajuan_harga`) VALUES
('BB001', 'B001', '1', '1', 80000, 50000, 30000, 10000),
('BB001', 'B003', '1', '1', 20000, 10000, 10000, 10000),
('BB002', 'B001', '1', '1', 60000, 40000, 20000, 50000),
('BB002', 'B005', '3', '5', 1000000, 500000, 500000, 1000000),
('BB004', 'B001', '2', '6', 2000, 1000, 1000, 1000);

-- --------------------------------------------------------

--
-- Table structure for table `customer`
--

CREATE TABLE `customer` (
  `id` varchar(45) NOT NULL,
  `nama` varchar(45) DEFAULT NULL,
  `alamat` varchar(45) DEFAULT NULL,
  `nomer_hp` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `customer`
--

INSERT INTO `customer` (`id`, `nama`, `alamat`, `nomer_hp`) VALUES
('1', 'John Ethens', 'Jl. Pegangsaan Timur No.56', '098765432112'),
('2', 'Rafael Kimura', 'Jl. Pahlawan 123', '(+62)82-3456-1222');

-- --------------------------------------------------------

--
-- Table structure for table `detail_pemesanan_bahan_baku`
--

CREATE TABLE `detail_pemesanan_bahan_baku` (
  `id` int(11) NOT NULL,
  `kode_pemesanan_bahan_baku` varchar(45) NOT NULL,
  `id_bahan_baku` varchar(45) NOT NULL,
  `jenis` varchar(45) DEFAULT NULL,
  `jumlah` int(11) DEFAULT NULL,
  `harga_satuan` int(11) DEFAULT NULL,
  `sub_total_harga` int(11) DEFAULT NULL,
  `tanggal_terima` datetime DEFAULT NULL,
  `keterangan` varchar(45) DEFAULT NULL,
  `kedatangan` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `detail_pemesanan_bahan_baku`
--

INSERT INTO `detail_pemesanan_bahan_baku` (`id`, `kode_pemesanan_bahan_baku`, `id_bahan_baku`, `jenis`, `jumlah`, `harga_satuan`, `sub_total_harga`, `tanggal_terima`, `keterangan`, `kedatangan`) VALUES
(1, 'w', 'BB001', 'd', 10, 10, 100, '2019-04-01 12:30:41', 'g', '1'),
(2, 'PBESI', 'BB004', 'Batang', 100, 100, 10000, '2019-04-01 12:30:41', 'aaa', '1'),
(3, 'P002', 'BB001', 'Batang', 20, 15000, 300000, '2019-04-01 12:30:41', 'aw', '1'),
(4, 'P002', 'BB001', 'Balok', 40, 20000, 800000, '2019-04-01 12:30:41', 'ww', '1'),
(5, 'PBB001', 'BB009', 'A', 20, 2000, 40000, '2019-06-24 03:39:02', 'PUTOL', '1'),
(6, 'PSEN', 'BB001', 'a', 1, 1, 1, '2019-04-01 12:30:41', 's', '1'),
(7, 'PSEN', 'BB001', 's', 1, 1, 1, '2019-04-01 12:30:41', 's', '1');

-- --------------------------------------------------------

--
-- Table structure for table `jabatan`
--

CREATE TABLE `jabatan` (
  `id` varchar(45) NOT NULL,
  `nama` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `jabatan`
--

INSERT INTO `jabatan` (`id`, `nama`) VALUES
('J1', 'Ketua Lab'),
('J2', 'Admin'),
('J3', 'Tukang');

-- --------------------------------------------------------

--
-- Table structure for table `mesin`
--

CREATE TABLE `mesin` (
  `id` varchar(45) NOT NULL,
  `nama` varchar(45) DEFAULT NULL,
  `harga_beli` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `mesin`
--

INSERT INTO `mesin` (`id`, `nama`, `harga_beli`) VALUES
('M1', 'Mesin Getok', 75000000),
('M2', 'Mesin Cuci', 22500000),
('M3', 'Mesin Kedobrak', 300000000);

-- --------------------------------------------------------

--
-- Table structure for table `nota_penerimaan`
--

CREATE TABLE `nota_penerimaan` (
  `nomor` varchar(45) NOT NULL,
  `nomor_dokumen_pengiriman` varchar(45) NOT NULL,
  `tanggal` datetime DEFAULT NULL,
  `nama` varchar(45) DEFAULT NULL,
  `alamat` varchar(45) DEFAULT NULL,
  `keterangan` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `nota_penerimaan`
--

INSERT INTO `nota_penerimaan` (`nomor`, `nomor_dokumen_pengiriman`, `tanggal`, `nama`, `alamat`, `keterangan`) VALUES
('123', 'POPO', '2019-06-24 04:51:33', 'a', 'a', 'a'),
('P001', 'POPO', '2019-06-24 04:56:27', 'Agdie', 'Jl. Tenggilis', 'wuaw');

-- --------------------------------------------------------

--
-- Table structure for table `order_penjualan`
--

CREATE TABLE `order_penjualan` (
  `id` varchar(45) NOT NULL,
  `tanggal` datetime DEFAULT NULL,
  `unit` varchar(45) DEFAULT NULL,
  `id_customer` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `order_penjualan`
--

INSERT INTO `order_penjualan` (`id`, `tanggal`, `unit`, `id_customer`) VALUES
('PO/20190327/001', '2019-03-27 04:13:52', 'wanz', '1'),
('PO/20190522/001', '2019-05-22 03:49:29', 'Kepala Divisi IT UGM', '1'),
('PO/20190522/002', '2019-05-22 03:53:31', 'Staff IT', '2'),
('PO/20190523/001', '2019-06-04 10:27:27', 'kepla it', '2'),
('PO/20190624/001', '2019-06-24 03:19:10', 'Kepala bagian lab UKP', '2');

-- --------------------------------------------------------

--
-- Table structure for table `pekerja`
--

CREATE TABLE `pekerja` (
  `id` varchar(45) NOT NULL,
  `nama` varchar(45) DEFAULT NULL,
  `alamat` varchar(45) DEFAULT NULL,
  `nomer_hp` varchar(45) DEFAULT NULL,
  `id_jabatan` varchar(45) NOT NULL,
  `username` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `pekerja`
--

INSERT INTO `pekerja` (`id`, `nama`, `alamat`, `nomer_hp`, `id_jabatan`, `username`, `password`) VALUES
('1', 'Indri', 'Jl. Panjang Jiwo No.3', '082138234567', 'J1', 'indri', ''),
('2', 'Joko Wowo', 'Jl. Kali Rungkut No.123', '081123143424', 'J2', 'joko', ''),
('3', 'Beni Saputera', 'Jl. Blitar 3', '083-3241-2343', 'J3', '', ''),
('4', 'Otnil Kepin', 'Jl. Pinggiran Kota No. 4', '08123413333', 'J3', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `pemesanan_bahan_baku`
--

CREATE TABLE `pemesanan_bahan_baku` (
  `kode` varchar(45) NOT NULL,
  `nomor_spk` varchar(45) NOT NULL,
  `tanggal` datetime DEFAULT NULL,
  `total_harga` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `pemesanan_bahan_baku`
--

INSERT INTO `pemesanan_bahan_baku` (`kode`, `nomor_spk`, `tanggal`, `total_harga`) VALUES
('P002', 'SP/20190522/002', '2019-06-24 03:10:29', 1100000),
('PBB001', 'SP/20190624/003', '2019-06-24 03:28:58', 40000),
('PBESI', 'SP/20190522/001', '2019-06-24 02:58:46', 10000),
('PSEN', 'SP/20190624/003', '2019-06-24 03:40:26', 2),
('w', 'SP/20190522/001', '2019-05-22 05:08:19', 100);

-- --------------------------------------------------------

--
-- Table structure for table `penggunaan_bahan_baku`
--

CREATE TABLE `penggunaan_bahan_baku` (
  `id_bahan_baku` varchar(45) NOT NULL,
  `nomor_spk` varchar(45) NOT NULL,
  `jumlah_masuk` int(11) DEFAULT NULL,
  `jumlah_keluar` int(11) DEFAULT NULL,
  `tanggal_keluar` datetime DEFAULT NULL,
  `stok_opname_tanggal` varchar(45) DEFAULT NULL,
  `sisa_stok` int(11) DEFAULT NULL,
  `jenis` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `penggunaan_bahan_baku`
--

INSERT INTO `penggunaan_bahan_baku` (`id_bahan_baku`, `nomor_spk`, `jumlah_masuk`, `jumlah_keluar`, `tanggal_keluar`, `stok_opname_tanggal`, `sisa_stok`, `jenis`) VALUES
('BB001', 'SP/20190522/001', 5, 5, '2019-05-22 05:08:42', 'Kayu Jati25 m222Mei2019', 5, 'Kayu Jati'),
('BB004', 'SP/20190624/003', 20, 1, '2019-06-24 04:12:49', 'BESI10 cm24Juni2019', 99, 'BESI'),
('BB009', 'SP/20190624/003', 50, 7, '2019-06-24 04:12:49', 'EMAS20 m²24Juni2019', 313, 'EMAS');

-- --------------------------------------------------------

--
-- Table structure for table `pengiriman`
--

CREATE TABLE `pengiriman` (
  `nomor_dokumen` varchar(45) NOT NULL,
  `nomor_spk` varchar(45) NOT NULL,
  `tanggal_pengiriman` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `pengiriman`
--

INSERT INTO `pengiriman` (`nomor_dokumen`, `nomor_spk`, `tanggal_pengiriman`) VALUES
('POPO', 'SP/20190624/003', '2019-06-24 04:20:48');

-- --------------------------------------------------------

--
-- Table structure for table `penjadwalan`
--

CREATE TABLE `penjadwalan` (
  `id` varchar(45) NOT NULL,
  `nomor_spk` varchar(45) NOT NULL,
  `tanggal_mulai` datetime DEFAULT NULL,
  `tanggal_selesai` datetime DEFAULT NULL,
  `keterangan` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `penjadwalan`
--

INSERT INTO `penjadwalan` (`id`, `nomor_spk`, `tanggal_mulai`, `tanggal_selesai`, `keterangan`) VALUES
('JA1', 'SP/20190522/001', '2019-05-22 04:03:05', '2019-05-23 04:03:05', 'Buat alas'),
('JA2', 'SP/20190522/001', '2019-05-23 04:04:00', '2019-05-24 04:04:00', 'BuatKaki'),
('JA3', 'SP/20190522/002', '2019-05-23 10:14:06', '2019-05-24 10:14:06', 'Pembuatan Meja'),
('JA4', 'SP/20190522/002', '2019-05-23 10:18:16', '2019-05-23 10:18:16', 'test'),
('JA5', 'SP/20190624/002', '2019-06-24 03:13:50', '2019-06-25 03:13:50', 'hhh'),
('JA6', 'SP/20190624/003', '2019-06-24 04:06:11', '2019-06-30 04:06:11', 'Membuat meja emas'),
('JA7', 'SP/20190624/002', '2019-06-24 04:10:43', '2019-06-30 04:10:43', 'Membuat rangka meja emas');

-- --------------------------------------------------------

--
-- Table structure for table `progress_produksi`
--

CREATE TABLE `progress_produksi` (
  `nomer_dokumen` varchar(45) NOT NULL COMMENT '1 Proses produksi memerlukan 1 mesin\n',
  `nomor_spk` varchar(45) NOT NULL,
  `id_mesin` varchar(45) NOT NULL,
  `id_pekerja_tukang` varchar(45) NOT NULL,
  `tanggal_mulai` datetime DEFAULT NULL,
  `tanggal_selesai` datetime DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `keterangan` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `progress_produksi`
--

INSERT INTO `progress_produksi` (`nomer_dokumen`, `nomor_spk`, `id_mesin`, `id_pekerja_tukang`, `tanggal_mulai`, `tanggal_selesai`, `status`, `keterangan`) VALUES
('P001', 'SP/20190522/001', 'M1', '1', '2019-05-22 04:18:38', '2019-05-23 04:18:38', 'Progress', 'test'),
('P002', 'SP/20190522/001', 'M2', '1', '2019-05-22 04:18:38', '2019-05-23 04:18:38', 'Pending', 'Messhsh'),
('P003', 'SP/20190522/002', 'M2', '4', '2019-05-22 04:33:16', '2019-05-22 04:33:16', 'Progress', 'TEST'),
('P004', 'SP/20190523/001', 'M1', '4', '2019-05-23 10:32:13', '2019-05-30 10:32:13', 'Progress', 'asd'),
('P005', 'SP/20190624/002', 'M2', '4', '2019-06-24 03:15:43', '2019-06-25 03:15:43', 'Selesai', 'AA'),
('P007', 'SP/20190624/003', 'M2', '3', '2019-06-24 04:11:16', '2019-06-30 04:11:16', 'Pending', 'Memotong kayu dengan mesin cuci');

-- --------------------------------------------------------

--
-- Table structure for table `riwayat_perbaikan`
--

CREATE TABLE `riwayat_perbaikan` (
  `id` int(11) NOT NULL,
  `id_mesin` varchar(45) NOT NULL,
  `tanggal` datetime DEFAULT NULL,
  `keterangan` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `riwayat_perbaikan`
--

INSERT INTO `riwayat_perbaikan` (`id`, `id_mesin`, `tanggal`, `keterangan`) VALUES
(1, 'M1', '2019-04-02 08:04:21', 'ganti oli'),
(2, 'M3', '2019-04-08 08:12:22', 'mesin mati total');

-- --------------------------------------------------------

--
-- Table structure for table `spk`
--

CREATE TABLE `spk` (
  `nomor` varchar(45) NOT NULL,
  `tanggal` datetime NOT NULL,
  `kode_barang` varchar(45) NOT NULL,
  `id_kepala_pekerja` varchar(45) NOT NULL,
  `pekerjaan` varchar(45) DEFAULT NULL,
  `lokasi` varchar(45) DEFAULT NULL,
  `biaya_pekerjaan` int(11) DEFAULT NULL,
  `lama_pekerjaan` varchar(45) DEFAULT NULL,
  `syarat` varchar(45) DEFAULT NULL,
  `metode` enum('DP30','Lunas') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `spk`
--

INSERT INTO `spk` (`nomor`, `tanggal`, `kode_barang`, `id_kepala_pekerja`, `pekerjaan`, `lokasi`, `biaya_pekerjaan`, `lama_pekerjaan`, `syarat`, `metode`) VALUES
('SP/20190522/001', '2019-05-22 03:59:42', 'B004', '1', 'buat sesuatu', 'Surabaya', 900000, '30', 'lemari harus bisa dilipat', 'DP30'),
('SP/20190522/002', '2019-05-22 04:32:06', 'B005', '4', 'BUatkuasd', 'Surabaya', 900000, '12', 'test', 'DP30'),
('SP/20190522/003', '2019-05-22 05:01:55', 'B005', '1', 'Mengerjakan Produk Ini', 'Surabaya', 120000, '10', 'harus emas', 'Lunas'),
('SP/20190523/001', '2019-05-23 10:29:17', 'B0100', '4', 'Membuat Meja', 'Surabaya', 100000, '10', '-', 'DP30'),
('SP/20190624/001', '2019-06-24 01:36:49', 'B0101', '1', 'a', 'asasas', 1000000, '12', 'aaa', 'Lunas'),
('SP/20190624/002', '2019-06-24 03:13:09', 'B005', '2', 'qq', 'eee', 4555666, '45', 'fghgh', 'Lunas'),
('SP/20190624/003', '2019-06-24 03:20:11', 'BB008', '3', 'Membuat meja emas', 'TEACHING INDUSTRY', 1000000, '10', 'Harus membayar 30%', 'DP30');

-- --------------------------------------------------------

--
-- Table structure for table `supplier`
--

CREATE TABLE `supplier` (
  `id` varchar(45) NOT NULL,
  `nama` varchar(45) DEFAULT NULL,
  `alamat` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `supplier`
--

INSERT INTO `supplier` (`id`, `nama`, `alamat`) VALUES
('1', 'PT. Surya Nagasari', 'Jl. Semolowaru No.6'),
('2', 'CV. Adi Beton Sejahtera', 'Jl. Diponogoro Gang XII 5');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bahan_baku`
--
ALTER TABLE `bahan_baku`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_bahan_baku_supplier1_idx` (`id_supplier`);

--
-- Indexes for table `barang`
--
ALTER TABLE `barang`
  ADD PRIMARY KEY (`kode`),
  ADD KEY `fk_barang_order_penjualan_idx` (`id_order_penjualan`);

--
-- Indexes for table `bill_of_materials`
--
ALTER TABLE `bill_of_materials`
  ADD PRIMARY KEY (`id_bahan_baku`,`kode_barang`),
  ADD KEY `fk_bahan_baku_has_barang_barang1_idx` (`kode_barang`),
  ADD KEY `fk_bahan_baku_has_barang_bahan_baku1_idx` (`id_bahan_baku`);

--
-- Indexes for table `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `detail_pemesanan_bahan_baku`
--
ALTER TABLE `detail_pemesanan_bahan_baku`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_nota_beli_pemesanan_bahan_baku_pemesanan_bahan_baku1_idx` (`kode_pemesanan_bahan_baku`),
  ADD KEY `fk_detail_pemesanan_bahan_baku_bahan_baku1_idx` (`id_bahan_baku`);

--
-- Indexes for table `jabatan`
--
ALTER TABLE `jabatan`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `mesin`
--
ALTER TABLE `mesin`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `nota_penerimaan`
--
ALTER TABLE `nota_penerimaan`
  ADD PRIMARY KEY (`nomor`),
  ADD KEY `fk_nota_penerimaan_pengiriman1_idx` (`nomor_dokumen_pengiriman`);

--
-- Indexes for table `order_penjualan`
--
ALTER TABLE `order_penjualan`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_order_penjualan_customer1_idx` (`id_customer`);

--
-- Indexes for table `pekerja`
--
ALTER TABLE `pekerja`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_pekerja_jabatan1_idx` (`id_jabatan`);

--
-- Indexes for table `pemesanan_bahan_baku`
--
ALTER TABLE `pemesanan_bahan_baku`
  ADD PRIMARY KEY (`kode`),
  ADD KEY `fk_pemesanan_bahan_baku_has_spk_spk1_idx` (`nomor_spk`);

--
-- Indexes for table `penggunaan_bahan_baku`
--
ALTER TABLE `penggunaan_bahan_baku`
  ADD PRIMARY KEY (`id_bahan_baku`,`nomor_spk`),
  ADD KEY `fk_bahan_baku_has_spk_spk1_idx` (`nomor_spk`),
  ADD KEY `fk_bahan_baku_has_spk_bahan_baku1_idx` (`id_bahan_baku`);

--
-- Indexes for table `pengiriman`
--
ALTER TABLE `pengiriman`
  ADD PRIMARY KEY (`nomor_dokumen`),
  ADD KEY `fk_pengiriman_spk1_idx` (`nomor_spk`);

--
-- Indexes for table `penjadwalan`
--
ALTER TABLE `penjadwalan`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_perencanaan_spk1_idx` (`nomor_spk`);

--
-- Indexes for table `progress_produksi`
--
ALTER TABLE `progress_produksi`
  ADD PRIMARY KEY (`nomer_dokumen`),
  ADD KEY `fk_proses_produksi_spk1_idx` (`nomor_spk`),
  ADD KEY `fk_proses_produksi_mesin1_idx` (`id_mesin`),
  ADD KEY `fk_proses_produksi_pekerja1_idx` (`id_pekerja_tukang`);

--
-- Indexes for table `riwayat_perbaikan`
--
ALTER TABLE `riwayat_perbaikan`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_riwayat_perbaikan_mesin1_idx` (`id_mesin`);

--
-- Indexes for table `spk`
--
ALTER TABLE `spk`
  ADD PRIMARY KEY (`nomor`),
  ADD KEY `fk_spk_pekerja1_idx` (`id_kepala_pekerja`),
  ADD KEY `fk_spk_barang1_idx` (`kode_barang`);

--
-- Indexes for table `supplier`
--
ALTER TABLE `supplier`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `detail_pemesanan_bahan_baku`
--
ALTER TABLE `detail_pemesanan_bahan_baku`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `bahan_baku`
--
ALTER TABLE `bahan_baku`
  ADD CONSTRAINT `fk_bahan_baku_supplier1` FOREIGN KEY (`id_supplier`) REFERENCES `supplier` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `barang`
--
ALTER TABLE `barang`
  ADD CONSTRAINT `fk_barang_order_penjualan` FOREIGN KEY (`id_order_penjualan`) REFERENCES `order_penjualan` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `bill_of_materials`
--
ALTER TABLE `bill_of_materials`
  ADD CONSTRAINT `fk_bahan_baku_has_barang_bahan_baku1` FOREIGN KEY (`id_bahan_baku`) REFERENCES `bahan_baku` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_bahan_baku_has_barang_barang1` FOREIGN KEY (`kode_barang`) REFERENCES `barang` (`kode`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `detail_pemesanan_bahan_baku`
--
ALTER TABLE `detail_pemesanan_bahan_baku`
  ADD CONSTRAINT `fk_detail_pemesanan_bahan_baku_bahan_baku1` FOREIGN KEY (`id_bahan_baku`) REFERENCES `bahan_baku` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_nota_beli_pemesanan_bahan_baku_pemesanan_bahan_baku1` FOREIGN KEY (`kode_pemesanan_bahan_baku`) REFERENCES `pemesanan_bahan_baku` (`kode`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `nota_penerimaan`
--
ALTER TABLE `nota_penerimaan`
  ADD CONSTRAINT `fk_nota_penerimaan_pengiriman1` FOREIGN KEY (`nomor_dokumen_pengiriman`) REFERENCES `pengiriman` (`nomor_dokumen`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `order_penjualan`
--
ALTER TABLE `order_penjualan`
  ADD CONSTRAINT `fk_order_penjualan_customer1` FOREIGN KEY (`id_customer`) REFERENCES `customer` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `pekerja`
--
ALTER TABLE `pekerja`
  ADD CONSTRAINT `fk_pekerja_jabatan1` FOREIGN KEY (`id_jabatan`) REFERENCES `jabatan` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `pemesanan_bahan_baku`
--
ALTER TABLE `pemesanan_bahan_baku`
  ADD CONSTRAINT `fk_pemesanan_bahan_baku_has_spk_spk1` FOREIGN KEY (`nomor_spk`) REFERENCES `spk` (`nomor`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `penggunaan_bahan_baku`
--
ALTER TABLE `penggunaan_bahan_baku`
  ADD CONSTRAINT `fk_bahan_baku_has_spk_bahan_baku1` FOREIGN KEY (`id_bahan_baku`) REFERENCES `bahan_baku` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_bahan_baku_has_spk_spk1` FOREIGN KEY (`nomor_spk`) REFERENCES `spk` (`nomor`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `pengiriman`
--
ALTER TABLE `pengiriman`
  ADD CONSTRAINT `fk_pengiriman_spk1` FOREIGN KEY (`nomor_spk`) REFERENCES `spk` (`nomor`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `penjadwalan`
--
ALTER TABLE `penjadwalan`
  ADD CONSTRAINT `fk_perencanaan_spk1` FOREIGN KEY (`nomor_spk`) REFERENCES `spk` (`nomor`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `progress_produksi`
--
ALTER TABLE `progress_produksi`
  ADD CONSTRAINT `fk_proses_produksi_mesin1` FOREIGN KEY (`id_mesin`) REFERENCES `mesin` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_proses_produksi_pekerja1` FOREIGN KEY (`id_pekerja_tukang`) REFERENCES `pekerja` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_proses_produksi_spk1` FOREIGN KEY (`nomor_spk`) REFERENCES `spk` (`nomor`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `riwayat_perbaikan`
--
ALTER TABLE `riwayat_perbaikan`
  ADD CONSTRAINT `fk_riwayat_perbaikan_mesin1` FOREIGN KEY (`id_mesin`) REFERENCES `mesin` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `spk`
--
ALTER TABLE `spk`
  ADD CONSTRAINT `fk_spk_barang1` FOREIGN KEY (`kode_barang`) REFERENCES `barang` (`kode`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_spk_pekerja1` FOREIGN KEY (`id_kepala_pekerja`) REFERENCES `pekerja` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
