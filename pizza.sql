-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 18, 2024 at 12:48 PM
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

-- --------------------------------------------------------

--
-- Table structure for table `ingredients`
--

CREATE TABLE `ingredients` (
  `ID` int(11) NOT NULL,
  `Name` varchar(15) DEFAULT NULL,
  `Amount` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Table structure for table `orders`
--

CREATE TABLE `orders` (
  `UserId` int(11) DEFAULT NULL,
  `ProductId` int(11) DEFAULT NULL,
  `Count` int(2) DEFAULT NULL,
  `Date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Table structure for table `pizzaingredients`
--

CREATE TABLE `pizzaingredients` (
  `PizzaId` int(11) NOT NULL,
  `IngredientId` int(11) DEFAULT NULL,
  `Amount` int(2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Table structure for table `pizzas`
--

CREATE TABLE `pizzas` (
  `ID` int(11) NOT NULL,
  `Name` varchar(25) DEFAULT NULL,
  `Description` varchar(300) DEFAULT NULL,
  `Img` blob DEFAULT NULL,
  `Price` int(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- Dumping data for table `pizzas`
--

INSERT INTO `pizzas` (`ID`, `Name`, `Description`, `Img`, `Price`) VALUES
(1, 'Margherita', 'Klasszikus pizza friss mozzarella sajttal, paradicsommal és bazsalikommal.', NULL, 12),
(2, 'Pepperoni', 'Fűszeres pepperoni szeletek mozzarella sajton.', NULL, 14),
(3, 'BBQ Csirke', 'Grillezett csirke, BBQ szósz és vöröshagyma mozzarella sajton.', NULL, 15),
(4, 'Vegetáriánus', 'Tele van paprikával, hagymával, gombával és olívabogyóval.', NULL, 13),
(5, 'Hawaiian', 'Sonka, ananász és mozzarella édes és sós ízélményért.', NULL, 14),
(6, 'Four Cheese', 'Mozzarella, gorgonzola, parmezán és cheddar sajt egyedi keveréke.', NULL, 16),
(7, 'Meat Lovers', 'Bőségesen gazdag húsokkal: sonka, pepperoni, kolbász és bacon.', NULL, 18),
(8, 'Pesto Veggie', 'Friss zöldségek és pesto szósz a mozzarella ágyon.', NULL, 14),
(9, 'Buffalo Chicken', 'Fűszeres csirke, kék sajt és zeller friss salátával.', NULL, 15),
(10, 'Mediterranean', 'Feta sajt, olívabogyó, paprika és friss bazsalikom.', NULL, 13);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `ID` int(11) NOT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `Password` varchar(20) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Phone` varchar(20) DEFAULT NULL,
  `Address` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`ID`, `Name`, `Password`, `Email`, `Phone`, `Address`) VALUES
(1, 'Alice Smith', 'password123', 'alice.smith@example.com', '123-456-7890', '123 Elm St, Springfield'),
(2, 'Bob Johnson', 'securepass', 'bob.johnson@example.com', '234-567-8901', '456 Oak St, Springfield'),
(3, 'Charlie Brown', 'mypassword', 'charlie.brown@example.com', '345-678-9012', '789 Pine St, Springfield'),
(4, 'Diana Prince', 'wonderpass', 'diana.prince@example.com', '456-789-0123', '321 Maple St, Springfield'),
(5, 'Edward Norton', 'edwardpass', 'edward.norton@example.com', '567-890-1234', '654 Cedar St, Springfield');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `ingredients`
--
ALTER TABLE `ingredients`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `orders`
--
ALTER TABLE `orders`
  ADD KEY `UserId` (`UserId`),
  ADD KEY `ProductId` (`ProductId`);

--
-- Indexes for table `pizzaingredients`
--
ALTER TABLE `pizzaingredients`
  ADD PRIMARY KEY (`PizzaId`),
  ADD KEY `IngredientId` (`IngredientId`);

--
-- Indexes for table `pizzas`
--
ALTER TABLE `pizzas`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`ID`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `users` (`ID`),
  ADD CONSTRAINT `orders_ibfk_2` FOREIGN KEY (`ProductId`) REFERENCES `pizzas` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `pizzaingredients`
--
ALTER TABLE `pizzaingredients`
  ADD CONSTRAINT `pizzaingredients_ibfk_1` FOREIGN KEY (`PizzaId`) REFERENCES `pizzas` (`ID`),
  ADD CONSTRAINT `pizzaingredients_ibfk_2` FOREIGN KEY (`IngredientId`) REFERENCES `ingredients` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
