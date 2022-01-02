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
    InventoryID INT PRIMARY KEY IDENTITY(1, 1),
    ProductID INT FOREIGN KEY REFERENCES Inventory(ProductID),
    Quantity INT,
    ProductItem NVARCHAR(100)
);

CREATE TABLE LineItem(
    LineItemID INT PRIMARY KEY IDENTITY(1, 1),
    ProductID INT FOREIGN KEY REFERENCES LineItem(ProductID),
    OrderID INTEGER,
    Quantity INT
);

CREATE TABLE Order(
    OrderID INT PRIMARY KEY IDENTITY(1, 1),
    OrderDate DATE,
    TotalAmountPlusPrice DECIMAL, 
    CustomerID INT FOREIGN KEY REFERENCES Order(CustomerID),
    StoreID NVARCHAR(100) INT FOREIGN KEY REFERENCES Order(StoreID)
);

CREATE TABLE Product(
    ProductID INT PRIMARY KEY IDENTITY(1, 1),
    ProductName NVARCHAR(100),
    ProductDescription NVARCHAR(100),
    Price DECIMAL 
);

INSERT INTO Product (ProductName, ProductDescription, Price) VALUES
('Boxing Gloves', '16oz gloves for ages 18+', 30.00),
('Football', 'Standard Size', 15.00),
('Dumbell', 'For ages 15+', 10.00);

SELECT * FROM Product


CREATE TABLE Store(
    StoreID INT PRIMARY KEY IDENTITY(1, 1),
    StoreName NVARCHAR(100),
    City NVARCHAR(100),
    State NVARCHAR (100),
    Address NVARCHAR (100)
);

INSERT INTO Store (StoreName, City, State, Address) VALUES
('LA Sports Store', 'Los Angeles', 'CA', '123 Water Street'),
('NYC Sports Store', 'New York City', 'NY', '123 Broad Street'),
('Chicago Sports Store', 'Chicago', 'IL', '123 West Stree');

SELECT * FROM Store

CREATE TABLE User(
    UserID INT PRIMARY KEY IDENTITY(1, 1),
    Username NVARCHAR(100),
    Password NVARCHAR(100),
    Name NVARCHAR(100),
    EmployeeNull NVARCHAR(100) FOREIGN KEY REFERENCES User(EmployeeNull),
);

CREATE TABLE User Type(
    UserTypeID INT PRIMARY KEY IDENTITY(1, 1),
    EmployeeNull NVARCHAR(100)
);