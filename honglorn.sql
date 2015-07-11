CREATE DATABASE  IF NOT EXISTS `honglorn` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `honglorn`;
-- MySQL dump 10.13  Distrib 5.6.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: honglorn
-- ------------------------------------------------------
-- Server version	5.6.15-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `class`
--

DROP TABLE IF EXISTS `class`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `class` (
  `Name` char(1) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `class`
--

LOCK TABLES `class` WRITE;
/*!40000 ALTER TABLE `class` DISABLE KEYS */;
INSERT INTO `class` VALUES ('5'),('6'),('7'),('8'),('9'),('E');
/*!40000 ALTER TABLE `class` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `classdisciplinerel`
--

DROP TABLE IF EXISTS `classdisciplinerel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `classdisciplinerel` (
  `ClassName` char(1) COLLATE utf8_unicode_ci NOT NULL,
  `Year` year(4) NOT NULL,
  `CompetitionDisciplineCollectionPKey` char(36) COLLATE utf8_unicode_ci DEFAULT NULL,
  `TraditionalDisciplineCollectionPKey` char(36) COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`ClassName`,`Year`),
  KEY `ClassDisciplineRel_CompetitionDisciplineCollectionPKey_FK_idx` (`CompetitionDisciplineCollectionPKey`),
  KEY `ClassDisciplineRel_TraditionalDisciplineCollectionPKey_FK_idx` (`TraditionalDisciplineCollectionPKey`),
  CONSTRAINT `ClassDisciplineRel_ClassName_FK` FOREIGN KEY (`ClassName`) REFERENCES `class` (`Name`),
  CONSTRAINT `ClassDisciplineRel_CompetitionDisciplineCollectionPKey_FK` FOREIGN KEY (`CompetitionDisciplineCollectionPKey`) REFERENCES `competitiondisciplinecollection` (`PKey`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `ClassDisciplineRel_TraditionalDisciplineCollectionPKey_FK` FOREIGN KEY (`TraditionalDisciplineCollectionPKey`) REFERENCES `traditionaldisciplinecollection` (`PKey`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `classdisciplinerel`
--

LOCK TABLES `classdisciplinerel` WRITE;
/*!40000 ALTER TABLE `classdisciplinerel` DISABLE KEYS */;
/*!40000 ALTER TABLE `classdisciplinerel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `competition`
--

DROP TABLE IF EXISTS `competition`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `competition` (
  `StudentPKey` char(36) COLLATE utf8_unicode_ci NOT NULL,
  `Year` year(4) NOT NULL,
  `Sprint` float DEFAULT NULL,
  `Jump` float DEFAULT NULL,
  `Throw` float DEFAULT NULL,
  `MiddleDistance` float DEFAULT NULL,
  PRIMARY KEY (`StudentPKey`,`Year`),
  KEY `StudentPKeyINDEX` (`StudentPKey`),
  KEY `YearINDEX` (`Year`),
  CONSTRAINT `Competition_StudentPKey_FK` FOREIGN KEY (`StudentPKey`) REFERENCES `student` (`PKey`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `competition`
--

LOCK TABLES `competition` WRITE;
/*!40000 ALTER TABLE `competition` DISABLE KEYS */;
INSERT INTO `competition` VALUES ('a98e078b-936c-11e4-a9c1-600292148ec2',2014,2,4,4,NULL),('a9931ee6-936c-11e4-a9c1-600292148ec2',2014,34,NULL,23,NULL),('a9a65e8b-936c-11e4-a9c1-600292148ec2',2014,NULL,NULL,3,NULL),('a9aa6916-936c-11e4-a9c1-600292148ec2',2014,NULL,NULL,3,NULL),('a9aba402-936c-11e4-a9c1-600292148ec2',2014,NULL,3,3,NULL),('a9ac9e2f-936c-11e4-a9c1-600292148ec2',2014,NULL,3,3,NULL),('a9ad82e7-936c-11e4-a9c1-600292148ec2',2014,NULL,NULL,3,NULL),('a9b24f91-936c-11e4-a9c1-600292148ec2',2014,1,2,3,4),('a9b678f8-936c-11e4-a9c1-600292148ec2',2014,NULL,3,3,NULL),('a9bbea3d-936c-11e4-a9c1-600292148ec2',2014,12.5,135,4,65),('a9bf5d5b-936c-11e4-a9c1-600292148ec2',2014,3,3,3232,NULL);
/*!40000 ALTER TABLE `competition` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `competitiondiscipline`
--

DROP TABLE IF EXISTS `competitiondiscipline`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `competitiondiscipline` (
  `PKey` char(36) COLLATE utf8_unicode_ci NOT NULL,
  `Type` enum('Sprint','Jump','Throw','MiddleDistance') COLLATE utf8_unicode_ci NOT NULL,
  `Name` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `Unit` varchar(25) COLLATE utf8_unicode_ci NOT NULL,
  `LowIsBetter` tinyint(1) NOT NULL,
  PRIMARY KEY (`PKey`),
  UNIQUE KEY `Name_UNIQUE` (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `competitiondiscipline`
--

LOCK TABLES `competitiondiscipline` WRITE;
/*!40000 ALTER TABLE `competitiondiscipline` DISABLE KEYS */;
/*!40000 ALTER TABLE `competitiondiscipline` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `competitiondisciplinecollection`
--

DROP TABLE IF EXISTS `competitiondisciplinecollection`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `competitiondisciplinecollection` (
  `PKey` char(36) COLLATE utf8_unicode_ci NOT NULL,
  `MaleSprintPKey` char(36) COLLATE utf8_unicode_ci NOT NULL,
  `MaleJumpPKey` char(36) COLLATE utf8_unicode_ci NOT NULL,
  `MaleThrowPKey` char(36) COLLATE utf8_unicode_ci NOT NULL,
  `MaleMiddleDistancePKey` char(36) COLLATE utf8_unicode_ci NOT NULL,
  `FemaleSprintPKey` char(36) COLLATE utf8_unicode_ci NOT NULL,
  `FemaleJumpPKey` char(36) COLLATE utf8_unicode_ci NOT NULL,
  `FemaleThrowPKey` char(36) COLLATE utf8_unicode_ci NOT NULL,
  `FemaleMiddleDistancePKey` char(36) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`PKey`),
  KEY `CompetitionDisciplineCollection_MaleSprintPKey_FK` (`MaleSprintPKey`),
  KEY `CompetitionDisciplineCollection_MaleJumpPKey_FK` (`MaleJumpPKey`),
  KEY `CompetitionDisciplineCollection_MaleThrowPKey_FK` (`MaleThrowPKey`),
  KEY `CompetitionDisciplineCollection_MaleMiddleDistancePKey_FK` (`MaleMiddleDistancePKey`),
  KEY `CompetitionDisciplineCollection_FemaleSprintPKey_FK` (`FemaleSprintPKey`),
  KEY `CompetitionDisciplineCollection_FemaleJumpPKey_FK` (`FemaleJumpPKey`),
  KEY `CompetitionDisciplineCollection_FemaleThrowPKey_FK` (`FemaleThrowPKey`),
  KEY `CompetitionDisciplineCollection_FemaleMiddleDistancePKey_FK` (`FemaleMiddleDistancePKey`),
  CONSTRAINT `CompetitionDisciplineCollection_FemaleJumpPKey_FK` FOREIGN KEY (`FemaleJumpPKey`) REFERENCES `competitiondiscipline` (`PKey`),
  CONSTRAINT `CompetitionDisciplineCollection_FemaleMiddleDistancePKey_FK` FOREIGN KEY (`FemaleMiddleDistancePKey`) REFERENCES `competitiondiscipline` (`PKey`),
  CONSTRAINT `CompetitionDisciplineCollection_FemaleSprintPKey_FK` FOREIGN KEY (`FemaleSprintPKey`) REFERENCES `competitiondiscipline` (`PKey`),
  CONSTRAINT `CompetitionDisciplineCollection_FemaleThrowPKey_FK` FOREIGN KEY (`FemaleThrowPKey`) REFERENCES `competitiondiscipline` (`PKey`),
  CONSTRAINT `CompetitionDisciplineCollection_MaleJumpPKey_FK` FOREIGN KEY (`MaleJumpPKey`) REFERENCES `competitiondiscipline` (`PKey`),
  CONSTRAINT `CompetitionDisciplineCollection_MaleMiddleDistancePKey_FK` FOREIGN KEY (`MaleMiddleDistancePKey`) REFERENCES `competitiondiscipline` (`PKey`),
  CONSTRAINT `CompetitionDisciplineCollection_MaleSprintPKey_FK` FOREIGN KEY (`MaleSprintPKey`) REFERENCES `competitiondiscipline` (`PKey`),
  CONSTRAINT `CompetitionDisciplineCollection_MaleThrowPKey_FK` FOREIGN KEY (`MaleThrowPKey`) REFERENCES `competitiondiscipline` (`PKey`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `competitiondisciplinecollection`
--

LOCK TABLES `competitiondisciplinecollection` WRITE;
/*!40000 ALTER TABLE `competitiondisciplinecollection` DISABLE KEYS */;
/*!40000 ALTER TABLE `competitiondisciplinecollection` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary table structure for view `competitionjumpdisciplines`
--

DROP TABLE IF EXISTS `competitionjumpdisciplines`;
/*!50001 DROP VIEW IF EXISTS `competitionjumpdisciplines`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE TABLE `competitionjumpdisciplines` (
  `PKey` tinyint NOT NULL,
  `Name` tinyint NOT NULL,
  `Unit` tinyint NOT NULL,
  `LowIsBetter` tinyint NOT NULL
) ENGINE=MyISAM */;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `competitionmiddledistancedisciplines`
--

DROP TABLE IF EXISTS `competitionmiddledistancedisciplines`;
/*!50001 DROP VIEW IF EXISTS `competitionmiddledistancedisciplines`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE TABLE `competitionmiddledistancedisciplines` (
  `PKey` tinyint NOT NULL,
  `Name` tinyint NOT NULL,
  `Unit` tinyint NOT NULL,
  `LowIsBetter` tinyint NOT NULL
) ENGINE=MyISAM */;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `competitionreportmeta`
--

DROP TABLE IF EXISTS `competitionreportmeta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `competitionreportmeta` (
  `Year` year(4) NOT NULL,
  `HonoraryCertificatePercentage` int(3) NOT NULL,
  `VictoryCertificatePercentage` int(3) NOT NULL,
  `Grade1Percentage` int(3) NOT NULL,
  `Grade2Percentage` int(3) NOT NULL,
  `Grade3Percentage` int(3) NOT NULL,
  `Grade4Percentage` int(3) NOT NULL,
  `Grade5Percentage` int(3) NOT NULL,
  PRIMARY KEY (`Year`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `competitionreportmeta`
--

LOCK TABLES `competitionreportmeta` WRITE;
/*!40000 ALTER TABLE `competitionreportmeta` DISABLE KEYS */;
/*!40000 ALTER TABLE `competitionreportmeta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary table structure for view `competitionsprintdisciplines`
--

DROP TABLE IF EXISTS `competitionsprintdisciplines`;
/*!50001 DROP VIEW IF EXISTS `competitionsprintdisciplines`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE TABLE `competitionsprintdisciplines` (
  `PKey` tinyint NOT NULL,
  `Name` tinyint NOT NULL,
  `Unit` tinyint NOT NULL,
  `LowIsBetter` tinyint NOT NULL
) ENGINE=MyISAM */;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `competitionthrowdisciplines`
--

DROP TABLE IF EXISTS `competitionthrowdisciplines`;
/*!50001 DROP VIEW IF EXISTS `competitionthrowdisciplines`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE TABLE `competitionthrowdisciplines` (
  `PKey` tinyint NOT NULL,
  `Name` tinyint NOT NULL,
  `Unit` tinyint NOT NULL,
  `LowIsBetter` tinyint NOT NULL
) ENGINE=MyISAM */;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `courseclassrel`
--

DROP TABLE IF EXISTS `courseclassrel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `courseclassrel` (
  `CourseName` char(3) COLLATE utf8_unicode_ci NOT NULL,
  `ClassName` char(1) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`CourseName`),
  KEY `ClassName_idx` (`ClassName`),
  CONSTRAINT `CourseClassRel_ClassName_FK` FOREIGN KEY (`ClassName`) REFERENCES `class` (`Name`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `courseclassrel`
--

LOCK TABLES `courseclassrel` WRITE;
/*!40000 ALTER TABLE `courseclassrel` DISABLE KEYS */;
INSERT INTO `courseclassrel` VALUES ('05A','5'),('05B','5'),('05C','5'),('05D','5'),('06A','6'),('06B','6'),('06C','6'),('06D','6'),('07A','7'),('07B','7'),('07C','7'),('07D','7'),('08A','8'),('08B','8'),('08C','8'),('08D','8'),('09A','9'),('09B','9'),('09C','9'),('09D','9'),('E01','E'),('E02','E'),('E03','E'),('E04','E');
/*!40000 ALTER TABLE `courseclassrel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `student`
--

DROP TABLE IF EXISTS `student`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `student` (
  `PKey` char(36) COLLATE utf8_unicode_ci NOT NULL,
  `Surname` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `Forename` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `Sex` enum('Male','Female') COLLATE utf8_unicode_ci NOT NULL,
  `YearOfBirth` year(4) NOT NULL,
  PRIMARY KEY (`PKey`),
  UNIQUE KEY `Student_uk` (`Surname`,`Forename`,`Sex`,`YearOfBirth`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `student`
--

LOCK TABLES `student` WRITE;
/*!40000 ALTER TABLE `student` DISABLE KEYS */;
INSERT INTO `student` VALUES ('aa50d06b-936c-11e4-a9c1-600292148ec2','Adams','Frances','Female',2003),('ab8515a1-936c-11e4-a9c1-600292148ec2','Adams','Irene','Female',2002),('a9cd87cd-936c-11e4-a9c1-600292148ec2','Adams','Irene','Female',2003),('a9f5a3be-936c-11e4-a9c1-600292148ec2','Alexander','Juan','Male',2004),('ac33cdf2-936c-11e4-a9c1-600292148ec2','Allen','Alan','Male',1999),('a9b24f91-936c-11e4-a9c1-600292148ec2','Allen','Karen','Female',2005),('ab03b60a-936c-11e4-a9c1-600292148ec2','Alvarez','Benjamin','Male',2002),('acb8bfc5-936c-11e4-a9c1-600292148ec2','Alvarez','Joyce','Female',1998),('abbfccda-936c-11e4-a9c1-600292148ec2','Alvarez','Katherine','Female',2001),('aaf06303-936c-11e4-a9c1-600292148ec2','Alvarez','Pamela','Female',2002),('ab1207cb-936c-11e4-a9c1-600292148ec2','Anderson','Ashley','Female',2002),('a9f4a054-936c-11e4-a9c1-600292148ec2','Anderson','Beverly','Female',2003),('ab518be8-936c-11e4-a9c1-600292148ec2','Anderson','Clarence','Male',2001),('ac1ba184-936c-11e4-a9c1-600292148ec2','Anderson','James','Male',1999),('ac844df6-936c-11e4-a9c1-600292148ec2','Anderson','Jeffrey','Male',1998),('ab0a3620-936c-11e4-a9c1-600292148ec2','Anderson','Raymond','Male',2003),('aa114689-936c-11e4-a9c1-600292148ec2','Armstrong','Stephanie','Female',2003),('aa798f2c-936c-11e4-a9c1-600292148ec2','Armstrong','Virginia','Female',2002),('acb7ac32-936c-11e4-a9c1-600292148ec2','Arnold','Craig','Male',2000),('a9bbea3d-936c-11e4-a9c1-600292148ec2','Arnold','Margaret','Female',2003),('aa241eb0-936c-11e4-a9c1-600292148ec2','Austin','Carol','Female',2005),('abd5970f-936c-11e4-a9c1-600292148ec2','Austin','Joan','Female',2001),('aa4157b4-936c-11e4-a9c1-600292148ec2','Austin','Phillip','Male',2003),('ab2255e7-936c-11e4-a9c1-600292148ec2','Bailey','John','Male',2001),('ab83069b-936c-11e4-a9c1-600292148ec2','Bailey','Ralph','Male',2000),('aa7a97d1-936c-11e4-a9c1-600292148ec2','Bailey','Sandra','Female',2003),('ac9d7301-936c-11e4-a9c1-600292148ec2','Baker','Angela','Female',1999),('abdf9bba-936c-11e4-a9c1-600292148ec2','Baker','Ann','Female',2000),('ab4c423d-936c-11e4-a9c1-600292148ec2','Baker','Arthur','Male',2001),('aa71f8f6-936c-11e4-a9c1-600292148ec2','Baker','Janice','Female',2002),('aaca8f69-936c-11e4-a9c1-600292148ec2','Baker','Laura','Female',2001),('aafe24da-936c-11e4-a9c1-600292148ec2','Banks','Marilyn','Female',2002),('ac61b35d-936c-11e4-a9c1-600292148ec2','Banks','Martha','Female',2000),('aa265263-936c-11e4-a9c1-600292148ec2','Banks','Todd','Male',2003),('ab482e12-936c-11e4-a9c1-600292148ec2','Bennett','Arthur','Male',2001),('ac7f16ea-936c-11e4-a9c1-600292148ec2','Bennett','Christine','Female',1998),('ab712532-936c-11e4-a9c1-600292148ec2','Bennett','Tina','Female',2002),('aae5725a-936c-11e4-a9c1-600292148ec2','Bishop','Donna','Female',2001),('a9931ee6-936c-11e4-a9c1-600292148ec2','Bishop','John','Male',2005),('ab36056c-936c-11e4-a9c1-600292148ec2','Black','David','Male',2002),('ac541132-936c-11e4-a9c1-600292148ec2','Black','Theresa','Female',1999),('aa157d69-936c-11e4-a9c1-600292148ec2','Bowman','Linda','Female',2003),('aab7af04-936c-11e4-a9c1-600292148ec2','Boyd','Beverly','Female',2001),('a9ed6461-936c-11e4-a9c1-600292148ec2','Boyd','Bobby','Male',2003),('ab1f0a99-936c-11e4-a9c1-600292148ec2','Boyd','Evelyn','Female',2003),('ab1564af-936c-11e4-a9c1-600292148ec2','Bradley','Jacqueline','Female',2003),('ac36f00b-936c-11e4-a9c1-600292148ec2','Brooks','Arthur','Male',2000),('abde22f6-936c-11e4-a9c1-600292148ec2','Brooks','Marie','Female',1999),('aae45880-936c-11e4-a9c1-600292148ec2','Brown','Jane','Female',2002),('ab9ff798-936c-11e4-a9c1-600292148ec2','Brown','Lillian','Female',2000),('ac0a9396-936c-11e4-a9c1-600292148ec2','Bryant','Amy','Female',2000),('acc7f86c-936c-11e4-a9c1-600292148ec2','Bryant','Denise','Female',1998),('aac97079-936c-11e4-a9c1-600292148ec2','Burke','Kimberly','Female',2003),('acabd6e7-936c-11e4-a9c1-600292148ec2','Burns','Jonathan','Male',2000),('abc61fb9-936c-11e4-a9c1-600292148ec2','Burns','Sharon','Female',2001),('aca570a2-936c-11e4-a9c1-600292148ec2','Campbell','Amy','Female',2000),('ac41dbc9-936c-11e4-a9c1-600292148ec2','Campbell','Edward','Male',2001),('ac034161-936c-11e4-a9c1-600292148ec2','Campbell','Ernest','Male',2001),('aaa8aa6f-936c-11e4-a9c1-600292148ec2','Campbell','Jack','Male',2004),('aca229e5-936c-11e4-a9c1-600292148ec2','Carpenter','Christine','Female',2000),('abe3751e-936c-11e4-a9c1-600292148ec2','Carr','Catherine','Female',2001),('ab791b04-936c-11e4-a9c1-600292148ec2','Carr','Lawrence','Male',2002),('a9e2e013-936c-11e4-a9c1-600292148ec2','Carr','Scott','Male',2003),('ab6382b8-936c-11e4-a9c1-600292148ec2','Carroll','Emily','Female',2001),('abb79188-936c-11e4-a9c1-600292148ec2','Carroll','Jeffrey','Male',2002),('abe24cfd-936c-11e4-a9c1-600292148ec2','Carroll','Joseph','Male',2001),('ab3c56b9-936c-11e4-a9c1-600292148ec2','Carter','Johnny','Male',2003),('aa445e1e-936c-11e4-a9c1-600292148ec2','Carter','Robin','Female',2003),('ab840dc9-936c-11e4-a9c1-600292148ec2','Castillo','James','Male',2001),('abeceff5-936c-11e4-a9c1-600292148ec2','Castillo','Janice','Female',2000),('ab32d33c-936c-11e4-a9c1-600292148ec2','Castillo','Melissa','Female',2002),('a9bf5d5b-936c-11e4-a9c1-600292148ec2','Castillo','Russell','Male',2005),('a9d087cd-936c-11e4-a9c1-600292148ec2','Castillo','Virginia','Female',2005),('a9df6916-936c-11e4-a9c1-600292148ec2','Chapman','Elizabeth','Female',2004),('aba38c45-936c-11e4-a9c1-600292148ec2','Chapman','Ernest','Male',2001),('acb6941f-936c-11e4-a9c1-600292148ec2','Chavez','Norma','Female',1998),('aa1b262f-936c-11e4-a9c1-600292148ec2','Chavez','Steven','Male',2004),('abf160cf-936c-11e4-a9c1-600292148ec2','Clark','Anna','Female',2000),('aa2f646e-936c-11e4-a9c1-600292148ec2','Clark','Randy','Male',2004),('aa3c6aa7-936c-11e4-a9c1-600292148ec2','Cole','Albert','Male',2004),('aafb6725-936c-11e4-a9c1-600292148ec2','Cole','Bonnie','Female',2002),('acb2442a-936c-11e4-a9c1-600292148ec2','Cole','Ralph','Male',1999),('a98e078b-936c-11e4-a9c1-600292148ec2','Coleman','Bruce','Male',2005),('abcc28c0-936c-11e4-a9c1-600292148ec2','Coleman','Gloria','Female',2000),('a9d9756e-936c-11e4-a9c1-600292148ec2','Coleman','Howard','Male',2003),('ac42f1aa-936c-11e4-a9c1-600292148ec2','Coleman','Kevin','Male',2000),('ab6e0a9d-936c-11e4-a9c1-600292148ec2','Collins','Bruce','Male',2001),('a9aa6916-936c-11e4-a9c1-600292148ec2','Collins','Jason','Male',2004),('abb6903e-936c-11e4-a9c1-600292148ec2','Collins','Mark','Male',2001),('ac3fb282-936c-11e4-a9c1-600292148ec2','Collins','Robin','Female',2001),('abe5ade0-936c-11e4-a9c1-600292148ec2','Cook','Jennifer','Female',1999),('aa72f95d-936c-11e4-a9c1-600292148ec2','Cook','Michelle','Female',2003),('ab966194-936c-11e4-a9c1-600292148ec2','Cooper','Louis','Male',2002),('ab18a2a3-936c-11e4-a9c1-600292148ec2','Crawford','Brian','Male',2001),('ab04d44d-936c-11e4-a9c1-600292148ec2','Crawford','Ernest','Male',2002),('ab58be98-936c-11e4-a9c1-600292148ec2','Crawford','Irene','Female',2002),('aaa3abea-936c-11e4-a9c1-600292148ec2','Crawford','Nicole','Female',2002),('a9db763b-936c-11e4-a9c1-600292148ec2','Crawford','Paul','Male',2005),('ac1cad17-936c-11e4-a9c1-600292148ec2','Cruz','Anne','Female',2001),('a9ea6d72-936c-11e4-a9c1-600292148ec2','Cruz','Christopher','Male',2004),('ab4d480b-936c-11e4-a9c1-600292148ec2','Cruz','Marilyn','Female',2002),('aa070975-936c-11e4-a9c1-600292148ec2','Cunningham','Brian','Male',2005),('ab49348a-936c-11e4-a9c1-600292148ec2','Cunningham','Paul','Male',2002),('acc6eba5-936c-11e4-a9c1-600292148ec2','Daniels','Jessica','Female',1999),('acb12b91-936c-11e4-a9c1-600292148ec2','Daniels','Judy','Female',1998),('ac2ad62d-936c-11e4-a9c1-600292148ec2','Daniels','Justin','Male',1999),('a9b678f8-936c-11e4-a9c1-600292148ec2','Daniels','Laura','Female',2003),('ab648f5f-936c-11e4-a9c1-600292148ec2','Daniels','Melissa','Female',2002),('a9ce8b2f-936c-11e4-a9c1-600292148ec2','Daniels','Randy','Male',2005),('ab605eab-936c-11e4-a9c1-600292148ec2','Davis','Cynthia','Female',2000),('aa8c445f-936c-11e4-a9c1-600292148ec2','Davis','Janet','Female',2002),('acde4732-936c-11e4-a9c1-600292148ec2','Davis','Scott','Male',2000),('a9eb668a-936c-11e4-a9c1-600292148ec2','Day','David','Male',2005),('aa2200f3-936c-11e4-a9c1-600292148ec2','Day','Jane','Female',2004),('aa829f6f-936c-11e4-a9c1-600292148ec2','Day','Marilyn','Female',2004),('ab54909c-936c-11e4-a9c1-600292148ec2','Dean','Bobby','Male',2001),('abb4919a-936c-11e4-a9c1-600292148ec2','Dean','Harry','Male',2000),('aa18c4a7-936c-11e4-a9c1-600292148ec2','Dean','Harry','Male',2003),('ac21df4b-936c-11e4-a9c1-600292148ec2','Dean','Kimberly','Female',1999),('abaf66af-936c-11e4-a9c1-600292148ec2','Diaz','Ruby','Female',2001),('a9cc8838-936c-11e4-a9c1-600292148ec2','Dixon','Frances','Female',2004),('a9fcbfca-936c-11e4-a9c1-600292148ec2','Dixon','Keith','Male',2005),('ac440b72-936c-11e4-a9c1-600292148ec2','Dixon','Lisa','Female',2001),('abf479af-936c-11e4-a9c1-600292148ec2','Duncan','Earl','Male',2001),('ac319fb3-936c-11e4-a9c1-600292148ec2','Duncan','Gary','Male',2001),('aa17af3f-936c-11e4-a9c1-600292148ec2','Duncan','Janet','Female',2005),('aa9f7ff8-936c-11e4-a9c1-600292148ec2','Duncan','Julie','Female',2003),('ab9aaca8-936c-11e4-a9c1-600292148ec2','Dunn','Annie','Female',2002),('ac952499-936c-11e4-a9c1-600292148ec2','Edwards','Arthur','Male',1999),('ab1deb03-936c-11e4-a9c1-600292148ec2','Edwards','Brandon','Male',2002),('ab27307f-936c-11e4-a9c1-600292148ec2','Elliott','Betty','Female',2003),('aaa7a42c-936c-11e4-a9c1-600292148ec2','Elliott','Gerald','Male',2002),('abd7b2e5-936c-11e4-a9c1-600292148ec2','Elliott','Jeffrey','Male',1999),('aa276226-936c-11e4-a9c1-600292148ec2','Ellis','Bobby','Male',2004),('ac8cda64-936c-11e4-a9c1-600292148ec2','Ellis','Brenda','Female',1999),('ac71c47b-936c-11e4-a9c1-600292148ec2','Ellis','Chris','Male',2000),('aab39943-936c-11e4-a9c1-600292148ec2','Ellis','Marie','Female',2002),('ac76fbcf-936c-11e4-a9c1-600292148ec2','Evans','Robin','Female',2000),('aaa4ac31-936c-11e4-a9c1-600292148ec2','Ferguson','Kimberly','Female',2004),('abf37045-936c-11e4-a9c1-600292148ec2','Fernandez','Brian','Male',1999),('ac51fe40-936c-11e4-a9c1-600292148ec2','Fernandez','David','Male',1998),('ac3023a8-936c-11e4-a9c1-600292148ec2','Fernandez','Joan','Female',2000),('aa6424d2-936c-11e4-a9c1-600292148ec2','Fields','Mildred','Female',2004),('abc40afa-936c-11e4-a9c1-600292148ec2','Fields','Pamela','Female',2001),('aa74fa84-936c-11e4-a9c1-600292148ec2','Fisher','Sean','Male',2004),('a9f09f51-936c-11e4-a9c1-600292148ec2','Flores','Charles','Male',2005),('ab2d64bd-936c-11e4-a9c1-600292148ec2','Flores','Diane','Female',2003),('aa169503-936c-11e4-a9c1-600292148ec2','Flores','Gary','Male',2005),('aa4a4f6d-936c-11e4-a9c1-600292148ec2','Ford','Kathryn','Female',2004),('aad57b43-936c-11e4-a9c1-600292148ec2','Ford','Phyllis','Female',2001),('aa84b6e5-936c-11e4-a9c1-600292148ec2','Foster','Jimmy','Male',2003),('a9c98c5e-936c-11e4-a9c1-600292148ec2','Foster','Roger','Male',2003),('ac9f9105-936c-11e4-a9c1-600292148ec2','Foster','Scott','Male',1998),('ac25015f-936c-11e4-a9c1-600292148ec2','Fowler','Sarah','Female',2001),('aa9642c9-936c-11e4-a9c1-600292148ec2','Fox','Bobby','Male',2004),('aadeeb8a-936c-11e4-a9c1-600292148ec2','Fox','Chris','Male',2001),('aa296e81-936c-11e4-a9c1-600292148ec2','Fox','Christopher','Male',2005),('aabed62f-936c-11e4-a9c1-600292148ec2','Fox','Joan','Female',2001),('a9d87929-936c-11e4-a9c1-600292148ec2','Fox','Paula','Female',2003),('acbf1c70-936c-11e4-a9c1-600292148ec2','Fox','Susan','Female',1998),('aad885a2-936c-11e4-a9c1-600292148ec2','Franklin','Albert','Male',2001),('ab4a2cfd-936c-11e4-a9c1-600292148ec2','Franklin','Cynthia','Female',2002),('acb35831-936c-11e4-a9c1-600292148ec2','Franklin','Nancy','Female',1999),('aaafb6d3-936c-11e4-a9c1-600292148ec2','Frazier','Paula','Female',2002),('aad788ca-936c-11e4-a9c1-600292148ec2','Fuller','Anna','Female',2002),('ac6bf021-936c-11e4-a9c1-600292148ec2','Fuller','Donald','Male',2000),('aa4d5ddb-936c-11e4-a9c1-600292148ec2','Fuller','Kathy','Female',2002),('ab8e6c29-936c-11e4-a9c1-600292148ec2','Fuller','Victor','Male',2001),('aaf3be75-936c-11e4-a9c1-600292148ec2','Garcia','Ann','Female',2001),('a9dd6bd7-936c-11e4-a9c1-600292148ec2','Garcia','Carolyn','Female',2005),('aaed108b-936c-11e4-a9c1-600292148ec2','Garcia','Debra','Female',2001),('aa1c45bc-936c-11e4-a9c1-600292148ec2','Garcia','Kathleen','Female',2004),('aca9c01a-936c-11e4-a9c1-600292148ec2','Garcia','Pamela','Female',2000),('ab8f46a1-936c-11e4-a9c1-600292148ec2','Garcia','Patricia','Female',2002),('ab559ebb-936c-11e4-a9c1-600292148ec2','Gardner','Betty','Female',2002),('acd7ca20-936c-11e4-a9c1-600292148ec2','Gardner','Paul','Male',1999),('abef368e-936c-11e4-a9c1-600292148ec2','Gardner','Stephen','Male',2001),('abca1da1-936c-11e4-a9c1-600292148ec2','Garrett','Robert','Male',2000),('ab66a86c-936c-11e4-a9c1-600292148ec2','Garrett','Robert','Male',2002),('a9de7040-936c-11e4-a9c1-600292148ec2','Garza','Jesse','Male',2003),('abd489ea-936c-11e4-a9c1-600292148ec2','Gibson','Aaron','Male',1999),('ac666d7b-936c-11e4-a9c1-600292148ec2','Gibson','Angela','Female',2000),('acc4c58f-936c-11e4-a9c1-600292148ec2','Gibson','Bobby','Male',1999),('a9cf8b69-936c-11e4-a9c1-600292148ec2','Gibson','Gloria','Female',2005),('acc02df0-936c-11e4-a9c1-600292148ec2','Gilbert','Christina','Female',1999),('acce77a8-936c-11e4-a9c1-600292148ec2','Gilbert','Jeremy','Male',2000),('ac499d47-936c-11e4-a9c1-600292148ec2','Gilbert','Roger','Male',2000),('ab43c6ca-936c-11e4-a9c1-600292148ec2','Gilbert','Victor','Male',2002),('a9ac9e2f-936c-11e4-a9c1-600292148ec2','Gonzales','Ruby','Female',2003),('aa0d4a40-936c-11e4-a9c1-600292148ec2','Gonzalez','Jack','Male',2005),('aabd7119-936c-11e4-a9c1-600292148ec2','Gordon','Frances','Female',2002),('acc90742-936c-11e4-a9c1-600292148ec2','Graham','Michelle','Female',1999),('aab0c2b7-936c-11e4-a9c1-600292148ec2','Graham','Sharon','Female',2003),('a9f9b615-936c-11e4-a9c1-600292148ec2','Grant','Kelly','Female',2005),('aa376acf-936c-11e4-a9c1-600292148ec2','Gray','Shirley','Female',2002),('aaccd7bc-936c-11e4-a9c1-600292148ec2','Green','Ann','Female',2001),('abe49535-936c-11e4-a9c1-600292148ec2','Green','Henry','Male',2001),('a9aba402-936c-11e4-a9c1-600292148ec2','Green','Paul','Male',2004),('ab1b1d5f-936c-11e4-a9c1-600292148ec2','Green','Rose','Female',2002),('a9ad82e7-936c-11e4-a9c1-600292148ec2','Griffin','Andrew','Male',2003),('aa1f87f9-936c-11e4-a9c1-600292148ec2','Griffin','Billy','Male',2005),('aa8d6359-936c-11e4-a9c1-600292148ec2','Griffin','Russell','Male',2002),('a9a65e8b-936c-11e4-a9c1-600292148ec2','Griffin','Willie','Male',2005),('ac973d1f-936c-11e4-a9c1-600292148ec2','Gutierrez','Howard','Male',1998),('abf04f5c-936c-11e4-a9c1-600292148ec2','Gutierrez','Joyce','Female',1999),('abc90ace-936c-11e4-a9c1-600292148ec2','Gutierrez','Maria','Female',1999),('a9c08498-936c-11e4-a9c1-600292148ec2','Gutierrez','Paula','Female',2003),('aaaeb6dc-936c-11e4-a9c1-600292148ec2','Hall','Joe','Male',2003),('ab10e75f-936c-11e4-a9c1-600292148ec2','Hamilton','Barbara','Female',2003),('ab68bf39-936c-11e4-a9c1-600292148ec2','Hamilton','Jesse','Male',2000),('a9c2ae9f-936c-11e4-a9c1-600292148ec2','Hansen','Kelly','Female',2003),('a9d28d6e-936c-11e4-a9c1-600292148ec2','Harper','Betty','Female',2005),('ac67be6a-936c-11e4-a9c1-600292148ec2','Harris','Mark','Male',1998),('acae01ae-936c-11e4-a9c1-600292148ec2','Harrison','Ernest','Male',1998),('ac3a3205-936c-11e4-a9c1-600292148ec2','Harrison','Roy','Male',2001),('aae122e2-936c-11e4-a9c1-600292148ec2','Hart','Steven','Male',2001),('abe6d601-936c-11e4-a9c1-600292148ec2','Hawkins','Helen','Female',2001),('abfce4fa-936c-11e4-a9c1-600292148ec2','Hawkins','Shirley','Female',1999),('aa909569-936c-11e4-a9c1-600292148ec2','Hayes','Carolyn','Female',2004),('acd5aa16-936c-11e4-a9c1-600292148ec2','Hayes','Linda','Female',1998),('a9f7b24c-936c-11e4-a9c1-600292148ec2','Hayes','Mary','Female',2003),('abc0df3e-936c-11e4-a9c1-600292148ec2','Henderson','Michael','Male',2002),('ab3a37e3-936c-11e4-a9c1-600292148ec2','Henry','Jesse','Male',2001),('ab24f9ac-936c-11e4-a9c1-600292148ec2','Henry','Nancy','Female',2003),('ac562f01-936c-11e4-a9c1-600292148ec2','Hernandez','Joshua','Male',1999),('ac22eabe-936c-11e4-a9c1-600292148ec2','Hernandez','Linda','Female',2000),('ac0008a4-936c-11e4-a9c1-600292148ec2','Hernandez','Shawn','Male',2000),('aca457d8-936c-11e4-a9c1-600292148ec2','Hernandez','William','Male',2000),('ac054dd3-936c-11e4-a9c1-600292148ec2','Hicks','Carolyn','Female',2000),('ab3e971d-936c-11e4-a9c1-600292148ec2','Hicks','Ruth','Female',2001),('a9be3776-936c-11e4-a9c1-600292148ec2','Hicks','Victor','Male',2004),('aacee562-936c-11e4-a9c1-600292148ec2','Hill','Clarence','Male',2001),('acda0143-936c-11e4-a9c1-600292148ec2','Hill','Cynthia','Female',2000),('a9c889ab-936c-11e4-a9c1-600292148ec2','Hill','Helen','Female',2005),('ac50ed69-936c-11e4-a9c1-600292148ec2','Hill','Keith','Male',2000),('aa19e765-936c-11e4-a9c1-600292148ec2','Hill','Theresa','Female',2003),('ac11da6e-936c-11e4-a9c1-600292148ec2','Holmes','Ronald','Male',1999),('abfbd7de-936c-11e4-a9c1-600292148ec2','Holmes','Rose','Female',2001),('ac23f671-936c-11e4-a9c1-600292148ec2','Holmes','Wayne','Male',2001),('aa2c8920-936c-11e4-a9c1-600292148ec2','Howard','Thomas','Male',2003),('ab0eaf85-936c-11e4-a9c1-600292148ec2','Howell','Ernest','Male',2002),('ab616ecb-936c-11e4-a9c1-600292148ec2','Howell','Todd','Male',2000),('abfdf14d-936c-11e4-a9c1-600292148ec2','Hudson','Phillip','Male',2001),('ac3e97af-936c-11e4-a9c1-600292148ec2','Hughes','Nancy','Female',2000),('aae9bc6b-936c-11e4-a9c1-600292148ec2','Hunter','Katherine','Female',2001),('aa4e5b3a-936c-11e4-a9c1-600292148ec2','Hunter','Melissa','Female',2002),('ac8dea3c-936c-11e4-a9c1-600292148ec2','Hunter','Paul','Male',1998),('abe109e1-936c-11e4-a9c1-600292148ec2','Jackson','Chris','Male',1999),('aabaade2-936c-11e4-a9c1-600292148ec2','Jackson','Ernest','Male',2001),('aaff67b8-936c-11e4-a9c1-600292148ec2','Jackson','Fred','Male',2002),('ac1a999e-936c-11e4-a9c1-600292148ec2','Jackson','Harold','Male',2000),('ab2a4fc0-936c-11e4-a9c1-600292148ec2','Jackson','Joseph','Male',2001),('ab9ccda3-936c-11e4-a9c1-600292148ec2','James','Julia','Female',2000),('aa1d733b-936c-11e4-a9c1-600292148ec2','James','Kevin','Male',2003),('ab392c97-936c-11e4-a9c1-600292148ec2','James','Nicole','Female',2002),('acd6b8da-936c-11e4-a9c1-600292148ec2','Jenkins','Matthew','Male',1998),('ac5c79e8-936c-11e4-a9c1-600292148ec2','Jenkins','Raymond','Male',1999),('ab7a4b90-936c-11e4-a9c1-600292148ec2','Jenkins','Willie','Male',2001),('aa782979-936c-11e4-a9c1-600292148ec2','Johnson','Eric','Male',2002),('abc7fd42-936c-11e4-a9c1-600292148ec2','Johnston','Keith','Male',1999),('aa66e942-936c-11e4-a9c1-600292148ec2','Johnston','Lawrence','Male',2003),('ab67b569-936c-11e4-a9c1-600292148ec2','Johnston','Sarah','Female',2002),('a9a8630e-936c-11e4-a9c1-600292148ec2','Johnston','Wanda','Female',2005),('ab4722bd-936c-11e4-a9c1-600292148ec2','Jones','Donald','Male',2000),('aa2534af-936c-11e4-a9c1-600292148ec2','Jones','Jesse','Male',2004),('aba83135-936c-11e4-a9c1-600292148ec2','Jones','Joan','Female',2000),('a9da7a30-936c-11e4-a9c1-600292148ec2','Jordan','Paul','Male',2005),('abcf4c04-936c-11e4-a9c1-600292148ec2','Jordan','Ruth','Female',2001),('abd26c86-936c-11e4-a9c1-600292148ec2','Jordan','Timothy','Male',2001),('abd8bc80-936c-11e4-a9c1-600292148ec2','Kelley','Denise','Female',2001),('aa9c6daa-936c-11e4-a9c1-600292148ec2','Kelly','Andrew','Male',2004),('accb3015-936c-11e4-a9c1-600292148ec2','Kelly','Harold','Male',1998),('ac8ff068-936c-11e4-a9c1-600292148ec2','Kennedy','Andrew','Male',2000),('ab989093-936c-11e4-a9c1-600292148ec2','Kennedy','Carl','Male',2001),('abdad159-936c-11e4-a9c1-600292148ec2','Kennedy','Donna','Female',1999),('ac62da02-936c-11e4-a9c1-600292148ec2','Kennedy','Janet','Female',1999),('abc2fedd-936c-11e4-a9c1-600292148ec2','Kim','Peter','Male',2001),('acdb1601-936c-11e4-a9c1-600292148ec2','King','Christina','Female',1998),('ab42bb8c-936c-11e4-a9c1-600292148ec2','King','Roy','Male',2001),('ac0e0113-936c-11e4-a9c1-600292148ec2','Knight','Alan','Male',2000),('aa4b54e1-936c-11e4-a9c1-600292148ec2','Knight','Christine','Female',2004),('a9ee6a0b-936c-11e4-a9c1-600292148ec2','Knight','Craig','Male',2004),('aa6bd6c7-936c-11e4-a9c1-600292148ec2','Knight','Joan','Female',2002),('ac68cf02-936c-11e4-a9c1-600292148ec2','Knight','Richard','Male',1998),('aac5dbf0-936c-11e4-a9c1-600292148ec2','Lane','Carol','Female',2001),('ac2dedf8-936c-11e4-a9c1-600292148ec2','Lane','Janet','Female',2000),('aac1a929-936c-11e4-a9c1-600292148ec2','Larson','Bruce','Male',2002),('ab3d659c-936c-11e4-a9c1-600292148ec2','Larson','Craig','Male',2003),('aac4750a-936c-11e4-a9c1-600292148ec2','Larson','Ernest','Male',2003),('ac941f12-936c-11e4-a9c1-600292148ec2','Larson','Lori','Female',1998),('ab6ad9ff-936c-11e4-a9c1-600292148ec2','Larson','Martin','Male',2001),('aa8a3751-936c-11e4-a9c1-600292148ec2','Larson','Rachel','Female',2002),('abaa4514-936c-11e4-a9c1-600292148ec2','Larson','Ruth','Female',2002),('ab913a3c-936c-11e4-a9c1-600292148ec2','Lawrence','Walter','Male',2002),('ac5f9d6f-936c-11e4-a9c1-600292148ec2','Lawson','Elizabeth','Female',1999),('ac3b4b62-936c-11e4-a9c1-600292148ec2','Lawson','Janice','Female',2000),('ab0d8b00-936c-11e4-a9c1-600292148ec2','Lawson','John','Male',2002),('ab90296f-936c-11e4-a9c1-600292148ec2','Lee','Craig','Male',2002),('aac70245-936c-11e4-a9c1-600292148ec2','Lee','Earl','Male',2001),('aa4955a1-936c-11e4-a9c1-600292148ec2','Lee','Marie','Female',2004),('ab284072-936c-11e4-a9c1-600292148ec2','Lee','Theresa','Female',2003),('aadad7d2-936c-11e4-a9c1-600292148ec2','Lee','Walter','Male',2002),('aa20b597-936c-11e4-a9c1-600292148ec2','Lewis','Elizabeth','Female',2004),('ac552058-936c-11e4-a9c1-600292148ec2','Lewis','Jesse','Male',1999),('ab20265e-936c-11e4-a9c1-600292148ec2','Lewis','Kathryn','Female',2002),('ac72d7ac-936c-11e4-a9c1-600292148ec2','Long','Billy','Male',1999),('aadbcb4e-936c-11e4-a9c1-600292148ec2','Lopez','Gloria','Female',2002),('ab4b3b20-936c-11e4-a9c1-600292148ec2','Lopez','Irene','Female',2001),('aad33a1e-936c-11e4-a9c1-600292148ec2','Lynch','Harold','Male',2003),('ac07672c-936c-11e4-a9c1-600292148ec2','Lynch','Jeffrey','Male',2001),('ab5e5690-936c-11e4-a9c1-600292148ec2','Lynch','Phyllis','Female',2000),('ac0ff041-936c-11e4-a9c1-600292148ec2','Marshall','Cynthia','Female',1999),('ac1fca18-936c-11e4-a9c1-600292148ec2','Marshall','Nancy','Female',2000),('a9ca8d03-936c-11e4-a9c1-600292148ec2','Martin','Russell','Male',2005),('aa91a39e-936c-11e4-a9c1-600292148ec2','Martinez','Diana','Female',2004),('aa4c5eda-936c-11e4-a9c1-600292148ec2','Martinez','Michael','Male',2003),('ab74e168-936c-11e4-a9c1-600292148ec2','Mason','Jacqueline','Female',2001),('ac9943da-936c-11e4-a9c1-600292148ec2','Mason','Rebecca','Female',1999),('ab419e7d-936c-11e4-a9c1-600292148ec2','Matthews','Anne','Female',2000),('aa1012d5-936c-11e4-a9c1-600292148ec2','Matthews','Michael','Male',2005),('ac32b6f9-936c-11e4-a9c1-600292148ec2','Mccoy','Alan','Male',2000),('ab9ee728-936c-11e4-a9c1-600292148ec2','Mccoy','Annie','Female',2001),('a9d186d8-936c-11e4-a9c1-600292148ec2','Mccoy','Douglas','Male',2003),('ac474843-936c-11e4-a9c1-600292148ec2','Mccoy','Irene','Female',2000),('acbe05be-936c-11e4-a9c1-600292148ec2','Mccoy','Mildred','Female',2000),('aca68045-936c-11e4-a9c1-600292148ec2','Mccoy','Virginia','Female',2000),('aa6ec85d-936c-11e4-a9c1-600292148ec2','Mcdonald','Amanda','Female',2004),('abb8a1d0-936c-11e4-a9c1-600292148ec2','Mcdonald','Jesse','Male',2000),('aa231637-936c-11e4-a9c1-600292148ec2','Mcdonald','Mark','Male',2005),('aa994724-936c-11e4-a9c1-600292148ec2','Mcdonald','Michael','Male',2003),('aa465aab-936c-11e4-a9c1-600292148ec2','Medina','Fred','Male',2004),('aa953a11-936c-11e4-a9c1-600292148ec2','Medina','Theresa','Female',2003),('a9c4d726-936c-11e4-a9c1-600292148ec2','Mendoza','Tina','Female',2004),('a9f2a6be-936c-11e4-a9c1-600292148ec2','Meyer','Janice','Female',2003),('ab659d29-936c-11e4-a9c1-600292148ec2','Meyer','Karen','Female',2000),('a9c5fbc6-936c-11e4-a9c1-600292148ec2','Meyer','Martha','Female',2004),('acd2a3a3-936c-11e4-a9c1-600292148ec2','Meyer','Norma','Female',1999),('ac4aafa6-936c-11e4-a9c1-600292148ec2','Miller','Shawn','Male',2001),('ac8550d2-936c-11e4-a9c1-600292148ec2','Miller','Walter','Male',1998),('abd6a196-936c-11e4-a9c1-600292148ec2','Mills','Jeffrey','Male',2000),('ac022c7f-936c-11e4-a9c1-600292148ec2','Mills','Nancy','Female',2000),('abee147e-936c-11e4-a9c1-600292148ec2','Mitchell','Judy','Female',2001),('aaadbf9c-936c-11e4-a9c1-600292148ec2','Mitchell','Margaret','Female',2004),('ac7a85a8-936c-11e4-a9c1-600292148ec2','Mitchell','Roy','Male',1999),('a9c78bcb-936c-11e4-a9c1-600292148ec2','Montgomery','Daniel','Male',2004),('aaead72d-936c-11e4-a9c1-600292148ec2','Montgomery','Helen','Female',2002),('aa9a4c7a-936c-11e4-a9c1-600292148ec2','Moore','Matthew','Male',2002),('a9ec6a5c-936c-11e4-a9c1-600292148ec2','Moore','Peter','Male',2005),('aa93cbfd-936c-11e4-a9c1-600292148ec2','Morales','Alan','Male',2003),('a9ae6497-936c-11e4-a9c1-600292148ec2','Moreno','Carol','Female',2004),('a9e4e241-936c-11e4-a9c1-600292148ec2','Moreno','Cynthia','Female',2003),('ab6be7bc-936c-11e4-a9c1-600292148ec2','Moreno','Daniel','Male',2001),('aca8acaf-936c-11e4-a9c1-600292148ec2','Moreno','Diana','Female',2000),('aa53d903-936c-11e4-a9c1-600292148ec2','Moreno','Jesse','Male',2004),('accc34d3-936c-11e4-a9c1-600292148ec2','Moreno','Louis','Male',1999),('aacbb3ab-936c-11e4-a9c1-600292148ec2','Moreno','Martin','Male',2003),('aaf5ff8c-936c-11e4-a9c1-600292148ec2','Moreno','Randy','Male',2002),('abc51c6d-936c-11e4-a9c1-600292148ec2','Morgan','Diane','Female',2000),('ab008300-936c-11e4-a9c1-600292148ec2','Morris','Cheryl','Female',2003),('ab5bd4ed-936c-11e4-a9c1-600292148ec2','Morris','Martin','Male',2000),('aa5bf8c1-936c-11e4-a9c1-600292148ec2','Murphy','Bobby','Male',2002),('aa6dccab-936c-11e4-a9c1-600292148ec2','Murphy','Douglas','Male',2003),('aaa9af50-936c-11e4-a9c1-600292148ec2','Murphy','Jimmy','Male',2004),('a9d57924-936c-11e4-a9c1-600292148ec2','Murphy','Nancy','Female',2005),('ac4dd1da-936c-11e4-a9c1-600292148ec2','Murray','Anthony','Male',2000),('ac9c6477-936c-11e4-a9c1-600292148ec2','Murray','Jason','Male',1998),('a998e624-936c-11e4-a9c1-600292148ec2','Murray','Joyce','Female',2004),('ac866d6d-936c-11e4-a9c1-600292148ec2','Myers','Henry','Male',1998),('aad21aac-936c-11e4-a9c1-600292148ec2','Myers','Walter','Male',2001),('a9d77e6c-936c-11e4-a9c1-600292148ec2','Nelson','Jose','Male',2003),('acca1a61-936c-11e4-a9c1-600292148ec2','Nelson','Matthew','Male',2000),('ac889069-936c-11e4-a9c1-600292148ec2','Nelson','Peter','Male',2000),('ac7e0936-936c-11e4-a9c1-600292148ec2','Nguyen','Fred','Male',2000),('abae60dd-936c-11e4-a9c1-600292148ec2','Nguyen','Jonathan','Male',2002),('abf8ad48-936c-11e4-a9c1-600292148ec2','Nguyen','Marie','Female',1999),('ab1451f7-936c-11e4-a9c1-600292148ec2','Nguyen','Mary','Female',2003),('ac2eff04-936c-11e4-a9c1-600292148ec2','Nguyen','Ruby','Female',2000),('ac14a713-936c-11e4-a9c1-600292148ec2','Nguyen','Stephen','Male',2001),('aa7d8e67-936c-11e4-a9c1-600292148ec2','Nichols','Douglas','Male',2003),('aa58e81b-936c-11e4-a9c1-600292148ec2','Nichols','Nancy','Female',2004),('aa80a8cb-936c-11e4-a9c1-600292148ec2','Nichols','Susan','Female',2003),('aa0bee62-936c-11e4-a9c1-600292148ec2','Oliver','Arthur','Male',2005),('aa5af2f3-936c-11e4-a9c1-600292148ec2','Oliver','Eugene','Male',2003),('aa68c8ec-936c-11e4-a9c1-600292148ec2','Olson','Diane','Female',2002),('aac30efe-936c-11e4-a9c1-600292148ec2','Olson','Kenneth','Male',2003),('ab3fa9b7-936c-11e4-a9c1-600292148ec2','Ortiz','Chris','Male',2002),('acaceca8-936c-11e4-a9c1-600292148ec2','Ortiz','Rachel','Female',1998),('aca7971b-936c-11e4-a9c1-600292148ec2','Ortiz','Roger','Male',2000),('aa337a88-936c-11e4-a9c1-600292148ec2','Ortiz','Sean','Male',2004),('abb1739f-936c-11e4-a9c1-600292148ec2','Ortiz','Shawn','Male',2001),('abb06cf6-936c-11e4-a9c1-600292148ec2','Ortiz','Willie','Male',2002),('ac3c61d6-936c-11e4-a9c1-600292148ec2','Owens','Edward','Male',1999),('accf9033-936c-11e4-a9c1-600292148ec2','Owens','Julie','Female',1998),('aaa180f6-936c-11e4-a9c1-600292148ec2','Owens','Ronald','Male',2002),('aa9851c2-936c-11e4-a9c1-600292148ec2','Palmer','Deborah','Female',2003),('abf9b8db-936c-11e4-a9c1-600292148ec2','Palmer','Robin','Female',2001),('ab7b60c3-936c-11e4-a9c1-600292148ec2','Parker','Patrick','Male',2001),('ab627b77-936c-11e4-a9c1-600292148ec2','Payne','Fred','Male',2000),('ab132b25-936c-11e4-a9c1-600292148ec2','Payne','Henry','Male',2002),('aaf824b2-936c-11e4-a9c1-600292148ec2','Payne','Larry','Male',2002),('aa92bd23-936c-11e4-a9c1-600292148ec2','Payne','Mark','Male',2003),('abbbbb20-936c-11e4-a9c1-600292148ec2','Payne','Michelle','Female',2000),('aba27fd2-936c-11e4-a9c1-600292148ec2','Perez','Amy','Female',2000),('aa405812-936c-11e4-a9c1-600292148ec2','Perez','Amy','Female',2003),('aa125c0c-936c-11e4-a9c1-600292148ec2','Perez','Jacqueline','Female',2003),('ab06f98d-936c-11e4-a9c1-600292148ec2','Perez','Nancy','Female',2001),('a9b34d68-936c-11e4-a9c1-600292148ec2','Perkins','Paul','Male',2003),('ac5a5f10-936c-11e4-a9c1-600292148ec2','Perry','Carolyn','Female',2000),('a9fbbea4-936c-11e4-a9c1-600292148ec2','Perry','Stephanie','Female',2003),('ac189b3d-936c-11e4-a9c1-600292148ec2','Perry','Virginia','Female',2000),('aa4f6335-936c-11e4-a9c1-600292148ec2','Peters','Benjamin','Male',2003),('aa70fa21-936c-11e4-a9c1-600292148ec2','Peters','Billy','Male',2002),('acd39785-936c-11e4-a9c1-600292148ec2','Peters','Gerald','Male',1999),('a9f8b6d0-936c-11e4-a9c1-600292148ec2','Peterson','Deborah','Female',2003),('aba60e61-936c-11e4-a9c1-600292148ec2','Peterson','Eugene','Male',2002),('aae00662-936c-11e4-a9c1-600292148ec2','Peterson','Jacqueline','Female',2002),('aa881238-936c-11e4-a9c1-600292148ec2','Peterson','James','Male',2003),('ab2c6547-936c-11e4-a9c1-600292148ec2','Phillips','Arthur','Male',2003),('abfef982-936c-11e4-a9c1-600292148ec2','Phillips','Justin','Male',1999),('acb57eae-936c-11e4-a9c1-600292148ec2','Phillips','Patrick','Male',1998),('abf79b0c-936c-11e4-a9c1-600292148ec2','Pierce','Diana','Female',2000),('ac8bb45f-936c-11e4-a9c1-600292148ec2','Pierce','Lisa','Female',2000),('ac0c0fc5-936c-11e4-a9c1-600292148ec2','Porter','Emily','Female',1999),('ac48644b-936c-11e4-a9c1-600292148ec2','Powell','Kathleen','Female',2001),('aba10a20-936c-11e4-a9c1-600292148ec2','Powell','Patricia','Female',2000),('aabc0e59-936c-11e4-a9c1-600292148ec2','Price','Judith','Female',2001),('aa52d5fa-936c-11e4-a9c1-600292148ec2','Ramirez','Jean','Female',2004),('ab5acf31-936c-11e4-a9c1-600292148ec2','Ramirez','Phillip','Male',2001),('abe91c76-936c-11e4-a9c1-600292148ec2','Ramirez','Richard','Male',2000),('aa3582b1-936c-11e4-a9c1-600292148ec2','Ramirez','Tina','Female',2004),('aa03995a-936c-11e4-a9c1-600292148ec2','Ramos','Lillian','Female',2003),('a9e88f2d-936c-11e4-a9c1-600292148ec2','Ramos','Lori','Female',2003),('ac20d2b0-936c-11e4-a9c1-600292148ec2','Ray','Dennis','Male',1999),('abbebcb1-936c-11e4-a9c1-600292148ec2','Reed','Bruce','Male',2002),('aa8e6b00-936c-11e4-a9c1-600292148ec2','Reed','Carol','Female',2003),('aa0eabfd-936c-11e4-a9c1-600292148ec2','Reed','Dennis','Male',2004),('aaf4d9cf-936c-11e4-a9c1-600292148ec2','Reed','Keith','Male',2001),('ab69cb40-936c-11e4-a9c1-600292148ec2','Reed','Peter','Male',2002),('ab308f49-936c-11e4-a9c1-600292148ec2','Reed','Ronald','Male',2001),('ac178a43-936c-11e4-a9c1-600292148ec2','Reid','Jean','Female',1999),('abea3c10-936c-11e4-a9c1-600292148ec2','Reid','Larry','Male',2000),('abd37eef-936c-11e4-a9c1-600292148ec2','Reid','Rachel','Female',2000),('aa81a057-936c-11e4-a9c1-600292148ec2','Reyes','Louise','Female',2004),('aa7c9014-936c-11e4-a9c1-600292148ec2','Reyes','Tammy','Female',2004),('abfac84d-936c-11e4-a9c1-600292148ec2','Reynolds','Debra','Female',2000),('ac823b11-936c-11e4-a9c1-600292148ec2','Reynolds','Jack','Male',1998),('a9d681e9-936c-11e4-a9c1-600292148ec2','Reynolds','Julie','Female',2003),('aaa6a100-936c-11e4-a9c1-600292148ec2','Reynolds','Walter','Male',2004),('aaa28e7d-936c-11e4-a9c1-600292148ec2','Richards','Robert','Male',2004),('ac8781aa-936c-11e4-a9c1-600292148ec2','Richardson','Joshua','Male',1998),('aaf18575-936c-11e4-a9c1-600292148ec2','Riley','Bruce','Male',2003),('a9a95d76-936c-11e4-a9c1-600292148ec2','Riley','Douglas','Male',2004),('ac5d9451-936c-11e4-a9c1-600292148ec2','Riley','Eugene','Male',1998),('abab4806-936c-11e4-a9c1-600292148ec2','Riley','Joe','Male',2002),('ac4cb49a-936c-11e4-a9c1-600292148ec2','Riley','Kenneth','Male',2000),('ab5cddcc-936c-11e4-a9c1-600292148ec2','Riley','Louise','Female',2001),('ab56a4a4-936c-11e4-a9c1-600292148ec2','Riley','Michael','Male',2000),('ab75ef32-936c-11e4-a9c1-600292148ec2','Rivera','Cheryl','Female',2002),('a9d48064-936c-11e4-a9c1-600292148ec2','Rivera','Kelly','Female',2005),('aafa4589-936c-11e4-a9c1-600292148ec2','Roberts','Albert','Male',2002),('a9b9ba29-936c-11e4-a9c1-600292148ec2','Robinson','Fred','Male',2004),('aafc881b-936c-11e4-a9c1-600292148ec2','Robinson','Joshua','Male',2002),('ac37f9af-936c-11e4-a9c1-600292148ec2','Rodriguez','Barbara','Female',1999),('aa623a47-936c-11e4-a9c1-600292148ec2','Rodriguez','Carolyn','Female',2003),('aa425f07-936c-11e4-a9c1-600292148ec2','Rodriguez','Christine','Female',2004),('a9b461e8-936c-11e4-a9c1-600292148ec2','Rodriguez','Earl','Male',2004),('ac27cb24-936c-11e4-a9c1-600292148ec2','Rodriguez','Wanda','Female',2000),('ab3b4644-936c-11e4-a9c1-600292148ec2','Rogers','Christine','Female',2001),('accd444d-936c-11e4-a9c1-600292148ec2','Rogers','Doris','Female',2000),('aab1c8ad-936c-11e4-a9c1-600292148ec2','Romero','Ruth','Female',2003),('ac6de159-936c-11e4-a9c1-600292148ec2','Rose','Arthur','Male',2000),('ab4617dd-936c-11e4-a9c1-600292148ec2','Rose','Sandra','Female',2001),('ac01189b-936c-11e4-a9c1-600292148ec2','Ross','Gregory','Male',2000),('aa83ac51-936c-11e4-a9c1-600292148ec2','Ross','Joseph','Male',2003),('acd493dc-936c-11e4-a9c1-600292148ec2','Ross','Ralph','Male',1998),('abf269aa-936c-11e4-a9c1-600292148ec2','Ruiz','Christopher','Male',1999),('ac40c91a-936c-11e4-a9c1-600292148ec2','Russell','Catherine','Female',2001),('ac5946ec-936c-11e4-a9c1-600292148ec2','Russell','Cynthia','Female',1999),('ac73ed83-936c-11e4-a9c1-600292148ec2','Russell','Susan','Female',2000),('aa974b41-936c-11e4-a9c1-600292148ec2','Ryan','Jason','Male',2002),('aad0001b-936c-11e4-a9c1-600292148ec2','Ryan','Justin','Male',2002),('acd8e7be-936c-11e4-a9c1-600292148ec2','Ryan','Walter','Male',1998),('a9b04dca-936c-11e4-a9c1-600292148ec2','Sanchez','Beverly','Female',2003),('ac750478-936c-11e4-a9c1-600292148ec2','Sanchez','Catherine','Female',2000),('ab538a01-936c-11e4-a9c1-600292148ec2','Sanchez','Donald','Male',2001),('ab23d5f0-936c-11e4-a9c1-600292148ec2','Sanchez','Janet','Female',2001),('aa6fcccf-936c-11e4-a9c1-600292148ec2','Sanchez','Keith','Male',2004),('aba71c26-936c-11e4-a9c1-600292148ec2','Sanchez','Shawn','Male',2002),('abbdb31b-936c-11e4-a9c1-600292148ec2','Sanders','Carolyn','Female',2000),('abeb5ca9-936c-11e4-a9c1-600292148ec2','Schmidt','Alice','Female',2001),('ac2cd954-936c-11e4-a9c1-600292148ec2','Schmidt','Jessica','Female',2001),('aaee2c8a-936c-11e4-a9c1-600292148ec2','Scott','Kevin','Male',2003),('aa772d08-936c-11e4-a9c1-600292148ec2','Shaw','Carl','Male',2002),('a9cb8e4e-936c-11e4-a9c1-600292148ec2','Shaw','Donald','Male',2005),('aa7e9018-936c-11e4-a9c1-600292148ec2','Shaw','Sharon','Female',2002),('aa3d729e-936c-11e4-a9c1-600292148ec2','Simmons','Christina','Female',2003),('ab33e798-936c-11e4-a9c1-600292148ec2','Simmons','Evelyn','Female',2001),('ab892cb1-936c-11e4-a9c1-600292148ec2','Simpson','Anna','Female',2001),('ab382001-936c-11e4-a9c1-600292148ec2','Simpson','Wayne','Male',2001),('aa51cda5-936c-11e4-a9c1-600292148ec2','Sims','David','Male',2003),('ab9461e4-936c-11e4-a9c1-600292148ec2','Sims','Howard','Male',2001),('aa7f9db5-936c-11e4-a9c1-600292148ec2','Smith','Dorothy','Female',2004),('a9d38743-936c-11e4-a9c1-600292148ec2','Smith','Elizabeth','Female',2004),('ac1ebfdd-936c-11e4-a9c1-600292148ec2','Smith','Jane','Female',2000),('aa613621-936c-11e4-a9c1-600292148ec2','Smith','Robert','Male',2002),('ab9dd51d-936c-11e4-a9c1-600292148ec2','Snyder','Douglas','Male',2000),('ab780e11-936c-11e4-a9c1-600292148ec2','Snyder','Helen','Female',2002),('ab999c6d-936c-11e4-a9c1-600292148ec2','Snyder','Willie','Male',2000),('acbcf571-936c-11e4-a9c1-600292148ec2','Spencer','Andrea','Female',1999),('aad982ca-936c-11e4-a9c1-600292148ec2','Spencer','Joyce','Female',2001),('aaebefe9-936c-11e4-a9c1-600292148ec2','Stanley','Joan','Female',2001),('aa2e60a6-936c-11e4-a9c1-600292148ec2','Stanley','Ryan','Male',2002),('aaef4999-936c-11e4-a9c1-600292148ec2','Stanley','Virginia','Female',2001),('ab8d594d-936c-11e4-a9c1-600292148ec2','Stephens','Carl','Male',2000),('aa86f461-936c-11e4-a9c1-600292148ec2','Stephens','Catherine','Female',2003),('a9dc734d-936c-11e4-a9c1-600292148ec2','Stevens','Carol','Female',2005),('acb46a06-936c-11e4-a9c1-600292148ec2','Stevens','Jerry','Male',2000),('ab450915-936c-11e4-a9c1-600292148ec2','Stevens','Phyllis','Female',2002),('aa56e9f4-936c-11e4-a9c1-600292148ec2','Stewart','Catherine','Female',2004),('ab0fcda0-936c-11e4-a9c1-600292148ec2','Stewart','Marilyn','Female',2003),('ab1c8b09-936c-11e4-a9c1-600292148ec2','Stone','Bonnie','Female',2003),('ac7bbf64-936c-11e4-a9c1-600292148ec2','Stone','Gregory','Male',1998),('ab213c8a-936c-11e4-a9c1-600292148ec2','Stone','Patrick','Male',2002),('aa8f8bb8-936c-11e4-a9c1-600292148ec2','Stone','Ronald','Male',2002),('aaabaeab-936c-11e4-a9c1-600292148ec2','Stone','Sarah','Female',2003),('ac90ff89-936c-11e4-a9c1-600292148ec2','Sullivan','Diana','Female',2000),('ac70afd3-936c-11e4-a9c1-600292148ec2','Sullivan','Jennifer','Female',1999),('ac452598-936c-11e4-a9c1-600292148ec2','Sullivan','Joseph','Male',2000),('aa9d7142-936c-11e4-a9c1-600292148ec2','Taylor','Nicholas','Male',2002),('aca11ad6-936c-11e4-a9c1-600292148ec2','Taylor','Phillip','Male',1998),('ace31b3c-936c-11e4-a9c1-600292148ec2','Taylor','Tammy','Female',2000),('ac834ecc-936c-11e4-a9c1-600292148ec2','Taylor','Tina','Female',2000),('acbbe5c6-936c-11e4-a9c1-600292148ec2','Thomas','Evelyn','Female',1998),('abac4f15-936c-11e4-a9c1-600292148ec2','Thomas','Evelyn','Female',2001),('aaf2aa41-936c-11e4-a9c1-600292148ec2','Thompson','Amanda','Female',2003),('aa327e1b-936c-11e4-a9c1-600292148ec2','Thompson','Anne','Female',2003),('aa3e6a0b-936c-11e4-a9c1-600292148ec2','Thompson','Arthur','Male',2003),('aca340f5-936c-11e4-a9c1-600292148ec2','Thompson','Debra','Female',1998),('aa3a88fc-936c-11e4-a9c1-600292148ec2','Thompson','Joan','Female',2002),('ab6f1a68-936c-11e4-a9c1-600292148ec2','Turner','Douglas','Male',2001),('ab8b5018-936c-11e4-a9c1-600292148ec2','Turner','Gloria','Female',2001),('ac9e7b17-936c-11e4-a9c1-600292148ec2','Turner','Maria','Female',1998),('aa000b68-936c-11e4-a9c1-600292148ec2','Turner','William','Male',2005),('aab49aba-936c-11e4-a9c1-600292148ec2','Vasquez','Amy','Female',2003),('ab7eeb4a-936c-11e4-a9c1-600292148ec2','Vasquez','Jonathan','Male',2000),('ab34f5ed-936c-11e4-a9c1-600292148ec2','Wagner','Anthony','Male',2002),('ac1db2bd-936c-11e4-a9c1-600292148ec2','Wagner','Ernest','Male',2000),('a9f1a0e2-936c-11e4-a9c1-600292148ec2','Wallace','Rebecca','Female',2005),('a9fabccf-936c-11e4-a9c1-600292148ec2','Ward','Aaron','Male',2003),('aa347c3e-936c-11e4-a9c1-600292148ec2','Ward','Mary','Female',2003),('ab57acb1-936c-11e4-a9c1-600292148ec2','Ward','Samuel','Male',2002),('ab7700a0-936c-11e4-a9c1-600292148ec2','Warren','Cynthia','Female',2000),('ace43ce0-936c-11e4-a9c1-600292148ec2','Washington','Kenneth','Male',2000),('ac087371-936c-11e4-a9c1-600292148ec2','Watkins','Scott','Male',2000),('aae33f04-936c-11e4-a9c1-600292148ec2','Watkins','Steven','Male',2003),('ab52919b-936c-11e4-a9c1-600292148ec2','Watson','Alice','Female',2002),('aa5cfb9d-936c-11e4-a9c1-600292148ec2','Watson','Carlos','Male',2003),('aa8b3a62-936c-11e4-a9c1-600292148ec2','Watson','Mary','Female',2004),('aa5f061b-936c-11e4-a9c1-600292148ec2','Watson','Raymond','Male',2002),('abce3d13-936c-11e4-a9c1-600292148ec2','Weaver','Arthur','Male',1999),('ac583330-936c-11e4-a9c1-600292148ec2','Weaver','Ashley','Female',1998),('ab3713db-936c-11e4-a9c1-600292148ec2','Weaver','Gerald','Male',2002),('ab59ca73-936c-11e4-a9c1-600292148ec2','Weaver','Steve','Male',2001),('aa85be88-936c-11e4-a9c1-600292148ec2','Weaver','Susan','Female',2004),('ac0980d5-936c-11e4-a9c1-600292148ec2','Webb','Judy','Female',1999),('aa2b7da7-936c-11e4-a9c1-600292148ec2','Welch','Aaron','Male',2005),('ab2e7255-936c-11e4-a9c1-600292148ec2','Welch','Jason','Male',2002),('aa4858b7-936c-11e4-a9c1-600292148ec2','Welch','Maria','Female',2002),('ace12494-936c-11e4-a9c1-600292148ec2','Wells','Jesse','Male',1999),('a9b79c56-936c-11e4-a9c1-600292148ec2','Wells','Juan','Male',2003),('a9b8ae73-936c-11e4-a9c1-600292148ec2','Wells','Kathryn','Female',2004),('ab8c535b-936c-11e4-a9c1-600292148ec2','Wells','Kathy','Female',2001),('a9fdc3ad-936c-11e4-a9c1-600292148ec2','West','Charles','Male',2003),('aac03e1c-936c-11e4-a9c1-600292148ec2','Wheeler','Joseph','Male',2003),('a9ef7368-936c-11e4-a9c1-600292148ec2','White','Amanda','Female',2004),('ab26122e-936c-11e4-a9c1-600292148ec2','White','Jimmy','Male',2002),('aae68fdd-936c-11e4-a9c1-600292148ec2','Williams','Brenda','Female',2002),('aa891dac-936c-11e4-a9c1-600292148ec2','Williams','John','Male',2002),('ab4f4589-936c-11e4-a9c1-600292148ec2','Williamson','Larry','Male',2002),('ab81f99a-936c-11e4-a9c1-600292148ec2','Williamson','Robin','Female',2002),('ac34ed84-936c-11e4-a9c1-600292148ec2','Williamson','Teresa','Female',2000),('ac64f8c2-936c-11e4-a9c1-600292148ec2','Willis','Albert','Male',1998),('ab5f5929-936c-11e4-a9c1-600292148ec2','Willis','James','Male',2002),('a9f6a9bd-936c-11e4-a9c1-600292148ec2','Willis','Lillian','Female',2004),('ac390b2f-936c-11e4-a9c1-600292148ec2','Wilson','Gloria','Female',1999),('ab6cfdd6-936c-11e4-a9c1-600292148ec2','Wilson','Norma','Female',2000),('ab8a43e0-936c-11e4-a9c1-600292148ec2','Wood','Margaret','Female',2002),('aa9e7738-936c-11e4-a9c1-600292148ec2','Wood','Theresa','Female',2003),('ab2b5ea7-936c-11e4-a9c1-600292148ec2','Woods','Heather','Female',2003),('aaa08029-936c-11e4-a9c1-600292148ec2','Wright','Denise','Female',2004),('ac63ea2b-936c-11e4-a9c1-600292148ec2','Wright','Earl','Male',2000),('acc3b20d-936c-11e4-a9c1-600292148ec2','Wright','James','Male',1998),('ac962ff2-936c-11e4-a9c1-600292148ec2','Wright','Louise','Female',1998),('aa475529-936c-11e4-a9c1-600292148ec2','Wright','Paula','Female',2002),('ab0813a5-936c-11e4-a9c1-600292148ec2','Wright','Raymond','Male',2002),('ab925546-936c-11e4-a9c1-600292148ec2','Wright','Robert','Male',2001),('ac5b6d9a-936c-11e4-a9c1-600292148ec2','Young','Daniel','Male',1998),('ab167b97-936c-11e4-a9c1-600292148ec2','Young','Jessica','Female',2003),('ac29ca95-936c-11e4-a9c1-600292148ec2','Young','Patrick','Male',2000);
/*!40000 ALTER TABLE `student` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `studentcourserel`
--

DROP TABLE IF EXISTS `studentcourserel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `studentcourserel` (
  `StudentPKey` char(36) COLLATE utf8_unicode_ci NOT NULL,
  `CourseName` char(3) COLLATE utf8_unicode_ci NOT NULL,
  `Year` year(4) NOT NULL,
  PRIMARY KEY (`StudentPKey`,`Year`),
  UNIQUE KEY `StudentPKeyCourseNameUNIQUE` (`StudentPKey`,`CourseName`),
  KEY `StudentPKeyINDEX` (`StudentPKey`),
  KEY `CourseNameINDEX` (`CourseName`),
  CONSTRAINT `StudentCourseRel_CoursePKey_FK` FOREIGN KEY (`CourseName`) REFERENCES `courseclassrel` (`CourseName`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `StudentCourseRel_StudentPKey_FK` FOREIGN KEY (`StudentPKey`) REFERENCES `student` (`PKey`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `studentcourserel`
--

LOCK TABLES `studentcourserel` WRITE;
/*!40000 ALTER TABLE `studentcourserel` DISABLE KEYS */;
INSERT INTO `studentcourserel` VALUES ('a98e078b-936c-11e4-a9c1-600292148ec2','05A',2014),('a9931ee6-936c-11e4-a9c1-600292148ec2','05A',2014),('a998e624-936c-11e4-a9c1-600292148ec2','05A',2014),('a9a65e8b-936c-11e4-a9c1-600292148ec2','05A',2014),('a9a8630e-936c-11e4-a9c1-600292148ec2','05A',2014),('a9a95d76-936c-11e4-a9c1-600292148ec2','05A',2014),('a9aa6916-936c-11e4-a9c1-600292148ec2','05A',2014),('a9aba402-936c-11e4-a9c1-600292148ec2','05A',2014),('a9ac9e2f-936c-11e4-a9c1-600292148ec2','05A',2014),('a9ad82e7-936c-11e4-a9c1-600292148ec2','05A',2014),('a9ae6497-936c-11e4-a9c1-600292148ec2','05A',2014),('a9b04dca-936c-11e4-a9c1-600292148ec2','05A',2014),('a9b24f91-936c-11e4-a9c1-600292148ec2','05A',2014),('a9b34d68-936c-11e4-a9c1-600292148ec2','05A',2014),('a9b461e8-936c-11e4-a9c1-600292148ec2','05A',2014),('a9b678f8-936c-11e4-a9c1-600292148ec2','05A',2014),('a9b79c56-936c-11e4-a9c1-600292148ec2','05A',2014),('a9b8ae73-936c-11e4-a9c1-600292148ec2','05A',2014),('a9b9ba29-936c-11e4-a9c1-600292148ec2','05A',2014),('a9bbea3d-936c-11e4-a9c1-600292148ec2','05A',2014),('a9be3776-936c-11e4-a9c1-600292148ec2','05A',2014),('a9bf5d5b-936c-11e4-a9c1-600292148ec2','05A',2014),('a9c08498-936c-11e4-a9c1-600292148ec2','05A',2014),('a9c2ae9f-936c-11e4-a9c1-600292148ec2','05A',2014),('a9c4d726-936c-11e4-a9c1-600292148ec2','05A',2014),('a9c5fbc6-936c-11e4-a9c1-600292148ec2','05B',2014),('a9c78bcb-936c-11e4-a9c1-600292148ec2','05B',2014),('a9c889ab-936c-11e4-a9c1-600292148ec2','05B',2014),('a9c98c5e-936c-11e4-a9c1-600292148ec2','05B',2014),('a9ca8d03-936c-11e4-a9c1-600292148ec2','05B',2014),('a9cb8e4e-936c-11e4-a9c1-600292148ec2','05B',2014),('a9cc8838-936c-11e4-a9c1-600292148ec2','05B',2014),('a9cd87cd-936c-11e4-a9c1-600292148ec2','05B',2014),('a9ce8b2f-936c-11e4-a9c1-600292148ec2','05B',2014),('a9cf8b69-936c-11e4-a9c1-600292148ec2','05B',2014),('a9d087cd-936c-11e4-a9c1-600292148ec2','05B',2014),('a9d186d8-936c-11e4-a9c1-600292148ec2','05B',2014),('a9d28d6e-936c-11e4-a9c1-600292148ec2','05B',2014),('a9d38743-936c-11e4-a9c1-600292148ec2','05B',2014),('a9d48064-936c-11e4-a9c1-600292148ec2','05B',2014),('a9d57924-936c-11e4-a9c1-600292148ec2','05B',2014),('a9d681e9-936c-11e4-a9c1-600292148ec2','05B',2014),('a9d77e6c-936c-11e4-a9c1-600292148ec2','05B',2014),('a9d87929-936c-11e4-a9c1-600292148ec2','05B',2014),('a9d9756e-936c-11e4-a9c1-600292148ec2','05B',2014),('a9da7a30-936c-11e4-a9c1-600292148ec2','05B',2014),('a9db763b-936c-11e4-a9c1-600292148ec2','05B',2014),('a9dc734d-936c-11e4-a9c1-600292148ec2','05B',2014),('a9dd6bd7-936c-11e4-a9c1-600292148ec2','05B',2014),('a9de7040-936c-11e4-a9c1-600292148ec2','05B',2014),('a9df6916-936c-11e4-a9c1-600292148ec2','05C',2014),('a9e2e013-936c-11e4-a9c1-600292148ec2','05C',2014),('a9e4e241-936c-11e4-a9c1-600292148ec2','05C',2014),('a9e88f2d-936c-11e4-a9c1-600292148ec2','05C',2014),('a9ea6d72-936c-11e4-a9c1-600292148ec2','05C',2014),('a9eb668a-936c-11e4-a9c1-600292148ec2','05C',2014),('a9ec6a5c-936c-11e4-a9c1-600292148ec2','05C',2014),('a9ed6461-936c-11e4-a9c1-600292148ec2','05C',2014),('a9ee6a0b-936c-11e4-a9c1-600292148ec2','05C',2014),('a9ef7368-936c-11e4-a9c1-600292148ec2','05C',2014),('a9f09f51-936c-11e4-a9c1-600292148ec2','05C',2014),('a9f1a0e2-936c-11e4-a9c1-600292148ec2','05C',2014),('a9f2a6be-936c-11e4-a9c1-600292148ec2','05C',2014),('a9f4a054-936c-11e4-a9c1-600292148ec2','05C',2014),('a9f5a3be-936c-11e4-a9c1-600292148ec2','05C',2014),('a9f6a9bd-936c-11e4-a9c1-600292148ec2','05C',2014),('a9f7b24c-936c-11e4-a9c1-600292148ec2','05C',2014),('a9f8b6d0-936c-11e4-a9c1-600292148ec2','05C',2014),('a9f9b615-936c-11e4-a9c1-600292148ec2','05C',2014),('a9fabccf-936c-11e4-a9c1-600292148ec2','05C',2014),('a9fbbea4-936c-11e4-a9c1-600292148ec2','05C',2014),('a9fcbfca-936c-11e4-a9c1-600292148ec2','05C',2014),('a9fdc3ad-936c-11e4-a9c1-600292148ec2','05C',2014),('aa000b68-936c-11e4-a9c1-600292148ec2','05C',2014),('aa03995a-936c-11e4-a9c1-600292148ec2','05C',2014),('aa070975-936c-11e4-a9c1-600292148ec2','05D',2014),('aa0bee62-936c-11e4-a9c1-600292148ec2','05D',2014),('aa0d4a40-936c-11e4-a9c1-600292148ec2','05D',2014),('aa0eabfd-936c-11e4-a9c1-600292148ec2','05D',2014),('aa1012d5-936c-11e4-a9c1-600292148ec2','05D',2014),('aa114689-936c-11e4-a9c1-600292148ec2','05D',2014),('aa125c0c-936c-11e4-a9c1-600292148ec2','05D',2014),('aa157d69-936c-11e4-a9c1-600292148ec2','05D',2014),('aa169503-936c-11e4-a9c1-600292148ec2','05D',2014),('aa17af3f-936c-11e4-a9c1-600292148ec2','05D',2014),('aa18c4a7-936c-11e4-a9c1-600292148ec2','05D',2014),('aa19e765-936c-11e4-a9c1-600292148ec2','05D',2014),('aa1b262f-936c-11e4-a9c1-600292148ec2','05D',2014),('aa1c45bc-936c-11e4-a9c1-600292148ec2','05D',2014),('aa1d733b-936c-11e4-a9c1-600292148ec2','05D',2014),('aa1f87f9-936c-11e4-a9c1-600292148ec2','05D',2014),('aa20b597-936c-11e4-a9c1-600292148ec2','05D',2014),('aa2200f3-936c-11e4-a9c1-600292148ec2','05D',2014),('aa231637-936c-11e4-a9c1-600292148ec2','05D',2014),('aa241eb0-936c-11e4-a9c1-600292148ec2','05D',2014),('aa2534af-936c-11e4-a9c1-600292148ec2','05D',2014),('aa265263-936c-11e4-a9c1-600292148ec2','05D',2014),('aa276226-936c-11e4-a9c1-600292148ec2','05D',2014),('aa296e81-936c-11e4-a9c1-600292148ec2','05D',2014),('aa2b7da7-936c-11e4-a9c1-600292148ec2','05D',2014),('aa2c8920-936c-11e4-a9c1-600292148ec2','06A',2014),('aa2e60a6-936c-11e4-a9c1-600292148ec2','06A',2014),('aa2f646e-936c-11e4-a9c1-600292148ec2','06A',2014),('aa327e1b-936c-11e4-a9c1-600292148ec2','06A',2014),('aa337a88-936c-11e4-a9c1-600292148ec2','06A',2014),('aa347c3e-936c-11e4-a9c1-600292148ec2','06A',2014),('aa3582b1-936c-11e4-a9c1-600292148ec2','06A',2014),('aa376acf-936c-11e4-a9c1-600292148ec2','06A',2014),('aa3a88fc-936c-11e4-a9c1-600292148ec2','06A',2014),('aa3c6aa7-936c-11e4-a9c1-600292148ec2','06A',2014),('aa3d729e-936c-11e4-a9c1-600292148ec2','06A',2014),('aa3e6a0b-936c-11e4-a9c1-600292148ec2','06A',2014),('aa405812-936c-11e4-a9c1-600292148ec2','06A',2014),('aa4157b4-936c-11e4-a9c1-600292148ec2','06A',2014),('aa425f07-936c-11e4-a9c1-600292148ec2','06A',2014),('aa445e1e-936c-11e4-a9c1-600292148ec2','06A',2014),('aa465aab-936c-11e4-a9c1-600292148ec2','06A',2014),('aa475529-936c-11e4-a9c1-600292148ec2','06A',2014),('aa4858b7-936c-11e4-a9c1-600292148ec2','06A',2014),('aa4955a1-936c-11e4-a9c1-600292148ec2','06A',2014),('aa4a4f6d-936c-11e4-a9c1-600292148ec2','06A',2014),('aa4b54e1-936c-11e4-a9c1-600292148ec2','06A',2014),('aa4c5eda-936c-11e4-a9c1-600292148ec2','06A',2014),('aa4d5ddb-936c-11e4-a9c1-600292148ec2','06A',2014),('aa4e5b3a-936c-11e4-a9c1-600292148ec2','06A',2014),('aa4f6335-936c-11e4-a9c1-600292148ec2','06B',2014),('aa50d06b-936c-11e4-a9c1-600292148ec2','06B',2014),('aa51cda5-936c-11e4-a9c1-600292148ec2','06B',2014),('aa52d5fa-936c-11e4-a9c1-600292148ec2','06B',2014),('aa53d903-936c-11e4-a9c1-600292148ec2','06B',2014),('aa56e9f4-936c-11e4-a9c1-600292148ec2','06B',2014),('aa58e81b-936c-11e4-a9c1-600292148ec2','06B',2014),('aa5af2f3-936c-11e4-a9c1-600292148ec2','06B',2014),('aa5bf8c1-936c-11e4-a9c1-600292148ec2','06B',2014),('aa5cfb9d-936c-11e4-a9c1-600292148ec2','06B',2014),('aa5f061b-936c-11e4-a9c1-600292148ec2','06B',2014),('aa613621-936c-11e4-a9c1-600292148ec2','06B',2014),('aa623a47-936c-11e4-a9c1-600292148ec2','06B',2014),('aa6424d2-936c-11e4-a9c1-600292148ec2','06B',2014),('aa66e942-936c-11e4-a9c1-600292148ec2','06B',2014),('aa68c8ec-936c-11e4-a9c1-600292148ec2','06B',2014),('aa6bd6c7-936c-11e4-a9c1-600292148ec2','06B',2014),('aa6dccab-936c-11e4-a9c1-600292148ec2','06B',2014),('aa6ec85d-936c-11e4-a9c1-600292148ec2','06B',2014),('aa6fcccf-936c-11e4-a9c1-600292148ec2','06B',2014),('aa70fa21-936c-11e4-a9c1-600292148ec2','06B',2014),('aa71f8f6-936c-11e4-a9c1-600292148ec2','06B',2014),('aa72f95d-936c-11e4-a9c1-600292148ec2','06B',2014),('aa74fa84-936c-11e4-a9c1-600292148ec2','06B',2014),('aa772d08-936c-11e4-a9c1-600292148ec2','06B',2014),('aa782979-936c-11e4-a9c1-600292148ec2','06C',2014),('aa798f2c-936c-11e4-a9c1-600292148ec2','06C',2014),('aa7a97d1-936c-11e4-a9c1-600292148ec2','06C',2014),('aa7c9014-936c-11e4-a9c1-600292148ec2','06C',2014),('aa7d8e67-936c-11e4-a9c1-600292148ec2','06C',2014),('aa7e9018-936c-11e4-a9c1-600292148ec2','06C',2014),('aa7f9db5-936c-11e4-a9c1-600292148ec2','06C',2014),('aa80a8cb-936c-11e4-a9c1-600292148ec2','06C',2014),('aa81a057-936c-11e4-a9c1-600292148ec2','06C',2014),('aa829f6f-936c-11e4-a9c1-600292148ec2','06C',2014),('aa83ac51-936c-11e4-a9c1-600292148ec2','06C',2014),('aa84b6e5-936c-11e4-a9c1-600292148ec2','06C',2014),('aa85be88-936c-11e4-a9c1-600292148ec2','06C',2014),('aa86f461-936c-11e4-a9c1-600292148ec2','06C',2014),('aa881238-936c-11e4-a9c1-600292148ec2','06C',2014),('aa891dac-936c-11e4-a9c1-600292148ec2','06C',2014),('aa8a3751-936c-11e4-a9c1-600292148ec2','06C',2014),('aa8b3a62-936c-11e4-a9c1-600292148ec2','06C',2014),('aa8c445f-936c-11e4-a9c1-600292148ec2','06C',2014),('aa8d6359-936c-11e4-a9c1-600292148ec2','06C',2014),('aa8e6b00-936c-11e4-a9c1-600292148ec2','06C',2014),('aa8f8bb8-936c-11e4-a9c1-600292148ec2','06C',2014),('aa909569-936c-11e4-a9c1-600292148ec2','06C',2014),('aa91a39e-936c-11e4-a9c1-600292148ec2','06C',2014),('aa92bd23-936c-11e4-a9c1-600292148ec2','06C',2014),('aa93cbfd-936c-11e4-a9c1-600292148ec2','06D',2014),('aa953a11-936c-11e4-a9c1-600292148ec2','06D',2014),('aa9642c9-936c-11e4-a9c1-600292148ec2','06D',2014),('aa974b41-936c-11e4-a9c1-600292148ec2','06D',2014),('aa9851c2-936c-11e4-a9c1-600292148ec2','06D',2014),('aa994724-936c-11e4-a9c1-600292148ec2','06D',2014),('aa9a4c7a-936c-11e4-a9c1-600292148ec2','06D',2014),('aa9c6daa-936c-11e4-a9c1-600292148ec2','06D',2014),('aa9d7142-936c-11e4-a9c1-600292148ec2','06D',2014),('aa9e7738-936c-11e4-a9c1-600292148ec2','06D',2014),('aa9f7ff8-936c-11e4-a9c1-600292148ec2','06D',2014),('aaa08029-936c-11e4-a9c1-600292148ec2','06D',2014),('aaa180f6-936c-11e4-a9c1-600292148ec2','06D',2014),('aaa28e7d-936c-11e4-a9c1-600292148ec2','06D',2014),('aaa3abea-936c-11e4-a9c1-600292148ec2','06D',2014),('aaa4ac31-936c-11e4-a9c1-600292148ec2','06D',2014),('aaa6a100-936c-11e4-a9c1-600292148ec2','06D',2014),('aaa7a42c-936c-11e4-a9c1-600292148ec2','06D',2014),('aaa8aa6f-936c-11e4-a9c1-600292148ec2','06D',2014),('aaa9af50-936c-11e4-a9c1-600292148ec2','06D',2014),('aaabaeab-936c-11e4-a9c1-600292148ec2','06D',2014),('aaadbf9c-936c-11e4-a9c1-600292148ec2','06D',2014),('aaaeb6dc-936c-11e4-a9c1-600292148ec2','06D',2014),('aaafb6d3-936c-11e4-a9c1-600292148ec2','06D',2014),('aab0c2b7-936c-11e4-a9c1-600292148ec2','06D',2014),('aab1c8ad-936c-11e4-a9c1-600292148ec2','07A',2014),('aab39943-936c-11e4-a9c1-600292148ec2','07A',2014),('aab49aba-936c-11e4-a9c1-600292148ec2','07A',2014),('aab7af04-936c-11e4-a9c1-600292148ec2','07A',2014),('aabaade2-936c-11e4-a9c1-600292148ec2','07A',2014),('aabc0e59-936c-11e4-a9c1-600292148ec2','07A',2014),('aabd7119-936c-11e4-a9c1-600292148ec2','07A',2014),('aabed62f-936c-11e4-a9c1-600292148ec2','07A',2014),('aac03e1c-936c-11e4-a9c1-600292148ec2','07A',2014),('aac1a929-936c-11e4-a9c1-600292148ec2','07A',2014),('aac30efe-936c-11e4-a9c1-600292148ec2','07A',2014),('aac4750a-936c-11e4-a9c1-600292148ec2','07A',2014),('aac5dbf0-936c-11e4-a9c1-600292148ec2','07A',2014),('aac70245-936c-11e4-a9c1-600292148ec2','07A',2014),('aac97079-936c-11e4-a9c1-600292148ec2','07A',2014),('aaca8f69-936c-11e4-a9c1-600292148ec2','07A',2014),('aacbb3ab-936c-11e4-a9c1-600292148ec2','07A',2014),('aaccd7bc-936c-11e4-a9c1-600292148ec2','07A',2014),('aacee562-936c-11e4-a9c1-600292148ec2','07A',2014),('aad0001b-936c-11e4-a9c1-600292148ec2','07A',2014),('aad21aac-936c-11e4-a9c1-600292148ec2','07A',2014),('aad33a1e-936c-11e4-a9c1-600292148ec2','07A',2014),('aad57b43-936c-11e4-a9c1-600292148ec2','07A',2014),('aad788ca-936c-11e4-a9c1-600292148ec2','07A',2014),('aad885a2-936c-11e4-a9c1-600292148ec2','07A',2014),('aad982ca-936c-11e4-a9c1-600292148ec2','07B',2014),('aadad7d2-936c-11e4-a9c1-600292148ec2','07B',2014),('aadbcb4e-936c-11e4-a9c1-600292148ec2','07B',2014),('aadeeb8a-936c-11e4-a9c1-600292148ec2','07B',2014),('aae00662-936c-11e4-a9c1-600292148ec2','07B',2014),('aae122e2-936c-11e4-a9c1-600292148ec2','07B',2014),('aae33f04-936c-11e4-a9c1-600292148ec2','07B',2014),('aae45880-936c-11e4-a9c1-600292148ec2','07B',2014),('aae5725a-936c-11e4-a9c1-600292148ec2','07B',2014),('aae68fdd-936c-11e4-a9c1-600292148ec2','07B',2014),('aae9bc6b-936c-11e4-a9c1-600292148ec2','07B',2014),('aaead72d-936c-11e4-a9c1-600292148ec2','07B',2014),('aaebefe9-936c-11e4-a9c1-600292148ec2','07B',2014),('aaed108b-936c-11e4-a9c1-600292148ec2','07B',2014),('aaee2c8a-936c-11e4-a9c1-600292148ec2','07B',2014),('aaef4999-936c-11e4-a9c1-600292148ec2','07B',2014),('aaf06303-936c-11e4-a9c1-600292148ec2','07B',2014),('aaf18575-936c-11e4-a9c1-600292148ec2','07B',2014),('aaf2aa41-936c-11e4-a9c1-600292148ec2','07B',2014),('aaf3be75-936c-11e4-a9c1-600292148ec2','07B',2014),('aaf4d9cf-936c-11e4-a9c1-600292148ec2','07B',2014),('aaf5ff8c-936c-11e4-a9c1-600292148ec2','07B',2014),('aaf824b2-936c-11e4-a9c1-600292148ec2','07B',2014),('aafa4589-936c-11e4-a9c1-600292148ec2','07B',2014),('aafb6725-936c-11e4-a9c1-600292148ec2','07B',2014),('aafc881b-936c-11e4-a9c1-600292148ec2','07C',2014),('aafe24da-936c-11e4-a9c1-600292148ec2','07C',2014),('aaff67b8-936c-11e4-a9c1-600292148ec2','07C',2014),('ab008300-936c-11e4-a9c1-600292148ec2','07C',2014),('ab03b60a-936c-11e4-a9c1-600292148ec2','07C',2014),('ab04d44d-936c-11e4-a9c1-600292148ec2','07C',2014),('ab06f98d-936c-11e4-a9c1-600292148ec2','07C',2014),('ab0813a5-936c-11e4-a9c1-600292148ec2','07C',2014),('ab0a3620-936c-11e4-a9c1-600292148ec2','07C',2014),('ab0d8b00-936c-11e4-a9c1-600292148ec2','07C',2014),('ab0eaf85-936c-11e4-a9c1-600292148ec2','07C',2014),('ab0fcda0-936c-11e4-a9c1-600292148ec2','07C',2014),('ab10e75f-936c-11e4-a9c1-600292148ec2','07C',2014),('ab1207cb-936c-11e4-a9c1-600292148ec2','07C',2014),('ab132b25-936c-11e4-a9c1-600292148ec2','07C',2014),('ab1451f7-936c-11e4-a9c1-600292148ec2','07C',2014),('ab1564af-936c-11e4-a9c1-600292148ec2','07C',2014),('ab167b97-936c-11e4-a9c1-600292148ec2','07C',2014),('ab18a2a3-936c-11e4-a9c1-600292148ec2','07C',2014),('ab1b1d5f-936c-11e4-a9c1-600292148ec2','07C',2014),('ab1c8b09-936c-11e4-a9c1-600292148ec2','07C',2014),('ab1deb03-936c-11e4-a9c1-600292148ec2','07C',2014),('ab1f0a99-936c-11e4-a9c1-600292148ec2','07C',2014),('ab20265e-936c-11e4-a9c1-600292148ec2','07C',2014),('ab213c8a-936c-11e4-a9c1-600292148ec2','07C',2014),('ab2255e7-936c-11e4-a9c1-600292148ec2','07D',2014),('ab23d5f0-936c-11e4-a9c1-600292148ec2','07D',2014),('ab24f9ac-936c-11e4-a9c1-600292148ec2','07D',2014),('ab26122e-936c-11e4-a9c1-600292148ec2','07D',2014),('ab27307f-936c-11e4-a9c1-600292148ec2','07D',2014),('ab284072-936c-11e4-a9c1-600292148ec2','07D',2014),('ab2a4fc0-936c-11e4-a9c1-600292148ec2','07D',2014),('ab2b5ea7-936c-11e4-a9c1-600292148ec2','07D',2014),('ab2c6547-936c-11e4-a9c1-600292148ec2','07D',2014),('ab2d64bd-936c-11e4-a9c1-600292148ec2','07D',2014),('ab2e7255-936c-11e4-a9c1-600292148ec2','07D',2014),('ab308f49-936c-11e4-a9c1-600292148ec2','07D',2014),('ab32d33c-936c-11e4-a9c1-600292148ec2','07D',2014),('ab33e798-936c-11e4-a9c1-600292148ec2','07D',2014),('ab34f5ed-936c-11e4-a9c1-600292148ec2','07D',2014),('ab36056c-936c-11e4-a9c1-600292148ec2','07D',2014),('ab3713db-936c-11e4-a9c1-600292148ec2','07D',2014),('ab382001-936c-11e4-a9c1-600292148ec2','07D',2014),('ab392c97-936c-11e4-a9c1-600292148ec2','07D',2014),('ab3a37e3-936c-11e4-a9c1-600292148ec2','07D',2014),('ab3b4644-936c-11e4-a9c1-600292148ec2','07D',2014),('ab3c56b9-936c-11e4-a9c1-600292148ec2','07D',2014),('ab3d659c-936c-11e4-a9c1-600292148ec2','07D',2014),('ab3e971d-936c-11e4-a9c1-600292148ec2','07D',2014),('ab3fa9b7-936c-11e4-a9c1-600292148ec2','08A',2014),('ab419e7d-936c-11e4-a9c1-600292148ec2','08A',2014),('ab42bb8c-936c-11e4-a9c1-600292148ec2','08A',2014),('ab43c6ca-936c-11e4-a9c1-600292148ec2','08A',2014),('ab450915-936c-11e4-a9c1-600292148ec2','08A',2014),('ab4617dd-936c-11e4-a9c1-600292148ec2','08A',2014),('ab4722bd-936c-11e4-a9c1-600292148ec2','08A',2014),('ab482e12-936c-11e4-a9c1-600292148ec2','08A',2014),('ab49348a-936c-11e4-a9c1-600292148ec2','08A',2014),('ab4a2cfd-936c-11e4-a9c1-600292148ec2','08A',2014),('ab4b3b20-936c-11e4-a9c1-600292148ec2','08A',2014),('ab4c423d-936c-11e4-a9c1-600292148ec2','08A',2014),('ab4d480b-936c-11e4-a9c1-600292148ec2','08A',2014),('ab4f4589-936c-11e4-a9c1-600292148ec2','08A',2014),('ab518be8-936c-11e4-a9c1-600292148ec2','08A',2014),('ab52919b-936c-11e4-a9c1-600292148ec2','08A',2014),('ab538a01-936c-11e4-a9c1-600292148ec2','08A',2014),('ab54909c-936c-11e4-a9c1-600292148ec2','08A',2014),('ab559ebb-936c-11e4-a9c1-600292148ec2','08A',2014),('ab56a4a4-936c-11e4-a9c1-600292148ec2','08A',2014),('ab57acb1-936c-11e4-a9c1-600292148ec2','08A',2014),('ab58be98-936c-11e4-a9c1-600292148ec2','08A',2014),('ab59ca73-936c-11e4-a9c1-600292148ec2','08A',2014),('ab5acf31-936c-11e4-a9c1-600292148ec2','08A',2014),('ab5bd4ed-936c-11e4-a9c1-600292148ec2','08A',2014),('ab5cddcc-936c-11e4-a9c1-600292148ec2','08B',2014),('ab5e5690-936c-11e4-a9c1-600292148ec2','08B',2014),('ab5f5929-936c-11e4-a9c1-600292148ec2','08B',2014),('ab605eab-936c-11e4-a9c1-600292148ec2','08B',2014),('ab616ecb-936c-11e4-a9c1-600292148ec2','08B',2014),('ab627b77-936c-11e4-a9c1-600292148ec2','08B',2014),('ab6382b8-936c-11e4-a9c1-600292148ec2','08B',2014),('ab648f5f-936c-11e4-a9c1-600292148ec2','08B',2014),('ab659d29-936c-11e4-a9c1-600292148ec2','08B',2014),('ab66a86c-936c-11e4-a9c1-600292148ec2','08B',2014),('ab67b569-936c-11e4-a9c1-600292148ec2','08B',2014),('ab68bf39-936c-11e4-a9c1-600292148ec2','08B',2014),('ab69cb40-936c-11e4-a9c1-600292148ec2','08B',2014),('ab6ad9ff-936c-11e4-a9c1-600292148ec2','08B',2014),('ab6be7bc-936c-11e4-a9c1-600292148ec2','08B',2014),('ab6cfdd6-936c-11e4-a9c1-600292148ec2','08B',2014),('ab6e0a9d-936c-11e4-a9c1-600292148ec2','08B',2014),('ab6f1a68-936c-11e4-a9c1-600292148ec2','08B',2014),('ab712532-936c-11e4-a9c1-600292148ec2','08B',2014),('ab74e168-936c-11e4-a9c1-600292148ec2','08B',2014),('ab75ef32-936c-11e4-a9c1-600292148ec2','08B',2014),('ab7700a0-936c-11e4-a9c1-600292148ec2','08B',2014),('ab780e11-936c-11e4-a9c1-600292148ec2','08B',2014),('ab791b04-936c-11e4-a9c1-600292148ec2','08B',2014),('ab7a4b90-936c-11e4-a9c1-600292148ec2','08B',2014),('ab7b60c3-936c-11e4-a9c1-600292148ec2','08C',2014),('ab7eeb4a-936c-11e4-a9c1-600292148ec2','08C',2014),('ab81f99a-936c-11e4-a9c1-600292148ec2','08C',2014),('ab83069b-936c-11e4-a9c1-600292148ec2','08C',2014),('ab840dc9-936c-11e4-a9c1-600292148ec2','08C',2014),('ab8515a1-936c-11e4-a9c1-600292148ec2','08C',2014),('ab892cb1-936c-11e4-a9c1-600292148ec2','08C',2014),('ab8a43e0-936c-11e4-a9c1-600292148ec2','08C',2014),('ab8b5018-936c-11e4-a9c1-600292148ec2','08C',2014),('ab8c535b-936c-11e4-a9c1-600292148ec2','08C',2014),('ab8d594d-936c-11e4-a9c1-600292148ec2','08C',2014),('ab8e6c29-936c-11e4-a9c1-600292148ec2','08C',2014),('ab8f46a1-936c-11e4-a9c1-600292148ec2','08C',2014),('ab90296f-936c-11e4-a9c1-600292148ec2','08C',2014),('ab913a3c-936c-11e4-a9c1-600292148ec2','08C',2014),('ab925546-936c-11e4-a9c1-600292148ec2','08C',2014),('ab9461e4-936c-11e4-a9c1-600292148ec2','08C',2014),('ab966194-936c-11e4-a9c1-600292148ec2','08C',2014),('ab989093-936c-11e4-a9c1-600292148ec2','08C',2014),('ab999c6d-936c-11e4-a9c1-600292148ec2','08C',2014),('ab9aaca8-936c-11e4-a9c1-600292148ec2','08C',2014),('ab9ccda3-936c-11e4-a9c1-600292148ec2','08C',2014),('ab9dd51d-936c-11e4-a9c1-600292148ec2','08C',2014),('ab9ee728-936c-11e4-a9c1-600292148ec2','08C',2014),('ab9ff798-936c-11e4-a9c1-600292148ec2','08C',2014),('aba10a20-936c-11e4-a9c1-600292148ec2','08D',2014),('aba27fd2-936c-11e4-a9c1-600292148ec2','08D',2014),('aba38c45-936c-11e4-a9c1-600292148ec2','08D',2014),('aba60e61-936c-11e4-a9c1-600292148ec2','08D',2014),('aba71c26-936c-11e4-a9c1-600292148ec2','08D',2014),('aba83135-936c-11e4-a9c1-600292148ec2','08D',2014),('abaa4514-936c-11e4-a9c1-600292148ec2','08D',2014),('abab4806-936c-11e4-a9c1-600292148ec2','08D',2014),('abac4f15-936c-11e4-a9c1-600292148ec2','08D',2014),('abae60dd-936c-11e4-a9c1-600292148ec2','08D',2014),('abaf66af-936c-11e4-a9c1-600292148ec2','08D',2014),('abb06cf6-936c-11e4-a9c1-600292148ec2','08D',2014),('abb1739f-936c-11e4-a9c1-600292148ec2','08D',2014),('abb4919a-936c-11e4-a9c1-600292148ec2','08D',2014),('abb6903e-936c-11e4-a9c1-600292148ec2','08D',2014),('abb79188-936c-11e4-a9c1-600292148ec2','08D',2014),('abb8a1d0-936c-11e4-a9c1-600292148ec2','08D',2014),('abbbbb20-936c-11e4-a9c1-600292148ec2','08D',2014),('abbdb31b-936c-11e4-a9c1-600292148ec2','08D',2014),('abbebcb1-936c-11e4-a9c1-600292148ec2','08D',2014),('abbfccda-936c-11e4-a9c1-600292148ec2','08D',2014),('abc0df3e-936c-11e4-a9c1-600292148ec2','08D',2014),('abc2fedd-936c-11e4-a9c1-600292148ec2','08D',2014),('abc40afa-936c-11e4-a9c1-600292148ec2','08D',2014),('abc51c6d-936c-11e4-a9c1-600292148ec2','08D',2014),('abc61fb9-936c-11e4-a9c1-600292148ec2','09A',2014),('abc7fd42-936c-11e4-a9c1-600292148ec2','09A',2014),('abc90ace-936c-11e4-a9c1-600292148ec2','09A',2014),('abca1da1-936c-11e4-a9c1-600292148ec2','09A',2014),('abcc28c0-936c-11e4-a9c1-600292148ec2','09A',2014),('abce3d13-936c-11e4-a9c1-600292148ec2','09A',2014),('abcf4c04-936c-11e4-a9c1-600292148ec2','09A',2014),('abd26c86-936c-11e4-a9c1-600292148ec2','09A',2014),('abd37eef-936c-11e4-a9c1-600292148ec2','09A',2014),('abd489ea-936c-11e4-a9c1-600292148ec2','09A',2014),('abd5970f-936c-11e4-a9c1-600292148ec2','09A',2014),('abd6a196-936c-11e4-a9c1-600292148ec2','09A',2014),('abd7b2e5-936c-11e4-a9c1-600292148ec2','09A',2014),('abd8bc80-936c-11e4-a9c1-600292148ec2','09A',2014),('abdad159-936c-11e4-a9c1-600292148ec2','09A',2014),('abde22f6-936c-11e4-a9c1-600292148ec2','09A',2014),('abdf9bba-936c-11e4-a9c1-600292148ec2','09A',2014),('abe109e1-936c-11e4-a9c1-600292148ec2','09A',2014),('abe24cfd-936c-11e4-a9c1-600292148ec2','09A',2014),('abe3751e-936c-11e4-a9c1-600292148ec2','09A',2014),('abe49535-936c-11e4-a9c1-600292148ec2','09A',2014),('abe5ade0-936c-11e4-a9c1-600292148ec2','09A',2014),('abe6d601-936c-11e4-a9c1-600292148ec2','09A',2014),('abe91c76-936c-11e4-a9c1-600292148ec2','09A',2014),('abea3c10-936c-11e4-a9c1-600292148ec2','09A',2014),('abeb5ca9-936c-11e4-a9c1-600292148ec2','09B',2014),('abeceff5-936c-11e4-a9c1-600292148ec2','09B',2014),('abee147e-936c-11e4-a9c1-600292148ec2','09B',2014),('abef368e-936c-11e4-a9c1-600292148ec2','09B',2014),('abf04f5c-936c-11e4-a9c1-600292148ec2','09B',2014),('abf160cf-936c-11e4-a9c1-600292148ec2','09B',2014),('abf269aa-936c-11e4-a9c1-600292148ec2','09B',2014),('abf37045-936c-11e4-a9c1-600292148ec2','09B',2014),('abf479af-936c-11e4-a9c1-600292148ec2','09B',2014),('abf79b0c-936c-11e4-a9c1-600292148ec2','09B',2014),('abf8ad48-936c-11e4-a9c1-600292148ec2','09B',2014),('abf9b8db-936c-11e4-a9c1-600292148ec2','09B',2014),('abfac84d-936c-11e4-a9c1-600292148ec2','09B',2014),('abfbd7de-936c-11e4-a9c1-600292148ec2','09B',2014),('abfce4fa-936c-11e4-a9c1-600292148ec2','09B',2014),('abfdf14d-936c-11e4-a9c1-600292148ec2','09B',2014),('abfef982-936c-11e4-a9c1-600292148ec2','09B',2014),('ac0008a4-936c-11e4-a9c1-600292148ec2','09B',2014),('ac01189b-936c-11e4-a9c1-600292148ec2','09B',2014),('ac022c7f-936c-11e4-a9c1-600292148ec2','09B',2014),('ac034161-936c-11e4-a9c1-600292148ec2','09B',2014),('ac054dd3-936c-11e4-a9c1-600292148ec2','09B',2014),('ac07672c-936c-11e4-a9c1-600292148ec2','09B',2014),('ac087371-936c-11e4-a9c1-600292148ec2','09B',2014),('ac0980d5-936c-11e4-a9c1-600292148ec2','09B',2014),('ac0a9396-936c-11e4-a9c1-600292148ec2','09C',2014),('ac0c0fc5-936c-11e4-a9c1-600292148ec2','09C',2014),('ac0e0113-936c-11e4-a9c1-600292148ec2','09C',2014),('ac0ff041-936c-11e4-a9c1-600292148ec2','09C',2014),('ac11da6e-936c-11e4-a9c1-600292148ec2','09C',2014),('ac14a713-936c-11e4-a9c1-600292148ec2','09C',2014),('ac178a43-936c-11e4-a9c1-600292148ec2','09C',2014),('ac189b3d-936c-11e4-a9c1-600292148ec2','09C',2014),('ac1a999e-936c-11e4-a9c1-600292148ec2','09C',2014),('ac1ba184-936c-11e4-a9c1-600292148ec2','09C',2014),('ac1cad17-936c-11e4-a9c1-600292148ec2','09C',2014),('ac1db2bd-936c-11e4-a9c1-600292148ec2','09C',2014),('ac1ebfdd-936c-11e4-a9c1-600292148ec2','09C',2014),('ac1fca18-936c-11e4-a9c1-600292148ec2','09C',2014),('ac20d2b0-936c-11e4-a9c1-600292148ec2','09C',2014),('ac21df4b-936c-11e4-a9c1-600292148ec2','09C',2014),('ac22eabe-936c-11e4-a9c1-600292148ec2','09C',2014),('ac23f671-936c-11e4-a9c1-600292148ec2','09C',2014),('ac25015f-936c-11e4-a9c1-600292148ec2','09C',2014),('ac27cb24-936c-11e4-a9c1-600292148ec2','09C',2014),('ac29ca95-936c-11e4-a9c1-600292148ec2','09C',2014),('ac2ad62d-936c-11e4-a9c1-600292148ec2','09C',2014),('ac2cd954-936c-11e4-a9c1-600292148ec2','09C',2014),('ac2dedf8-936c-11e4-a9c1-600292148ec2','09C',2014),('ac2eff04-936c-11e4-a9c1-600292148ec2','09C',2014),('ac3023a8-936c-11e4-a9c1-600292148ec2','09D',2014),('ac319fb3-936c-11e4-a9c1-600292148ec2','09D',2014),('ac32b6f9-936c-11e4-a9c1-600292148ec2','09D',2014),('ac33cdf2-936c-11e4-a9c1-600292148ec2','09D',2014),('ac34ed84-936c-11e4-a9c1-600292148ec2','09D',2014),('ac36f00b-936c-11e4-a9c1-600292148ec2','09D',2014),('ac37f9af-936c-11e4-a9c1-600292148ec2','09D',2014),('ac390b2f-936c-11e4-a9c1-600292148ec2','09D',2014),('ac3a3205-936c-11e4-a9c1-600292148ec2','09D',2014),('ac3b4b62-936c-11e4-a9c1-600292148ec2','09D',2014),('ac3c61d6-936c-11e4-a9c1-600292148ec2','09D',2014),('ac3e97af-936c-11e4-a9c1-600292148ec2','09D',2014),('ac3fb282-936c-11e4-a9c1-600292148ec2','09D',2014),('ac40c91a-936c-11e4-a9c1-600292148ec2','09D',2014),('ac41dbc9-936c-11e4-a9c1-600292148ec2','09D',2014),('ac42f1aa-936c-11e4-a9c1-600292148ec2','09D',2014),('ac440b72-936c-11e4-a9c1-600292148ec2','09D',2014),('ac452598-936c-11e4-a9c1-600292148ec2','09D',2014),('ac474843-936c-11e4-a9c1-600292148ec2','09D',2014),('ac48644b-936c-11e4-a9c1-600292148ec2','09D',2014),('ac499d47-936c-11e4-a9c1-600292148ec2','09D',2014),('ac4aafa6-936c-11e4-a9c1-600292148ec2','09D',2014),('ac4cb49a-936c-11e4-a9c1-600292148ec2','09D',2014),('ac4dd1da-936c-11e4-a9c1-600292148ec2','09D',2014),('ac50ed69-936c-11e4-a9c1-600292148ec2','09D',2014),('ac51fe40-936c-11e4-a9c1-600292148ec2','E01',2014),('ac541132-936c-11e4-a9c1-600292148ec2','E01',2014),('ac552058-936c-11e4-a9c1-600292148ec2','E01',2014),('ac562f01-936c-11e4-a9c1-600292148ec2','E01',2014),('ac583330-936c-11e4-a9c1-600292148ec2','E01',2014),('ac5946ec-936c-11e4-a9c1-600292148ec2','E01',2014),('ac5a5f10-936c-11e4-a9c1-600292148ec2','E01',2014),('ac5b6d9a-936c-11e4-a9c1-600292148ec2','E01',2014),('ac5c79e8-936c-11e4-a9c1-600292148ec2','E01',2014),('ac5d9451-936c-11e4-a9c1-600292148ec2','E01',2014),('ac5f9d6f-936c-11e4-a9c1-600292148ec2','E01',2014),('ac61b35d-936c-11e4-a9c1-600292148ec2','E01',2014),('ac62da02-936c-11e4-a9c1-600292148ec2','E01',2014),('ac63ea2b-936c-11e4-a9c1-600292148ec2','E01',2014),('ac64f8c2-936c-11e4-a9c1-600292148ec2','E01',2014),('ac666d7b-936c-11e4-a9c1-600292148ec2','E01',2014),('ac67be6a-936c-11e4-a9c1-600292148ec2','E01',2014),('ac68cf02-936c-11e4-a9c1-600292148ec2','E01',2014),('ac6bf021-936c-11e4-a9c1-600292148ec2','E01',2014),('ac6de159-936c-11e4-a9c1-600292148ec2','E01',2014),('ac70afd3-936c-11e4-a9c1-600292148ec2','E01',2014),('ac71c47b-936c-11e4-a9c1-600292148ec2','E01',2014),('ac72d7ac-936c-11e4-a9c1-600292148ec2','E01',2014),('ac73ed83-936c-11e4-a9c1-600292148ec2','E01',2014),('ac750478-936c-11e4-a9c1-600292148ec2','E01',2014),('ac76fbcf-936c-11e4-a9c1-600292148ec2','E02',2014),('ac7a85a8-936c-11e4-a9c1-600292148ec2','E02',2014),('ac7bbf64-936c-11e4-a9c1-600292148ec2','E02',2014),('ac7e0936-936c-11e4-a9c1-600292148ec2','E02',2014),('ac7f16ea-936c-11e4-a9c1-600292148ec2','E02',2014),('ac823b11-936c-11e4-a9c1-600292148ec2','E02',2014),('ac834ecc-936c-11e4-a9c1-600292148ec2','E02',2014),('ac844df6-936c-11e4-a9c1-600292148ec2','E02',2014),('ac8550d2-936c-11e4-a9c1-600292148ec2','E02',2014),('ac866d6d-936c-11e4-a9c1-600292148ec2','E02',2014),('ac8781aa-936c-11e4-a9c1-600292148ec2','E02',2014),('ac889069-936c-11e4-a9c1-600292148ec2','E02',2014),('ac8bb45f-936c-11e4-a9c1-600292148ec2','E02',2014),('ac8cda64-936c-11e4-a9c1-600292148ec2','E02',2014),('ac8dea3c-936c-11e4-a9c1-600292148ec2','E02',2014),('ac8ff068-936c-11e4-a9c1-600292148ec2','E02',2014),('ac90ff89-936c-11e4-a9c1-600292148ec2','E02',2014),('ac941f12-936c-11e4-a9c1-600292148ec2','E02',2014),('ac952499-936c-11e4-a9c1-600292148ec2','E02',2014),('ac962ff2-936c-11e4-a9c1-600292148ec2','E02',2014),('ac973d1f-936c-11e4-a9c1-600292148ec2','E02',2014),('ac9943da-936c-11e4-a9c1-600292148ec2','E02',2014),('ac9c6477-936c-11e4-a9c1-600292148ec2','E02',2014),('ac9d7301-936c-11e4-a9c1-600292148ec2','E02',2014),('ac9e7b17-936c-11e4-a9c1-600292148ec2','E02',2014),('ac9f9105-936c-11e4-a9c1-600292148ec2','E03',2014),('aca11ad6-936c-11e4-a9c1-600292148ec2','E03',2014),('aca229e5-936c-11e4-a9c1-600292148ec2','E03',2014),('aca340f5-936c-11e4-a9c1-600292148ec2','E03',2014),('aca457d8-936c-11e4-a9c1-600292148ec2','E03',2014),('aca570a2-936c-11e4-a9c1-600292148ec2','E03',2014),('aca68045-936c-11e4-a9c1-600292148ec2','E03',2014),('aca7971b-936c-11e4-a9c1-600292148ec2','E03',2014),('aca8acaf-936c-11e4-a9c1-600292148ec2','E03',2014),('aca9c01a-936c-11e4-a9c1-600292148ec2','E03',2014),('acabd6e7-936c-11e4-a9c1-600292148ec2','E03',2014),('acaceca8-936c-11e4-a9c1-600292148ec2','E03',2014),('acae01ae-936c-11e4-a9c1-600292148ec2','E03',2014),('acb12b91-936c-11e4-a9c1-600292148ec2','E03',2014),('acb2442a-936c-11e4-a9c1-600292148ec2','E03',2014),('acb35831-936c-11e4-a9c1-600292148ec2','E03',2014),('acb46a06-936c-11e4-a9c1-600292148ec2','E03',2014),('acb57eae-936c-11e4-a9c1-600292148ec2','E03',2014),('acb6941f-936c-11e4-a9c1-600292148ec2','E03',2014),('acb7ac32-936c-11e4-a9c1-600292148ec2','E03',2014),('acb8bfc5-936c-11e4-a9c1-600292148ec2','E03',2014),('acbbe5c6-936c-11e4-a9c1-600292148ec2','E03',2014),('acbcf571-936c-11e4-a9c1-600292148ec2','E03',2014),('acbe05be-936c-11e4-a9c1-600292148ec2','E03',2014),('acbf1c70-936c-11e4-a9c1-600292148ec2','E03',2014),('acc02df0-936c-11e4-a9c1-600292148ec2','E04',2014),('acc3b20d-936c-11e4-a9c1-600292148ec2','E04',2014),('acc4c58f-936c-11e4-a9c1-600292148ec2','E04',2014),('acc6eba5-936c-11e4-a9c1-600292148ec2','E04',2014),('acc7f86c-936c-11e4-a9c1-600292148ec2','E04',2014),('acc90742-936c-11e4-a9c1-600292148ec2','E04',2014),('acca1a61-936c-11e4-a9c1-600292148ec2','E04',2014),('accb3015-936c-11e4-a9c1-600292148ec2','E04',2014),('accc34d3-936c-11e4-a9c1-600292148ec2','E04',2014),('accd444d-936c-11e4-a9c1-600292148ec2','E04',2014),('acce77a8-936c-11e4-a9c1-600292148ec2','E04',2014),('accf9033-936c-11e4-a9c1-600292148ec2','E04',2014),('acd2a3a3-936c-11e4-a9c1-600292148ec2','E04',2014),('acd39785-936c-11e4-a9c1-600292148ec2','E04',2014),('acd493dc-936c-11e4-a9c1-600292148ec2','E04',2014),('acd5aa16-936c-11e4-a9c1-600292148ec2','E04',2014),('acd6b8da-936c-11e4-a9c1-600292148ec2','E04',2014),('acd7ca20-936c-11e4-a9c1-600292148ec2','E04',2014),('acd8e7be-936c-11e4-a9c1-600292148ec2','E04',2014),('acda0143-936c-11e4-a9c1-600292148ec2','E04',2014),('acdb1601-936c-11e4-a9c1-600292148ec2','E04',2014),('acde4732-936c-11e4-a9c1-600292148ec2','E04',2014),('ace12494-936c-11e4-a9c1-600292148ec2','E04',2014),('ace31b3c-936c-11e4-a9c1-600292148ec2','E04',2014),('ace43ce0-936c-11e4-a9c1-600292148ec2','E04',2014);
/*!40000 ALTER TABLE `studentcourserel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `traditionaldiscipline`
--

DROP TABLE IF EXISTS `traditionaldiscipline`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `traditionaldiscipline` (
  `PKey` char(36) COLLATE utf8_unicode_ci NOT NULL,
  `Type` enum('Sprint','Jump','Throw','MiddleDistance') COLLATE utf8_unicode_ci NOT NULL,
  `Sex` enum('Male','Female') COLLATE utf8_unicode_ci NOT NULL,
  `Name` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `UnitSymbol` char(1) COLLATE utf8_unicode_ci NOT NULL,
  `Distance` int(4) DEFAULT NULL,
  `Overhead` float(3,2) DEFAULT NULL,
  `ConstantA` float(6,5) NOT NULL,
  `ConstantC` float(7,6) NOT NULL,
  `Measurement` enum('Manual','Electronic') COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`PKey`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `traditionaldiscipline`
--

LOCK TABLES `traditionaldiscipline` WRITE;
/*!40000 ALTER TABLE `traditionaldiscipline` DISABLE KEYS */;
INSERT INTO `traditionaldiscipline` VALUES ('02e7bcb5-fbbf-421e-bad7-d2b3190ed2ca','Sprint','Female','Sprint 100 m','s',100,NULL,4.00620,0.006560,'Electronic'),('0560491e-f326-483b-974f-6d07b967d427','Throw','Male','Kugelstoß','m',NULL,NULL,1.42500,0.003700,NULL),('0a18a585-a888-4993-83a0-342afea368c2','Jump','Male','Hochsprung','m',NULL,NULL,0.84100,0.000800,NULL),('0dcf6e43-e4d3-4dae-8966-8ce805dbb64e','Throw','Female','200-g-Ballwurf','m',NULL,NULL,1.41490,0.010390,NULL),('138b08a4-940c-4633-9537-027a58df115d','Throw','Female','Kugelstoß','m',NULL,NULL,1.27900,0.003980,NULL),('24d9b5dd-3513-416c-a126-349ac2dcb781','Jump','Female','Weitsprung','m',NULL,NULL,1.09350,0.002080,NULL),('25ce654a-68dd-4094-b2b6-737581fb8957','Jump','Male','Weitsprung','m',NULL,NULL,1.15028,0.002190,NULL),('426231f9-6f68-43d2-877f-2760ed6ab068','MiddleDistance','Male','Lauf 3000 m','s',3000,NULL,1.70000,0.005800,NULL),('48742630-8e5b-41d0-934c-f4a58e8227f4','MiddleDistance','Male','Lauf 1000 m','s',1000,NULL,2.15800,0.006000,NULL),('55597498-82e2-4f02-be94-5c766e599935','Throw','Male','200-g-Ballwurf','m',NULL,NULL,1.93600,0.012400,NULL),('587b637d-5e4d-4a2d-bb1c-9641b83a7a08','MiddleDistance','Female','Lauf 3000 m','s',3000,NULL,1.75000,0.005000,NULL),('7205b19a-6036-4dad-a1a1-ccee7ea48584','Sprint','Male','Sprint 75 m','s',75,0.24,4.10000,0.006640,'Manual'),('80927ffb-7f27-11e4-bf87-00249b0f3387','Sprint','Female','Sprint 75 m','s',75,0.24,3.99800,0.006600,'Manual'),('953d6cb3-501b-4a02-99da-f1a86edb636f','Jump','Female','Hochsprung','m',NULL,NULL,0.88070,0.000680,NULL),('99144998-865d-47c7-8d45-552998349254','Sprint','Male','Sprint 75 m','s',75,NULL,4.10000,0.006640,'Electronic'),('9a72a264-7e72-11e4-bf87-00249b0f3387','Sprint','Female','Sprint 50 m','s',50,0.24,3.64800,0.006600,'Manual'),('9f6f0333-b70e-4d55-98c0-67057decbee0','Sprint','Male','Sprint 100 m','s',100,0.24,4.34100,0.006760,'Manual'),('ac62b909-c533-470a-9eb8-744d2b9cc013','Sprint','Male','Sprint 50 m','s',50,0.24,3.79000,0.006900,'Manual'),('b101f80e-cea6-4c81-99f6-1ba5643f6c70','Throw','Female','80-g-Schlagballwurf','m',NULL,NULL,2.02320,0.008740,NULL),('b16745e2-bbba-4346-8d49-7d9d65e7ecd6','Sprint','Male','Sprint 50 m','s',50,NULL,3.79000,0.006900,'Electronic'),('b68cb942-8826-4938-abce-9b1bf2cee550','Sprint','Female','Sprint 75 m','s',75,NULL,3.99800,0.006600,'Electronic'),('b82a9905-cc00-40a8-87af-0d94b1f72cda','Throw','Male','80-g-Schlagballwurf','m',NULL,NULL,2.80000,0.011000,NULL),('bb4fdf4d-e832-491c-aa62-af0e693155d5','Throw','Female','Schleuderball','m',NULL,NULL,1.08500,0.009210,NULL),('bfe57845-d9d2-4d33-9ca9-d8ac82d1dca6','MiddleDistance','Female','Lauf 800 m','s',800,NULL,2.02320,0.006470,NULL),('c3300949-30fe-41a5-84bc-46ae791bf062','Sprint','Male','Sprint 100 m','s',100,NULL,4.34100,0.006760,'Electronic'),('cb418b3b-3293-43f2-9a28-d6acfef81734','MiddleDistance','Male','Lauf 2000 m','s',2000,NULL,1.78400,0.006000,NULL),('cd48a79b-4ded-4de1-badb-795dd7a2c5dd','Sprint','Female','Sprint 100 m','s',100,0.24,4.00620,0.006560,'Manual'),('cfaccaf6-10c9-42b4-9c4e-fc53d59b09ad','Sprint','Female','Sprint 50 m','s',50,NULL,3.64800,0.006600,'Electronic'),('e000cca7-8ab0-4c5c-bf15-c2fef424efd6','Throw','Male','Schleuderball','m',NULL,NULL,1.59500,0.009125,NULL),('fc40a2c0-46cc-42d6-bd56-f11e7f4954d1','MiddleDistance','Female','Lauf 2000 m','s',2000,NULL,1.80000,0.005400,NULL);
/*!40000 ALTER TABLE `traditionaldiscipline` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `traditionaldisciplinecollection`
--

DROP TABLE IF EXISTS `traditionaldisciplinecollection`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `traditionaldisciplinecollection` (
  `PKey` char(36) COLLATE utf8_unicode_ci NOT NULL,
  `MaleSprintPKey` char(36) COLLATE utf8_unicode_ci NOT NULL,
  `MaleJumpPKey` char(36) COLLATE utf8_unicode_ci NOT NULL,
  `MaleThrowPKey` char(36) COLLATE utf8_unicode_ci NOT NULL,
  `MaleMiddleDistancePKey` char(36) COLLATE utf8_unicode_ci NOT NULL,
  `FemaleSprintPKey` char(36) COLLATE utf8_unicode_ci NOT NULL,
  `FemaleJumpPKey` char(36) COLLATE utf8_unicode_ci NOT NULL,
  `FemaleThrowPKey` char(36) COLLATE utf8_unicode_ci NOT NULL,
  `FemaleMiddleDistancePKey` char(36) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`PKey`),
  KEY `TraditionalDisciplineCollection_MaleSprintPKey_FK` (`MaleSprintPKey`),
  KEY `TraditionalDisciplineCollection_MaleJumpPKey_FK` (`MaleJumpPKey`),
  KEY `TraditionalDisciplineCollection_MaleThrowPKey_FK` (`MaleThrowPKey`),
  KEY `TraditionalDisciplineCollection_MaleMiddleDistancePKey_FK` (`MaleMiddleDistancePKey`),
  KEY `TraditionalDisciplineCollection_FemaleSprintPKey_FK` (`FemaleSprintPKey`),
  KEY `TraditionalDisciplineCollection_FemaleJumpPKey_FK` (`FemaleJumpPKey`),
  KEY `TraditionalDisciplineCollection_FemaleThrowPKey_FK` (`FemaleThrowPKey`),
  KEY `TraditionalDisciplineCollection_FemaleMiddleDistancePKey_FK` (`FemaleMiddleDistancePKey`),
  CONSTRAINT `TraditionalDisciplineCollection_FemaleJumpPKey_FK` FOREIGN KEY (`FemaleJumpPKey`) REFERENCES `traditionaldiscipline` (`PKey`),
  CONSTRAINT `TraditionalDisciplineCollection_FemaleMiddleDistancePKey_FK` FOREIGN KEY (`FemaleMiddleDistancePKey`) REFERENCES `traditionaldiscipline` (`PKey`),
  CONSTRAINT `TraditionalDisciplineCollection_FemaleSprintPKey_FK` FOREIGN KEY (`FemaleSprintPKey`) REFERENCES `traditionaldiscipline` (`PKey`),
  CONSTRAINT `TraditionalDisciplineCollection_FemaleThrowPKey_FK` FOREIGN KEY (`FemaleThrowPKey`) REFERENCES `traditionaldiscipline` (`PKey`),
  CONSTRAINT `TraditionalDisciplineCollection_MaleJumpPKey_FK` FOREIGN KEY (`MaleJumpPKey`) REFERENCES `traditionaldiscipline` (`PKey`),
  CONSTRAINT `TraditionalDisciplineCollection_MaleMiddleDistancePKey_FK` FOREIGN KEY (`MaleMiddleDistancePKey`) REFERENCES `traditionaldiscipline` (`PKey`),
  CONSTRAINT `TraditionalDisciplineCollection_MaleSprintPKey_FK` FOREIGN KEY (`MaleSprintPKey`) REFERENCES `traditionaldiscipline` (`PKey`),
  CONSTRAINT `TraditionalDisciplineCollection_MaleThrowPKey_FK` FOREIGN KEY (`MaleThrowPKey`) REFERENCES `traditionaldiscipline` (`PKey`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `traditionaldisciplinecollection`
--

LOCK TABLES `traditionaldisciplinecollection` WRITE;
/*!40000 ALTER TABLE `traditionaldisciplinecollection` DISABLE KEYS */;
/*!40000 ALTER TABLE `traditionaldisciplinecollection` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary table structure for view `traditionalfemalejumpdisciplines`
--

DROP TABLE IF EXISTS `traditionalfemalejumpdisciplines`;
/*!50001 DROP VIEW IF EXISTS `traditionalfemalejumpdisciplines`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE TABLE `traditionalfemalejumpdisciplines` (
  `PKey` tinyint NOT NULL,
  `Name` tinyint NOT NULL
) ENGINE=MyISAM */;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `traditionalfemalemiddledistancedisciplines`
--

DROP TABLE IF EXISTS `traditionalfemalemiddledistancedisciplines`;
/*!50001 DROP VIEW IF EXISTS `traditionalfemalemiddledistancedisciplines`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE TABLE `traditionalfemalemiddledistancedisciplines` (
  `PKey` tinyint NOT NULL,
  `Name` tinyint NOT NULL
) ENGINE=MyISAM */;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `traditionalfemalesprintdisciplines`
--

DROP TABLE IF EXISTS `traditionalfemalesprintdisciplines`;
/*!50001 DROP VIEW IF EXISTS `traditionalfemalesprintdisciplines`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE TABLE `traditionalfemalesprintdisciplines` (
  `PKey` tinyint NOT NULL,
  `Name` tinyint NOT NULL,
  `Measurement` tinyint NOT NULL
) ENGINE=MyISAM */;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `traditionalfemalethrowdisciplines`
--

DROP TABLE IF EXISTS `traditionalfemalethrowdisciplines`;
/*!50001 DROP VIEW IF EXISTS `traditionalfemalethrowdisciplines`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE TABLE `traditionalfemalethrowdisciplines` (
  `PKey` tinyint NOT NULL,
  `Name` tinyint NOT NULL
) ENGINE=MyISAM */;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `traditionalmalejumpdisciplines`
--

DROP TABLE IF EXISTS `traditionalmalejumpdisciplines`;
/*!50001 DROP VIEW IF EXISTS `traditionalmalejumpdisciplines`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE TABLE `traditionalmalejumpdisciplines` (
  `PKey` tinyint NOT NULL,
  `Name` tinyint NOT NULL
) ENGINE=MyISAM */;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `traditionalmalemiddledistancedisciplines`
--

DROP TABLE IF EXISTS `traditionalmalemiddledistancedisciplines`;
/*!50001 DROP VIEW IF EXISTS `traditionalmalemiddledistancedisciplines`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE TABLE `traditionalmalemiddledistancedisciplines` (
  `PKey` tinyint NOT NULL,
  `Name` tinyint NOT NULL
) ENGINE=MyISAM */;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `traditionalmalesprintdisciplines`
--

DROP TABLE IF EXISTS `traditionalmalesprintdisciplines`;
/*!50001 DROP VIEW IF EXISTS `traditionalmalesprintdisciplines`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE TABLE `traditionalmalesprintdisciplines` (
  `PKey` tinyint NOT NULL,
  `Name` tinyint NOT NULL,
  `Measurement` tinyint NOT NULL
) ENGINE=MyISAM */;
SET character_set_client = @saved_cs_client;

--
-- Temporary table structure for view `traditionalmalethrowdisciplines`
--

DROP TABLE IF EXISTS `traditionalmalethrowdisciplines`;
/*!50001 DROP VIEW IF EXISTS `traditionalmalethrowdisciplines`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE TABLE `traditionalmalethrowdisciplines` (
  `PKey` tinyint NOT NULL,
  `Name` tinyint NOT NULL
) ENGINE=MyISAM */;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `traditionalreportmeta`
--

DROP TABLE IF EXISTS `traditionalreportmeta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `traditionalreportmeta` (
  `PKey` char(36) COLLATE utf8_unicode_ci NOT NULL,
  `Sex` enum('Male','Female') COLLATE utf8_unicode_ci NOT NULL,
  `Age` int(2) unsigned zerofill NOT NULL,
  `HonoraryCertificateScore` int(4) NOT NULL,
  `VictoryCertificateScore` int(4) NOT NULL,
  PRIMARY KEY (`PKey`),
  UNIQUE KEY `SexAgeUNIQUE` (`Sex`,`Age`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `traditionalreportmeta`
--

LOCK TABLES `traditionalreportmeta` WRITE;
/*!40000 ALTER TABLE `traditionalreportmeta` DISABLE KEYS */;
INSERT INTO `traditionalreportmeta` VALUES ('13c6c0d2-76f1-49b1-9ee3-146aef697b68','Male',17,1400,1125),('1ebc5e7d-ec86-4dcf-81c8-1a7e221a975b','Male',10,775,600),('2d859676-dd11-4265-8988-1dfa8d1fc966','Male',19,1550,1275),('40d2abbb-9f4e-4651-a87c-afbd481cd165','Female',11,900,700),('47e90afd-953c-4ebf-ab17-834d2ca26467','Male',13,1050,825),('4e2a0780-51cf-440a-b5aa-ca69b6b26b9f','Female',18,1150,950),('6d415c15-2a06-47b8-819e-fdc61a5c988b','Male',12,975,750),('7143df0f-9211-4238-b1d2-aa3f6957bbc0','Female',13,1025,825),('7bfa22c2-d48a-4c91-a946-a4dbb33f32cc','Female',15,1075,875),('8289c7bc-960a-4bc0-8bef-a06dbee80459','Female',08,625,475),('8ad75e1d-da87-4d74-8c31-2aad5e78ca84','Male',11,875,675),('9bea4fb4-ba32-4c7f-9b7b-a003825b7471','Male',15,1225,975),('a12347d4-0b50-4682-ba0f-e59d92945bf0','Female',17,1125,925),('a2d5fb6b-13da-453f-ac3b-d92d1895e708','Male',14,1125,900),('b0380ba0-0084-4fa8-b4d2-66ceb47f7de3','Male',08,575,450),('c014bbc4-71f7-426d-a689-263d5569141f','Male',18,1475,1200),('c02347fd-b640-4841-b1c2-2b0b6e52fdd9','Female',16,1100,900),('cc927219-030c-4a03-98d6-eaaffce5959a','Female',14,1050,850),('d895f448-ec5b-49cc-b56f-8ac716f18945','Male',16,1325,1050),('dd634026-f207-4833-ad33-7e21f36cf7ee','Female',12,975,775),('e12ca7bb-bc8a-4c94-9dbc-001a7b2ad59f','Female',10,825,625),('e97eb114-c7b2-4c3e-9044-99bb04897824','Male',09,675,525),('fc1b97e0-2946-4b85-a2a9-ae864ef8adf7','Female',09,725,550);
/*!40000 ALTER TABLE `traditionalreportmeta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary table structure for view `validyears`
--

DROP TABLE IF EXISTS `validyears`;
/*!50001 DROP VIEW IF EXISTS `validyears`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE TABLE `validyears` (
  `year` tinyint NOT NULL
) ENGINE=MyISAM */;
SET character_set_client = @saved_cs_client;

--
-- Dumping events for database 'honglorn'
--

--
-- Dumping routines for database 'honglorn'
--
/*!50003 DROP FUNCTION IF EXISTS `ClassExists` */;
ALTER DATABASE `honglorn` CHARACTER SET utf8 COLLATE utf8_general_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `ClassExists`(`cClassName` CHAR(1) CHARSET utf8) RETURNS tinyint(1)
    READS SQL DATA
BEGIN



RETURN EXISTS(

  SELECT

    NULL

  FROM

    Class

  WHERE

    ClassName = cClassName COLLATE utf8_unicode_ci

  );



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
ALTER DATABASE `honglorn` CHARACTER SET utf8 COLLATE utf8_unicode_ci ;
/*!50003 DROP FUNCTION IF EXISTS `CourseExists` */;
ALTER DATABASE `honglorn` CHARACTER SET utf8 COLLATE utf8_general_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `CourseExists`(`cCourseName` CHAR(3) CHARSET utf8) RETURNS tinyint(1)
    READS SQL DATA
BEGIN



RETURN EXISTS(

  SELECT

    NULL

  FROM

    CourseClassRel

  WHERE

    CourseName = cCourseName COLLATE utf8_unicode_ci

  );



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
ALTER DATABASE `honglorn` CHARACTER SET utf8 COLLATE utf8_unicode_ci ;
/*!50003 DROP FUNCTION IF EXISTS `DisciplineMetaExists` */;
ALTER DATABASE `honglorn` CHARACTER SET utf8 COLLATE utf8_general_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `DisciplineMetaExists`(`cClassName` CHAR(1) CHARSET utf8, `yYear` Year(4)) RETURNS tinyint(1)
    READS SQL DATA
BEGIN



RETURN EXISTS(select null from ClassDisciplineMeta where ClassName = cClassName COLLATE utf8_unicode_ci AND `Year` = yYear);



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
ALTER DATABASE `honglorn` CHARACTER SET utf8 COLLATE utf8_unicode_ci ;
/*!50003 DROP FUNCTION IF EXISTS `GetClassPKey` */;
ALTER DATABASE `honglorn` CHARACTER SET utf8 COLLATE utf8_general_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `GetClassPKey`(cClassName CHAR(3) CHARSET utf8) RETURNS char(36) CHARSET utf8
    READS SQL DATA
BEGIN

RETURN (select PKey from Class where ClassName = cClassName COLLATE utf8_unicode_ci);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
ALTER DATABASE `honglorn` CHARACTER SET utf8 COLLATE utf8_unicode_ci ;
/*!50003 DROP FUNCTION IF EXISTS `GetCoursePKey` */;
ALTER DATABASE `honglorn` CHARACTER SET utf8 COLLATE utf8_general_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `GetCoursePKey`(cCourseName CHAR(3) CHARSET utf8) RETURNS char(36) CHARSET utf8
    READS SQL DATA
BEGIN



RETURN (select PKey from Course where CourseName = cCourseName COLLATE utf8_unicode_ci);



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
ALTER DATABASE `honglorn` CHARACTER SET utf8 COLLATE utf8_unicode_ci ;
/*!50003 DROP FUNCTION IF EXISTS `GetGameType` */;
ALTER DATABASE `honglorn` CHARACTER SET utf8 COLLATE utf8_general_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `GetGameType`(`cClassName` CHAR(1) CHARSET utf8, `yYear` YEAR(4)) RETURNS enum('Competition','Traditional') CHARSET utf8
    READS SQL DATA
BEGIN



RETURN (

  SELECT

    GameType

  FROM

    DisciplineMeta INNER JOIN Class ON DisciplineMeta.ClassPKey = Class.PKey

  WHERE

    Class.ClassName = cClassName COLLATE utf8_unicode_ci

    AND DisciplineMeta.`Year` = yYear

  );



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
ALTER DATABASE `honglorn` CHARACTER SET utf8 COLLATE utf8_unicode_ci ;
/*!50003 DROP FUNCTION IF EXISTS `GetStudentPKey` */;
ALTER DATABASE `honglorn` CHARACTER SET utf8 COLLATE utf8_general_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `GetStudentPKey`(sSurname VARCHAR(45) CHARSET utf8, sForename VARCHAR(45) CHARSET utf8, eSex ENUM('Male','Female') CHARSET utf8, yYearOfBirth YEAR(4)) RETURNS char(36) CHARSET utf8
    READS SQL DATA
BEGIN



RETURN (select PKey from Student where Surname = sSurname COLLATE utf8_unicode_ci and Forename = sForename COLLATE utf8_unicode_ci and Sex = eSex COLLATE utf8_unicode_ci and YearOfBirth = yYearOfBirth);



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
ALTER DATABASE `honglorn` CHARACTER SET utf8 COLLATE utf8_unicode_ci ;
/*!50003 DROP FUNCTION IF EXISTS `IsValidCompetitionDiscipline` */;
ALTER DATABASE `honglorn` CHARACTER SET utf8 COLLATE utf8_general_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `IsValidCompetitionDiscipline`(cPKey CHAR(36) CHARSET utf8, eType ENUM('Sprint','Jump','Throw','MiddleDistance')) RETURNS tinyint(1)
    READS SQL DATA
BEGIN

RETURN exists(select null from CompetitionDiscipline
				where PKey = cPKey COLLATE utf8_unicode_ci
				AND Type = eType);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
ALTER DATABASE `honglorn` CHARACTER SET utf8 COLLATE utf8_unicode_ci ;
/*!50003 DROP FUNCTION IF EXISTS `IsValidDisciplineMeta` */;
ALTER DATABASE `honglorn` CHARACTER SET utf8 COLLATE utf8_general_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
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

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
ALTER DATABASE `honglorn` CHARACTER SET utf8 COLLATE utf8_unicode_ci ;
/*!50003 DROP FUNCTION IF EXISTS `IsValidTraditionalDiscipline` */;
ALTER DATABASE `honglorn` CHARACTER SET utf8 COLLATE utf8_general_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `IsValidTraditionalDiscipline`(cPKey CHAR(36) CHARSET utf8, eSex ENUM('Male','Female'), eType ENUM('Sprint','Jump','Throw','MiddleDistance')) RETURNS tinyint(1)
    READS SQL DATA
BEGIN

RETURN exists(select null from TraditionalDiscipline
				where PKey = cPKey COLLATE utf8_unicode_ci
				AND Type = eType
                AND Sex = eSex);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
ALTER DATABASE `honglorn` CHARACTER SET utf8 COLLATE utf8_unicode_ci ;
/*!50003 DROP FUNCTION IF EXISTS `StudentCourseRelExists` */;
ALTER DATABASE `honglorn` CHARACTER SET utf8 COLLATE utf8_general_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `StudentCourseRelExists`(cStudentPKey CHAR(36) CHARSET utf8, yYear YEAR(4)) RETURNS tinyint(1)
    READS SQL DATA
BEGIN



RETURN exists(select null from StudentCourseRel where StudentPKey = cStudentPKey COLLATE utf8_unicode_ci and `Year` = yYear);



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
ALTER DATABASE `honglorn` CHARACTER SET utf8 COLLATE utf8_unicode_ci ;
/*!50003 DROP FUNCTION IF EXISTS `StudentExists` */;
ALTER DATABASE `honglorn` CHARACTER SET utf8 COLLATE utf8_general_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `StudentExists`(`sSurname` VARCHAR(45) CHARSET utf8, `sForename` VARCHAR(45) CHARSET utf8, `eSex` ENUM('Male','Female') CHARSET utf8, `yYearOfBirth` YEAR(4)) RETURNS tinyint(1)
    READS SQL DATA
BEGIN



RETURN exists(SELECT null from Student where Surname = sSurname COLLATE utf8_unicode_ci and Forename = sForename COLLATE utf8_unicode_ci and Sex = eSex COLLATE utf8_unicode_ci and YearOfBirth = yYearOfBirth);



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
ALTER DATABASE `honglorn` CHARACTER SET utf8 COLLATE utf8_unicode_ci ;
/*!50003 DROP PROCEDURE IF EXISTS `EnterCompetitionValues` */;
ALTER DATABASE `honglorn` CHARACTER SET utf8 COLLATE utf8_general_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `EnterCompetitionValues`(IN `cPKey` CHAR(36), IN `yYear` YEAR, IN `fSprintValue` FLOAT(12), IN `fJumpValue` FLOAT(12), IN `fThrowValue` FLOAT(12), IN `fMiddleDistanceValue` FLOAT(12))
    MODIFIES SQL DATA
BEGIN



  IF COALESCE(fSprintValue,fJumpValue,fThrowValue,fMiddleDistanceValue) IS NULL THEN



    DELETE FROM

      Competition

    WHERE

      StudentPKey = cPKey COLLATE utf8_unicode_ci

      AND `Year` = yYear;



  ELSE



    IF EXISTS (

      SELECT

        NULL

      FROM

        Competition

      WHERE

        StudentPKey = cPKey COLLATE utf8_unicode_ci

        AND YEAR = yYear

    ) THEN

      UPDATE

        Competition

      SET

        Sprint = fSprintValue,

        Jump = fJumpValue,

        Throw = fThrowValue,

        MiddleDistance = fMiddleDistanceValue

      WHERE

        StudentPKey = cPKey COLLATE utf8_unicode_ci

        AND YEAR = yYEAR;



    ELSE



      INSERT INTO Competition (

        StudentPKey,

        Year,

        Sprint,

        Jump,

        Throw,

        MiddleDistance

      ) VALUES (

        cPKey,

        yYEAR,

        fSprintValue,

        fJumpValue,

        fThrowValue,

        fMiddleDistanceValue

      );



    END IF;

  END IF;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
ALTER DATABASE `honglorn` CHARACTER SET utf8 COLLATE utf8_unicode_ci ;
/*!50003 DROP PROCEDURE IF EXISTS `EnterDisciplineMeta` */;
ALTER DATABASE `honglorn` CHARACTER SET utf8 COLLATE utf8_general_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `EnterDisciplineMeta`(IN `cClassName` CHAR(1) CHARSET utf8, IN `yYear` Year(4), IN `eGameType` ENUM('Competition','Traditional'), IN `cMaleSprintPKey` CHAR(36) CHARSET utf8, IN `cMaleJumpPKey` CHAR(36) CHARSET utf8, IN `cMaleThrowPKey` CHAR(36) CHARSET utf8, IN `cMaleMiddleDistancePKey` CHAR(36) CHARSET utf8, IN `cFemaleSprintPKey` CHAR(36) CHARSET utf8, IN `cFemaleJumpPKey` CHAR(36) CHARSET utf8, IN `cFemaleThrowPKey` CHAR(36) CHARSET utf8, IN `cFemaleMiddleDistancePKey` CHAR(36) CHARSET utf8)
    MODIFIES SQL DATA
BEGIN



IF COALESCE(cMaleSprintPKey,cMaleJumpPKey,cMaleThrowPKey,cMaleMiddleDistancePKey,cFemaleSprintPKey,cFemaleJumpPKey,cFemaleThrowPKey,cFemaleMiddleDistancePKey) IS NULL THEN



  DELETE FROM

    dm

  USING

    DisciplineMeta dm

      INNER JOIN Class

        ON dm.ClassPKey = Class.PKey

  WHERE

    ClassName = cClassName

    AND Year = yYear;



ELSE



  IF IsValidDisciplineMeta(eGameType,cMaleSprintPKey,cMaleJumpPKey,cMaleThrowPKey,cMaleMiddleDistancePKey,cFemaleSprintPKey,cFemaleJumpPKey,cFemaleThrowPKey,cFemaleMiddleDistancePKey) THEN

    -- could possible be replaced by Update where exists and insert ignore ?

    IF DisciplineMetaExists(cClassName, yYear) THEN



      UPDATE

        DisciplineMeta

      SET

        GameType = eGameType,

        MaleSprintPKey = cMaleSprintPKey,

        MaleJumpPKey = cMaleJumpPKey,

        MaleThrowPKey = cMaleThrowPKey,

        MaleMiddleDistancePKey = cMaleMiddleDistancePKey,

        FemaleSprintPKey = cFemaleSprintPKey,

        FemaleJumpPKey = cFemaleJumpPKey,

        FemaleThrowPKey = cFemaleThrowPKey,

        FemaleMiddleDistancePKey = cFemaleMiddleDistancePKey

      WHERE

        ClassPKey = GetClassPKey(cClassName)

        AND `Year` = yYear;



    ELSE



    INSERT INTO DisciplineMeta (

      ClassPKey,

      `Year`,

      GameType,

      MaleSprintPKey,

      MaleJumpPKey,

      MaleThrowPKey,

      MaleMiddleDistancePKey,

      FemaleSprintPKey,

      FemaleJumpPKey,

      FemaleThrowPKey,

      FemaleMiddleDistancePKey

    ) VALUES (

      GetClassPKey(cClassName),

      yYear,

      eGameType,

      cMaleSprintPKey,

      cMaleJumpPKey,

      cMaleThrowPKey,

      cMaleMiddleDistancePKey,

      cFemaleSprintPKey,

      cFemaleJumpPKey,

      cFemaleThrowPKey,

      cFemaleMiddleDistancePKey

        );



    END IF;

  END IF;

END IF;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
ALTER DATABASE `honglorn` CHARACTER SET utf8 COLLATE utf8_unicode_ci ;
/*!50003 DROP PROCEDURE IF EXISTS `ImportStudent` */;
ALTER DATABASE `honglorn` CHARACTER SET utf8 COLLATE utf8_general_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `ImportStudent`(IN `sSurname` VARCHAR(45), IN `sForename` VARCHAR(45), IN `cCourseName` CHAR(3), IN `cClassName` CHAR(1), IN `eSex` ENUM('Male','Female'), IN `yYearOfBirth` YEAR(4), IN `yYear` YEAR(4))
    MODIFIES SQL DATA
BEGIN



  DECLARE

    cStudentPKey,

    cRetrievedCoursePKey,

    cGeneratedCoursePKey,

    cGeneratedStudentPKey,

    cRetrievedClassPKey,

    cGeneratedClassPKey

    CHAR(36);



  IF StudentExists(sSurname, sForename, eSex, yYearOfBirth) THEN

  

    SET cStudentPKey = GetStudentPKey(sSurname, sForename, eSex, yYearOfBirth);



  ELSE



    SET cStudentPKey = UUID();



    INSERT INTO Student(

      PKey,

      Surname,

      Forename,

      Sex,

      YearOfBirth

    ) VALUES (

      cStudentPKey,

      sSurname,

      sForename,

      eSex,

      yYearOfBirth

    );

    

  END IF;



  IF NOT StudentCourseRelExists(cStudentPKey, yYear) THEN

    

    IF CourseExists(cCourseName) THEN



      INSERT INTO StudentCourseRel (

        `StudentPKey`,

        `CourseName`,

        `Year`

      ) VALUES (

        cStudentPKey,

        cCourseName,

        yYear

      );



    ELSE



      IF ClassExists(cClassName) THEN



        SET cRetrievedClassPKey = GetClassPKey(cClassName);



        INSERT INTO CourseClassRel (

          CourseName,

          ClassPKey

        ) VALUES (

          cCourseName,

          cRetrievedClassPKey

        );



        INSERT INTO StudentCourseRel (

          StudentPKey,

          CourseName,

          `Year`

        ) VALUES (

          cStudentPKey,

          cCourseName,

          yYear

        );



      ELSE



        SET cGeneratedClassPKey = UUID();



        INSERT INTO Class (

          PKey,

          ClassName

        ) VALUES (

          cGeneratedClassPKey,

          cClassName

        );



        INSERT INTO CourseClassRel (

          CourseName,

          ClassPKey

        ) VALUES (

          cCourseName,

          cGeneratedClassPKey

        );

        

        INSERT INTO StudentCourseRel (

          StudentPKey,

          CourseName,

          `Year`

        ) VALUES (

          cStudentPKey,

          cCourseName,

          yYear

        );



      END IF;     



    END IF;



  END IF;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
ALTER DATABASE `honglorn` CHARACTER SET utf8 COLLATE utf8_unicode_ci ;

--
-- Final view structure for view `competitionjumpdisciplines`
--

/*!50001 DROP TABLE IF EXISTS `competitionjumpdisciplines`*/;
/*!50001 DROP VIEW IF EXISTS `competitionjumpdisciplines`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `competitionjumpdisciplines` AS select `competitiondiscipline`.`PKey` AS `PKey`,`competitiondiscipline`.`Name` AS `Name`,`competitiondiscipline`.`Unit` AS `Unit`,`competitiondiscipline`.`LowIsBetter` AS `LowIsBetter` from `competitiondiscipline` where (`competitiondiscipline`.`Type` = 'Jump') order by `competitiondiscipline`.`Name` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `competitionmiddledistancedisciplines`
--

/*!50001 DROP TABLE IF EXISTS `competitionmiddledistancedisciplines`*/;
/*!50001 DROP VIEW IF EXISTS `competitionmiddledistancedisciplines`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `competitionmiddledistancedisciplines` AS select `competitiondiscipline`.`PKey` AS `PKey`,`competitiondiscipline`.`Name` AS `Name`,`competitiondiscipline`.`Unit` AS `Unit`,`competitiondiscipline`.`LowIsBetter` AS `LowIsBetter` from `competitiondiscipline` where (`competitiondiscipline`.`Type` = 'MiddleDistance') order by `competitiondiscipline`.`Name` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `competitionsprintdisciplines`
--

/*!50001 DROP TABLE IF EXISTS `competitionsprintdisciplines`*/;
/*!50001 DROP VIEW IF EXISTS `competitionsprintdisciplines`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `competitionsprintdisciplines` AS select `competitiondiscipline`.`PKey` AS `PKey`,`competitiondiscipline`.`Name` AS `Name`,`competitiondiscipline`.`Unit` AS `Unit`,`competitiondiscipline`.`LowIsBetter` AS `LowIsBetter` from `competitiondiscipline` where (`competitiondiscipline`.`Type` = 'Sprint') order by `competitiondiscipline`.`Name` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `competitionthrowdisciplines`
--

/*!50001 DROP TABLE IF EXISTS `competitionthrowdisciplines`*/;
/*!50001 DROP VIEW IF EXISTS `competitionthrowdisciplines`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `competitionthrowdisciplines` AS select `competitiondiscipline`.`PKey` AS `PKey`,`competitiondiscipline`.`Name` AS `Name`,`competitiondiscipline`.`Unit` AS `Unit`,`competitiondiscipline`.`LowIsBetter` AS `LowIsBetter` from `competitiondiscipline` where (`competitiondiscipline`.`Type` = 'Throw') order by `competitiondiscipline`.`Name` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `traditionalfemalejumpdisciplines`
--

/*!50001 DROP TABLE IF EXISTS `traditionalfemalejumpdisciplines`*/;
/*!50001 DROP VIEW IF EXISTS `traditionalfemalejumpdisciplines`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `traditionalfemalejumpdisciplines` AS select `traditionaldiscipline`.`PKey` AS `PKey`,`traditionaldiscipline`.`Name` AS `Name` from `traditionaldiscipline` where ((`traditionaldiscipline`.`Type` = 'Jump') and (`traditionaldiscipline`.`Sex` = 'Female')) order by `traditionaldiscipline`.`Name` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `traditionalfemalemiddledistancedisciplines`
--

/*!50001 DROP TABLE IF EXISTS `traditionalfemalemiddledistancedisciplines`*/;
/*!50001 DROP VIEW IF EXISTS `traditionalfemalemiddledistancedisciplines`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `traditionalfemalemiddledistancedisciplines` AS select `traditionaldiscipline`.`PKey` AS `PKey`,`traditionaldiscipline`.`Name` AS `Name` from `traditionaldiscipline` where ((`traditionaldiscipline`.`Type` = 'MiddleDistance') and (`traditionaldiscipline`.`Sex` = 'Female')) order by length(`traditionaldiscipline`.`Name`),`traditionaldiscipline`.`Name` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `traditionalfemalesprintdisciplines`
--

/*!50001 DROP TABLE IF EXISTS `traditionalfemalesprintdisciplines`*/;
/*!50001 DROP VIEW IF EXISTS `traditionalfemalesprintdisciplines`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `traditionalfemalesprintdisciplines` AS select `traditionaldiscipline`.`PKey` AS `PKey`,`traditionaldiscipline`.`Name` AS `Name`,`traditionaldiscipline`.`Measurement` AS `Measurement` from `traditionaldiscipline` where ((`traditionaldiscipline`.`Type` = 'Sprint') and (`traditionaldiscipline`.`Sex` = 'Female')) order by `traditionaldiscipline`.`Measurement`,length(`traditionaldiscipline`.`Name`),`traditionaldiscipline`.`Name` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `traditionalfemalethrowdisciplines`
--

/*!50001 DROP TABLE IF EXISTS `traditionalfemalethrowdisciplines`*/;
/*!50001 DROP VIEW IF EXISTS `traditionalfemalethrowdisciplines`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `traditionalfemalethrowdisciplines` AS select `traditionaldiscipline`.`PKey` AS `PKey`,`traditionaldiscipline`.`Name` AS `Name` from `traditionaldiscipline` where ((`traditionaldiscipline`.`Type` = 'Throw') and (`traditionaldiscipline`.`Sex` = 'Female')) order by `traditionaldiscipline`.`Name` desc */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `traditionalmalejumpdisciplines`
--

/*!50001 DROP TABLE IF EXISTS `traditionalmalejumpdisciplines`*/;
/*!50001 DROP VIEW IF EXISTS `traditionalmalejumpdisciplines`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `traditionalmalejumpdisciplines` AS select `traditionaldiscipline`.`PKey` AS `PKey`,`traditionaldiscipline`.`Name` AS `Name` from `traditionaldiscipline` where ((`traditionaldiscipline`.`Type` = 'Jump') and (`traditionaldiscipline`.`Sex` = 'Male')) order by `traditionaldiscipline`.`Name` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `traditionalmalemiddledistancedisciplines`
--

/*!50001 DROP TABLE IF EXISTS `traditionalmalemiddledistancedisciplines`*/;
/*!50001 DROP VIEW IF EXISTS `traditionalmalemiddledistancedisciplines`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `traditionalmalemiddledistancedisciplines` AS select `traditionaldiscipline`.`PKey` AS `PKey`,`traditionaldiscipline`.`Name` AS `Name` from `traditionaldiscipline` where ((`traditionaldiscipline`.`Type` = 'MiddleDistance') and (`traditionaldiscipline`.`Sex` = 'Male')) order by length(`traditionaldiscipline`.`Name`),`traditionaldiscipline`.`Name` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `traditionalmalesprintdisciplines`
--

/*!50001 DROP TABLE IF EXISTS `traditionalmalesprintdisciplines`*/;
/*!50001 DROP VIEW IF EXISTS `traditionalmalesprintdisciplines`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `traditionalmalesprintdisciplines` AS select `traditionaldiscipline`.`PKey` AS `PKey`,`traditionaldiscipline`.`Name` AS `Name`,`traditionaldiscipline`.`Measurement` AS `Measurement` from `traditionaldiscipline` where ((`traditionaldiscipline`.`Type` = 'Sprint') and (`traditionaldiscipline`.`Sex` = 'Male')) order by `traditionaldiscipline`.`Measurement`,length(`traditionaldiscipline`.`Name`),`traditionaldiscipline`.`Name` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `traditionalmalethrowdisciplines`
--

/*!50001 DROP TABLE IF EXISTS `traditionalmalethrowdisciplines`*/;
/*!50001 DROP VIEW IF EXISTS `traditionalmalethrowdisciplines`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `traditionalmalethrowdisciplines` AS select `traditionaldiscipline`.`PKey` AS `PKey`,`traditionaldiscipline`.`Name` AS `Name` from `traditionaldiscipline` where ((`traditionaldiscipline`.`Type` = 'Throw') and (`traditionaldiscipline`.`Sex` = 'Male')) order by `traditionaldiscipline`.`Name` desc */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `validyears`
--

/*!50001 DROP TABLE IF EXISTS `validyears`*/;
/*!50001 DROP VIEW IF EXISTS `validyears`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `validyears` AS select distinct `studentcourserel`.`Year` AS `year` from `studentcourserel` order by `studentcourserel`.`Year` desc */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-07-11 18:56:30
