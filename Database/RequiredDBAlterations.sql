/* 
    *** USED SECTION *****
*/
/* Adds firstInsert column to employee table */
ALTER TABLE employee ADD COLUMN firstInsert BOOLEAN DEFAULT TRUE;

/* Sets every record in the employee table to have firstInsert = FALSE */
SET SQL_SAFE_UPDATES = 0;
UPDATE employee SET firstInsert = FALSE;
SET SQL_SAFE_UPDATES = 1;

/* Trigger for inserting records on the inventory table, never allows quantity to go below 0 */
DROP TRIGGER IF EXISTS inventory_insert;
DELIMITER #
CREATE TRIGGER inventory_insert
    BEFORE INSERT ON inventory
    FOR EACH ROW
BEGIN
    IF NEW.quantity < 0 THEN
        SET NEW.quantity = 0;
    END IF;
END #
DELIMITER ;

/* Trigger for updating records on the inventory table, never allows quantity to go below 0 */
DROP TRIGGER IF EXISTS inventory_update;
DELIMITER #
CREATE TRIGGER inventory_update
    BEFORE UPDATE ON inventory
    FOR EACH ROW
BEGIN
    IF NEW.quantity < 0 THEN
        SET NEW.quantity = 0;
    END IF;
END #
DELIMITER ;

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

    WHILE EXISTS (SELECT 1 FROM employee WHERE (username = newUserName OR Email = newEmail) AND employeeID <> NEW.employeeID) DO
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

/* Adds "All" StatusName to txnstatus table */
INSERT INTO txnstatus (StatusName, statusDescription)
VALUES ('All', "Show All");

/* Adds "All" to txnType in txntype table */
INSERT INTO txntype (txnType)
VALUES ('All');

/* Adds "All" to site table, sets siteID to 11, siteName to "All", province to 'NB' */
INSERT INTO site (siteID, siteName, provinceID, address, city, country, postalCode, phone, distanceFromWH)
VALUES (11, 'All', 'NB', "", "", "", "", "", 0);

/* Adds bool field to delivery table to say wheter the delivery is enroute or not */
ALTER TABLE delivery ADD COLUMN enRoute boolean DEFAULT false;

/* Adds bool field to delivery table to say wheter the delivery is delivered or not */
ALTER TABLE delivery ADD COLUMN delivered boolean DEFAULT false;

/* Adds bool field to delivery table to say wheter the delivery is accepted or not */
ALTER TABLE delivery ADD COLUMN accepted boolean DEFAULT false;

/* Adds int field to txnItems to track their location */
ALTER TABLE txnitems ADD COLUMN itemLocation int DEFAULT 0;