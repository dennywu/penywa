using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Global.Repository;
using Spring.Context.Support;
using Global.Repository.models;

namespace Global.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        ICustomerRepository custRepo;
        public ActionResult Index()
        {
            IList<Customer> customers = CustomerRepository.GetCustomers();
            return View(customers);
        }
        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(string name, string alamat, string kota, string negara, string kodepos, string email)
        {
            try
            {
                Customer cust = new Customer()
                {
                    Name = name,
                    Alamat = alamat,
                    Kota = kota,
                    Negara = negara,
                    KodePos = kodepos,
                    Email = email,
                    Outstanding = 0
                };
                CustomerRepository.AddCustomer(cust);
                return RedirectToAction("Index", "Customer");
            }
            catch (ApplicationException ex)
            {
                return View(ex);
            }
        }

        private ICustomerRepository CustomerRepository
        {
            get
            {
                if(custRepo == null)
                    custRepo = (ICustomerRepository)ContextRegistry.GetContext().GetObject("CustomerRepository");
                return custRepo;
            }
        }
    }
}
