using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Global.ReportingRepository;
using Spring.Context.Support;
using Global.ReportingRepository.model;
using Global.Repository;

namespace Global.Controllers
{
    public class PenyewaanController : Controller
    {
        IRentalReportingRepository rentalreportingRepo;
        ICustomerRepository custRepo;

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddPenyewaan()
        {
            return View();
        }

        public ActionResult DetailPenyewaan(string rentalId)
        {
            Guid _rentalId = new Guid(rentalId);
            RentalHeader rentalHeader = RentalReportingRepository.GetRentalHeaderById(_rentalId);
            ViewBag.CustomerName = CustomerRepository.GetCustomerById(rentalHeader.CustId).Name;
            ViewBag.RentalItems = RentalReportingRepository.GetRentalItemByRentalId(_rentalId);
            ViewBag.Summary = RentalReportingRepository.GetRentalSummaryByRentalId(_rentalId);
            return View(rentalHeader);
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
        private ICustomerRepository CustomerRepository
        {
            get
            {
                if (custRepo == null)
                    custRepo = (ICustomerRepository)ContextRegistry.GetContext().GetObject("CustomerRepository");
                return custRepo;
            }
        }
    }
}
