-- MySQL dump 10.13  Distrib 8.0.18, for Win64 (x86_64)
--
-- Host: localhost    Database: ethereal_em
-- ------------------------------------------------------
-- Server version	8.0.18

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
-- Table structure for table `tbl_admin`
--

DROP TABLE IF EXISTS `tbl_admin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_admin` (
  `admin_id` int(50) NOT NULL AUTO_INCREMENT,
  `admin_name` varchar(45) DEFAULT NULL,
  `admin_password` varchar(45) DEFAULT NULL,
  `admin_photo` text,
  PRIMARY KEY (`admin_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_admin`
--

LOCK TABLES `tbl_admin` WRITE;
/*!40000 ALTER TABLE `tbl_admin` DISABLE KEYS */;
INSERT INTO `tbl_admin` VALUES (1,'DJ','123456','black'),(2,'Hyper','654321','gay'),(3,'Oeshi','13579','nay'),(4,'Bunny','24680','Good');
/*!40000 ALTER TABLE `tbl_admin` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_category`
--

DROP TABLE IF EXISTS `tbl_category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_category` (
  `category_id` int(11) NOT NULL AUTO_INCREMENT,
  `category_sub_id` int(11) DEFAULT NULL,
  `category_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`category_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_category`
--

LOCK TABLES `tbl_category` WRITE;
/*!40000 ALTER TABLE `tbl_category` DISABLE KEYS */;
INSERT INTO `tbl_category` VALUES (1,1,'AA');
/*!40000 ALTER TABLE `tbl_category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_email_template`
--

DROP TABLE IF EXISTS `tbl_email_template`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_email_template` (
  `EmailTemplateID` int(100) NOT NULL,
  `template_name` varchar(255) DEFAULT NULL,
  `template_content` varchar(255) DEFAULT NULL,
  `subject` varchar(255) DEFAULT NULL,
  `from_email` varchar(255) DEFAULT NULL,
  `variable` varchar(255) DEFAULT NULL,
  `modified_date` datetime DEFAULT '0000-00-00 00:00:00',
  PRIMARY KEY (`EmailTemplateID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_email_template`
--

LOCK TABLES `tbl_email_template` WRITE;
/*!40000 ALTER TABLE `tbl_email_template` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_email_template` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_eventlog`
--

DROP TABLE IF EXISTS `tbl_eventlog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_eventlog` (
  `ID` int(11) NOT NULL,
  `LogType` int(11) DEFAULT NULL,
  `LogDateTime` datetime DEFAULT '0000-00-00 00:00:00',
  `Source` varchar(45) DEFAULT NULL,
  `FormName` varchar(45) DEFAULT NULL,
  `LogMessage` varchar(45) DEFAULT NULL,
  `ErrMessage` varchar(45) DEFAULT NULL,
  `UserID` int(11) DEFAULT NULL,
  `UserType` varchar(45) DEFAULT NULL,
  `ipAddress` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_eventlog`
--

LOCK TABLES `tbl_eventlog` WRITE;
/*!40000 ALTER TABLE `tbl_eventlog` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_eventlog` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_menu`
--

DROP TABLE IF EXISTS `tbl_menu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_menu` (
  `menu_id` int(50) NOT NULL AUTO_INCREMENT,
  `sub_menu_id` int(50) DEFAULT NULL,
  `menu_name` varchar(45) DEFAULT NULL,
  `menu_route` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`menu_id`)
) ENGINE=InnoDB AUTO_INCREMENT=1005 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_menu`
--

LOCK TABLES `tbl_menu` WRITE;
/*!40000 ALTER TABLE `tbl_menu` DISABLE KEYS */;
INSERT INTO `tbl_menu` VALUES (1,1,'Review','Review_link'),(2,2,'Notification','Noti_Link'),(3,3,'User Management','User_management_link'),(4,4,'Admin Management','Admin_management_link'),(5,5,'Announcement','Announcement_link'),(1001,1,'Freelance Post','Freelance_link'),(1002,1,'Business Post','Business_link'),(1003,1,'User Post','User_link'),(1004,1,'Report','Report_link');
/*!40000 ALTER TABLE `tbl_menu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_menu_permission`
--

DROP TABLE IF EXISTS `tbl_menu_permission`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_menu_permission` (
  `menu_permission_id` int(50) NOT NULL AUTO_INCREMENT,
  `menu_id` int(50) DEFAULT NULL,
  `permission_id` int(50) DEFAULT NULL,
  PRIMARY KEY (`menu_permission_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_menu_permission`
--

LOCK TABLES `tbl_menu_permission` WRITE;
/*!40000 ALTER TABLE `tbl_menu_permission` DISABLE KEYS */;
INSERT INTO `tbl_menu_permission` VALUES (1,1,2),(2,3,2);
/*!40000 ALTER TABLE `tbl_menu_permission` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_notification`
--

DROP TABLE IF EXISTS `tbl_notification`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_notification` (
  `notification_id` int(11) NOT NULL AUTO_INCREMENT,
  `notification_user_photo` varchar(255) DEFAULT NULL,
  `admin_id` int(11) DEFAULT NULL,
  `notification_title` varchar(255) DEFAULT NULL,
  `notification_description` varchar(255) DEFAULT NULL,
  `notification_status` int(11) DEFAULT NULL,
  `notification_date` datetime DEFAULT NULL,
  `notification_route` varchar(255) DEFAULT NULL,
  `post_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`notification_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_notification`
--

LOCK TABLES `tbl_notification` WRITE;
/*!40000 ALTER TABLE `tbl_notification` DISABLE KEYS */;
INSERT INTO `tbl_notification` VALUES (1,'abc',2,'dea','asdxzcb',2,'2018-12-19 09:26:03','asd',2),(2,'DEF',2,'DEF','zxcvbn',1,'2018-12-19 09:26:03','qqqq',3);
/*!40000 ALTER TABLE `tbl_notification` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_permission`
--

DROP TABLE IF EXISTS `tbl_permission`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_permission` (
  `permission_id` int(50) NOT NULL AUTO_INCREMENT,
  `permission_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`permission_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_permission`
--

LOCK TABLES `tbl_permission` WRITE;
/*!40000 ALTER TABLE `tbl_permission` DISABLE KEYS */;
INSERT INTO `tbl_permission` VALUES (1,'Cleaning'),(2,'Network');
/*!40000 ALTER TABLE `tbl_permission` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_permission_admin`
--

DROP TABLE IF EXISTS `tbl_permission_admin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_permission_admin` (
  `permission_admin_id` int(50) NOT NULL AUTO_INCREMENT,
  `admin_id` int(50) DEFAULT NULL,
  `permission_id` int(50) DEFAULT NULL,
  PRIMARY KEY (`permission_admin_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_permission_admin`
--

LOCK TABLES `tbl_permission_admin` WRITE;
/*!40000 ALTER TABLE `tbl_permission_admin` DISABLE KEYS */;
INSERT INTO `tbl_permission_admin` VALUES (1,2,1),(2,1,2);
/*!40000 ALTER TABLE `tbl_permission_admin` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_post`
--

DROP TABLE IF EXISTS `tbl_post`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_post` (
  `post_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_photo` varchar(255) DEFAULT NULL,
  `uploader_id` int(11) NOT NULL DEFAULT '0',
  `content_text` text,
  `photo_count` int(11) DEFAULT '0',
  `created_date` datetime DEFAULT '0000-00-00 00:00:00',
  `approved_rejected_date` datetime DEFAULT '0000-00-00 00:00:00',
  `status` int(3) DEFAULT '0',
  PRIMARY KEY (`post_id`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_post`
--

LOCK TABLES `tbl_post` WRITE;
/*!40000 ALTER TABLE `tbl_post` DISABLE KEYS */;
INSERT INTO `tbl_post` VALUES (1,NULL,0,'Kilo',0,'2020-01-01 10:10:10','0000-00-00 00:00:00',0),(2,NULL,0,'King',0,'2020-01-01 10:10:10','0000-00-00 00:00:00',0),(3,NULL,0,'Mega',0,'2020-01-01 10:10:10','0000-00-00 00:00:00',0),(4,NULL,0,'giga',0,'2020-01-01 10:10:10','0000-00-00 00:00:00',0),(5,NULL,0,'titan',0,'2020-01-01 10:10:10','0000-00-00 00:00:00',0),(6,NULL,0,'zff',0,'2020-01-01 10:10:10','0000-00-00 00:00:00',0),(7,NULL,0,'ff',0,'2020-01-01 10:10:10','0000-00-00 00:00:00',0),(8,NULL,0,'ddd',0,'0000-00-00 00:00:00','0000-00-00 00:00:00',0),(9,NULL,0,'ss',0,'0000-00-00 00:00:00','0000-00-00 00:00:00',0),(10,NULL,0,'rr',0,'0000-00-00 00:00:00','0000-00-00 00:00:00',0),(11,NULL,0,'tt',0,'0000-00-00 00:00:00','0000-00-00 00:00:00',0),(12,NULL,0,'ffd',0,'0000-00-00 00:00:00','0000-00-00 00:00:00',0),(13,NULL,0,'ffa',0,'0000-00-00 00:00:00','0000-00-00 00:00:00',0);
/*!40000 ALTER TABLE `tbl_post` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_post_category`
--

DROP TABLE IF EXISTS `tbl_post_category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_post_category` (
  `post_category_id` int(11) NOT NULL AUTO_INCREMENT,
  `category_id` varchar(256) DEFAULT NULL,
  `post_id` int(11) NOT NULL,
  PRIMARY KEY (`post_category_id`),
  UNIQUE KEY `post_id_UNIQUE` (`post_id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_post_category`
--

LOCK TABLES `tbl_post_category` WRITE;
/*!40000 ALTER TABLE `tbl_post_category` DISABLE KEYS */;
INSERT INTO `tbl_post_category` VALUES (1,'2,4,5,6,7',1),(2,'2,4,5,6,7',12),(3,'2,3,4,6,7',2),(4,'2,4,5,6,7',13),(5,'2,4,5,6,7',3),(6,'2,4,5,6,7',4),(7,'2,4,5,6,7',5),(8,'2,4,5,6,7',6),(9,'2,4,5,6,7',7),(10,'2,4,5,6,7',8),(11,'2,4,5,6,7',9),(12,'2,4,5,6,7',10),(13,'2,4,5,6,7',11);
/*!40000 ALTER TABLE `tbl_post_category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_post_detail`
--

DROP TABLE IF EXISTS `tbl_post_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_post_detail` (
  `post_detail_id` int(11) NOT NULL AUTO_INCREMENT,
  `post_id` int(11) DEFAULT NULL,
  `content_text` text,
  `photo` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`post_detail_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_post_detail`
--

LOCK TABLES `tbl_post_detail` WRITE;
/*!40000 ALTER TABLE `tbl_post_detail` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_post_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_role`
--

DROP TABLE IF EXISTS `tbl_role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_role` (
  `role_id` int(50) NOT NULL AUTO_INCREMENT,
  `role_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`role_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_role`
--

LOCK TABLES `tbl_role` WRITE;
/*!40000 ALTER TABLE `tbl_role` DISABLE KEYS */;
INSERT INTO `tbl_role` VALUES (1,'a'),(2,'b'),(3,'c');
/*!40000 ALTER TABLE `tbl_role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_role_admin`
--

DROP TABLE IF EXISTS `tbl_role_admin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_role_admin` (
  `role_admin_id` int(50) NOT NULL AUTO_INCREMENT,
  `admin_id` int(50) DEFAULT NULL,
  `role_id` int(50) DEFAULT NULL,
  PRIMARY KEY (`role_admin_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_role_admin`
--

LOCK TABLES `tbl_role_admin` WRITE;
/*!40000 ALTER TABLE `tbl_role_admin` DISABLE KEYS */;
INSERT INTO `tbl_role_admin` VALUES (1,2,3),(2,2,1);
/*!40000 ALTER TABLE `tbl_role_admin` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_user`
--

DROP TABLE IF EXISTS `tbl_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_user` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_name` varchar(255) DEFAULT NULL,
  `user_phone` varchar(255) DEFAULT NULL,
  `user_location` varchar(255) DEFAULT NULL,
  `user_registered_date` datetime DEFAULT '0000-00-00 00:00:00',
  `user_email` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_user`
--

LOCK TABLES `tbl_user` WRITE;
/*!40000 ALTER TABLE `tbl_user` DISABLE KEYS */;
INSERT INTO `tbl_user` VALUES (1,'King April','09450032533','Botahtaung','0000-00-00 00:00:00','obamese.969@gmail.com');
/*!40000 ALTER TABLE `tbl_user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-02-06 15:12:17
