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