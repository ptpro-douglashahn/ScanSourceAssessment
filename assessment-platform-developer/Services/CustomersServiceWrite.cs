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
using assessment_platform_developer.Repositories;

namespace assessment_platform_developer.Services
{
    //  Version Date         Author        Description
    //  1.0     ?            ScanSource    Original developer assessment
    //  2.0     12 Jun 2024  Douglas Hahn  My updates to the developer assessment
    //
    /// <summary>
    /// Customers Service Write Interface
    /// </summary>
    public interface ICustomersServiceWrite
    {
        CustomerWrite GetCustomer(int id);
        void AddCustomer(CustomerWrite customer);
        void UpdateCustomer(CustomerWrite customer);
        void DeleteCustomer(int id);
    }
    /// <summary>
    /// Customers Service Write Class
    /// </summary>
    public class CustomersServiceWrite : ICustomersServiceWrite
    {
        private readonly ICustomersRepositoryWrite customerRepository;
        /// <summary>
        /// Fires when the class is instantiated
        /// </summary>
        /// <param name="customerRepository"></param>
        public CustomersServiceWrite(ICustomersRepositoryWrite customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        /// <summary>
        /// Get one customer
        /// </summary>
        /// <param name="id">Customer ID</param>
        /// <returns>Customer Write Class</returns>
        public CustomerWrite GetCustomer(int id)
        {
            return customerRepository.Get(id);
        }
        /// <summary>
        /// Add a customer
        /// </summary>
        /// <param name="customer">Customer Write Class</param>
        public void AddCustomer(CustomerWrite customer)
        {
            customerRepository.Add(customer);
        }
        /// <summary>
        /// Change data in a customer class
        /// </summary>
        /// <param name="customer">Customer Write Class</param>
        public void UpdateCustomer(CustomerWrite customer)
        {
            customerRepository.Update(customer);
        }
        /// <summary>
        /// Delete a specific customer
        /// </summary>
        /// <param name="id">Customer ID</param>
        public void DeleteCustomer(int id)
        {
            customerRepository.Delete(id);
        }
    }
}