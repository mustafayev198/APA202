CREATE DATABASE CompanyMM;
GO

USE CompanyMM;
GO

CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    BirthDate DATE,
    Email NVARCHAR(100) UNIQUE,
    CONSTRAINT CHK_BirthDate CHECK (BirthDate < GETDATE())
);

CREATE TABLE Projects (
    ProjectID INT IDENTITY(1,1) PRIMARY KEY,
    ProjectName NVARCHAR(100) NOT NULL,
    StartDate DATE,
    EndDate DATE,
    CONSTRAINT CHK_ProjectDates CHECK (EndDate IS NULL OR EndDate >= StartDate)
);

CREATE TABLE EmployeeProjects (
    EmployeeID INT,
    ProjectID INT,
    AssignedDate DATE DEFAULT GETDATE(),
    CONSTRAINT PK_EmployeeProjects PRIMARY KEY (EmployeeID, ProjectID),
    CONSTRAINT FK_Employee FOREIGN KEY (EmployeeID)
        REFERENCES Employees(EmployeeID) ON DELETE CASCADE,
    CONSTRAINT FK_Project FOREIGN KEY (ProjectID)
        REFERENCES Projects(ProjectID) ON DELETE CASCADE
);

INSERT INTO Employees (FirstName, LastName, BirthDate, Email) VALUES
('Ali', 'Mammadov', '1990-05-10', 'ali@mail.com'),
('Leyla', 'Aliyeva', '1992-07-15', 'leyla@mail.com'),
('Rashad', 'Huseynov', '1988-03-22', 'rashad@mail.com'),
('Nigar', 'Hasanova', '1995-11-30', 'nigar@mail.com'),
('Elvin', 'Quliyev', '1991-09-09', 'elvin@mail.com');

INSERT INTO Projects (ProjectName, StartDate, EndDate) VALUES
('Website Development', '2024-01-01', '2024-06-01'),
('Mobile App', '2024-02-01', '2024-08-01'),
('AI System', '2024-03-01', NULL);

INSERT INTO EmployeeProjects (EmployeeID, ProjectID) VALUES
(1,1),(1,2),(2,1),(3,2),(3,3),(4,3),(5,1);

SELECT * FROM Employees;

SELECT * FROM Projects;

SELECT e.EmployeeID, e.FirstName, e.LastName, p.ProjectName
FROM Employees e
JOIN EmployeeProjects ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects p ON ep.ProjectID = p.ProjectID;

SELECT p.ProjectName, COUNT(ep.EmployeeID) AS EmployeeCount
FROM Projects p
LEFT JOIN EmployeeProjects ep ON p.ProjectID = ep.ProjectID
GROUP BY p.ProjectName;

SELECT e.EmployeeID, e.FirstName, e.LastName, COUNT(ep.ProjectID) AS ProjectCount
FROM Employees e
JOIN EmployeeProjects ep ON e.EmployeeID = ep.EmployeeID
GROUP BY e.EmployeeID, e.FirstName, e.LastName
HAVING COUNT(ep.ProjectID) > 2;
GO

CREATE VIEW EmployeeProjectView AS
SELECT 
    e.EmployeeID,
    e.FirstName + ' ' + e.LastName AS FullName,
    p.ProjectID,
    p.ProjectName,
    ep.AssignedDate
FROM Employees e
JOIN EmployeeProjects ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects p ON ep.ProjectID = p.ProjectID;
GO

SELECT * FROM EmployeeProjectView
WHERE EmployeeID = 1;
GO

CREATE PROCEDURE sp_AssignEmployeeToProject
    @empId INT,
    @projId INT
AS
BEGIN
    IF NOT EXISTS (
        SELECT 1 FROM EmployeeProjects
        WHERE EmployeeID = @empId AND ProjectID = @projId
    )
    BEGIN
        INSERT INTO EmployeeProjects (EmployeeID, ProjectID)
        VALUES (@empId, @projId);
    END
END;
GO

CREATE FUNCTION fn_GetProjectCount(@empId INT)
RETURNS INT
AS
BEGIN
    DECLARE @total INT;

    SELECT @total = COUNT(*)
    FROM EmployeeProjects
    WHERE EmployeeID = @empId;

    RETURN @total;
END;
GO

SELECT dbo.fn_GetProjectCount(1) AS ProjectCount;

EXEC sp_AssignEmployeeToProject @empId = 2, @projId = 3;

SELECT * FROM EmployeeProjects;

DELETE FROM EmployeeProjects
WHERE EmployeeID = 1;

SELECT * FROM EmployeeProjects;