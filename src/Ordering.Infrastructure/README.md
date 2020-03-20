# Infrastructure Layer
This layer provides generic technical capabilities that support the higher layers: message sending for the application, persistence of the domain, drawing widgets for the UI , and so on.  The decoupling of the technical capabilities provides some added benefit by allowing the application layer to worry about *when* to perform a technical action instead of the *how*.

## Key Points
* The **infrastructure layer** should not initiate any actions in the **domain layer**.
* This layer should have no specific knowledge of the domain it is serving.
* Decoupling the technical concerns from the domain makes it easier to write unit tests for the domain layer as fewer items will have to be mocked.

## Components

### DbContexts

### Entity Type Configurations
**Entity Type Configurations** provide for a way to capture all of the configuration of an entity object within a single class.  The alternatives to this are to make use of *data annotations* or *fluent api* within the *OnModelCreating* method of the *DbContext* object.  The problem with data annotations is that it is not possible to take advantage of all of the entity features solely with them which can potentially put one in a situation where an entity model is configured using both data annotations and fluent api in the DbContent.  This disconnected scenario opens code up to the possibility of having conflicting configuration elements for a model.  It also means remembering to check multiple locations when confirming a configuration.  The problem with fluent api within a DbContext is that is easily becomes a rats news of code.

### Repositories

### Unit of Work



