-- Indexes for primary keys have been explicitly created.




DROP TABLE Product;
DROP TABLE Category;
DROP TABLE CreditCard;
DROP TABLE Client;
DROP TABLE ClientOrder;


CREATE TABLE Client (
    clientId AUTOINCREMENT,
    clientLogin VARCHAR(60) COLLATE latin1_bin NOT NULL,
    clientPassword VARCHAR(60) NOT NULL, 
    clientName VARCHAR(60) NOT NULL,
	clientFirstName VARCHAR(60) NOT NULL,
    clientLastName VARCHAR(60) NOT NULL, 
	clientAddress VARCHAR(60) NOT NULL, 
    email VARCHAR(60) NOT NULL,
	clientLanguage VARCHAR(60) NOT NULL,
);




CREATE TABLE CreditCard (
	cardId AUTOINCREMENT,
	number VARCHAR(20) NOT NULL ,
	cardType VARCHAR(20) NOT NULL,
	verificationCode BIGINT NOT NULL,
	expeditionDate DATETIME NOT NULL,

) 

CREATE TABLE ClientOrder (
	orderDate DATETIME NOT NULL,
	orderId AUTOINCREMENT, 
)


CREATE TABLE Product (
	productId AUTOINCREMENT,
	productName VARCHAR(20) NOT NULL,
	price float NOT NULL,
	registerDate DATETIME NOT NULL,
	stock Int NOT NULL,
)


CREATE TABLE Category (
	categoryId AUTOINCREMENT,
	categoryName VARCHAR(20) NOT NULL,
)


ALTER TABLE Client ADD CONSTRAINT ClientIdPK PRIMARY KEY (clientId);
ALTER TABLE Client ADD CONSTRAINT ClientLoginUK UNIQUE (clientLogin);


ALTER TABLE CreditCard ADD CONSTRAINT CreditCardPK PRIMARY KEY (cardId);
ALTER TABLE CreditCard ADD CONSTRAINT CardNumberUK UNIQUE (number);


ALTER TABLE ClientOrder ADD CONSTRAINT ClientOrderPK PRIMARY KEY (orderId);

ALTER TABLE Product ADD CONSTRAINT ProductIdPK PRIMARY KEY (productId);
ALTER TABLE Product ADD CONSTRAINT CardNumberUK UNIQUE (number);

ALTER TABLE Category ADD CONSTRAINT CategoryIdPK PRIMARY KEY (categoryId);
ALTER TABLE Category ADD CONSTRAINT CardNumberUK UNIQUE (number);