# Framework Project
This project contains a set of base classes and interfaces to support the DDD architectural framework.  The framework components can be unique to the needs of each application which is why it is not a nuget package.

## Key Points

### Entity Base Class
The **Entity** base class contains an Id property as each entity is required to have a unique identifier. 

TODO: Should the Entity Base Class contain an equality override?

### ValueObject Base Class
Unlike an **entity** that is only concerned with are the id's the same to determine equality a **value object** actually compares all of the properties in an object to determine equality.  The **ValueObject** base class provides a common set of methods for performing these equality operations.

