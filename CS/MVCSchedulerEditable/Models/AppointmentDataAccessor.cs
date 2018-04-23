using System.Linq;

namespace MVCSchedulerEditable.Models
{
    #region #AppointmentDataAccessor
    public class AppointmentDataAccessor
    {
        public static void InsertAppointment(DBAppointment appt)
        {
            if (appt == null)
                return;
            SchedulingDataClassesDataContext db = new SchedulingDataClassesDataContext();
            appt.UniqueID = appt.GetHashCode();
            db.DBAppointments.InsertOnSubmit(appt);
            db.SubmitChanges();
        }
        public static void UpdateAppointment(DBAppointment appt)
        {
            if (appt == null)
                return;
            SchedulingDataClassesDataContext db = new SchedulingDataClassesDataContext();
            DBAppointment query = (DBAppointment)(from carSchedule 
                                                      in db.DBAppointments 
                                                  where carSchedule.UniqueID == appt.UniqueID 
                                                  select carSchedule).SingleOrDefault();

            query.UniqueID = appt.UniqueID;
            query.StartDate = appt.StartDate;
            query.EndDate = appt.EndDate;
            query.AllDay = appt.AllDay;
            query.Subject = appt.Subject;
            query.Description = appt.Description;
            query.Location = appt.Location;
            query.RecurrenceInfo = appt.RecurrenceInfo;
            query.ReminderInfo = appt.ReminderInfo;
            query.Status = appt.Status;
            query.Type = appt.Type;
            query.Label = appt.Label;
            query.ResourceID = appt.ResourceID;
            db.SubmitChanges();
        }
        public static void RemoveAppointment(DBAppointment appt)
        {
            SchedulingDataClassesDataContext db = new SchedulingDataClassesDataContext();
            DBAppointment query = (DBAppointment)(from carSchedule 
                                                      in db.DBAppointments 
                                                  where carSchedule.UniqueID == appt.UniqueID 
                                                  select carSchedule).SingleOrDefault();
            db.DBAppointments.DeleteOnSubmit(query);
            db.SubmitChanges();
        }
    }
    #endregion #AppointmentDataAccessor
}