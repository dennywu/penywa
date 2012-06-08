using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BonaStoco.Inf.DataMapper.Impl;
using Global.Repository.models;

namespace Global.Penyewaan.Domain
{
    public class PenyewaanDomain
    {
        QueryObjectMapper qryObjectMapper;
        public PenyewaanDomain(QueryObjectMapper qryObject)
        {
            this.qryObjectMapper = qryObject;
        }

        public void CreateRentalHeader(RentalHeader header)
        {
            string query = String.Format("INSERT INTO tblrentalheader (rentalid,rentalno,transactiondate,duedate,custid,status) values ('{0}','{1}','{2}','{3}','{4}','{5}')",
                header.RentalId, header.RentalNo, header.TransactionDate, header.DueDate, header.CustomerId,header.Status);
            qryObjectMapper.Map<RentalHeader>(query);
        }
        public void CreateRentalItem(RentalItem item)
        {
            string query = String.Format("INSERT INTO tblrentalitem (rentalid,itemid,description,qty,harga,total) values ('{0}','{1}','{2}','{3}','{4}','{5}')",
                item.RentalId, item.ItemId, item.Deskripsi, item.Qty, item.Harga, item.Total);
            qryObjectMapper.Map<RentalItem>(query);
        }
        public void CreateRentalSummary(RentalSummary summary)
        {
            string query = String.Format("INSERT INTO tblrentalsummary (rentalid,total) values ('{0}','{1}')",
                summary.RentalId, summary.Total);
            qryObjectMapper.Map<RentalSummary>(query);
        }
        public void UpdateRentalHeader(RentalHeader header)
        {
            string query = String.Format("UPDATE tblrentalheader set status = '{0}' where rentalid = '{1}'", header.Status, header.RentalId);
            qryObjectMapper.Map<RentalHeader>(query);
        }
    }
}
