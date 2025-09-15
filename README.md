SOLID:
1. BaseNameSorter is abstract and derives from INameSorter. BaseNameSorter cpntains some default implementation which is overridable.
2. Dependency inversion is used; for example the arguments to method SortNames are from abstract type so concrete type can be instantiated bt the clients 
3. Extending the solution would be via deriving from BaseNameSorter (and not midification of existing class), and overriding GetComparer




For ease of unit testing of IO files and also to follow SOLID, the arguments to SortNames method are from type Stream which is abstract 
so when unit testing we can pass an instance of MemoryStream instead of File Stream.
To unit test the Console SetOut method has been used.Alternatively we could create abstraction and use Moq. 


record data type has been used for Name which makes it immutable and easier for data handling.


