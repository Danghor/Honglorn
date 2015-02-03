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

-- Dumping structure for table bjs.competitionreportmeta
DROP TABLE IF EXISTS `competitionreportmeta`;
CREATE TABLE IF NOT EXISTS `competitionreportmeta` (
  `Year` year(4) NOT NULL,
  `HonoraryCertificatePercentage` int(3) NOT NULL,
  `VictoryCertificatePercentage` int(3) NOT NULL,
  `Grade1Percentage` int(3) NOT NULL,
  `Grade2Percentage` int(3) NOT NULL,
  `Grade3Percentage` int(3) NOT NULL,
  `Grade4Percentage` int(3) NOT NULL,
  `Grade5Percentage` int(3) NOT NULL,
  PRIMARY KEY (`Year`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Dumping data for table bjs.competitionreportmeta: ~0 rows (approximately)
DELETE FROM `competitionreportmeta`;
/*!40000 ALTER TABLE `competitionreportmeta` DISABLE KEYS */;
/*!40000 ALTER TABLE `competitionreportmeta` ENABLE KEYS */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
