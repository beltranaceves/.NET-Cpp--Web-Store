-- Indexes for primary keys have been explicitly created.




DROP TABLE Product;
DROP TABLE Category;
DROP TABLE CreditCard;
DROP TABLE User;
DROP TABLE Order;
DROP TABLE OrderLines;


CREATE TABLE User (
    id BIGINT NOT NULL AUTO_INCREMENT,
    login VARCHAR(60) COLLATE latin1_bin NOT NULL,
    password VARCHAR(60) NOT NULL, 
    name VARCHAR(60) NOT NULL,
	firstName VARCHAR(60) NOT NULL,
    lastName VARCHAR(60) NOT NULL, 
	address VARCHAR(60) NOT NULL, 
    email VARCHAR(60) NOT NULL,
	language VARCHAR(60) NOT NULL,
    CONSTRAINT UserPK PRIMARY KEY (id),
    CONSTRAINT UserNameUniqueKey UNIQUE (login)
) ENGINE = InnoDB;

CREATE TABLE CreditCard (
	number VARCHAR(20) NOT NULL,
	type VARCHAR(20) NOT NULL,
	verificationCode BIGINT NOT NULL,
	expeditionDate DATETIME NOT NULL,
    CONSTRAINT CreditCardPK PRIMARY KEY (number);
    
) ENGINE = InnoDB;


CREATE TABLE Order (
CONSTRAINT CreditCardNumberFK FOREIGN KEY (creditCardNumber)
		REFERENCES CreditCard (number),
CONSTRAINT AdresssFK FOREIGN KEY (clientAdress)
		REFERENCES User (address),	

orderDate DATETIME NOT NULL,
id BIGINT NOT NULL AUTO_INCREMENT,
CONSTRAINT OrderPK PRIMARY KEY (id);    
) ENGINE = InnoDB;


CREATE TABLE Product (
	id BIGINT NOT NULL AUTO_INCREMENT,
	name VARCHAR(20) NOT NULL,
	price float NOT NULL,
	registerDate DATETIME NOT NULL,
	stock smallint NOT NULL,
	CONSTRAINT CategoryFK FOREIGN KEY (productCategory)
		REFERENCES Category (name),
    CONSTRAINT ProductPK PRIMARY KEY (id);
    
) ENGINE = InnoDB;


CREATE TABLE Category (
	name VARCHAR(20) NOT NULL,
    CONSTRAINT CategoryPK PRIMARY KEY (name);
    
) ENGINE = InnoDB;

INSERT INTO User (login,password,name,firstName,lastName,address,email, languaje) VALUES ('DigoStorm','1234','Diego','Villanueva','Farina','Mi Casa','d@udc.es','Español');
INSERT INTO User (login,password,name,firstName,lastName,address,email, languaje) VALUES ('Jacojh21','1234','Jacobo','Jorge','Hermida','Su Casa','j@udc.es','Español');

INSERT INTO CreditCard (number,type,name,verificationCode,expeditionDate) VALUES ('123456789','VISA',888,(DATE_ADD(DATE(NOW()), INTERVAL '0 20:55' DAY_MINUTE)));

INSERT INTO Order (creditCardNumber,clientAdress,orderDate) VALUES ('123456789','Mi Casa',(DATE_ADD(DATE(NOW()), INTERVAL '0 20:55' DAY_MINUTE)));

INSERT INTO Category (name) VALUES ('Sillas');


INSERT INTO Product (name,price,registerDate,stock,productCategory) VALUES ('Silla Gamming',999,(DATE_ADD(DATE(NOW()), INTERVAL '0 20:55' DAY_MINUTE)),9,'Sillas');


