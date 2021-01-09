INSERT INTO Client (clientLogin,clientPassword,firstName,firstSurname,lastSurname,clientAddress,email, clientLanguage,country, rol) VALUES ('DigoStorm','ypeBEsobvcr6wjGzmiPcTaeG7/gUfE5yuYB3ha/uSLs=','Diego','Villanueva','Farina','Mi Casa','d@udc.es','es','ES', 'ADMIN');
INSERT INTO Client (clientLogin,clientPassword,firstName,firstSurname,lastSurname,clientAddress,email, clientLanguage,country, rol) VALUES ('JacoJh21','ypeBEsobvcr6wjGzmiPcTaeG7/gUfE5yuYB3ha/uSLs=','Jacobo','Jorge','Hermida','Mi Casa','j@udc.es','es','ES', 'ADMIN');

INSERT INTO Category (categoryName) VALUES ('Sillas');
INSERT INTO Category (categoryName) VALUES ('Musica');
INSERT INTO Category (categoryName) VALUES ('Peliculas');
INSERT INTO Category (categoryName) VALUES ('Libros');


INSERT INTO Product (productName,price,registerDate,stock,categoryId) VALUES ('Silla Gamming',999,GETDATE(),9,1);
INSERT INTO Product (productName,price,registerDate,stock,categoryId) VALUES ( 'Artic Moneys CD',15,GETDATE(),9,2);
INSERT INTO Product (productName,price,registerDate,stock,categoryId) VALUES ( 'Titanic',10,GETDATE(),9,3);
INSERT INTO Product (productName,price,registerDate,stock,categoryId) VALUES ( 'Las aventuras de Pepe',10,GETDATE(),9,4);

INSERT INTO Music (productId,artist,genere,type) VALUES(2,'Arctic Monkeys','Rock','CD');
INSERT INTO Films (productId,director,filmYear,duration,genere) VALUES(3,'James Cameron',1997,210,'Drama');
INSERT INTO Books (productId,author,pages,ISBN,editorial) VALUES(4,'Yo mismo',300,262655,'Anaya');

