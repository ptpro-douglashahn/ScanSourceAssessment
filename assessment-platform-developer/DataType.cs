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

namespace assessment_platform_developer
{
    //  Version Date         Author        Description
    //  1.0     ?            ScanSource    Original developer assessment
    //  2.0     12 Jun 2024  Douglas Hahn  My updates to the developer assessment
    //
    /// <summary>
    /// Data types for each of the data components.
    /// This isn't as useful as the DataLength class because there are many places
    /// that we can't specify the data type as a variable.  However, coming from a
    /// client/server background, datatype is used often and can be used in many 
    /// different environments as a variable (e.g. parameters in an SQL Command or Adapter)
    /// </summary>
    public static class DataType
    {
        public static Type ID = typeof(int);
        public static Type Name = typeof(string);
        public static Type Address = typeof(string);
        public static Type Email = typeof(string);
        public static Type Phone = typeof(string);
        public static Type City = typeof(string);
        public static Type State = typeof(string);
        public static Type Zip = typeof(string);
        public static Type Country = typeof(string);
        public static Type Notes = typeof(string);
        public static Type ContactName = typeof(string);
        public static Type ContactPhone = typeof(string);
        public static Type ContactEmail = typeof(string);
        public static Type ContactTitle = typeof(string);
        public static Type ContactNotes = typeof(string);
    }
}