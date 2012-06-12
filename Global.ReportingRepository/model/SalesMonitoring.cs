using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BonaStoco.Inf.Data.ViewModel;

namespace Global.ReportingRepository.model
{
    [NamedSqlQuery("GetSalesMonitoring",@"SELECT rh.transactiondate as Date,rs.total as Amount from tblrentalheader rh inner join tblrentalsummary rs on rh.rentalid = rs.rentalid 
                                            where rh.transactiondate = @date
                                            group by rh.transactiondate, rs.total")]
    public class SalesMonitoring : IViewModel
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
