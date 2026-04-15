CREATE DATABASE Company;
GO

USE Company;
GO

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(100),
    PhoneNumber VARCHAR(20),
    HireDate DATE,
    JobTitle VARCHAR(50),
    Salary DECIMAL(10, 2),
    Department VARCHAR(50)
);
GO

INSERT INTO Employees (FirstName, LastName, Email, PhoneNumber, HireDate, JobTitle, Salary, Department)
VALUES 
('Leyla', 'Həsənova', 'leyla.h@company.az', '055-111-22-33', '2019-05-15', 'Kadrlar mütəxəssisi', 1200.00, 'HR'),
('Anar', 'Məmmədov', 'anar.m@company.az', '050-222-33-44', '2021-02-10', 'Proqramçı', 3000.00, 'IT'),
('Nigar', 'Əliyeva', 'nigar.e@other.com', '070-333-44-55', '2022-08-20', 'Analitik', 2200.00, 'IT'),
('Rəşad', 'Quliyev', 'rashad.q@company.az', '055-444-55-66', '2018-11-01', 'Mühasib', 2600.00, 'Maliyyə'),
('Elvin', 'Paşayev', 'elvin.p@company.az', '050-555-66-77', '2020-01-12', 'Sistem Admini', 1400.00, 'IT');
GO
SELECT * FROM Employees;
GO

SELECT * FROM Employees WHERE Salary > 2000;
GO

SELECT * FROM Employees WHERE Department = 'IT';
GO

SELECT * FROM Employees ORDER BY Salary DESC;
GO

SELECT FirstName, Salary FROM Employees;
GO

SELECT * FROM Employees WHERE HireDate > '2020-12-31';
GO

SELECT * FROM Employees WHERE Email LIKE '%company.az%';
GO
SELECT MAX(Salary) AS En_Yuksek_Maas FROM Employees;
GO

SELECT MIN(Salary) AS En_Asagi_Maas FROM Employees;
GO

SELECT AVG(Salary) AS Ortalama_Maas FROM Employees;
GO

SELECT COUNT(*) AS Umumi_Isci_Sayi FROM Employees;
GO

SELECT SUM(Salary) AS Umumi_Maas_Cemi FROM Employees;
GO
SELECT Department, COUNT(*) AS Isci_Sayi 
FROM Employees 
GROUP BY Department;
GO

SELECT Department, AVG(Salary) AS Ortalama_Maas 
FROM Employees 
GROUP BY Department;
GO

SELECT Department, MAX(Salary) AS En_Yuksek_Maas 
FROM Employees 
GROUP BY Department;
GO
UPDATE Employees 
SET Salary = 2800 
WHERE EmployeeID = 1;
GO

UPDATE Employees 
SET Salary = Salary * 1.10 
WHERE Department = 'IT';
GO

UPDATE Employees 
SET JobTitle = 'HR Meneceri' 
WHERE FirstName = 'Leyla' AND LastName = 'Həsənova';
GO
DELETE FROM Employees 
WHERE EmployeeID = 5;
GO

DELETE FROM Employees 
WHERE Salary < 1500;
GO
SELECT * FROM Employees 
WHERE FirstName LIKE '%a%';
GO

SELECT * FROM Employees 
WHERE Salary BETWEEN 2000 AND 2500;
GO

SELECT * FROM Employees 
WHERE Department IN ('Maliyyə', 'IT');
GO