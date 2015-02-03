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

-- Dumping structure for function bjs.StudentExists
DROP FUNCTION IF EXISTS `StudentExists`;
DELIMITER //
CREATE DEFINER=`root`@`localhost` FUNCTION `StudentExists`(`sSurname` VARCHAR(45) CHARSET utf8, `sForename` VARCHAR(45) CHARSET utf8, `eSex` ENUM('Male','Female') CHARSET utf8, `yYearOfBirth` YEAR(4)) RETURNS tinyint(1)
    READS SQL DATA
BEGIN

RETURN exists(SELECT null from Student where Surname = sSurname COLLATE utf8_unicode_ci and Forename = sForename COLLATE utf8_unicode_ci and Sex = eSex COLLATE utf8_unicode_ci and YearOfBirth = yYearOfBirth);

END//
DELIMITER ;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
