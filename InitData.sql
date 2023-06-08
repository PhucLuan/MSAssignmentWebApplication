---- Insert 3 Shops
--INSERT INTO Shop (Name, Location)
--VALUES ('Shop 1', 'Location 1'),
--       ('Shop 2', 'Location 2'),
--       ('Shop 3', 'Location 3');

---- Insert 3000 Products
--DECLARE @i INT = 1;
--WHILE (@i <= 3000)
--BEGIN
--    INSERT INTO Product (Name, Price, ShopID)
--    VALUES (CONCAT('Product ', @i), @i * 10.00, @i % 3 + 1);
--    SET @i = @i + 1;
--END;

-----------------------------------------------------------------

---- Insert 30 Customers using a while loop
-- Insert 30 Customers using a while loop
--DECLARE @i INT = 1;
--WHILE (@i <= 30)
--BEGIN
--    INSERT INTO Customer (FullName, DOB, Email)
--    VALUES (CONCAT('Customer ', @i), DATEADD(YEAR, -20, GETDATE()), CONCAT('customer', @i, '@example.com'));
--    SET @i = @i + 1;
--END;


---- Delete data from the table
--DELETE FROM Customer;

---- Reset the identity column
--DBCC CHECKIDENT ('Customer', RESEED, 0);



-- Load data from the database and sort it
SELECT c.FullName + ' - ' + c.Email AS 'Customer (Name - Email)',
       s.Name + ' - ' + s.Location AS 'Shop (Name - Location)',
       p.Name + ' - ' + CAST(p.Price AS VARCHAR(10)) AS 'Product (Name - Price)'
FROM Customer c
JOIN Purchase pu ON c.CustomerID = pu.CustomerID
JOIN Product p ON pu.ProductID = p.ProductID
JOIN Shop s ON p.ShopID = s.ShopID
ORDER BY c.Email ASC, s.Location DESC, p.Price DESC;
