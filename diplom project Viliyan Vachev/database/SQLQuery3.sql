Create database Store;
go

use Store;

create table Users(id_user int identity Primary key,
first_name varchar(50) Not null,
lastst_name varchar(50) Not null,
address varchar(50) Not null,
telephone int Not null,
email varchar(50) Not null,
userName varchar(50) Not null,
password varchar(50))
go

create table Categories(
id_category int identity Primary key,
gategory_name varchar(50) Not null)
go

create table Orders
(id_order int identity Primary key,
id_user int Not null,
date_time date)
go

alter table Orders
add constraint FK_Orders_REFERENCE_Oders_P foreign key(id_user)
references Users (id_user)
go

create table Products
(id_product int identity Primary key,
id_category int Not null,
id_user int Not null,
product_name varchar(50) Not null,
price float Not null,
quantity int Not null,
image text,
description text)
go

alter table Products
add constraint FK_Products_REFERENCE_Cat foreign key(id_category)
references Categories (id_category)
go

alter table Products
add constraint FK_Products_REFERENCE_User foreign key(id_user)
references Users (id_user)
go

create table Carts
(id_order int Primary key,
id_product int Not null)
go

alter table Carts
add constraint FK_Carts_REFERENCE_Orders foreign key(id_order)
references Orders (id_order)
go

alter table Carts
add constraint FK_Carts_REFERENCE_Prod foreign key(id_product)
references Products (id_product)
go