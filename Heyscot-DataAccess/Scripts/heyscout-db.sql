-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema heyscout-db
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema heyscout-db
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `heyscout-db` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `heyscout-db` ;

-- -----------------------------------------------------
-- Table `heyscout-db`.`customers`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `heyscout-db`.`customers` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(255) NULL DEFAULT NULL,
  `City` VARCHAR(255) NULL DEFAULT NULL,
  `RegistrationDate` DATETIME NULL DEFAULT NULL,
  PRIMARY KEY (`ID`))
ENGINE = InnoDB
AUTO_INCREMENT = 13
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `heyscout-db`.`talents`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `heyscout-db`.`talents` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(255) NULL DEFAULT NULL,
  `City` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`ID`))
ENGINE = InnoDB
AUTO_INCREMENT = 9
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- --------------------------
-- INSERT Data
-- --------------------------

USE `heyscout-db` ;
INSERT INTO `heyscout-db`.`customers`(`Name`,`City`,`RegistrationDate`)
VALUES('Muneer','Berlin',now());
INSERT INTO `heyscout-db`.`customers`(`Name`,`City`,`RegistrationDate`)
VALUES('Joahana','Berlin',now());
INSERT INTO `heyscout-db`.`customers`(`Name`,`City`,`RegistrationDate`)
VALUES('Elham','Hamburg',now());
INSERT INTO `heyscout-db`.`customers`(`Name`,`City`,`RegistrationDate`)
VALUES('Julia','Hanover',now());
INSERT INTO `heyscout-db`.`customers`(`Name`,`City`,`RegistrationDate`)
VALUES('Erik','Hanover',now());
INSERT INTO `heyscout-db`.`customers`(`Name`,`City`,`RegistrationDate`)
VALUES('Brigida','Milano',now());

INSERT INTO `heyscout-db`.`talents`(`Name`,`City`)
VALUES('Mark','Berlin');
INSERT INTO `heyscout-db`.`talents`(`Name`,`City`)
VALUES('Andreas','Berlin');
INSERT INTO `heyscout-db`.`talents`(`Name`,`City`)
VALUES('Nadeem','Hamburg');
INSERT INTO `heyscout-db`.`talents`(`Name`,`City`)
VALUES('Manzoor','Hamburg');
INSERT INTO `heyscout-db`.`talents`(`Name`,`City`)
VALUES('Kashif','Hanover');
INSERT INTO `heyscout-db`.`talents`(`Name`,`City`)
VALUES('Mahar','Hanover');
INSERT INTO `heyscout-db`.`talents`(`Name`,`City`)
VALUES('Jessa','Munich');
INSERT INTO `heyscout-db`.`talents`(`Name`,`City`)
VALUES('Marie','Prague');

USE `heyscout-db` ;

-- -----------------------------------------------------
-- procedure GetData
-- -----------------------------------------------------

DELIMITER $$
USE `heyscout-db`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetData`(selectedType Nvarchar(100))
BEGIN
	if selectedType = 'All'
		Then
			Select * from customers ORDER BY  City;
			select * from talents ORDER BY  City;
		END IF;
    if selectedType = 'Customers'
		Then
			Select * from customers ORDER BY  City;
		END IF;
	if selectedType = 'Talents'
		Then
			Select * from talents ORDER BY  City;
		END IF;
	if selectedType = 'MatchByCity'
		Then      
			select * from customers where city in (Select City from talents) ORDER BY  City;
			select * from talents where city in (Select City from customers) ORDER BY  City;
        END IF;
END$$

DELIMITER ;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
