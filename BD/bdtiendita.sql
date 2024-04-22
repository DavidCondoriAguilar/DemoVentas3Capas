-- cerrar todas las conexiones a la base de datos
use master
go
IF EXISTS(SELECT * from sys.databases WHERE name='bdtiendita')  
BEGIN 
alter database bdtiendita set single_user 
with rollback immediate
END 
go

-- buscamos si existe la base de datos
IF EXISTS(SELECT * from sys.databases WHERE name='bdtiendita')  
BEGIN 
	-- seleccionamos el master 
	use master
	--eliminamos la base de datos 
    drop DATABASE bdtiendita
END 
go

-- creando la base de datos
create database bdtiendita
go
--seleccionamos la base de datos
use bdtiendita
go
--creamos la tabla
-- continente
create table categoria(
codcat integer primary key identity(1,1),
nomcat varchar(60) not null,
estcat bit not null
)
go

-- producto
create table producto(
codpro int primary key identity(1,1),
nompro varchar(60) not null,
despro varchar(500) not null,
prepro decimal not null,
canpro decimal not null,
estpro bit not null,
codcat int,
foreign key (codcat) references categoria(codcat)
)
go

-- insertando datos
-- categoria
insert into categoria values('bebidas',1)
insert into categoria values('golosinas',1)
insert into categoria values('abarrotes',1)
insert into categoria values('licor',0)
go

-- producto
insert into producto values('Coca Cola 3Lt',
'Botella no retornable de plastico de 3 litros',11,20,1,1)
insert into producto values('Sublime de 120g',
'Chocolate Sublime de 120g con mani',2.5,40,1,2)
insert into producto values('Arroz Costeño',
'Arroz Costeño Premium',5.3,80,1,3)
go

-- mostrando datos
select * from categoria
select * from producto
go
