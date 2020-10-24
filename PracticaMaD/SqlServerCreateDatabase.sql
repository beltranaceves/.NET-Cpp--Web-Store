INSERT INTO Client (clientId, clientLogin,clientPassword,clientName,firstName,lastName,clientAddress,email, clientLanguage, rol) VALUES (0, 'DigoStorm','1234','Diego','Villanueva','Farina','Mi Casa','d@udc.es','Español', 'Cliente');
INSERT INTO Client (clientId, clientLogin,clientPassword,clientName,firstName,lastName,clientAddress,email, clientLanguage, rol) VALUES (1, 'Jacojh21','1234','Jacobo','Jorge','Hermida','Su Casa','j@udc.es','Español', 'Admin');

INSERT INTO CreditCard (cardId,cardNumber,cardType,verificationCode,expeditionDate, defaultCard, clientId) VALUES (0,'1111222233334444','debit',888,GETDATE(),1,0);

INSERT INTO ClientOrder (orderId,orderDate,orderName,creditCardId,clientOrderAddress, clientId) VALUES (0, GETDATE(),'Regalo Hervella',0,'Mi Casa 5ºE, 15011', 0);

INSERT INTO Category (categoryId,categoryName) VALUES (0, 'Sillas');

INSERT INTO Product (productId, productName,price,registerDate,stock,categoryId) VALUES (0, 'Silla Gamming',999,GETDATE(),9,0);

INSERT INTO ClientOrderLine (orderLineId, orderId, productId, quantity, price) VALUES (0, 0, 0, 2, 899);