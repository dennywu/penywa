using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BonaStoco.Inf.Data.ViewModel;

namespace Global.Outstanding.models
{
    [NamedSqlQuery("GetOustanding", @"SELECT id,outstanding from tblcustomer where id = @id")]
    public class CustomerOutstanding : IViewModel
    {
        public int Id { get; set; }
        public decimal Outstanding { get; set; }
    }
}
