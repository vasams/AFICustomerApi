# AfiCustomerApi
A .net core 3.1 REST Api with a single endpoint for registering a customer in SQL Serve Database. The Api makes use of entityframework core for persisting the data in to database. The Controller uses several Services in the services project for validating customer entity and transferring data into repositories. The Data project contains the DBContext for communicating with the Database and the Repository for Creating the specific user.
The Rest API contains one endpoint called api/AfiCustomer/RegisterCustomer. This takes a AfiCustomer Object as it argument.

The 'AfiCustomerApi' Solution is divided into four projects:
1. AfiCustomerApi: Contains the Controller class with above mentioned endpoint.The "Appsettings.Development" json file holds the     "ConnectionStrings" configuration for the Database.The name of the Configuration is "AfiCustomerDbString". It needs to be configured for  each individual machine. 
2. AfiCustomerApi.Data: Contains the Models,Repository and DBContext classes.The migrations specify an intial Identity value for the AfiCustomerID to be 1000.
3. AfiCustomerApi.Services: Contains the Validation service for the customer and the Customer Service for persisting the data in to
   database.Also, contains the migrations for the entities persisted into SQLServer instance.
4. AfiCustomerApiServicesTests: Contains the Validator service tests in xunit.Checks the Validation service for various scenarios.

Return Values from the RegisterCustomer endpoint:
1. The Api returns a newly generated ID of the Customer in the Database, if succesfully added in to the database.
2. The Api returns a value of -1, if validation of the Customer rules fail.
3. The Api returns a value of -2, if there is a problem in the creation of the Customer in the database. 
