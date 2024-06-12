using assessment_platform_developer.Models;
using assessment_platform_developer.Repositories;
using assessment_platform_developer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace assessment_platform_developer
{
    public interface ICustomerServiceWithValidations
    {
        IEnumerable<CustomerWithValidations> GetAllCustomers();
        CustomerWithValidations GetCustomer(int id);
        void AddCustomer(CustomerWithValidations custWV);
        void UpdateCustomer(CustomerWithValidations custWV);
        void DeleteCustomer(int id);
    }

    public class CustomerServiceWithValidations : ICustomerServiceWithValidations
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerServiceWithValidations(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public IEnumerable<CustomerWithValidations> GetAllCustomers()
        {
            List<CustomerWithValidations> custWVs = new List<CustomerWithValidations>();
            foreach (Customer customer in customerRepository.GetAll())
            {
                custWVs.Add(CastCustomerToCustomerWithValidations(customer));
            }
            return custWVs;
        }
        public CustomerWithValidations GetCustomer(int id)
        {
            return CastCustomerToCustomerWithValidations(customerRepository.Get(id));
        }
        public void AddCustomer(CustomerWithValidations custWV)
        {
            customerRepository.Add(CastCustomerWithValidationsToCustomer(custWV));
        }
        public void UpdateCustomer(CustomerWithValidations custWV)
        {
            customerRepository.Update(CastCustomerWithValidationsToCustomer(custWV));
        }
        public void DeleteCustomer(int id)
        {
            customerRepository.Delete(id);
        }
        public CustomerWithValidations CastCustomerToCustomerWithValidations(Customer customer)
        {
            //
            //  You might see this as goofy...it shows how little I know about Entity Framework
            //  I'd love to learn the proper way to do it.
            //  In this instance, I would ask someone how to do it better, but this is a test
            //  and it is important to me that you understand my abilities and I know when I need to ask for help.
            //
            CustomerWithValidations custWV = new CustomerWithValidations();

            custWV.ID = customer.ID;
            custWV.Name = customer.Name;
            custWV.Address = customer.Address;
            custWV.Email = customer.Email;
            custWV.Phone = customer.Phone;
            custWV.City = customer.City;
            custWV.State = customer.State;
            custWV.Zip = customer.Zip;
            custWV.Country = customer.Country;
            custWV.Notes = customer.Notes;
            custWV.ContactName = customer.ContactName;
            custWV.ContactPhone = customer.ContactPhone;
            custWV.ContactTitle = customer.ContactTitle;
            custWV.ContactNotes = customer.ContactNotes;

            return custWV;
        }

        public Customer CastCustomerWithValidationsToCustomer(CustomerWithValidations customerWithValidations)
        {
            Customer customer = new Customer();

            customer.ID = customerWithValidations.ID;
            customer.Name = customerWithValidations.Name;
            customer.Address = customerWithValidations.Address;
            customer.Email = customerWithValidations.Email;
            customer.Phone = customerWithValidations.Phone;
            customer.City = customerWithValidations.City;
            customer.State = customerWithValidations.State;
            customer.Zip = customerWithValidations.Zip;
            customer.Country = customerWithValidations.Country;
            customer.Notes = customerWithValidations.Notes;
            customer.ContactName = customerWithValidations.ContactName;
            customer.ContactPhone = customerWithValidations.ContactPhone;
            customer.ContactTitle = customerWithValidations.ContactTitle;
            customer.ContactNotes = customerWithValidations.ContactNotes;

            return customer;
        }


    }
}