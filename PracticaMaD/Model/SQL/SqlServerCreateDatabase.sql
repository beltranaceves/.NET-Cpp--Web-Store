INSERT INTO Client (clientLogin,clientPassword,firstName,firstSurname,lastSurname,clientAddress,email, clientLanguage,country, rol) VALUES ('d','ypeBEsobvcr6wjGzmiPcTaeG7/gUfE5yuYB3ha/uSLs=','Diego','Villanueva','Farina','Mi Casa','d@udc.es','es','ES', 'ADMIN');
INSERT INTO Client (clientLogin,clientPassword,firstName,firstSurname,lastSurname,clientAddress,email, clientLanguage, rol) VALUES ('Jacojh21','1234','Jacobo','Jorge','Hermida','Su Casa','j@udc.es','Espa�ol', 'Admin');

INSERT INTO CreditCard (cardNumber,cardType,verificationCode,expeditionDate, defaultCard, clientId)
	VALUES ('1111222233334444','debit',888,'05-21',1,1);

INSERT INTO ClientOrder (orderDate,orderName,creditCardId,clientOrderAddress, clientId) 
	VALUES (GETDATE(),'Regalo Hervella',1,'Mi Casa 5�E, 15011', 1);

INSERT INTO Category (categoryName) VALUES ('Sillas');
INSERT INTO Category (categoryName) VALUES ('Cds');
INSERT INTO Category (categoryName) VALUES ('DvDs');
INSERT INTO Category (categoryName) VALUES ('Libros');


INSERT INTO Product (productName,price,registerDate,stock,categoryId) VALUES ('Silla Gamming',999,GETDATE(),9,1);
INSERT INTO Product (productName,price,registerDate,stock,categoryId) VALUES ( 'Artic Moneys CD',15,GETDATE(),9,2);
INSERT INTO Product (productName,price,registerDate,stock,categoryId) VALUES ( 'Titanic',10,GETDATE(),9,3);
INSERT INTO Product (productName,price,registerDate,stock,categoryId) VALUES ( 'Las aventuras de Pepe',10,GETDATE(),9,4);

INSERT INTO Music (productId,artist,genere,type) VALUES(2,'Arctic Monkeys','Rock','CD');
INSERT INTO Films (productId,director,filmYear,duration,genere) VALUES(3,'James Cameron',1997,210,'Drama');
INSERT INTO Books (productId,author,pages,ISBN,editorial) VALUES(4,'Yo mismo',300,262655,'Anaya');



INSERT INTO ClientOrderLine (orderId, productId, quantity, price) VALUES (1,1, 2, 899);

INSERT INTO Tag (tagName) VALUES ('Buen producto');

INSERT INTO ProductComment (productId ,commentText, commentDate, clientId) VALUES (1,'Muy buena silla, muy comoda para pasar horas jugando',GETDATE(),1);

INSERT INTO ProductCommentTag(commentId, tagId) VALUES (1, 1);