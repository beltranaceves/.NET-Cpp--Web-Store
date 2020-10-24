USE nombreAplicacionMaD

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Client]') 
AND type in ('U')) DROP TABLE [Client]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[CreditCard]') 
AND type in ('U')) DROP TABLE [CreditCard]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[ClientOrder]') 
AND type in ('U')) DROP TABLE [ClientOrder]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[ClientOrderLine]') 
AND type in ('U')) DROP TABLE [ClientOrderLine]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Category]') 
AND type in ('U')) DROP TABLE [Category]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Product]') 
AND type in ('U')) DROP TABLE [Product]
GO


CREATE TABLE Client (
    clientId BIGINT IDENTITY(1,1) NOT NULL,
    clientLogin VARCHAR(60) COLLATE latin1_bin NOT NULL,
    clientPassword VARCHAR(60) NOT NULL, 
    clientName VARCHAR(60) NOT NULL,
	firstName VARCHAR(60) NOT NULL,
    lastName VARCHAR(60) NOT NULL, 
	clientAddress VARCHAR(60) NOT NULL, 
    email VARCHAR(60) NOT NULL,
	clientLanguage VARCHAR(60) NOT NULL,
	rol varchar(60) NOT NULL,
	CONSTRAINT [PK_Client] PRIMARY KEY (clientId),
	CONSTRAINT [Unique_ClientLogin] UNIQUE (clientLogin)
)

CREATE NONCLUSTERED INDEX [IX_ClientIndexByClientLogin] ON Client (clientId ASC, loginId ASC);

PRINT N'Table Client created.'
GO

CREATE TABLE CreditCard (
	cardId BIGINT IDENTITY(1, 1) NOT NULL,
	cardNumber VARCHAR(16) NOT NULL ,
	cardType VARCHAR(20) NOT NULL,
	verificationCode BIGINT NOT NULL,
	expeditionDate DATETIME NOT NULL,
	defaultCard BIT NOT NULL,
	clientId BIGINT NOT NULL,
	CONSTRAINT [PK_CreditCard] PRIMARY KEY (cardId),
	CONSTRAINT [FK_CreditCard_Client] FOREIGN KEY (clientId) REFERENCES Client (clientId) ON DELETE CASCADE,
	CONSTRAINT [UK_CardNumber] UNIQUE (number)
) 

CREATE NONCLUSTERED INDEX [IX_CreditCardIndexByClientId] ON CreditCard (cardId ASC, clientId ASC);


PRINT N'Table CreditCard created.'
GO

CREATE TABLE ClientOrder (
	orderId BIGINT IDENTITY(1,1) NOT NULL, 
	orderDate DATETIME NOT NULL,
	orderName VARCHAR(60) NOT NULL,
	creditCardId BIGINT,
	clientOrderAddress VARCHAR(60) NOT NULL,
	clientId BIGINT,

	CONSTRAINT [PK_ClientOrder] PRIMARY KEY (orderId),
	CONSTRAINT [FK_ClientOrder_Client] FOREIGN KEY (clientId) REFERENCES Client (clientId),
	CONSTRAINT [FK_ClientOrder_CreditCard] FOREIGN KEY (creditCardId) REFERENCES CreditCard (cardId)
)

CREATE NONCLUSTERED INDEX [IX_ClientOrderIndexByClientId] ON ClientOrder (orderId ASC, clientId ASC);


PRINT N'Table ClientOrder created.'
GO

CREATE TABLE Category (
	categoryId BIGINT IDENTITY(1, 1),
	categoryName VARCHAR(20) NOT NULL,

	CONSTRAINT [PK_Category] PRIMARY KEY (categoryId),
	CONSTRAINT [UK_CategoryName] UNIQUE (categoryName)
)

PRINT N'Table Categort created.'
GO


CREATE TABLE Product (
	productId BIGINT IDENTITY(1, 1),
	productName VARCHAR(60) NOT NULL,
	price float NOT NULL,
	registerDate DATETIME NOT NULL,
	stock Int NOT NULL,
	categoryId BIGINT NOT NULL, 

	CONSTRAINT [PK_Product] PRIMARY KEY (productId),
	CONSTRAINT [FK_Product_Category] FOREIGN KEY (categoryId) REFERENCES Category (categoryid)
)

CREATE NONCLUSTERED INDEX [IX_ProductIndexByCategoryId] ON Product(productId ASC, categoryId ASC);


PRINT N'Table Product created.'
GO

CREATE TABLE ClientOrderLine (
	orderLineId BIGINT IDENTITY(1, 1) NOT NULL,
	orderId BIGINT NOT NULL,
	productId BIGINT NOT NULL,
	quantity INT NOT NULL,
	price FLOAT NOT NULL,

	CONSTRAINT [PK_ClientOrderLine] PRIMARY KEY (orderLineId),
	CONSTRAINT [FK_ClientOrderLine_ClientOrder] FOREIGN KEY (orderId) REFERENCES ClientOrder (orderId),
	CONSTRAINT [FK_ClientOrderLine_Product] FOREIGN KEY (productId) REFERENCES Product (productId)
) 

CREATE NONCLUSTERED INDEX [IX_ClientOrderLineIndexByClientOrderId] ON ClientOrderLine (orderLineId ASC, orderId ASC);


PRINT N'Table ClientOrderLine created.'
GO



