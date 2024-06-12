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
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Web;

namespace assessment_platform_developer
{
    //  Version Date         Author        Description
    //  1.0     ?            ScanSource    Original developer assessment
    //  2.0     12 Jun 2024  Douglas Hahn  My updates to the developer assessment
    //
    /// <summary>
    /// I use this class because I use the datalength in many different places in the system
    /// If, say, we decide that the company name should be 100 characters instead of 75, it is easiest
    /// if there is only one place to change the data.
    /// </summary>
    public static class DataLength
    {
        public static int ID = 0;
        public static int Name = 75;
        public static int Address = 50;
        public static int Email = 260;
        public static int Phone = 14;
        public static int City = 50;
        public static int State = 35;
        public static int Zip = 10;
        public static int Country = 50;
        public static int Notes = 100;
        public static int ContactName = 100;
        public static int ContactEmail = 260;
        public static int ContactPhone = 14;
        public static int ContactTitle = 100;
        public static int ContactNotes = 100;
    }
}