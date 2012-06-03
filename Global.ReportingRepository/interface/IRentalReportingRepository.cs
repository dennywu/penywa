using System;
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
	}
}
