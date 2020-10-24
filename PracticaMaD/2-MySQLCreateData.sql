INSERT INTO User (login,password,name,firstName,lastName,address,email, languaje) VALUES ('DigoStorm','1234','Diego','Villanueva','Farina','Mi Casa','d@udc.es','Español');
INSERT INTO User (login,password,name,firstName,lastName,address,email, languaje) VALUES ('Jacojh21','1234','Jacobo','Jorge','Hermida','Su Casa','j@udc.es','Español');

INSERT INTO CreditCard (number,type,name,verificationCode,expeditionDate) VALUES ('123456789','VISA',888,(DATE_ADD(DATE(NOW()), INTERVAL '0 20:55' DAY_MINUTE)));

INSERT INTO Order (creditCardNumber,clientAdress,orderDate) VALUES ('123456789','Mi Casa',(DATE_ADD(DATE(NOW()), INTERVAL '0 20:55' DAY_MINUTE)));

INSERT INTO Category (name) VALUES ('Sillas');


INSERT INTO Product (name,price,registerDate,stock,productCategory) VALUES ('Silla Gamming',999,(DATE_ADD(DATE(NOW()), INTERVAL '0 20:55' DAY_MINUTE)),9,'Sillas');

