# CodeChallenge
Coding Challenge Submission For an Event Location System
 
 
 The Coding Challenge was completed in C# using .Net Framework 4.5.2
 The executable file is in the ViagogoChallenge\bin\Release folder.

Assumptions

When entering coordinates to search from, any coordinate can be entered – not just on map of locations. Validation checks are in place, and allow the user to proceed anyway. Simply finding the nearest event to the off-map coordinates they enter.

results are limited to 5 events, even if more than one event are the same distance away,

Assumed that there was currently no need for depleting the amount of tickets. but this could be easily added.

Questions

Q. How might you change your program if you needed to support multiple events at the same location? 

A. A Simple way of supporting multiple events in the same location would simply to have a 2d array of event lists. Each position in the array would have a list of events.
  
Q. How would you change your program if you were working with a much larger world size? 

A. For a larger world size I would more than likely be using a database backend in mysql. Sorting locations there for retrieval instead of an array structure. In this structure locations could be broken down into postcodes or smaller areas.

The array system works well when the events are not sparse, and most locations are filled. It allows for very fast retrieval of the nearest events simply by spiralling outward from a coordinate location. While the program as it stands works with any world size, it would become rather inneficient if the world was very sparse; especially in a large world as memory would be wasted storing empty cells.


I have created and run unit-tests for all classes, but if any errors have managed to sneak through, please let me know.
