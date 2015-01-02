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
CREATE TABLE IF NOT EXISTS `traditionalreportmeta` (
  `PKey` char(36) COLLATE utf8_unicode_ci NOT NULL,
  `Sex` enum('Male','Female') COLLATE utf8_unicode_ci NOT NULL,
  `Age` int(2) unsigned zerofill NOT NULL,
  `HonoraryCertificateScore` int(4) NOT NULL,
  `VictoryCertificateScore` int(4) NOT NULL,
  PRIMARY KEY (`PKey`),
  UNIQUE KEY `SexAgeUNIQUE` (`Sex`,`Age`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Data exporting was unselected.
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
