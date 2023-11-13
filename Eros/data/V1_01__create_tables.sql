CREATE TABLE IF NOT EXISTS PaymentMethods (
    ID_PaymentMethod SERIAL PRIMARY KEY,
    Name VARCHAR(255) NOT NULL
);

CREATE TABLE IF NOT EXISTS OrderStatuses (
    ID_OrderStatus SERIAL PRIMARY KEY,
    Name VARCHAR(255) NOT NULL
);

CREATE TABLE IF NOT EXISTS Categories (
    ID_Category SERIAL PRIMARY KEY,
    Name VARCHAR(255) NOT NULL
);

CREATE TABLE IF NOT EXISTS Users (
    ID_User SERIAL PRIMARY KEY,
    FirstName VARCHAR(255) NOT NULL,
    LastName VARCHAR(255) NOT NULL,
    Email VARCHAR(255) UNIQUE NOT NULL,
    Password VARCHAR(255) NOT NULL,
    Cash DECIMAL(10,2) NOT NULL
);

CREATE TABLE IF NOT EXISTS Products (
    ID_Product SERIAL PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Description TEXT NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL,
    Image VARCHAR(255) NOT NULL,
    ID_Category INT NOT NULL,
    FOREIGN KEY (ID_Category) REFERENCES Categories (ID_Category)
);

CREATE TABLE IF NOT EXISTS Carts (
    ID_Cart SERIAL PRIMARY KEY,
    ID_User INT NOT NULL,
    ID_Product INT NOT NULL,
    Quantity INT NOT NULL,
    FOREIGN KEY (ID_User) REFERENCES Users (ID_User),
    FOREIGN KEY (ID_Product) REFERENCES Products (ID_Product)
);

CREATE TABLE IF NOT EXISTS Addresses (
    ID_Address SERIAL PRIMARY KEY,
    ID_User INT NOT NULL,
    Type VARCHAR(255) NOT NULL,
    StreetAddress VARCHAR(255) NOT NULL,
    City VARCHAR(255) NOT NULL,
    State VARCHAR(255) NOT NULL,
    PostalCode VARCHAR(10) NOT NULL,
    FOREIGN KEY (ID_User) REFERENCES Users (ID_User)
);

CREATE TABLE IF NOT EXISTS Orders (
    ID_Order SERIAL PRIMARY KEY,
    ID_User INT NOT NULL,
    ID_PaymentMethod INT NOT NULL,
    ID_OrderStatus INT NOT NULL,
    TotalPrice DECIMAL(10,2) NOT NULL,
    DateOrder TIMESTAMP NOT NULL,
    FOREIGN KEY (ID_User) REFERENCES Users (ID_User),
    FOREIGN KEY (ID_PaymentMethod) REFERENCES PaymentMethods (ID_PaymentMethod),
    FOREIGN KEY (ID_OrderStatus) REFERENCES OrderStatuses (ID_OrderStatus)
);

CREATE TABLE IF NOT EXISTS OrderDetails (
    ID_OrderDetail SERIAL PRIMARY KEY,
    ID_Order INT NOT NULL,
    ProductDescription VARCHAR(255) NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (ID_Order) REFERENCES Orders (ID_Order)
);

CREATE TABLE IF NOT EXISTS AuditLogs (
    ID_AuditLog SERIAL PRIMARY KEY,
    ID_User INT,
    Action VARCHAR(255) NOT NULL,
    TableName VARCHAR(255) NOT NULL,
    RecordID INT,
    Timestamp TIMESTAMP NOT NULL
);

CREATE TABLE IF NOT EXISTS PaymentTransactions (
    ID_PaymentTransaction SERIAL PRIMARY KEY,
    ID_Order INT NOT NULL,
    Amount DECIMAL(10,2) NOT NULL,
    PaymentDate TIMESTAMP NOT NULL,
    Status VARCHAR(255) NOT NULL,
    FOREIGN KEY (ID_Order) REFERENCES Orders (ID_Order)
);
