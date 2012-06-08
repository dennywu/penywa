using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BonaStoco.Inf.DataMapper.Impl;
using Global.Outstanding.models;

namespace Global.Outstanding
{
    public class CustomerOutstandingHandler
    {
        QueryObjectMapper qryObjectMapper;
        public CustomerOutstandingHandler(QueryObjectMapper qryObjectMapper)
        {
            this.qryObjectMapper = qryObjectMapper;
        }

        public void AddOutstanding(int custid, decimal outstanding)
        {
            CustomerOutstanding custOutstanding = qryObjectMapper.Map<CustomerOutstanding>("GetOustanding", new string[1] { "id" }, new object[1] { custid }).FirstOrDefault();
            string query = String.Format("UPDATE tblcustomer set outstanding = '{0}' where id = '{1}'", (custOutstanding.Outstanding + outstanding), custid);
            qryObjectMapper.Map<CustomerOutstanding>(query);
        }

        public void MinusOutstanding(int custid, decimal outstanding)
        {
            CustomerOutstanding custOutstanding = qryObjectMapper.Map<CustomerOutstanding>("GetOustanding", new string[1] { "id" }, new object[1] { custid }).FirstOrDefault();
            string query = String.Format("UPDATE tblcustomer set outstanding = '{0}' where id = '{1}'", (custOutstanding.Outstanding - outstanding), custid);
            qryObjectMapper.Map<CustomerOutstanding>(query);
        }
    }
}
