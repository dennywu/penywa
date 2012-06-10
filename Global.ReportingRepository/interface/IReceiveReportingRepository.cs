using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Global.ReportingRepository.model;

namespace Global.ReportingRepository
{
	public interface IReceiveReportingRepository
	{
        IList<ReceiveListViewReport> GetListView();
        ReceiveHeaderReport GetReceiveHeaderByReceiveId(Guid receiveId);
        IList<ReceiveItemReport> GetReceiveItemById(Guid id);
        ReceiveSummaryReport GetReceiveSummaryByReceiveId(Guid receiveId);
	}
}
