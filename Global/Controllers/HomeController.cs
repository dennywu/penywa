using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Global.ReportingRepository.model;
using Global.ReportingRepository;
using Spring.Context.Support;

namespace Global.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private DateTime utcDate;
        private IRentalReportingRepository rentalreportingRepo;
        public HomeController()
        {
            utcDate = DateTime.SpecifyKind(DateTime.Now.Date, DateTimeKind.Utc);
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Grafik()
        {
            return View();
        }
        public JsonResult MonitoringSalesByPeriode()
        {
            IList<SalesMonitoring> sales = new List<SalesMonitoring>();
            DateTime fromDate = DateTime.UtcNow.AddDays(-30);
            for (var i = 0; i < 31; i++)
            {
                DateTime date = fromDate.AddDays(i);
                SalesMonitoring monitoring = RentalReportingRepository.GetSalesMonitoring(date);
                if (monitoring == null)
                {
                    monitoring = new SalesMonitoring()
                    {
                        Date = date.Date,
                        Amount = 0
                    };
                }
                sales.Add(monitoring);
            }
            return Json(sales, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SalesAmountToday()
        {
            return Json(RentalReportingRepository.GetSalesAmountByDate(utcDate), JsonRequestBehavior.AllowGet);
        }
        public JsonResult SalesAmountThisMonth()
        {
            DateTime from = utcDate.AddDays(0 - utcDate.Day + 1);
            int daysOfMonth = DateTime.DaysInMonth(utcDate.Year, utcDate.Month);
            DateTime to = new DateTime(utcDate.Year, utcDate.Month, daysOfMonth);
            return Json(RentalReportingRepository.GetSalesAmountBetweenDate(from,to), JsonRequestBehavior.AllowGet);
        }
        public JsonResult SalesAmountThisYear()
        {
            int tahun = utcDate.Year;
            DateTime from = new DateTime(tahun, 1, 1);
            int dayOfMonth = DateTime.DaysInMonth(tahun, 12);
            DateTime to = new DateTime(tahun, 12, dayOfMonth);
            return Json(RentalReportingRepository.GetSalesAmountBetweenDate(from,to), JsonRequestBehavior.AllowGet);
        }

        public JsonResult OutstandingAmountToday()
        {
            return Json(RentalReportingRepository.GetOutstandingAmountByDate(utcDate), JsonRequestBehavior.AllowGet);
        }
        public JsonResult OutstandingAmountThisMonth()
        {
            DateTime from = utcDate.AddDays(0 - utcDate.Day + 1);
            int daysOfMonth = DateTime.DaysInMonth(utcDate.Year, utcDate.Month);
            DateTime to = new DateTime(utcDate.Year, utcDate.Month, daysOfMonth);
            return Json(RentalReportingRepository.GetOutstandingAmountBetweenDate(from, to), JsonRequestBehavior.AllowGet);
        }
        public JsonResult OutstandingAmountThisYear()
        {
            int tahun = utcDate.Year;
            DateTime from = new DateTime(tahun, 1, 1);
            int dayOfMonth = DateTime.DaysInMonth(tahun, 12);
            DateTime to = new DateTime(tahun, 12, dayOfMonth);
            return Json(RentalReportingRepository.GetOutstandingAmountBetweenDate(from, to), JsonRequestBehavior.AllowGet);
        }

        private string GetPeriod(int month)
        {
            DateTime toDay = DateTime.Today;
            int tahun = toDay.Year;
            int bulan = month;
            string period = string.Format("{0}{1}", tahun, bulan.ToString().PadLeft(2, '0'));
            return period;
        }

        private IRentalReportingRepository RentalReportingRepository
        {
            get
            {
                if (rentalreportingRepo == null)
                    rentalreportingRepo = (IRentalReportingRepository)ContextRegistry.GetContext().GetObject("RentalReportingRepository");
                return rentalreportingRepo;
            }
        }
    }
}
