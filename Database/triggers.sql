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