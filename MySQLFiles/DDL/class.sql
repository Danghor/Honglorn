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

-- Dumping structure for table bjs.class
DROP TABLE IF EXISTS `class`;
CREATE TABLE IF NOT EXISTS `class` (
  `PKey` char(36) COLLATE utf8_unicode_ci NOT NULL,
  `ClassName` char(1) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`PKey`),
  UNIQUE KEY `ClassNameUNIQUE` (`ClassName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Dumping data for table bjs.class: ~6 rows (approximately)
DELETE FROM `class`;
/*!40000 ALTER TABLE `class` DISABLE KEYS */;
INSERT INTO `class` (`PKey`, `ClassName`) VALUES
	('a9914e5e-936c-11e4-a9c1-600292148ec2', '5'),
	('aa2cf624-936c-11e4-a9c1-600292148ec2', '6'),
	('aab238c7-936c-11e4-a9c1-600292148ec2', '7'),
	('ab40124d-936c-11e4-a9c1-600292148ec2', '8'),
	('abc6906f-936c-11e4-a9c1-600292148ec2', '9'),
	('ac527057-936c-11e4-a9c1-600292148ec2', 'E');
/*!40000 ALTER TABLE `class` ENABLE KEYS */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
