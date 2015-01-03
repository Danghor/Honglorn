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

-- Data exporting was unselected.
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
