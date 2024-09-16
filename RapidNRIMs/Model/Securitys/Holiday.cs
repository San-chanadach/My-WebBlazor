using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;
using BlazorFullCalendar.Data;

namespace RapidNRIMs.Model.Securitys
{
    public class Holiday
    {
        public int ScheduleID { get; set; }
        [Required(ErrorMessage = "The Name field is required")]
        public string ScheduleName { get; set; } = "";
        [Required(ErrorMessage = "The StartDate field is required")]
        public DateTime ScheduleStartDate { get; set; } 
        [Required(ErrorMessage = "The EndDate field is required")]
        public DateTime ScheduleEndDate { get; set; }
        public Nullable<int> ScheduleTypeID { get; set; }

        public ScheduleType ScheduleType { get; set; }

        public void Getlookup(List<ScheduleType> s)
        {
            this.ScheduleType = s.Find(r => r.ScheduleTypeID == this.ScheduleTypeID);
        }

        public List<CalendarDateItem> MaptoCalendar(List<Holiday> holidays)
        {
            List<CalendarDateItem> calendarDateItems = new List<CalendarDateItem>();
            foreach (var i in holidays)
            {
                calendarDateItems.Add(new CalendarDateItem()
                {
                    Id = i.ScheduleID.ToString(),
                    Title = i.ScheduleName,
                    Start = i.ScheduleStartDate,
                    End = i.ScheduleEndDate.AddDays(1) ,
                    BackgroundColor = "#D9D9D9",
                    TextColor = "#d62713",
                    AllDay = true

                });
            }
            return calendarDateItems;
        }
    }
}