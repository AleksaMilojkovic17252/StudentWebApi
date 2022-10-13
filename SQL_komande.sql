CREATE TABLE STUDENT
(
studentId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
ime varchar(255) NOT NULL,
prezime varchar(255) NOT NULL,
grad varchar(255) NOT NULL,
drzava varchar(255) NOT NULL,
datumRodjenja DATE NOT NULL,
pol varchar(2)
);

CREATE TABLE KURS(
kod varchar(20) NOT NULL PRIMARY KEY,
ime varchar(255) NOT NULL,
opis varchar(1000) NOT NULL
);

CREATE TABLE OCENA(
id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
ocena int NOT NULL,
studentId int NOT NULL,
kursKod varchar(20) NOT NULL,
FOREIGN KEY (studentId) REFERENCES STUDENT(studentId)
ON DELETE CASCADE
ON UPDATE CASCADE,
FOREIGN KEY (kursKod) REFERENCES KURS(kod)
ON DELETE CASCADE
ON UPDATE CASCADE
);

Create unique index StudentIndex on model.dbo.OCENA(studentId,kursKod);

INSERT INTO STUDENT(ime,prezime,grad,drzava,datumRodjenja,pol)
VALUES('Aleksa', 'Milojkovic', 'Nis', 'Srbija','1999-04-05','M');
INSERT INTO STUDENT(ime,prezime,grad,drzava,datumRodjenja,pol)
VALUES('Danilo', 'Potpara', 'Nis', 'Srbija','1999-11-11','M');
INSERT INTO STUDENT(ime,prezime,grad,drzava,datumRodjenja,pol)
VALUES('Matija', 'Nikolic', 'Trnava', 'Srbija','1999-04-11','M');
INSERT INTO STUDENT(ime,prezime,grad,drzava,datumRodjenja,pol)
VALUES('Natalija', 'Peric', 'Aleksinac', 'Srbija','2000-01-03','F');

INSERT INTO KURS(kod,ime,opis)
VALUES('2OEZ1O04','Uvod u racunarstvo','Predmet prve godine, prvog semestra');
INSERT INTO KURS(kod,ime,opis)
VALUES('2OEZ2O03','Algoritmi i programiranje','Predmet prve godine, drugog semestra');
INSERT INTO KURS(kod,ime,opis)
VALUES('2OER3O01','Racunarski sistemi','Predmet druge godine, prvog semestra');
INSERT INTO KURS(kod,ime,opis)
VALUES('2OER3O03','Objektno orijentisano programiranje','Predmet druge godine, prvog semestra');
INSERT INTO KURS(kod,ime,opis)
VALUES('2OER4O04','Baze podataka','Predmet druge godine, drugog semestra');
INSERT INTO KURS(kod,ime,opis)
VALUES('2OER4O02','Strukture podataka','Predmet druge godine, drugog semestra');

INSERT INTO ocena(ocena, studentId, kursKod) 
VALUES(10,1,'2OEZ1O04');
INSERT INTO ocena(ocena, studentId, kursKod) 
VALUES(9,1,'2OEZ2O03');
INSERT INTO ocena(ocena, studentId, kursKod) 
VALUES(10,1,'2OER4O04');


INSERT INTO ocena(ocena, studentId, kursKod) 
VALUES(10,2,'2OEZ1O04');
INSERT INTO ocena(ocena, studentId, kursKod) 
VALUES(10,2,'2OEZ2O03');
INSERT INTO ocena(ocena, studentId, kursKod) 
VALUES(10,2,'2OER3O03');

INSERT INTO ocena(ocena, studentId, kursKod) 
VALUES(8,3,'2OEZ1O04');
INSERT INTO ocena(ocena, studentId, kursKod) 
VALUES(7,3,'2OEZ2O03');
INSERT INTO ocena(ocena, studentId, kursKod) 
VALUES(8,3,'2OER3O01');
INSERT INTO ocena(ocena, studentId, kursKod) 
VALUES(8,3,'2OER4O02');

INSERT INTO ocena(ocena, studentId, kursKod) 
VALUES(10,4,'2OEZ1O04');
INSERT INTO ocena(ocena, studentId, kursKod) 
VALUES(10,4,'2OEZ2O03');
INSERT INTO ocena(ocena, studentId, kursKod) 
VALUES(7,4,'2OER3O01');
INSERT INTO ocena(ocena, studentId, kursKod) 
VALUES(9,4,'2OER3O03');

SELECT * FROM model.dbo.STUDENT s INNER JOIN model.dbo.OCENA o ON s.studentId = o.studentId INNER JOIN model.dbo.KURS k ON k.kod = o.kursKod WHERE k.ime LIKE '%Uvod%' AND (s.ime LIKE '%Aleksa%' OR s.prezime LIKE '%Aleksa%');
