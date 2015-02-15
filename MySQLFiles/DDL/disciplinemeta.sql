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

-- Dumping structure for table bjs.disciplinemeta
DROP TABLE IF EXISTS `disciplinemeta`;
CREATE TABLE IF NOT EXISTS `disciplinemeta` (
  `ClassPKey` char(36) COLLATE utf8_unicode_ci NOT NULL,
  `Year` year(4) NOT NULL,
  `GameType` enum('Competition','Traditional') COLLATE utf8_unicode_ci NOT NULL,
  `MaleSprintPKey` char(36) COLLATE utf8_unicode_ci NOT NULL COMMENT 'Polymorphic',
  `MaleJumpPKey` char(36) COLLATE utf8_unicode_ci NOT NULL COMMENT 'Polymorphic',
  `MaleThrowPKey` char(36) COLLATE utf8_unicode_ci NOT NULL COMMENT 'Polymorphic',
  `MaleMiddleDistancePKey` char(36) COLLATE utf8_unicode_ci NOT NULL COMMENT 'Polymorphic',
  `FemaleSprintPKey` char(36) COLLATE utf8_unicode_ci NOT NULL COMMENT 'Polymorphic',
  `FemaleJumpPKey` char(36) COLLATE utf8_unicode_ci NOT NULL COMMENT 'Polymorphic',
  `FemaleThrowPKey` char(36) COLLATE utf8_unicode_ci NOT NULL COMMENT 'Polymorphic',
  `FemaleMiddleDistancePKey` char(36) COLLATE utf8_unicode_ci NOT NULL COMMENT 'Polymorphic',
  PRIMARY KEY (`ClassPKey`,`Year`),
  KEY `YearINDEX` (`Year`),
  CONSTRAINT `DisciplineMetaClassPKey` FOREIGN KEY (`ClassPKey`) REFERENCES `class` (`PKey`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- Dumping data for table bjs.disciplinemeta: ~0 rows (approximately)
DELETE FROM `disciplinemeta`;
/*!40000 ALTER TABLE `disciplinemeta` DISABLE KEYS */;
INSERT INTO `disciplinemeta` (`ClassPKey`, `Year`, `GameType`, `MaleSprintPKey`, `MaleJumpPKey`, `MaleThrowPKey`, `MaleMiddleDistancePKey`, `FemaleSprintPKey`, `FemaleJumpPKey`, `FemaleThrowPKey`, `FemaleMiddleDistancePKey`) VALUES
	('abc6906f-936c-11e4-a9c1-600292148ec2', '2014', 'Traditional', '9f6f0333-b70e-4d55-98c0-67057decbee0', '25ce654a-68dd-4094-b2b6-737581fb8957', '0560491e-f326-483b-974f-6d07b967d427', '48742630-8e5b-41d0-934c-f4a58e8227f4', '80927ffb-7f27-11e4-bf87-00249b0f3387', '25ce654a-68dd-4094-b2b6-737581fb8957', '0dcf6e43-e4d3-4dae-8966-8ce805dbb64e', 'bfe57845-d9d2-4d33-9ca9-d8ac82d1dca6');
/*!40000 ALTER TABLE `disciplinemeta` ENABLE KEYS */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
