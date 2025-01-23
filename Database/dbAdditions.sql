/*
    ***NOT USED SECTION****
*/
ALTER TABLE employee DROP COLUMN userName;
ALTER TABLE employee ADD COLUMN userName VARCHAR(25) DEFAULT NULL;

/*Allows hashed passwords */
ALTER TABLE Employee
MODIFY COLUMN Password VARCHAR(255) NOT NULL;

/* Creates username */
UPDATE employee
SET userName = CONCAT(LEFT(FirstName, 1), LastName)
WHERE employeeID IS NOT NULL
LIMIT 20; /* Satifies Safe mode error but limits the amount of users changed, ensure this number is higher than total users */

/* txnAudit entry */
INSERT INTO `txnaudit` (
  `txnID`, 
  `employeeID`, 
  `txnType`, 
  `status`, 
  `txnDate`, 
  `SiteID`, 
  `deliveryID`, 
  `notes`
) VALUES (
  1001,
  10008,        
  'Correction',   
  'Pending',       
  NOW(),           
  1,               
  NULL,            
  'Correction for inventory mismatch' 
);

DELETE FROM `txnaudit`
WHERE `txnAuditID` = 32094823844039;




/* 
    *** USED SECTION *****
*/
/* Adds firstInsert column to employee table */
ALTER TABLE employee ADD COLUMN firstInsert BOOLEAN DEFAULT TRUE;

/* Sets every record in the employee table to have firstInsert = FALSE */
SET SQL_SAFE_UPDATES = 0;
UPDATE employee SET firstInsert = FALSE;
SET SQL_SAFE_UPDATES = 1;

/*Trigger for creating username and email if first insert is true */
DROP TRIGGER IF EXISTS employee_insert;
DELIMITER #
CREATE TRIGGER employee_insert
    BEFORE INSERT ON employee
    FOR EACH ROW
BEGIN
    DECLARE baseUserName VARCHAR(26);
    DECLARE baseEmail VARCHAR(50);
    DECLARE counter INT DEFAULT 0;
    DECLARE newUserName VARCHAR(26);
    DECLARE newEmail VARCHAR(50);

    IF NEW.firstInsert = TRUE THEN
        SET baseUserName = CONCAT(LOWER(LEFT(NEW.FirstName, 1)), LOWER(NEW.LastName));
        SET baseEmail = CONCAT(LOWER(LEFT(NEW.FirstName, 1)), LOWER(NEW.LastName), '@bullseye.com');
        SET newUserName = baseUserName;
        SET newEmail = baseEmail;

        WHILE EXISTS (SELECT 1 FROM employee WHERE username = newUserName OR Email = newEmail) DO
            SET counter = counter + 1;
            SET newUserName = CONCAT(baseUserName, counter);
            SET newEmail = CONCAT(LOWER(LEFT(NEW.FirstName, 1)), LOWER(NEW.LastName), counter, '@bullseye.com');
        END WHILE;

        SET NEW.username = newUserName;
        SET NEW.Email = newEmail;
    END IF;
END #
DELIMITER ;

/* Creates username and email for updates on employee */
DROP TRIGGER IF EXISTS employee_update;
DELIMITER #
CREATE TRIGGER employee_update
    BEFORE UPDATE ON employee
    FOR EACH ROW
BEGIN
    DECLARE baseUserName VARCHAR(26);
    DECLARE baseEmail VARCHAR(50);
    DECLARE counter INT DEFAULT 0;
    DECLARE newUserName VARCHAR(26);
    DECLARE newEmail VARCHAR(50);

    SET baseUserName = CONCAT(LOWER(LEFT(NEW.FirstName, 1)), LOWER(NEW.LastName));
    SET baseEmail = CONCAT(LOWER(LEFT(NEW.FirstName, 1)), LOWER(NEW.LastName), '@bullseye.com');
    SET newUserName = baseUserName;
    SET newEmail = baseEmail;

    WHILE EXISTS (SELECT 1 FROM employee WHERE username = newUserName OR Email = newEmail) DO
        SET counter = counter + 1;
        SET newUserName = CONCAT(baseUserName, counter);
        SET newEmail = CONCAT(LOWER(LEFT(NEW.FirstName, 1)), LOWER(NEW.LastName), counter, '@bullseye.com');
    END WHILE;

    SET NEW.username = newUserName;
    SET NEW.Email = newEmail;
END #
DELIMITER ;

/* Changes locked back to 0 for admin */
UPDATE employee
SET locked = 0
WHERE employeeID = 1000;

