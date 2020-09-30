IF OBJECT_ID('Units') IS NULL
CREATE TABLE [dbo].[Units] (
    [ID]        INT           IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Unit_Name] VARCHAR (200) NULL,
	[Last_Edit] DATETIME
);
GO

IF OBJECT_ID('Currency') IS NULL
CREATE TABLE [dbo].[Currency] (
    [ID]            INT           IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [Currency_Name] VARCHAR (100) NULL,
    [Currency_Abbr] VARCHAR (20)  NULL,
	[Last_Edit] DATETIME
);
GO

IF OBJECT_ID('Category') IS NULL
CREATE TABLE [dbo].[Category] (
    [ID]            INT           IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [Category_Name] VARCHAR (200) NULL,
	[Last_Edit] DATETIME
);
GO

IF OBJECT_ID('Product') IS NULL
CREATE TABLE [dbo].[Product] (
    [ID]           INT             IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [Product_Name] VARCHAR (200)   NULL,
	[CategoryXID]  INT REFERENCES Category(ID),
    [UnitXID]      INT             REFERENCES Units(ID),
    [Price]        DECIMAL (10, 2) NULL,
    [CurrencyXID]  INT             REFERENCES Currency(ID),
	[Last_Edit]    DATETIME
);
GO

IF OBJECT_ID('GetAllCurrencies') IS NOT NULL
DROP PROCEDURE [dbo].[GetAllCurrencies]
GO

CREATE PROCEDURE [dbo].[GetAllCurrencies]
AS
BEGIN

	SELECT	ID
			, C.Currency_Abbr [Currency_Name]
	FROM	dbo.Currency C

END
GO

IF OBJECT_ID('GetAllUnits') IS NOT NULL
DROP PROCEDURE [dbo].[GetAllUnits]
GO

CREATE PROCEDURE [dbo].[GetAllUnits]
AS
BEGIN

	SELECT	ID
			, U.Unit_Name [Unit_Name]
	FROM	dbo.Units U

END
GO

IF OBJECT_ID('GetAllCategories') IS NOT NULL
DROP PROCEDURE [dbo].[GetAllCategories]
GO

CREATE PROCEDURE [dbo].[GetAllCategories]
AS
BEGIN

	SELECT	C.ID
			, C.Category_Name [Category_Name]
			, Case When ISNULL(P.ID, -1) < 0 Then 0 Else 1 End [In_Use]
	FROM	dbo.Category C
			Left Join dbo.Product P ON P.CategoryXID = C.ID
	Group By C.ID, C.Category_Name, Case When ISNULL(P.ID, -1) < 0 Then 0 Else 1 End

END
GO

IF OBJECT_ID('GetCategory') IS NOT NULL
DROP PROCEDURE [dbo].[GetCategory]
GO

CREATE PROCEDURE [dbo].[GetCategory]
	@ID INT
AS
BEGIN

	SELECT	C.ID
			, C.Category_Name [Category_Name]
			, Case When ISNULL(P.ID, -1) < 0 Then 0 Else 1 End [In_Use]
	FROM	dbo.Category C
			Left Join dbo.Product P ON P.CategoryXID = C.ID
	WHERE	C.ID = @ID
	Group By C.ID, C.Category_Name, Case When ISNULL(P.ID, -1) < 0 Then 0 Else 1 End

END
GO

IF OBJECT_ID('GetProduct') IS NOT NULL
DROP PROCEDURE [dbo].[GetProduct]
GO

CREATE PROCEDURE [dbo].[GetProduct]
	@ID INT
AS
BEGIN

	SELECT	P.ID
			, P.Product_Name [Product_Name]
			, CT.ID [Category_ID]
			, CT.Category_Name [Category_Name]
			, U.ID [Unit_ID]
			, U.Unit_Name [Unit_Name]
			, C.ID [Currency_ID]
			, C.Currency_Name [Currency_Name]
			, P.Price [Price]
	FROM	dbo.Product P
			INNER JOIN dbo.Currency C ON C.ID = P.CurrencyXID
			INNER JOIN dbo.Units U ON U.ID	 = P.UnitXID
			INNER JOIN dbo.Category CT ON CT.ID = P.CategoryXID
	WHERE	P.ID = @ID

END
GO

IF OBJECT_ID('GetAllProducts') IS NOT NULL
DROP PROCEDURE [dbo].[GetAllProducts]
GO

CREATE PROCEDURE [dbo].[GetAllProducts]
AS
BEGIN

	SELECT	P.ID
			, P.Product_Name [Product_Name]
			, CT.ID [Category_ID]
			, CT.Category_Name [Category_Name]
			, U.ID [Unit_ID]
			, U.Unit_Name [Unit_Name]
			, C.ID [Currency_ID]
			, C.Currency_Name [Currency_Name]
			, P.Price [Price]
	FROM	dbo.Product P
			INNER JOIN dbo.Currency C ON C.ID = P.CurrencyXID
			INNER JOIN dbo.Units U ON U.ID	 = P.UnitXID
			INNER JOIN dbo.Category CT ON CT.ID = P.CategoryXID

END
GO

IF OBJECT_ID('CreateProduct') IS NOT NULL
DROP PROCEDURE [dbo].[CreateProduct]
GO

CREATE PROCEDURE [dbo].[CreateProduct]
	@Product_Name Varchar(200),
    @CategoryXID Int,
    @UnitXID Int,
    @Price Decimal(10,4),
	@CurrencyXID Int
AS
Begin
	
	Insert Into dbo.Product
		(
			Product_Name
			, CategoryXID
			, UnitXID
			, Price
			, CurrencyXID
			, Last_Edit
		)
	Values
		(
			@Product_Name
			, @CategoryXID
			, @UnitXID
			, @Price
			, @CurrencyXID
			, GETDATE()
		)

	Select	SCOPE_IDENTITY() [ID]

End
GO

IF OBJECT_ID('UpdateProduct') IS NOT NULL
DROP PROCEDURE [dbo].[UpdateProduct]
GO

CREATE PROCEDURE [dbo].[UpdateProduct]
	@ID INT,
	@Product_Name Varchar(200),
    @CategoryXID Int,
    @UnitXID Int,
    @Price Decimal(10,4),
	@CurrencyXID Int
AS
Begin
	
	Update	dbo.Product
	Set
		Product_Name = @Product_Name
		, CategoryXID = @CategoryXID
		, UnitXID = @UnitXID
		, Price = @Price
		, CurrencyXID = @CurrencyXID
		, Last_Edit = GETDATE()
	Where	ID = @ID

	Select	@ID [ID]

End
GO

IF OBJECT_ID('DeleteProduct') IS NOT NULL
DROP PROCEDURE [dbo].[DeleteProduct]
GO

CREATE PROCEDURE [dbo].[DeleteProduct]
	@ID INT
AS
Begin
	
	Delete From dbo.Product
	Where	ID = @ID

	Select	@ID [ID]

End
GO

IF OBJECT_ID('CreateCategory') IS NOT NULL
DROP PROCEDURE [dbo].[CreateCategory]
GO

CREATE PROCEDURE [dbo].[CreateCategory]
	@Category_Name Varchar(200)
AS
Begin
	
	Insert Into dbo.Category
		(
			Category_Name
			, Last_Edit
		)
	Values
		(
			@Category_Name
			, GETDATE()
		)

	Select	SCOPE_IDENTITY() [ID]

End
GO

IF OBJECT_ID('UpdateCategory') IS NOT NULL
DROP PROCEDURE [dbo].[UpdateCategory]
GO

CREATE PROCEDURE [dbo].[UpdateCategory]
	@ID INT,
	@Category_Name Varchar(200)
AS
Begin
	
	Update	dbo.Category
	Set
		Category_Name = @Category_Name
		, Last_Edit = GETDATE()
	Where	ID = @ID

	Select	@ID [ID]

End
GO

IF OBJECT_ID('DeleteCategory') IS NOT NULL
DROP PROCEDURE [dbo].[DeleteCategory]
GO

CREATE PROCEDURE [dbo].[DeleteCategory]
	@ID INT
AS
Begin
	
	Delete From dbo.Category
	Where	ID = @ID

	Select	@ID [ID]

End
GO

IF NOT EXISTS(Select 1 From dbo.Currency C Where C.Currency_Abbr = 'INR')
Insert Into dbo.Currency(Currency_Name, Currency_Abbr)
Values ('Indian Rupees', 'INR')

IF NOT EXISTS(Select 1 From dbo.Currency C Where C.Currency_Abbr = 'USD')
Insert Into dbo.Currency(Currency_Name, Currency_Abbr)
Values ('US Dollar', 'USD')

IF NOT EXISTS(Select 1 From dbo.Units U Where U.Unit_Name = 'Per Kilo')
Insert Into dbo.Units(Unit_Name)
Values ('Per Kilo')

IF NOT EXISTS(Select 1 From dbo.Units U Where U.Unit_Name = 'Per Unit')
Insert Into dbo.Units(Unit_Name)
Values ('Per Unit')