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

-- Dumping structure for table bjs.courseclassrel
DROP TABLE IF EXISTS `courseclassrel`;
CREATE TABLE IF NOT EXISTS `courseclassrel` (
  `CourseName` char(3) COLLATE utf8_unicode_ci NOT NULL,
  `ClassPKey` char(36) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`CourseName`),
  KEY `ClassPKeyINDEX` (`ClassPKey`),
  CONSTRAINT `ClassPKey` FOREIGN KEY (`ClassPKey`) REFERENCES `class` (`PKey`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Dumping data for table bjs.courseclassrel: ~24 rows (approximately)
DELETE FROM `courseclassrel`;
/*!40000 ALTER TABLE `courseclassrel` DISABLE KEYS */;
INSERT INTO `courseclassrel` (`CourseName`, `ClassPKey`) VALUES
	('05A', 'a9914e5e-936c-11e4-a9c1-600292148ec2'),
	('05B', 'a9914e5e-936c-11e4-a9c1-600292148ec2'),
	('05C', 'a9914e5e-936c-11e4-a9c1-600292148ec2'),
	('05D', 'a9914e5e-936c-11e4-a9c1-600292148ec2'),
	('06A', 'aa2cf624-936c-11e4-a9c1-600292148ec2'),
	('06B', 'aa2cf624-936c-11e4-a9c1-600292148ec2'),
	('06C', 'aa2cf624-936c-11e4-a9c1-600292148ec2'),
	('06D', 'aa2cf624-936c-11e4-a9c1-600292148ec2'),
	('07A', 'aab238c7-936c-11e4-a9c1-600292148ec2'),
	('07B', 'aab238c7-936c-11e4-a9c1-600292148ec2'),
	('07C', 'aab238c7-936c-11e4-a9c1-600292148ec2'),
	('07D', 'aab238c7-936c-11e4-a9c1-600292148ec2'),
	('08A', 'ab40124d-936c-11e4-a9c1-600292148ec2'),
	('08B', 'ab40124d-936c-11e4-a9c1-600292148ec2'),
	('08C', 'ab40124d-936c-11e4-a9c1-600292148ec2'),
	('08D', 'ab40124d-936c-11e4-a9c1-600292148ec2'),
	('09A', 'abc6906f-936c-11e4-a9c1-600292148ec2'),
	('09B', 'abc6906f-936c-11e4-a9c1-600292148ec2'),
	('09C', 'abc6906f-936c-11e4-a9c1-600292148ec2'),
	('09D', 'abc6906f-936c-11e4-a9c1-600292148ec2'),
	('E01', 'ac527057-936c-11e4-a9c1-600292148ec2'),
	('E02', 'ac527057-936c-11e4-a9c1-600292148ec2'),
	('E03', 'ac527057-936c-11e4-a9c1-600292148ec2'),
	('E04', 'ac527057-936c-11e4-a9c1-600292148ec2');
/*!40000 ALTER TABLE `courseclassrel` ENABLE KEYS */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
