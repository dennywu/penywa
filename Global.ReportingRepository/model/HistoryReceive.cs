using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BonaStoco.Inf.Data.ViewModel;

namespace Global.ReportingRepository.model
{
    [NamedSqlQuery("GetHistoryReceiveByRentalId",@"SELECT rh.receiveno,rh.receivedate,ri.payamount 
                    FROM tblreceiveitem ri inner join tblreceiveheader rh on ri.receiveid = rh.receiveid 
                    where ri.rentalid = @id")]
    public class HistoryReceive : IViewModel
    {
        public string ReceiveNo { get; set; }
        public DateTime ReceiveDate { get; set; }
        public decimal PayAmount { get; set; }
    }
}
