use master
go
drop database DACSAN3MIEN
go
create database DACSAN3MIEN
go
use DACSAN3MIEN
go

create table [dbo].[Region](
	id int identity primary key,
	name nvarchar(20)
)

create table [dbo].[Product](
	id int identity primary key,
	name nvarchar(100),
	image varchar(50),
	price float,
	status varchar(30),
	description nvarchar(1500),
	regionID int,
	constraint FK_User_Region foreign key(regionID)
		references Region(id) on update cascade on delete cascade
);

create table [dbo].[User](
	id int identity primary key,
	name nvarchar(100) not null,
	email varchar(50),
	birthday varchar(20),
	gender nvarchar(10),
	phone varchar(20),
	address nvarchar(100),
	password varchar(50),
	role varchar(20),
);

insert into [dbo].[Regions] values(N'Miền Bắc');
insert into [dbo].[Regions] values(N'Miền Trung');
insert into [dbo].[Regions] values(N'Miền Nam');

insert into [dbo].[Products] values(N'Sản phẩm 1', 'product_1.jpg', 10000, 'in stock', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua', 1);
insert into [dbo].[Products] values(N'Sản phẩm 2', 'product_2.jpg', 20000, 'in stock', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua', 1);
insert into [dbo].[Products] values(N'Sản phẩm 3', 'product_3.jpg', 30000, 'in stock', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua', 2);
insert into [dbo].[Products] values(N'Sản phẩm 4', 'product_4.jpg', 40000, 'in stock', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua', 2);
insert into [dbo].[Products] values(N'Sản phẩm 5', 'product_5.jpg', 50000, 'in stock', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua', 3);
insert into [dbo].[Products] values(N'Sản phẩm 6', 'product_6.jpg', 60000, 'in stock', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua', 3);

insert into [dbo].[Users] values(N'Ngọc Nghĩa', 'ngocnghiaphuc@gmail.com', '21/08/1997', 'Nam', '0382305339', N'Tuyên Quang', '123456', 'admin')

select * from Regions
select * from [dbo].[Products]
select * from [dbo].[Users]
