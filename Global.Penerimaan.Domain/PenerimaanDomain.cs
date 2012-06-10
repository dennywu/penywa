using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BonaStoco.Inf.DataMapper.Impl;
using Global.Repository.models;

namespace Global.Penerimaan.Domain
{
    public class PenerimaanDomain
    {
        QueryObjectMapper qryObjectMapper;
        public PenerimaanDomain(QueryObjectMapper qryObject)
        {
            this.qryObjectMapper = qryObject;
        }
        public void CreateReceiveHeader(ReceiveHeader header)
        {
            string query = String.Format("INSERT INTO tblreceiveheader (receiveid,receiveno,receivedate,custid) values ('{0}','{1}','{2}','{3}')",
                header.ReceiveId, header.ReceiveNo, header.ReceiveDate, header.CustId);
            qryObjectMapper.Map<ReceiveHeader>(query);
        }
        public void CreateRentalItem(ReceiveItem item)
        {
            string query = String.Format("INSERT INTO tblreceiveitem (receiveid,rentalid,denda,payamount,total,totalafterdenda) values ('{0}','{1}','{2}','{3}','{4}','{5}')",
                item.ReceiveId, item.RentalId, item.TotalDenda, item.PayAmount, item.Total, item.TotalAfterDenda);
            qryObjectMapper.Map<ReceiveItem>(query);
        }
        public void CreateRentalSummary(ReceiveSummary summary)
        {
            string query = String.Format("INSERT INTO tblreceivesummary (receiveid,total) values ('{0}','{1}')",
                summary.ReceiveId, summary.Total);
            qryObjectMapper.Map<ReceiveSummary>(query);
        }
    }
}
