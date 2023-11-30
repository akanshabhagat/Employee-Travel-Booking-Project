CREATE DATABASE Assignment;
-- Use the newly created database
USE Assignment;

-- Creating EmployeeInfo Table
CREATE TABLE EmployeeInfo (
    EmpID INT PRIMARY KEY,
    EmpFname VARCHAR(50),
    EmpLname VARCHAR(50),
    Department VARCHAR(50),
    Project VARCHAR(50),
    Address VARCHAR(100),
    DOB DATE,
    Gender CHAR(1)
);

-- Inserting data into EmployeeInfo Table
INSERT INTO EmployeeInfo (EmpID, EmpFname, EmpLname, Department, Project, Address, DOB, Gender)
VALUES
    (1, 'Sanjay', 'Mehra', 'HR', 'P1', 'Hyderabad(HYD)', '1976-12-01', 'M'),
    (2, 'Ananya', 'Mishra', 'Admin', 'P2', 'Delhi(DEL)', '1968-05-02', 'F'),
    (3, 'Rohan', 'Diwan', 'Account', 'P3', 'Mumbai(BOM)', '1980-01-01', 'M'),
    (4, 'Sonia', 'Kulkarni', 'HR', 'P1', 'Hyderabad(HYD)', '1992-05-02', 'F'),
    (5, 'Ankit', 'Kapoor', 'Admin', 'P2', 'Delhi(DEL)', '1994-07-03', 'M');

-- Creating EmployeePosition Table
CREATE TABLE EmployeePosition (
    EmpID INT,
    EmpPosition VARCHAR(50),
    DateOfJoining DATE,
    Salary DECIMAL(10, 2),
    FOREIGN KEY (EmpID) REFERENCES EmployeeInfo(EmpID)
);

-- Inserting data into EmployeePosition Table
INSERT INTO EmployeePosition (EmpID, EmpPosition, DateOfJoining, Salary)
VALUES
    (1, 'Manager', '2022-05-01', 500000),
    (2, 'Executive', '2022-05-02', 75000),
    (3, 'Manager', '2022-05-01', 90000),
    (2, 'Lead', '2022-05-02', 85000),
    (1, 'Executive', '2022-05-01', 300000);

--query to fetch the number of employees working in the department ‘HR’  
SELECT COUNT(*) AS NumberOfEmployees
FROM EmployeeInfo
WHERE Department = 'HR';

--) Write a query to find all the employees whose salary is between 50000 to 100000.  
SELECT *
FROM EmployeePosition
WHERE Salary BETWEEN 50000 AND 100000;

--Write a query to find the names of employees that begin with ‘S’  
SELECT EmpFname, EmpLname
FROM EmployeeInfo
WHERE EmpFname LIKE 'S%';

--Write a query to fetch all the records from the EmployeeInfo table ordered by EmpLname in descending order and Department in the ascending order.  
SELECT *
FROM EmployeeInfo
ORDER BY EmpLname DESC, Department ASC;

-- Write a query to fetch details of employees whose EmpLname ends with an alphabet ‘A’ and contains five alphabets.  
SELECT *
FROM EmployeeInfo
WHERE EmpLname LIKE '____A' COLLATE Latin1_General_BIN;

-- Write a query to fetch details of all employees excluding the employees with first names, “Sanjay” and “Sonia” from the EmployeeInfo table.  
SELECT *
FROM EmployeeInfo
WHERE EmpFname NOT IN ('Sanjay', 'Sonia');

--Write a query to fetch all employees who also hold the managerial position. 
SELECT E.*
FROM EmployeeInfo E
JOIN EmployeePosition P ON E.EmpID = P.EmpID
WHERE P.EmpPosition = 'Manager';

