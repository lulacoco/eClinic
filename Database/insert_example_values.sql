USE Clinic
GO

INSERT INTO Doctor (DoctorPesel, FirstName, LastName, Age)
VALUES ('82025373453', 'Andrew', 'Morrison', 36),
	('80128462129', 'Mikolaj', 'Andjejko', 38),
	('91044423712', 'Anthony', 'Mousako', 27),
	('86748291245', 'Jen', 'Cannon', 32);

INSERT INTO DoctorLogin(Username, Pass, Email, DoctorPesel)
VALUES('andrmorr', 'andrespassword', 'andrewmorrison@gmail.com', '82025373453'),
	('mikoandrjejko', 'mikpassword', 'mikolajandrjejko@gmail.com', '80128462129'),
	('anthonymousako', 'anthonypassword', 'anthonymousako@gmail.com', '91044423712'),
	('jencann', 'jenpassword', 'jencannon@gmil.com', '86748291245');

INSERT INTO Patient (PatientPesel, FirstName, LastName, Age)
VALUES('97237492312', 'Anastazia', 'Monty', 21),
	('95436623125', 'Amadeusz', 'Stylowski', 23),
	('92345632819', 'Polly', 'Anom', 26),
	('86345019202', 'Anastazia', 'Monty', 32);


INSERT INTO PatientLogin(Username, Pass, Email, PatientPesel)
VALUES('anastaziamonty', 'anamonty', 'anastaziamonty@gmail.com', '97237492312'),
	('amadeuszstyl', 'amapass', 'amadeuszstylowski@gmail.com', '95436623125'),
	('pollyanom', 'pollypass', 'pollyanom@gmail.com', '92345632819'),
	('anastaziamon', 'amonty', 'amonty@gmail.com', '86345019202');

INSERT INTO Diseases(DiseaseType, DiseaseName, Orders)
VALUES('Virus', 'Flu', 'Medicine one, medicine two, medicine three'),
	('Virus', 'Chicken pox', 'Medicine four, medicine five'),
	('Bacterial', 'Angina', 'Medicine two, medicine ten'),
	('Virus', 'Pneumonia', 'Medicine nine, antibiotic one'),
	('Heart diseases', 'Erratic heart rhythms', 'Medicine eight, medicine eleven');

INSERT INTO Appointment(DoctorPesel, PatientPesel, DiseaseID, AppointmentDate)
VALUES('82025373453', '92345632819', 1, '2018-11-20 10:00:00 AM'),
	('80128462129', '86345019202', 2, '2018-11-22 12:20:00 AM'),
	('82025373453', '97237492312', 3,  '2018-11-28 12:50:00 AM');