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

-- Dumping structure for procedure bjs.EnterCompetitionValues
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `EnterCompetitionValues`(IN `cPKey` CHAR(36), IN `yYear` YEAR(4), IN `fSprintValue` FLOAT, IN `fJumpValue` FLOAT, IN `fThrowValue` FLOAT, IN `fMiddleDistanceValue` FLOAT)
BEGIN
IF EXISTS (SELECT NULL FROM Competition WHERE StudentPKey = cPKey AND YEAR = yYear) THEN
  IF COALESCE(fSprintValue,fJumpValue,fThrowValue,fMiddleDistanceValue) IS NULL THEN
    DELETE FROM Competition WHERE StudentPKey = cPKey AND Year = yYear;
  ELSE
    UPDATE Competition SET Sprint = fSprintValue, Jump = fJumpValue, Throw = fThrowValue, MiddleDistance = fMiddleDistanceValue WHERE StudentPKey = cPKey AND YEAR = yYEAR;
  END IF;
ELSE
  INSERT INTO Competition (StudentPKey,Year,Sprint,Jump,Throw,MiddleDistance) VALUES (cPKey,yYEAR,fSprintValue,fJumpValue,fThrowValue,fMiddleDistanceValue);
END IF;
END//
DELIMITER ;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
