use CompanyDB
go  

/*Create*/
CREATE TABLE Employees (
		Level hierarchyid NOT NULL UNIQUE,
		Name nvarchar(30) NOT NULL,
		Position nvarchar(30) NOT NULL
	);
go
/*
create procedure addEmployee 
@Level as varchar(1000), @Name as varchar(1000), @Position as varchar(1000)
as
BEGIN
INSERT Employees VALUES ( hierarchyid::Parse(@Level), @Name, @Position );
END
go
*/
create procedure addEmployee 
@Level as varchar(1000), @Name as varchar(1000), @Position as varchar(1000)
as
BEGIN
INSERT Employees VALUES ( hierarchyid::Parse(@Level), @Name, @Position );
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
/*
create procedure getEmployee 
@Level hierarchyid
as
BEGIN
SELECT Level.ToString() as [Level], Name, Position FROM Employees WHERE Level=@Level
END
go 

create procedure getEmployeeWithChildren
@Level varchar(100)
as
BEGIN
SELECT Level.ToString() as [Level], Name, Position FROM Employees WHERE Level.IsDescendantOf(hierarchyid::Parse(@Level)) = 1
END
go
*/
create procedure getEmployee 
@Level hierarchyid
as
BEGIN
SELECT Level as [Level], Name, Position FROM Employees WHERE Level=@Level
END
go 

create procedure getEmployeeWithChildren
@Level hierarchyid
as
BEGIN
SELECT Level as [Level], Name, Position FROM Employees WHERE Level.IsDescendantOf(@Level) = 1
END
go




create procedure getAllEmployees
as
BEGIN
SELECT Level.ToString() as [Level], Name, Position FROM Employees
END

go


/*Delete*/
drop table Employees
go

drop procedure addEmployee
go

drop procedure removeEmployee
go

drop procedure getEmployee
go

drop procedure getEmployeeWithChildren
go

drop procedure getAllEmployees
go

/*Insert*/

select * from dbo.[Employees]

INSERT dbo.[Employees] ([Level], [Name], [Position]) VALUES (N'/', N'Mark Hamilton', N'CEO')

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

EXEC getAllEmployees
go












/*
go

IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'hierarchy_CreateTree')
                    AND type IN ( N'P', N'PC' ) ) 
drop procedure hierarchy_CreateTree
go
create procedure hierarchy_CreateTree
@name varchar(100)
as
BEGIN
if not exists (select * from sysobjects where name='Company' and xtype='U')
    CREATE TABLE @name (
		Level hierarchyid NOT NULL UNIQUE,
		FirstName nvarchar(30) NOT NULL,
		LastName nvarchar(30) NOT NULL
	);
END
*/
go


    