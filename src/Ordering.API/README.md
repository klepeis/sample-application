# API Project
The API Project is the "edge" of our application, that means that it is the publicly accessible entry point to interact with out application.  There can be multiple "edge" projects for any given application.  It depends on the number of ways you want to allow you application to be interacted with.

## API Request Models

### Application Layer

### POCOs (Plain-old C# Objects)
* A controller needs to accept strongly typed requests.  The models for these requests will be **POCOs** and stored in the **Contracts** folder.
* A **POCO**:
  *  Does not contain any business logic.
  *  Only contains primative types.
     *  Practically you can add a complex type to your **POCO** because in some cases the same type is used in multiple contracts.  Be aware though that the use of complex types can cause compatability issues since when you change the type all contacts that use it will also change.
     *  The **Application** layer (objects that implement IApplicationService) is responsible for translating the request in the API layer to a value object that can be used by the domain layer.
  *  Does not require any tricks to be serialized/deserialized.
* Some changes in a **POCO** type are considered non-breaking:
  * Changing property type so any value of the type that was used before can be serialized to the new type.  For example, we can change a property from being an integer to a string, and it will be compatible.
  * Adding a new property is also considered a non-breaking change.  This is because when we try to deserialize a JSON or XML object that does not have this new property because the sender hasn't updated their contract yet, most popular serializers will accept it and use the defailt value is the value is not supplied.

## POCO Versioning
* As our software evolves overtime breaking changes might have to be introduced which means that we will have to version our POCO objects to allow for different versions of an API to work at the same time.

** WRITE MORE HERE**
Packt 154


