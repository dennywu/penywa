using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Global.Repository.models;
using Newtonsoft.Json;
using Global.Penyewaan.Domain;
using Spring.Context.Support;
using Global.Outstanding;
using Global.ReportingRepository;
using Spring.Context.Support;
using Global.Repository;

namespace Global.Controllers
{
    public class PenyewaanController : Controller
    {
        private PenyewaanDomain _domain;
        IRentalReportingRepository rentalreportingRepo;
        ICustomerRepository custRepo;
        private RentalOutstandingHandler _outstanding;
        private CustomerOutstandingHandler _custoutstanding;
        [Authorize]
        public ActionResult Index()
        {
            IList<Global.ReportingRepository.model.RentalListViewReport> rentalList = RentalReportingRepository.GetListView();
            return View(rentalList);
        }

        public ActionResult AddPenyewaan()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddPenyewaan(string rental)
        {
            Rental rent = JsonConvert.DeserializeObject<Rental>(rental);
            Guid rentalId = Guid.NewGuid();
            rent.RentalId = rentalId;
            rent.RentalNo = "RENTAL-" + Guid.NewGuid().ToString().GetHashCode().ToString("x");
            CreateRentalHeader(rent);
            CreateRentalItem(rent);
            decimal outstanding = CreateRentalSummary(rent);
            Outstanding.CreateNewOutstandingRental(rent.RentalId, outstanding);
            CustomerOutstanding.AddOutstanding(rent.CustomerId, outstanding);
            return Json(new { redirectTo = Url.Action("DetailPenyewaan", "Penyewaan", new { rentalId = rentalId.ToString() }) }, JsonRequestBehavior.AllowGet);
        }

        private decimal CreateRentalSummary(Rental rent)
        {
            decimal subtotal = 0;
            foreach (RentalItem itm in rent.Items)
            {
                subtotal += itm.Total;
            }
            RentalSummary summary = new RentalSummary()
            {
                RentalId = rent.RentalId,
                Total = subtotal
            };
            Penyewaan.CreateRentalSummary(summary);
            return subtotal;
        }

        private void CreateRentalItem(Rental rent)
        {
            foreach (RentalItem itm in rent.Items)
            {
                RentalItem item = new RentalItem
                {
                    RentalId = rent.RentalId,
                    ItemId = itm.ItemId,
                    Deskripsi = itm.Deskripsi,
                    Qty = itm.Qty,
                    Harga = itm.Harga,
                    Total = itm.Total
                };
                Penyewaan.CreateRentalItem(item);
            }
        }

        private void CreateRentalHeader(Rental rent)
        {
            RentalHeader header = new RentalHeader
            {
                CustomerId = rent.CustomerId,
                DueDate = rent.DueDate,
                RentalId = rent.RentalId,
                RentalNo = rent.RentalNo,
                TransactionDate = rent.TransactionDate
            };
            Penyewaan.CreateRentalHeader(header);
        }
        private PenyewaanDomain Penyewaan
        {
            get
            {
                if(_domain == null)
                    _domain = (PenyewaanDomain)ContextRegistry.GetContext().GetObject("PenyewaanDomain");
                return _domain;
            }
        }
        private RentalOutstandingHandler Outstanding
        {
            get
            {
                if (_outstanding == null)
                    _outstanding = (RentalOutstandingHandler)ContextRegistry.GetContext().GetObject("Outstanding");
                return _outstanding;
            }
        }
        private CustomerOutstandingHandler CustomerOutstanding
        {
            get
            {
                if (_custoutstanding == null)
                    _custoutstanding = (CustomerOutstandingHandler)ContextRegistry.GetContext().GetObject("CustomerOutstanding");
                return _custoutstanding;
            }
        }
        public ActionResult DetailPenyewaan(string rentalId)
        {
            Guid _rentalId = new Guid(rentalId);
            Global.ReportingRepository.model.RentalHeader rentalHeader = RentalReportingRepository.GetRentalHeaderById(_rentalId);
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
