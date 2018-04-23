Imports DevExpress.Web.Mvc

Namespace MVCSchedulerEditable.Models
#Region "#SchedulerStorageProvider"
    Public Class SchedulerStorageProvider

        Private Shared defaultAppointmentStorage_Renamed As MVCxAppointmentStorage
        Public Shared ReadOnly Property DefaultAppointmentStorage() As MVCxAppointmentStorage
            Get
                If defaultAppointmentStorage_Renamed Is Nothing Then
                    defaultAppointmentStorage_Renamed = CreateDefaultAppointmentStorage()
                End If
                Return defaultAppointmentStorage_Renamed
            End Get
        End Property

        Private Shared Function CreateDefaultAppointmentStorage() As MVCxAppointmentStorage
            Dim appointmentStorage As New MVCxAppointmentStorage()
            appointmentStorage.Mappings.AppointmentId = "UniqueID"
            appointmentStorage.Mappings.Start = "StartDate"
            appointmentStorage.Mappings.End = "EndDate"
            appointmentStorage.Mappings.Subject = "Subject"
            appointmentStorage.Mappings.Description = "Description"
            appointmentStorage.Mappings.Location = "Location"
            appointmentStorage.Mappings.AllDay = "AllDay"
            appointmentStorage.Mappings.Type = "Type"
            appointmentStorage.Mappings.RecurrenceInfo = "RecurrenceInfo"
            appointmentStorage.Mappings.ReminderInfo = "ReminderInfo"
            appointmentStorage.Mappings.Label = "Label"
            appointmentStorage.Mappings.Status = "Status"
            appointmentStorage.Mappings.ResourceId = "ResourceID"
            Return appointmentStorage
        End Function


        Private Shared defaultResourceStorage_Renamed As MVCxResourceStorage
        Public Shared ReadOnly Property DefaultResourceStorage() As MVCxResourceStorage
            Get
                If defaultResourceStorage_Renamed Is Nothing Then
                    defaultResourceStorage_Renamed = CreateDefaultResourceStorage()
                End If
                Return defaultResourceStorage_Renamed
            End Get
        End Property
        Private Shared Function CreateDefaultResourceStorage() As MVCxResourceStorage
            Dim resourceStorage As New MVCxResourceStorage()
            resourceStorage.Mappings.ResourceId = "ResourceID"
            resourceStorage.Mappings.Caption = "ResourceName"
            Return resourceStorage
        End Function
    End Class
#End Region ' #SchedulerStorageProvider
End Namespace