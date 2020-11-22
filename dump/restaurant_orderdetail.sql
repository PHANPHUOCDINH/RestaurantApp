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
-- Table structure for table `orderdetail`
--

DROP TABLE IF EXISTS `orderdetail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orderdetail` (
  `OrderDetailId` varchar(50) NOT NULL,
  `DishId` varchar(50) NOT NULL,
  `OrderId` varchar(50) NOT NULL,
  `CookId` varchar(50) DEFAULT NULL,
  `OrderDetailStatus` int NOT NULL,
  `OrderDetailStarttime` datetime DEFAULT NULL,
  `OrderDetailEndtime` datetime DEFAULT NULL,
  `OrderDetailIsDeleted` tinyint DEFAULT NULL,
  PRIMARY KEY (`OrderDetailId`,`DishId`,`OrderId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orderdetail`
--

LOCK TABLES `orderdetail` WRITE;
/*!40000 ALTER TABLE `orderdetail` DISABLE KEYS */;
INSERT INTO `orderdetail` VALUES ('08deb388-e122-474b-83d3-1f9a7b677e5f','dish01','order01','staff001',0,'2020-11-22 17:00:00','2020-11-22 17:30:00',0),('53853efe-d6b3-4f27-8b33-79c748478133','dish02','order01','staff001',0,'2020-11-22 17:00:00','2020-10-22 17:30:00',0),('66f1c717-ad41-46e9-a2f3-d958d65acc83','dish03','order02','staf002',1,'2020-11-22 17:00:00','2020-11-22 17:31:00',0),('a0e5c8a1-428d-4b72-b274-fc694f12a4bd','dish01','order01','staff001',0,'2020-11-22 17:00:00','2020-10-22 17:00:00',0),('a505459b-58c3-4e10-9d6a-863ae38a16ee','dish02','order01','staff003',1,NULL,NULL,0);
/*!40000 ALTER TABLE `orderdetail` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-11-22 21:54:35
