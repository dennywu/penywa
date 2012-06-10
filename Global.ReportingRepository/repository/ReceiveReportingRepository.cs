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
    }
}
