create database Inventory
go

use Inventory

go
create schema Product

go
create schema Customer

go
create schema Purchase

go
create table Product.Product(
ProductId int identity(1,1),
Name nvarchar(500),
Description nvarchar(1000),
Price decimal(18,2),
DiscountRange decimal(18,2),
constraint PK_Product primary key(ProductId))

go
create table Customer.Customer(
CustomerId int identity(1,1),
Name nvarchar(200),
Address nvarchar(500),
ContactNo nvarchar(20),
constraint PK_Customer primary key(CustomerId))

go
create table Purchase.PurchaseOrder(
POID int identity(1,1),
CustomerId int,
Date date,
Amount decimal(18,2),
constraint PK_Purchase primary key(POID),
constraint FK_Customer foreign key(CustomerId) references Customer.Customer(CustomerId))

go
create table Purchase.PurchaseOrderDetails(
PODID int identity(1,1),
OID int,
ProductId int,
Price decimal(18,2),
qty int,
constraint PK_PurchaseOrderDetails primary key(PODID),
constraint FK_Purchase foreign key(OID) references Purchase.PurchaseOrder(POID),
constraint FK_Product foreign key(ProductId) references Product.Product(ProductId))

select * from Product.Product
select * from Customer.Customer
select * from Purchase.PurchaseOrder
select * from Purchase.PurchaseOrderDetails

--2
select DATENAME(month,Date) Month,C.Name,Amount from Purchase.PurchaseOrder PO
join Customer.Customer C on PO.CustomerId = C.CustomerId

--3
select name from Product.Product order by Name asc

--4
select DATENAME(month,Date) Month,P.Name,qty from Purchase.PurchaseOrder PO
join Purchase.PurchaseOrderDetails POD on PO.POID = POD.OID
join Product.Product P on POD.ProductId = P.ProductId

--5
select DATENAME(month,Date) Month,POID,Price from Purchase.PurchaseOrder PO
join Purchase.PurchaseOrderDetails POD on PO.POID = POD.OID