-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         8.0.30 - MySQL Community Server - GPL
-- SO del servidor:              Win64
-- HeidiSQL Versión:             12.1.0.6537
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para proyecto-agendamiento-valeria
CREATE DATABASE IF NOT EXISTS `proyecto-agendamiento-valeria` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `proyecto-agendamiento-valeria`;

-- Volcando estructura para tabla proyecto-agendamiento-valeria.accion
CREATE TABLE IF NOT EXISTS `accion` (
  `idaccion` int NOT NULL AUTO_INCREMENT,
  `fk_rol` int NOT NULL,
  `dk_permisos` int NOT NULL,
  PRIMARY KEY (`idaccion`),
  KEY `x_idx` (`fk_rol`),
  KEY `x_idx1` (`dk_permisos`),
  CONSTRAINT `` FOREIGN KEY (`fk_rol`) REFERENCES `rol` (`id_rol`) ON DELETE CASCADE,
  CONSTRAINT `x` FOREIGN KEY (`dk_permisos`) REFERENCES `permisos` (`idpermisos`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla proyecto-agendamiento-valeria.accion: ~21 rows (aproximadamente)
INSERT IGNORE INTO `accion` (`idaccion`, `fk_rol`, `dk_permisos`) VALUES
	(2, 2, 2),
	(3, 3, 3),
	(4, 3, 4),
	(7, 1, 7),
	(8, 1, 8),
	(9, 1, 9),
	(10, 1, 10),
	(11, 1, 11),
	(12, 1, 12),
	(13, 1, 13),
	(14, 2, 16),
	(15, 3, 16),
	(16, 1, 14),
	(17, 1, 15),
	(18, 1, 16),
	(21, 3, 18),
	(22, 2, 1),
	(23, 2, 19),
	(25, 3, 20),
	(26, 2, 20),
	(27, 1, 21);

-- Volcando estructura para tabla proyecto-agendamiento-valeria.agendamiento_detalle
CREATE TABLE IF NOT EXISTS `agendamiento_detalle` (
  `idagenda_detalle` int NOT NULL AUTO_INCREMENT,
  `hora_inicio_asesoria` datetime NOT NULL,
  `contador_asesoria` int DEFAULT NULL,
  `observaciones` varchar(400) DEFAULT NULL,
  `horario_fk` int NOT NULL,
  `estudiante_fk` int DEFAULT NULL,
  `estado` enum('V','S','T') NOT NULL,
  `asistencia` tinyint DEFAULT NULL,
  PRIMARY KEY (`idagenda_detalle`),
  KEY `horario_fk_idx` (`horario_fk`),
  KEY `estudiante_fk_idx` (`estudiante_fk`),
  CONSTRAINT `estudiante_fk` FOREIGN KEY (`estudiante_fk`) REFERENCES `usuario` (`id_usuario`) ON DELETE CASCADE,
  CONSTRAINT `horario_fk` FOREIGN KEY (`horario_fk`) REFERENCES `horario` (`idhorario`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=968 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla proyecto-agendamiento-valeria.agendamiento_detalle: ~271 rows (aproximadamente)
INSERT IGNORE INTO `agendamiento_detalle` (`idagenda_detalle`, `hora_inicio_asesoria`, `contador_asesoria`, `observaciones`, `horario_fk`, `estudiante_fk`, `estado`, `asistencia`) VALUES
	(614, '2022-07-01 05:00:00', NULL, NULL, 29, NULL, 'T', NULL),
	(615, '2022-07-01 05:30:00', NULL, NULL, 29, NULL, 'T', NULL),
	(616, '2022-07-08 05:00:00', NULL, NULL, 29, NULL, 'T', NULL),
	(617, '2022-07-08 05:30:00', NULL, '', 29, 6, 'S', 1),
	(618, '2022-07-15 05:00:00', NULL, NULL, 29, NULL, 'V', NULL),
	(619, '2022-07-15 05:30:00', NULL, NULL, 29, NULL, 'V', NULL),
	(620, '2022-07-22 05:00:00', NULL, NULL, 29, NULL, 'V', NULL),
	(621, '2022-07-22 05:30:00', NULL, NULL, 29, 5, 'S', NULL),
	(622, '2022-06-28 14:00:00', NULL, NULL, 30, NULL, 'T', NULL),
	(623, '2022-06-28 14:30:00', NULL, NULL, 30, NULL, 'T', NULL),
	(624, '2022-06-28 15:00:00', NULL, NULL, 30, NULL, 'T', NULL),
	(625, '2022-06-28 15:30:00', NULL, NULL, 30, NULL, 'T', NULL),
	(626, '2022-06-28 16:00:00', NULL, NULL, 30, NULL, 'T', NULL),
	(627, '2022-06-28 16:30:00', NULL, NULL, 30, NULL, 'T', NULL),
	(628, '2022-06-28 17:00:00', NULL, NULL, 30, NULL, 'T', NULL),
	(629, '2022-06-28 17:30:00', NULL, NULL, 30, NULL, 'T', NULL),
	(630, '2022-07-05 14:00:00', NULL, 'muy bien', 30, 5, 'S', 1),
	(631, '2022-07-05 14:30:00', NULL, NULL, 30, NULL, 'T', NULL),
	(632, '2022-07-05 15:00:00', NULL, NULL, 30, NULL, 'T', NULL),
	(633, '2022-07-05 15:30:00', NULL, NULL, 30, NULL, 'T', NULL),
	(634, '2022-07-05 16:00:00', NULL, NULL, 30, NULL, 'T', NULL),
	(635, '2022-07-05 16:30:00', NULL, NULL, 30, NULL, 'T', NULL),
	(636, '2022-07-05 17:00:00', NULL, NULL, 30, NULL, 'T', NULL),
	(637, '2022-07-05 17:30:00', NULL, NULL, 30, NULL, 'T', NULL),
	(638, '2022-07-12 14:00:00', NULL, NULL, 30, NULL, 'V', NULL),
	(639, '2022-07-12 14:30:00', NULL, NULL, 30, NULL, 'V', NULL),
	(640, '2022-07-12 15:00:00', NULL, NULL, 30, NULL, 'V', NULL),
	(641, '2022-07-12 15:30:00', NULL, NULL, 30, NULL, 'V', NULL),
	(642, '2022-07-12 16:00:00', NULL, NULL, 30, NULL, 'V', NULL),
	(643, '2022-07-12 16:30:00', NULL, NULL, 30, NULL, 'V', NULL),
	(644, '2022-07-12 17:00:00', NULL, NULL, 30, NULL, 'V', NULL),
	(645, '2022-07-12 17:30:00', NULL, NULL, 30, NULL, 'V', NULL),
	(646, '2022-07-19 14:00:00', NULL, NULL, 30, NULL, 'V', NULL),
	(647, '2022-07-19 14:30:00', NULL, NULL, 30, NULL, 'V', NULL),
	(648, '2022-07-19 15:00:00', NULL, NULL, 30, NULL, 'V', NULL),
	(649, '2022-07-19 15:30:00', NULL, NULL, 30, NULL, 'V', NULL),
	(650, '2022-07-19 16:00:00', NULL, NULL, 30, NULL, 'V', NULL),
	(651, '2022-07-19 16:30:00', NULL, NULL, 30, NULL, 'V', NULL),
	(652, '2022-07-19 17:00:00', NULL, NULL, 30, NULL, 'V', NULL),
	(653, '2022-07-19 17:30:00', NULL, NULL, 30, NULL, 'V', NULL),
	(654, '2022-07-26 14:00:00', NULL, NULL, 30, NULL, 'V', NULL),
	(655, '2022-07-26 14:30:00', NULL, NULL, 30, NULL, 'V', NULL),
	(656, '2022-07-26 15:00:00', NULL, NULL, 30, NULL, 'V', NULL),
	(657, '2022-07-26 15:30:00', NULL, NULL, 30, NULL, 'V', NULL),
	(658, '2022-07-26 16:00:00', NULL, NULL, 30, NULL, 'V', NULL),
	(659, '2022-07-26 16:30:00', NULL, NULL, 30, NULL, 'V', NULL),
	(660, '2022-07-26 17:00:00', NULL, NULL, 30, NULL, 'V', NULL),
	(661, '2022-07-26 17:30:00', NULL, NULL, 30, NULL, 'V', NULL),
	(662, '2022-07-01 08:00:00', NULL, NULL, 31, NULL, 'T', NULL),
	(663, '2022-07-01 08:30:00', NULL, NULL, 31, NULL, 'T', NULL),
	(664, '2022-07-01 09:00:00', NULL, NULL, 31, NULL, 'T', NULL),
	(665, '2022-07-01 09:30:00', NULL, NULL, 31, NULL, 'T', NULL),
	(666, '2022-07-01 10:00:00', NULL, NULL, 31, NULL, 'T', NULL),
	(667, '2022-07-01 10:30:00', NULL, NULL, 31, NULL, 'T', NULL),
	(668, '2022-07-01 11:00:00', NULL, NULL, 31, NULL, 'T', NULL),
	(669, '2022-07-01 11:30:00', NULL, NULL, 31, NULL, 'T', NULL),
	(670, '2022-07-08 08:00:00', NULL, NULL, 31, NULL, 'T', NULL),
	(671, '2022-07-08 08:30:00', NULL, NULL, 31, 5, 'S', NULL),
	(672, '2022-07-08 09:00:00', NULL, NULL, 31, NULL, 'T', NULL),
	(673, '2022-07-08 09:30:00', NULL, NULL, 31, NULL, 'T', NULL),
	(674, '2022-07-08 10:00:00', NULL, NULL, 31, NULL, 'T', NULL),
	(675, '2022-07-08 10:30:00', NULL, NULL, 31, NULL, 'T', NULL),
	(676, '2022-07-08 11:00:00', NULL, NULL, 31, NULL, 'T', NULL),
	(677, '2022-07-08 11:30:00', NULL, NULL, 31, NULL, 'T', NULL),
	(678, '2022-07-15 08:00:00', NULL, NULL, 31, NULL, 'V', NULL),
	(679, '2022-07-15 08:30:00', NULL, NULL, 31, NULL, 'V', NULL),
	(680, '2022-07-15 09:00:00', NULL, NULL, 31, NULL, 'V', NULL),
	(681, '2022-07-15 09:30:00', NULL, NULL, 31, NULL, 'V', NULL),
	(682, '2022-07-15 10:00:00', NULL, NULL, 31, NULL, 'V', NULL),
	(683, '2022-07-15 10:30:00', NULL, NULL, 31, NULL, 'V', NULL),
	(684, '2022-07-15 11:00:00', NULL, NULL, 31, NULL, 'V', NULL),
	(685, '2022-07-15 11:30:00', NULL, NULL, 31, NULL, 'V', NULL),
	(686, '2022-07-22 08:00:00', NULL, NULL, 31, NULL, 'V', NULL),
	(687, '2022-07-22 08:30:00', NULL, NULL, 31, NULL, 'V', NULL),
	(688, '2022-07-22 09:00:00', NULL, NULL, 31, NULL, 'V', NULL),
	(689, '2022-07-22 09:30:00', NULL, NULL, 31, NULL, 'V', NULL),
	(690, '2022-07-22 10:00:00', NULL, NULL, 31, NULL, 'V', NULL),
	(691, '2022-07-22 10:30:00', NULL, NULL, 31, NULL, 'V', NULL),
	(692, '2022-07-22 11:00:00', NULL, NULL, 31, NULL, 'V', NULL),
	(693, '2022-07-22 11:30:00', NULL, NULL, 31, 5, 'S', NULL),
	(694, '2022-06-30 17:00:00', NULL, NULL, 32, NULL, 'T', NULL),
	(695, '2022-06-30 17:30:00', NULL, NULL, 32, NULL, 'T', NULL),
	(696, '2022-07-07 17:00:00', NULL, NULL, 32, 5, 'S', NULL),
	(697, '2022-07-07 17:30:00', NULL, NULL, 32, NULL, 'T', NULL),
	(698, '2022-07-14 17:00:00', NULL, NULL, 32, NULL, 'V', NULL),
	(699, '2022-07-14 17:30:00', NULL, NULL, 32, 5, 'S', NULL),
	(700, '2022-07-21 17:00:00', NULL, NULL, 32, NULL, 'V', NULL),
	(701, '2022-07-21 17:30:00', NULL, NULL, 32, NULL, 'V', NULL),
	(702, '2022-07-28 17:00:00', NULL, NULL, 32, 5, 'S', NULL),
	(703, '2022-07-28 17:30:00', NULL, NULL, 32, 5, 'S', NULL),
	(787, '2022-07-13 06:00:00', NULL, NULL, 38, NULL, 'V', NULL),
	(788, '2022-07-13 06:30:00', NULL, NULL, 38, NULL, 'V', NULL),
	(789, '2022-07-13 07:00:00', NULL, NULL, 38, NULL, 'V', NULL),
	(790, '2022-07-13 07:30:00', NULL, NULL, 38, NULL, 'V', NULL),
	(791, '2022-07-13 08:00:00', NULL, NULL, 38, NULL, 'V', NULL),
	(792, '2022-07-13 08:30:00', NULL, NULL, 38, NULL, 'V', NULL),
	(793, '2022-07-13 09:00:00', NULL, NULL, 38, NULL, 'V', NULL),
	(794, '2022-07-13 09:30:00', NULL, NULL, 38, NULL, 'V', NULL),
	(795, '2022-07-13 10:00:00', NULL, NULL, 38, NULL, 'V', NULL),
	(796, '2022-07-13 10:30:00', NULL, NULL, 38, NULL, 'V', NULL),
	(797, '2022-07-13 11:00:00', NULL, NULL, 38, NULL, 'V', NULL),
	(798, '2022-07-13 11:30:00', NULL, NULL, 38, NULL, 'V', NULL),
	(799, '2022-07-13 12:00:00', NULL, NULL, 38, NULL, 'V', NULL),
	(800, '2022-07-13 12:30:00', NULL, NULL, 38, NULL, 'V', NULL),
	(801, '2022-07-13 13:00:00', NULL, NULL, 38, NULL, 'V', NULL),
	(802, '2022-07-13 13:30:00', NULL, NULL, 38, NULL, 'V', NULL),
	(803, '2022-07-13 14:00:00', NULL, NULL, 38, NULL, 'V', NULL),
	(804, '2022-07-13 14:30:00', NULL, NULL, 38, NULL, 'V', NULL),
	(805, '2022-07-13 15:00:00', NULL, NULL, 38, NULL, 'V', NULL),
	(806, '2022-07-13 15:30:00', NULL, NULL, 38, NULL, 'V', NULL),
	(807, '2022-07-13 16:00:00', NULL, NULL, 38, NULL, 'V', NULL),
	(808, '2022-07-13 16:30:00', NULL, NULL, 38, NULL, 'V', NULL),
	(809, '2022-07-13 17:00:00', NULL, NULL, 38, NULL, 'V', NULL),
	(810, '2022-07-13 17:30:00', NULL, NULL, 38, NULL, 'V', NULL),
	(811, '2022-07-13 18:00:00', NULL, NULL, 38, NULL, 'V', NULL),
	(812, '2022-07-13 18:30:00', NULL, NULL, 38, NULL, 'V', NULL),
	(813, '2022-07-20 06:00:00', NULL, NULL, 38, NULL, 'V', NULL),
	(814, '2022-07-20 06:30:00', NULL, NULL, 38, NULL, 'V', NULL),
	(815, '2022-07-20 07:00:00', NULL, NULL, 38, NULL, 'V', NULL),
	(816, '2022-07-20 07:30:00', NULL, NULL, 38, NULL, 'V', NULL),
	(817, '2022-07-20 08:00:00', NULL, NULL, 38, NULL, 'V', NULL),
	(818, '2022-07-20 08:30:00', NULL, NULL, 38, NULL, 'V', NULL),
	(819, '2022-07-20 09:00:00', NULL, NULL, 38, NULL, 'V', NULL),
	(820, '2022-07-20 09:30:00', NULL, NULL, 38, NULL, 'V', NULL),
	(821, '2022-07-20 10:00:00', NULL, NULL, 38, NULL, 'V', NULL),
	(822, '2022-07-20 10:30:00', NULL, NULL, 38, NULL, 'V', NULL),
	(823, '2022-07-20 11:00:00', NULL, NULL, 38, NULL, 'V', NULL),
	(824, '2022-07-20 11:30:00', NULL, NULL, 38, NULL, 'V', NULL),
	(825, '2022-07-20 12:00:00', NULL, NULL, 38, NULL, 'V', NULL),
	(826, '2022-07-20 12:30:00', NULL, NULL, 38, NULL, 'V', NULL),
	(827, '2022-07-20 13:00:00', NULL, NULL, 38, NULL, 'V', NULL),
	(828, '2022-07-20 13:30:00', NULL, NULL, 38, NULL, 'V', NULL),
	(829, '2022-07-20 14:00:00', NULL, NULL, 38, NULL, 'V', NULL),
	(830, '2022-07-20 14:30:00', NULL, NULL, 38, NULL, 'V', NULL),
	(831, '2022-07-20 15:00:00', NULL, NULL, 38, NULL, 'V', NULL),
	(832, '2022-07-20 15:30:00', NULL, NULL, 38, NULL, 'V', NULL),
	(833, '2022-07-20 16:00:00', NULL, NULL, 38, NULL, 'V', NULL),
	(834, '2022-07-20 16:30:00', NULL, NULL, 38, NULL, 'V', NULL),
	(835, '2022-07-20 17:00:00', NULL, NULL, 38, NULL, 'V', NULL),
	(836, '2022-07-20 17:30:00', NULL, NULL, 38, NULL, 'V', NULL),
	(837, '2022-07-20 18:00:00', NULL, NULL, 38, NULL, 'V', NULL),
	(838, '2022-07-20 18:30:00', NULL, NULL, 38, NULL, 'V', NULL),
	(839, '2022-07-27 06:00:00', NULL, NULL, 38, NULL, 'V', NULL),
	(840, '2022-07-27 06:30:00', NULL, NULL, 38, NULL, 'V', NULL),
	(841, '2022-07-27 07:00:00', NULL, NULL, 38, NULL, 'V', NULL),
	(842, '2022-07-27 07:30:00', NULL, NULL, 38, NULL, 'V', NULL),
	(843, '2022-07-27 08:00:00', NULL, NULL, 38, NULL, 'V', NULL),
	(844, '2022-07-27 08:30:00', NULL, NULL, 38, NULL, 'V', NULL),
	(845, '2022-07-27 09:00:00', NULL, NULL, 38, NULL, 'V', NULL),
	(846, '2022-07-27 09:30:00', NULL, NULL, 38, NULL, 'V', NULL),
	(847, '2022-07-27 10:00:00', NULL, NULL, 38, NULL, 'V', NULL),
	(848, '2022-07-27 10:30:00', NULL, NULL, 38, NULL, 'V', NULL),
	(849, '2022-07-27 11:00:00', NULL, NULL, 38, NULL, 'V', NULL),
	(850, '2022-07-27 11:30:00', NULL, NULL, 38, NULL, 'V', NULL),
	(851, '2022-07-27 12:00:00', NULL, NULL, 38, NULL, 'V', NULL),
	(852, '2022-07-13 06:00:00', NULL, NULL, 39, NULL, 'V', NULL),
	(853, '2022-07-13 06:30:00', NULL, NULL, 39, NULL, 'V', NULL),
	(854, '2022-07-20 06:00:00', NULL, NULL, 39, NULL, 'V', NULL),
	(855, '2022-07-20 06:30:00', NULL, NULL, 39, NULL, 'V', NULL),
	(856, '2022-07-27 06:00:00', NULL, NULL, 39, NULL, 'V', NULL),
	(857, '2022-07-27 06:30:00', NULL, NULL, 39, NULL, 'V', NULL),
	(858, '2022-08-03 06:00:00', NULL, NULL, 39, NULL, 'V', NULL),
	(859, '2022-08-03 06:30:00', NULL, NULL, 39, NULL, 'V', NULL),
	(860, '2022-07-13 08:00:00', NULL, NULL, 40, NULL, 'V', NULL),
	(861, '2022-07-13 08:20:00', NULL, NULL, 40, NULL, 'V', NULL),
	(862, '2022-07-13 08:40:00', NULL, NULL, 40, NULL, 'V', NULL),
	(863, '2022-07-13 09:00:00', NULL, NULL, 40, NULL, 'V', NULL),
	(864, '2022-07-13 09:20:00', NULL, NULL, 40, NULL, 'V', NULL),
	(865, '2022-07-13 09:40:00', NULL, NULL, 40, NULL, 'V', NULL),
	(866, '2022-07-13 10:00:00', NULL, NULL, 40, NULL, 'V', NULL),
	(867, '2022-07-13 10:20:00', NULL, NULL, 40, NULL, 'V', NULL),
	(868, '2022-07-13 10:40:00', NULL, NULL, 40, NULL, 'V', NULL),
	(869, '2022-07-13 11:00:00', NULL, NULL, 40, NULL, 'V', NULL),
	(870, '2022-07-13 11:20:00', NULL, NULL, 40, NULL, 'V', NULL),
	(871, '2022-07-13 11:40:00', NULL, NULL, 40, NULL, 'V', NULL),
	(872, '2022-07-20 08:00:00', NULL, NULL, 40, NULL, 'V', NULL),
	(873, '2022-07-20 08:20:00', NULL, NULL, 40, NULL, 'V', NULL),
	(874, '2022-07-20 08:40:00', NULL, NULL, 40, NULL, 'V', NULL),
	(875, '2022-07-20 09:00:00', NULL, NULL, 40, NULL, 'V', NULL),
	(876, '2022-07-20 09:20:00', NULL, NULL, 40, NULL, 'V', NULL),
	(877, '2022-07-20 09:40:00', NULL, NULL, 40, NULL, 'V', NULL),
	(878, '2022-07-20 10:00:00', NULL, NULL, 40, NULL, 'V', NULL),
	(879, '2022-07-20 10:20:00', NULL, NULL, 40, NULL, 'V', NULL),
	(880, '2022-07-20 10:40:00', NULL, NULL, 40, NULL, 'V', NULL),
	(881, '2022-07-20 11:00:00', NULL, NULL, 40, NULL, 'V', NULL),
	(882, '2022-07-20 11:20:00', NULL, NULL, 40, NULL, 'V', NULL),
	(883, '2022-07-20 11:40:00', NULL, NULL, 40, NULL, 'V', NULL),
	(884, '2022-07-27 08:00:00', NULL, NULL, 40, NULL, 'V', NULL),
	(885, '2022-07-27 08:20:00', NULL, NULL, 40, NULL, 'V', NULL),
	(886, '2022-07-27 08:40:00', NULL, NULL, 40, NULL, 'V', NULL),
	(887, '2022-07-27 09:00:00', NULL, NULL, 40, NULL, 'V', NULL),
	(888, '2022-07-27 09:20:00', NULL, NULL, 40, NULL, 'V', NULL),
	(889, '2022-07-27 09:40:00', NULL, NULL, 40, NULL, 'V', NULL),
	(890, '2022-07-27 10:00:00', NULL, NULL, 40, NULL, 'V', NULL),
	(891, '2022-07-27 10:20:00', NULL, NULL, 40, NULL, 'V', NULL),
	(892, '2022-07-27 10:40:00', NULL, NULL, 40, NULL, 'V', NULL),
	(893, '2022-07-27 11:00:00', NULL, NULL, 40, NULL, 'V', NULL),
	(894, '2022-07-27 11:20:00', NULL, NULL, 40, NULL, 'V', NULL),
	(895, '2022-07-27 11:40:00', NULL, NULL, 40, NULL, 'V', NULL),
	(896, '2022-08-03 08:00:00', NULL, NULL, 40, NULL, 'V', NULL),
	(897, '2022-08-03 08:20:00', NULL, NULL, 40, NULL, 'V', NULL),
	(898, '2022-08-03 08:40:00', NULL, NULL, 40, NULL, 'V', NULL),
	(899, '2022-08-03 09:00:00', NULL, NULL, 40, NULL, 'V', NULL),
	(900, '2022-08-03 09:20:00', NULL, NULL, 40, NULL, 'V', NULL),
	(901, '2022-08-03 09:40:00', NULL, NULL, 40, NULL, 'V', NULL),
	(902, '2022-08-03 10:00:00', NULL, NULL, 40, NULL, 'V', NULL),
	(903, '2022-08-03 10:20:00', NULL, NULL, 40, NULL, 'V', NULL),
	(904, '2022-08-03 10:40:00', NULL, NULL, 40, NULL, 'V', NULL),
	(905, '2022-08-03 11:00:00', NULL, NULL, 40, NULL, 'V', NULL),
	(906, '2022-08-03 11:20:00', NULL, NULL, 40, NULL, 'V', NULL),
	(907, '2022-08-03 11:40:00', NULL, NULL, 40, NULL, 'V', NULL),
	(908, '2022-07-07 18:00:00', NULL, NULL, 41, NULL, 'T', NULL),
	(909, '2022-07-07 18:20:00', NULL, NULL, 41, NULL, 'T', NULL),
	(910, '2022-07-07 18:40:00', NULL, NULL, 41, NULL, 'T', NULL),
	(911, '2022-07-14 18:00:00', NULL, NULL, 41, NULL, 'V', NULL),
	(912, '2022-07-14 18:20:00', NULL, NULL, 41, NULL, 'V', NULL),
	(913, '2022-07-14 18:40:00', NULL, NULL, 41, NULL, 'V', NULL),
	(914, '2022-07-21 18:00:00', NULL, NULL, 41, NULL, 'V', NULL),
	(915, '2022-07-21 18:20:00', NULL, NULL, 41, NULL, 'V', NULL),
	(916, '2022-07-21 18:40:00', NULL, NULL, 41, NULL, 'V', NULL),
	(917, '2022-07-28 18:00:00', NULL, NULL, 41, NULL, 'V', NULL),
	(918, '2022-07-28 18:20:00', NULL, NULL, 41, NULL, 'V', NULL),
	(919, '2022-07-28 18:40:00', NULL, NULL, 41, NULL, 'V', NULL),
	(920, '2022-08-04 18:00:00', NULL, NULL, 41, NULL, 'V', NULL),
	(921, '2022-08-04 18:20:00', NULL, NULL, 41, NULL, 'V', NULL),
	(922, '2022-08-04 18:40:00', NULL, NULL, 41, NULL, 'V', NULL),
	(923, '2022-07-13 07:00:00', NULL, NULL, 42, NULL, 'V', NULL),
	(924, '2022-07-13 07:20:00', NULL, NULL, 42, NULL, 'V', NULL),
	(925, '2022-07-13 07:40:00', NULL, NULL, 42, NULL, 'V', NULL),
	(926, '2022-07-20 07:00:00', NULL, NULL, 42, NULL, 'V', NULL),
	(927, '2022-07-20 07:20:00', NULL, NULL, 42, NULL, 'V', NULL),
	(928, '2022-07-20 07:40:00', NULL, NULL, 42, NULL, 'V', NULL),
	(929, '2022-07-27 07:00:00', NULL, NULL, 42, NULL, 'V', NULL),
	(930, '2022-07-27 07:20:00', NULL, NULL, 42, NULL, 'V', NULL),
	(931, '2022-07-27 07:40:00', NULL, NULL, 42, NULL, 'V', NULL),
	(932, '2022-08-03 07:00:00', NULL, NULL, 42, NULL, 'V', NULL),
	(933, '2022-08-03 07:20:00', NULL, NULL, 42, NULL, 'V', NULL),
	(934, '2022-08-03 07:40:00', NULL, NULL, 42, NULL, 'V', NULL),
	(935, '2022-07-07 16:00:00', NULL, NULL, 43, NULL, 'T', NULL),
	(936, '2022-07-07 16:20:00', NULL, NULL, 43, NULL, 'T', NULL),
	(937, '2022-07-07 16:40:00', NULL, NULL, 43, NULL, 'T', NULL),
	(938, '2022-07-11 20:00:00', NULL, NULL, 44, NULL, 'V', NULL),
	(939, '2022-07-11 20:20:00', NULL, NULL, 44, NULL, 'V', NULL),
	(940, '2022-07-11 20:40:00', NULL, NULL, 44, NULL, 'V', NULL),
	(941, '2022-07-11 21:00:00', NULL, NULL, 44, NULL, 'V', NULL),
	(942, '2022-07-11 21:20:00', NULL, NULL, 44, NULL, 'V', NULL),
	(943, '2022-07-11 21:40:00', NULL, NULL, 44, NULL, 'V', NULL),
	(944, '2022-07-18 20:00:00', NULL, NULL, 44, NULL, 'V', NULL),
	(945, '2022-07-18 20:20:00', NULL, NULL, 44, NULL, 'V', NULL),
	(946, '2022-07-18 20:40:00', NULL, NULL, 44, NULL, 'V', NULL),
	(947, '2022-07-18 21:00:00', NULL, NULL, 44, 5, 'S', NULL),
	(948, '2022-07-18 21:20:00', NULL, NULL, 44, NULL, 'V', NULL),
	(949, '2022-07-18 21:40:00', NULL, NULL, 44, 5, 'S', NULL),
	(950, '2022-07-25 20:00:00', NULL, NULL, 44, NULL, 'V', NULL),
	(951, '2022-07-25 20:20:00', NULL, NULL, 44, NULL, 'V', NULL),
	(952, '2022-07-25 20:40:00', NULL, NULL, 44, NULL, 'V', NULL),
	(953, '2022-07-25 21:00:00', NULL, NULL, 44, NULL, 'V', NULL),
	(954, '2022-07-25 21:20:00', NULL, NULL, 44, 5, 'S', NULL),
	(955, '2022-07-25 21:40:00', NULL, 'f', 44, 5, 'S', 1),
	(956, '2022-08-01 20:00:00', NULL, NULL, 44, NULL, 'V', NULL),
	(957, '2022-08-01 20:20:00', NULL, NULL, 44, NULL, 'V', NULL),
	(958, '2022-08-01 20:40:00', NULL, NULL, 44, NULL, 'V', NULL),
	(959, '2022-08-01 21:00:00', NULL, NULL, 44, NULL, 'V', NULL),
	(960, '2022-08-01 21:20:00', NULL, NULL, 44, NULL, 'V', NULL),
	(961, '2022-08-01 21:40:00', NULL, NULL, 44, NULL, 'V', NULL),
	(962, '2022-08-08 20:00:00', NULL, NULL, 44, NULL, 'V', NULL),
	(963, '2022-08-08 20:20:00', NULL, NULL, 44, NULL, 'V', NULL),
	(964, '2022-08-08 20:40:00', NULL, NULL, 44, NULL, 'V', NULL),
	(965, '2022-08-08 21:00:00', NULL, NULL, 44, NULL, 'V', NULL),
	(966, '2022-08-08 21:20:00', NULL, NULL, 44, NULL, 'V', NULL),
	(967, '2022-08-08 21:40:00', NULL, NULL, 44, NULL, 'V', NULL);

-- Volcando estructura para tabla proyecto-agendamiento-valeria.horario
CREATE TABLE IF NOT EXISTS `horario` (
  `idhorario` int NOT NULL AUTO_INCREMENT,
  `dia` varchar(45) NOT NULL,
  `hora_inicio` varchar(45) NOT NULL,
  `horafin` varchar(45) NOT NULL,
  `plantilla_fk` int NOT NULL,
  PRIMARY KEY (`idhorario`),
  KEY `plantilla_fk_idx` (`plantilla_fk`),
  CONSTRAINT `plantilla_fk` FOREIGN KEY (`plantilla_fk`) REFERENCES `plantilla_agendamiento` (`idplantilla_agenda`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=45 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla proyecto-agendamiento-valeria.horario: ~11 rows (aproximadamente)
INSERT IGNORE INTO `horario` (`idhorario`, `dia`, `hora_inicio`, `horafin`, `plantilla_fk`) VALUES
	(29, 'viernes', '05:00', '06:00', 20),
	(30, 'martes', '14:00', '18:00', 21),
	(31, 'viernes', '08:00', '12:00', 21),
	(32, 'jueves', '17:00', '18:00', 22),
	(38, 'miercoles', '06:00', '19:00', 28),
	(39, 'miercoles', '06:00', '07:00', 29),
	(40, 'miercoles', '08:00', '12:00', 30),
	(41, 'jueves', '18:00', '19:00', 30),
	(42, 'miercoles', '07:00', '08:00', 30),
	(43, 'jueves', '16:00', '17:00', 31),
	(44, 'lunes', '20:00', '22:00', 32);

-- Volcando estructura para tabla proyecto-agendamiento-valeria.identificacion
CREATE TABLE IF NOT EXISTS `identificacion` (
  `id_identificacion` int NOT NULL AUTO_INCREMENT,
  `nombre_identificacion` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`id_identificacion`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla proyecto-agendamiento-valeria.identificacion: ~3 rows (aproximadamente)
INSERT IGNORE INTO `identificacion` (`id_identificacion`, `nombre_identificacion`) VALUES
	(1, 'Tarjeta de identidad'),
	(2, 'cedula de ciudadania'),
	(3, 'cedula de extranjeria');

-- Volcando estructura para tabla proyecto-agendamiento-valeria.permisos
CREATE TABLE IF NOT EXISTS `permisos` (
  `idpermisos` int NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(45) DEFAULT NULL,
  `url` varchar(55) DEFAULT NULL,
  PRIMARY KEY (`idpermisos`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla proyecto-agendamiento-valeria.permisos: ~21 rows (aproximadamente)
INSERT IGNORE INTO `permisos` (`idpermisos`, `descripcion`, `url`) VALUES
	(1, 'MIS AGENDAMIENTOS', 'VerAgendamientosSolicitados.aspx'),
	(2, 'SOLICITAR AGENDAMIENTO', 'SolicitarAgendamiento.aspx'),
	(3, 'CREAR AGENDAMIENTO', 'CrearAgendamiento.aspx'),
	(4, 'AGREGAR OBSERVACIONES', 'Observaciones.aspx'),
	(5, 'ACTUALIZAR AGENDA', '#'),
	(6, 'ELIMINAR AGENDA', '#'),
	(7, 'CREAR USUARIO', 'CrearUsuario.aspx'),
	(8, 'CREAR ROL', 'CrearRol.aspx'),
	(9, 'ELIMINAR ROL', 'EliminarRol.aspx'),
	(10, 'MODIFICAR ROL', 'ModificarRol.aspx'),
	(11, 'CAMBIAR NOMBRE(ROL)', 'CambiarNombreRol.aspx'),
	(12, 'CREAR ACCION', 'CrearAccion.aspx'),
	(13, 'ELIMINAR ACCION', 'EliminarAccion.aspx'),
	(14, 'CREAR PERMISOS', 'CrearPermisos.aspx'),
	(15, 'CONSULTAR USUARIOS', 'ConsultarUsuarios.aspx'),
	(16, 'CAMBIAR CONTRASEÑA', 'CambiarContrase.aspx'),
	(18, 'REPORTES', 'Reportes.aspx'),
	(19, 'REPORTES', 'ReporteEstuAgendamiento.aspx'),
	(20, 'QUEJAS', 'Quejas.aspx'),
	(21, 'REPORTES', 'ReporteAdmin.aspx'),
	(22, 'permisoprueba', 'prueba.aspx');

-- Volcando estructura para tabla proyecto-agendamiento-valeria.plantilla_agendamiento
CREATE TABLE IF NOT EXISTS `plantilla_agendamiento` (
  `idplantilla_agenda` int NOT NULL AUTO_INCREMENT,
  `rango_tiempo_minutos` int NOT NULL,
  `nombre_plantilla` varchar(45) NOT NULL,
  `usuario_fk_plantilla` int NOT NULL,
  `rango_cancelar` int NOT NULL,
  `fecha_inicio` datetime NOT NULL,
  `fecha_fin` datetime NOT NULL,
  `tema` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`idplantilla_agenda`),
  KEY `usuario_fk_plantilla_idx` (`usuario_fk_plantilla`),
  CONSTRAINT `usuario_fk_plantilla` FOREIGN KEY (`usuario_fk_plantilla`) REFERENCES `usuario` (`id_usuario`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla proyecto-agendamiento-valeria.plantilla_agendamiento: ~8 rows (aproximadamente)
INSERT IGNORE INTO `plantilla_agendamiento` (`idplantilla_agenda`, `rango_tiempo_minutos`, `nombre_plantilla`, `usuario_fk_plantilla`, `rango_cancelar`, `fecha_inicio`, `fecha_fin`, `tema`) VALUES
	(20, 30, 'claseSalsa', 3, 30, '2022-06-28 00:00:00', '2022-07-28 00:00:00', 'salsa'),
	(21, 30, 'claseMerengue', 3, 30, '2022-06-28 00:00:00', '2022-07-28 00:00:00', 'Merengue'),
	(22, 30, 'claseRegue', 3, 30, '2022-06-28 00:00:00', '2022-07-28 00:00:00', 'Regue'),
	(28, 30, 'clasejueves', 3, 30, '2022-07-07 00:00:00', '2022-08-07 00:00:00', 'cumbia'),
	(29, 30, 'danza', 3, 30, '2022-07-07 00:00:00', '2022-08-07 00:00:00', 'cumbia'),
	(30, 20, 'ritmica', 3, 40, '2022-07-07 00:00:00', '2022-08-07 00:00:00', 'techo'),
	(31, 20, 'regaeton', 3, 60, '2022-07-07 00:00:00', '2022-07-07 00:00:00', 'clasejueves'),
	(32, 20, 'LunesBAile', 3, 60, '2022-07-11 00:00:00', '2022-08-11 00:00:00', 'salachoque');

-- Volcando estructura para tabla proyecto-agendamiento-valeria.quejas
CREATE TABLE IF NOT EXISTS `quejas` (
  `idqueja` int NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(45) NOT NULL,
  `usuario_fk` int NOT NULL,
  `fecha_queja` datetime NOT NULL,
  PRIMARY KEY (`idqueja`),
  KEY `usuario_fk_idx` (`usuario_fk`),
  CONSTRAINT `usuario_fk` FOREIGN KEY (`usuario_fk`) REFERENCES `usuario` (`id_usuario`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla proyecto-agendamiento-valeria.quejas: ~0 rows (aproximadamente)
INSERT IGNORE INTO `quejas` (`idqueja`, `descripcion`, `usuario_fk`, `fecha_queja`) VALUES
	(2, 'Demasiado bonita la admin', 5, '2022-06-23 15:23:50');

-- Volcando estructura para tabla proyecto-agendamiento-valeria.rol
CREATE TABLE IF NOT EXISTS `rol` (
  `id_rol` int NOT NULL AUTO_INCREMENT,
  `nombre_rol` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`id_rol`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla proyecto-agendamiento-valeria.rol: ~3 rows (aproximadamente)
INSERT IGNORE INTO `rol` (`id_rol`, `nombre_rol`) VALUES
	(1, 'Administrador'),
	(2, 'Estudiante'),
	(3, 'Instructor');

-- Volcando estructura para tabla proyecto-agendamiento-valeria.software
CREATE TABLE IF NOT EXISTS `software` (
  `idsoftware` int NOT NULL AUTO_INCREMENT,
  `nombre_software` varchar(45) NOT NULL,
  PRIMARY KEY (`idsoftware`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla proyecto-agendamiento-valeria.software: ~0 rows (aproximadamente)
INSERT IGNORE INTO `software` (`idsoftware`, `nombre_software`) VALUES
	(1, 'Agendamiento');

-- Volcando estructura para tabla proyecto-agendamiento-valeria.usuario
CREATE TABLE IF NOT EXISTS `usuario` (
  `id_usuario` int NOT NULL AUTO_INCREMENT,
  `numero_documento` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `primer_nombre` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `segundo_nombre` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `primer_apellido` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `segundo_apellido` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `usuario` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `clave` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `correo` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `id_rol_fk` int NOT NULL,
  `id_identificacion_fk` int NOT NULL,
  PRIMARY KEY (`id_usuario`),
  KEY `id_rol_fk` (`id_rol_fk`),
  KEY `id_identificacion_fk` (`id_identificacion_fk`),
  CONSTRAINT `id_identificacion_fk` FOREIGN KEY (`id_identificacion_fk`) REFERENCES `identificacion` (`id_identificacion`),
  CONSTRAINT `id_rol_fk` FOREIGN KEY (`id_rol_fk`) REFERENCES `rol` (`id_rol`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla proyecto-agendamiento-valeria.usuario: ~6 rows (aproximadamente)
INSERT IGNORE INTO `usuario` (`id_usuario`, `numero_documento`, `primer_nombre`, `segundo_nombre`, `primer_apellido`, `segundo_apellido`, `usuario`, `clave`, `correo`, `id_rol_fk`, `id_identificacion_fk`) VALUES
	(1, '78518686', 'German ', NULL, 'lozano', NULL, 'admin', '1234', 'admin@udla.edu.co', 1, 2),
	(3, '10023832', 'Diego', '', 'Mora', '', 'diego', '7110eda4d09e062aa5e4a390b0a572ac0d2c0220', 'diego@mora.com', 3, 2),
	(5, '1007662', 'Fernando', '', 'Mora', '', 'ma', '8cb2237d0679ca88db6464eac60da96345513964', 'diegasaso@mora.com', 2, 2),
	(6, '100283723', 'Usurio', '', 'Prueba', '', 'userprueba', '7110eda4d09e062aa5e4a390b0a572ac0d2c0220', 'userprueba@gmail.com', 1, 2),
	(10, '1006514', 'German', '', 'Lozano', '', 'administrador', '7110eda4d09e062aa5e4a390b0a572ac0d2c0220', 'correo@correo.es', 1, 1),
	(11, '1111111111', 'valeria', '', 'salazar', 'serna', 'valeria', '7110eda4d09e062aa5e4a390b0a572ac0d2c0220', 'valeria@gmailcom', 1, 2);

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
