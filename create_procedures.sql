use CompanyDB
go  

/*Create*/
CREATE TABLE Employees (
		Level hierarchyid NOT NULL UNIQUE,
		Name nvarchar(30) NOT NULL,
		Position nvarchar(30) NOT NULL,
		Salary Int NOT NULL
	);
go


create procedure AddEmployee 
@Level as varchar(1000), @Name as varchar(1000), @Position as varchar(1000), @Salary as Int
as
BEGIN
INSERT Employees VALUES ( hierarchyid::Parse(@Level), @Name, @Position, @Salary );
END
go

create procedure RemoveEmployee 
@Level hierarchyid
as
BEGIN
DELETE FROM Employees
WHERE Level=@Level 
END
go 

create procedure RemoveAllEmployees
as
BEGIN
DELETE FROM Employees
END
go 

create procedure GetEmployee 
@Level hierarchyid
as
BEGIN
SELECT Level as [Level], Name, Position, Salary FROM Employees WHERE Level=@Level
END
go 

create procedure GetEmployeeWithChildren
@Level hierarchyid
as
BEGIN
SELECT Level as [Level], Name, Position, Salary FROM Employees WHERE Level.IsDescendantOf(@Level) = 1
END
go


create procedure GetAllEmployees
as
BEGIN
SELECT Level as [Level], Name, Position, Salary FROM Employees
END
go


create procedure GetMaxSalary
as
BEGIN
SELECT MAX(Salary) as Salary FROM Employees
END
go

create procedure GetAverageSalary
as
BEGIN
SELECT AVG(Salary) as Salary FROM Employees
END
go

create procedure GetSumSalary
as
BEGIN
SELECT SUM(Salary) as Salary FROM Employees
END
go
