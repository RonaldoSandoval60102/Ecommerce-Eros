INSERT INTO PaymentMethods (Name)
VALUES
    ('Credit Card'),
    ('PayPal'),
    ('Bank Transfer');

INSERT INTO OrderStatuses (Name)
VALUES
    ('Pending'),
    ('Processing'),
    ('Shipped'),
    ('Delivered');

INSERT INTO Users (FirstName, LastName, Email, Password, Cash)
VALUES
    ('John', 'Doe', 'john.doe@example.com', 'password', 1000.00),
    ('Jane', 'Smith', 'jane.smith@example.com', 'admin123', 750.50);

INSERT INTO Categories (Name)
VALUES
    ('Electronics'),
    ('Clothing'),
    ('Home');

INSERT INTO Products (Name, Description, Price, Stock, Image, ID_Category)
VALUES
    ('Smartphone', 'Latest-generation Android phone', 599.99, 50, 'phone.jpg', 1),
    ('T-shirt', 'High-quality cotton t-shirt', 19.99, 100, 'shirt.jpg', 2),
    ('Table Lamp', 'Modern LED table lamp for home', 49.99, 30, 'lamp.jpg', 3);

INSERT INTO Orders (ID_User, ID_PaymentMethod, ID_OrderStatus, TotalPrice, DateOrder)
VALUES
    (1, 1, 1, 599.99, '2023-11-04 10:00:00'),
    (2, 2, 1, 19.99, '2023-11-04 11:30:00');

INSERT INTO OrderDetails (ID_Order, ProductDescription, Quantity, Price)
VALUES
    (1,'Latest-generation Android phone', 1, 599.99),
    (2,'Modern LED table lamp for home', 2, 99.98);

INSERT INTO Carts (ID_User, ID_Product, Quantity)
VALUES
    (1, 1, 2),
    (2, 3, 1);

INSERT INTO Addresses (ID_User, Type, StreetAddress, City, State, PostalCode)
VALUES
    (1, 'Shipping', '123 Main St', 'Cityville', 'CA', '12345'),
    (1, 'Billing', '456 Oak St', 'Townsville', 'NY', '54321');

INSERT INTO AuditLogs (ID_User, Action, TableName, RecordID, Timestamp)
VALUES
    (1, 'CREATE', 'Users', 1, '2023-11-04 12:15:00'),
    (2, 'UPDATE', 'Products', 3, '2023-11-04 13:45:00');

INSERT INTO PaymentTransactions (ID_Order, Amount, PaymentDate, Status)
VALUES
    (1, 599.99, '2023-11-04 14:20:00', 'Approved'),
    (2, 19.99, '2023-11-04 15:00:00', 'Approved');
