ALTER TABLE employee DROP COLUMN userName;
ALTER TABLE employee ADD COLUMN userName VARCHAR(25) DEFAULT NULL;

UPDATE employee
SET userName = CONCAT(LEFT(FirstName, 1), LastName)
WHERE employeeID IS NOT NULL
LIMIT 20; /* Satifies Safe mode error but limits the amount of users changed, ensure this number is higher than total users */

DROP TRIGGER IF EXISTS employee_insert;
DELIMITER #
CREATE TRIGGER employee_insert
    AFTER INSERT ON employee
    FOR EACH ROW
BEGIN
    UPDATE employee
    SET userName = CONCAT(LEFT(FirstName, 1), LastName),
        Email = CONCAT(LEFT(FirstName, 1), LastName, '@bullseye.com')
    WHERE EmployeeID = NEW.EmployeeID;

END #
DELIMITER ;