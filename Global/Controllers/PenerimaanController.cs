using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Global.ReportingRepository;
using Global.Repository;
using Spring.Context.Support;
using Global.ReportingRepository.model;

namespace Global.Controllers
{
    [Authorize]
    public class PenerimaanController : Controller
    {
        IRentalReportingRepository rentalreportingRepo;
        //
        // GET: /Pembayaran/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddPenerimaan()
        {
            return View();
        }
        public JsonResult GetAllRental()
        {
            return Json(RentalReportingRepository.GetListView(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetReceiveItemDetail(string rentalId)
        {
            Guid _rentalId = new Guid(rentalId);
            RentalHeader _rentalHeader=RentalReportingRepository.GetRentalHeaderById(_rentalId);
            RentalSummary _rentalSummary=RentalReportingRepository.GetRentalSummaryByRentalId(_rentalId);
            return Json(
                new { 
                    RentalId = _rentalHeader.RentalId, 
                    RentalNo = _rentalHeader.RentalNo, 
                    TransactionDate = _rentalHeader.TransactionDate, 
                    DueDate = _rentalHeader.DueDate, 
                    Total = _rentalSummary.Total }
                    , JsonRequestBehavior.AllowGet);
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
