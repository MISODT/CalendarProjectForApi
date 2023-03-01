-- phpMyAdmin SQL Dump
-- version 5.1.1deb5ubuntu1
-- https://www.phpmyadmin.net/
--
-- Хост: localhost:3306
-- Время создания: Фев 24 2023 г., 15:29
-- Версия сервера: 10.6.12-MariaDB-0ubuntu0.22.04.1
-- Версия PHP: 8.1.2-1ubuntu2.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `calendardatabase`
--

-- --------------------------------------------------------

--
-- Структура таблицы `Events`
--

CREATE TABLE `Events` (
  `Id` int(11) NOT NULL,
  `EventTheme` varchar(100) DEFAULT NULL,
  `EventDate` varchar(50) DEFAULT NULL,
  `UserId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `Events`
--

INSERT INTO `Events` (`Id`, `EventTheme`, `EventDate`, `UserId`) VALUES
(36, 'Собеседование', '28.02.2023', 3),
(39, 'Работа', '26.02.2023', 15),
(42, '1 Февраля', '01.02.2023', 1);

-- --------------------------------------------------------

--
-- Структура таблицы `Users`
--

CREATE TABLE `Users` (
  `Id` int(11) NOT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `UserLogin` varchar(50) DEFAULT NULL,
  `UserPassword` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `Users`
--

INSERT INTO `Users` (`Id`, `Name`, `UserLogin`, `UserPassword`) VALUES
(1, 'Вадим', 'vadimsolodkov', '1234567890'),
(2, 'Егор', 'egorbasharov', '1234567890'),
(3, 'Алан', 'alanvaliev', '1234567890'),
(4, 'Кирилл', 'kirilldrozdov', '1234567890'),
(5, 'Сергей', 'sergeypak', '1234567890'),
(6, 'Валя', 'valentinakarpova', '1234567890'),
(7, 'nikitagermanov', 'nikitagermanov', '1234567890'),
(8, 'juliamentova', 'juliamentova', '1234567890'),
(14, 'Дмитрий', 'dmitriypopov', '1234567890'),
(15, 'Роман', 'romanbadoev', '1234567890'),
(16, 'Анастасия', 'anastasiashukina', '1234567890');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `Events`
--
ALTER TABLE `Events`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `UserId` (`UserId`);

--
-- Индексы таблицы `Users`
--
ALTER TABLE `Users`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `Events`
--
ALTER TABLE `Events`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=44;

--
-- AUTO_INCREMENT для таблицы `Users`
--
ALTER TABLE `Users`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `Events`
--
ALTER TABLE `Events`
  ADD CONSTRAINT `Events_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
