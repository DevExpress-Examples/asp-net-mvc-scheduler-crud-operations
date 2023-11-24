Imports System.Linq

Namespace MVCSchedulerEditable.Models

'#Region "#SchedulerDataObject"
    Public Class SchedulerDataObject

        Public Property Appointments As System.Collections.IEnumerable

        Public Property Resources As System.Collections.IEnumerable
    End Class

'#End Region  ' #SchedulerDataObject
'#Region "#SchedulerDataHelper"
    Public Class SchedulerDataHelper

        Public Shared Function GetResources() As System.Collections.IEnumerable
            Dim db As SchedulingDataClassesDataContext = New SchedulingDataClassesDataContext()
            Return From res In db.DBResources Select res
        End Function

        Public Shared Function GetAppointments() As System.Collections.IEnumerable
            Dim db As SchedulingDataClassesDataContext = New SchedulingDataClassesDataContext()
            Return From apt In db.DBAppointments Select apt
        End Function

        Public Shared ReadOnly Property DataObject As SchedulerDataObject
            Get
                Return New SchedulerDataObject() With {.Appointments = GetAppointments(), .Resources = GetResources()}
            End Get
        End Property
    End Class
'#End Region  ' #SchedulerDataHelper
End Namespace
