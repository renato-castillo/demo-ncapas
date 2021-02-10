use master
go

if db_id('Prueba') is not null
drop database Prueba
go

create database Prueba
go

use Prueba
go

create table clientes(
idCliente		int				primary key		identity(1,1),
nomCliente		varchar(100)	not null,
apeCliente		varchar(100)	not null,
fecCliente		datetime						default getdate()
)
go

create procedure usp_listarClientes
as
begin
	select * from clientes
end
go

create procedure usp_registrarCliente
@nomCliente varchar(100),
@apeCliente	varchar(100)
as
begin
	insert into clientes values(@nomCliente, @apeCliente, default)
end
go

exec usp_registrarCliente 'Renato', 'Castillo'
go
exec usp_registrarCliente 'Pedro', 'Perez'
go
exec usp_registrarCliente 'Juan', 'Quispe'
go

create procedure usp_listarClienteById
@idCliente int
as
begin
	select * from clientes where idCliente = @idCliente
end
go

create procedure usp_editarCliente
@idCliente int,
@nomCliente varchar(100),
@apeCliente varchar(100)
as
begin
	update clientes set nomCliente = @nomCliente, apeCliente = @apeCliente
	where idCliente = @idCliente
end
go

create procedure usp_eliminarCliente
@idCliente int
as
begin
	delete from clientes where idCliente = @idCliente
end
go