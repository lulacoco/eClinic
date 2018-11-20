USE Clinic
GO

CREATE TRIGGER CompletedVisit
ON Appointment FOR UPDATE
AS
BEGIN
    UPDATE T
    SET AppointmentCompleted = 1
    FROM
        INSERTED I
    INNER JOIN Appointment T ON
        T.DiseaseID = I.DiseaseID
END
GO


CREATE TRIGGER UpdatePatientAge
ON Patient FOR INSERT
AS
BEGIN
    UPDATE T
    SET Age = (SELECT DATEDIFF(year, (SELECT CONCAT('1-1-', (SELECT CAST(LEFT(PatientPesel, 2) AS INT) FROM Patient P WHERE T.PatientPesel = P.PatientPesel))), (SELECT CONCAT('1-1-', (SELECT CAST(RIGHT(YEAR (GETDATE()), 2) AS INT))))))
    FROM
        INSERTED I
    INNER JOIN Patient T ON
        T.PatientPesel = I.PatientPesel
END


CREATE TRIGGER UpdateDoctorAge
ON Doctor FOR INSERT
AS
BEGIN
    UPDATE T
    SET Age = (SELECT DATEDIFF(year, (SELECT CONCAT('1-1-', (SELECT CAST(LEFT(DoctorPesel, 2) AS INT) FROM Doctor D WHERE T.DoctorPesel = D.DoctorPesel))), (SELECT CONCAT('1-1-', (SELECT CAST(RIGHT(YEAR (GETDATE()), 2) AS INT))))))
    FROM
        INSERTED I
    INNER JOIN Doctor T ON
        T.DoctorPesel = I.DoctorPesel
END