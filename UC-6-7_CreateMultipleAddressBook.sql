USE [Address_Book_Service]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Create_Multipul_AddressBook]
AS
BEGIN
	create table Family(
	FirstName varchar(50) unique,
LastName varchar(50),
Address varchar(50),
City varchar(50),
State varchar(50),
Zipcode varchar(20),
PhoneNumber varchar(20),
EmailId varchar(20));

create table Office(
	FirstName varchar(50) unique,
LastName varchar(50),
Address varchar(50),
City varchar(50),
State varchar(50),
Zipcode varchar(20),
PhoneNumber varchar(20),
EmailId varchar(20));

END
GO

select * from Office;