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

-- Dumping structure for procedure bjs.ImportStudent
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `ImportStudent`(IN `sSurname` VARCHAR(45), IN `sForename` VARCHAR(45), IN `cCourseName` CHAR(3), IN `eSex` ENUM('Male','Female'), IN `yYearOfBirth` YEAR(4), IN `yYear` YEAR(4))
BEGIN

declare cRetrievedStudentPKey CHAR(36);
declare cRetrievedCoursePKey CHAR(36);
declare cGeneratedCoursePKey CHAR(36);
declare cGeneratedStudentPKey CHAR(36);

IF StudentExists(sSurname, sForename, eSex, yYearOfBirth) then

    set cRetrievedStudentPKey = GetStudentPKey(sSurname, sForename, eSex, yYearOfBirth);
	if not StudentCourseRelExists(cRetrievedPKey, yYear) then
		
        if CourseExists(cCourseName) then
			set cRetrievedCoursePKey = GetCoursePKey(cCourseName);
            INSERT INTO StudentCourseRel (StudentPKey,CoursePKey,`Year`) VALUES (cRetrievedStudentPKey,cRetrievedCoursePKey,yYear);
        else
			set cGeneratedCoursePKey = uuid();
            INSERT INTO Course (PKey,CourseName) VALUES (cGeneratedCoursePKey,cCourseName);
            INSERT INTO StudentCourseRel (StudentPKey,CoursePKey,`Year`) VALUES (cRetrievedStudentPKey,cGeneratedCoursePKey,yYear);
        end if;
        
    end if;
    
else
    
    set cGeneratedStudentPKey = uuid();
    INSERT INTO Student (PKey,Surname,Forename,Sex,YearOfBirth) VALUES (cGeneratedStudentPKey,sSurname,sForename,eSex,yYearOfBirth);
    
    if CourseExists(cCourseName) then
			set cRetrievedCoursePKey = GetCoursePKey(cCourseName);
            INSERT INTO StudentCourseRel (StudentPKey,CoursePKey,`Year`) VALUES (cGeneratedStudentPKey,cRetrievedCoursePKey,yYear);
	else
			set cGeneratedCoursePKey = uuid();
            INSERT INTO Course (PKey,CourseName) VALUES (cGeneratedCoursePKey,cCourseName);
            INSERT INTO StudentCourseRel (StudentPKey,CoursePKey,`Year`) VALUES (cGeneratedStudentPKey,cGeneratedCoursePKey,yYear);
	end if;
    
end if;

END//
DELIMITER ;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
