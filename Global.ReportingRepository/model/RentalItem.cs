using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BonaStoco.Inf.Data.ViewModel;

namespace Global.ReportingRepository.model
{
    [NamedSqlQuery("FindRentalItemByRentalId","select * from tblrentalitem where rentalid=@rentalId")]
    [NamedSqlQuery("FindRentalItemById", "select * from tblrentalitem where itemid=@itemidId")]
    public class RentalItem:IViewModel
    {
        public Guid ItemId { get; set; }
        public Guid RentalId { get; set; }
        public string PartName { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }
        public decimal Harga { get; set; }
        public decimal Total { get; set; }
    }
}
