use master
go
drop database DACSAN3MIEN
go
create database DACSAN3MIEN
go
use DACSAN3MIEN
go
create table [dbo].[Product](
	id int identity primary key,
	name nvarchar(100),
	image varchar(50),
	price float,
	status varchar(30),
	description nvarchar(1500)
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
	role varchar(20)
);

insert into [dbo].[Product] values(N'Sản phẩm 1', 'product_1.jpg', 10000, 'in stock', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua');
insert into [dbo].[Product] values(N'Sản phẩm 2', 'product_2.jpg', 20000, 'in stock', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua');
insert into [dbo].[Product] values(N'Sản phẩm 3', 'product_3.jpg', 30000, 'in stock', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua');
insert into [dbo].[Product] values(N'Sản phẩm 4', 'product_4.jpg', 40000, 'in stock', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua');
insert into [dbo].[Product] values(N'Sản phẩm 5', 'product_5.jpg', 50000, 'in stock', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua');

insert into [dbo].[User] values(N'Ngọc Nghĩa', 'ngocnghiaphuc@gmail.com', '21/08/1997', 'Nam', '0382305339', N'Tuyên Quang', '123456', 'admin')

select * from [dbo].[Product]
select * from [dbo].[User]
delete from [dbo].[User] where id = 1