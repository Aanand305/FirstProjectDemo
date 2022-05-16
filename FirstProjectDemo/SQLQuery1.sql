create database FIRSTPROJECT_DEMO 
USE FIRSTPROJECT_DEMO
create table Tbl_Users(
id int primary key identity,
Fname varchar(50),
Lname varchar(50),
Email varchar(50)unique,
Password varchar(50),
Gender varchar(10),
Profile_img varchar(max),
Isactive bit,
Isvarified bit,
Created_on datetime,
Updated_on datetime)

create table VarifyAccount
(id int primary key identity,
Otp varchar(10),
UserId int foreign key references Tbl_Users(id),
Sendtime datetime
)

select * from Tbl_Users
select * from VarifyAccount

create table Author(
id int primary key identity,
Author_Name varchar(50),
Author_Mobile varchar (10),
Author_Email varchar(50)
)

create table Books(
id int primary key identity,
Title varchar(50),
Price int,
Quantity int,
Published_On varchar(50),
Author_id int foreign key references Author(id)
)

insert into Author(Author_Name,Author_Mobile,Author_Email) values
('Ajay','9854621354','ajay@gmail.com'),
('Ravi','9851245684','ravi@gmail.com'),
('Rohan','9895756254','rohan@gmail.com')

insert into Books(Title,Price,Quantity,Published_On,Author_id) values
('ASP.NET',1000,50,GETDATE(),1),
('JAVA',1100,60,GETDATE(),1),
('ANDROID',1200,70,GETDATE(),2),
('C++',1300,80,GETDATE(),3),
('CSHARP',1400,90,GETDATE(),2)

select * from Author
select * from Books