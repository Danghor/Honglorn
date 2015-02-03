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

-- Dumping structure for table bjs.competitiondiscipline
DROP TABLE IF EXISTS `competitiondiscipline`;
CREATE TABLE IF NOT EXISTS `competitiondiscipline` (
  `PKey` char(36) COLLATE utf8_unicode_ci NOT NULL,
  `Type` enum('Sprint','Jump','Throw','MiddleDistance') COLLATE utf8_unicode_ci NOT NULL,
  `Name` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `Unit` varchar(25) COLLATE utf8_unicode_ci NOT NULL,
  `LowIsBetter` tinyint(1) NOT NULL,
  PRIMARY KEY (`PKey`),
  UNIQUE KEY `Name_UNIQUE` (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Dumping data for table bjs.competitiondiscipline: ~0 rows (approximately)
DELETE FROM `competitiondiscipline`;
/*!40000 ALTER TABLE `competitiondiscipline` DISABLE KEYS */;
/*!40000 ALTER TABLE `competitiondiscipline` ENABLE KEYS */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
