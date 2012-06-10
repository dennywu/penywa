using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BonaStoco.Inf.Data.ViewModel;

namespace Global.ReportingRepository.model
{
    [NamedSqlQuery("FindById", "select * from tblreceiveheader where receiveid=@id")]
    public class ReceiveHeaderReport : IViewModel
    {
        public Guid ReceiveId { get; set; }
        public string ReceiveNo { get; set; }
        public DateTime ReceiveDate { get; set; }
        public int CustId { get; set; }
    }

    [NamedSqlQuery("FindReceiveItemByReceiveId", "select r.*,a.rentalno,o.outstanding from tblreceiveitem r inner join tblrentalheader a on r.rentalid = a.rentalid inner join tblrentaloutstanding o on o.rentalid = r.rentalid where r.receiveid=@id")]
    public class ReceiveItemReport : IViewModel
    {
        public Guid ReceiveId { get; set; }
        public Guid RentalId { get; set; }
        public string RentalNo { get; set; }
        public decimal Denda { get; set; }
        public decimal PayAmount { get; set; }
        public decimal Outstanding { get; set; }
        public decimal Total { get; set; }
        public decimal TotalAfterDenda { get; set; }
    }

    [NamedSqlQuery("FindSummaryByReceiveId", "select * from tblreceivesummary where receiveid=@id")]
    public class ReceiveSummaryReport : IViewModel
    {
        public Guid ReceiveId { get; set; }
        public decimal Total { get; set; }
    }
}
