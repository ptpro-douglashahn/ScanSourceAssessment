<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="assessment_platform_developer.Customers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta charset="utf-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1.0" />
	<title><%: Page.Title %> RPM Platform Developer Assessment</title>

	<asp:PlaceHolder runat="server">
		<%: Scripts.Render("~/bundles/modernizr") %>
	</asp:PlaceHolder>

	<webopt:bundlereference runat="server" path="~/Content/css" />
	<link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
	<link rel="stylesheet" href="Content/Assessment.css" />
</head>
<body>
<form id="customerForm" runat="server">
	<asp:ScriptManager runat="server">
		<Scripts>
			<%--To learn more about bundling scripts in ScriptManager see https://go.microsoft.com/fwlink/?LinkID=301884 --%>
			<%--Framework Scripts--%>
			<asp:ScriptReference Name="MsAjaxBundle" />
			<asp:ScriptReference Name="jquery" />
			<asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
			<asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
			<asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
			<asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
			<asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
			<asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
			<asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
			<asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
			<asp:ScriptReference Name="WebFormsBundle" />
			<%--Site Scripts--%>
		</Scripts>
	</asp:ScriptManager>

	<nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-dark bg-dark">
		<div class="container body-content">
			<a class="navbar-brand" runat="server" href="~/">RPM Platform Developer Assessment</a>
			<button type="button" class="navbar-toggler" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" title="Toggle navigation" aria-controls="navbarSupportedContent"
			        aria-expanded="false" aria-label="Toggle navigation">
				<span class="navbar-toggler-icon"></span>
			</button>
			<div class="collapse navbar-collapse d-sm-inline-flex justify-content-between">
				<ul class="navbar-nav flex-grow-1">
					<li class="nav-item">
						<a class="nav-link" runat="server" href="~/">Home</a>
					</li>
					<li class="nav-item">
						<a class="nav-link" runat="server" href="~/Customers">Customers</a>
					</li>
				</ul>
			</div>
		</div>
	</nav>

	<div>
		<!--
		    Customer List Drop Down
		-->
		<div class="container body-content">
			<h2>Customer Registry</h2>
            <asp:DropDownList runat="server" ID="CustomersDDL" CssClass="form-control" OnSelectedIndexChanged="CustomersDDL_SelectedIndexChanged" AutoPostBack="true" />
		</div>
		<!--
		    Generic scripts
		-->
		<div class="container body-content">
			<script>
				function ToProperCase(targetText) {
					if (targetText == targetText.toUpperCase() || targetText == targetText.toLowerCase()) {
						var bolBreak = true;
						var strBreakChars = "/,.:;[]{}-_=+!@#$%^&*()1234567890 ";
						var ProperCase = "";
						for (const ch of targetText) {
							if (bolBreak) {
								ProperCase += ch.toUpperCase();
							} else
							{
								ProperCase += ch.toLowerCase();
							}
							if (strBreakChars.includes(ch)) {
								bolBreak = true;
							} else
							{
								bolBreak = false;
							}
						}
						return ProperCase;
					}
					return targetText;
				}
            </script>
			<div class="card">

				<div class="card-body">

					<div class="row justify-content-center">
						<!--
						    Customer Name
						-->
						<div class="col-md-6">
							<h1>Add customer</h1>
							<div class="form-group">
								<asp:Label ID="CustomerNameLabel" runat="server" Text="Name" CssClass="form-label"></asp:Label>
								<asp:TextBox ID="CustomerName" runat="server" CssClass="form-control" onchange="CustomerNameProperCase(this)"></asp:TextBox>
								<script>
                                    function CustomerNameProperCase(customerName) {
                                        customerName.value = ToProperCase(customerName.value);
                                        this.CustomerName = customerName;
                                    }
                                </script>
								<asp:RequiredFieldValidator runat="server" id="reqCustomerName" controltovalidate="CustomerName" errormessage="Company name cannot be blank." ForeColor="Red" />
							</div>
							<!--
							    Customer Email
							-->
							<div class="form-group">
								<asp:Label ID="CustomerEmailLabel" runat="server" Text="Email" CssClass="form-label"></asp:Label>
								<asp:TextBox ID="CustomerEmail" runat="server" CssClass="form-control" CausesValidation="true" 
									AutoPostBack="true" ValidateEmptyText="true" ValidationGroup="CustomerEmailValidationGroup"></asp:TextBox>
								<asp:RequiredFieldValidator runat="server" id="CustomerEmailRequired" controltovalidate="CustomerEmail" 
									errormessage="Email cannot be blank." ValidationGroup="CustomerEmailValidationGroup" ForeColor="Red"/>
								<br />
								<asp:CustomValidator ID="CustomerEmailCustomValidator" runat="server" ErrorMessage="Email is not valid" 
									ControlToValidate="CustomerEmail" OnServerValidate="ValidateEmail" ForeColor="Red" ValidationGroup="CustomerEmailValidationGroup"></asp:CustomValidator>
       						</div>
							<!--
							    Customer Phone
							-->
							<div class="form-group">
								<asp:Label ID="CustomerPhoneLabel" runat="server" Text="Phone" CssClass="form-label"></asp:Label>
								<asp:TextBox ID="CustomerPhone" runat="server" CssClass="form-control"></asp:TextBox>
								<ajaxToolkit:MaskedEditExtender ID="maskCustomerPhone" runat="server" TargetControlID="CustomerPhone"
									ClearMaskOnLostFocus="false" MaskType="None" Mask="(999) 999-9999"
									MessageValidatorTip="true" InputDirection="LeftToRight" ErrorTooltipEnabled="true">
								</ajaxToolkit:MaskedEditExtender>
								<asp:RegularExpressionValidator ID="CustomerPhoneValidator" runat="server" 
									ErrorMessage="Invalid Phone Number" ControlToValidate="CustomerPhone" 
									ValidationExpression="^$|\(\d{3}\) \d{3}-\d{4}$" ForeColor="Red">
								</asp:RegularExpressionValidator>
							</div>
							<!--
							    Customer Address
							-->
							<div class="form-group">
								<asp:Label ID="CustomerAddressLabel" runat="server" Text="Address" CssClass="form-label"></asp:Label>
								<asp:TextBox ID="CustomerAddress" runat="server" CssClass="form-control" onchange="CustomerAddressProperCase(this)"></asp:TextBox>
								<script>
                                    function CustomerAddressProperCase(customerAddress) {
                                        customerAddress.value = ToProperCase(customerAddress.value);
                                        this.CustomerAddress = customerAddress;
                                    }
                                </script>
							</div>
							<!--
							    Customer City
							-->
							<div class="form-group">
								<asp:Label ID="CustomerCityLabel" runat="server" Text="City" CssClass="form-label"></asp:Label>
								<asp:TextBox ID="CustomerCity" runat="server" CssClass="form-control" onchange="CustomerCityProperCase(this)"></asp:TextBox>
								<script>
                                    function CustomerCityProperCase(customerCity) {
                                        customerCity.value = ToProperCase(customerCity.value);
                                        this.CustomerCity = customerCity;
                                    }
                                </script>
								<asp:RequiredFieldValidator runat="server" id="CustomerCityValidator" controltovalidate="CustomerCity" errormessage="City cannot be blank." ForeColor="Red" />
							</div>
							<!--
							    Customer State
							-->
							<div class="form-group">
								<asp:Label ID="CustomerStateLabel" runat="server" Text="Province/State" CssClass="form-label"></asp:Label>
								<asp:DropDownList ID="StateDropDownList" runat="server" CssClass="form-control" ValidationGroup="StateValidationGroup"/>
								<asp:RequiredFieldValidator runat="server" id="StateDropDownListValidator" controltovalidate="StateDropDownList" errormessage="Province/State cannot be blank." ForeColor="Red" ValidationGroup="StateValidationGroup" />
							</div>
							<!--
							    Customer Zip
							-->
							<div class="form-group">
								<asp:Label ID="CustomerZipLabel" runat="server" Text="Postal/Zip Code" CssClass="form-label"></asp:Label>
								<asp:TextBox ID="CustomerZip" runat="server" CssClass="postalzip"></asp:TextBox>
								<asp:CustomValidator ID="ZipCustomValidator" runat="server" ControlToValidate="CustomerZip" ClientValidationFunction="CheckAndReformatZip" ValidateEmptyText="false" ErrorMessage="Invalid Zip/Postal Code" ForeColor="Red"></asp:CustomValidator>
								
								<script>
									function CheckAndReformatZip(source, arguments) {
										var countryName = document.getElementById("CountryDropDownList");
                                        var selectedCountry = countryName.options[countryName.value].text;
										var zip = document.getElementById("CustomerZip").value.toUpperCase();
										var canadianPostalCode = /^[ABCEGHJ-NPRSTVXY]\d[ABCEGHJ-NPRSTV-Z][ ]\d[ABCEGHJ-NPRSTV-Z]\d$/i;
										var canadianPostalCodeNoSpace = /^[ABCEGHJ-NPRSTVXY]\d[ABCEGHJ-NPRSTV-Z]\d[ABCEGHJ-NPRSTV-Z]\d$/i;
										var zip5 = /^\d{5}$/i;
										var zip54 = /^\d{5}[-]\d{4}$/i;
										var zip9 = /^\d{9}$/i;
										if (selectedCountry == "Canada") {
											if (canadianPostalCode.test(zip)) {
												arguments.IsValid = true;
											} else if (canadianPostalCodeNoSpace.test(zip)) {
												var reformatted = zip.substr(0, 3) + " " + zip.substr(3, 3);
												document.getElementById("CustomerZip").value = reformatted;
                                                arguments.IsValid = true;
											} else {
												arguments.IsValid = false;
											}
										} else {
											if (zip5.test(zip)) {
                                                arguments.IsValid = true;
											} else if (zip54.test(zip)) {
                                                arguments.IsValid = true;
											} else if (zip9.test(zip)) {
												document.getElementById("CustomerZip").value = zip.substr(0, 5) + "-" + zip.substr(5, 4);
                                                arguments.IsValid = true;
											} else {
                                                arguments.IsValid = false;
											}
										}
									}
                                </script>
							</div>
							<!--
							    Customer Country
							-->
							<div class="form-group">
								<asp:Label ID="CustomerCountryLabel" runat="server" Text="Country" CssClass="form-label"></asp:Label>
								<asp:DropDownList ID="CountryDropDownList" runat="server" CssClass="form-control" OnSelectedIndexChanged="Country_SelectedIndexChanged" AutoPostBack="true"/>
							</div>
							<!--
							    Customer Notes
							-->
							<div>
								<asp:Label ID="CustomerNotesLabel" runat="server" Text="Notes" CssClass="form-label"></asp:Label>
								<asp:TextBox ID="CustomerNotes" runat="server" CssClass="form-control"></asp:TextBox>
							</div>
							<!--
								******************************************************************************************
								  Contact Data
								******************************************************************************************
							-->
							<h1>Customer contact details</h1>
							<!--
							    Contact Name
							-->
							<div class="form-group">
								<asp:Label ID="ContactNameLabel" runat="server" Text="Name" CssClass="form-label"></asp:Label>
								<asp:TextBox ID="ContactName" runat="server" CssClass="form-control" onchange="ContactNameProperCase(this)"></asp:TextBox>
								<script>
                                    function ContactNameProperCase(ContactName) {
                                        ContactName.value = ToProperCase(ContactName.value);
                                        this.ContactName = ContactName;
                                    }
                                </script>
							</div>
							<!--
							    Contact Email
							-->
							<div class="form-group">
								<asp:Label ID="ContactEmailLabel" runat="server" Text="Email" CssClass="form-label"></asp:Label>
								<asp:TextBox ID="ContactEmail" runat="server" CssClass="form-control" AutoPostBack="true" CausesValidation="true" ValidationGroup="ContactEmailValidationGroup"></asp:TextBox>
								<asp:CustomValidator ID="ContactEmailValidator" runat="server" ErrorMessage="Email is not valid" 
									ControlToValidate="ContactEmail" OnServerValidate="ValidateEmail" ForeColor="Red" ValidationGroup="ContactEmailValidationGroup"></asp:CustomValidator>
							</div>
							<!--
							    Contact Phone
							-->
							<div class="form-group">
								<asp:Label ID="ContactPhoneLabel" class="col-form-label" runat="server" Text="Phone" CssClass="form-label"></asp:Label>
								<asp:TextBox ID="ContactPhone" runat="server" CssClass="form-control" onchange="ContactPhoneMaskOnly(this)"></asp:TextBox>
								<script>
									function ContactPhoneMaskOnly(contactPhone)
									{
										var contactPhoneText = contactPhone.value;
										if (contactPhoneText == "(___) ___-____") {
											contactPhoneText = "";
										} else if (contactPhoneText.length == 10) {
											contactPhoneText = "(" + contactPhoneText.substr(0,3) + ") " + contactPhoneText.substr(3,3) + "-" + contactPhoneText.substr(6,4)
										}
									}
								</script>
								<ajaxToolkit:MaskedEditExtender ID="MaskedEditExtenderContactPhone" runat="server" TargetControlID="ContactPhone"
									ClearMaskOnLostFocus="false" MaskType="None" Mask="(999) 999-9999"
									MessageValidatorTip="true" InputDirection="LeftToRight" ErrorTooltipEnabled="true">
								</ajaxToolkit:MaskedEditExtender>
								<asp:RegularExpressionValidator ID="RegularExpressionValidatorContactPhone" runat="server" 
									ErrorMessage="Invalid Phone Number" ControlToValidate="ContactPhone" ValidationExpression="^\(\d{3}\) \d{3}-\d{4}$|^\(___\) ___-____$" ForeColor="Red">
								</asp:RegularExpressionValidator>
							</div>
							<!--
							    Contact Title
							-->
							<div class="form-group">
								<asp:Label ID="ContactTitleLabel" runat="server" Text="Title" CssClass="form-label"></asp:Label>
								<asp:TextBox ID="ContactTitle" runat="server" CssClass="form-control" onchange="ContactTitleProperCase(this)"></asp:TextBox>
								<script>
                                    function ContactTitleProperCase(ContactTitle) {
                                        ContactTitle.value = ToProperCase(ContactTitle.value);
                                        this.ContactTitle = ContactTitle;
                                    }
                                </script>
							</div>
							<!--
							    Contact Notes
							-->
							<div class="form-group">
								<asp:Label ID="ContactNotesLabel" runat="server" Text="Notes" CssClass="form-label"></asp:Label>
								<asp:TextBox ID="ContactNotes" runat="server" CssClass="form-control"></asp:TextBox>
							</div>
							<!--
							    Buttons
							-->
							<div class="form-group">
								<asp:Button ID="AddButton" class="btn btn-primary btn-md" runat="server" Text="Add" OnClick="AddButton_Click" />
								<asp:Button ID="UpdateButton" CssClass="btn btn-primary btn-md" runat="server" Text="Update" OnClick="UpdateButton_Click" Visible="false"/>
								<asp:Button ID="DeleteButton" CssClass="btn btn-primary btn-md" runat="server" Text="Delete" OnClick="DeleteButton_Click" Visible="false" />
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</form>
</body>
</html>