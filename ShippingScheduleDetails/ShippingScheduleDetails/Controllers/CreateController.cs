using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShippingScheduleDetails.Models;

namespace ShippingScheduleDetails.Controllers
{
    public class CreateController : Controller
    {
        private ShippingScheduleDetail db = new ShippingScheduleDetail();
        // GET: Create
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateSheduling()
        {
            List<SelectListItem> sponsor = new List<SelectListItem>();
            sponsor.Add(new SelectListItem { Text = "--Select Sponsor--", Value = null });
            var sponsorName = db.MasterProtocolLookupTables.Where(x => x.isActive == true).Select(x => x.Sponsor).Distinct().ToList();
            foreach (var item in sponsorName)
            {
                sponsor.Add(new SelectListItem { Text = item, Value = item });
            }

            List<SelectListItem> shippingType = new List<SelectListItem>();
            shippingType.Add(new SelectListItem { Text = "--Select Shipping Type --", Value = null });
            shippingType.Add(new SelectListItem() { Text = "Day of Collection", Value = "Daily" });
            
            shippingType.Add(new SelectListItem() { Text = "Weekly", Value = "Weekly" });
            shippingType.Add(new SelectListItem() { Text = "Monthly", Value = "Monthly" });
            shippingType.Add(new SelectListItem() { Text = "Time Point", Value = "TimePoint" });

            ViewBag.sponsors = sponsor;
            ViewBag.ShipType = shippingType;
            return View();
        }

        [HttpPost]
        public ActionResult CreateSheduling(ShippingScheduleDetail obj)
        {
            return View();
        }

        public JsonResult GetMasterProtocol(string id)
        {
            List<SelectListItem> masterProtocol = new List<SelectListItem>();
            masterProtocol.Add(new SelectListItem { Text = "--Select Protocol--", Value = null });
            var masterProtocolName = (from mp in db.MasterProtocolLookupTables where mp.isActive == true && mp.Sponsor == id select mp).OrderBy(mp => mp.Protocol).ToList();
            foreach (var item in masterProtocolName)
            {
                masterProtocol.Add(new SelectListItem { Text = item.Protocol, Value = item.ID.ToString() });
            }

            return Json(masterProtocol, JsonRequestBehavior.AllowGet);
        }

        //Get: Method to get the Assessment ids from  the table
        public JsonResult GetAssessment(int id)
        {
            var assessment = (from am in db.AnalyteMatrices where am.MasterProtocolID == id select am).OrderBy(am => am.Assessment).ToList();
            List<SelectListItem> liAssessment = new List<SelectListItem>();

            liAssessment.Add(new SelectListItem { Text = "--Select Assessment--", Value = null });
            if (assessment != null)
            {
                foreach (var x in assessment)
                {
                    liAssessment.Add(new SelectListItem { Text = x.Assessment, Value = x.ID.ToString() });

                }
            }
            return Json(liAssessment, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDays()
        {
            List<SelectListItem> DayList = new List<SelectListItem>();
            DayList.Add(new SelectListItem { Text = "--Select Day--", Value = null });
            DayList.Add(new SelectListItem { Text = "Monday", Value = "Monday" });
            DayList.Add(new SelectListItem { Text = "Tuesday", Value = "Tuesday" });
            DayList.Add(new SelectListItem { Text = "Wednesday", Value = "Wednesday" });
            DayList.Add(new SelectListItem { Text = "Thursday", Value = "Thursday" });
            DayList.Add(new SelectListItem { Text = "Friday", Value = "Friday" });
            DayList.Add(new SelectListItem { Text = "Satureday", Value = "Satureday" });
            DayList.Add(new SelectListItem { Text = "Sunday", Value = "Sunday" });

            return Json(DayList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDayoftheMonth()
        {
            List<SelectListItem> DayoftheMonthList = new List<SelectListItem>();
            DayoftheMonthList.Add(new SelectListItem { Text = "--Select Day--", Value = null });
            DayoftheMonthList.Add(new SelectListItem { Text = "First Day of the Month", Value = "Firstday" });
            DayoftheMonthList.Add(new SelectListItem { Text = "Last Day of the Month", Value = "Lastday" });
            DayoftheMonthList.Add(new SelectListItem { Text = "Particular Day", Value = "ParticularDay" });

            return Json(DayoftheMonthList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTimePoints(int? id)
        {
            List<SelectListItem> TimePointList = new List<SelectListItem>();
            var cycleTimepoint = db.Database.SqlQuery<CycleTimepoint>("Select ('P'+CAST(p.Period as nvarchar(MAX))+case when WeekNominal='0' then '' else +'W'+CAST( WeekNominal  as nvarchar(MAX))end 	+case when DayNominal='0' then '' else+'D'+CAST(DayNominal as nvarchar(MAX))end 	+case when HourNominal='0' then '' else+'H'+CAST(HourNominal as nvarchar(MAX))end 	+case when MinuteNominal='0' then '' else+'M'+CAST(MinuteNominal as nvarchar(MAX))end) as Name, tp.Timepoint as Value FROM TimePoint tp INNER JOIN Period p ON p.ID=tp.PeriodID  WHERE tp.AnalyteMatrixID=@analyteMatrixId ORDER BY Name;"
                                                        , new SqlParameter("@analyteMatrixId", id)).ToList();
            foreach(var listItem in cycleTimepoint)
            {
                TimePointList.Add(new SelectListItem { Text = listItem.Name, Value = listItem.Value.ToString() });
            }

            return Json(TimePointList, JsonRequestBehavior.AllowGet);
        }        
    }
}