using assessment_platform_developer.Models;
using assessment_platform_developer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace assessment_platform_developer.Services
{
    public interface ICustomerServiceLite
    {
        IEnumerable<CustomerLite> GetAllCustomers();
        CustomerLite GetCustomer(int id);
    }

    public class CustomerServiceLite : ICustomerServiceLite
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerServiceLite(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public IEnumerable<CustomerLite> GetAllCustomers()
        {
            return (IEnumerable<CustomerLite>)customerRepository.GetAll();
        }

        public CustomerLite GetCustomer(int id)
        {
            return customerRepository.Get(id);
        }
    }

}