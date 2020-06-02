# AfiCustomerApi
A .net core 3.1 rest API used for registering a customer with sqlserver local DB.

The Rest API contains one endpoint called api/AfiCustomer/RegisterCustomer. This takes a AfiCustomer Object as it argument.
The whole Solution is divided into four projects:
1. AfiCustomerApi:Contains the Controller class with above mentioned endpoint.The "Appsettings.Development" json file holds the "ConnectionStrings" configuration for the Database.The name of the Configuration is "AfiCustomerDbString". It needs to be configured for each individual machine. 
2. AfiCustomerApi.Data: Contains the Models,Repository and DBContext classes.
3. AfiCustomerApi.Services: Contains the Validation service for the customer and the Customer Service for persisting the data in to
   database.Also, contains the migrations for the entities persisted into SQLServer instance.
4. AfiCustomerApiServicesTests:Contains the Validator service tests in xunit.Checks the Validation service for various scenarios.
