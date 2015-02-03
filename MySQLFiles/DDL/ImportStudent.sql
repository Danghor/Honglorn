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
DROP PROCEDURE IF EXISTS `ImportStudent`;
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `ImportStudent`(IN `sSurname` VARCHAR(45), IN `sForename` VARCHAR(45), IN `cCourseName` CHAR(3), IN `cClassName` CHAR(1), IN `eSex` ENUM('Male','Female'), IN `yYearOfBirth` YEAR(4), IN `yYear` YEAR(4))
BEGIN

declare cStudentPKey CHAR(36);
declare cRetrievedCoursePKey CHAR(36);
declare cGeneratedCoursePKey CHAR(36);
declare cGeneratedStudentPKey CHAR(36);
declare cRetrievedClassPKey CHAR(36);
declare cGeneratedClassPKey CHAR(36);

IF StudentExists(sSurname, sForename, eSex, yYearOfBirth) then
	set cStudentPKey = GetStudentPKey(sSurname, sForename, eSex, yYearOfBirth);
else
    set cStudentPKey = uuid();
    INSERT INTO Student (PKey,Surname,Forename,Sex,YearOfBirth) VALUES (cStudentPKey,sSurname,sForename,eSex,yYearOfBirth);
end if;

if not StudentCourseRelExists(cStudentPKey, yYear) then
	if CourseExists(cCourseName) then
		INSERT INTO StudentCourseRel (StudentPKey,CourseName,`Year`) VALUES (cStudentPKey,cCourseName,yYear);
	else
		if ClassExists(cClassName) then
			set cRetrievedClassPKey = GetClassPKey(cClassName);
			INSERT INTO CourseClassRel (CourseName,ClassPKey) VALUES (cCourseName,cRetrievedClassPKey);
			INSERT INTO StudentCourseRel (StudentPKey,CourseName,`Year`) VALUES (cStudentPKey,cCourseName,yYear);
		else
			set cGeneratedClassPKey = uuid();
			INSERT INTO Class (PKey,ClassName) VALUES (cGeneratedClassPKey,cClassName);
			INSERT INTO CourseClassRel (CourseName,ClassPKey) VALUES (cCourseName,cGeneratedClassPKey);
			INSERT INTO StudentCourseRel (StudentPKey,CourseName,`Year`) VALUES (cStudentPKey,cCourseName,yYear);
		end if;
	end if;
end if;

END//
DELIMITER ;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
