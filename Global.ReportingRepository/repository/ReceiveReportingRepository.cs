using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Global.ReportingRepository.model;
using BonaStoco.Inf.DataMapper.Impl;

namespace Global.ReportingRepository
{
    public class ReceiveReportingRepository:IReceiveReportingRepository
    {
        QueryObjectMapper qryObjectMapper;
        public ReceiveReportingRepository(QueryObjectMapper qryObject)
        {
            this.qryObjectMapper = qryObject;
        }
        public IList<ReceiveListViewReport> GetListView()
        {
            return qryObjectMapper.Map<ReceiveListViewReport>("FindReceiveListView", new string[] { }, new object[] { }).ToList();
        }

        public ReceiveHeaderReport GetReceiveHeaderByReceiveId(Guid receiveId)
        {
            return qryObjectMapper.Map<ReceiveHeaderReport>("FindById", new string[1] { "id" }, new object[1] { receiveId }).FirstOrDefault();
        }

        public IList<ReceiveItemReport> GetReceiveItemById(Guid id)
        {
            return qryObjectMapper.Map<ReceiveItemReport>("FindReceiveItemByReceiveId", new string[1] { "id" }, new object[1] { id }).ToList();
        }

        public ReceiveSummaryReport GetReceiveSummaryByReceiveId(Guid receiveId)
        {
            return qryObjectMapper.Map<ReceiveSummaryReport>("FindSummaryByReceiveId", new string[1] { "id" }, new object[1] { receiveId }).FirstOrDefault();
        }
    }
}
