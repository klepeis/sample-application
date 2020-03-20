# Infrastructure Layer
This layer provides generic technical capabilities that support the higher layers: message sending for the application, persistence of the domain, drawing widgets for the UI , and so on.  The decoupling of the technical capabilities provides some added benefit by allowing the application layer to worry about *when* to perform a technical action instead of the *how*.

## Key Points
* The **infrastructure layer** should not initiate any actions in the **domain layer**.
* This layer should have no specific knowledge of the domain it is serving.
* Decoupling the technical concerns from the domain makes it easier to write unit tests for the domain layer as fewer items will have to be mocked.


