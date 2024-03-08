create database assignment_prn_231;
go
use assignment_prn_231;
go
create table [Role](
	[Id] int Identity(1,1) primary key,
	[RoleName] nvarchar(MAX) NOT NULL CHECK ([RoleName] IN ('Admin', 'User', 'Staff')),
);
go
insert into [Role](RoleName) Values
('Admin'),('Staff'),('User')
go
create table [Account](
	[Id] int Identity(1,1) primary key,
	[Email] nvarchar(MAX) not null,
	[Password] nvarchar(MAX) not null,
	[FullName] nvarchar(MAX) not null,
	[DateOfBirth] date not null,
	[Address] nvarchar(MAX) not null,
	[RoleId] int foreign key references [Role](Id)
);
go
insert into [Account]([Email],[Password],[FullName],[DateOfBirth],[Address],[RoleId])
Values
('admin@gmail.com', 'Aa@123456', 'I am Admin', '2002-01-01', 'FPT UNIVERSITY', 1)
go
create table [Category](
	[Id] int Identity(1,1) primary key,
	[Name] nvarchar(MAX) not null
);
create table [Product](
	[Id] int Identity(1,1) primary key,
	[Name] nvarchar(MAX) not null,
	[Detail] nvarchar(MAX) not null,
	[Price] float not null,
	[CategoryId] int foreign key references [Category](Id)
);
