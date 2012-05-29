using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BonaStoco.Inf.DataMapper.Impl;
using BonaStoco.Inf.Reporting;

namespace Global.Repository
{
    public class AccountRepository : IAccountRepository
    {
        QueryObjectMapper qryObjectMapper;
        IReportingRepository rptRepo;
        public AccountRepository(QueryObjectMapper qryObject, IReportingRepository reportingRepository)
        {
            this.qryObjectMapper = qryObject;
            this.rptRepo = reportingRepository;
        }
        public Account FindAccountByUsername(string username)
        {
            return qryObjectMapper.Map<Account>("findByUsername", new string[1] { "username" }, new object[1] { username }).FirstOrDefault();
        }
    }
}
