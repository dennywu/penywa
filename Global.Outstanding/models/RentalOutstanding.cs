using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BonaStoco.Inf.Data.ViewModel;

namespace Global.Outstanding.models
{
    [NamedSqlQuery("GetOustanding",@"SELECT outstanding from tblrentaloutstanding where rentalid = @id")]
    public class RentalOutstanding:IViewModel
    {
        public Guid RentalId { get; set; }
        public decimal Outstanding { get; set; }
    }
}
