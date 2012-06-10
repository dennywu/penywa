using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BonaStoco.Inf.Data.ViewModel;

namespace Global.ReportingRepository.model
{
    [NamedSqlQuery("FindReceiveListView",@"SELECT
                    h.receiveid, 
                    h.receiveno,
                    h.receivedate,
                    c.name as CustomerName,
                    s.total 
                    from tblreceiveheader h
                    inner join tblcustomer c on h.custid=c.id 
                    inner join tblreceivesummary s on h.receiveid=s.receiveid")]
    public class ReceiveListViewReport:IViewModel
    {
        public Guid ReceiveId { get; set; }
        public string ReceiveNo { get; set; }
        public DateTime ReceiveDate { get; set; }
        public string CustomerName { get; set; }
        public decimal Total { get; set; }
    }
}
