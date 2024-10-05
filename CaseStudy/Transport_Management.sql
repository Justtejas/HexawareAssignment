create database Transport_Management
use Transport_Management

create table Vehicles( 
	VehicleID int identity(1,1) not null primary key,
	Model varchar(255),
	Capacity decimal(10,2),
	Type varchar(50),
	VehicleStatus varchar(50)
)
create table Drivers(
	DriverID int identity(1,1) not null primary key,
	TripID int foreign key(TripID) references Trips(TripID) on delete cascade on update cascade,
	name varchar(25) not null,
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

exec sp_rename 'Bookings.VehicleStatus', 'BookingsStatus', 'COLUMN' 

alter table Trips
Add constraint FK_Trips_Drivers
foreign key (DriverID)
references Drivers(DriverID)

-- Inserting sample values
insert into Drivers values(1,'Akash');
-- Vehicles

Insert into Vehicles values('Ford Transit',10.00,'Van','On Trip'),
('Mercedes Actros', 25.00, 'Truck', 'On Trip'),
('Volvo Bus 9700', 50.00, 'Bus', 'Maintenance')

-- Routes

Insert into Routes values('Mumbai', 'Delhi', 1392.00),
('Hyderabad', 'Banglore', 574.00),
('Banglore', 'Chennai', 346.00);

-- Trips 

insert into Trips values(1, 1, '2024-09-22 08:00:00', '2024-09-24 14:00:00', 'Scheduled', 'Passenger', 8),
(2, 2, '2024-09-23 06:30:00', '2024-09-24 12:30:00', 'In Progress', 'Freight', NULL),
(3, 3, '2024-09-25 09:00:00', '2024-09-26 18:00:00', 'Scheduled', 'Passenger', 45);

-- Passengers

insert into Passengers values('Tejas', 'Male', 22, 'tejas@gmail.com', '9897980978'),
('Sneha', 'Female', 23, 'sneha@gmail.com', '8907898900'),
('Prathmesh', 'Male', 21, 'prath@gmail.com', '9878690899');

-- Bookings

insert into Bookings values(1, 1, '2024-09-20 10:00:00', 'Confirmed'),
(1, 2, '2024-09-21 14:00:00', 'Confirmed'),
(3, 3, '2024-09-22 09:00:00', 'Cancelled');

update Drivers set TripID = null where DriverID = 1
select * from Vehicles where VehicleID = 2;
select * from Routes
select * from Trips 
select * from Drivers where TripID IS NULL
select * from Passengers
select * from Bookings


Alter database [Transport_Management] Modify name = [Transport_Management_Test]