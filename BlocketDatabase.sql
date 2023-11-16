CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    CategoryName VARCHAR(50) NOT NULL UNIQUE
);
CREATE TABLE Ads (
    AdID INT PRIMARY KEY IDENTITY(1,1),
    Title VARCHAR(100) NOT NULL,
    Description TEXT NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    CategoryID INT,
    FrontImagePath NVARCHAR(255), -- Nullable
    SecondImagePath NVARCHAR(255), -- Nullable
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);