-- DB.sql
-- скрипт делает базу с уровнем совметистимости 2012 (offset, fetch)
-- это тестовая задача
-- без разгрваничения прав
-- без динамической подгрузки списков
-- без автообновления состояния
-- без серверной сортировки и постраничной разбивки 
-- без табличных параметров и массовой обработки записей
-- без обработки ошибок и статуса в параметрах
-- связи на LINQ кроме запросов с партиями ???

-- #dbname# = tstAppPavlov
--##>
SET ANSI_NULL_DFLT_ON off
set dateformat dmy
use master
go
if not exists(select * from sys.sysdatabases where name = 'tstAppPavlov')
	create database tstAppPavlov

	alter database tstAppPavlov
	SET COMPATIBILITY_LEVEL = 110
go

use tstAppPavlov

go


if exists (select  * from sys.tables where name = 'lots')
drop table lots
if exists (select  * from sys.tables where name = 'stores')
drop table stores
if exists (select  * from sys.tables where name = 'pharms')
drop table pharms
if exists (select  * from sys.tables where name = 'goods')
drop table goods

create table Goods(
	id		int identity (0,1)				primary key
,	name	varchar(250)					unique		
)

create table Pharms(
	id		int								identity (0,1)	primary key
,	name	nvarchar(250)					unique
,	address	nvarchar(250)					null
,	phone	nvarchar(16)					null
,	constraint	uPharms_AllFields						unique	(name, address, phone)
)

create table Stores(
	id		int	 identity (0,1)				
,	pharmID	int				 	
,	name	nvarchar(250)
,	primary key (pharmId, id)	
,	constraint FK_Store_Pharm				foreign key(pharmID)	references  Pharms(Id) on delete cascade on update cascade
,	constraint uStors_AllFields						unique	(name, pharmid)
)

create table Lots(
	id		int	 identity (0,1)				
,	storeId	int		
,	pharmID	int				 	
,	goodId	int					
,	q		int				
,	primary key								(pharmID, storeId, goodId, id)
,	constraint chkQ	check					(q >=0)
,	constraint FK_Lot_Store					foreign key(pharmID, storeId)	references  Stores(pharmID, Id)  on delete cascade on update cascade
,	constraint FK_Good_Store				foreign key(goodId)		references  Goods(Id)  on delete cascade on update cascade
)
--------====================-------
--процедуры
--IUD
if exists(select*from sys.objects where name ='D_Lots'		and type = 'P')	drop proc D_Lots
if exists(select*from sys.objects where name ='D_stores'	and type = 'P')	drop proc D_Stores
if exists(select*from sys.objects where name ='D_pharms'	and type = 'P')	drop proc D_Pharms
if exists(select*from sys.objects where name ='D_goods'		and type = 'P')	drop proc D_Goods

if exists(select*from sys.objects where name ='IU_Lots'		and type = 'P')	drop proc IU_Lots
if exists(select*from sys.objects where name ='IU_stores'	and type = 'P')	drop proc IU_Stores
if exists(select*from sys.objects where name ='IU_pharms'	and type = 'P')	drop proc IU_Pharms
if exists(select*from sys.objects where name ='IU_goods'	and type = 'P')	drop proc IU_Goods

if exists(select*from sys.objects where name ='S_Lots'		and type = 'P')	drop proc S_Lots
if exists(select*from sys.objects where name ='S_stores'	and type = 'P')	drop proc S_Stores
if exists(select*from sys.objects where name ='S_pharms'	and type = 'P')	drop proc S_Pharms
if exists(select*from sys.objects where name ='S_goods'		and type = 'P')	drop proc S_Goods

if exists(select*from sys.objects where name ='GET_GoodsByPharm'		and type = 'P')	drop proc GET_GoodsByPharm
go

create proc S_Goods
as
select * from goods
go

create proc S_Pharms
as
select * from Pharms
go

create proc S_Stores
(@pharmID int = null)
as
select * from Stores
where pharmID = coalesce(@pharmID,pharmID)
go

create proc S_Lots
(@pharmID int	= null
,@storeId int	= null
,@goodId int	= null
)
as
select * from Lots
where 
pharmID = coalesce(@pharmID,pharmID) and 
storeID = coalesce(@storeID,storeID) and
goodId  = coalesce(@goodId,goodId)
go

create proc GET_GoodsByPharm
(@pharmID int = null)
as
select p.ID, g.name, sum(l.q) as N   
from Pharms p
join Lots l on l.pharmID = p.id
join Goods g on g.id = l.goodId
where p.ID = coalesce(@pharmID,p.ID)
group by g.name,p.ID
go

create proc D_Lots
(@id int)
as
delete from Lots where @id = id
select * from Lots where @id = id
go

create proc D_Stores
(@id int)
as
delete from Stores where @id = id
select * from Stores where @id = id
go

create proc D_Pharms
(@id int)
as
delete from Pharms where @id = id
select * from Pharms where @id = id
go

create proc D_Goods
(@id int)
as
delete from Goods where @id = id
select* from Goods where @id = id
go

create proc IU_Goods
(@id int, @name	varchar(250))
as
if(@id is null)
begin
	insert into Goods(name) values(@name)
	select * from Goods where id = @@IDENTITY
end
else
begin
	update Goods set name = @name where id = @id
	select * from Goods where id = @id
end
go


create proc IU_Pharms
(	@id			int
,	@name		nvarchar(250)		
,	@address	nvarchar(250)		
,	@phone		nchar(16)			
)
as
if(@id is null)
begin
	insert into Pharms	(name,	address,	phone) values	(@name, @address,	@phone)
	select * from Pharms where id = @@IDENTITY
end
else 
begin
	update Pharms set 
		name	= @name 
	,	address = @address
	,	phone	= @phone
	where id = @id
	select * from Pharms where id = @id
end
go

create proc IU_Stores
(	@id			int
,	@pharmID	int				 	
,	@name		nvarchar(250)
)
as
if(@id is null)
begin
	insert into Stores	(name,	pharmID) 
		values			(@name,	@pharmID)
	select * from Stores where id = @@IDENTITY
end
else 
begin	
	update Stores set name	= @name,	pharmID	= @pharmID	where id = @id
	select * from Stores where id = @id
end
go

create proc IU_lots
(	@id			int					
,	@storeId	int		
,	@pharmID	int				 	
,	@goodId		int					
,	@q			money	
)
as
if(@id is null)
begin
	insert into Lots	(storeId,	pharmID,	goodId	, q) 
		values			(@storeId,	@pharmID,	@goodId	, @q)
	select * from Lots where id = @@IDENTITY
end
else 
begin	
	update lots set storeId = @storeId,	pharmID = @pharmID,	goodId = @goodId	, q = @q
	where id = @id
	select * from Lots where id = @id

end
go
--##<
---------tsts
/*
exec IU_Goods null, 'товар1'
exec IU_Goods null, 'товар2'
exec IU_Goods null, 'товар3'
exec IU_Goods null, 'товар4'
exec IU_Goods 3, 'товар4'


exec IU_Pharms null, 'аптека1','адрес1','12345'
exec IU_Pharms null, 'аптека2','адрес2','12345'
exec IU_Pharms null, 'аптека32','адрес3',null
exec IU_Pharms 2, 'аптека3','адрес4','322233322'


exec IU_Stores null ,2, 'склад 2 3 аптеки'
exec IU_Stores null ,2, 'склад 1 3 аптеки'
exec IU_Stores null ,0, 'склад 3 1 аптеки'

exec S_Pharms
exec S_Stores
exec S_Goods
exec  S_Lots

exec IU_lots @id = null, @storeId = 2, @pharmid = 0, @goodid = 0, @q = 0100
exec IU_lots @id = null, @storeId = 1, @pharmid = 2, @goodid = 2, @q = 010000
exec IU_lots @id = null, @storeId = 1, @pharmid = 2, @goodid = 1, @q = 010000
exec IU_lots @id = null, @storeId = 1, @pharmid = 2, @goodid = 1, @q = 010000
exec IU_lots @id = null, @storeId = 1, @pharmid = 2, @goodid = 1, @q = 010000
exec IU_lots @id = null, @storeId = 1, @pharmid = 2, @goodid = 1, @q = 010000
exec IU_lots @id = null, @storeId = 1, @pharmid = 2, @goodid = 1, @q = 010000

exec GET_GoodsByPharm @pharmid =2

exec D_Stores 0,2
exec  D_Goods 1
*/