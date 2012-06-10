using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Global.ReportingRepository;
using Global.Repository;
using Spring.Context.Support;
using Global.ReportingRepository.model;
using Global.Repository.models;
using Newtonsoft.Json;
using Global.Penerimaan.Domain;
using Global.Outstanding;

namespace Global.Controllers
{
    [Authorize]
    public class PenerimaanController : Controller
    {
        private PenerimaanDomain _domain;
        private CustomerOutstandingHandler _custoutstanding;
        private RentalOutstandingHandler _outstanding;
        private IRentalReportingRepository rentalreportingRepo;
        private IReceiveReportingRepository receivereportingRepo;
        //
        // GET: /Pembayaran/

        public ActionResult Index()
        {
            IList<ReceiveListViewReport> listView = ReceiveReportingRepository.GetListView();
            return View(listView);
        }

        public ActionResult AddPenerimaan()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddPenerimaan(string receive)
        {
            Receive _receive = JsonConvert.DeserializeObject<Receive>(receive);
            Guid receiveId = Guid.NewGuid();
            _receive.ReceiveId = receiveId;
            _receive.ReceiveNo = "RECEIVE-" + Guid.NewGuid().ToString().GetHashCode().ToString("x");
            CreateReceiveHeader(_receive);
            CreateReceiveItem(_receive);
            decimal totalPayAmount = CreateReceiveSummary(_receive);
            RecalculateRentaloutstanding(_receive);
            CustomerOutstanding.MinusOutstanding(_receive.CustId, totalPayAmount);
            return Json(new { redirectTo = Url.Action("Index", "Penerimaan") }, JsonRequestBehavior.AllowGet);
        }

        private void RecalculateRentaloutstanding(Receive _receive)
        {
            foreach (ReceiveItem itm in _receive.Items)
            {
                Outstanding.MinusOutstanding(itm.RentalId, itm.PayAmount);
            }
        }

        private decimal CreateReceiveSummary(Receive _receive)
        {
            decimal subTotal = 0;
            foreach (ReceiveItem itm in _receive.Items)
            {
                subTotal += itm.PayAmount;
            }
            ReceiveSummary summary = new ReceiveSummary()
            {
                ReceiveId = _receive.ReceiveId,
                Total = subTotal
            };
            Penerimaan.CreateRentalSummary(summary);
            return subTotal;
        }

        private void CreateReceiveItem(Receive _receive)
        {
            foreach (ReceiveItem itm in _receive.Items)
            {
                ReceiveItem item = new ReceiveItem()
                {
                    RentalId = itm.RentalId,
                    ReceiveId = _receive.ReceiveId,
                    TotalDenda = itm.TotalDenda,
                    PayAmount = itm.PayAmount,
                    Total = itm.Total,
                    TotalAfterDenda = itm.TotalAfterDenda
                };
                Penerimaan.CreateRentalItem(item);
            }
        }

        private void CreateReceiveHeader(Receive _receive)
        {
            ReceiveHeader header = new ReceiveHeader()
            {
                ReceiveId = _receive.ReceiveId,
                ReceiveNo = _receive.ReceiveNo,
                CustId = _receive.CustId,
                ReceiveDate = _receive.ReceiveDate
            };
            Penerimaan.CreateReceiveHeader(header);
        }

        public JsonResult GetAllRental(string custId)
        {
            int _custId = int.Parse(custId.ToString());
            return Json(RentalReportingRepository.GetReturnedListViewbyCustId(_custId), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetReceiveItemDetail(string rentalId)
        {
            Guid _rentalId = new Guid(rentalId);
            Global.ReportingRepository.model.RentalHeader _rentalHeader = RentalReportingRepository.GetRentalHeaderById(_rentalId);
            Global.ReportingRepository.model.RentalSummary _rentalSummary = RentalReportingRepository.GetRentalSummaryByRentalId(_rentalId);
            Global.ReportingRepository.model.RentalOutstanding _rentalOutstanding = RentalReportingRepository.GetRentalOutstandingByRentalId(_rentalId);
            return Json(
                new
                {
                    RentalId = _rentalHeader.RentalId,
                    RentalNo = _rentalHeader.RentalNo,
                    TransactionDate = _rentalHeader.TransactionDate,
                    DueDate = _rentalHeader.DueDate,
                    Total = _rentalSummary.Total - _rentalSummary.TotalDenda,
                    TotalDenda = _rentalSummary.TotalDenda,
                    TotalAfterDenda = _rentalSummary.Total,
                    Outstanding = _rentalOutstanding.Outstanding
                }
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

        private PenerimaanDomain Penerimaan
        {
            get
            {
                if (_domain == null)
                    _domain = (PenerimaanDomain)ContextRegistry.GetContext().GetObject("PenerimaanDomain");
                return _domain;
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

        private RentalOutstandingHandler Outstanding
        {
            get
            {
                if (_outstanding == null)
                    _outstanding = (RentalOutstandingHandler)ContextRegistry.GetContext().GetObject("Outstanding");
                return _outstanding;
            }
        }

        private IReceiveReportingRepository ReceiveReportingRepository
        {
            get
            {
                if (receivereportingRepo == null)
                    receivereportingRepo = (IReceiveReportingRepository)ContextRegistry.GetContext().GetObject("ReceiveReportingRepository");
                return receivereportingRepo;
            }
        }
    }
}
