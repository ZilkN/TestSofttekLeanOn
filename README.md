# TestSofttekLeanOn


Hello!,

Thank you for the test,


This code was made using .NET 5 and in a console program,


The design was made using an abstract factory so it can help me to extend the project if needed.

The product abstract class will be inherited by every type of the products that we need, so it can use the methods and 
creating a new product won't be an issue if the product requieres some extra especifications and we won't need to change the actual code.

For the taxes i used a strategy pattern to manage the taxes handling

It can be extended if a need tax calculation strategy is needed

As per configurations, i created an static class that will handle the "basic" configurations so anything is hardcoded on tye system.

Assumptions:
  1 - The product price can't be < 0
  2 - The product basket should not be empty
  3 - The product has to be "registered"
  
  
 Thank you!
