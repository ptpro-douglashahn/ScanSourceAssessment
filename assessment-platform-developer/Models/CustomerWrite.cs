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
    /// A full class that performs data validations before the data is accepted
    /// Use this class for adding, updating, and deleting
    /// </summary>
    [Serializable]
    public class CustomerWrite : Customer
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

        #region ID
        /// <summary>
        /// Customer ID
        /// </summary>
        public new int ID
        {
            get
            {
                return customerID;
            }
            set
            {
                try
                {
                    Validations.ID(ref value);
                }
                catch (Exception ex)
                {
                    throw new Exception("Validations.ID - data is not valid.\r\n" + ex.Message);
                }
                customerID = value;
            }
        }
        #endregion

        #region Name
        /// <summary>
        /// Company Name
        /// </summary>
        public new string Name
        {
            get
            {
                return customerName;
            }
            set
            {
                if (value == null || value.Trim() == "")
                {
                    throw new Exception("Null is not permitted in Name");
                }
                try
                {
                    Validations.Name(ref value);
                }
                catch (Exception ex)
                {
                    throw new Exception("Validations.Name - data is not valid.\r\n" + ex.Message);
                }
                if (value == value.ToUpper() || value == value.ToLower())
                {
                    value = Validations.ProperCase(value);
                }
                customerName = value;
            }
        }
        #endregion

        #region Address
        /// <summary>
        /// Street Address
        /// </summary>
        public new string Address
        {
            get
            {
                return customerAddress;
            }
            set
            {
                try
                {
                    Validations.Address(ref value);
                }
                catch (Exception ex)
                {
                    throw new Exception("Validations.Address - data is not valid.\r\n" + ex.Message);
                }
                if (value == null)
                {

                } else if (value == value.ToUpper() || value == value.ToLower())
                {
                    value = Validations.ProperCase(value);
                }
                customerAddress = value;
            }
        }
        #endregion

        #region Email
        /// <summary>
        /// Main Corporate Email Address
        /// </summary>
        public new string Email
        {
            get
            {
                return customerEmail;
            }
            set
            {
                if(value == null)
                {
                    throw new Exception("Email cannot be null.");
                }
                value = value.Trim();
                if (value == "")
                {
                    throw new Exception("Email cannot be blank.");
                }
                try
                {
                    Validations.Email(ref value);
                }
                catch (Exception ex)
                {
                    throw new Exception("Validations.Email - data is not valid.\r\n" + ex.Message);
                }
                customerEmail = value;
            }
        }
        #endregion

        #region Phone
        /// <summary>
        /// Main Company Phone Number
        /// </summary>
        public new string Phone
        {
            get
            {
                return customerPhone;
            }
            set
            {
                try
                {
                    Validations.Phone(ref value);
                }
                catch (Exception ex)
                {
                    throw new Exception("Validations.Phone - data is not valid.\r\n" + ex.Message);
                }
                customerPhone = value;
            }
        }
        #endregion

        #region City
        /// <summary>
        /// Company Mailing City
        /// </summary>
        public new string City
        {
            get
            {
                return customerCity;
            }
            set
            {
                if (value == null || value.Trim() == "")
                {
                    throw new Exception("Null is not permitted in City");
                }
                try
                {
                    Validations.City(ref value);
                }
                catch (Exception ex)
                {
                    throw new Exception("Validations.City - data is not valid.\r\n" + ex.Message);
                }
                if (value == value.ToUpper() || value == value.ToLower())
                {
                    value = Validations.ProperCase(value);
                }
                customerCity = value;
            }
        }
        #endregion

        #region State
        /// <summary>
        /// Company Mailing State
        /// </summary>
        public new string State
        {
            get
            {
                return customerState;
            }
            set
            {
                if (value == null || value.Trim() == "")
                {
                    throw new Exception("Null is not permitted in State");
                }
                if (customerCountry == null)
                {
                    throw new Exception("You must set the Country before you set the State/Province.");
                }
                if (value == value.ToUpper() || value == value.ToLower())
                {
                    value = Validations.ProperCase(value);
                }
                try
                {
                    Validations.State(ref value, customerCountry);
                }
                catch (Exception ex)
                {
                    throw new Exception("Validations.State - data is not valid.\r\n" + ex.Message);
                }
                customerState = value;
            }
        }
        #endregion

        #region Zip
        /// <summary>
        /// Company Mailing US Zip Code or Canadian Postal Code
        /// </summary>
        public new string Zip
        {
            get
            {
                return customerZip;
            }
            set
            {
                if (value == null || value.Trim() == "")
                {
                    throw new Exception("Null is not permitted in Zip");
                }
                if (customerCountry == null)
                {
                    throw new Exception("You must set the country before you set the Zip.");
                }
                try
                {
                    Validations.Zip(ref value, customerCountry);
                }
                catch (Exception ex)
                {
                    throw new Exception("Validations.Zip - data is not valid.\r\n" + ex.Message);
                }
                customerZip = value.ToUpper();
            }
        }
        #endregion

        #region Country
        /// <summary>
        /// Company Mailing Country
        /// </summary>
        public new string Country
        {
            get
            {
                return customerCountry;
            }
            set
            {
                if (value == null || value.Trim() == "")
                {
                    throw new Exception("Null is not permitted in Country");
                }
                if (value == value.ToUpper() || value == value.ToLower())
                {
                    value = Validations.ProperCase(value);
                }
                try
                {
                    Validations.Country(ref value);
                }
                catch (Exception ex)
                {
                    throw new Exception("Validations.Country - data is not valid.\r\n" + ex.Message);
                }
                customerCountry = value;
            }
        }
        #endregion

        #region Notes
        /// <summary>
        /// Company Notes
        /// </summary>
        public new string Notes
        {
            get
            {
                return customerNotes;
            }
            set
            {
                if(value == null)
                {
                    
                } else
                {
                    value = value.Trim();
                    if (value == "")
                    {
                        value = null;
                    } else
                    {
                        try
                        {
                            Validations.Notes(ref value);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Validations.Notes - data is not valid.\r\n" + ex.Message);
                        }
                    }
                }
                customerNotes = value;
            }
        }
        #endregion

        #region ContactName
        /// <summary>
        /// Contact Name of the person you deal with at the Company
        /// </summary>
        public new string ContactName
        {
            get
            {
                return customerContactName;
            }
            set
            {
                if (value == null)
                {

                } else
                {
                    value = value.Trim();
                    if (value == "")
                    {
                        value = null;
                    }
                    else
                    {
                        try
                        {
                            Validations.ContactName(ref value);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Validations.ContactName - data is not valid.\r\n" + ex.Message);
                        }
                        if (value == value.ToUpper() || value == value.ToLower())
                        {
                            value = Validations.ProperCase(value);
                        }
                    }
                }
                customerContactName = value;
            }
        }
        #endregion

        #region ContactPhone
        /// <summary>
        /// The Contact's Phone Number
        /// </summary>
        public new string ContactPhone
        {
            get
            {
                return customerContactPhone;
            }
            set
            {
                if (value == null)
                {

                } 
                else
                {
                    value = value.Trim();
                    if (value == "")
                    {
                        value = null;
                    } 
                    else
                    {
                        try
                        {
                            Validations.ContactPhone(ref value);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Validations.ContactPhone - data is not valid.\r\n" + ex.Message);
                        }
                    }
                }
                customerContactPhone = value;
            }
        }
        #endregion

        #region ContactEmail
        /// <summary>
        /// The Contact's Email Address
        /// </summary>
        public new string ContactEmail
        {
            get
            {
                return customerContactEmail;
            }
            set
            {
                if (value == null)
                {
                    
                }
                else
                {
                    value = value.Trim();
                    if (value == "")
                    {
                        value = null;
                    }
                    else
                    {
                        try
                        {
                            Validations.ContactEmail(ref value);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Validations.ContactEmail - data is not valid.\r\n" + ex.Message);
                        }
                    }
                }
                customerContactEmail = value;
            }
        }
        #endregion

        #region ContactTitle
        /// <summary>
        /// The Contact's Title at the Company
        /// </summary>
        public new string ContactTitle
        {
            get
            {
                return customerContactTitle;
            }
            set
            {
                if (value == null)
                {

                } else
                {
                    value = value.Trim();
                    if (value == "")
                    {
                        value = null;
                    } else
                    {
                        try
                        {
                            Validations.ContactTitle(ref value);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Validations.ContactTitle - data is not valid.\r\n" + ex.Message);
                        }
                        if (value == value.ToUpper() || value == value.ToLower())
                        {
                            value = Validations.ProperCase(value);
                        }
                    }
                }
                customerContactTitle = value;
            }
        }
        #endregion

        #region ContactNotes
        /// <summary>
        /// Any relevant Notes about the Contact
        /// </summary>
        public new string ContactNotes
        {
            get
            {
                return customerContactNotes;
            }
            set
            {
                if (value == null)
                {

                } else
                {
                    value = value.Trim();
                    if (value == "")
                    {
                        value = null;
                    }else
                    {
                        try
                        {
                            Validations.ContactNotes(ref value);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Validations.ContactNotes - data is not valid.\r\n" + ex.Message);
                        }
                    }
                }
                customerContactNotes = value;
            }
        }
        #endregion
        /// <summary>
        /// When we need to convert from a CustomerRead 
        /// </summary>
        /// <param name="customer"></param>
        public void CastFromCustomerRead(CustomerRead customer)
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
            customerContactEmail = customer.ContactEmail;
            customerContactPhone = customer.ContactPhone;
            customerContactTitle = customer.ContactTitle;
            customerContactNotes = customer.Notes;
        }
    }
}