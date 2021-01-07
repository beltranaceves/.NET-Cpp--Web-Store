IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[ProductCommentTag]') 
AND type in ('U')) DROP TABLE [ProductCommentTag]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[ProductComment]') 
AND type in ('U')) DROP TABLE [ProductComment]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[ClientOrderLine]') 
AND type in ('U')) DROP TABLE [ClientOrderLine]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[ClientOrder]') 
AND type in ('U')) DROP TABLE [ClientOrder]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Books]') 
AND type in ('U')) DROP TABLE [Books]
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Films]') 
AND type in ('U')) DROP TABLE [Films]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Music]') 
AND type in ('U')) DROP TABLE [Music]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Product]') 
AND type in ('U')) DROP TABLE [Product]
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[CreditCard]') 
AND type in ('U')) DROP TABLE [CreditCard]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Client]') 
AND type in ('U')) DROP TABLE [Client]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Category]') 
AND type in ('U')) DROP TABLE [Category]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[Tag]') 
AND type in ('U')) DROP TABLE [Tag]
GO





CREATE TABLE Category (
	categoryId BIGINT IDENTITY(1, 1),
	categoryName VARCHAR(20) NOT NULL,

	CONSTRAINT [PK_Category] PRIMARY KEY (categoryId),
	CONSTRAINT [UK_CategoryName] UNIQUE (categoryName)
)

PRINT N'Table Category created.'
GO




CREATE TABLE Client (
    clientId BIGINT IDENTITY(1,1) NOT NULL,
    clientLogin VARCHAR(60)  NOT NULL,
    clientPassword VARCHAR(60) NOT NULL, 
    firstName VARCHAR(60) NOT NULL,
	firstSurname VARCHAR(60) NOT NULL,
    lastSurname VARCHAR(60) NOT NULL, 
	clientAddress VARCHAR(60) NOT NULL, 
    email VARCHAR(60) NOT NULL,
	clientLanguage VARCHAR(2) NOT NULL,
	country VARCHAR(2) NOT NULL,
	rol VARCHAR(60) NOT NULL,
	CONSTRAINT [PK_Client] PRIMARY KEY (clientId),
	CONSTRAINT [Unique_ClientLogin] UNIQUE (clientLogin),
	CONSTRAINT [Unique_ClientEmail] UNIQUE (email)
)

CREATE NONCLUSTERED INDEX [IX_ClientIndexByClientLogin] ON Client (clientId ASC, clientLogin ASC);

PRINT N'Table Client created.'
GO

CREATE TABLE CreditCard (
	cardId BIGINT IDENTITY(1, 1) NOT NULL,
	cardNumber VARCHAR(16) NOT NULL ,
	cardType VARCHAR(20) NOT NULL,
	verificationCode BIGINT NOT NULL,
	expeditionDate VARCHAR(5) NOT NULL,
	defaultCard BIT NOT NULL,
	clientId BIGINT NOT NULL,
	CONSTRAINT [PK_CreditCard] PRIMARY KEY (cardId),
	CONSTRAINT [FK_CreditCard_Client] FOREIGN KEY (clientId) REFERENCES Client (clientId) ON DELETE CASCADE,
	CONSTRAINT [UK_CardNumber] UNIQUE (cardNumber)
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
	totalPrize FLOAT NOT NULL,
	clientId BIGINT,
	

	CONSTRAINT [PK_ClientOrder] PRIMARY KEY (orderId),
	CONSTRAINT [FK_ClientOrder_Client] FOREIGN KEY (clientId) REFERENCES Client (clientId),
	CONSTRAINT [FK_ClientOrder_CreditCard] FOREIGN KEY (creditCardId) REFERENCES CreditCard (cardId)
)

CREATE NONCLUSTERED INDEX [IX_ClientOrderIndexByClientId] ON ClientOrder (orderId ASC, clientId ASC);


PRINT N'Table ClientOrder created.'
GO



CREATE TABLE Product (
	productId BIGINT IDENTITY(1, 1) NOT NULL,
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
	totalPrice FLOAT NOT NULL,
	price FLOAT NOT NULL,
	forGift BIT NOT NULL,
	pName VARCHAR(60) NOT NULL,

	CONSTRAINT [PK_ClientOrderLine] PRIMARY KEY (orderLineId),
	CONSTRAINT [FK_ClientOrderLine_ClientOrder] FOREIGN KEY (orderId) REFERENCES ClientOrder (orderId),
	CONSTRAINT [FK_ClientOrderLine_Product] FOREIGN KEY (productId) REFERENCES Product (productId)
) 

CREATE NONCLUSTERED INDEX [IX_ClientOrderLineIndexByClientOrderId] ON ClientOrderLine (orderLineId ASC, orderId ASC);


PRINT N'Table ClientOrderLine created.'
GO


CREATE TABLE Tag (
	tagId BIGINT IDENTITY(1, 1) NOT NULL,
	tagName VARCHAR(20) NOT NULL,

	CONSTRAINT [PK_Tag] PRIMARY KEY (tagId),
	CONSTRAINT [UK_TagName] UNIQUE (tagName)
)

PRINT N'Table Tag created.'
GO


CREATE TABLE ProductComment (
	commentId BIGINT IDENTITY(1, 1) NOT NULL,
	productId BIGINT NOT NULL,
	commentText VARCHAR(260) NOT NULL,
	commentDate DATETIME NOT NULL,
	clientId BIGINT NOT NULL,

	CONSTRAINT [PK_Comment] PRIMARY KEY (commentId),
	CONSTRAINT [FK_Comment_ClientId] FOREIGN KEY (clientId) REFERENCES Client (clientId),
	CONSTRAINT [FK_Comment_Product] FOREIGN KEY (productId) REFERENCES Product (productId)
) 

CREATE NONCLUSTERED INDEX [IX_CommentIndexByProductId] ON ProductComment (commentId ASC, productId ASC );

PRINT N'Table Comment created.'
GO

CREATE TABLE ProductCommentTag (
	commentId BIGINT NOT NULL,
	tagId BIGINT NOT NULL,

	CONSTRAINT [PK_ProductCommentTag] PRIMARY KEY (commentId, tagId),
	CONSTRAINT [FK_ProductCommentTag_ProductComment] FOREIGN KEY (commentId) REFERENCES ProductComment (commentId),
	CONSTRAINT [FK_ProductCommentTag_Tag] FOREIGN KEY (tagId) REFERENCES Tag (tagId)
)

PRINT N'Table ProductCommentTag created.'
GO

CREATE TABLE Books (
	productId BIGINT NOT NULL,
	author VARCHAR(60) NOT NULL,
	pages INT NOT NULL,
	ISBN BIGINT NOT NULL,
	editorial VARCHAR(60) NOT NULL,

	CONSTRAINT [PK_Books] PRIMARY KEY (productId),
	CONSTRAINT [FK_Books] FOREIGN KEY (productId) REFERENCES Product (productId)
)
PRINT N'Table Books created.'


CREATE TABLE Films (
	productId BIGINT NOT NULL,
	director VARCHAR(60) NOT NULL,
	filmYear INT NOT NULL,
	duration INT NOT NULL,
	genere VARCHAR(60) NOT NULL,

	CONSTRAINT [PK_Films] PRIMARY KEY (productId),
	CONSTRAINT [FK_Films] FOREIGN KEY (productId) REFERENCES Product (productId)
)
PRINT N'Table Films created.'

CREATE TABLE Music (
	productId BIGINT NOT NULL,
	artist VARCHAR(60) NOT NULL,
    genere VARCHAR(60) NOT NULL,
	type VARCHAR(60) NOT NULL,

	CONSTRAINT [PK_Music] PRIMARY KEY (productId),
	CONSTRAINT [FK_Music] FOREIGN KEY (productId) REFERENCES Product (productId)
)
PRINT N'Table Music created.'