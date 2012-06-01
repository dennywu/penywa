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
            return qryObjectMapper.Map<Customer>().OrderBy(c => c.Name).ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return qryObjectMapper.Map<Customer>("GetCustomerById", new string[1] { "id" }, new object[1] { id }).FirstOrDefault();
        }

        public void AddCustomer(Customer cust)
        {
            string query = String.Format("INSERT INTO tblcustomer (name,alamat,kota,negara,kodepos,email,outstanding) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                cust.Name, cust.Alamat, cust.Kota, cust.Negara, cust.KodePos, cust.Email, cust.Outstanding);
            qryObjectMapper.Map<Customer>(query);
        }

        public IList<Customer> GetCustomerByName(string key)
        {
            key = "%" + key.ToLower() + "%";
            return qryObjectMapper.Map<Customer>("GetCustomerByName", new string[1] { "key" }, new object[1] { key }).OrderBy(c => c.Name).ToList();
        }

        public void UpdateCustomer(Customer cust)
        {
            string query = String.Format("UPDATE tblcustomer set name = '{0}',alamat = '{1}',kota = '{2}',negara = '{3}',kodepos = '{4}',email = '{5}' where id = '{6}'",
                cust.Name, cust.Alamat, cust.Kota, cust.Negara, cust.KodePos, cust.Email, cust.Id);
            qryObjectMapper.Map<Customer>(query);
        }
    }
}
