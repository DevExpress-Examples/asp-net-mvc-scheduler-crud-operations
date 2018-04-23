using System.Linq;

namespace MVCSchedulerEditable.Models
{
    #region #SchedulerDataObject
    public class SchedulerDataObject
    {
        public System.Collections.IEnumerable Appointments { get; set; }
        public System.Collections.IEnumerable Resources { get; set; }
    }
    #endregion #SchedulerDataObject

    #region #SchedulerDataHelper
    public class SchedulerDataHelper
    {
        public static System.Collections.IEnumerable GetResources()
        {
            SchedulingDataClassesDataContext db = new SchedulingDataClassesDataContext();
            return from res in db.DBResources select res;
        }
        public static System.Collections.IEnumerable GetAppointments()
        {
            SchedulingDataClassesDataContext db = new SchedulingDataClassesDataContext();
            return from apt in db.DBAppointments select apt;
        }
        public static SchedulerDataObject DataObject
        {
            get
            {
                return new SchedulerDataObject()
                {
                    Appointments = GetAppointments(),
                    Resources = GetResources()
                };
            }
        }
    }
    #endregion #SchedulerDataHelper
}