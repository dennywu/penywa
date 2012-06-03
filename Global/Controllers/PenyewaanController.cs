using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Global.Repository.models;
using Newtonsoft.Json;
using Global.Penyewaan.Domain;
using Spring.Context.Support;
using Global.ReportingRepository;
using Spring.Context.Support;
using Global.ReportingRepository.model;
using Global.Repository;

namespace Global.Controllers
{
    public class PenyewaanController : Controller
    {
        private PenyewaanDomain _domain;
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

        [HttpPost]
        public ActionResult AddPenyewaan(string rental)
        {
            Rental rent = JsonConvert.DeserializeObject<Rental>(rental);
            Guid rentalId = Guid.NewGuid();
            rent.RentalId = rentalId;
            rent.RentalNo = "RENT-001";
            CreateRentalHeader(rent);
            CreateRentalItem(rent);
            CreateRentalSummary(rent);
            return RedirectToAction("Index", "Penyewaan");
        }

        private void CreateRentalSummary(Rental rent)
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
