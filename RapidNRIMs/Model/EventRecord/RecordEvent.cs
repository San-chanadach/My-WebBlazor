using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace RapidNRIMs.Model.EventRecord
{
    public class RecordEvent
    {
        /// <summary>
        /// Index
        /// </summary>
        public int EventID { get; set; }

        /// <summary>
        /// Number {Barcode}
        /// </summary>
        public string EventNumber { get; set; } = string.Empty;

        public string EventName { get; set;} = string.Empty;

        /// <summary>
        ///  ประเภทเหตุการณ์
        /// </summary>
        public Nullable<int>  EventType {get; set;}
        /// <summary>
        /// วันที่เกิดเหตุ
        /// </summary>
        public Nullable<DateTime> EventRegisterDate { get; set; }
        /// <summary>
        /// สถานที่เกิดเหตุ
        /// </summary>
        public string EventLocationName { get; set; } = string.Empty;
        /// <summary>
        /// จังหวัด
        /// </summary>
        public Nullable<int> ProvinceID { get; set; }
        /// <summary>
        /// อำเภอ
        /// </summary>
        public Nullable<int> DistrictID { get; set; }
        /// <summary>
        /// ตำบล
        /// </summary>
        public Nullable<int> SubDistrictID { get; set; }
        /// <summary>
        /// ZipCode
        /// </summary>
        public Nullable<int> zipCode { get; set; } 
        
        /// <summary>
        /// Informer ผู้แจ้งเหตุ
        /// </summary>
        public string EventInformerName { get; set; } = string.Empty;
        /// <summary>
        /// Information รายละเอียดเบื้องต้น
        /// </summary>
        public string EventInformation{ get; set;} = string.Empty;
        /// <summary>
        /// วันที่เริ่มดำเนินการ
        /// </summary>
        public Nullable<DateTime> EventStartDate { get; set; } /*= DateTime.Today;*/
        public DateTime StartTime { get; set; }
        public DateTime OriginalStartTime { get; set; }
        /// <summary>
        /// วันที่สิ้นสุดการดำเนินการ
        /// </summary>
        public Nullable<DateTime> EventEndDate { get; set; } /*= DateTime.Today.AddDays(1);*/
        public DateTime EndTime { get; set; }
        /// <summary>
        /// สถานะการดำเนินงาน
        /// </summary>
        public int? EventStatusID { get; set; }
        /// <summary>
        /// คนลงทะเบียน
        /// </summary>
        public Guid? eventCreateBy { get; set; }
        /// <summary>
        /// วันที่ลงทะเบียน
        /// </summary>
        public DateTime? eventCreateDate { get; set; }

        public Nullable<Guid> eventUpdateBy { get; set; } = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");

        public Nullable<DateTime> eventUpdateDate { get; set; } = DateTime.Today;
        /// <summary>
        /// 
        /// </summary>
        public string eventContaminationDescription { get; set; } = string.Empty;
        public string eventRadiationScreening{ get; set; } = string.Empty;
        public string eventRecommendResult { get; set; } = string.Empty;

        public string TotalHour { get; set; } = string.Empty;


        public bool? IsActive { get; set; }


        /*
         StatusID = ผลรวมของ State        
         StateID += 16   เมื่อ กด InstrumentCheckOutAll
         StateID += 8    เมื่อ กด InstrumentCheckInAll
         StateID += 4    เมื่อ กด Consumable CheckOut         
         */

        public void setCheckOutInstrumentAll(){

            if (!isCheckOutInstrumentAll()) {

                this.EventStatusID = EventStatusID + 16;
            }

       
        }

        public void setCheckInInstrumentAll()
        {

            if (!isCheckInInstrumentAll())
            {

                this.EventStatusID = EventStatusID + 8;
            }


        }

        public void setCheckOutConsumableAll()
        {

            if (!isCheckOutConsumableAll())
            {

                this.EventStatusID = EventStatusID + 4;
            }


        }



        public bool isCheckOutInstrumentAll() {

            var status = EventStatusID / 16;
            return (status == 1);
        }


        public bool isCheckInInstrumentAll()
        {

            var status =(EventStatusID % 16) / 8;
            return (status == 1);
        }



        public bool isCheckOutConsumableAll()
        {

            var status = ((EventStatusID % 16) % 8) / 4;
            return (status == 1);
        }




    }
}