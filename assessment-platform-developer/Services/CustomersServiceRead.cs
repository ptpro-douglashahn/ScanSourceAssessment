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
using System.Collections.Generic;

namespace assessment_platform_developer.Services
{
    //  Version Date         Author        Description
    //  1.0     ?            ScanSource    Original developer assessment
    //  2.0     12 Jun 2024  Douglas Hahn  My updates to the developer assessment
    //
    /// <summary>
    /// Customers Service Read Interface
    /// </summary>
    public interface ICustomersServiceRead
    {
        IEnumerable<CustomerRead> GetAllCustomers();
        CustomerRead GetCustomer(int id);
    }
    /// <summary>
    /// Customers Service Read Class
    /// </summary>
    public class CustomersServiceRead : ICustomersServiceRead
    {
        private readonly ICustomersRepositoryRead customerRepository;
        /// <summary>
        /// When the class is instantiated
        /// </summary>
        /// <param name="customerRepository"></param>
        public CustomersServiceRead(ICustomersRepositoryRead customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        /// <summary>
        /// Get all the customers
        /// </summary>
        /// <returns>List of Customer Reads</returns>
        public IEnumerable<CustomerRead> GetAllCustomers()
        {
            return customerRepository.GetAll();
        }
        /// <summary>
        /// Get one specific customer
        /// </summary>
        /// <param name="id">Customer ID</param>
        /// <returns>Customer Read Class</returns>
        public CustomerRead GetCustomer(int id)
        {
            return customerRepository.Get(id);
        }
    }
}