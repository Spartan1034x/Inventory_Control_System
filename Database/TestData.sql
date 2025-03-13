INSERT INTO Txn (employeeID, siteIDTo, siteIDFrom, txnStatus, shipDate, txnType, barCode, createdDate, deliveryID, emergencyDelivery, notes)
VALUES 
(1008, 2, 4, 'NEW', '2025-02-21 18:09:08', 'Curbside', 'BC722843', '2023-02-12 18:09:08', NULL, 0, 'Auto-generated test order'),
(1001, 3, 5, 'CANCELLED', '2025-02-19 18:09:08', 'Online', 'BC684109', '2023-02-12 18:09:08', NULL, 0, 'Auto-generated test order'),
(1003, 6, 2, 'ASSEMBLING', '2025-02-19 18:09:08', 'Return', 'BC249579', '2023-02-12 18:09:08', NULL, 0, 'Auto-generated test order'),
(1009, 9, 8, 'ASSEMBLED', '2025-02-17 18:09:08', 'Store Order', 'BC724974', '2023-02-12 18:09:08', NULL, 0, 'Auto-generated test order'),
(1001, 9, 4, 'IN TRANSIT', '2025-02-17 18:09:08', 'Sale', 'BC520087', '2023-02-12 18:09:08', NULL, 0, 'Auto-generated test order'),
(1001, 10, 6, 'DELIVERED', '2025-02-13 18:09:08', 'Sale', 'BC640762', '2023-02-12 18:09:08', NULL, 0, 'Auto-generated test order'),
(1005, 7, 10, 'DELIVERED', '2025-02-13 18:09:08', 'Supplier Order', 'BC973999', '2023-02-12 18:09:08', NULL, 0, 'Auto-generated test order'),
(1008, 9, 10, 'CANCELLED', '2025-02-20 18:09:08', 'Correction', 'BC892305', '2023-02-12 18:09:08', NULL, 0, 'Auto-generated test order'),
(1000, 9, 5, 'NEW', '2025-02-22 18:09:08', 'Online', 'BC271932', '2023-02-12 18:09:08', NULL, 0, 'Auto-generated test order'),
(1000, 7, 10, 'NEW', '2025-02-14 18:09:08', 'Return', 'BC981289', '2023-02-12 18:09:08', NULL, 0, 'Auto-generated test order'),
(1004, 4, 1, 'IN TRANSIT', '2025-02-20 18:09:08', 'Rejected', 'BC617241', '2023-02-12 18:09:08', NULL, 0, 'Auto-generated test order'),
(1010, 8, 1, 'SUBMITTED', '2025-02-17 18:09:08', 'Gain', 'BC854452', '2023-02-12 18:09:08', NULL, 0, 'Auto-generated test order'),
(1008, 4, 5, 'DELIVERED', '2025-02-14 18:09:08', 'Emergency Order', 'BC387629', '2023-02-12 18:09:08', NULL, 0, 'Auto-generated test order'),
(1005, 4, 1, 'NEW', '2025-02-21 18:09:08', 'Loss', 'BC994926', '2023-02-12 18:09:08', NULL, 0, 'Auto-generated test order'),
(1009, 4, 5, 'ASSEMBLING', '2025-02-17 18:09:08', 'Damage', 'BC167923', '2023-02-12 18:09:08', NULL, 0, 'Auto-generated test order'),
(1005, 5, 7, 'ASSEMBLING', '2025-02-16 18:09:08', 'Damage', 'BC329543', '2023-02-12 18:09:08', NULL, 0, 'Auto-generated test order'),
(1005, 8, 4, 'ASSEMBLING', '2025-02-17 18:09:08', 'Correction', 'BC937754', '2023-02-12 18:09:08', NULL, 0, 'Auto-generated test order'),
(1006, 8, 1, 'COMPLETE', '2025-02-13 18:09:08', 'Sale', 'BC731060', '2023-02-12 18:09:08', NULL, 0, 'Auto-generated test order'),
(1009, 6, 2, 'CANCELLED', '2025-02-19 18:09:08', 'Online', 'BC521897', '2023-02-12 18:09:08', NULL, 0, 'Auto-generated test order'),
(1006, 8, 9, 'ASSEMBLING', '2025-02-18 18:09:08', 'Correction', 'BC367198', '2023-02-12 18:09:08', NULL, 0, 'Auto-generated test order')
(1011, 7, 3, 'SUBMITTED', '2025-02-23 18:09:08', 'Online', 'BC123456', NOW(), NULL, 0, 'Auto-generated test order');


/* Query that sets all createdDate to 2023-02-12 18:09:08 in txn table and disable safe mode for 1 entry */
SET SQL_SAFE_UPDATES = 0;
UPDATE txn
SET createdDate = '2023-02-12 18:09:08';
SET SQL_SAFE_UPDATES = 1;


/* Add username column */
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

/* Add a new column to the delivery table type blob default null and named 'signature' */
ALTER TABLE delivery ADD COLUMN 'signature' BLOB DEFAULT NULL;

/* Set quantity to 0 for all items in the inventory table where siteID = 3 */
UPDATE inventory
SET quantity = 0
WHERE siteID = 3;