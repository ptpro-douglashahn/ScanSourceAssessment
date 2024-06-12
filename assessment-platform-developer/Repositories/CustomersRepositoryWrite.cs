//  Copyright © 2024 Put the company name here
//  All rights reserved
//
//  The following code was modified by:
//  
//      Douglas Hahn
//      Platinum Pro Ltd.
//      Calgary, Alberta, Canada
//      (403) 265-4869
//      www.ptpro.com
//
using assessment_platform_developer.Models;
using System.Collections.Generic;
using System.Linq;

namespace assessment_platform_developer.Repositories
{
    //  Version Date         Author        Description
    //  1.0     ?            ScanSource    Original developer assessment
    //  2.0     12 Jun 2024  Douglas Hahn  My updates to the developer assessment
    //
    /// <summary>
    /// Interface for the Customers Repository Write
    /// </summary>
    public interface ICustomersRepositoryWrite
    {
        CustomerWrite Get(int id);
        void Add(CustomerWrite customer);
        void Update(CustomerWrite customer);
        void Delete(int id);
    }
    /// <summary>
    /// Customers Repository Write Class
    /// </summary>
    public class CustomersRepositoryWrite : ICustomersRepositoryWrite
    {
        // Assuming you have a DbContext named 'context'
        private readonly List<CustomerWrite> customers = new List<CustomerWrite>();
        /// <summary>
        /// Get one specific customer
        /// </summary>
        /// <param name="id">Customer ID</param>
        /// <returns></returns>
        public CustomerWrite Get(int id)
        {
            return customers.FirstOrDefault(c => c.ID == id);
        }
        /// <summary>
        /// Add a new customer (the customer ID must not exist in the list)
        /// </summary>
        /// <param name="customer"></param>
        public void Add(CustomerWrite customer)
        {
            customers.Add(customer);
        }
        /// <summary>
        /// Update data for an existing customer
        /// </summary>
        /// <param name="customer">CustomerWrite Class</param>
        public void Update(CustomerWrite customer)
        {
            var existingCustomer = customers.FirstOrDefault(c => c.ID == customer.ID);
            if (existingCustomer != null)
            {
                // Update properties of existingCustomer based on the properties of customer
                existingCustomer.Name = customer.Name;
                existingCustomer.Address = customer.Address;
                existingCustomer.Email = customer.Email;
                existingCustomer.Phone = customer.Phone;    
                existingCustomer.City = customer.City;  
                existingCustomer.State = customer.State;
                existingCustomer.Zip = customer.Zip;
                existingCustomer.Country = customer.Country;
                existingCustomer.Notes = customer.Notes;
                existingCustomer.ContactName = customer.ContactName;
                existingCustomer.ContactEmail = customer.ContactEmail;
                existingCustomer.ContactPhone = customer.ContactPhone;
                existingCustomer.ContactTitle = customer.ContactTitle;
                existingCustomer.ContactNotes = customer.ContactNotes;
            }
        }
        /// <summary>
        /// Delete a customer and all their data from the list
        /// If the customer ID does not exist, no customer will be deleted
        /// </summary>
        /// <param name="id">Customer ID</param>
        public void Delete(int id)
        {
            var customer = customers.FirstOrDefault(c => c.ID == id);
            if (customer != null)
            {
                customers.Remove(customer);
            }
        }
    }
}