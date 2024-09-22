create database Transport_Management
use Transport_Management

create table Vehicles( 
	VehicleID int identity(1,1) not null primary key,
	Model varchar(255),
	Capacity decimal(10,2),
	Type varchar(50),
	VehicleStatus varchar(50)
)

create table Routes( 
	RouteID int identity(1,1) not null primary key,
	StartDestination varchar(255),
	EndDestination varchar(255),
	Distance decimal(10,2),
)

create table Trips( 
	TripID int identity(1,1) not null primary key,
	VehicleID int foreign key(VehicleID)references Vehicles(VehicleID),
	RouteID int foreign key(RouteID)references Routes(RouteID),
	DepartureDate datetime,
	ArrivalDate datetime,
	VehicleStatus varchar(50),
	TripType varchar(50) DEFAULT 'Freight',
	MaxPassenger int
)

create table Passengers( 
	PassengerID int identity(1,1) not null primary key,
	FirstName varchar(255),
	Gender varchar(255),
	Age int,
	Email varchar(255) unique,
	PhoneNumber varchar(255)
)

create table Bookings(
	BookingID int identity(1,1) not null primary key,
	TripID int foreign key(TripID) references Trips(TripID),
	PassengerID int foreign key(PassengerID) references Passengers(PassengerID),
	BookingDate datetime,
	VehicleStatus varchar(50)
)
