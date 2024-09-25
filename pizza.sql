-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Sze 25. 14:07
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `pizza`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ingredients`
--

CREATE TABLE `ingredients` (
  `ID` int(11) NOT NULL,
  `Name` varchar(15) NOT NULL,
  `Quantity` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `ingredients`
--

INSERT INTO `ingredients` (`ID`, `Name`, `Quantity`) VALUES
(1, 'Mozzarella', 500),
(2, 'Pepperoni', 300),
(3, 'Gomba', 300),
(4, 'Hagyma', 400),
(5, 'Pizzaszósz', 1200),
(6, 'Kukorica', 250),
(7, 'Olívaolaj', 500),
(8, 'Parmezán', 200),
(9, 'Sonka', 300),
(10, 'Ananász', 150),
(11, 'BBQ Szósz', 300),
(12, 'Feta', 200),
(13, 'Gorgonzola', 300),
(18, 'Teszt', 999),
(20, 'asdasd', 0);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `orderitems`
--

CREATE TABLE `orderitems` (
  `ID` int(11) NOT NULL,
  `OrderID` int(11) NOT NULL,
  `PizzaID` int(11) NOT NULL,
  `Quantity` int(3) NOT NULL,
  `Size` enum('24','32','45') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `orderitems`
--

INSERT INTO `orderitems` (`ID`, `OrderID`, `PizzaID`, `Quantity`, `Size`) VALUES
(1, 1, 1, 2, '32'),
(2, 1, 2, 1, '45'),
(3, 2, 3, 1, '24'),
(4, 2, 4, 2, '32'),
(5, 3, 5, 3, '45'),
(6, 3, 6, 2, '32');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `orders`
--

CREATE TABLE `orders` (
  `ID` int(11) NOT NULL,
  `UserID` int(11) NOT NULL,
  `OrderDate` datetime NOT NULL,
  `Status` enum('Baking','On the way','Delivered') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `orders`
--

INSERT INTO `orders` (`ID`, `UserID`, `OrderDate`, `Status`) VALUES
(1, 1, '2024-09-18 22:06:01', 'Baking'),
(2, 2, '2024-09-18 22:13:12', 'Baking'),
(3, 3, '2024-09-18 22:22:59', 'Baking');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `pizzas`
--

CREATE TABLE `pizzas` (
  `ID` int(11) NOT NULL,
  `Name` varchar(25) NOT NULL,
  `Description` varchar(300) NOT NULL,
  `Img` blob DEFAULT NULL,
  `Price` decimal(4,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `pizzas`
--

INSERT INTO `pizzas` (`ID`, `Name`, `Description`, `Img`, `Price`) VALUES
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
-- Tábla szerkezet ehhez a táblához `toppings`
--

CREATE TABLE `toppings` (
  `ID` int(11) NOT NULL,
  `PizzaID` int(11) NOT NULL,
  `IngredientID` int(11) NOT NULL,
  `Quantity` int(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `toppings`
--

INSERT INTO `toppings` (`ID`, `PizzaID`, `IngredientID`, `Quantity`) VALUES
(1, 1, 1, 160),
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
(14, 4, 5, 100),
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
(29, 8, 5, 150),
(32, 1, 8, 69);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `users`
--

CREATE TABLE `users` (
  `ID` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Password` varchar(128) NOT NULL,
  `Salt` text NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Phone` varchar(20) NOT NULL,
  `Address` varchar(250) NOT NULL,
  `IsAdmin` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `users`
--

INSERT INTO `users` (`ID`, `Name`, `Password`, `Salt`, `Email`, `Phone`, `Address`, `IsAdmin`) VALUES
(1, 'Kiss László', 'D388987B89E1DE2BA0781210BCC345A4584980436666A6ED2AC3DDE98483A3221760B3547ED71563710BF913592362888713324B2BB993A555374D48D12E3A73', '63E8C7C62A1BD893E89F80BF9F2AD546596C8680F5B3B4B6C8CFA6E302FFA14E146F904AF53A1E1AB6FEFC320C493DDA6318C70D599D286215BAEFC7AE6E20F3', 'kiss.laszlo@example.com', '0612345678', '1011 Budapest, Múzeum körút 10.', 1),
(2, 'Horváth Júlia', 'C66FCA151F707142AB3E0852D514A192BC01A6E1F93A5D0A553F497260406FF70A9F194D04E4E4AD5C8B3A2E8105FD9DD8130814EB3E116858FF3C2322EBC7E4', 'EC649D53CEED838F9C96F01BA5222BA9582B86A3C97CD2ED6F3B007124C7A6C65985BBAE5F56C1901E27E053DA5AA03837FCE6D9C5A05A973D5B275BFB95E79E', 'horvath.julia@example.com', '0623456789', '1022 Budapest, Batthyány tér 5.', 0),
(3, 'Németh Gábor', 'DF18E5174D173383D142BCE7F35A160A4C49F3B9C606C70CBA4789A9A0F9B5162D689FBB4C7CD663CD3A36AE4F4949B6416E913F7383E85A089D908724EB5AEB', '117841685355C32F7E890F6BDDE448348AB1FE4ED04E14C60706142C0C13349792209D5A66C7DB95BD80C094DE583B874A3568755E0968BA0F67B5A558C268F6', 'nemeth.gabor@example.com', '0634567890', '1033 Budapest, Bécsi út 45.', 0);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `ingredients`
--
ALTER TABLE `ingredients`
  ADD PRIMARY KEY (`ID`);

--
-- A tábla indexei `orderitems`
--
ALTER TABLE `orderitems`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `FK_OrderItems_Orders` (`OrderID`),
  ADD KEY `FK_OrderItems_Pizzas` (`PizzaID`);

--
-- A tábla indexei `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `FK_Orders_Users` (`UserID`);

--
-- A tábla indexei `pizzas`
--
ALTER TABLE `pizzas`
  ADD PRIMARY KEY (`ID`);

--
-- A tábla indexei `toppings`
--
ALTER TABLE `toppings`
  ADD PRIMARY KEY (`ID`) USING BTREE,
  ADD KEY `FK_PizzaIngredients_Pizzas` (`PizzaID`),
  ADD KEY `FK_PizzaIngredients_Ingredients` (`IngredientID`);

--
-- A tábla indexei `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`ID`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `ingredients`
--
ALTER TABLE `ingredients`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT a táblához `orderitems`
--
ALTER TABLE `orderitems`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT a táblához `orders`
--
ALTER TABLE `orders`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT a táblához `pizzas`
--
ALTER TABLE `pizzas`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT a táblához `toppings`
--
ALTER TABLE `toppings`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34;

--
-- AUTO_INCREMENT a táblához `users`
--
ALTER TABLE `users`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `orderitems`
--
ALTER TABLE `orderitems`
  ADD CONSTRAINT `FK_OrderItems_Orders` FOREIGN KEY (`OrderID`) REFERENCES `orders` (`ID`),
  ADD CONSTRAINT `FK_OrderItems_Pizzas` FOREIGN KEY (`PizzaID`) REFERENCES `pizzas` (`ID`);

--
-- Megkötések a táblához `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `FK_Orders_Users` FOREIGN KEY (`UserID`) REFERENCES `users` (`ID`);

--
-- Megkötések a táblához `toppings`
--
ALTER TABLE `toppings`
  ADD CONSTRAINT `FK_PizzaIngredients_Ingredients` FOREIGN KEY (`IngredientID`) REFERENCES `ingredients` (`ID`),
  ADD CONSTRAINT `FK_PizzaIngredients_Pizzas` FOREIGN KEY (`PizzaID`) REFERENCES `pizzas` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
