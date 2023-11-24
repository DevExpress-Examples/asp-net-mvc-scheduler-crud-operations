Imports DevExpress.Web.Mvc

Namespace MVCSchedulerEditable.Models

'#Region "#SchedulerStorageProvider"
    Public Class SchedulerStorageProvider

        Private Shared defaultAppointmentStorageField As MVCxAppointmentStorage

        Public Shared ReadOnly Property DefaultAppointmentStorage As MVCxAppointmentStorage
            Get
                If defaultAppointmentStorageField Is Nothing Then defaultAppointmentStorageField = CreateDefaultAppointmentStorage()
                Return defaultAppointmentStorageField
            End Get
        End Property

        Private Shared Function CreateDefaultAppointmentStorage() As MVCxAppointmentStorage
            Dim appointmentStorage As MVCxAppointmentStorage = New MVCxAppointmentStorage()
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

        Private Shared defaultResourceStorageField As MVCxResourceStorage

        Public Shared ReadOnly Property DefaultResourceStorage As MVCxResourceStorage
            Get
                If defaultResourceStorageField Is Nothing Then defaultResourceStorageField = CreateDefaultResourceStorage()
                Return defaultResourceStorageField
            End Get
        End Property

        Private Shared Function CreateDefaultResourceStorage() As MVCxResourceStorage
            Dim resourceStorage As MVCxResourceStorage = New MVCxResourceStorage()
            resourceStorage.Mappings.ResourceId = "ResourceID"
            resourceStorage.Mappings.Caption = "ResourceName"
            Return resourceStorage
        End Function
    End Class
'#End Region  ' #SchedulerStorageProvider
End Namespace
