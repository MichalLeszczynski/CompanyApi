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


/*Delete*/
drop table Employees
go

drop procedure AddEmployee
go

drop procedure RemoveEmployee
go

drop procedure RemoveAllEmployees
go

drop procedure GetEmployee
go

drop procedure GetEmployeeWithChildren
go

drop procedure GetAllEmployees
go

drop procedure GetMaxSalary
go

drop procedure GetAverageSalary
go

drop procedure GetSumSalary
go

/*Insert*/

select * from dbo.[Employees]

INSERT dbo.[Employees] ([Level], [Name], [Position], [Salary]) VALUES (N'/', N'Mark Hamilton', N'CEO', 20000)

INSERT dbo.[Employees] ([Level], [Name], [Position]) VALUES (N'/1/', N'James Smith', N'Vice President Finance')

INSERT dbo.[Employees] ([Level], [Name], [Position]) VALUES (N'/1/1/', N'Maria Garcia',  N'Chief Accountant')
INSERT dbo.[Employees] ([Level], [Name], [Position]) VALUES (N'/1/2/', N'Maria Rodriguez',  N'Chief Accountant')
INSERT dbo.[Employees] ([Level], [Name], [Position]) VALUES (N'/1/3/', N'Mary Smith',  N'Junior Accountant')


INSERT dbo.[Employees] ([Level], [Name], [Position]) VALUES (N'/2/', N'James Johnson', N'Vice President Manufacturing')

INSERT dbo.[Employees] ([Level], [Name], [Position]) VALUES (N'/2/1/', N'John Moore', N'Plant Manager')
INSERT dbo.[Employees] ([Level], [Name], [Position]) VALUES (N'/2/2/', N'Adam Nelson', N'Plant Manager')
INSERT dbo.[Employees] ([Level], [Name], [Position]) VALUES (N'/2/2/1/', N'Garry Baker', N'Maintanance Supervisor')


INSERT dbo.[Employees] ([Level], [Name], [Position]) VALUES (N'/3/', N'Hilda Hall', N'Vice President Marketing')

INSERT dbo.[Employees] ([Level], [Name], [Position]) VALUES (N'/3/1/', N'Selena Gomez',  N'Sales Manager')
INSERT dbo.[Employees] ([Level], [Name], [Position]) VALUES (N'/3/2/', N'David Diaz', N'Advertising Manager')
INSERT dbo.[Employees] ([Level], [Name], [Position]) VALUES (N'/3/2/1/', N'Michael Parker', N'Account Executive')


INSERT dbo.[Employees] ([Level], [Name], [Position]) VALUES (N'/4/', N'Penelope Cruz', N'Vice President HR')

INSERT dbo.[Employees] ([Level], [Name], [Position]) VALUES (N'/4/1/', N'Sherlock Holmes', N'HR Manager')
INSERT dbo.[Employees] ([Level], [Name], [Position]) VALUES (N'/4/2/', N'Joseph Murphy', N'Recruit Manager')
INSERT dbo.[Employees] ([Level], [Name], [Position]) VALUES (N'/4/2/1/', N'',  N'Recruiter')
INSERT dbo.[Employees] ([Level], [Name], [Position]) VALUES (N'/4/2/2/', N'', N'Recruiter')
INSERT dbo.[Employees] ([Level], [Name], [Position]) VALUES (N'/4/2/2/1/', N'', N'Recruit Assistant')

INSERT dbo.[Employees] ([Level], [Name], [Position]) VALUES ('/4/2/2/1/', N'', N'Recruit Assistant')

/*Debug*/

EXEC RemoveAllEmployees
go



    