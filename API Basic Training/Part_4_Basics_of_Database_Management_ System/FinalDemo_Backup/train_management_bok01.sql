-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: train_management
-- ------------------------------------------------------
-- Server version	8.0.27

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
-- Table structure for table `bok01`
--

DROP TABLE IF EXISTS `bok01`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bok01` (
  `K01F01` int NOT NULL AUTO_INCREMENT COMMENT 'booking id',
  `K01F02` int DEFAULT NULL COMMENT 'train id',
  `K01F03` int DEFAULT NULL COMMENT 'passenger id',
  `K01F04` date DEFAULT NULL COMMENT 'booking date',
  PRIMARY KEY (`K01F01`),
  KEY `K01F02` (`K01F02`),
  KEY `K01F03` (`K01F03`),
  CONSTRAINT `bok01_ibfk_1` FOREIGN KEY (`K01F02`) REFERENCES `tra01` (`A01F01`),
  CONSTRAINT `bok01_ibfk_2` FOREIGN KEY (`K01F03`) REFERENCES `psg01` (`G01F01`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='bookings';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bok01`
--

LOCK TABLES `bok01` WRITE;
/*!40000 ALTER TABLE `bok01` DISABLE KEYS */;
INSERT INTO `bok01` VALUES (1,1,1,'2024-01-15'),(2,2,2,'2024-01-16'),(3,3,3,'2024-01-17');
/*!40000 ALTER TABLE `bok01` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-01-15 16:23:08