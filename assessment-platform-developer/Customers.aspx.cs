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
using AjaxControlToolkit;
using assessment_platform_developer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using assessment_platform_developer.Services;
using Container = SimpleInjector.Container;
using System.Globalization;
using System.Data;
using assessment_platform_developer.Repositories;

namespace assessment_platform_developer
{
    //  Version Date         Author        Description
    //  1.0     ?            ScanSource    Original developer assessment
    //  2.0     12 Jun 2024  Douglas Hahn  My updates to the developer assessment
    //
    /// <summary>
    /// Partial class for the customers ASP.Net web page
    /// </summary>
    public partial class Customers : Page
	{
		private static List<CustomerRead> customers = new List<CustomerRead>();
        /// <summary>
        /// Page_Load - set up and populate CustomerList, Country, and Provinces/States.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				var testContainer = (Container)HttpContext.Current.Application["DIContainer"];
				var customerService = testContainer.GetInstance<ICustomersServiceRead>();

				var allCustomers = customerService.GetAllCustomers();
				ViewState["customers"] = allCustomers;
                PopulateCustomerListBox();
                PopulateCountryDropdownList();
                PopulateProvinceStateDropDownLists();
            }
            else
			{
				customers = (List<CustomerRead>)ViewState["customers"];
			}
            CustomerName.MaxLength = DataLength.Name;
            CustomerAddress.MaxLength = DataLength.Address;
            CustomerEmail.MaxLength = DataLength.Email;
            CustomerPhone.MaxLength = DataLength.Phone;
            CustomerCity.MaxLength = DataLength.City;
            // CustomerState is a drop down and doesn't need a MaxLength
            CustomerZip.MaxLength = DataLength.Zip;
            // CustomerCountry is a drop down and doesn't need a MaxLength
            CustomerNotes.MaxLength = DataLength.Notes;
            ContactName.MaxLength = DataLength.ContactName;
            ContactEmail.MaxLength = DataLength.ContactEmail;
            ContactPhone.MaxLength = DataLength.ContactPhone;
            ContactTitle.MaxLength = DataLength.ContactTitle;
            ContactNotes.MaxLength = DataLength.ContactNotes;
		}
        /// <summary>
        /// Populate the country drop down list
        /// </summary>
        private void PopulateCountryDropdownList()
        {
            CountryDropDownList.Items.Clear();
            var countryList = Enum.GetValues(typeof(Countries))
                .Cast<Countries>()
                .Select(c => new ListItem
                {
                    Text = c.GetDescription(),
                    Value = ((int)c).ToString()
                })
                .ToArray();

            CountryDropDownList.Items.AddRange(countryList);
            CountryDropDownList.SelectedValue = ((int)Countries.Canada).ToString();
        }
        /// <summary>
        /// Populate the province or state drop down list
        /// </summary>
        private void PopulateProvinceStateDropDownLists()
		{
            StateDropDownList.Items.Clear();
            StateDropDownList.Items.Add(new ListItem(""));

            if (CountryDropDownList.SelectedItem.Text == "Canada")
            {
                var provinceList = Enum.GetValues(typeof(CanadianProvinces))
                    .Cast<CanadianProvinces>()
                    .Select(p => new ListItem
                    {
                        Text = p.GetDescription(),
                        Value = ((int)p).ToString()
                    })
                    .ToArray();
                StateDropDownList.Items.AddRange(provinceList);
                CustomerStateLabel.Text = "Province/Territory";
                CustomerZipLabel.Text = "Postal Code";
            }
            else
            {
                var stateList = Enum.GetValues(typeof(USStates))
                    .Cast<USStates>()
                    .Select(p => new ListItem
                    {
                        Text = p.GetDescription(),
                        Value = ((int)p).ToString()
                    })
                    .ToArray();
                StateDropDownList.Items.AddRange(stateList);
                CustomerStateLabel.Text = "State";
                CustomerZipLabel.Text = "Zip Code";
            }
        }
        /// <summary>
        /// Populate the Customer List Box
        /// </summary>
		protected void PopulateCustomerListBox()
		{
			CustomersDDL.Items.Clear();
            var customersDict = new Dictionary<int, string>
            {
                { 0, " Add new customer" }
            };
            foreach (CustomerRead cust in customers)
            {
                customersDict.Add(cust.ID, cust.Name);
            }
            var sortedDict = from entry in customersDict orderby entry.Value ascending select entry;
            CustomersDDL.DataSource = sortedDict;
            CustomersDDL.DataTextField = "Value";
            CustomersDDL.DataValueField = "Key";
            CustomersDDL.DataBind();

			CustomersDDL.SelectedIndex = 0;
		}
        /// <summary>
        /// Retrieve the next available customer ID
        /// </summary>
        /// <returns>The next unused customer ID</returns>
        protected int NextCustomerID()
        {
            var testContainer = (Container)HttpContext.Current.Application["DIContainer"];
            var customerService = testContainer.GetInstance<ICustomersServiceRead>();
            var lastCustID = 0;
            foreach (CustomerRead cust in customers)
            {
                if (cust.ID > lastCustID)
                {
                    lastCustID = cust.ID;
                }
            }
            return lastCustID + 1;
        }
        /// <summary>
        /// Add a new customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		protected void AddButton_Click(object sender, EventArgs e)
		{
            var testContainer = (Container)HttpContext.Current.Application["DIContainer"];
            var customerServiceWrite = testContainer.GetInstance<ICustomersServiceWrite>();
            var nextCustomerID = NextCustomerID();
			var customer = new CustomerWrite();
			try
			{
                customer.ID = nextCustomerID;
				customer.Name = CustomerName.Text;
                customer.Address = CustomerAddress.Text;
				customer.City = CustomerCity.Text;
                customer.Country = CountryDropDownList.SelectedItem.Text;
                customer.State = StateDropDownList.SelectedItem.Text;
				customer.Zip = CustomerZip.Text;
				customer.Email = CustomerEmail.Text;
				customer.Phone = CustomerPhone.Text;
				customer.Notes = CustomerNotes.Text;
				customer.ContactName = ContactName.Text;
				customer.ContactPhone = CustomerPhone.Text;
				customer.ContactEmail = CustomerEmail.Text;
				customer.ContactTitle = ContactTitle.Text;
				customer.ContactNotes = ContactNotes.Text;
				
				customerServiceWrite.AddCustomer(customer);
                CustomerRead customerRead = new();
                customerRead.CastFromCustomerWrite(customer);

                customers.Add(customerRead);

                ClearScreen();
                PopulateCountryDropdownList();
                PopulateProvinceStateDropDownLists();
                PopulateCustomerListBox();
            }
            catch (Exception ex) 
			{
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
		}
        /// <summary>
        /// Update an existing customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		protected void UpdateButton_Click(object sender, EventArgs e)
		{
            var testContainer = (Container)HttpContext.Current.Application["DIContainer"];
            var customerService = testContainer.GetInstance<ICustomersServiceWrite>();
            try
            {
                var custID = int.Parse(CustomersDDL.SelectedValue.ToString());
                //var customer = customerService.GetCustomer(custID);
                CustomerRead customerRead = customers.Find(c => c.ID == custID);
                CustomerWrite customer = new();
                customer.CastFromCustomerRead(customerRead);
                try
                {
                    customer.Name = CustomerName.Text;
                    customer.Address = CustomerAddress.Text;
                    customer.City = CustomerCity.Text;
                    customer.Country = CountryDropDownList.SelectedItem.Text;
                    customer.State = StateDropDownList.SelectedItem.Text;
                    customer.Zip = CustomerZip.Text;
                    customer.Email = CustomerEmail.Text;
                    customer.Phone = CustomerPhone.Text;
                    customer.Notes = CustomerNotes.Text;
                    customer.ContactName = ContactName.Text;
                    customer.ContactPhone = CustomerPhone.Text;
                    customer.ContactEmail = CustomerEmail.Text;
                    customer.ContactTitle = ContactTitle.Text;
                    customer.ContactNotes = ContactNotes.Text;

                    customerService.UpdateCustomer(customer);
                    //
                    //  I need to populate the customer list box because the name may have changed
                    //
                    customerRead.CastFromCustomerWrite(customer);

                    ClearScreen();

                    PopulateCountryDropdownList();
                    PopulateProvinceStateDropDownLists();
                    PopulateCustomerListBox();
                }
                catch (Exception ex)
                {
                    //
                    //  I need this catch if the field values throw an error because of something 
                    //  not previously caught, for example, a semi-colon in the address
                    //
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            catch { 
                //
                //  I need this catch in case the int.Parse doesn't work (selected value is null)
                //
            }
        }
        /// <summary>
        /// Delete an existing customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		protected void DeleteButton_Click(object sender, EventArgs e)
		{
            var testContainer = (Container)HttpContext.Current.Application["DIContainer"];
            var customerService = testContainer.GetInstance<ICustomersServiceWrite>();
            var custID = int.Parse(CustomersDDL.SelectedValue.ToString());
            customerService.DeleteCustomer(custID);
            ClearScreen();
            CustomerRead customerRead = customers.Find(c => c.ID == custID);
            customers.Remove(customerRead);
            PopulateCustomerListBox();
            PopulateCountryDropdownList();
            PopulateProvinceStateDropDownLists();
        }
        /// <summary>
        /// Clear the screen
        /// </summary>
        protected void ClearScreen()
		{
            CustomerEmailRequired.Enabled = false;
            CustomerName.Text = string.Empty;
            CustomerAddress.Text = string.Empty;
            CustomerEmail.Text = string.Empty;
            CustomerPhone.Text = string.Empty;
            CustomerCity.Text = string.Empty;
            StateDropDownList.SelectedIndex = -1;
            CustomerZip.Text = string.Empty;
            CountryDropDownList.SelectedIndex = 0;
            CustomerNotes.Text = string.Empty;
            ContactName.Text = string.Empty;
            ContactPhone.Text = string.Empty;
            ContactEmail.Text = string.Empty;
			ContactTitle.Text = string.Empty;
			ContactNotes.Text = string.Empty;
            CustomerEmailRequired.Enabled = true;

            CustomerEmailRequired.Text = string.Empty;

            AddButton.Visible = true;
            UpdateButton.Visible = false;
            DeleteButton.Visible = false;
        }
        /// <summary>
        /// When the user selects a different customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CustomersDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
			if (CustomersDDL.SelectedIndex == 0)
			{
				ClearScreen();

                CustomerEmailRequired.ErrorMessage = "";

                AddButton.Visible = true;
                UpdateButton.Visible = false;
                DeleteButton.Visible = false;
            }
            else
			{
                int CustID = 0;
                int.TryParse(CustomersDDL.SelectedValue, out CustID);
                
                CustomerRead customer = customers.Find(c => c.ID == CustID);
				
                CustomerName.Text = customer.Name;
                CustomerAddress.Text = customer.Address;
                CustomerEmail.Text = customer.Email;
                CustomerPhone.Text = customer.Phone;
                CustomerCity.Text = customer.City;
                PopulateCountryDropdownList();
                CountryDropDownList.SelectedItem.Text = customer.Country;
                PopulateProvinceStateDropDownLists();
                StateDropDownList.SelectedItem.Text = customer.State;
                CustomerZip.Text = customer.Zip;
                CustomerNotes.Text = customer.Notes;
                ContactName.Text = customer.ContactName;
                ContactPhone.Text = customer.ContactPhone;
                ContactEmail.Text = customer.ContactEmail;
                ContactTitle.Text = customer.ContactTitle;
                ContactNotes.Text = customer.ContactNotes;

                AddButton.Visible = false;
				UpdateButton.Visible = true;
				DeleteButton.Visible = true;
            }
        }
        /// <summary>
        /// When the user selects a different country
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateProvinceStateDropDownLists();
        }
        /// <summary>
        /// When the user enters a customer email
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected void ValidateEmail(object sender, ServerValidateEventArgs args)
        {
            var emailToCheck = args.Value.ToString();
            CustomValidator customValidator = (CustomValidator)sender;
            string controlToValidate = customValidator.ControlToValidate;
            try
            {
                Validations.EMailAddressRFC5322(ref emailToCheck);
                args.IsValid = true;
                if (controlToValidate == "CustomerEmail") { CustomerPhone.Focus(); }
                if (controlToValidate == "ContactEmail") { ContactPhone.Focus(); }
            } catch (Exception ex)
            {
                args.IsValid = false;
                CustomValidator cv = (CustomValidator)sender;
                cv.ErrorMessage = ex.Message;
                CustomerEmail.Focus();
            }
            return;
        }
    }
}