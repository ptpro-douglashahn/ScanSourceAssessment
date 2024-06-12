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
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace assessment_platform_developer
{
    //  Version Date         Author        Description
    //  1.0     ?            ScanSource    Original developer assessment
    //  2.0     12 Jun 2024  Douglas Hahn  My updates to the developer assessment
    //
    /// <summary>
    /// Validations for data entry
    /// </summary>
    [Serializable]
    public class Validations
    {
        #region EMailAddressRFC5322
        /// <summary>
        /// Validate an email address according to the RFC5322 specification
        /// </summary>
        /// <param name="EMailAddress"></param>
        /// <exception cref="Exception"></exception>
        public static void EMailAddressRFC5322(ref string EMailAddress)
        {
            string[] emailParts = EMailAddress.Split("@".ToCharArray());
            if (emailParts.Length != 2)
            {
                throw new Exception("Email address must contain exactly one @ sign.");
            }
            string localPart = emailParts[0].Trim();
            string domainPart = emailParts[1].Trim();
            //
            //  Local Validation
            //
            if (localPart == "")
            {
                throw new Exception("Person name part of email address is blank.");
            }
            string localValidCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!#$%&'*+-/=?^_`{|}~.";
            string localInvalidCharacters = "";
            foreach (char ch in localPart)
            {
                if (!localValidCharacters.Contains(ch))
                {
                    if (!localInvalidCharacters.Contains(ch))
                    {
                        localInvalidCharacters += ch;
                    }
                }
            }
            if (localInvalidCharacters.Length > 0)
            {
                throw new Exception("The person name part of the email address contains the invalid characters " + localInvalidCharacters);
            }
            if (localPart.StartsWith(".") || localPart.EndsWith("."))
            {
                throw new Exception("The local part of the email address cannot start or end with a period.");
            }
            if (localPart.Length > 64)
            {
                throw new Exception("The person name part of the email address cannot be greater than 64 characters.");
            }
            //
            //  Domain Validation
            //
            if (domainPart.Trim().Length == 0)
            {
                throw new Exception("Domain part EMail address is blank.");
            }
            DomainRFC5322(ref domainPart);
            EMailAddress = localPart + "@" + domainPart;
        }
        #endregion

        #region DomainRFC5322
        /// <summary>
        /// Domain Validation
        /// </summary>
        /// <param name="Domain"></param>
        /// <exception cref="Exception"></exception>
        public static void DomainRFC5322(ref string Domain)
        {
            string[] domainParts = Domain.Trim().Split(".".ToCharArray());
            string domainVaidChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-";
            string domainInvalidChars = "";
            foreach (string domainPart in domainParts)
            {
                if (domainPart.Length < 1)
                {
                    throw new Exception("The domain appears to have two periods together.");
                }
                if (domainPart.Length > 63)
                {
                    throw new Exception("Each part of the domain (separated by periods) cannot be greater than 63 characters in length.");
                }
                foreach (char ch in domainPart)
                {
                    if (!domainVaidChars.Contains(ch))
                    {
                        if (!domainInvalidChars.Contains(ch))
                        {
                            domainInvalidChars += ch;
                        }
                    }
                }
                if (domainInvalidChars.Length > 0)
                {
                    throw new Exception("The domain contains the invalid characters " + domainInvalidChars);
                }
                if (domainPart.StartsWith("-") || domainPart.EndsWith("-"))
                {
                    throw new Exception("The domain cannot start or end with a dash.");
                }
            }
        }
        #endregion
        /// <summary>
        /// Convert a string to proper case, for example:
        ///   PLATINUM PRO LTD. will be converted to Platinum Pro Ltd.
        ///   platinum pro ltd. will be converted to Platinum Pro Ltd.
        /// Before using this conversion, check to see if there is a mixture of upper case and lower case characters
        /// in your string, if there are both, don't call this function because
        ///   McDonalds Inc. will be converted to Mcdonalds Inc.
        /// </summary>
        /// <param name="Name">The string you want converted</param>
        /// <returns>Converted to upper case and lower case.  First character after a break character is capitalized 
        /// and all the rest are changed to lower case.</returns>
        public static string ProperCase(string Name)
        {
            bool bolBreak = true;
            string strBreakChars = @"/,.:;[]{}-_=+!@#$%^&*()1234567890 ";
            string ProperCase = @"";
            for (int intC = 0; intC <= Name.Length - 1; intC++)
            {
                if (bolBreak)
                {
                    ProperCase += Name.Substring(intC, 1).ToUpper();
                }
                else
                {
                    ProperCase += Name.Substring(intC, 1).ToLower();
                }
                if (strBreakChars.Contains(Name.Substring(intC, 1)))
                {
                    bolBreak = true;
                }
                else
                {
                    bolBreak = false;
                }
            }
            return ProperCase;
        }

        #region ID
        /// <summary>
        /// The customer ID - this is usually assigned by the system
        /// </summary>
        /// <param name="ID">Customer number</param>
        /// <exception cref="Exception">Any errors in the data</exception>
        public static void ID(ref int ID)
        {
            if (ID < 1)
            {
                throw new Exception("ID cannot be less than zero.");
            }
        }
        #endregion

        #region Name
        /// <summary>
        /// Name (Company Name)
        /// I've assumed that this is a corporate database and there will always be a company name.
        /// </summary>
        /// <param name="Name"></param>
        /// <exception cref="Exception">Any errors in the data</exception>
        public static void Name(ref string Name)
        {
            //
            // Change to Title Case but only if it is all upper case or all lower case
            //
            if (Name == Name.ToLower() || Name == Name.ToUpper())
            {
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                Name = Validations.ProperCase(Name);
            }
            if (Name.Length > DataLength.Name)
            {
                throw new Exception("Name cannot be longer than " + DataLength.Name.ToString());
            }
            //
            //  I've excluded characters like =;" because they can be used in code injections
            //
            string nameValidChars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789- '.,/()&";
            string nameInvalidChars = "";
            foreach (char ch in Name)
            {
                if (!nameValidChars.Contains(ch))
                {
                    if (!nameInvalidChars.Contains(ch))
                    {
                        nameInvalidChars += ch;
                    }
                }
            }
            if (nameInvalidChars.Length > 0)
            {
                throw new Exception("The Name contains the invalid characters " + nameInvalidChars);
            }
        }
        #endregion

        #region Address
        /// <summary>
        /// Address is not required because with some small towns in Canada, only the person's name and
        /// the town is required.  The town is small enough that everyone knows everyone and a box number or "General Delivery"
        /// is not required.
        /// </summary>
        /// <param name="Address">Street Address, not city, province, or postal code</param>
        /// <exception cref="Exception">Any errors in the data</exception>
        public static void Address(ref string Address)
        {
            if (Address != null)
            {
                //
                // Change to Title Case but only if it is all upper case or all lower case
                //
                if (Address == Address.ToLower() || Address == Address.ToUpper())
                {
                    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                    Address = Validations.ProperCase(Address);
                }
                if (Address.Length > DataLength.Address)
                {
                    throw new Exception("Address cannot be longer than " + DataLength.Address.ToString());
                }
                //
                //  I've excluded characters like =;" because they can be used in code injections
                //
                string AddressValidChars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789- '.,/()&#";
                string AddressInvalidChars = "";
                foreach (char ch in Address)
                {
                    if (!AddressValidChars.Contains(ch))
                    {
                        if (!AddressInvalidChars.Contains(ch))
                        {
                            AddressInvalidChars += ch;
                        }
                    }
                }
                if (AddressInvalidChars.Length > 0)
                {
                    throw new Exception("The Address contains the invalid characters " + AddressInvalidChars);
                }
            }
        }
        #endregion

        #region Email
        /// <summary>
        /// Email address
        /// This is not required
        /// </summary>
        /// <param name="Email">Email address</param>
        public static void Email(ref string Email)
        {
            if (Email != null)
            {
                EMailAddressRFC5322(ref Email);
            }
        }
        #endregion

        #region Phone
        /// <summary>
        /// Phone number will be reformatted to (999) 999-9999
        /// This is not required.
        /// </summary>
        /// <param name="Phone"></param>
        /// <exception cref="Exception">Any errors in the data</exception>
        public static void Phone(ref string Phone)
        {
            if (Phone == null)
            { }
            else
            {
                Phone = Phone.Trim();
                if (Phone == "")
                {
                    Phone = null;
                } else
                {
                    string numbersOnly = "";
                    foreach (char ch in Phone)
                    {
                        if (ch >= '0' && ch <= '9')
                        {
                            numbersOnly += ch;
                        }
                    }
                    if (numbersOnly.Length != 10)
                    {
                        throw new Exception("Your phone number must have exactly 10 digits.");
                    }
                    Phone = "(" + numbersOnly.Substring(0, 3) + ") " + numbersOnly.Substring(3, 3) + "-" + numbersOnly.Substring(6, 4);
                }
            }
        }
        #endregion

        #region City
        /// <summary>
        /// City - required
        /// </summary>
        /// <param name="City">Name of the city, town, village, etc.</param>
        /// <exception cref="Exception">Any errors in the data</exception>
        public static void City(ref string City)
        {
            if (City.Length > DataLength.City)
            {
                throw new Exception("City cannot be longer than " + DataLength.City.ToString());
            }
            if (City == City.ToLower() || City == City.ToUpper())
            {
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                City = Validations.ProperCase(City);
            }
            //
            //  I've excluded characters like =;" because they can be used in code injections
            //
            string CityValidChars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz- ";
            string CityInvalidChars = "";
            foreach (char ch in City)
            {
                if (!CityValidChars.Contains(ch))
                {
                    if (!CityInvalidChars.Contains(ch))
                    {
                        CityInvalidChars += ch;
                    }
                }
            }
            if (CityInvalidChars.Length > 0)
            {
                throw new Exception("The City contains the invalid characters " + CityInvalidChars);
            }
        }
        #endregion

        #region State
        /// <summary>
        /// State - required
        /// </summary>
        /// <param name="State">Name of the U.S. State or Canadian Province</param>
        /// <exception cref="Exception">Any errors in the data</exception>
        public static void State(ref string State, string Country)
        {
            State = State.Replace(" ", "");
            if (Country == "Canada")
            {
                if (!Enum.IsDefined(typeof(CanadianProvinces), State))
                {
                    throw new Exception("Canadian Province " + State + " does not exist.");
                }
            } else
            {
                if (!Enum.IsDefined(typeof(USStates), State))
                {
                    throw new Exception("US State " + State + " does not exist.");
                }
            }
        }
        #endregion

        #region Zip
        /// <summary>
        /// Zip/Postal code - required
        /// </summary>
        /// <param name="Zip">The US zip code or the Canadian Postal Code</param>
        /// <param name="Country">Either 'Canada' or 'United States'</param>
        /// <exception cref="Exception"></exception>
        public static void Zip(ref string Zip, string Country)
        {
            {
                Zip = Zip.ToUpper().Trim();
                if (Country == "Canada")
                {
                    if (Regex.IsMatch(Zip, @"^[ABCEGHJ-NPRSTVXY]\d[ABCEGHJ-NPRSTV-Z][ ]\d[ABCEGHJ-NPRSTV-Z]\d$"))
                    {
                        //  Canadian Postal Code properly formatted
                    }
                    else if (Regex.IsMatch(Zip, @"^[ABCEGHJ-NPRSTVXY]\d[ABCEGHJ-NPRSTV-Z]\d[ABCEGHJ-NPRSTV-Z]\d$"))
                    {
                        //  Canadian Postal Code no space
                        Zip = Zip.Substring(0, 3) + " " + Zip.Substring(3, 3);
                    }
                    else
                    {
                        throw new Exception("Postal Code is not valid.");
                    }
                }
                else
                {
                    if (Regex.IsMatch(Zip, @"^\d{5}$"))
                    {
                        // Exactly 5 digits US short zip code
                    }
                    else if (Regex.IsMatch(Zip, @"^\d{9}$"))
                    {
                        // Exactly 9 digits US long zip code - reformat with a dash
                        Zip = Zip.Substring(0, 5) + "-" + Zip.Substring(5, 4);
                    }
                    else if (Regex.IsMatch(Zip, @"^\d{5}[-]\d{4}$"))
                    {
                        //  Five dash four US long zip code properly formatted
                    }
                    else
                    {
                        throw new Exception("Zip code is not valid.");
                    }
                }
            }
        }
        #endregion

        #region Country
        /// <summary>
        /// Country
        /// </summary>
        /// <param name="Country">Either 'Canada' or 'United States'</param>
        /// <exception cref="Exception"></exception>
        public static void Country(ref string Country)
        {
            Country = Country.Replace(" ", "");
            switch (Country)
            {
                case "Canada":
                    break;
                case "UnitedStates":
                    break;
                default:
                    throw new Exception("Only Canada and United States are valid countries.");
            }
        }
        #endregion

        #region Notes
        /// <summary>
        /// Notes
        /// </summary>
        /// <param name="Notes"></param>
        /// <exception cref="Exception"></exception>
        public static void Notes(ref string Notes)
        {
            if (Notes != null)
            {
                //
                // Change to Title Case but only if it is all upper case or all lower case
                //
                if (Notes == Notes.ToLower() || Notes == Notes.ToUpper())
                {
                    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                    Notes = Validations.ProperCase(Notes);
                }
                if (Notes.Length > DataLength.Notes)
                {
                    throw new Exception("Notes cannot be longer than " + DataLength.Notes.ToString());
                }
                //
                //  I've excluded characters like =;" because they can be used in code injections
                //
                string NotesValidChars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789- '.,/()&#";
                string NotesInvalidChars = "";
                foreach (char ch in Notes)
                {
                    if (!NotesValidChars.Contains(ch))
                    {
                        if (!NotesInvalidChars.Contains(ch))
                        {
                            NotesInvalidChars += ch;
                        }
                    }
                }
                if (NotesInvalidChars.Length > 0)
                {
                    throw new Exception("The Notes contains the invalid characters " + NotesInvalidChars);
                }
            }
        }
        #endregion

        #region ContactName
        /// <summary>
        /// ContactName
        /// </summary>
        /// <param name="ContactName"></param>
        /// <exception cref="Exception"></exception>
        public static void ContactName(ref string ContactName)
        {
            if (ContactName != null)
            {
                //
                // Change to Title Case but only if it is all upper case or all lower case
                //
                if (ContactName == ContactName.ToLower() || ContactName == ContactName.ToUpper())
                {
                    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                    ContactName = Validations.ProperCase(ContactName);
                }
                if (ContactName.Length > DataLength.ContactName)
                {
                    throw new Exception("ContactName cannot be longer than " + DataLength.ContactName.ToString());
                }
                //
                //  I've excluded characters like =;" because they can be used in code injections
                //
                string ContactNameValidChars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz- '.,/()";
                string ContactNameInvalidChars = "";
                foreach (char ch in ContactName)
                {
                    if (!ContactNameValidChars.Contains(ch))
                    {
                        if (!ContactNameInvalidChars.Contains(ch))
                        {
                            ContactNameInvalidChars += ch;
                        }
                    }
                }
                if (ContactNameInvalidChars.Length > 0)
                {
                    throw new Exception("The ContactName contains the invalid characters " + ContactNameInvalidChars);
                }
            }
        }
        #endregion

        #region ContactEmail
        /// <summary>
        /// ContactEmail
        /// </summary>
        /// <param name="ContactEmail"></param>
        /// <exception cref="Exception"></exception>
        public static void ContactEmail(ref string ContactEmail)
        {
            if (ContactEmail != null)
            {
                EMailAddressRFC5322(ref ContactEmail);
            }

        }
        #endregion

        #region ContactPhone
        /// <summary>
        /// ContactPhone number will be reformatted to (999) 999-9999
        /// </summary>
        /// <param name="ContactPhone"></param>
        /// <exception cref="Exception">Any errors in the data</exception>
        public static void ContactPhone(ref string ContactPhone)
        {
            if (ContactPhone != null)
            {
                string numbersOnly = "";
                foreach (char ch in ContactPhone)
                {
                    if (ch >= '0' && ch <= '9')
                    {
                        numbersOnly += ch;
                    }
                }
                if (numbersOnly.Length != 10)
                {
                    throw new Exception("Your ContactPhone number must have exactly 10 digits.");
                }
                ContactPhone = "(" + numbersOnly.Substring(0, 3) + ") " + numbersOnly.Substring(3, 3) + "-" + numbersOnly.Substring(6, 4);
            }
        }
        #endregion

        #region ContactTitle
        /// <summary>
        /// ContactTitle
        /// </summary>
        /// <param name="ContactTitle"></param>
        /// <exception cref="Exception"></exception>
        public static void ContactTitle(ref string ContactTitle)
        {
            if (ContactTitle != null)
            {
                //
                // Change to Title Case but only if it is all upper case or all lower case
                //
                if (ContactTitle == ContactTitle.ToLower() || ContactTitle == ContactTitle.ToUpper())
                {
                    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                    ContactTitle = Validations.ProperCase(ContactTitle);
                }
                if (ContactTitle.Length > DataLength.ContactTitle)
                {
                    throw new Exception("ContactTitle cannot be longer than " + DataLength.ContactTitle.ToString());
                }
                //
                //  I've excluded characters like =;" because they can be used in code injections
                //
                string ContactTitleValidChars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz- '.,/()";
                string ContactTitleInvalidChars = "";
                foreach (char ch in ContactTitle)
                {
                    if (!ContactTitleValidChars.Contains(ch))
                    {
                        if (!ContactTitleInvalidChars.Contains(ch))
                        {
                            ContactTitleInvalidChars += ch;
                        }
                    }
                }
                if (ContactTitleInvalidChars.Length > 0)
                {
                    throw new Exception("The ContactTitle contains the invalid characters " + ContactTitleInvalidChars);
                }
            }
        }
        #endregion

        #region ContactNotes
        /// <summary>
        /// ContactNotes
        /// </summary>
        /// <param name="ContactNotes"></param>
        /// <exception cref="Exception"></exception>
        public static void ContactNotes(ref string ContactNotes)
        {
            if (ContactNotes != null)
            {
                //
                // Change to Title Case but only if it is all upper case or all lower case
                //
                if (ContactNotes == ContactNotes.ToLower() || ContactNotes == ContactNotes.ToUpper())
                {
                    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                    ContactNotes = Validations.ProperCase(ContactNotes);
                }
                if (ContactNotes.Length > DataLength.ContactNotes)
                {
                    throw new Exception("ContactNotes cannot be longer than " + DataLength.ContactNotes.ToString());
                }
                //
                //  I've excluded characters like =;" because they can be used in code injections
                //
                string ContactNotesValidChars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789- '.,/()&#";
                string ContactNotesInvalidChars = "";
                foreach (char ch in ContactNotes)
                {
                    if (!ContactNotesValidChars.Contains(ch))
                    {
                        if (!ContactNotesInvalidChars.Contains(ch))
                        {
                            ContactNotesInvalidChars += ch;
                        }
                    }
                }
                if (ContactNotesInvalidChars.Length > 0)
                {
                    throw new Exception("The ContactNotes contains the invalid characters " + ContactNotesInvalidChars);
                }
            }
        }
        #endregion
    }
}