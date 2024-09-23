-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 20, 2024 at 01:02 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `pizza`
--

--
-- Table structure for table `ingredients`
--

CREATE TABLE `ingredients` (
  `IngredientID` int(11) NOT NULL,
  `Name` varchar(15) NOT NULL,
  `Quantity` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- Dumping data for table `ingredients`
--

INSERT INTO `ingredients` (`IngredientID`, `Name`, `Quantity`) VALUES
(1, 'Mozzarella', 500),
(2, 'Pepperoni', 300),
(3, 'Gomba', 200),
(4, 'Hagyma', 150),
(5, 'Pizzaszósz', 1000),
(6, 'Kukorica', 250),
(7, 'Olívaolaj', 500),
(8, 'Parmezán', 200),
(9, 'Sonka', 300),
(10, 'Ananász', 150),
(11, 'BBQ Szósz', 300),
(12, 'Feta', 200),
(13, 'Gorgonzola', 200);

-- --------------------------------------------------------

--
-- Table structure for table `orderitems`
--

CREATE TABLE `orderitems` (
  `OrderItemID` int(11) NOT NULL,
  `OrderID` int(11) NOT NULL,
  `PizzaID` int(11) NOT NULL,
  `Quantity` int(3) NOT NULL,
  `Size` enum('24','32','45') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- Dumping data for table `orderitems`
--

INSERT INTO `orderitems` (`OrderItemID`, `OrderID`, `PizzaID`, `Quantity`, `Size`) VALUES
(1, 1, 1, 2, '32'),
(2, 1, 2, 1, '45'),
(3, 2, 3, 1, '24'),
(4, 2, 4, 2, '32'),
(5, 3, 5, 3, '45'),
(6, 3, 6, 2, '32');

--
-- Table structure for table `orders`
--

CREATE TABLE `orders` (
  `OrderID` int(11) NOT NULL,
  `UserID` int(11) NOT NULL,
  `OrderDate` datetime NOT NULL,
  `Status` enum('Baking','On the way','Delivered') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- Dumping data for table `orders`
--

INSERT INTO `orders` (`OrderID`, `UserID`, `OrderDate`, `Status`) VALUES
(1, 1, '2024-09-18 22:06:01', 'Baking'),
(2, 2, '2024-09-18 22:13:12', 'Baking'),
(3, 3, '2024-09-18 22:22:59', 'Baking');

-- --------------------------------------------------------

--
-- Table structure for table `pizzas`
--

CREATE TABLE `pizzas` (
  `PizzaID` int(11) NOT NULL,
  `Name` varchar(25) NOT NULL,
  `Description` varchar(300) NOT NULL,
  `Img` blob DEFAULT NULL,
  `Price` decimal(4,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- Dumping data for table `pizzas`
--

INSERT INTO `pizzas` (`PizzaID`, `Name`, `Description`, `Img`, `Price`) VALUES
(1, 'Margherita', 'Hagyományos pizza friss mozzarella sajttal, bazsalikommal és pizzaszósszal.', NULL, 1200),
(2, 'Pepperoni', 'Pizza gazdag pepperonival, mozzarella sajttal és ízletes pizzaszósszal.', NULL, 1500),
(3, 'Veggie', 'Vegetáriánus pizza gombával, hagymával, kukoricával és mozzarella sajttal.', NULL, 1400),
(4, 'Hawaii', 'Pizza ananásszal, sonkával és mozzarella sajttal, édes-savanyú ízélménnyel.', NULL, 1600),
(5, 'BBQ Chicken', 'Pizza grillezett csirkehússal, BBQ szósszal, vöröshagymával és mozzarella sajttal.', NULL, 1700),
(6, '4 Sajtos', 'Pizza négyféle sajttal: mozzarella, parmezán, gorgonzola és cheddar.', NULL, 1800),
(7, 'Mediterrán', 'Pizza olívaolajjal, szárított paradicsommal, fekete olívával és feta sajttal.', NULL, 1500),
(8, 'Rántott Gomba', 'Pizza rántott gombával, sajttal, és ízletes pizzaszósszal.', NULL, 1400);

-- --------------------------------------------------------

--
-- Table structure for table `toppings`
--

CREATE TABLE `toppings` (
  `ToppingID` int(11) NOT NULL,
  `PizzaID` int(11) NOT NULL,
  `IngredientID` int(11) NOT NULL,
  `Quantity` int(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- Dumping data for table `toppings`
--

INSERT INTO `toppings` (`ToppingID`, `PizzaID`, `IngredientID`, `Quantity`) VALUES
(1, 1, 1, 150),
(2, 1, 5, 200),
(3, 2, 1, 150),
(4, 2, 2, 100),
(5, 2, 5, 150),
(6, 3, 1, 150),
(7, 3, 3, 100),
(8, 3, 4, 50),
(9, 3, 6, 100),
(10, 3, 5, 150),
(11, 4, 1, 150),
(12, 4, 9, 100),
(13, 4, 10, 100),
(14, 4, 5, 150),
(15, 5, 1, 150),
(16, 5, 12, 100),
(17, 5, 4, 50),
(18, 5, 5, 150),
(19, 6, 1, 100),
(20, 6, 7, 50),
(21, 6, 8, 50),
(22, 6, 2, 50),
(23, 7, 1, 100),
(24, 7, 13, 100),
(25, 7, 5, 150),
(26, 7, 6, 50),
(27, 8, 1, 150),
(28, 8, 3, 100),
(29, 8, 5, 150);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `UserID` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Password` varchar(20) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Phone` varchar(20) NOT NULL,
  `Address` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`UserID`, `Name`, `Password`, `Email`, `Phone`, `Address`) VALUES
(1, 'Kiss László', 'laszlo123', 'kiss.laszlo@example.com', '0612345678', '1011 Budapest, Múzeum körút 10.'),
(2, 'Horváth Júlia', 'julia456', 'horvath.julia@example.com', '0623456789', '1022 Budapest, Batthyány tér 5.'),
(3, 'Németh Gábor', 'gabor789', 'nemeth.gabor@example.com', '0634567890', '1033 Budapest, Bécsi út 45.'),
(4, 'Szűcs Zoltán', 'zoltan321', 'szucs.zoltan@example.com', '0645678901', '1044 Budapest, Váci út 120.'),
(5, 'Molnár Erika', 'erika654', 'molnar.erika@example.com', '0656789012', '1055 Budapest, Károly körút 5.'),
(6, 'Farkas Péter', 'peter987', 'farkas.peter@example.com', '0667890123', '1066 Budapest, Teréz körút 8.');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `ingredients`
--
ALTER TABLE `ingredients`
  ADD PRIMARY KEY (`IngredientID`);

--
-- Indexes for table `orderitems`
--
ALTER TABLE `orderitems`
  ADD PRIMARY KEY (`OrderItemID`),
  ADD KEY `FK_OrderItems_Orders` (`OrderID`),
  ADD KEY `FK_OrderItems_Pizzas` (`PizzaID`);

--
-- Indexes for table `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`OrderID`),
  ADD KEY `FK_Orders_Users` (`UserID`);

--
-- Indexes for table `pizzas`
--
ALTER TABLE `pizzas`
  ADD PRIMARY KEY (`PizzaID`);

--
-- Indexes for table `toppings`
--
ALTER TABLE `toppings`
  ADD PRIMARY KEY (`ToppingID`) USING BTREE,
  ADD KEY `FK_PizzaIngredients_Pizzas` (`PizzaID`),
  ADD KEY `FK_PizzaIngredients_Ingredients` (`IngredientID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`UserID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `ingredients`
--
ALTER TABLE `ingredients`
  MODIFY `IngredientID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `orderitems`
--
ALTER TABLE `orderitems`
  MODIFY `OrderItemID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `orders`
--
ALTER TABLE `orders`
  MODIFY `OrderID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `pizzas`
--
ALTER TABLE `pizzas`
  MODIFY `PizzaID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `toppings`
--
ALTER TABLE `toppings`
  MODIFY `ToppingID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=30;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `UserID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `orderitems`
--
ALTER TABLE `orderitems`
  ADD CONSTRAINT `FK_OrderItems_Orders` FOREIGN KEY (`OrderID`) REFERENCES `orders` (`OrderID`),
  ADD CONSTRAINT `FK_OrderItems_Pizzas` FOREIGN KEY (`PizzaID`) REFERENCES `pizzas` (`PizzaID`);

--
-- Constraints for table `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `FK_Orders_Users` FOREIGN KEY (`UserID`) REFERENCES `users` (`UserID`);

--
-- Constraints for table `toppings`
--
ALTER TABLE `toppings`
  ADD CONSTRAINT `FK_PizzaIngredients_Ingredients` FOREIGN KEY (`IngredientID`) REFERENCES `ingredients` (`IngredientID`),
  ADD CONSTRAINT `FK_PizzaIngredients_Pizzas` FOREIGN KEY (`PizzaID`) REFERENCES `pizzas` (`PizzaID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
