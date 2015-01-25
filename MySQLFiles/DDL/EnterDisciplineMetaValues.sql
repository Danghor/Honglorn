CREATE DEFINER=`root`@`localhost` PROCEDURE `EnterDisciplineMetaValues`(IN `cClassName` CHAR(1), IN `yYear` YEAR(4), IN `eGameType` ENUM('Traditional','Competition'), IN `MaleSprintPKey` CHAR(36), IN `MaleJumpPKey` CHAR(36), IN `MaleThrowPKey` CHAR(36), IN `MaleMiddleDistancePKey` CHAR(36), IN `FemaleSprintPKey` CHAR(36), IN `FemaleJumpPKey` CHAR(36), IN `FemaleThrowPKey` CHAR(36), IN `FemaleMiddleDistancePKey` CHAR(36))
BEGIN
IF EXISTS (SELECT NULL FROM Competition WHERE StudentPKey = cPKey AND YEAR = yYear) THEN
  
  IF COALESCE(fSprintValue,fJumpValue,fThrowValue,fMiddleDistanceValue) IS NULL THEN
    
    DELETE FROM Competition
    WHERE StudentPKey = cPKey
		AND Year = yYear;
  
  ELSE
  
    UPDATE Competition
    SET Sprint = fSprintValue,
		Jump = fJumpValue,
        Throw = fThrowValue,
        MiddleDistance = fMiddleDistanceValue
	WHERE StudentPKey = cPKey
		AND YEAR = yYEAR;
        
  END IF;
  
ELSE

  INSERT INTO Competition (StudentPKey,Year,Sprint,Jump,Throw,MiddleDistance) VALUES (cPKey,yYEAR,fSprintValue,fJumpValue,fThrowValue,fMiddleDistanceValue);

END IF;
END