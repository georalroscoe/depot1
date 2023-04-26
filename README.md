# depot1
A personal project which mimics the database requirements of running a warehouse, built with ASP.NET Core linked to a local SQL server. 

Includes a POST request which imitates the movement of warehouse batches between different locations. The input of a dto through the WebAPI using swagger is used with the parameters
of the quantity, old batch ID, manufactoring lot and new batch ID, which if left as 0 will create a new batch in the location specified of the 5th optional parameter, location ID.
The transaction follows ACID principles with the information being retrieved in the Productbatcher class in application file and all the business logic being pushed to the WarehouseBatch domain
to ensure clean domain-driven design architecture. 

Also includes a GET request which is intended to help a warehouse worker find all the products for a specific order, clearing out the batches containing the product with the lowest quantities first.
An order ID is passed through the WebAPI with the method GetOrderDetails() in the ProductFinder class of the application file invoked. LINQ queries are then used
to retreive all the relevant information from the database to be passed through to the domain layer (Product and CustomerOrder) where the business logic is applied and returns the neccessary information in a 
dto with embedded dto's to alert the worker of where to find the warehouse batches that contain the product required for the order.
