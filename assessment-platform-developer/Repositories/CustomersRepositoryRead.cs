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
    /// Interface for RepositoryRead
    /// </summary>
    public interface ICustomersRepositoryRead
    {
        IEnumerable<CustomerRead> GetAll();
        CustomerRead Get(int id);
    }
    /// <summary>
    /// Customers Repository Read Class
    /// </summary>
    public class CustomersRepositoryRead : ICustomersRepositoryRead
    {
        private readonly List<CustomerRead> customers = new List<CustomerRead>();
        /// <summary>
        /// Get all the Customers
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CustomerRead> GetAll()
        {
            return customers;
        }
        /// <summary>
        /// Get one specific Customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CustomerRead Get(int id)
        {
            return customers.FirstOrDefault(c => c.ID == id);
        }
    }
}