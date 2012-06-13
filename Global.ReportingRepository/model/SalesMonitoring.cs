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

    [NamedSqlQuery("GetSalesAmountBetweenDate", @"SELECT sum(s.total) as Total FROM tblrentalheader h inner join tblrentalsummary s on h.rentalid=s.rentalid 
                                            WHERE h.transactiondate BETWEEN @from and @to")]
    [NamedSqlQuery("GetSalesAmountByDate", @"SELECT sum(s.total) as Total FROM tblrentalheader h inner join tblrentalsummary s on h.rentalid=s.rentalid 
                                            WHERE h.transactiondate = @date")]
    public class SalesMonitoringAmount : IViewModel
    {
        public decimal Total { get; set; }
    }

    [NamedSqlQuery("GetSalesOutstandingBetweenDate",@"SELECT sum(o.outstanding) as Total FROM tblrentalheader h inner join tblrentaloutstanding o on h.rentalid=o.rentalid 
                                            WHERE h.transactiondate BETWEEN @from and @to")]
    [NamedSqlQuery("GetSalesOutstandingByDate", @"SELECT sum(o.outstanding) as Total FROM tblrentalheader h inner join tblrentaloutstanding o on h.rentalid=o.rentalid 
                                            WHERE h.transactiondate = @date")]
    public class OutstandingMonitoringAmount : IViewModel
    {
        public decimal Total { get; set; }
    }
}
