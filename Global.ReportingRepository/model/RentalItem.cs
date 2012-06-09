using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BonaStoco.Inf.Data.ViewModel;

namespace Global.ReportingRepository.model
{
    [NamedSqlQuery("FindRentalItemByRentalId","select ri.*,i.name as partname from tblrentalitem ri inner join tblitem i on ri.itemid=i.itemid where ri.rentalid=@rentalId")]
    public class RentalItem:IViewModel
    {
        public long Id { get; set; }
        public Guid RentalId { get; set; }
        public int ItemId { get; set; }
        public string Deskripsi { get; set; }
        public int Qty { get; set; }
        public decimal Harga { get; set; }
        public decimal Denda { get; set; }
        public decimal Total { get; set; }
        public string PartName { get; set; }
    }
}
