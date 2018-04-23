Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports DevExpress.Web.Mvc
Imports MVCSchedulerEditable.Models

Namespace MVCSchedulerEditable.Views
    Public Class HomeController
        Inherits Controller

        '
        ' GET: /Home/
        #Region "#commonactions"
        Public Function Index() As ActionResult
            Return View(SchedulerDataHelper.DataObject)
        End Function

        Public Function SchedulerPartial() As ActionResult
            Return PartialView("SchedulerPartial", SchedulerDataHelper.DataObject)
        End Function
        #End Region ' #commonactions
        #Region "#editactions"
        Public Function EditAppointment() As ActionResult
            UpdateAppointment()
            Return PartialView("SchedulerPartial", SchedulerDataHelper.DataObject)
        End Function

        Private Shared Sub UpdateAppointment()
            Dim insertedAppointments() As DBAppointment = SchedulerExtension.GetAppointmentsToInsert(Of DBAppointment)("scheduler", SchedulerDataHelper.GetAppointments(), SchedulerDataHelper.GetResources(), SchedulerStorageProvider.DefaultAppointmentStorage, SchedulerStorageProvider.DefaultResourceStorage)
            For Each appt In insertedAppointments
                AppointmentDataAccessor.InsertAppointment(appt)
            Next appt

            Dim updatedAppointments() As DBAppointment = SchedulerExtension.GetAppointmentsToUpdate(Of DBAppointment)("scheduler", SchedulerDataHelper.GetAppointments(), SchedulerDataHelper.GetResources(), SchedulerStorageProvider.DefaultAppointmentStorage, SchedulerStorageProvider.DefaultResourceStorage)
            For Each appt In updatedAppointments
                AppointmentDataAccessor.UpdateAppointment(appt)
            Next appt

            Dim removedAppointments() As DBAppointment = SchedulerExtension.GetAppointmentsToRemove(Of DBAppointment)("scheduler", SchedulerDataHelper.GetAppointments(), SchedulerDataHelper.GetResources(), SchedulerStorageProvider.DefaultAppointmentStorage, SchedulerStorageProvider.DefaultResourceStorage)
            For Each appt In removedAppointments
                AppointmentDataAccessor.RemoveAppointment(appt)
            Next appt
        End Sub
        #End Region ' #editactions
    End Class
End Namespace
