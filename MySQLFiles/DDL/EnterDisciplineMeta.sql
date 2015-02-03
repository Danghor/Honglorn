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

-- Dumping structure for procedure bjs.EnterDisciplineMeta
DROP PROCEDURE IF EXISTS `EnterDisciplineMeta`;
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `EnterDisciplineMeta`(cClassName CHAR(1) CHARSET utf8, yYear Year(4), eGameType ENUM('Competition','Traditional'), cMaleSprintPKey CHAR(36) CHARSET utf8, cMaleJumpPKey CHAR(36) CHARSET utf8, cMaleThrowPKey CHAR(36) CHARSET utf8, cMaleMiddleDistancePKey CHAR(36) CHARSET utf8, cFemaleSprintPKey CHAR(36) CHARSET utf8, cFemaleJumpPKey CHAR(36) CHARSET utf8, cFemaleThrowPKey CHAR(36) CHARSET utf8, cFemaleMiddleDistancePKey CHAR(36) CHARSET utf8)
BEGIN

IF COALESCE(cMaleSprintPKey,cMaleJumpPKey,cMaleThrowPKey,cMaleMiddleDistancePKey,cFemaleSprintPKey,cFemaleJumpPKey,cFemaleThrowPKey,cFemaleMiddleDistancePKey) IS NULL THEN

	DELETE FROM dm
    USING DisciplineMeta dm
    INNER JOIN Class ON dm.ClassPKey = Class.PKey
    WHERE ClassName = cClassName
    AND Year = yYear;
        
ELSE

	IF IsValidDisciplineMeta(eGameType,cMaleSprintPKey,cMaleJumpPKey,cMaleThrowPKey,cMaleMiddleDistancePKey,cFemaleSprintPKey,cFemaleJumpPKey,cFemaleThrowPKey,cFemaleMiddleDistancePKey) THEN
    
		IF DisciplineMetaExists(cClassName, yYear) THEN

			update DisciplineMeta
            set GameType = eGameType,
				MaleSprintPKey = cMaleSprintPKey,
				MaleJumpPKey = cMaleJumpPKey,
				MaleThrowPKey = cMaleThrowPKey,
				MaleMiddleDistancePKey = cMaleMiddleDistancePKey,
				FemaleSprintPKey = cFemaleSprintPKey,
				FemaleJumpPKey = cFemaleJumpPKey,
				FemaleThrowPKey = cFemaleThrowPKey,
				FemaleMiddleDistancePKey = cFemaleMiddleDistancePKey
			where ClassPKey = GetClassPKey(cClassName)
			 and  Year = yYear;
        
        ELSE

			insert into DisciplineMeta (ClassPKey,`Year`,GameType,MaleSprintPKey,MaleJumpPKey,MaleThrowPKey,MaleMiddleDistancePKey,FemaleSprintPKey,FemaleJumpPKey,FemaleThrowPKey,FemaleMiddleDistancePKey)
            values (GetClassPKey(cClassName),yYear,eGameType,cMaleSprintPKey,cMaleJumpPKey,cMaleThrowPKey,cMaleMiddleDistancePKey,cFemaleSprintPKey,cFemaleJumpPKey,cFemaleThrowPKey,cFemaleMiddleDistancePKey);

        END IF;
    
    END IF;
    
END IF;

END//
DELIMITER ;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
