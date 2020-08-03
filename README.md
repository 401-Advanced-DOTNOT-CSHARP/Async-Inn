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

## Lab 16

Add onto your current Async Inn application by cleaning up input and outputs of your controllers to be DTOs.

In addition, add tests to a single service. If you have time, test the other services.

Hint: Order you should consider building your DTOs: DTOs stand for data trasfer objects

Amentities,
Rooms
HotelRooms
Hotels
Routes and Responses
HotelsController
Route (GET): api/Hotels/{id}:

Here is the expected output when calling Hotels:

{
    "id": 1,
    "name": "My really cool Hotel",
    "streetAddress": "123 CandyCane Lane",
    "city": "Seattle",
    "state": "WA",
    "phone": "123-456-8798",
    "rooms": [
        {
            "hotelID": 1,
            "roomNumber": 101,
            "rate": 75.00,
            "petFriendly": false,
            "roomID": 2,
            "room": {
                "id": 2,
                "name": "Queen Suite",
                "layout": "TwoBedroom",
                "amenities": [
                    {
                        "id": 1,
                        "name": "Coffee Maker"
                    },
                    {
                        "id": 2,
                        "name": "Mini Bar"
                    }
                ]
            }
        },
        {
            "hotelID": 1,
            "roomNumber": 123,
            "rate": 120.00,
            "petFriendly": true,
            "roomID": 1,
            "room": {
                "id": 1,
                "name": "Princess Suite",
                "layout": "OneBedroom",
                "amenities": [
                    {
                        "id": 1,
                        "name": "Coffee Maker"
                    },
                    {
                        "id": 2,
                        "name": "Mini Bar"
                    }
                ]
            }
        }
    ]
}
Route: (GET) : ‘api/Hotels’

An array of individual hotels. (See result from api/Hotels/{id})
HotelRooms Controller
Route: (Get/Put/Delete) : /api/Hotels/{hotelId}/Rooms/{roomNumber}

This is the HotelRooms Controller
Create, Read, Update, Delete a hotel room
THe PUT request will include the HotelRoomDTO in the incoming request from the client
Route: (Get/Post) : /api/Hotels/{hotelId}/Rooms

Get all the rooms for a hotel
Add a single room to a hotel
When adding a room, the HotelRoomDTO will be the incoming request from the client
{
    "hotelID": 1,
    "roomNumber": 101,
    "rate": 75.00,
    "petFriendly": false,
    "roomID": 2,
    "room": {
        "id": 2,
        "name": "Queen Suite",
        "layout": "TwoBedroom",
        "amenities": [
            {
                "id": 1,
                "name": "Coffee Maker"
            },
            {
                "id": 2,
                "name": "Mini Bar"
            }
        ]
    }
}
Rooms Controller
Route (Get/Put) : api/rooms/{roomId}

Get a specific room
Update a room
{
    "id": 1,
    "name": "Princess Suite",
    "layout": "OneBedroom",
    "amenities": [
        {
            "id": 1,
            "name": "Coffee Maker"
        },
        {
            "id": 2,
            "name": "Mini Bar"
        }
    ]
}
Route: (GET/POST) : api/rooms/

Get an array of RoomDTO objects
refer to request above for formatting
Post request will create a new room
Post request will have the room DTO included in request
Amenities Controller
Route: (Get) api/amenities/{id}

Get specific amenity
{
    "id": 1,
    "name": "Coffee Maker"
}
Route: (GET/POST) - api/amenities/

Get all Amenities
Response will be an array of amenities
Post is adding a new general amenity
Post will include the Amenities DTO in the request
Guidance
Create DTOs that will be accepted and returned to the user:

    public class HotelDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public List<HotelRoomDTO> Rooms { get; set; }
    }


    public class HotelRoomDTO
    {
        public int HotelID { get; set; }
        public int RoomNumber { get; set; }
        public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }
        public int RoomID { get; set; }
        public RoomDTO Room { get; set; }
    }

    public class RoomDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Layout { get; set; }
        public List<AmenityDTO> Amenities { get; set; }
    }

    public class AmenityDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

## Lab 17 - DTOs and Routing

Building off of your Async Inn API, integrate identity by completing the following:

Create an Applicaiton User ApplicationUser:IdentityUser
Update your DbContext to derive from `IdentityDbContext
Update your database to integrate in the Identity database tables
Register Identity into your Startup file services.AddIdentity....
Create an Account Controller and add both Register and Login actions
Confirm that you can register a user successfully in the database
Confirm that you can login with the credentials of an existing user

# Visual

![Diagram](/Diagram.jpg)

Versions:
2.1: *Added the ability to create a user and Login with a created user. Did this by installing Identity on the data file
        and inheriting from the Identity instead of DBContext. This created 7 more tables inside the database. Then I added
        a register and login DTO files to use as a basis for creating the user and loggin in the user in the 2 different POST routes
        I then created a controller with 2 POST routes 1 for registering a user and 1 for logging a user in.* - August 2 2020
2.0: *Created DTO class, modified the Interfaces to take in and output DTO classes, modified the services 
        to convert DTO objects to their normal object counterparts and then return the DTO object while passing
        the normal object to the database. Modified the controllers to intake DTO objects with the correct routing* August 1 2020
1.9: *Added summary Comments to Interfaces and Services* - August 1 2020
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
