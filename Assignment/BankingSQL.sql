create database HMBank
use HMBank

create table Customers(
	customerID int identity(1,1) not null primary key,
	first_name varchar(255) not null,
	last_name varchar(255) not null,
	DOB date not null,
	email varchar(255) unique not null,
	phone_number varchar(255) unique not null,
	address text not null
)

create table Accounts(
	accountID int identity(1,1) not null primary key,
	customerID int not null,
	account_type varchar(255) not null,
	balance decimal(18,2) not null,
	Constraint FK_Customers_Accounts FOREIGN KEY (customerID) references Customers(customerID)
)

create table Transactions(
	transactionID int identity(1,1) not null primary key,
	accountID int not null,
	transaction_type varchar(255) not null,
	amount decimal(18,2) not null,
	transaction_date datetime not null DEFAULT GETDATE()
	Constraint FK_Account_Transactions FOREIGN KEY (accountID) References Accounts(accountID)
)


-- Task 2.1
-- Inserting values
Insert into Customers values('Ajay','Patil','2002-06-04','ajay@gmail.com','9876787689','Ooty'),
('Tejas','Pantoji','2002-04-23','tejas@gmail.com','9876833499','Pune'),
('Amol','Ajari','2002-09-22','amol@gmail.com','9878678543','Kolhapur'),
('Amaan','Attar','2001-12-09','amaan@gmail.com','7685790987','Pune'),
('Prathmesh','Parit','2002-02-02','parit@gmail.com','8798065643','Chennai'),
('Niraj','Joshi','2002-09-11','niraj@gmail.com','7656784590','Mumbai'),
('Yash','Rane','2002-09-20','yash@gmail.com','5678987678','Delhi'),
('Sneha','Murthy','2002-04-08','sneha@gmail.com','9089876754','Banglore'),
('Shruti','Singh','2002-03-04','shruti@gmail.com','9789065789','Delhi'),
('Harsh','Sinha','2002-06-08','harsh@gmail.com','0989765890','Banglore'),
('Krish','Shah','2002-12-07','krish@gmail.com','0989765678','Surat')

Insert into Accounts values(1,'savings',1600.00),
(1,'current',2100.00),
(2,'savings',1200.00),
(3,'savings',5000.00),
(4,'savings',12000.00),
(4,'current',2100.00),
(5,'savings',50000.00),
(6,'savings',65000.00),
(7,'savings',56000.00),
(7,'current',3400.00),
(8,'savings',22000.00),
(9,'savings',35000.00),
(10,'savings',46000.00)

Insert into Transactions values(1, 'deposit', 500.00, '2023-09-01'),
(1, 'withdrawal', 200.00, '2023-09-10'),
(2, 'deposit', 1000.00, '2023-09-05'),
(3, 'withdrawal', 50.00, '2023-09-12'),
(4, 'deposit', 600.00, '2023-09-15'),
(5, 'withdrawal', 100.00, '2023-09-17'),
(6, 'deposit', 250.00, '2023-09-20'),
(7, 'withdrawal', 75.00, '2023-09-22'),
(8, 'deposit', 300.00, '2023-09-25'),
(9, 'withdrawal', 150.00, '2023-09-30');

-- Selecting values
select * from Customers
select * from Accounts
select * from Transactions

exec sp_rename 'Transactions.accountID' , 'account_id' , 'COLUMN'

alter table Customers
alter column address varchar(255)
-- Task 2.2 
-- 1. Write a SQL query to retrieve the name, account type and email of all customers. 
select concat(c.first_name ,' ' , c.last_name) as name,
a.account_type, c.email
from
Customers as c
join
Accounts as a
on c.customer_id = a.customer_id


-- 2. Write a SQL query to list all transaction corresponding customer.
select 
C.customer_id,
C.first_name,
C.last_name,
A.account_id,
A.account_type,
T.transaction_id,
T.transaction_type,
T.amount,
T.transaction_date
from
Transactions T
join 
Accounts A on T.account_id = A.account_id
join
Customers C on A.customer_id = C.customer_id
order by 
T.transaction_date;
-- 3. Write a SQL query to increase the balance of a specific account by a certain amount.
update Accounts
set balance = 0
where account_id = 13
-- 4. Write a SQL query to Combine first and last names of customers as a full_name.
select concat(first_name, ' ', last_name) as full_name
from Customers
-- 5. Write a SQL query to remove accounts with a balance of zero where the account type is savings.
delete from Accounts
where balance=0 and account_type='savings'
-- 6. Write a SQL query to Find customers living in a specific city.
select concat(first_name, ' ', last_name) as full_name
from Customers
where [address] = 'Pune'
-- 7. Write a SQL query to Get the account balance for a specific account.
select balance
from Accounts
where account_id=1
-- 8. Write a SQL query to List all current accounts with a balance greater than $1,000.
select *
from Accounts
where balance > 1000 and account_type = 'current'
-- 9. Write a SQL query to Retrieve all transactions for a specific account. 
select * 
from Transactions
where account_id = 5
-- 10. Write a SQL query to Calculate the interest accrued on savings accounts based on a given interest rate.
declare @interest_rate int = 5
select account_id, account_type, balance, (balance * @interest_rate / 100) as Accrued_Interest
from Accounts
where account_type = 'savings'
-- 11. Write a SQL query to Identify accounts where the balance is less than a specified overdraft limit.
declare @overdraft_limit int = 20000
select * 
from Accounts
where balance < @overdraft_limit
-- 12. Write a SQL query to Find customers not living in a specific city
select *
from Customers
where address != 'Mumbai'


-- Tasks 3: Aggregate functions, Having, Order By, GroupBy and Joins:
-- 1. Write a SQL query to Find the average account balance for all customers.
select c.first_name, c.last_name ,AVG(a.balance) as [Average]
from Accounts a
join 
Customers c
on a.customer_id = c.customer_id
group by c.first_name, c.last_name, c.customer_id
-- 2. Write a SQL query to Retrieve the top 10 highest account balances.
select top 10 balance
from Accounts
order by balance desc
-- 3. Write a SQL query to Calculate Total Deposits for All Customers in specific date.
select transaction_date, SUM(amount) as [Total Deposit]
from Transactions
where transaction_type = 'deposit' and transaction_date = '2023-09-01'
group by transaction_date
-- 4. Write a SQL query to Find the Oldest and Newest Customer

SELECT TOP 1 * FROM Customers 
ORDER BY customer_id ASC -- oldest

SELECT TOP 1 * FROM Customers
ORDER BY customer_id DESC -- newest
-- 5. Write a SQL query to Retrieve transaction details along with the account type.
declare @acc_type varchar(20) = 'current'
select t.*, a.account_type
from Transactions t
join
Accounts a
on t.account_id = a.account_id and a.account_type = @acc_type

-- 6. Write a SQL query to Get a list of customers along with their account details.
select c.customer_id, CONCAT(c.first_name,' '  ,c.last_name) as [Name], a.*
from Customers c
right join
Accounts a
on c.customer_id = a.customer_id

-- 7. Write a SQL query to Retrieve transaction details along with customer information for a
-- specific account.
select t.*, c.*
from Transactions t
join 
Accounts a
on a.account_id = t.account_id
join
Customers c
on c.customer_id = a.customer_id
where a.account_id = 4
-- 8. Write a SQL query to Identify customers who have more than one account.
select customer_id, COUNT(account_id) as [Number of Accounts]
from Accounts a
group by customer_id
having COUNT(account_id) > 1

-- 9. Write a SQL query to Calculate the difference in transaction amounts between deposits and
-- withdrawals.
select 
(select SUM(amount) from Transactions where transaction_type = 'deposit') - 
(select SUM(amount) from Transactions where transaction_type = 'withdrawal')
AS Differences

-- 10. Write a SQL query to Calculate the average daily balance for each account over a specified
-- period.
select A.account_id, AVG(balance) as AverageDailyBalance
from Accounts A
join 
Transactions T
on A.account_id = T.account_id
where T.transaction_date between '2023-09-02' and '2023-11-06'
group by A.account_id
-- 11. Calculate the total balance for each account type.
select AVG(balance) as [Average Balance], a.account_id
from Accounts a
join 
Transactions t
on a.account_id = t.account_id
where transaction_date between '2023-09-01' and '2023-09-20'
group by a.account_id
-- 12. Identify accounts with the highest number of transactions order by descending order.
select COUNT(transaction_id) as [Number of Transactions], account_id
from Transactions
group by account_id
order by COUNT(transaction_id) desc
-- 13. List customers with high aggregate account balances, along with their account types.
select c.customer_id,c.first_name, c.last_name,a.account_type, SUM(a.balance) as [Aggregate Balance]
from Customers c
join 
Accounts a
on a.customer_id = c.customer_id
group by c.customer_id, c.first_name, c.last_name, a.account_type
order by [Aggregate Balance] desc

-- 14. Identify and list duplicate transactions based on transaction amount, date, and account.
select account_id, amount, transaction_date
from Transactions
group by account_id, amount, transaction_date
having COUNT(*) > 1
order by amount, transaction_date, account_id


-- Tasks 4: Subquery and its type:
-- 1. Retrieve the customer(s) with the highest account balance.
select concat(c.first_name, ' ' , c.last_name) as [Name], a.account_id, a.balance as [Highest Balance]
from Customers c
join
Accounts a
on a.customer_id = c.customer_id
where a.balance = (select MAX(balance) from Accounts)

-- 2. Calculate the average account balance for customers who have more than one account.
select AVG(balance) as [Average account balance]
from Accounts 
where customer_id in (
	select customer_id
	from Accounts
	group by customer_id
	having count(account_id) > 1
)
-- 3. Retrieve accounts with transactions whose amounts exceed the average transaction amount.
select amount, account_id
from Transactions
where amount > (select AVG(amount) from Transactions)
-- 4. Identify customers who have no recorded transactions.
select customer_id, CONCAT(first_name,' ',last_name) as [Name] FROM Customers
where customer_id in(
	select customer_id from Accounts
	where account_id not in(
		select account_id from Transactions
	)
)
group by customer_id, first_name, last_name
-- 5. Calculate the total balance of accounts with no recorded transactions.
select sum(balance) as [Total Balance], account_id
from Accounts
where account_id not in (select account_id from Transactions)
group by account_id
-- 6. Retrieve transactions for accounts with the lowest balance.
select *
from Transactions
where account_id in (
	select account_id from Accounts
	where balance = (
		select min(balance) from Accounts
	)
) 
-- 7. Identify customers who have accounts of multiple types.
select *
from Customers
where customer_id in (
	select customer_id from Accounts
	group by customer_id
	having COUNT(customer_id) > 1
) 
-- 8. Calculate the percentage of each account type out of the total number of accounts.
select account_type, COUNT(*) * 100 / (select COUNT(*) from Accounts) as [Percentage of each account type] 
from Accounts
group by account_type

-- 9. Retrieve all transactions for a customer with a given customer_id.
select * 
from Transactions
where account_id in (
	 select account_id from Accounts
	 where customer_id in (
		select customer_id from Customers
	 ) and customer_id = 3
)
-- 10. Calculate the total balance for each account type, including a subquery within the SELECT
-- clause
select account_type, (select sum(balance) from Accounts where account_type = a.account_type) as [Total Balance]
from Accounts a
group by account_type