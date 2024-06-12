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
using System;

namespace assessment_platform_developer.Models
{
    //  Version Date         Author        Description
    //  1.0     ?            ScanSource    Original developer assessment
    //  2.0     12 Jun 2024  Douglas Hahn  My updates to the developer assessment
    //
    /// <summary>
    /// This is a lite model that does no validation checking
    /// Use this class for reading data from a source that has already been validated
    /// </summary>
    [Serializable]
    public class CustomerRead : Customer
    {
        #region Variable Definitions
        protected int customerID;
        protected string customerName;
        protected string customerAddress;
        protected string customerEmail;
        protected string customerPhone;
        protected string customerCity;
        protected string customerState;
        protected string customerZip;
        protected string customerCountry;
        protected string customerNotes;
        protected string customerContactName;
        protected string customerContactPhone;
        protected string customerContactEmail;
        protected string customerContactTitle;
        protected string customerContactNotes;
        #endregion

        #region Values
        public new int ID { get { return customerID; } }
        public new string Name { get { return customerName; } }
        public new string Address { get { return customerAddress; } }
        public new string Email { get { return customerEmail; } }
        public new string Phone { get { return customerPhone; } }
        public new string City { get { return customerCity; } }
        public new string State { get { return customerState; } }
        public new string Zip { get { return customerZip; } }
        public new string Country { get { return customerCountry; } }
        public new string Notes { get { return customerNotes; } }
        public new string ContactName { get { return customerContactName; } }
        public new string ContactPhone { get { return customerContactPhone; } }
        public new string ContactEmail { get { return customerContactEmail; } }
        public new string ContactTitle { get { return customerContactTitle; } }
        public new string ContactNotes { get { return customerContactNotes; } }
        #endregion
        /// <summary>
        /// When we need to convert from a CustomerWrite 
        /// </summary>
        /// <param name="customer">The customer data defined by a CustomerWrite class</param>
        public void CastFromCustomerWrite(CustomerWrite customer)
        {
            customerID = customer.ID;
            customerName = customer.Name;
            customerAddress = customer.Address;
            customerEmail = customer.Email;
            customerPhone = customer.Phone;
            customerCity = customer.City;
            customerState = customer.State;
            customerZip = customer.Zip;
            customerCountry = customer.Country;
            customerNotes = customer.Notes;
            customerContactName = customer.ContactName;
            customerContactPhone = customer.ContactPhone;
            customerContactEmail = customer.ContactEmail;
            customerContactTitle = customer.ContactTitle;
            customerContactNotes = customer.ContactNotes;
        }
    }
}