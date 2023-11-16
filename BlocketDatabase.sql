CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY,
    CategoryName VARCHAR(50) NOT NULL
);


CREATE TABLE Ads (
    AdID INT PRIMARY KEY,
    Title VARCHAR(100) NOT NULL,
    Description TEXT,
    Price DECIMAL(10, 2) NOT NULL,
    CategoryID INT,
    FrontImagePath NVARCHAR(500), 
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);

