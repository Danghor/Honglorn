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

-- Dumping structure for function bjs.IsValidDisciplineMeta
DROP FUNCTION IF EXISTS `IsValidDisciplineMeta`;
DELIMITER //
CREATE DEFINER=`root`@`localhost` FUNCTION `IsValidDisciplineMeta`(eGameType ENUM('Competition','Traditional'), cMaleSprintPKey CHAR(36) CHARSET utf8, cMaleJumpPKey CHAR(36) CHARSET utf8, cMaleThrowPKey CHAR(36) CHARSET utf8, cMaleMiddleDistancePKey CHAR(36) CHARSET utf8, cFemaleSprintPKey CHAR(36) CHARSET utf8, cFemaleJumpPKey CHAR(36) CHARSET utf8, cFemaleThrowPKey CHAR(36) CHARSET utf8, cFemaleMiddleDistancePKey CHAR(36) CHARSET utf8) RETURNS tinyint(1)
    READS SQL DATA
BEGIN

declare bIsValid tinyint(1);
set bIsValid = 0;

IF eGameType = 'Competition' THEN

	set bIsValid = IsValidCompetitionDiscipline(cMaleSprintPKey, 'Sprint')
				AND IsValidCompetitionDiscipline(cMaleJumpPKey, 'Jump')
                AND IsValidCompetitionDiscipline(cMaleThrowPKey, 'Throw')
                AND IsValidCompetitionDiscipline(cMaleMiddleDistancePKey, 'MiddleDistance')
                AND IsValidCompetitionDiscipline(cFemaleSprintPKey, 'Sprint')
				AND IsValidCompetitionDiscipline(cFemaleJumpPKey, 'Jump')
                AND IsValidCompetitionDiscipline(cFemaleThrowPKey, 'Throw')
                AND IsValidCompetitionDiscipline(cFemaleMiddleDistancePKey, 'MiddleDistance');

ELSE IF eGameType = 'Traditional' THEN

	set bIsValid = IsValidTraditionalDiscipline(cMaleSprintPKey, 'Male', 'Sprint')
				AND IsValidTraditionalDiscipline(cMaleJumpPKey, 'Male', 'Jump')
                AND IsValidTraditionalDiscipline(cMaleThrowPKey, 'Male', 'Throw')
                AND IsValidTraditionalDiscipline(cMaleMiddleDistancePKey, 'Male', 'MiddleDistance')
                AND IsValidTraditionalDiscipline(cFemaleSprintPKey, 'Female', 'Sprint')
				AND IsValidTraditionalDiscipline(cFemaleJumpPKey, 'Female', 'Jump')
                AND IsValidTraditionalDiscipline(cFemaleThrowPKey, 'Female', 'Throw')
                AND IsValidTraditionalDiscipline(cFemaleMiddleDistancePKey, 'Female', 'MiddleDistance');

	END IF;
END IF;

RETURN bIsValid;

END//
DELIMITER ;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
