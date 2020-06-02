# AfiCustomerApi
A .net core 3.1 rest API used for registering a customer with sqlserver local DB.

The Rest API contains one endpoint called api/AfiCustomer/RegisterCustomer. This takes a AfiCustomer Object as it argument.
The whole Solution is divided into four projects:
1. AfiCustomerApi:Contains the Cotroller class.
2. AfiCustomerApi.Data: Contains the Models,Repository and DBContext classes.
3. AfiCustomerApi.Services: Contains the Validation service for the customer and the Customer Service for persisting the data in to
   database.
4. AfiCustomerApiServicesTests:Contains the Validator service tests in xunit.Checks the Validation service for various scenarios.
