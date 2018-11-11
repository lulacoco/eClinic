CREATE DATABASE Clinic
GO

USE Clinic
GO

CREATE TABLE Diseases (
	DiseaseID int IDENTITY(1,1) PRIMARY KEY,
	DiseaseType varchar(100),
	DiseaseName varchar(100),
	Orders varchar(200)
);

CREATE TABLE Doctor (
	DoctorPesel int PRIMARY KEY,
	FirstName varchar(50) NOT NULL,
	LastName varchar(50) NOT NULL,
	Age int
);

CREATE TABLE DoctorLogin (
	LoginID int IDENTITY(1,1) PRIMARY KEY,
	Username varchar(100) NOT NULL,
	Pass char(64) NOT NULL,
	Email varchar(320) NOT NULL,
	DoctorPesel int FOREIGN KEY REFERENCES Doctor(DoctorPesel)
);

CREATE TABLE Patient (
	PatientPesel int PRIMARY KEY,
	FirstName varchar(50) NOT NULL,
	LastName varchar(50) NOT NULL,
	Age int
);

CREATE TABLE PatientLogin (
	LoginID int IDENTITY(1,1) PRIMARY KEY,
	Username varchar(100) NOT NULL,
	Pass char(64) NOT NULL,
	Email varchar(320) NOT NULL,
	PatientPesel int FOREIGN KEY REFERENCES Patient(PatientPesel)
);	 

CREATE TABLE Appointment (
	AppointmentID int IDENTITY(1,1) PRIMARY KEY,
	DoctorPesel int FOREIGN KEY REFERENCES Doctor(DoctorPesel),
	PatientPesel int FOREIGN KEY REFERENCES Patient(PatientPesel),
	DiseaseID int FOREIGN KEY REFERENCES Diseases(DiseaseID),
	AppointmentDate DATETIME NOT NULL
);