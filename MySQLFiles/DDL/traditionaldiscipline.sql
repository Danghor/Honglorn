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

-- Dumping structure for table bjs.traditionaldiscipline
DROP TABLE IF EXISTS `traditionaldiscipline`;
CREATE TABLE IF NOT EXISTS `traditionaldiscipline` (
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

-- Dumping data for table bjs.traditionaldiscipline: ~30 rows (approximately)
DELETE FROM `traditionaldiscipline`;
/*!40000 ALTER TABLE `traditionaldiscipline` DISABLE KEYS */;
INSERT INTO `traditionaldiscipline` (`PKey`, `Type`, `Sex`, `Name`, `UnitSymbol`, `Distance`, `Overhead`, `ConstantA`, `ConstantC`, `Measurement`) VALUES
	('02e7bcb5-fbbf-421e-bad7-d2b3190ed2ca', 'Sprint', 'Female', 'Sprint 100 m', 's', 100, NULL, 4.00620, 0.006560, 'Electronic'),
	('0560491e-f326-483b-974f-6d07b967d427', 'Throw', 'Male', 'Kugelstoß', 'm', NULL, NULL, 1.42500, 0.003700, NULL),
	('0a18a585-a888-4993-83a0-342afea368c2', 'Jump', 'Male', 'Hochsprung', 'm', NULL, NULL, 0.84100, 0.000800, NULL),
	('0dcf6e43-e4d3-4dae-8966-8ce805dbb64e', 'Throw', 'Female', '200-g-Ballwurf', 'm', NULL, NULL, 1.41490, 0.010390, NULL),
	('138b08a4-940c-4633-9537-027a58df115d', 'Throw', 'Female', 'Kugelstoß', 'm', NULL, NULL, 1.27900, 0.003980, NULL),
	('24d9b5dd-3513-416c-a126-349ac2dcb781', 'Jump', 'Female', 'Weitsprung', 'm', NULL, NULL, 1.09350, 0.002080, NULL),
	('25ce654a-68dd-4094-b2b6-737581fb8957', 'Jump', 'Male', 'Weitsprung', 'm', NULL, NULL, 1.15028, 0.002190, NULL),
	('426231f9-6f68-43d2-877f-2760ed6ab068', 'MiddleDistance', 'Male', 'Lauf 3000 m', 's', 3000, NULL, 1.70000, 0.005800, NULL),
	('48742630-8e5b-41d0-934c-f4a58e8227f4', 'MiddleDistance', 'Male', 'Lauf 1000 m', 's', 1000, NULL, 2.15800, 0.006000, NULL),
	('55597498-82e2-4f02-be94-5c766e599935', 'Throw', 'Male', '200-g-Ballwurf', 'm', NULL, NULL, 1.93600, 0.012400, NULL),
	('587b637d-5e4d-4a2d-bb1c-9641b83a7a08', 'MiddleDistance', 'Female', 'Lauf 3000 m', 's', 3000, NULL, 1.75000, 0.005000, NULL),
	('7205b19a-6036-4dad-a1a1-ccee7ea48584', 'Sprint', 'Male', 'Sprint 75 m', 's', 75, 0.24, 4.10000, 0.006640, 'Manual'),
	('80927ffb-7f27-11e4-bf87-00249b0f3387', 'Sprint', 'Female', 'Sprint 75 m', 's', 75, 0.24, 3.99800, 0.006600, 'Manual'),
	('953d6cb3-501b-4a02-99da-f1a86edb636f', 'Jump', 'Female', 'Hochsprung', 'm', NULL, NULL, 0.88070, 0.000680, NULL),
	('99144998-865d-47c7-8d45-552998349254', 'Sprint', 'Male', 'Sprint 75 m', 's', 75, NULL, 4.10000, 0.006640, 'Electronic'),
	('9a72a264-7e72-11e4-bf87-00249b0f3387', 'Sprint', 'Female', 'Sprint 50 m', 's', 50, 0.24, 3.64800, 0.006600, 'Manual'),
	('9f6f0333-b70e-4d55-98c0-67057decbee0', 'Sprint', 'Male', 'Sprint 100 m', 's', 100, 0.24, 4.34100, 0.006760, 'Manual'),
	('ac62b909-c533-470a-9eb8-744d2b9cc013', 'Sprint', 'Male', 'Sprint 50 m', 's', 50, 0.24, 3.79000, 0.006900, 'Manual'),
	('b101f80e-cea6-4c81-99f6-1ba5643f6c70', 'Throw', 'Female', '80-g-Schlagballwurf', 'm', NULL, NULL, 2.02320, 0.008740, NULL),
	('b16745e2-bbba-4346-8d49-7d9d65e7ecd6', 'Sprint', 'Male', 'Sprint 50 m', 's', 50, NULL, 3.79000, 0.006900, 'Electronic'),
	('b68cb942-8826-4938-abce-9b1bf2cee550', 'Sprint', 'Female', 'Sprint 75 m', 's', 75, NULL, 3.99800, 0.006600, 'Electronic'),
	('b82a9905-cc00-40a8-87af-0d94b1f72cda', 'Throw', 'Male', '80-g-Schlagballwurf', 'm', NULL, NULL, 2.80000, 0.011000, NULL),
	('bb4fdf4d-e832-491c-aa62-af0e693155d5', 'Throw', 'Female', 'Schleuderball', 'm', NULL, NULL, 1.08500, 0.009210, NULL),
	('bfe57845-d9d2-4d33-9ca9-d8ac82d1dca6', 'MiddleDistance', 'Female', 'Lauf 800 m', 's', 800, NULL, 2.02320, 0.006470, NULL),
	('c3300949-30fe-41a5-84bc-46ae791bf062', 'Sprint', 'Male', 'Sprint 100 m', 's', 100, NULL, 4.34100, 0.006760, 'Electronic'),
	('cb418b3b-3293-43f2-9a28-d6acfef81734', 'MiddleDistance', 'Male', 'Lauf 2000 m', 's', 2000, NULL, 1.78400, 0.006000, NULL),
	('cd48a79b-4ded-4de1-badb-795dd7a2c5dd', 'Sprint', 'Female', 'Sprint 100 m', 's', 100, 0.24, 4.00620, 0.006560, 'Manual'),
	('cfaccaf6-10c9-42b4-9c4e-fc53d59b09ad', 'Sprint', 'Female', 'Sprint 50 m', 's', 50, NULL, 3.64800, 0.006600, 'Electronic'),
	('e000cca7-8ab0-4c5c-bf15-c2fef424efd6', 'Throw', 'Male', 'Schleuderball', 'm', NULL, NULL, 1.59500, 0.009125, NULL),
	('fc40a2c0-46cc-42d6-bd56-f11e7f4954d1', 'MiddleDistance', 'Female', 'Lauf 2000 m', 's', 2000, NULL, 1.80000, 0.005400, NULL);
/*!40000 ALTER TABLE `traditionaldiscipline` ENABLE KEYS */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
