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
using System.ComponentModel;

namespace assessment_platform_developer
{
    //  Version Date         Author        Description
    //  1.0     ?            ScanSource    Original developer assessment
    //  2.0     12 Jun 2024  Douglas Hahn  My updates to the developer assessment
    //
    #region Countries
    /// <summary>
    /// Countries
    /// </summary>
    public enum Countries
    {
        Canada,
        [Description("United States")]
        UnitedStates
    }
    #endregion

    #region USStates
    /// <summary>
    /// US States
    /// </summary>
    public enum USStates
    {
        Alabama,
        Alaska,
        Arizona,
        Arkansas,
        California,
        Colorado,
        Connecticut,
        Delaware,
        Florida,
        Georgia,
        Hawaii,
        Idaho,
        Illinois,
        Indiana,
        Iowa,
        Kansas,
        Kentucky,
        Louisiana,
        Maine,
        Maryland,
        Massachusetts,
        Michigan,
        Minnesota,
        Mississippi,
        Missouri,
        Montana,
        Nebraska,
        Nevada,
        [Description("New Hampshire")]
        NewHampshire,
        [Description("New Jersey")]
        NewJersey,
        [Description("New Mexico")]
        NewMexico,
        [Description("New York")]
        NewYork,
        [Description("North Carolina")]
        NorthCarolina,
        [Description("North Dakota")]
        NorthDakota,
        Ohio,
        Oklahoma,
        Oregon,
        Pennsylvania,
        [Description("Rhode Island")]
        RhodeIsland,
        [Description("South Carolina")]
        SouthCarolina,
        [Description("South Dakota")]
        SouthDakota,
        Tennessee,
        Texas,
        Utah,
        Vermont,
        Virginia,
        Washington,
        [Description("West Virginia")]
        WestVirginia,
        Wisconsin,
        Wyoming
    }
    #endregion

    #region CanadianProvinces
    /// <summary>
    /// Canadian Provinces
    /// </summary>
    public enum CanadianProvinces
    {
        Alberta,
        [Description("British Columbia")]
        BritishColumbia,
        Manitoba,
        [Description("New Brunswick")]
        NewBrunswick,
        [Description("Newfoundland and Labrador")]
        NewfoundlandAndLabrador,
        [Description("Northwest Territories")]
        NorthwestTerritories,
        [Description("Nova Scotia")]
        NovaScotia,
        Nunavut,
        Ontario,
        [Description("Prince Edward Island")]
        PrinceEdwardIsland,
        Quebec,
        Saskatchewan,
        Yukon
    }
    #endregion

}