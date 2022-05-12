-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: localhost    Database: gallery_db
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
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20220318055119_migr','5.0.14');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `authors`
--

DROP TABLE IF EXISTS `authors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `authors` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(200) DEFAULT NULL,
  `Bio` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `authors`
--

LOCK TABLES `authors` WRITE;
/*!40000 ALTER TABLE `authors` DISABLE KEYS */;
INSERT INTO `authors` VALUES (1,'Клод Моне','Великий импрессионист, всю свою жизнь рисовавший картины. Художник является основателем и теоретиком французского импрессионизма, которому следовал на протяжении всего творческого пути. Живописная манера Моне в импрессионизме считается классической. Для нее характерны раздельные мазки чистого цвета, создающие богатство света при передаче воздушной среды. В своих картинах художник стремился передать сиюминутное впечатление от происходящего.'),(2,'Рафаэль Санти','Итальянский художник эпохи Ренессанса, гениальный график и мастер архитектурных решений, Рафаэль Санти впитал опыт умбрийской школы живописи. В его полотнах, как в зеркале, отразились идеалы Возрождения. Мир стал добрее и чище, когда на него посмотрели глаза рафаэлевских мадонн – Сикстинской, Конестабиле, Пасадинской, Орлеанской. '),(3,'Микеланджело','Признанный гений эпохи Возрождения, который принес неоценимый вклад в сокровищницу мировой культуры.'),(4,'Леонардо да Винчи','Это один из самых гениальных и загадочных людей за всю историю человечества. Изобретатель, писатель, музыкант… но известен нам, прежде всего, как художник. Да Винчи был признан еще при жизни: владел собственной мастерской, писал портреты итальянской знати и расписывал стены храмов. Имя мастера часто фигурирует в кино и литературе, поэтому его хорошо знают даже подростки. '),(5,'Пабло Пикассо','Имя этого художника давно стало нарицательным. Живописца отождествляют с гениальностью, мастерством художника, неординарностью. Прежде всего, он ассоциируется с кубизмом. Однажды Поль Сезанн посоветовал Пикассо рассматривать натуру с точки зрения геометрических фигур: совокупности квадратов, треугольников и ромбов. Конечно, он имел в виду работу над базисом картины. Но Пикассо воспринял это буквально. С тех пор все работы автора имели строгие геометрические формы.'),(6,'Сальвадор Дали','Гений, психопат, фрик — его называли по-разному. Ясно одно: настолько эпатажный и эксцентричный человек рождается нечасто. Сальвадор Дали отличался нестандартным мышлением и тяготел к теории психоанализа Фрейда.'),(7,'Клод Моне','Если разговор заходит про импрессионизм, с уверенностью вспомните Клода Моне. Он действительно видел переменчивость и красоту природы в деталях. Мастер выделился уникальной техникой передачи форм и цвета.'),(8,'Сандро Боттичелли','Боттичелли творил во Флоренции — колыбели эпохи Возрождения. Он был востребованным художником, который писал портреты для знати. Талант мастера оценила знаменитая семья Медичи, члены которой нередко становились правителями Флоренции.'),(9,'Фрида Кало де Ривера','Творчество мексиканской художницы трудно с чем-то спутать. Основа ее искусства — автопортреты и элементы мексиканской культуры. Фрида много путешествовала, по это все больше пробуждало в ней любовь к Родине. Она стала носить мексиканские народные костюмы в повседневной жизни и рождать самобытные сюжеты.'),(10,'Джексон Поллок','Его инструментами становились самые необычные предметы: ножи, палочки, осколки стекла и собственные руки. Мастер не закреплял холст на мольберт, а чаще всего просто ложил на пол. Так он ощущал себя “внутри” картины и мог подходить к ней с разных сторон.');
/*!40000 ALTER TABLE `authors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employees`
--

DROP TABLE IF EXISTS `employees`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employees` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `Login1` varchar(50) DEFAULT NULL,
  `Passw1` text,
  `Right` int NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employees`
--

LOCK TABLES `employees` WRITE;
/*!40000 ALTER TABLE `employees` DISABLE KEYS */;
INSERT INTO `employees` VALUES (1,'Осипов Денис Евгеньевич','qwe','asd',0),(2,'Самойлов Анатолий Сергеевич','asd','asd1',0),(3,'Яковлева Татьяна Алексеевна','hjk','jkl',3),(4,'Васиьльев Гаврил Ионович','yui','uio',2),(5,'Кардашевский Николай Дмитриевич','jhhf','fdjkjkdf',1),(6,'Захаров Вячеслав Анатольевич','hfdhdfj','jfdfj',3),(7,'Дьячковский Аман Николаевич','hrfhfh','jfrjrf',1),(8,'Павлов Прокопий Петрович','gdfghjh','jhjhwjh',2),(9,'Полянский Илья Игоревич','bffh','djdjjd',3),(10,'Павлов Вадим Июльевич','hdhdeh','djdj',2),(11,'\r\nБудикин Артур Евсеевич','tu4a','GFGF',2);
/*!40000 ALTER TABLE `employees` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `genres`
--

DROP TABLE IF EXISTS `genres`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `genres` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `genres`
--

LOCK TABLES `genres` WRITE;
/*!40000 ALTER TABLE `genres` DISABLE KEYS */;
INSERT INTO `genres` VALUES (1,'Портрет'),(2,'Пейзаж'),(3,'Марина'),(4,'Исторический'),(5,'Батальный'),(6,'Анималистика'),(7,'Бытовой'),(8,'Натюрморт'),(9,'Архитектурный'),(10,'Ню'),(11,'Абстракционизм');
/*!40000 ALTER TABLE `genres` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `journals`
--

DROP TABLE IF EXISTS `journals`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `journals` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Oper_date` datetime NOT NULL,
  `PaintingId` int NOT NULL,
  `EmployeeId` int NOT NULL,
  `ToId` int NOT NULL,
  `FromId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Journals_EmployeeId` (`EmployeeId`),
  KEY `IX_Journals_FromId` (`FromId`),
  KEY `IX_Journals_PaintingId` (`PaintingId`),
  KEY `IX_Journals_ToId` (`ToId`),
  CONSTRAINT `FK_Journals_Employees_EmployeeId` FOREIGN KEY (`EmployeeId`) REFERENCES `employees` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Journals_Paintings_PaintingId` FOREIGN KEY (`PaintingId`) REFERENCES `paintings` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Journals_Places_FromId` FOREIGN KEY (`FromId`) REFERENCES `places` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Journals_Places_ToId` FOREIGN KEY (`ToId`) REFERENCES `places` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `journals`
--

LOCK TABLES `journals` WRITE;
/*!40000 ALTER TABLE `journals` DISABLE KEYS */;
/*!40000 ALTER TABLE `journals` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `paintings`
--

DROP TABLE IF EXISTS `paintings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `paintings` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `Year` int NOT NULL,
  `Price` int NOT NULL,
  `Status` int NOT NULL,
  `AuthorId` int NOT NULL,
  `GenreId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Paintings_AuthorId` (`AuthorId`),
  KEY `IX_Paintings_GenreId` (`GenreId`),
  CONSTRAINT `FK_Paintings_Authors_AuthorId` FOREIGN KEY (`AuthorId`) REFERENCES `authors` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Paintings_Genres_GenreId` FOREIGN KEY (`GenreId`) REFERENCES `genres` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `paintings`
--

LOCK TABLES `paintings` WRITE;
/*!40000 ALTER TABLE `paintings` DISABLE KEYS */;
INSERT INTO `paintings` VALUES (1,'Железнодорожный мост в Аржантее',1873,41000000,2,1,9),(2,'Водяные лилии',1905,54000000,2,1,3),(3,'Стога сена',1891,110000000,2,1,2),(4,'Сикстинская мадонна',1512,60000000,2,2,1),(5,'Афинская школа, фреска',1511,55000000,2,2,1),(6,'Преображение, дерево, темпера',1520,62000000,2,2,1),(7,'Любительница абсента',1901,40000000,2,5,1),(8,'Герника',1937,35000000,2,5,11),(9,'Старый еврей с мальчиком',1903,38000000,2,5,1),(10,'Постоянство памяти',1931,120000000,2,6,11),(11,'Сон',1937,65000000,2,6,11),(12,'Слоны',1948,50000000,2,6,11);
/*!40000 ALTER TABLE `paintings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `places`
--

DROP TABLE IF EXISTS `places`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `places` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(200) DEFAULT NULL,
  `Discriminator` text NOT NULL,
  `Place` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `places`
--

LOCK TABLES `places` WRITE;
/*!40000 ALTER TABLE `places` DISABLE KEYS */;
INSERT INTO `places` VALUES (1,'Выставочный ЗАЛ Национального Художественного Музея','.','ул. Кирова, 12'),(2,'Национальный худoжественный музей','.',' ул. Кирова, 9'),(3,'Картинная галерея академика Осипова А.О.','.','ул. Хабарова, 27'),(4,'Сокровищница Республики Саха (Якутия), музей','.','ул. Кирова, 12'),(5,'Галерея зарубежного искусства им. М. Ф. Габышева','.','ул. Петровского, 4'),(6,'Ургэл, арт-галерея','.','ул. Лермонтова, 35/1'),(7,'Art гараж, художественный салон местных художников','.','ул. Ойунского, 24/2г'),(8,'Исторический парк \"Россия - моя история\"','.','улица Ксенофонта Уткина, 5'),(9,'Музей ретротехники','.','ул. Чернышевского, 106Д'),(10,'Центр культуры и современного искусства им. Ю.А. Гагарина','.','ул. Можайского, 25');
/*!40000 ALTER TABLE `places` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-05-12 12:39:29
