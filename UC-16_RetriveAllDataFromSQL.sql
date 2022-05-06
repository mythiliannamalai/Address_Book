USE [Address_Book_Service]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [GetAllDataFromSQL]
AS
BEGIN
	select CreateAddressBook.FirstName,LastName,Address,City,State,Zipcode,PhoneNumber,EmailId from CreateAddressBook; 
END
GO

