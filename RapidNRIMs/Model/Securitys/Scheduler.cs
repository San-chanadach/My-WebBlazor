using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using BlazorFullCalendar.Data;
using Newtonsoft.Json;
using RapidNRIMs.Model.Authenications;

namespace RapidNRIMs.Model.Securitys
{
    public class Scheduler
    {
        public int ScheduleID { get; set; }
        [Required(ErrorMessage = "The Name field is required")]
        public string ScheduleName { get; set; } = "";
        [Required(ErrorMessage = "The StartDate field is required")]
        public DateTime ScheduleStartDate { get; set; }
        [Required(ErrorMessage = "The EndDate field is required")]
	    public DateTime ScheduleEndDate { get; set; }
        [Required(ErrorMessage = "The User field is required")]
        public Nullable<Guid> UserID { get; set; }
        [Range(1,2000, ErrorMessage = "The Type field is required")]
        public Nullable<int> ScheduleTypeID { get; set; } = 0;

        public Account User { get; set; }
        public ScheduleType Scheduletype { get; set; }

        public void GetLookup (List<Account> accounts,List<ScheduleType> scheduleTypes)
        {
            this.User= accounts.Find(i=>i.UserID==this.UserID);
            this.Scheduletype = scheduleTypes.Find(s => s.ScheduleTypeID == this.ScheduleTypeID);
        }
        public List<CalendarDateItem> MaptoCalendar(List<Scheduler> scheduler) 
        {
            List<CalendarDateItem> calendarDateItems = new List<CalendarDateItem>();
            foreach (var i in scheduler) {
                calendarDateItems.Add(new CalendarDateItem()
                {
                    Id      = i.ScheduleID.ToString(),
                    Title   = i.ScheduleName,
                    Start   = i.ScheduleStartDate,
                    End     = i.ScheduleEndDate.AddDays(1),
                    BackgroundColor = i.Scheduletype.ScheduleTypeColour,
                    TextColor = "#333333",
                    AllDay = true,

                });
            }
            return calendarDateItems;
        }
     }
}