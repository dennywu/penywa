using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BonaStoco.Inf.Data.ViewModel;

namespace Global.ReportingRepository.model
{
    [NamedSqlQuery("FindById", "select * from tblrentalheader where rentalid=@Id")]
    public class RentalHeader : IViewModel
    {
        public Guid RentalId { get; set; }
        public string RentalNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime DueDate { get; set; }
        public int CustId { get; set; }
        public string Status { get; set; }
    }

    [NamedSqlQuery("FindSummaryByHeaderId", "select * from tblrentalsummary where rentalid=@Id")]
    public class RentalSummary : IViewModel
    {
        public Guid RentalId { get; set; }
        public decimal TotalDenda { get; set; }
        public decimal Total { get; set; }
    }
}
