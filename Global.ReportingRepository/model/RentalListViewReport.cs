using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BonaStoco.Inf.Data.ViewModel;

namespace Global.ReportingRepository.model
{
    [NamedSqlQuery("GetRentalListView", @"SELECT 
                    h.rentalid,
                    h.rentalno,
                    h.status,
                    c.name as CustomerName,
                    h.transactiondate,
                    h.duedate,
                    s.total,
                    o.outstanding 
                    FROM tblrentalheader h inner join 
                    tblcustomer c on h.custid = c.id inner join 
                    tblrentalsummary s on h.rentalid = s.rentalid inner join
                    tblrentaloutstanding o on h.rentalid = o.rentalid")]
    [NamedSqlQuery("GetReturnedRentalListViewByCustomerId", @"SELECT 
                    h.rentalid,
                    h.rentalno,
                    h.status,
                    c.name as CustomerName,
                    h.transactiondate,
                    h.duedate,
                    s.total,
                    o.outstanding 
                    FROM tblrentalheader h inner join 
                    tblcustomer c on h.custid = c.id inner join 
                    tblrentalsummary s on h.rentalid = s.rentalid inner join
                    tblrentaloutstanding o on h.rentalid = o.rentalid
                    where h.custid=@custId and h.status='Return' and o.outstanding<>0")]
    public class RentalListViewReport : IViewModel
    {
        public Guid RentalId { get; set; }
        public string RentalNo { get; set; }
        public string CustomerName { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal OutStanding { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }
    }
}
