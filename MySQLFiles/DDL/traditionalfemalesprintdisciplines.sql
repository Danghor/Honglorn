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

-- Dumping structure for view bjs.traditionalfemalesprintdisciplines
DROP VIEW IF EXISTS `traditionalfemalesprintdisciplines`;
-- Removing temporary table and create final VIEW structure
DROP TABLE IF EXISTS `traditionalfemalesprintdisciplines`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` VIEW `traditionalfemalesprintdisciplines` AS SELECT PKey, Name, Measurement
FROM TraditionalDiscipline
WHERE `Type` = "Sprint" AND `Sex` = "Female"
ORDER BY Measurement ASC, LENGTH(Name) ASC, Name ASC ;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
