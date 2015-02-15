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

-- Dumping structure for table bjs.competition
DROP TABLE IF EXISTS `competition`;
CREATE TABLE IF NOT EXISTS `competition` (
  `StudentPKey` char(36) COLLATE utf8_unicode_ci NOT NULL,
  `Year` year(4) NOT NULL,
  `Sprint` float DEFAULT NULL,
  `Jump` float DEFAULT NULL,
  `Throw` float DEFAULT NULL,
  `MiddleDistance` float DEFAULT NULL,
  PRIMARY KEY (`StudentPKey`,`Year`),
  KEY `StudentPKeyINDEX` (`StudentPKey`),
  KEY `YearINDEX` (`Year`),
  CONSTRAINT `StudentPKey` FOREIGN KEY (`StudentPKey`) REFERENCES `student` (`PKey`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Dumping data for table bjs.competition: ~2 rows (approximately)
DELETE FROM `competition`;
/*!40000 ALTER TABLE `competition` DISABLE KEYS */;
INSERT INTO `competition` (`StudentPKey`, `Year`, `Sprint`, `Jump`, `Throw`, `MiddleDistance`) VALUES
	('a9b24f91-936c-11e4-a9c1-600292148ec2', '2014', 1, 2, 3, 4),
	('a9bbea3d-936c-11e4-a9c1-600292148ec2', '2014', 12.5, 135, NULL, 65);
/*!40000 ALTER TABLE `competition` ENABLE KEYS */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
