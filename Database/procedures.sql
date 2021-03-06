USE Clinic
GO

CREATE PROCEDURE GetDoctorAppointments
@DoctorPesel varchar(11)
AS
SELECT PatientPesel, AppointmentDate
FROM Appointment
WHERE DoctorPesel = @DoctorPesel AND AppointmentCompleted=0

GO

CREATE PROCEDURE GetPatientAppointments
@PatientPesel varchar(11)
AS
SELECT DoctorPesel, AppointmentDate
FROM Appointment
WHERE PatientPesel = @PatientPesel AND AppointmentCompleted=0