-- MySQL dump 10.13  Distrib 8.0.22, for Win64 (x86_64)
--
-- Host: localhost    Database: restaurant
-- ------------------------------------------------------
-- Server version	8.0.22

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `staff`
--

DROP TABLE IF EXISTS `staff`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `staff` (
  `StaffId` varchar(50) NOT NULL,
  `RoleId` varchar(50) DEFAULT NULL,
  `StaffVisa` varchar(5) DEFAULT NULL,
  `StaffName` varchar(100) DEFAULT NULL,
  `StaffUsername` varchar(50) DEFAULT NULL,
  `StaffPassword` varchar(100) DEFAULT NULL,
  `StaffBirthdate` datetime DEFAULT NULL,
  `StaffSalary` decimal(15,2) DEFAULT NULL,
  `StaffIsActive` tinyint NOT NULL,
  `ExternalId` varchar(50) DEFAULT NULL,
  `RefreshToken` longtext,
  `AccessToken` longtext,
  PRIMARY KEY (`StaffId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `staff`
--

LOCK TABLES `staff` WRITE;
/*!40000 ALTER TABLE `staff` DISABLE KEYS */;
INSERT INTO `staff` VALUES ('9f22accb-c222-4088-8c14-c00e47bdd612',NULL,NULL,'Nguyen Van E',NULL,NULL,NULL,10000000.00,1,NULL,NULL,NULL),('dbc8697b-3e6c-44ec-a57c-0fde73650b8e',NULL,NULL,'Nguyen Van D','admin3','admin3',NULL,7000000.00,0,NULL,NULL,NULL),('staff001','role01',NULL,NULL,'admin','admin',NULL,5000000.00,0,NULL,'xIzPdx09oA2cWPeAM9bbStqXxj2amcq1D7FY6FuWAlU=',NULL),('staff002','role02',NULL,NULL,'admin1','admin1',NULL,7500000.00,1,NULL,NULL,NULL),('staff003','role01',NULL,NULL,'admin3','admin3',NULL,8500000.00,0,NULL,NULL,NULL);
/*!40000 ALTER TABLE `staff` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-11-22 21:54:36
