INSERT INTO Client (clientLogin,clientPassword,clientName,firstName,lastName,clientAddress,email, clientLanguage, rol) VALUES ('DigoStorm','1234','Diego','Villanueva','Farina','Mi Casa','d@udc.es','Español', 'Cliente');
INSERT INTO Client (clientLogin,clientPassword,clientName,firstName,lastName,clientAddress,email, clientLanguage, rol) VALUES ('Jacojh21','1234','Jacobo','Jorge','Hermida','Su Casa','j@udc.es','Español', 'Admin');

INSERT INTO CreditCard (cardNumber,cardType,verificationCode,expeditionDate, defaultCard, clientId)
	VALUES ('1111222233334444','debit',888,'05-21',1,1);

INSERT INTO ClientOrder (orderDate,orderName,creditCardId,clientOrderAddress, clientId) 
	VALUES (GETDATE(),'Regalo Hervella',1,'Mi Casa 5ºE, 15011', 1);

INSERT INTO Category (categoryName) VALUES ('Sillas');

INSERT INTO Product (productName,price,registerDate,stock,categoryId) VALUES ( 'Silla Gamming',999,GETDATE(),9,1);

INSERT INTO ClientOrderLine (orderId, productId, quantity, price) VALUES (1,1, 2, 899);

INSERT INTO Tag (tagName) VALUES ('Buen producto');

INSERT INTO ProductComment (productId ,commentText, commentDate, clientId ,tagId) VALUES (1,'Muy buena silla, muy comoda para pasar horas jugando',GETDATE(),1,1);