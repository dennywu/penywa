using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BonaStoco.Inf.DataMapper.Impl;
using Global.Repository.models;

namespace Global.Repository
{
    public class RentalRepository:IRentalRepository
    {
        QueryObjectMapper qryObjectMapper;
        public RentalRepository(QueryObjectMapper qryObject)
        {
            this.qryObjectMapper = qryObject;
        }
        public RentalHeader GetRentalHeaderById(Guid id)
        {
            return qryObjectMapper.Map<RentalHeader>("GetHeaderById", new string[1] { "id" }, new object[1] { id }).FirstOrDefault();
        }
        public IList<RentalItem> GetRentalItemById(Guid id)
        {
            return qryObjectMapper.Map<RentalItem>("GetItemByRentId", new string[1] { "id" }, new object[1] { id }).ToList();
        }
        public RentalSummary GetRentalSummaryById(Guid id)
        {
            return qryObjectMapper.Map<RentalSummary>("GetSummaryById", new string[1] { "id" }, new object[1] { id }).FirstOrDefault();
        }
    }
}
