using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BonaStoco.Inf.DataMapper.Impl;
using BonaStoco.Inf.Reporting;
using Global.Repository.models;

namespace Global.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        QueryObjectMapper qryObjectMapper;
        public CustomerRepository(QueryObjectMapper qryObject)
        {
            this.qryObjectMapper = qryObject;
        }

        public IList<Customer> GetCustomers()
        {
            return qryObjectMapper.Map<Customer>().ToList();
        }

        public void AddCustomer(Customer cust)
        {
        }
    }
}
