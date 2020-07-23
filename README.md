# Async-Inn
Author: Bryant Davis
Collaborators: Nicholas Ryan, Bade Habib

# Domain Problem

## Lab11
https://docs.google.com/document/d/1nppbXbjYCOY2yeuyXozYDU2KQVrGXcFB8_k19UAyZWs/edit?usp=sharing

## Lab12
Gievn your ERD create models, a database, tables, properties that reflect the ERD. Setup a server that you can use CRUD from and test to ensure 
these all work through POSTMAN.

## Lab 13
Using Dependency Injection, refactor your Hotels, Rooms, and Amenities Controllers to depend on an interface rather than the dbcontext.

Build an interface for each of the controllers that contain the required method signatures to all for CRUD operations to the database directly

Update each of the controllers to inject the interface rather than the DBContext

Create a service for each of the controllers that implement the appropriate interface. Build out the logic to satisfy the interface by making the appropriate calls to the db for each action.

Update your Controller to use the appropraite methosd from the interface rather than the DBContext direclty.

Confirm in POSTMAN that your controllers are returning the same logic as they did in Lab 12.

# Visual

![Diagram](/Diagram.jpg)

Versions:
1.6: *Added Interfaces for Amenity, Hotel and Room, added 3 services for each, updated all 3 
controlelrs, updated startup and then tested each route with postman* July 22 2020
1.5: *Tested in POSTMAN for CRUD - was a success* - July 21 2020
1.4: *Added two classes Room and Amenity and added them to the data file and the database* - July 21 2020
1.3: *Added controllers for Hotel, Amenity, Room* - July 21 2020
1.2: *Added two classes Room and Amenity and added them to the data file and the database* - July 21 2020
1.1: *Inital push of code:
	* Setup the server
	* Created the Hotel Model
	* Migrated and updated the database with the Hotel model* - July 21 2020
	
1.0: *Created Diagram and README* - July 20 2020
