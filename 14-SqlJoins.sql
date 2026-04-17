
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Company')
BEGIN
    CREATE DATABASE Company;
END
GO

USE Company;
GO

IF OBJECT_ID('Employees', 'U') IS NOT NULL DROP TABLE Employees;
IF OBJECT_ID('Cities', 'U') IS NOT NULL DROP TABLE Cities;
IF OBJECT_ID('Countries', 'U') IS NOT NULL DROP TABLE Countries;
GO


CREATE TABLE Countries (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE Cities (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    CountryId INT FOREIGN KEY REFERENCES Countries(Id)
);
GO

CREATE TABLE Employees (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL,
    Surname NVARCHAR(50) NOT NULL,
    Age INT,
    Salary DECIMAL(18,2),
    Position NVARCHAR(100),
    IsDeleted BIT DEFAULT 0, 
    CityId INT FOREIGN KEY REFERENCES Cities(Id)
);
GO


INSERT INTO Countries (Name) 
VALUES ('Azərbaycan'), ('Türkiyə'), ('ABŞ');

INSERT INTO Cities (Name, CountryId) 
VALUES ('Bakı', 1), ('Gəncə', 1), ('İstanbul', 2), ('Ankara', 2), ('Nyu-York', 3);

INSERT INTO Employees (Name, Surname, Age, Salary, Position, IsDeleted, CityId) 
VALUES 
('Əli', 'Məmmədov', 28, 2500.00, 'Developer', 0, 1),
('Aygün', 'Əliyeva', 24, 1500.00, 'Reseption', 0, 1),
('Murad', 'Həsənov', 35, 3200.00, 'Menecer', 0, 3),
('Leyla', 'Quliyeva', 22, 1200.00, 'Reseption', 1, 2), 
('Con', 'Smit', 40, 4500.00, 'Direktor', 0, 5);
GO


PRINT '--- 1. İşçilərin özlərini, yaşadıqları şəhərlərini və ölkələrini göstərin ---';
SELECT 
    E.Name, 
    E.Surname, 
    C.Name AS CityName, 
    Co.Name AS CountryName
FROM Employees E
JOIN Cities C ON E.CityId = C.Id
JOIN Countries Co ON C.CountryId = Co.Id;

PRINT '--- 2. Maaşı 2000-dən yuxarı olan işçilərin adları və yaşadıqları ölkələri göstərin ---';
SELECT 
    E.Name, 
    Co.Name AS CountryName
FROM Employees E
JOIN Cities C ON E.CityId = C.Id
JOIN Countries Co ON C.CountryId = Co.Id
WHERE E.Salary > 2000;

PRINT '--- 3. Hansı şəhərin hansı ölkəyə aid olduğunu göstərin ---';
SELECT 
    C.Name AS CityName, 
    Co.Name AS CountryName
FROM Cities C
JOIN Countries Co ON C.CountryId = Co.Id;

PRINT '--- 4. Position-i "Reseption" olan işçilərin ID-lər daxil olmamaq şərti ilə bütün məlumatlarını göstərmək ---';
SELECT 
    E.Name, 
    E.Surname, 
    E.Age, 
    E.Salary, 
    E.Position, 
    E.IsDeleted,
    C.Name AS CityName, 
    Co.Name AS CountryName
FROM Employees E
JOIN Cities C ON E.CityId = C.Id
JOIN Countries Co ON C.CountryId = Co.Id
WHERE E.Position = 'Reseption';

PRINT '--- 5. İşdən çıxan işçilərin yaşadıqları şəhər və ölkələri, həmçinin ad və soyadlarını göstərən query ---';
SELECT 
    E.Name, 
    E.Surname, 
    C.Name AS CityName, 
    Co.Name AS CountryName
FROM Employees E
JOIN Cities C ON E.CityId = C.Id
JOIN Countries Co ON C.CountryId = Co.Id
WHERE E.IsDeleted = 1;
GO