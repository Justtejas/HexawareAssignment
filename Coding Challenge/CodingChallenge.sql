-- Coding Challenge	
create database CDC
use CDC

-- Vehicle
create table Vehicle(
	vehicleID int identity(1,1) not null primary key,
	make		varchar(255),
	model		varchar(255),
	[year]		int,
	dailyRate	decimal,
	[status]	int,
	passengerCapacity int,
	engineCapacity	int,
	Constraint chk_status check(status in(1,0))
)

-- Inserting values in Vehicle table
insert into Vehicle values ('Toyota', 'Camry',2022,50.00,1,4,1450),
('Honda', 'Civic',2023,45.00,1,7,1550),
('Ford', 'Focus',2022,48.00,0,4,1400),
('Nissan', 'Altima',2023,52.00,1,7,1200),
('Chevrolet', 'Malibu',2022,47.00,1,4,1800),
('Hyundai', 'Sonata',2023,49.00,0,7,1400),
('BMW', '3 Series',2023,60.00,1,7,2499),
('Mercedes', 'C-Class',2022,58.00,1,8,2599),
('Audi', 'A4',2022,55.00,0,4,2500),
('Lexus', 'ES',2023,54.00,1,4,2500)

-- Customer
create table Customer(
	CustomerId int identity(1,1) not null primary key,
	firstName varchar(50) not null,
	lastName varchar(50) not null,
	email varchar(50) not null unique,
	phoneNumber	varchar(20) unique
)

-- Inserting values in Customer table
insert into Customer values('John','Doe','johndoe@example.com','555-555-555'),
('Jane','Smith','janesmith@example.com','555-123-4567'),
('Robert','Johnson','robert@example.com','555-789-1234'),
('Sarah','Brown','sarah@example.com','555-456-7890'),
('David','Lee','david@example.com','555-987-6543'),
('Laura','Hall','laura@example.com','555-234-5678'),
('Michael','Davis','michael@example.com','555-876-5432'),
('Emma','Wilson','emma@example.com','555-432-1098'),
('William','Taylor','william@example.com','555-321-6547'),
('Olivia','Adams','olivia@example.com','555-765-4321')

-- Lease
create table Lease(
	leaseID int identity(1,1) not null primary key,
	vehicleID int foreign key(vehicleID) references Vehicle(vehicleID) on delete cascade,
	CustomerID int foreign key(CustomerID) references Customer(CustomerID) on delete cascade,
	startDate date,
	endDate date,
	type varchar(15)
)

-- Inserting values into Lease table
insert into Lease values(1,1,'2023-01-01','2023-01-05','Daily'),
(2,2,'2023-02-15','2023-02-28','Monthly'),
(3,3,'2023-03-10','2023-03-15','Daily'),
(4,4,'2023-04-20','2023-04-30','Monthly'),
(5,5,'2023-05-05','2023-05-10','Daily'),
(3,3,'2023-06-15','2023-06-30','Monthly'),
(7,7,'2023-07-01','2023-07-10','Daily'),
(8,8,'2023-08-12','2023-08-15','Monthly'),
(3,3,'2023-09-07','2023-09-10','Daily'),
(10,10,'2023-10-10','2023-10-31','Monthly')

update Lease
set vehicleID=4
where leaseID=6


-- Payment
create table Payment(
	paymentID int identity(1,1) not null primary key,
	leaseID int foreign key(leaseID) references Lease(leaseID) on delete cascade,
	paymentDate date,
	amount decimal
)

-- Inserting values into Payment table
insert into Payment values(1,'2023-01-03',200.00),
(2,'2023-02-20',1000.00),
(3,'2023-03-12',75.00),
(4,'2023-04-25',900.00),
(5,'2023-05-07',60.00),
(6,'2023-06-18',1200.00),
(7,'2023-07-03',40.00),
(8,'2023-08-14',1100.00),
(9,'2023-09-09',80.00),
(10,'2023-10-25',1500.00)

select * from Payment
select * from Customer
select * from Lease
select * from Vehicle

-- Questions

-- From the lease table pick the monthly leases and print it

select make
from Vehicle
where vehicleID in (select vehicleID from Lease where [type] = 'Monthly')
-- 1. Update the daily rate for a Mercedes car to 68.
select * from Vehicle
update Vehicle
set dailyRate = 68
where make = 'Mercedes'
-- 2. Delete a specific customer and all associated leases and payments.
declare @customerToDelete int = 4
delete from Customer where CustomerId = @customerToDelete
-- 3. Rename the "paymentDate" column in the Payment table to "transactionDate".
exec sp_rename 'Payment.paymentDate', 'transactionDate', 'COLUMN'
select * from Payment
-- 4. Find a specific customer by email.
declare @emailToSearch varchar(50)= 'janesmith@example.com'
select * from Customer where email= @emailToSearch
-- 5. Get active leases for a specific customer.
declare @customerIdToSearch int = 5
Select * from Lease
where endDate > '2023-05-07' and startDate < '2023-05-07' and CustomerID = @customerIdToSearch

-- 6. Find all payments made by a customer with a specific phone number.
declare @phoneNumberToSearch varchar(20) = '555-555-555'
select *
from Payment
where leaseID in (
	select leaseID
	from Lease
	where CustomerID in (
		select CustomerID
		from Customer
		where phoneNumber = @phoneNumberToSearch
	)
)
-- 7. Calculate the average daily rate of all available cars.
select AVG(dailyRate) as [Average Daily Rate]
from Vehicle
group by status
having [status] = 1
-- 8. Find the car with the highest daily rate.
select *
from Vehicle
where dailyRate = ( select MAX(dailyRate) from Vehicle)
-- 9. Retrieve all cars leased by a specific customer.
declare @customerIdToFind int = 7
select vehicleID,make,model
from Vehicle
where vehicleID in (select vehicleID from Lease where CustomerID = @customerIdToFind)
-- 10. Find the details of the most recent lease.
select *
from Lease
where startDate = (select MAX(startDate) from Lease)
-- 11. List all payments made in the year 2023.
select *
from Payment
where YEAR(transactionDate) = '2023'
-- 12. Retrieve customers who have not made any payments.
select *
from Customer
where CustomerId not in (
	select CustomerId from Lease 
)
-- 13. Retrieve Car Details and Their Total Payments.
select *
from Vehicle v
join
	(select l.vehicleID ,SUM(p.amount) as [Total Payments]
		from Lease l join Payment p
		on l.leaseID = p.leaseID
		group by l.vehicleID
	)pm
on v.vehicleID = pm.vehicleID


-- 14. Calculate Total Payments for Each Customer.
select c.CustomerId, SUM(amount) as [Total Amount]
from Customer c
join 
Lease l
on c.CustomerId = l.CustomerID
join Payment p
on p.leaseID = l.leaseID
group by c.CustomerId
-- 15. List Car Details for Each Lease.
select *
from Vehicle
where vehicleID in (select vehicleID from Lease)
-- 16. Retrieve Details of Active Leases with Customer and Car Information.
select l.* , c.*, v.*
from Lease l
join 
Customer c
on l.CustomerID = c.CustomerId
join
Vehicle v
on v.vehicleID = l.vehicleID
where l.endDate > '2023-05-07' and l.startDate < '2023-05-07'
-- 17. Find the Customer Who Has Spent the Most on Leases.
select top 1 l.CustomerID, SUM(amount) as [Total Amount]
from Lease l
join Payment p
on l.leaseID = p.leaseID
group by l.CustomerID
order by [Total Amount] desc
-- 18. List All Cars with Their Current Lease Information.
select v.*, l.leaseID, l.startDate, l.endDate
from Vehicle v
join 
Lease l
on l.vehicleID = v.vehicleID

