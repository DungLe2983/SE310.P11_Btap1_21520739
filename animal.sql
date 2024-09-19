USE master;
GO


CREATE DATABASE FarmManagementDB;
GO

USE FarmManagementDB;
GO

CREATE TABLE Animals
(
    AnimalID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(50) NOT NULL,
    Voice NVARCHAR(50) NOT NULL,
    Count INT NOT NULL
);
GO


ALTER TABLE Animals
ADD NumberOfOffspring INT,
    MilkProduced INT;
GO

UPDATE Animals
SET NumberOfOffspring = ROUND(RAND() * 5 + 1, 0), 
    MilkProduced = CASE 
                        WHEN Name = 'Bò' THEN ROUND(RAND() * 20, 0) + 1  
                        WHEN Name = 'Cừu' THEN ROUND(RAND() * 5, 0) + 1   
                        WHEN Name = 'Dê' THEN ROUND(RAND() * 10, 0) + 1   
                        ELSE 0
                     END

SELECT * FROM Animals