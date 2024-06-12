ScanSource Assessment - Douglas Hahn

This is the first time I have programmed in Entity Framework.  Also, before this project, I had never heard of Command Query Responsibility Segregation Pattern.  However, the concepts that I have discovered are interesting and I would like to learn how to implement these concepts better.
I'm particularly unsure about the correct way to implement DBContext.  I focused, instead, on making the screen functional.


Issues Found:

List of Canadian Provinces in the model was not correct.
All the data entry prompts allowed for unlimited characters.  This should be limited to make code injection more difficult.

Customer Name is limited to 75 characters.
Customer Name is required.

Customer Email is limited to 260 characters.  (Though this is the theoretical maximum for email addresses, this could be set to a much lower value.)
Customer Email is required.
Customer Email is validated according to RFC5322 rules.
Customer Email Error messages are greatly expanded.

Customer Phone is limited to 14 characters.
Customer Phone is required.
Customer Phone is formatted according to North American phone number rules (123) 456-7890
Customer Phone mask is added.
Customer Phone validation is added.

Customer Address is limited to 50 characters.
**Note Customer Address is not required because it is not needed in some small towns **

Customer City is limited to 50 characters.
Customer City is required.

Customer State Label is changed to "Province/Territory" for Canada
Customer State Label is changed to "State" for United States
Customer State showed the code and not the description.  (Code was 'NewBrunswick'.  Description was 'New Brunswick')

Customer State is required.
Originally, whenever you added a new customer, the state drop down list would add duplicate entries.

Customer Zip Label is changed to "Postal Code" for Canada
Customer Zip Label is changed to "Zip Code" for United States

Customer Zip is required.
Customer Zip is limited to 10 characters
Customer Zip A1B2C3 is reformatted to A1B 2C3
Customer Zip 123456789 is reformatted to 12345-6789

Customer Country is required.
Originally, whenever you added a new customer, the country drop down list would add duplicate entries.
Customer Country showed the code and not the description (Code was 'UnitedStates' description was 'United States')

Contact Name is limited to 100 characters.

Contact Email is limited to 260 characters.
Contact Email is validated according to RFC5322 rules.
Contact Email error messages are greatly expanded.

Contact Phone is limited to 14 characters.
Contact Phone is formatted according to North American phone number rules (123) 456-7890.
Contact Phone mask is added.
Contact Phone validation is added.

Contact Title is added onto the screen.  (It was in the data but not on the screen).
Contact Title is limited to 100 characters.
Contact Title is converted to proper case if it is all upper case or all lower case.

Contact Notes is added onto the screen.  (It was in the data but not on the screen).
Contact Notes is limited to 100 characters.

When you select an existing contact, the data is not displayed.  It should be displayed and two buttons should appear "Update" and "Delete" and the "Add" button should disappear.

There was no delete option.

There was a nomenclature issue with the CustomerService and CustomerRepository.  The file name was "CustomersService", but the class name was "CustomerService".  I left this the way it was, but when I made the CustomersServiceRead and CustomersServiceWrite I made the names using "Customers".


Enhancements:

Customer name is switched to proper case if all characters are either upper case or lower case.

Customer Phone is givien a mask to assist data entry.	

Customer Address is moved to be just before City to provide a more logical data flow.
Customer Address is switched to proper case if all characters are either upper case or lower case.

Customer City is switched to proper case if all characters are either upper case or lower case.


Limitations:

State, Zip/Postal Code, and Country are limited to Canada and United States
Phone numbers are limited to North American Phone Numbers


SOLID principles:

S - Single Responsibility Principle

There were three enums included in the Customer.cs file.  These were separated into their own file (EnumLists.cs)
Validations were placed in their own class
DataLength and DataType were placed in their own class
Move CustomerDBContext from Customer.cs to CustomerDBContext.cs

O - Open-closed Principle

Initially, I modified the Customer.cs file to add the validations, however, this would contradict the Open/Closed principle, so I restored the Customer.cs (except for the enums).
I left the Customer class but inherited it for the CustomerRead and CustomerWrite.

L - Liskov Substitution Principle

Not sure if there was an instance where this principle could be applied in this system.
I couldn't inherit the CustomersRepository when I was making CustomersRepositoryRead and CustomersRepositoryWrite
because we didn't want certain methods in the destination, for example, we didn't want Add, Update, and Delete in 
the Read Class.

I - Interface Segregation Principle

The Read and Write classes were separated to try and make them more efficient.

D  - Dependency Inversion Principle

Not sure that I implemented this principle.


Command Query Responsibility Segregation Pattern

I'm not sure that I accomplished the task you were wanting.  I did split the models, the services, and the repositories into read and write components.  Because the data is not written to a database, I'm not sure if it is working properly.  I need to learn more about this concept before I can implement it properly.
