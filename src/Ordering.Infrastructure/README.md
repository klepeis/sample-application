# Infrastructure Layer
This layer provides generic technical capabilities that support the higher layers: message sending for the application, persistence of the domain, drawing widgets for the UI , and so on.  The decoupling of the technical capabilities provides some added benefit by allowing the application layer to worry about *when* to perform a technical action instead of the *how*.

## Key Points
* The **infrastructure layer** should not initiate any actions in the **domain layer**.
* This layer should have no specific knowledge of the domain it is serving.
* Decoupling the technical concerns from the domain makes it easier to write unit tests for the domain layer as fewer items will have to be mocked.

## Components

### DbContexts
The DbContexts are the objects that bind together all of the configuration elements of the Entity Framework to make data access possible.  This should not be a new concept to anyone who has worked with on our NextGen platform so I am not going to detail. I will say that as of this writing any reference to Entity Framework is geared towards Entity Framework Core 3.1.

### Entity Type Configurations
**Entity Type Configurations** are not new to Entity Framework (EF).  They were present in EF 6.x, did not make the cut for EF Core 1.x, but made a return in EF Core 2.x+.  They provide for a way to capture all of the configuration of an entity object within a single class.  The alternatives to this are to make use of *data annotations* or *fluent api* within the OnModelCreating method of the DbContext object.  The problem with *data annotations* is that it is not possible to take advantage of all of the entity features solely with them which can potentially create a situation where an entity model is configured using both *data annotations* and *fluent api* in the DbContent.  This disconnected scenario opens code up to the possibility of having conflicting configuration elements for a model.  It also means remembering to check multiple locations when confirming a configuration.  The problem with *fluent api* within a DbContext is that is easily becomes a rats news of code.

This [site](http://anthonygiretti.com/2018/01/11/entity-framework-core-2-entity-type-configuration/) provides a simple example as to how to work with Entity Type Configurations.

### Repositories and Unit Of Work

The **repositories** and the **unit of work** objects are stored in the **infrastructure layer**.  A **repository** provides access to retrieve an object from a data store and modify its values in memory, ***but not persist the changes to the store***.  In the past if we had to update multiple database records as part of an operation we would create a stored procedure or use Entity to handle this complex action one record at a time.  This is where **unit of work** comes into play.  **Unit of work** allows us to manipulate multiple records in a given context in memory and then once all of the necessary updates have been made commit the changes to the store.

The above provides a very high level overview of repositories and unit of work.  Having a solid understanding of these concepts is vital to understanding how data gets retrieved and persisted.  For additional understanding please see the link to a short video located in the README at the root of this repository.


