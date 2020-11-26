-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: restaurant
-- ------------------------------------------------------
-- Server version	8.0.19

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
  `num` int DEFAULT '0',
  `DishFunds` decimal(15,2) DEFAULT NULL,
  `DishImage` varchar(450) DEFAULT NULL,
  PRIMARY KEY (`DishId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dish`
--

LOCK TABLES `dish` WRITE;
/*!40000 ALTER TABLE `dish` DISABLE KEYS */;
INSERT INTO `dish` VALUES ('1','Cơm tấm',30000.00,'Cơm ngon lắm',1,0,1.00,'https://images.foody.vn/res/g10/98048/prof/s576x330/foody-upload-api-foody-mobile-com-190311132057.jpg'),('2','Cơm lam',35000.00,'Cơm lam gà nướng',1,0,1.00,'https://thucphamdongxanh.com/wp-content/uploads/2020/09/com-lam-ong-tre.jpg'),('3','Mì xào bò',25000.00,'Mì dai dai',1,0,1.00,'https://cdn.cet.edu.vn/wp-content/uploads/2019/06/mi-xao-bo.jpg'),('4','Cơm chiên dưa bò',25000.00,'Cơm ngon tuyệt cú mèo',1,0,1.00,'https://v-food.vn/wp-content/uploads/2019/03/c%C6%A1m-rang-d%C6%B0a-b%C3%B2.-40k.jpg'),('5','Lẩu gà lá giang',90000.00,'Couple giá rẻ',1,0,1.00,'https://daynauan.info.vn/wp-content/uploads/2018/07/lau-ga-la-giang.jpg'),('6','Phở xào',25000.00,'Phở ngon',1,0,1.00,'https://daynauan.info.vn/wp-content/uploads/2018/06/pho-xao-bo.jpg'),('7','Lẩu thái',150000.00,'Lẩu Thái chuẩn Thái',1,0,1.00,'https://image-us.eva.vn/upload/1-2019/images/2019-03-26/1553563014-942-thumbnail_schema_article.jpg'),('8','Hến xào',30000.00,'Hến ngon',1,0,1.00,'https://img-global.cpcdn.com/recipes/9877bb218702b13d/751x532cq70/h%E1%BA%BFn-xao-h%E1%BA%B9-xuc-banh-da-recipe-main-photo.jpg');
/*!40000 ALTER TABLE `dish` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-11-26 22:28:46
