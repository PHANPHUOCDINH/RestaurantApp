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
-- Table structure for table `dish`
--

DROP TABLE IF EXISTS `dish`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dish` (
  `DishId` varchar(50) NOT NULL,
  `DishName` varchar(100) NOT NULL,
  `DishPrice` decimal(15,2) NOT NULL,
  `DishDescription` varchar(200) DEFAULT NULL,
  `DishIsActive` tinyint(1) NOT NULL,
  `DishIsDeleted` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`DishId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dish`
--

LOCK TABLES `dish` WRITE;
/*!40000 ALTER TABLE `dish` DISABLE KEYS */;
INSERT INTO `dish` VALUES ('qqq','Món C',53000.00,NULL,1,1),('xxx','Món A',2000.00,NULL,1,0),('xxy','Món B',3000.00,NULL,1,0);
/*!40000 ALTER TABLE `dish` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `noticontent`
--

DROP TABLE IF EXISTS `noticontent`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `noticontent` (
  `noti_content_id` varchar(50) NOT NULL,
  `noti_title` varchar(50) DEFAULT NULL,
  `noti_content` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`noti_content_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `noticontent`
--

LOCK TABLES `noticontent` WRITE;
/*!40000 ALTER TABLE `noticontent` DISABLE KEYS */;
/*!40000 ALTER TABLE `noticontent` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `notification`
--

DROP TABLE IF EXISTS `notification`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `notification` (
  `NotiId` varchar(50) NOT NULL,
  `CookId` varchar(50) DEFAULT NULL,
  `WaiterId` varchar(50) DEFAULT NULL,
  `NotiTitle` varchar(50) DEFAULT NULL,
  `NotiDate` datetime DEFAULT NULL,
  `NotiContent` varchar(100) DEFAULT NULL,
  `NotiIsDeleted` tinyint DEFAULT NULL,
  PRIMARY KEY (`NotiId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `notification`
--

LOCK TABLES `notification` WRITE;
/*!40000 ALTER TABLE `notification` DISABLE KEYS */;
INSERT INTO `notification` VALUES ('xxx','aaa','bbb',NULL,NULL,NULL,NULL),('yyy','bbb','aaa',NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `notification` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order`
--

DROP TABLE IF EXISTS `order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order` (
  `OrderId` varchar(50) NOT NULL,
  `TableId` varchar(50) DEFAULT NULL,
  `WaiterId` varchar(50) DEFAULT NULL,
  `OrderDate` datetime DEFAULT NULL,
  `OrderTotal` decimal(15,2) DEFAULT NULL,
  `OrderStarttime` datetime DEFAULT NULL,
  `OrderEndtime` datetime DEFAULT NULL,
  `OrderIsDeleted` tinyint DEFAULT NULL,
  `OrderStatus` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`OrderId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order`
--

LOCK TABLES `order` WRITE;
/*!40000 ALTER TABLE `order` DISABLE KEYS */;
INSERT INTO `order` VALUES ('b12b95dc-0a02-4e77-848b-7a474ba5842b',NULL,NULL,NULL,150000.00,NULL,NULL,0,NULL),('order1',NULL,NULL,NULL,100.00,NULL,NULL,1,NULL);
/*!40000 ALTER TABLE `order` ENABLE KEYS */;
UNLOCK TABLES;

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
  `OrderDetailStarttime` time DEFAULT NULL,
  `OrderDetailEndtime` time DEFAULT NULL,
  `OrderDetailIsDeleted` tinyint DEFAULT NULL,
  PRIMARY KEY (`OrderDetailId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orderdetail`
--

LOCK TABLES `orderdetail` WRITE;
/*!40000 ALTER TABLE `orderdetail` DISABLE KEYS */;
INSERT INTO `orderdetail` VALUES ('asqwqw','qqq','order1',NULL,0,NULL,NULL,0);
/*!40000 ALTER TABLE `orderdetail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role`
--

DROP TABLE IF EXISTS `role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `role` (
  `RoldId` varchar(50) NOT NULL,
  `RoldName` varchar(100) NOT NULL,
  `RoleDescription` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`RoldId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `role`
--

LOCK TABLES `role` WRITE;
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
INSERT INTO `role` VALUES ('1','Quan tri',NULL),('2','Nhan vien',NULL);
/*!40000 ALTER TABLE `role` ENABLE KEYS */;
UNLOCK TABLES;

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
  `StaffPassword` varchar(50) DEFAULT NULL,
  `StaffBirthdate` datetime DEFAULT NULL,
  `StaffSalary` decimal(15,2) DEFAULT NULL,
  `StaffIsDeleted` tinyint DEFAULT NULL,
  PRIMARY KEY (`StaffId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `staff`
--

LOCK TABLES `staff` WRITE;
/*!40000 ALTER TABLE `staff` DISABLE KEYS */;
INSERT INTO `staff` VALUES ('aaa',NULL,NULL,'NguyenVanB',NULL,NULL,NULL,NULL,1),('da0df4dd-34ba-48ac-a3c5-1203d6ed224c',NULL,NULL,'Nguyen Van H','test',NULL,NULL,NULL,0);
/*!40000 ALTER TABLE `staff` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stafftype`
--

DROP TABLE IF EXISTS `stafftype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `stafftype` (
  `stafftype_id` varchar(50) NOT NULL,
  `stafftype_name` varchar(100) NOT NULL,
  `stafftype_description` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`stafftype_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stafftype`
--

LOCK TABLES `stafftype` WRITE;
/*!40000 ALTER TABLE `stafftype` DISABLE KEYS */;
/*!40000 ALTER TABLE `stafftype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `table`
--

DROP TABLE IF EXISTS `table`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `table` (
  `TableId` varchar(50) NOT NULL,
  `TableName` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `TableIdOrderServing` varchar(50) DEFAULT NULL,
  `TableStatus` int DEFAULT NULL,
  PRIMARY KEY (`TableId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `table`
--

LOCK TABLES `table` WRITE;
/*!40000 ALTER TABLE `table` DISABLE KEYS */;
INSERT INTO `table` VALUES ('gỳtghfghcgh','hjbghjg','higy',3);
/*!40000 ALTER TABLE `table` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `test`
--

DROP TABLE IF EXISTS `test`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `test` (
  `TestId` int NOT NULL,
  `TestName` varchar(450) DEFAULT NULL,
  PRIMARY KEY (`TestId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `test`
--

LOCK TABLES `test` WRITE;
/*!40000 ALTER TABLE `test` DISABLE KEYS */;
INSERT INTO `test` VALUES (1,'z'),(2,'z');
/*!40000 ALTER TABLE `test` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-11-05 20:30:19
