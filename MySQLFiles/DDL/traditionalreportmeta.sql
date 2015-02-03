-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               5.6.15-log - MySQL Community Server (GPL)
-- Server OS:                    Win32
-- HeidiSQL Version:             9.1.0.4867
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- Dumping structure for table bjs.traditionalreportmeta
DROP TABLE IF EXISTS `traditionalreportmeta`;
CREATE TABLE IF NOT EXISTS `traditionalreportmeta` (
  `PKey` char(36) COLLATE utf8_unicode_ci NOT NULL,
  `Sex` enum('Male','Female') COLLATE utf8_unicode_ci NOT NULL,
  `Age` int(2) unsigned zerofill NOT NULL,
  `HonoraryCertificateScore` int(4) NOT NULL,
  `VictoryCertificateScore` int(4) NOT NULL,
  PRIMARY KEY (`PKey`),
  UNIQUE KEY `SexAgeUNIQUE` (`Sex`,`Age`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Dumping data for table bjs.traditionalreportmeta: ~23 rows (approximately)
DELETE FROM `traditionalreportmeta`;
/*!40000 ALTER TABLE `traditionalreportmeta` DISABLE KEYS */;
INSERT INTO `traditionalreportmeta` (`PKey`, `Sex`, `Age`, `HonoraryCertificateScore`, `VictoryCertificateScore`) VALUES
	('13c6c0d2-76f1-49b1-9ee3-146aef697b68', 'Male', 17, 1400, 1125),
	('1ebc5e7d-ec86-4dcf-81c8-1a7e221a975b', 'Male', 10, 775, 600),
	('2d859676-dd11-4265-8988-1dfa8d1fc966', 'Male', 19, 1550, 1275),
	('40d2abbb-9f4e-4651-a87c-afbd481cd165', 'Female', 11, 900, 700),
	('47e90afd-953c-4ebf-ab17-834d2ca26467', 'Male', 13, 1050, 825),
	('4e2a0780-51cf-440a-b5aa-ca69b6b26b9f', 'Female', 18, 1150, 950),
	('6d415c15-2a06-47b8-819e-fdc61a5c988b', 'Male', 12, 975, 750),
	('7143df0f-9211-4238-b1d2-aa3f6957bbc0', 'Female', 13, 1025, 825),
	('7bfa22c2-d48a-4c91-a946-a4dbb33f32cc', 'Female', 15, 1075, 875),
	('8289c7bc-960a-4bc0-8bef-a06dbee80459', 'Female', 08, 625, 475),
	('8ad75e1d-da87-4d74-8c31-2aad5e78ca84', 'Male', 11, 875, 675),
	('9bea4fb4-ba32-4c7f-9b7b-a003825b7471', 'Male', 15, 1225, 975),
	('a12347d4-0b50-4682-ba0f-e59d92945bf0', 'Female', 17, 1125, 925),
	('a2d5fb6b-13da-453f-ac3b-d92d1895e708', 'Male', 14, 1125, 900),
	('b0380ba0-0084-4fa8-b4d2-66ceb47f7de3', 'Male', 08, 575, 450),
	('c014bbc4-71f7-426d-a689-263d5569141f', 'Male', 18, 1475, 1200),
	('c02347fd-b640-4841-b1c2-2b0b6e52fdd9', 'Female', 16, 1100, 900),
	('cc927219-030c-4a03-98d6-eaaffce5959a', 'Female', 14, 1050, 850),
	('d895f448-ec5b-49cc-b56f-8ac716f18945', 'Male', 16, 1325, 1050),
	('dd634026-f207-4833-ad33-7e21f36cf7ee', 'Female', 12, 975, 775),
	('e12ca7bb-bc8a-4c94-9dbc-001a7b2ad59f', 'Female', 10, 825, 625),
	('e97eb114-c7b2-4c3e-9044-99bb04897824', 'Male', 09, 675, 525),
	('fc1b97e0-2946-4b85-a2a9-ae864ef8adf7', 'Female', 09, 725, 550);
/*!40000 ALTER TABLE `traditionalreportmeta` ENABLE KEYS */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
