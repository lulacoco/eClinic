USE Clinic
GO

CREATE PROCEDURE GetDoctorAppointments
@DoctorPesel bigint
AS
SELECT PatientPesel, AppointmentDate
FROM Appointment
WHERE DoctorPesel = @DoctorPesel AND AppointmentCompleted=0