﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Global.ReportingRepository.model;

namespace Global.ReportingRepository
{
	public interface IRentalReportingRepository
	{
        RentalHeader GetRentalHeaderById(Guid rentalId);
        IList<RentalItem> GetRentalItemByRentalId(Guid id);
        RentalSummary GetRentalSummaryByRentalId(Guid rentalId);
        IList<RentalListViewReport> GetListView();
        IList<RentalListViewReport> GetReturnedListViewbyCustId(int custId);
        RentalOutstanding GetRentalOutstandingByRentalId(Guid rentalId);
        IList<HistoryReceive> GetHistoryReceiveByRentalId(Guid rentalId);
        SalesMonitoring GetSalesMonitoring(DateTime date);
        SalesMonitoringAmount GetSalesAmountByDate(DateTime date);
        SalesMonitoringAmount GetSalesAmountBetweenDate(DateTime from, DateTime to);
        OutstandingMonitoringAmount GetOutstandingAmountByDate(DateTime date);
        OutstandingMonitoringAmount GetOutstandingAmountBetweenDate(DateTime from, DateTime to);
	}
}
