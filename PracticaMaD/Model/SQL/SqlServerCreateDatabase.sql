INSERT INTO Client (clientLogin,clientPassword,firstName,firstSurname,lastSurname,clientAddress,email, clientLanguage, rol) VALUES ('DigoStorm','1234','Diego','Villanueva','Farina','Mi Casa','d@udc.es','Espa�ol', 'Cliente');
INSERT INTO Client (clientLogin,clientPassword,firstName,firstSurname,lastSurname,clientAddress,email, clientLanguage, rol) VALUES ('Jacojh21','1234','Jacobo','Jorge','Hermida','Su Casa','j@udc.es','Espa�ol', 'Admin');

INSERT INTO CreditCard (cardNumber,cardType,verificationCode,expeditionDate, defaultCard, clientId)
	VALUES ('1111222233334444','debit',888,'05-21',1,1);

INSERT INTO ClientOrder (orderDate,orderName,creditCardId,clientOrderAddress, clientId) 
	VALUES (GETDATE(),'Regalo Hervella',1,'Mi Casa 5�E, 15011', 1);

INSERT INTO Category (categoryName) VALUES ('Sillas');
INSERT INTO Category (categoryName) VALUES ('Cds');
INSERT INTO Category (categoryName) VALUES ('DvDs');
INSERT INTO Category (categoryName) VALUES ('Libros');


INSERT INTO Product (productName,price,registerDate,stock,categoryId) VALUES ('Silla Gamming',999,GETDATE(),9,10);
INSERT INTO Product (productName,price,registerDate,stock,categoryId) VALUES ( 'Artic Moneys CD',15,GETDATE(),9,11);
INSERT INTO Product (productName,price,registerDate,stock,categoryId) VALUES ( 'Titanic',10,GETDATE(),9,12);
INSERT INTO Product (productName,price,registerDate,stock,categoryId) VALUES ( 'Las aventuras de Pepe',10,GETDATE(),9,13);

INSERT INTO Music (artist,title,genere,type,productId) VALUES('Arctic Monkeys','AM','Rock','CD',12);
INSERT INTO Films (title,director,filmYear,duration,productId) VALUES('Titanic','James Cameron',1997,210,13);
INSERT INTO Books (bookName,author,pages,ISBN,productId) VALUES('Las aventuras de Pepe','Yo mismo',300,262655,14);



INSERT INTO ClientOrderLine (orderId, productId, quantity, price) VALUES (1,1, 2, 899);

INSERT INTO Tag (tagName) VALUES ('Buen producto');

INSERT INTO ProductComment (productId ,commentText, commentDate, clientId) VALUES (1,'Muy buena silla, muy comoda para pasar horas jugando',GETDATE(),1);

INSERT INTO ProductCommentTag(commentId, tagId) VALUES (1, 1);