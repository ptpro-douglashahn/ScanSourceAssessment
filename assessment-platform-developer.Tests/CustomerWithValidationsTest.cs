//  Copyright © 2024 Platinum Pro Ltd.
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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace assessment_platform_developer.Tests
{

	[TestClass]
	public class CustomerWithValidationsTest
	{
        #region ID
        [TestMethod]
        public void IDTestValid()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            int expected = 1;
            customer.ID = expected;
            int actual = customer.ID;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IDTestZero()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            int invalidID = 0;
            bool failed = false;
            try
            {
                customer.ID = invalidID;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.ID - data is not valid.\r\nID cannot be less than zero.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("IDTestZero failed to throw an exception.");
            }
        }
        #endregion

        #region Name
        [TestMethod]
		public void NameTestValid()
		{
			CustomerWithValidations customer = new CustomerWithValidations();
			string expected = "Platinum Pro Ltd.";
			customer.Name = expected;
			string actual = customer.Name;
			Assert.AreEqual(expected, actual);
		}
		[TestMethod]
		public void NameTestMaxLength() 
		{ 
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = 'A' + new string('a',DataLength.Name - 1);
            customer.Name = expected;
            string actual = customer.Name;
            Assert.AreEqual(expected, actual);
        }
		[TestMethod] public void NameTestMinLength() 
		{
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = "A";
            customer.Name = expected;
            string actual = customer.Name;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void NameTestUpperCase()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = "Platinum Pro Ltd.";
            customer.Name = expected.ToUpper();
            string actual = customer.Name;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void NameTestLowerCase()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = "Platinum Pro Ltd.";
            customer.Name = expected.ToLower();
            string actual = customer.Name;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
		public void NameTestTooLong() 
		{
			CustomerWithValidations customer = new CustomerWithValidations();
			string invalidName = 'A' + new string('a',DataLength.Name);
			bool failed = false;
            try
			{
				customer.Name = invalidName;
				failed = true;
			} catch (Exception ex) 
			{
				string expectedError = "Validations.Name - data is not valid.\r\nName cannot be longer than " + DataLength.Name.ToString();
				string actualError = ex.Message;
				Assert.AreEqual (expectedError, actualError);
			}
			if (failed)
			{
				Assert.Fail("NameTestTooLong failed to throw an exception.");
			}
		}
		[TestMethod]
		public void NameTestNull()
		{
            CustomerWithValidations customer = new CustomerWithValidations();
			string invalidName = null;
            bool failed = false;
            try
            {
                customer.Name = invalidName;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Null is not permitted in Name";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("NameTestNull failed to throw an exception.");
            }
        }
        [TestMethod]
        public void NameTestEmptyString()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidName = "";
            bool failed = false;
            try
            {
                customer.Name = invalidName;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Null is not permitted in Name";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("NameTestEmptyString failed to throw an exception.");
            }
        }
        [TestMethod]
        public void NameTestSpace()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidName = " ";
            bool failed = false;
            try
            {
                customer.Name = invalidName;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Null is not permitted in Name";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("NameTestSpace failed to throw an exception.");
            }
        }
        [TestMethod]
        public void NameTestInvalidCharacters()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidName = "Max Productions;)";
            bool failed = false;
            try
            {
                customer.Name = invalidName;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.Name - data is not valid.\r\nThe Name contains the invalid characters ;";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("NameTestInvalidCharacters failed to throw an exception.");
            }
        }
        #endregion

        #region Address
        [TestMethod]
        public void AddressValid()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = new string('0',DataLength.Address);
            customer.Address = expected;
            string actual = customer.Address;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddressMaxLength()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = new string('0',DataLength.Address);
            customer.Address = expected;
            string actual = customer.Address;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddressMinLength()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = null;
            customer.Address = expected;
            string actual = customer.Address;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddressTestUpperCase()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = "123 Valhalla Drive N.W.";
            customer.Address = expected.ToUpper();
            string actual = customer.Address;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddressTestLowerCase()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = "123 Valhalla Drive N.W.";
            customer.Address = expected.ToLower();
            string actual = customer.Address;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddressTestTooLong()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidAddress = 'A' + new string('a', DataLength.Address);
            bool failed = false;
            try
            {
                customer.Address = invalidAddress;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.Address - data is not valid.\r\nAddress cannot be longer than " + DataLength.Address.ToString();
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("AddressTestTooLong failed to throw an exception.");
            }
        }
        [TestMethod]
        public void AddressTestInvalidCharacters()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidAddress = "Max Productions;)";
            bool failed = false;
            try
            {
                customer.Address = invalidAddress;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.Address - data is not valid.\r\nThe Address contains the invalid characters ;";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("AddressTestInvalidCharacters failed to throw an exception.");
            }
        }
        #endregion

        #region Email
        [TestMethod]
        public void EmailValid()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = "douglas.hahn@ptpro.com";
            customer.Email = expected;
            string actual = customer.Email;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EmailMaxLocal()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = new string('a',64) + "@ptpro.com";
            customer.Email = expected;
            string actual = customer.Email;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EmailTestNull()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidEmail = null;
            bool failed = false;
            try
            {
                customer.Email = invalidEmail;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Email cannot be null.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("EmailTestNull failed to throw an exception.");
            }
        }
        [TestMethod]
        public void EmailTestEmptyString()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidEmail = "";
            bool failed = false;
            try
            {
                customer.Email = invalidEmail;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Email cannot be blank.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("EmailTestEmptyString failed to throw an exception.");
            }
        }
        [TestMethod]
        public void EmailTestSpace()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidEmail = " ";
            bool failed = false;
            try
            {
                customer.Email = invalidEmail;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Email cannot be blank.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("EmailTestSpace failed to throw an exception.");
            }
        }
        [TestMethod]
        public void EmailTestNoAtSign()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidEmail = "SendItToMyEmailAddressPtpro.com";
            bool failed = false;
            try
            {
                customer.Email = invalidEmail;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.Email - data is not valid.\r\nEmail address must contain exactly one @ sign.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("EmailTestNoAtSign failed to throw an exception.");
            }
        }
        [TestMethod]
        public void EmailTestTwoAtSign()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidEmail = "SendItToMy@EmailAddress@Ptpro.com";
            bool failed = false;
            try
            {
                customer.Email = invalidEmail;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.Email - data is not valid.\r\nEmail address must contain exactly one @ sign.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("EmailTestTwoAtSign failed to throw an exception.");
            }
        }
        [TestMethod]
        public void EmailTestNoPersonName()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidEmail = "@Ptpro.com";
            bool failed = false;
            try
            {
                customer.Email = invalidEmail;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.Email - data is not valid.\r\nPerson name part of email address is blank.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("EmailTestNoPersonName failed to throw an exception.");
            }
        }
        [TestMethod]
        public void EmailTestPersonNameWithSpace()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidEmail = "Douglas Hahn@Ptpro.com";
            bool failed = false;
            try
            {
                customer.Email = invalidEmail;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.Email - data is not valid.\r\nThe person name part of the email address contains the invalid characters  ";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("EmailTestPersonNameWithSpace failed to throw an exception.");
            }
        }
        [TestMethod]
        public void EmailTestPersonNameStartsWithPeriod()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidEmail = ".Douglas.Hahn@Ptpro.com";
            bool failed = false;
            try
            {
                customer.Email = invalidEmail;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.Email - data is not valid.\r\nThe local part of the email address cannot start or end with a period.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("EmailTestPersonNameStartsWithPeriod failed to throw an exception.");
            }
        }
        [TestMethod]
        public void EmailTestPersonNameEndsWithPeriod()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidEmail = "Douglas.Hahn.@Ptpro.com";
            bool failed = false;
            try
            {
                customer.Email = invalidEmail;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.Email - data is not valid.\r\nThe local part of the email address cannot start or end with a period.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("EmailTestPersonNameEndsWithPeriod failed to throw an exception.");
            }
        }
        [TestMethod]
        public void EmailTestLocalTooLong()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidEmail = new string('a',65) + "@Ptpro.com";
            bool failed = false;
            try
            {
                customer.Email = invalidEmail;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.Email - data is not valid.\r\nThe person name part of the email address cannot be greater than 64 characters.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("EmailTestLocalTooLong failed to throw an exception.");
            }
        }
        [TestMethod]
        public void EmailTestNoDomain()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidEmail = "douglas.hahn@";
            bool failed = false;
            try
            {
                customer.Email = invalidEmail;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.Email - data is not valid.\r\nDomain part EMail address is blank.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("EmailTestNoDomain failed to throw an exception.");
            }
        }
        [TestMethod]
        public void EmailTestTwoPeriodsTogether()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidEmail = "douglas.hahn@ptpro..com";
            bool failed = false;
            try
            {
                customer.Email = invalidEmail;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.Email - data is not valid.\r\nThe domain appears to have two periods together.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("EmailTestTwoPeriodsTogether failed to throw an exception.");
            }
        }
        [TestMethod]
        public void EmailTestDomainPartTooLong()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidEmail = "douglas.hahn@" + new string('a',64) + ".com";
            bool failed = false;
            try
            {
                customer.Email = invalidEmail;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.Email - data is not valid.\r\nEach part of the domain (separated by periods) cannot be greater than 63 characters in length.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("EmailTestDomainPartTooLong failed to throw an exception.");
            }
        }
        [TestMethod]
        public void EmailTestDomainInvalidCharacters()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidEmail = "douglas.hahn@ptpro;com";
            bool failed = false;
            try
            {
                customer.Email = invalidEmail;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.Email - data is not valid.\r\nThe domain contains the invalid characters ;";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("EmailTestDomainInvalidCharacters failed to throw an exception.");
            }
        }
        [TestMethod]
        public void EmailTestDomainStartsWithDash()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidEmail = "douglas.hahn@-ptpro.com";
            bool failed = false;
            try
            {
                customer.Email = invalidEmail;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.Email - data is not valid.\r\nThe domain cannot start or end with a dash.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("EmailTestDomainStartsWithDash failed to throw an exception.");
            }
        }
        [TestMethod]
        public void EmailTestDomainEndsWithDash()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidEmail = "douglas.hahn@ptpro-.com";
            bool failed = false;
            try
            {
                customer.Email = invalidEmail;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.Email - data is not valid.\r\nThe domain cannot start or end with a dash.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("EmailTestDomainEndsWithDash failed to throw an exception.");
            }
        }
        #endregion

        #region Phone
        [TestMethod]
        public void PhoneTestValidFormatted()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = "(403) 265-4869";
            customer.Phone = expected;
            string actual = customer.Phone;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void PhoneTestValidUnformatted()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = "(403) 265-4869";
            customer.Phone = "4032654869";
            string actual = customer.Phone;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void PhoneTestNull()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = null;
            customer.Phone = expected;
            string actual = customer.Phone;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void PhoneTestEmptyString()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = null;
            customer.Phone = "";
            string actual = customer.Phone;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void PhoneTestSpace()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = null;
            customer.Phone = " ";
            string actual = customer.Phone;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void PhoneTestTooShort()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidPhone = "123456789";
            bool failed = false;
            try
            {
                customer.Phone = invalidPhone;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.Phone - data is not valid.\r\nYour phone number must have exactly 10 digits.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("PhoneTestTooShort failed to throw an exception.");
            }
        }
        [TestMethod]
        public void PhoneTestTooLong()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidPhone = "12345678901";
            bool failed = false;
            try
            {
                customer.Phone = invalidPhone;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.Phone - data is not valid.\r\nYour phone number must have exactly 10 digits.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("PhoneTestTooLong failed to throw an exception.");
            }
        }
        #endregion

        #region City
        [TestMethod]
        public void CityValid()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = "Calgary";
            customer.Name = expected;
            string actual = customer.Name;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CityMaxLength()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = "A" + new string('a', DataLength.City - 1);
            customer.City = expected;
            string actual = customer.City;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CityMinLength()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = "A";
            customer.City = expected;
            string actual = customer.City;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CityTestUpperCase()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = "Calgary";
            customer.City = expected.ToUpper();
            string actual = customer.City;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CityTestLowerCase()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = "Edmonton";
            customer.City = expected.ToLower();
            string actual = customer.City;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CityTestTooLong()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidCity = 'A' + new string('a', DataLength.City);
            bool failed = false;
            try
            {
                customer.City = invalidCity;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.City - data is not valid.\r\nCity cannot be longer than " + DataLength.City.ToString();
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("CityTestTooLong failed to throw an exception.");
            }
        }
        [TestMethod]
        public void CityTestNull()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidCity = null;
            bool failed = false;
            try
            {
                customer.City = invalidCity;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Null is not permitted in City";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("CityTestNull failed to throw an exception.");
            }
        }
        [TestMethod]
        public void CityTestInvalidCharacters()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidCity = "Red Deer;";
            bool failed = false;
            try
            {
                customer.City = invalidCity;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.City - data is not valid.\r\nThe City contains the invalid characters ;";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("CityTestInvalidCharacters failed to throw an exception.");
            }
        }
        #endregion

        #region State
        [TestMethod]
        public void StateValid()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            customer.Country = "Canada";
            string expected = "Alberta";
            customer.Name = expected;
            string actual = customer.Name;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void StateMaxCanada()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            customer.Country = "Canada";
            string expected = "NewfoundlandAndLabrador";
            customer.State = "Newfoundland And Labrador";
            string actual = customer.State;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void StateMaxUnitedStates()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            customer.Country = "United States";
            string expected = "SouthCarolina";
            customer.State = "South Carolina";
            string actual = customer.State;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void StateProperCase()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            customer.Country = "United States";
            string expected = "SouthCarolina";
            customer.State = "South Carolina".ToUpper();
            string actual = customer.State;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void StateTestNull()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidState = null;
            bool failed = false;
            try
            {
                customer.State = invalidState;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Null is not permitted in State";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("StateTestNull failed to throw an exception.");
            }
        }
        [TestMethod]
        public void StateTestUSInvalid()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            customer.Country = "United States";
            string invalidState = "Wrexham";
            bool failed = false;
            try
            {
                customer.State = invalidState;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.State - data is not valid.\r\nUS State Wrexham does not exist.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("StateTestInvalid failed to throw an exception.");
            }
        }
        [TestMethod]
        public void StateTestCAInvalid()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            customer.Country = "Canada";
            string invalidState = "Upper Canada";
            bool failed = false;
            try
            {
                customer.State = invalidState;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.State - data is not valid.\r\nCanadian Province UpperCanada does not exist.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("StateTestInvalid failed to throw an exception.");
            }
        }
        [TestMethod]
        public void StateTestNoCountry()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidState = "Alberta";
            bool failed = false;
            try
            {
                customer.State = invalidState;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "You must set the Country before you set the State/Province.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("StateTestNoCountry failed to throw an exception.");
            }
        }
        #endregion

        #region Zip
        [TestMethod]
        public void ZipValidCAWithSpace()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            customer.Country = "Canada";
            string expected = "A1B 2C3";
            customer.Zip = expected;
            string actual = customer.Zip;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ZipValidCANoSpace()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            customer.Country = "Canada";
            string expected = "A1B 2C3";
            customer.Zip = "A1B2C3";
            string actual = customer.Zip;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ZipValidUS5()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            customer.Country = "United States";
            string expected = "12345";
            customer.Zip = expected;
            string actual = customer.Zip;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ZipValidUSWithDash()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            customer.Country = "United States";
            string expected = "12345-6789";
            customer.Zip = expected;
            string actual = customer.Zip;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ZipValidUSNoDash()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            customer.Country = "United States";
            string expected = "12345-6789";
            customer.Zip = "123456789";
            string actual = customer.Zip;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ZipTestNull()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            customer.Country = "Canada";
            string invalidZip = null;
            bool failed = false;
            try
            {
                customer.Zip = invalidZip;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Null is not permitted in Zip";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("ZipTestNull failed to throw an exception.");
            }
        }
        [TestMethod]
        public void ZipTestNoCountry()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidZip = "12345";
            bool failed = false;
            try
            {
                customer.Zip = invalidZip;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "You must set the country before you set the Zip.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("ZipTestNoCountry failed to throw an exception.");
            }
        }
        [TestMethod]
        public void ZipTestCAInvalid()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            customer.Country = "Canada";
            string invalidZip = "AOB 1C2";
            bool failed = false;
            try
            {
                customer.Zip = invalidZip;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.Zip - data is not valid.\r\nPostal Code is not valid.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("ZipTestNoCountry failed to throw an exception.");
            }
        }
        [TestMethod]
        public void ZipTestUSInvalid()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            customer.Country = "United States";
            string invalidZip = "123456";
            bool failed = false;
            try
            {
                customer.Zip = invalidZip;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.Zip - data is not valid.\r\nZip code is not valid.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("ZipTestNoCountry failed to throw an exception.");
            }
        }
        #endregion

        #region Country
        [TestMethod]
        public void CountryValidCA()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = "Canada";
            customer.Country = expected;
            string actual = customer.Country;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CountryValidUSWithSpace()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = "UnitedStates";
            customer.Country = "United States";
            string actual = customer.Country;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CountryValidUSNoSpace()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = "UnitedStates";
            customer.Country = expected;
            string actual = customer.Country;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CountryValidProperCase()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = "UnitedStates";
            customer.Country = "UNITED STATES";
            string actual = customer.Country;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CountryTestNull()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            customer.Country = "Canada";
            string invalidCountry = null;
            bool failed = false;
            try
            {
                customer.Country = invalidCountry;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Null is not permitted in Country";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("CountryTestNull failed to throw an exception.");
            }
        }
        [TestMethod]
        public void CountryInvalid()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidCountry = "United States of America";
            bool failed = false;
            try
            {
                customer.Country = invalidCountry;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.Country - data is not valid.\r\nOnly Canada and United States are valid countries.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("CountryInvalid failed to throw an exception.");
            }
        }
        #endregion

        #region Notes
        [TestMethod]
        public void NotesValid()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = new string('0', DataLength.Notes);
            customer.Notes = expected;
            string actual = customer.Notes;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void NotesNull()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = null;
            customer.Notes = expected;
            string actual = customer.Notes;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void NotesEmptyString()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = null;
            customer.Notes = string.Empty;
            string actual = customer.Notes;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void NotesSpace()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = null;
            customer.Notes = " ";
            string actual = customer.Notes;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void NotesMaxLength()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = new string('0', DataLength.Notes);
            customer.Notes = expected;
            string actual = customer.Notes;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void NotesMinLength()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = null;
            customer.Notes = expected;
            string actual = customer.Notes;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void NotesTestTooLong()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidNotes = 'A' + new string('a', DataLength.Notes);
            bool failed = false;
            try
            {
                customer.Notes = invalidNotes;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.Notes - data is not valid.\r\nNotes cannot be longer than " + DataLength.Notes.ToString();
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("NotesTestTooLong failed to throw an exception.");
            }
        }
        [TestMethod]
        public void NotesTestInvalidCharacters()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidNotes = "Max Productions;)";
            bool failed = false;
            try
            {
                customer.Notes = invalidNotes;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.Notes - data is not valid.\r\nThe Notes contains the invalid characters ;";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("NotesTestInvalidCharacters failed to throw an exception.");
            }
        }
        #endregion

        #region ContactName
        [TestMethod]
        public void ContactNameTestValid()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = "Douglas Hahn";
            customer.ContactName = expected;
            string actual = customer.ContactName;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ContactNameTestWithSpace()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = "Douglas Hahn";
            customer.ContactName = " Douglas Hahn ";
            string actual = customer.ContactName;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ContactNameTestNull()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = null;
            customer.ContactName = expected;
            string actual = customer.ContactName;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ContactNameTestEmptyString()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = null;
            customer.ContactName = string.Empty;
            string actual = customer.ContactName;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ContactNameTestSpace()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = null;
            customer.ContactName = " ";
            string actual = customer.ContactName;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ContactNameTestMaxLength()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = 'A' + new string('a', DataLength.ContactName - 1);
            customer.ContactName = expected;
            string actual = customer.ContactName;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ContactNameTestMinLength()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = "A";
            customer.ContactName = expected;
            string actual = customer.ContactName;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ContactNameTestUpperCase()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = "Douglas Hahn";
            customer.ContactName = expected.ToUpper();
            string actual = customer.ContactName;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ContactNameTestLowerCase()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = "Douglas Hahn";
            customer.ContactName = expected.ToLower();
            string actual = customer.ContactName;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ContactNameTestTooLong()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidContactName = 'A' + new string('a', DataLength.ContactName);
            bool failed = false;
            try
            {
                customer.ContactName = invalidContactName;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.ContactName - data is not valid.\r\nContactName cannot be longer than " + DataLength.ContactName.ToString();
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("ContactNameTestTooLong failed to throw an exception.");
            }
        }
        [TestMethod]
        public void ContactNameTestInvalidCharacters()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidContactName = "Max Productions;)";
            bool failed = false;
            try
            {
                customer.ContactName = invalidContactName;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.ContactName - data is not valid.\r\nThe ContactName contains the invalid characters ;";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("ContactNameTestInvalidCharacters failed to throw an exception.");
            }
        }
        #endregion
        #region ContactPhone
        [TestMethod]
        public void ContactPhoneTestValidFormatted()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = "(403) 265-4869";
            customer.ContactPhone = expected;
            string actual = customer.ContactPhone;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ContactPhoneTestValidUnformatted()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = "(403) 265-4869";
            customer.ContactPhone = "4032654869";
            string actual = customer.ContactPhone;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ContactPhoneTestNull()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = null;
            customer.ContactPhone = expected;
            string actual = customer.ContactPhone;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ContactPhoneTestEmptyString()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = null;
            customer.ContactPhone = "";
            string actual = customer.ContactPhone;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ContactPhoneTestSpace()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = null;
            customer.ContactPhone = " ";
            string actual = customer.ContactPhone;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ContactPhoneTestTooShort()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidContactPhone = "123456789";
            bool failed = false;
            try
            {
                customer.ContactPhone = invalidContactPhone;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.ContactPhone - data is not valid.\r\nYour ContactPhone number must have exactly 10 digits.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("ContactPhoneTestTooShort failed to throw an exception.");
            }
        }
        [TestMethod]
        public void ContactPhoneTestTooLong()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidContactPhone = "12345678901";
            bool failed = false;
            try
            {
                customer.ContactPhone = invalidContactPhone;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.ContactPhone - data is not valid.\r\nYour ContactPhone number must have exactly 10 digits.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("ContactPhoneTestTooLong failed to throw an exception.");
            }
        }
        #endregion

        #region ContactEmail
        [TestMethod]
        public void ContactEmailValid()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = "douglas.hahn@ptpro.com";
            customer.ContactEmail = expected;
            string actual = customer.ContactEmail;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ContactEmailMaxLocal()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = new string('a', 64) + "@ptpro.com";
            customer.ContactEmail = expected;
            string actual = customer.ContactEmail;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ContactEmailTestNull()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = null;
            customer.ContactEmail = expected;
            string actual = customer.ContactEmail;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ContactEmailTestEmptyString()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = null;
            customer.ContactEmail = string.Empty;
            string actual = customer.ContactEmail;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ContactEmailTestSpace()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = null;
            customer.ContactEmail = " ";
            string actual = customer.ContactEmail;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ContactEmailTestNoAtSign()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidContactEmail = "SendItToMyContactEmailAddressPtpro.com";
            bool failed = false;
            try
            {
                customer.ContactEmail = invalidContactEmail;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.ContactEmail - data is not valid.\r\nEmail address must contain exactly one @ sign.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("ContactEmailTestNoAtSign failed to throw an exception.");
            }
        }
        [TestMethod]
        public void ContactEmailTestTwoAtSign()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidContactEmail = "SendItToMy@ContactEmailAddress@Ptpro.com";
            bool failed = false;
            try
            {
                customer.ContactEmail = invalidContactEmail;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.ContactEmail - data is not valid.\r\nEmail address must contain exactly one @ sign.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("ContactEmailTestTwoAtSign failed to throw an exception.");
            }
        }
        [TestMethod]
        public void ContactEmailTestNoPersonName()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidContactEmail = "@Ptpro.com";
            bool failed = false;
            try
            {
                customer.ContactEmail = invalidContactEmail;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.ContactEmail - data is not valid.\r\nPerson name part of email address is blank.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("ContactEmailTestNoPersonName failed to throw an exception.");
            }
        }
        [TestMethod]
        public void ContactEmailTestPersonNameWithSpace()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidContactEmail = "Douglas Hahn@Ptpro.com";
            bool failed = false;
            try
            {
                customer.ContactEmail = invalidContactEmail;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.ContactEmail - data is not valid.\r\nThe person name part of the email address contains the invalid characters  ";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("ContactEmailTestPersonNameWithSpace failed to throw an exception.");
            }
        }
        [TestMethod]
        public void ContactEmailTestPersonNameStartsWithPeriod()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidContactEmail = ".Douglas.Hahn@Ptpro.com";
            bool failed = false;
            try
            {
                customer.ContactEmail = invalidContactEmail;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.ContactEmail - data is not valid.\r\nThe local part of the email address cannot start or end with a period.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("ContactEmailTestPersonNameStartsWithPeriod failed to throw an exception.");
            }
        }
        [TestMethod]
        public void ContactEmailTestPersonNameEndsWithPeriod()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidContactEmail = "Douglas.Hahn.@Ptpro.com";
            bool failed = false;
            try
            {
                customer.ContactEmail = invalidContactEmail;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.ContactEmail - data is not valid.\r\nThe local part of the email address cannot start or end with a period.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("ContactEmailTestPersonNameEndsWithPeriod failed to throw an exception.");
            }
        }
        [TestMethod]
        public void ContactEmailTestLocalTooLong()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidContactEmail = new string('a', 65) + "@Ptpro.com";
            bool failed = false;
            try
            {
                customer.ContactEmail = invalidContactEmail;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.ContactEmail - data is not valid.\r\nThe person name part of the email address cannot be greater than 64 characters.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("ContactEmailTestLocalTooLong failed to throw an exception.");
            }
        }
        [TestMethod]
        public void ContactEmailTestNoDomain()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidContactEmail = "douglas.hahn@";
            bool failed = false;
            try
            {
                customer.ContactEmail = invalidContactEmail;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.ContactEmail - data is not valid.\r\nDomain part EMail address is blank.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("ContactEmailTestNoDomain failed to throw an exception.");
            }
        }
        [TestMethod]
        public void ContactEmailTestTwoPeriodsTogether()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidContactEmail = "douglas.hahn@ptpro..com";
            bool failed = false;
            try
            {
                customer.ContactEmail = invalidContactEmail;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.ContactEmail - data is not valid.\r\nThe domain appears to have two periods together.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("ContactEmailTestTwoPeriodsTogether failed to throw an exception.");
            }
        }
        [TestMethod]
        public void ContactEmailTestDomainPartTooLong()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidContactEmail = "douglas.hahn@" + new string('a', 64) + ".com";
            bool failed = false;
            try
            {
                customer.ContactEmail = invalidContactEmail;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.ContactEmail - data is not valid.\r\nEach part of the domain (separated by periods) cannot be greater than 63 characters in length.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("ContactEmailTestDomainPartTooLong failed to throw an exception.");
            }
        }
        [TestMethod]
        public void ContactEmailTestDomainInvalidCharacters()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidContactEmail = "douglas.hahn@ptpro;com";
            bool failed = false;
            try
            {
                customer.ContactEmail = invalidContactEmail;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.ContactEmail - data is not valid.\r\nThe domain contains the invalid characters ;";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("ContactEmailTestDomainInvalidCharacters failed to throw an exception.");
            }
        }
        [TestMethod]
        public void ContactEmailTestDomainStartsWithDash()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidContactEmail = "douglas.hahn@-ptpro.com";
            bool failed = false;
            try
            {
                customer.ContactEmail = invalidContactEmail;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.ContactEmail - data is not valid.\r\nThe domain cannot start or end with a dash.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("ContactEmailTestDomainStartsWithDash failed to throw an exception.");
            }
        }
        [TestMethod]
        public void ContactEmailTestDomainEndsWithDash()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidContactEmail = "douglas.hahn@ptpro-.com";
            bool failed = false;
            try
            {
                customer.ContactEmail = invalidContactEmail;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.ContactEmail - data is not valid.\r\nThe domain cannot start or end with a dash.";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("ContactEmailTestDomainEndsWithDash failed to throw an exception.");
            }
        }
        #endregion

        #region ContactTitle
        [TestMethod]
        public void ContactTitleTestValid()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = "Grand Pooh Bah";
            customer.ContactTitle = expected;
            string actual = customer.ContactTitle;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ContactTitleTestWithSpace()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = "Software Architect";
            customer.ContactTitle = " Software Architect ";
            string actual = customer.ContactTitle;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ContactTitleTestNull()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = null;
            customer.ContactTitle = expected;
            string actual = customer.ContactTitle;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ContactTitleTestEmptyString()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = null;
            customer.ContactTitle = string.Empty;
            string actual = customer.ContactTitle;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ContactTitleTestSpace()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = null;
            customer.ContactTitle = " ";
            string actual = customer.ContactTitle;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ContactTitleTestMaxLength()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = 'A' + new string('a', DataLength.ContactTitle - 1);
            customer.ContactTitle = expected;
            string actual = customer.ContactTitle;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ContactTitleTestMinLength()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = "A";
            customer.ContactTitle = expected;
            string actual = customer.ContactTitle;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ContactTitleTestUpperCase()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = "President";
            customer.ContactTitle = expected.ToUpper();
            string actual = customer.ContactTitle;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ContactTitleTestLowerCase()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = "Director Sales";
            customer.ContactTitle = expected.ToLower();
            string actual = customer.ContactTitle;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ContactTitleTestTooLong()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidContactTitle = 'A' + new string('a', DataLength.ContactTitle);
            bool failed = false;
            try
            {
                customer.ContactTitle = invalidContactTitle;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.ContactTitle - data is not valid.\r\nContactTitle cannot be longer than " + DataLength.ContactTitle.ToString();
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("ContactTitleTestTooLong failed to throw an exception.");
            }
        }
        [TestMethod]
        public void ContactTitleTestInvalidCharacters()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidContactTitle = "Legal Fixer;)";
            bool failed = false;
            try
            {
                customer.ContactTitle = invalidContactTitle;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.ContactTitle - data is not valid.\r\nThe ContactTitle contains the invalid characters ;";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("ContactTitleTestInvalidCharacters failed to throw an exception.");
            }
        }
        #endregion

        #region ContactNotes
        [TestMethod]
        public void ContactNotesValid()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = new string('0', DataLength.ContactNotes);
            customer.ContactNotes = expected;
            string actual = customer.ContactNotes;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ContactNotesNull()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = null;
            customer.ContactNotes = expected;
            string actual = customer.ContactNotes;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ContactNotesEmptyString()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = null;
            customer.ContactNotes = string.Empty;
            string actual = customer.ContactNotes;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ContactNotesSpace()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = null;
            customer.ContactNotes = " ";
            string actual = customer.ContactNotes;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ContactNotesMaxLength()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = new string('0', DataLength.ContactNotes);
            customer.ContactNotes = expected;
            string actual = customer.ContactNotes;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ContactNotesMinLength()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string expected = null;
            customer.ContactNotes = expected;
            string actual = customer.ContactNotes;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ContactNotesTestTooLong()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidContactNotes = 'A' + new string('a', DataLength.ContactNotes);
            bool failed = false;
            try
            {
                customer.ContactNotes = invalidContactNotes;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.ContactNotes - data is not valid.\r\nContactNotes cannot be longer than " + DataLength.ContactNotes.ToString();
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("ContactNotesTestTooLong failed to throw an exception.");
            }
        }
        [TestMethod]
        public void ContactNotesTestInvalidCharacters()
        {
            CustomerWithValidations customer = new CustomerWithValidations();
            string invalidContactNotes = "Max Productions;)";
            bool failed = false;
            try
            {
                customer.ContactNotes = invalidContactNotes;
                failed = true;
            }
            catch (Exception ex)
            {
                string expectedError = "Validations.ContactNotes - data is not valid.\r\nThe ContactNotes contains the invalid characters ;";
                string actualError = ex.Message;
                Assert.AreEqual(expectedError, actualError);
            }
            if (failed)
            {
                Assert.Fail("ContactNotesTestInvalidCharacters failed to throw an exception.");
            }
        }
        #endregion

    }
}
