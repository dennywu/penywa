using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BonaStoco.Inf.DataMapper.Impl;
using Global.Outstanding.models;

namespace Global.Outstanding
{
    public class RentalOutstandingHandler
    {
        QueryObjectMapper qryObjectMapper;
        public RentalOutstandingHandler(QueryObjectMapper qryObjectMapper)
        {
            this.qryObjectMapper = qryObjectMapper;
        }

        public void CreateNewOutstandingRental(Guid rentalId, decimal outstanding)
        {
            string query = String.Format("INSERT INTO tblrentaloutstanding (rentalid, outstanding) values ('{0}','{1}')",
                rentalId, outstanding);
            qryObjectMapper.Map<RentalOutstanding>(query);
        }

        public void RemoveOutstanding(Guid rentalId, decimal outstanding)
        {
            RentalOutstanding rentalOutstanding = qryObjectMapper.Map<RentalOutstanding>("GetOustanding", new string[1] { "id" }, new object[1] { rentalId }).FirstOrDefault();
            UpdateRentalOutstanding(rentalId, outstanding, rentalOutstanding);
        }
        private void UpdateRentalOutstanding(Guid rentalId, decimal outstanding, RentalOutstanding rentalOutstanding)
        {
            string query = String.Format("UPDATE tblrentaloutstanding set outstanding = '{0}' where rentalid = '{1}'", (rentalOutstanding.Outstanding - outstanding), rentalId);
            qryObjectMapper.Map<RentalOutstanding>(query);
        }
    }
}
