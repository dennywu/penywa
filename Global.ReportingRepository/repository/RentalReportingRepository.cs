using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BonaStoco.Inf.DataMapper.Impl;
using Global.ReportingRepository.model;

namespace Global.ReportingRepository
{
    public class RentalReportingRepository:IRentalReportingRepository
    {
        QueryObjectMapper qryObjectMapper;
        public RentalReportingRepository(QueryObjectMapper qryObject)
        {
            this.qryObjectMapper = qryObject;
        }

        public RentalHeader GetRentalHeaderById(Guid rentalId)
        {
            return qryObjectMapper.Map<RentalHeader>("FindById", new string[1] { "Id" }, new object[1] { rentalId }).FirstOrDefault();
        }

        public IList<RentalItem> GetRentalItemByRentalId(Guid id)
        {
            return qryObjectMapper.Map<RentalItem>("FindRentalItemByRentalId", new string[1] { "rentalId" }, new object[1] { id }).ToList();
        }

        public RentalSummary GetRentalSummaryByRentalId(Guid rentalId)
        {
            return qryObjectMapper.Map<RentalSummary>("FindSummaryByHeaderId", new string[1] { "Id" }, new object[1] { rentalId }).FirstOrDefault();
        }

        public IList<RentalListViewReport> GetListView()
        {
            return qryObjectMapper.Map<RentalListViewReport>("GetRentalListView",new string[]{},new object[]{}).ToList();
        }
        public IList<RentalListViewReport> GetReturnedListViewbyCustId(int custId)
        {
            return qryObjectMapper.Map<RentalListViewReport>("GetReturnedRentalListViewByCustomerId", new string[1] { "custId" }, new object[1] { custId }).ToList();
        }
        public RentalOutstanding GetRentalOutstandingByRentalId(Guid rentalId)
        {
            return qryObjectMapper.Map<RentalOutstanding>("FindById", new string[1] { "Id" }, new object[1] { rentalId }).FirstOrDefault();
        }
    }
}
