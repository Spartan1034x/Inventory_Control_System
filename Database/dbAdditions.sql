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

/*Trigger for creating username and email */
DROP TRIGGER IF EXISTS employee_insert;
DELIMITER #
CREATE TRIGGER employee_insert
    AFTER INSERT ON employee
    FOR EACH ROW
BEGIN
    DECLARE baseUserName VARCHAR(26);
    DECLARE baseEmail VARCHAR(50);
    DECLARE counter INT DEFAULT 0;
    DECLARE newUserName VARCHAR(26);
    DECLARE newEmail VARCHAR(50);

    SET baseUserName = CONCAT(LEFT(NEW.FirstName, 1), NEW.LastName);
    SET baseEmail = CONCAT(LEFT(NEW.FirstName, 1), NEW.LastName, '@bullseye.com');
    SET newUserName = baseUserName;
    SET newEmail = baseEmail;

    WHILE EXISTS (SELECT 1 FROM employee WHERE userName = newUserName OR Email = newEmail) DO
        SET counter = counter + 1;
        SET newUserName = CONCAT(baseUserName, counter);
        SET newEmail = CONCAT(LEFT(NEW.FirstName, 1), NEW.LastName, counter, '@bullseye.com');
    END WHILE;

    UPDATE employee
    SET userName = newUserName,
        Email = newEmail
    WHERE EmployeeID = NEW.EmployeeID;

END #
DELIMITER ;

/* Changes locked back to 0 for admin */
UPDATE employee
SET locked = 0
WHERE employeeID = 1000;