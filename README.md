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

## Lab 14
RoomAmenities
Add onto your RoomsController the ability to add and remove amenities to a specific room
Routes: POST/DELETE: [Route("{roomId}/Amenity/{amenityId}")]
Add to your IRoom Interface the method signatures to AddAmenityToRoom(int roomId, int amenityId) and RemoveAmentityFromRoom(int roomId, int amenityId)
Add the logic for the above methods into your RoomRepository.cs Service.
Add to your Room.cs, Amenity.cs, and RoomAmenity.cs file the navigation properties that we defined in your ERD.
On the Get() based call in your RoomRepository.cs and your ‘AmenityRepository.cs file, use the Include()` to populate the navigation property details within the return object.
HotelRoom
Create a new interface named IHotelRoom that contains basic CRUD operations for manipulating a HotelRoom.
Create a service named HotelRepository that implements the IHotelRoom interface. Add the logic for each of the methods to satisfy the CRUD operations on a HotelRoom.
Scaffold out a new HotelController that will inject the IHotelRoomInterface. Update/customize the logic to use the interface instead of the DBContext
Modify the routes of this controller for the following:
GET all the rooms for a hotel: /api/Hotels/{hotelId}/Rooms
POST to add a room to a hotel: /api/Hotels/{hotelId}/Rooms
GET all room details for a specific room: /api/Hotels/{hotelId}/Rooms/{roomNumber}
PUT update the details of a specific room: /api/Hotels/{hotelId}/Rooms/{roomNumber}
DELETE a specific room from a hotel: /api/Hotels/{hotelId}/Rooms/{roomNumber}

# Visual

![Diagram](/Diagram.jpg)

Versions:
1.8: *Added and tested HotelRoom class, interface, service and controller.* - July 30 2020
1.7: *Added a RoomAmenities class, added a Add Amenity and Remove Amenity methods on the Room Repo and added a POST and DELETE Method on the controller* - July 23, 2020
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
