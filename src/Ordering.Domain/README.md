# Domain Layer

# Exceptions
* Two different ways to handle exceptions.  TODO: Pick one or demo both.

## Aggregate
* Aggregate Boundaries serve as transactional boundaries.
* Aggregate maintains consistency - The state of ALL elements of the aggregate are validated across all operations executed on the aggregate.
  * The aggregate does not guarantee any consistency requirements external to the aggregate.  If working with a relational data model, it would mean that we cannot have referencial integrity between a table used to persist our aggregate root and anything that is outside of the aggregate boundary.
  * When using aggregates with a system using an ORM such as entity the best practice is not to maintain the DB Object references within the ORM as the ORM will not be responsible for traversing the objects. The aggregate will be used to traverse as well as to ensure data integrity. 