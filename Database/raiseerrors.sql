USE Clinic
GO

CREATE TRIGGER AgeRestriction
ON PatientLogin
FOR INSERT, UPDATE AS
BEGIN 

IF(SELECT DATEDIFF(year, 
	(SELECT CONCAT('1-1-', 
	(SELECT CAST(LEFT(p.PatientPesel, 2) AS INT) FROM PatientLogin p JOIN inserted AS i ON p.PatientPesel = i.PatientPesel))), 
	(SELECT CONCAT('1-1-', 
	(SELECT CAST(RIGHT(YEAR (GETDATE()), 2) AS INT)))))) 
	< 18
BEGIN
RAISERROR('Nie mo¿na siê zarejestrowaæ, gdy nie ma siê skoñczonych 18 lat', 16,1)
ROLLBACK
RETURN
END
END

/********  DZIA£A  ********/


USE Clinic
GO

CREATE TRIGGER EmailValidation
ON PatientLogin
FOR INSERT, UPDATE AS
IF(SELECT TOP 1 i.Email FROM inserted i) not like '[a-z,0-9,_,-]%@[a-z,0-9,_,-]%.[a-z][a-z]%'
BEGIN
RAISERROR('To nie jest w³aœciwy adres e-mail', 16,1)
ROLLBACK
RETURN 
END
GO


/********  INSERT  ********/

USE Clinic
GO

INSERT INTO Patient(PatientPesel, FirstName, LastName)
VALUES('03928392843', 'andrzeju', 'niedenerwujsie')

GO

INSERT INTO PatientLogin(Username, Pass, Email, PatientPesel)
VALUES('ziomekstefana', 'jegotajnehaslo123', 'jegozajebistyemail@gmai.com', '03928392843')