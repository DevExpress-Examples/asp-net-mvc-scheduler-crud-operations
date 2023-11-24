Imports System.Linq

Namespace MVCSchedulerEditable.Models

'#Region "#AppointmentDataAccessor"
    Public Class AppointmentDataAccessor

        Public Shared Sub InsertAppointment(ByVal appt As DBAppointment)
            If appt Is Nothing Then Return
            Dim db As SchedulingDataClassesDataContext = New SchedulingDataClassesDataContext()
            appt.UniqueID = appt.GetHashCode()
            db.DBAppointments.InsertOnSubmit(appt)
            db.SubmitChanges()
        End Sub

        Public Shared Sub UpdateAppointment(ByVal appt As DBAppointment)
            If appt Is Nothing Then Return
            Dim db As SchedulingDataClassesDataContext = New SchedulingDataClassesDataContext()
            Dim query As DBAppointment = CType((From carSchedule In db.DBAppointments Where carSchedule.UniqueID = appt.UniqueID Select carSchedule).SingleOrDefault(), DBAppointment)
            query.UniqueID = appt.UniqueID
            query.StartDate = appt.StartDate
            query.EndDate = appt.EndDate
            query.AllDay = appt.AllDay
            query.Subject = appt.Subject
            query.Description = appt.Description
            query.Location = appt.Location
            query.RecurrenceInfo = appt.RecurrenceInfo
            query.ReminderInfo = appt.ReminderInfo
            query.Status = appt.Status
            query.Type = appt.Type
            query.Label = appt.Label
            query.ResourceID = appt.ResourceID
            db.SubmitChanges()
        End Sub

        Public Shared Sub RemoveAppointment(ByVal appt As DBAppointment)
            Dim db As SchedulingDataClassesDataContext = New SchedulingDataClassesDataContext()
            Dim query As DBAppointment = CType((From carSchedule In db.DBAppointments Where carSchedule.UniqueID = appt.UniqueID Select carSchedule).SingleOrDefault(), DBAppointment)
            db.DBAppointments.DeleteOnSubmit(query)
            db.SubmitChanges()
        End Sub
    End Class
'#End Region  ' #AppointmentDataAccessor
End Namespace
