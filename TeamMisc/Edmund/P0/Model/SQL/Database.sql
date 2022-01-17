--creating a new dc in the server
create DATABASE SportsStore


-- turning off default auto close
alter DATABASE SportsStore
SET AUTO_CLOSE OFF

-- using sports instead of master database
USE SportsStore

-- tables take constraints
--which includes data type
-- not null (this column cannot be left empty)
-- unique (you can have duplicates of the data in this column)
--check (for additional checking)
--primary key ( = not null + unique ), foreign key (use with reference keyword)
-- default (for providing default value)

CREATE TABLE Inventory(
    InventoryID INT PRIMARY KEY IDENTITY,
    ProductID INT FOREIGN KEY REFERENCES Product(ProductID),
    Quantity INT,
    ProductItem NVARCHAR(100)
);

SELECT * FROM Inventory

CREATE TABLE LineItem(
    LineItemID INT PRIMARY KEY IDENTITY(1, 1),
    ProductID INT FOREIGN KEY REFERENCES Product(ProductID),
    OrderID INT,
    Quantity INT
);

SELECT * FROM LineItem


CREATE TABLE Orders(
    ID INT PRIMARY KEY IDENTITY,
    OrderDate DATE,
    TotalAmountPlusPrice DECIMAL, 
    CustomerID INT,
    StoreID INT FOREIGN KEY REFERENCES Store(ID)
);

CREATE TABLE Product(
    ProductID INT PRIMARY KEY IDENTITY(1, 1),
    ProductName VARCHAR(100),
    ProductDescription VARCHAR(100),
    Price DECIMAL 
);

INSERT INTO Product (ProductName, ProductDescription, Price) VALUES
('Boxing Gloves', '16oz gloves for ages 18+', 30.00),
('Football', 'Standard Size', 15.00),
('Dumbell', 'For ages 15+', 10.00);

SELECT * FROM Product


CREATE TABLE Store(
    ID INT PRIMARY KEY IDENTITY(1, 1),
    StoreName VARCHAR(100),
    City VARCHAR(100),
    State VARCHAR (100),
    Address VARCHAR (100)
);
SELECT * FROM Store

INSERT INTO Store (StoreName, City, State, Address) VALUES
('LA Sports Store', 'Los Angeles', 'CA', '123 Water Street'),
('NYC Sports Store', 'New York City', 'NY', '123 Broad Street'),
('Chicago Sports Store', 'Chicago', 'IL', '123 West Stree');

SELECT * FROM Store

CREATE TABLE Users(
    UserID INT PRIMARY KEY IDENTITY(1, 1),
    Username VARCHAR(100),
    Password VARCHAR(100),
    Name VARCHAR(100),
    EmployeeNull VARCHAR(100) FOREIGN KEY REFERENCES UserType(EmployeeNull),
);

CREATE TABLE UserType(
    UserTypeID INT PRIMARY KEY IDENTITY(1, 1),
    EmployeeNull VARCHAR(100)
);

SELECT * FROM UserType