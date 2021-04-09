# NBCexample
Code example project for Nebraska Book Company. Products have a name, id, created date, and price. When a new product is created, or a product is updated, a Price History record is created that stores product id, change date, and the new price.

Coded against SQLite database, but underlying database should be able to be swapped by changing the `services.AddDbContext<ProductContext>` in Startup.cs. When run, data is written/retrieved from the SQLite db file `Data.db`. Running the TableCreation.sql on the Data.db database will drop/recreate the tables to reset the data.

Swagger API documentation can be found at https://localhost:5001/swagger when app is running. API can be tested via the Try It Out buttons there, otherwise the endpoints are all found starting at https://localhost:5001/api/Products
* GET ​/api​/Products
    - Retrieve full list of products
* POST ​/api​/Products
    - Create a new product
* GET ​/api​/Products​/{id}
    - Retrieve a single product by ID
* PUT ​/api​/Products​/{id}
    - Update a product
* DELETE ​/api​/Products​/{id}
    - Delete a product
* GET ​/api​/Products​/{id}​/priceHistory
    - Retrieve price history for a product


### Resources
* .gitignore taken from https://github.com/github/gitignore/blob/master/VisualStudio.gitignore
* Project structure created using `dotnet new webapi` and `dotnet aspnet-codegenerator`
* Visual Studio Code used as IDE
* Postman used for testing API

