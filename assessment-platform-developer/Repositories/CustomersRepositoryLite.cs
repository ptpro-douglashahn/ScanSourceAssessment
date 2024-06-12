using assessment_platform_developer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace assessment_platform_developer.Repositories
{
    public interface ICustomerRepositoryLite
    {
        IEnumerable<CustomerWithValidations> GetAll();
        CustomerWithValidations Get(int id);
    }

    public class CustomerRepositoryLite : ICustomerRepositoryLite
    {
        // Assuming you have a DbContext named 'context'
        private readonly List<CustomerWithValidations> customers = new List<CustomerWithValidations>();

        public IEnumerable<CustomerWithValidations> GetAll()
        {
            return customers;
        }

        public CustomerWithValidations Get(int id)
        {
            return customers.FirstOrDefault(c => c.ID == id);
        }
    }
}