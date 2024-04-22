-- Mostrar Producto
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarProducto') 
DROP PROCEDURE SP_MostrarProducto;  
go
CREATE PROC	SP_MostrarProducto
as
begin
select * from producto where estpro = 1;
end
go
exec SP_MostrarProducto
go

-- mostrar productos todo
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_MostrarProductoTodo') 
DROP PROCEDURE SP_MostrarProductoTodo;  
go
CREATE PROC	SP_MostrarProductoTodo
as
begin
select * from producto;
end
go
exec SP_MostrarProductoTodo
go

-- Registrar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_RegistrarProducto') 
DROP PROCEDURE SP_RegistrarProducto;  
go
CREATE PROC	SP_RegistrarProducto
@nombre varchar(60),
@descripcion varchar(500),
@precio decimal,
@cantidad decimal,
@estado bit,
@codcat int
as
begin
begin tran SP_RegistrarProducto
begin try
insert into producto (nompro, despro, prepro, canpro, estpro, codcat) 
values (@nombre, @descripcion, @precio, @cantidad, @estado, @codcat);
commit tran SP_RegistrarProducto
end try
begin catch
	rollback tran SP_RegistrarProducto
end catch
end
go

EXEC SP_RegistrarProducto
    @nombre = 'Mantequilla',
    @descripcion = 'Rica y deliciosa',
    @precio = 10.99,
    @cantidad = 100,
    @estado = 1, 
    @codcat = 3; 
go

-- Actualizar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_ActualizarProducto') 
DROP PROCEDURE SP_ActualizarProducto;  
go
CREATE PROC	SP_ActualizarProducto
@codigo int,
@nombre varchar(60),
@descripcion varchar(500),
@precio decimal,
@cantidad decimal,
@estado bit,
@codcat int
as
begin
begin tran SP_ActualizarProducto
begin try
update producto 
set nompro = @nombre, despro = @descripcion, prepro = @precio, 
    canpro = @cantidad, estpro = @estado, codcat = @codcat 
where codpro = @codigo;
commit tran SP_ActualizarProducto
end try
begin catch
	rollback tran SP_ActualizarProducto
end catch
end
go

-- actualizando datos
DECLARE @codigoProducto int = 4; 
DECLARE @NewNombre varchar(60) = 'Mantequilla de calidad';
DECLARE @NewDescripcion varchar(500) = 'La mejor mantequilla del mercado';
DECLARE @NewPrecio decimal = 12.99;
DECLARE @NewCantidad decimal = 150;
DECLARE @NewEstado bit = 1; 
DECLARE @NewCodCat int = 2; 

EXEC SP_ActualizarProducto 
    @codigo = @codigoProducto,
    @nombre = @NewNombre,
    @descripcion = @NewDescripcion,
    @precio = @NewPrecio,
    @cantidad = @NewCantidad,
    @estado = @NewEstado,
    @codcat = @NewCodCat;
go

-- Eliminar
IF EXISTS(SELECT * FROM sys.procedures WHERE NAME='SP_EliminarProducto') 
DROP PROCEDURE SP_EliminarProducto;  
go
CREATE PROC	SP_EliminarProducto
@codigo int
as
begin
begin tran SP_EliminarProducto
begin try
update producto set estpro = 0 where codpro = @codigo;
commit tran SP_EliminarProducto
end try
begin catch
	rollback tran SP_EliminarProducto
end catch
end
go

--ELIMINAR UN PRODUCTO
DECLARE @codigoProducto int = 4; 

EXEC SP_EliminarProducto
    @codigo = @codigoProducto;
go