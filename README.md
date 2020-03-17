# sample-application

## Features
### Layer Separation
 1. Presentation/API Layer
    * This layer is responsible for providing information to a user (or another system) and interpretting a user's/systems commands.
    * This is the "edge" layer.
 2. Application Layer
    * This purpose of this layer is to decouple the edge layer from the application.  In the event that you want to have multiple edge interfaces to the application they all simply need to make use of the application layer.
    * This layer is responsible for defining the jobs/tasks that the software is suppose to work out.  There is no business logic here.  This is a thin later that is responsible for coordinating tasks and delegating work to the domain objects in the next layer down.
 3. Domain Layer
    * This is the most critical part of the software.
    * Responsible for representing concepts of the business, information about the business situation, and business rules.
 4. Infrastructure Layer
    * Provides generic technical capabilities that support the higher layers.
      * Examples are:
        * Message sending for the application
        * Data persistance
        * Drawing widgets for the UI (I'm assuming this is for a service side application)


### Design Patterns Utilized
1. [Repository](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design)
   * 10 minute video tutorial on implementing the [Repository Pattern w/ Unit of Work](https://youtube.com/watch?v=rtXpYpZdOzM)
2. [Unit of work](https://www.martinfowler.com/eaaCatalog/unitOfWork.html)
 persisted.  persistance is managed by unitofwork.

## Notes
* Framework namespace in Domain project.
  * Evan 74
* Repository - Repositories are used to seperate the manipulation of entities (fix wording) from their persistance.  Changes in a repository are not

