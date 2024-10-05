create database Insurance_Management;
use Insurance_Management;

create table Users(
	UserID int identity(1,1) primary key,
	Username varchar(30) unique not null,
	[password] varchar(30) not null,
	[role] varchar(30) not null
)

create table Policies(
	PolicyID int identity(1,1) primary key,
	PolicyNumber varchar(50) not null unique,
	PolicyType	varchar(50) not null,
	AmountCovered decimal not null,
	StartDate date not null,
	EndDate date not null
)

create table Clients(
	ClientID int identity(1,1) primary key,
	ClientName varchar(50) not null,
	ContactInfo varchar(50) unique not null,
	PolicyID int foreign key(PolicyID) references Policies(PolicyID) on delete cascade on update cascade
)

create table Claims(
	ClaimID int identity(1,1) not null primary key,
	ClaimNumber int not null unique,
	DateFiled Date default GETDATE(),
	ClaimAmount decimal not null,
	[Status] varchar not null,
	PolicyID int foreign key(PolicyID) references Policies(PolicyID),
	ClientID int foreign key(ClientID) references Clients(ClientID) on delete cascade on update cascade,
	Constraint chk_Status check([Status] in ('Claimed','Unclaimed'))
)

create table Payments(
    PaymentId int identity(1,1) primary key,
    PaymentDate date not null,
    PaymentAmount decimal not null,
    ClientID int not null,
    foreign key(ClientID) references Clients(ClientID)
        on delete cascade
        on update cascade
);