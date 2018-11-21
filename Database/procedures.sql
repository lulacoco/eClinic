USE Clinic
GO

CREATE PROCEDURE GetDoctorAppointments
@DoctorPesel bigint
AS
SELECT PatientPesel, AppointmentDate
FROM Appointment
WHERE DoctorPesel = @DoctorPesel AND AppointmentCompleted=0

GO

CREATE PROCEDURE GetPatientAppointments
@PatientPesel bigint
AS
SELECT DoctorPesel, AppointmentDate
FROM Appointment
WHERE PatientPesel = @PatientPesel AND AppointmentCompleted=0