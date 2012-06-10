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
        private IRentalReportingRepository rentalreportingRepo;
        private IRentalRepository rentalRepo;
        private ICustomerRepository custRepo;
        private RentalOutstandingHandler _outstanding;
        private CustomerOutstandingHandler _custoutstanding;
        private IItemRepository itemRepo;
        
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
            CustomerOutstanding.AddOutstanding(rent.CustId, outstanding);
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
                CustId = rent.CustId,
                DueDate = rent.DueDate,
                RentalId = rent.RentalId,
                RentalNo = rent.RentalNo,
                TransactionDate = rent.TransactionDate,
                Status = RentalStatus.APPROVED
            };
            Penyewaan.CreateRentalHeader(header);
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

        public ActionResult ReturnRental(Guid rentalId)
        {
            RentalHeader header = RentalRepository.GetRentalHeaderById(rentalId);
            header.Status = RentalStatus.RETURN;
            Penyewaan.UpdateRentalHeader(header);
            DateTime today = DateTime.UtcNow.Date;
            int latedate = today.CompareTo(header.DueDate) > 0 ? today.CompareTo(header.DueDate) : 0;

            IList<RentalItem> items = RentalRepository.GetRentalItemById(rentalId);
            decimal totalDenda = 0;
            decimal total = 0;
            foreach (RentalItem item in items)
            {
                decimal dendaPerHari = ItemRepository.GetItemById(item.ItemId).DendaPerHari;
                item.Denda = (dendaPerHari * latedate) * item.Qty;
                item.Total += item.Denda;
                Penyewaan.UpdateRentalItem(item);
                totalDenda += item.Denda;
                total += item.Total;
            }

            RentalSummary summary = RentalRepository.GetRentalSummaryById(rentalId);
            summary.TotalDenda = totalDenda;
            summary.Total = total;
            Penyewaan.UpdateRentalSummary(summary);

            Outstanding.AddOutstanding(rentalId, totalDenda);
            CustomerOutstanding.AddOutstanding(header.CustId, totalDenda);
            return RedirectToAction("DetailPenyewaan", new { rentalId = rentalId });
        }
        public JsonResult HistoryReceive(Guid id)
        {
            IList<Global.ReportingRepository.model.HistoryReceive> history = RentalReportingRepository.GetHistoryReceiveByRentalId(id);
            return Json(history, JsonRequestBehavior.AllowGet);
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
        private PenyewaanDomain Penyewaan
        {
            get
            {
                if (_domain == null)
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
        private IRentalRepository RentalRepository
        {
            get
            {
                if (rentalRepo == null)
                    rentalRepo = (IRentalRepository)ContextRegistry.GetContext().GetObject("RentRepository");
                return rentalRepo;
            }
        }
        private IItemRepository ItemRepository
        {
            get
            {
                if (itemRepo == null)
                    itemRepo = (IItemRepository)ContextRegistry.GetContext().GetObject("ItemRepository");
                return itemRepo;
            }
        }
    }
}
