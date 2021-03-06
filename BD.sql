USE [MALL]
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 08/24/2020 17:24:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIO](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [nvarchar](40) NOT NULL,
	[contraseña] [nvarchar](40) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Area]    Script Date: 08/24/2020 17:24:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Area](
	[id_area] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_area] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 08/24/2020 17:24:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empleados](
	[id_empleado] [int] IDENTITY(1,1) NOT NULL,
	[nombres] [varchar](50) NOT NULL,
	[apellidoP] [varchar](30) NOT NULL,
	[apellidoM] [varchar](30) NOT NULL,
	[id_area] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[telefono] [nvarchar](20) NOT NULL,
	[correo] [nvarchar](40) NOT NULL,
	[sueldo] [decimal](7, 2) NOT NULL,
 CONSTRAINT [PK__Empleado__88B513940AD2A005] PRIMARY KEY CLUSTERED 
(
	[id_empleado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 08/24/2020 17:24:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clientes](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](50) NOT NULL,
	[apellidoP] [varchar](30) NOT NULL,
	[apellidoM] [varchar](30) NOT NULL,
	[telefono] [nvarchar](20) NOT NULL,
	[direccion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__Clientes__677F38F507020F21] PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 08/24/2020 17:24:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categorias](
	[id_categoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_categoria] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 08/24/2020 17:24:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Proveedores](
	[id_proveedor] [int] IDENTITY(1,1) NOT NULL,
	[compañia] [varchar](40) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[direccion] [nvarchar](50) NOT NULL,
	[ciudad] [varchar](40) NOT NULL,
	[pais] [varchar](40) NOT NULL,
	[telefono] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK__Proveedo__8D3DFE281273C1CD] PRIMARY KEY CLUSTERED 
(
	[id_proveedor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 08/24/2020 17:24:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Productos](
	[id_producto] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](30) NOT NULL,
	[id_proveedor] [int] NOT NULL,
	[id_categoria] [int] NOT NULL,
	[precio] [decimal](7, 2) NOT NULL,
	[unidades] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_producto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[IniciarSesion]    Script Date: 08/24/2020 17:24:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[IniciarSesion](
@usuario nvarchar(30),
@contraseña nvarchar(30)
)
as
select usuario from USUARIO
where usuario = @usuario and contraseña = @contraseña
GO
/****** Object:  StoredProcedure [dbo].[CargarUsuarios]    Script Date: 08/24/2020 17:24:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CargarUsuarios]
AS
SELECT*FROM USUARIO ORDER BY usuario
GO
/****** Object:  StoredProcedure [dbo].[SP_AGREGAR_CLIENTE]    Script Date: 08/24/2020 17:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AGREGAR_CLIENTE]
 (
	@nombres varchar(50), @apellidoP varchar(30),
	@apellidoM varchar(30), @telefono nvarchar(20),
	@direccion nvarchar(50)
 )
 AS
 INSERT INTO Clientes(Nombres,apellidoP, apellidoM,telefono,direccion)
 VALUES(@nombres, @apellidoP, @apellidoM,@telefono,@direccion)
GO
/****** Object:  StoredProcedure [dbo].[SP_AGREGAR_CATEGORIA]    Script Date: 08/24/2020 17:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AGREGAR_CATEGORIA]
(
	@nombre varchar(40)
)
AS
INSERT INTO Categorias(Nombre)
VALUES(@nombre)
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZAR_PROVEEEDOR]    Script Date: 08/24/2020 17:24:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ACTUALIZAR_PROVEEEDOR]
 (
	@compañia varchar(40), @nombre varchar(50),
	@direccion varchar(50), @ciudad varchar(40),
	@pais varchar(40), @telefono nvarchar(20),
	@id_proveedor int
 )
 AS
 UPDATE Proveedores SET compañia=@compañia, nombre=@nombre, direccion=@direccion,ciudad=@ciudad,
 pais=@pais, telefono=@telefono WHERE id_proveedor=@id_proveedor
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCAR_EMPLEADOS_ID]    Script Date: 08/24/2020 17:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Tabla Empleados
CREATE PROCEDURE [dbo].[SP_BUSCAR_EMPLEADOS_ID]
(
	@id_empleado int=null, @nombres varchar(50)=null,
	@apellidoP varchar(30)=null
)
AS
	SELECT E.id_empleado as [Código], E.nombres as [Nombres], E.apellidoP as [Apellido Paterno],
    E.apellidoM as [Apellido Materno], A.nombre as [Area], E.fecha as [Fecha de Nacimiento],
    E.telefono as [Telefono], E.correo as [Correo], E.sueldo as [Sueldo] 
    FROM  Empleados E INNER JOIN Area A on E.id_area=A.id_area WHERE E.id_empleado=@id_empleado
    ORDER BY E.apellidoP, E.apellidoM, E.nombres
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCAR_EMPLEADO_NOMBRE]    Script Date: 08/24/2020 17:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_BUSCAR_EMPLEADO_NOMBRE]
(
	@nombres varchar(50)
)	
AS
        SELECT E.id_empleado as [Código], E.nombres as [Nombres], E.apellidoP as [Apellido Paterno],
        E.apellidoM as [Apellido Materno], A.nombre as [Area], E.fecha as [Fecha de Nacimiento],
        E.telefono as [Telefono], E.correo as [Correo], E.sueldo as [Sueldo] 
        FROM  Empleados E INNER JOIN Area A on E.id_area=A.id_area WHERE E.nombres like +'%'+@nombres+'%'
        ORDER BY E.apellidoP, E.apellidoM, E.nombres
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCAR_EMPLEADO_APELLIDO]    Script Date: 08/24/2020 17:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_BUSCAR_EMPLEADO_APELLIDO]
(
	@apellido varchar(30)
)        
AS
        SELECT E.id_empleado as [Código], E.nombres as [Nombres], E.apellidoP as [Apellido Paterno],
        E.apellidoM as [Apellido Materno], A.nombre as [Area], E.fecha as [Fecha de Nacimiento],
        E.telefono as [Telefono], E.correo as [Correo], E.sueldo as [Sueldo] 
        FROM  Empleados E INNER JOIN Area A on E.id_area=A.id_area WHERE E.apellidoP like +'%'+@apellido+'%'
        ORDER BY E.apellidoP, E.apellidoM, E.nombres
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCAR_CLIENTE_NOMBRE]    Script Date: 08/24/2020 17:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_BUSCAR_CLIENTE_NOMBRE]
 (
	@nombres varchar(50)
 )
 AS
	SELECT C.id_cliente as [NoCliente], C.Nombres as [Nombres], C.apellidoP as [Apellido Paterno], 
    C.apellidoM as [Apellido Materno], C.telefono as [Telefono], C.direccion as [Direccion]
    FROM Clientes C WHERE C.Nombres like+'%'+@nombres+'%' ORDER BY C.apellidoP, C.apellidoM, C.Nombres
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCAR_CLIENTE_ID]    Script Date: 08/24/2020 17:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_BUSCAR_CLIENTE_ID]
 (
	@id_cliente int
 )
 AS
   SELECT C.id_cliente as [NoCliente], C.Nombres as [Nombres], C.apellidoP as [Apellido Paterno], 
   C.apellidoM as [Apellido Materno], C.telefono as [Telefono], C.direccion as [Direccion]
   FROM Clientes C WHERE id_cliente=@id_cliente ORDER BY C.apellidoP, C.apellidoM, C.Nombres
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCAR_CLIENTE_APELLIDO]    Script Date: 08/24/2020 17:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_BUSCAR_CLIENTE_APELLIDO]
(
	@apellidoP varchar(30)
)
AS
	SELECT C.id_cliente as [NoCliente], C.Nombres as [Nombres], C.apellidoP as [Apellido Paterno], 
    C.apellidoM as [Apellido Materno], C.telefono as [Telefono], C.direccion as [Direccion]
    FROM Clientes C WHERE C.apellidoP like+'%'+@apellidoP+'%' ORDER BY C.apellidoP, C.apellidoM, C.Nombres
GO
/****** Object:  StoredProcedure [dbo].[SP_AGREGAR_PROVEEDOR]    Script Date: 08/24/2020 17:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AGREGAR_PROVEEDOR]
 (
	@compañia varchar(40), @nombre varchar(50),
	@direccion varchar(50), @ciudad varchar(40),
	@pais varchar(40), @telefono nvarchar(20)
 )
 AS
 INSERT INTO Proveedores(compañia, nombre,direccion,ciudad,pais,telefono)
 VALUES(@compañia, @nombre, @direccion, @ciudad,@pais,@telefono)
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_EMPLEADO]    Script Date: 08/24/2020 17:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ELIMINAR_EMPLEADO]
(
	@id_empleado int
)
AS
DELETE FROM Empleados WHERE id_empleado=@id_empleado
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_CLIENTE]    Script Date: 08/24/2020 17:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ELIMINAR_CLIENTE]
 (
	@id_cliente int
 )
 AS
 DELETE Clientes WHERE id_cliente=@id_cliente
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_CATEGORIA]    Script Date: 08/24/2020 17:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ELIMINAR_CATEGORIA]
(
	@id_categoria int
)
AS
DELETE Categorias WHERE id_categoria=@id_categoria
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCAR_PROVEEDOR_NOMBRE]    Script Date: 08/24/2020 17:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_BUSCAR_PROVEEDOR_NOMBRE]
(
	@nombre varchar(50)
)	
AS
	SELECT P.id_proveedor as [No.Proveedor], P.compañia as [Compañia], P.nombre as [Nombre],
    P.direccion as [Dirección], P.ciudad as [Ciudad], P.pais as [País], P.telefono as [Télefono]
    FROM Proveedores P WHERE nombre like+'%'+@nombre+'%' ORDER BY P.nombre
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCAR_PROVEEDOR_ID]    Script Date: 08/24/2020 17:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_BUSCAR_PROVEEDOR_ID]
 (
   @id_proveedor int
 )
 AS
   SELECT P.id_proveedor as [No.Proveedor], P.compañia as [Compañia], P.nombre as [Nombre],
   P.direccion as [Dirección], P.ciudad as [Ciudad], P.pais as [País], P.telefono as [Télefono]
   FROM Proveedores P WHERE id_proveedor=@id_proveedor ORDER BY P.nombre
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCAR_PROVEEDOR_COMPAÑIA]    Script Date: 08/24/2020 17:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_BUSCAR_PROVEEDOR_COMPAÑIA]
(
	@compañia varchar(40)
)
AS
  SELECT P.id_proveedor as [No.Proveedor], P.compañia as [Compañia], P.nombre as [Nombre],
  P.direccion as [Dirección], P.ciudad as [Ciudad], P.pais as [País], P.telefono as [Télefono]
  FROM Proveedores P WHERE compañia like+'%'+@compañia+'%' ORDER BY P.nombre
GO
/****** Object:  StoredProcedure [dbo].[SP_LLENAR_COMBO_CATEGORIAS]    Script Date: 08/24/2020 17:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_LLENAR_COMBO_CATEGORIAS]
AS
SELECT*FROM Categorias ORDER BY Nombre
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_EMPLEADO]    Script Date: 08/24/2020 17:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_EMPLEADO]
(
	@nombres varchar(50), @apellidoP varchar(30),
	@apellidoM varchar(30), @id_area int, @fecha date,
	@telefono nvarchar(20), @correo nvarchar(40), @sueldo decimal(7,2)
)
AS
INSERT INTO Empleados(nombres,apellidoP,apellidoM,id_area,fecha,telefono,correo,sueldo)
VALUES(@nombres, @apellidoP, @apellidoM,@id_area,@fecha,@telefono,@correo,@sueldo)
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_PROVEEDOR]    Script Date: 08/24/2020 17:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ELIMINAR_PROVEEDOR]
 (
	@id_proveedor int
 )
 AS
 DELETE Proveedores WHERE id_proveedor=@id_proveedor
GO
/****** Object:  StoredProcedure [dbo].[SP_MOSTRAR_EMPLEADOS]    Script Date: 08/24/2020 17:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_MOSTRAR_EMPLEADOS]
AS
    SELECT E.id_empleado as [Código], E.nombres as [Nombres], E.apellidoP as [Apellido Paterno],
    E.apellidoM as [Apellido Materno], A.nombre as [Area], E.fecha as [Fecha de Nacimiento],
    E.telefono as [Telefono], E.correo as [Correo], E.sueldo as [Sueldo] 
    FROM  Empleados E INNER JOIN Area A on E.id_area=A.id_area 
    ORDER BY E.apellidoP, E.apellidoM, E.nombres
GO
/****** Object:  StoredProcedure [dbo].[SP_MOSTRAR_COMBO_AREA]    Script Date: 08/24/2020 17:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_MOSTRAR_COMBO_AREA]
AS
SELECT*FROM Area ORDER BY nombre
GO
/****** Object:  StoredProcedure [dbo].[SP_MOSTRAR_CLIENTES]    Script Date: 08/24/2020 17:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_MOSTRAR_CLIENTES]
AS
SELECT C.id_cliente as [NoCliente], C.Nombres as [Nombres], C.apellidoP as [Apellido Paterno], 
C.apellidoM as [Apellido Materno], C.telefono as [Telefono], C.direccion as [Direccion]
 FROM Clientes C ORDER BY C.apellidoP, C.apellidoM, C.Nombres
GO
/****** Object:  StoredProcedure [dbo].[SP_MODIFICAR_EMPLEADO]    Script Date: 08/24/2020 17:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_MODIFICAR_EMPLEADO]
(
	@id_empleado int, @nombres varchar(50), @apellidoP varchar(30),
	@apellidoM varchar(30), @id_area int, @fecha date,
	@correo nvarchar(40), @sueldo decimal(7,2), @telefono nvarchar(20)
)
AS
UPDATE Empleados SET nombres=@nombres, apellidoP=@apellidoP, apellidoM=@apellidoM, id_area=@id_area,
fecha=@fecha, telefono=@telefono, correo=@correo, sueldo=@sueldo WHERE id_empleado=@id_empleado
GO
/****** Object:  StoredProcedure [dbo].[SP_LLENAR_COMBO_PROVEEDORES]    Script Date: 08/24/2020 17:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Tabla Productos
CREATE PROCEDURE [dbo].[SP_LLENAR_COMBO_PROVEEDORES]
AS
SELECT*FROM Proveedores ORDER BY nombre, compañia
GO
/****** Object:  Trigger [TR_Proveedores_Inicializacion]    Script Date: 08/24/2020 17:24:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[TR_Proveedores_Inicializacion]
on [dbo].[Proveedores]
after insert
as
begin
	declare @id_proveedor int, @nombre varchar(50)
	select @id_proveedor=id_proveedor, @nombre=nombre from inserted
	declare @validar int
	set @validar=(select count(nombre) from Proveedores where nombre=@nombre)
	if @validar=2
	begin
		delete Proveedores where id_proveedor=@id_proveedor
	end
end
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZAR_CLIENTE]    Script Date: 08/24/2020 17:24:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ACTUALIZAR_CLIENTE]
 (
	@id_cliente int, 
	@nombres varchar(50), @apellidoP varchar(30),
	@apellidoM varchar(30), @telefono nvarchar(20),
	@direccion nvarchar(50)
 )
 AS
 UPDATE Clientes SET Nombres=@nombres, apellidoP=@apellidoP, apellidoM=@apellidoM, telefono=@telefono,
 direccion=@direccion WHERE id_cliente=@id_cliente
GO
/****** Object:  Trigger [TR_INICIALIZAR_CATEGORIAS]    Script Date: 08/24/2020 17:24:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[TR_INICIALIZAR_CATEGORIAS]
ON [dbo].[Categorias]
AFTER INSERT
AS		
BEGIN
	declare @id_categoria int,
	@nombre varchar(40), @validar int
	SELECT @id_categoria=id_categoria, @nombre=Nombre FROM inserted
	SET @validar=(SELECT COUNT(Nombre) FROM Categorias WHERE Nombre=@nombre)
	if @validar=2
	BEGIN
		DELETE Categorias WHERE id_categoria=@id_categoria
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_MOSTRAR_PROVEEDORES]    Script Date: 08/24/2020 17:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_MOSTRAR_PROVEEDORES]
AS
   SELECT P.id_proveedor as [No.Proveedor], P.compañia as [Compañia], P.nombre as [Nombre],
   P.direccion as [Dirección], P.ciudad as [Ciudad], P.pais as [País], P.telefono as [Télefono]
   FROM Proveedores P ORDER BY P.nombre
GO
/****** Object:  StoredProcedure [dbo].[SP_MOSTRAR_PRODUCTOS]    Script Date: 08/24/2020 17:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_MOSTRAR_PRODUCTOS]
AS
SELECT P.id_producto as [Código], P.nombre as [Producto], PR.nombre as [Proveedor], C.Nombre as [Categoria],
P.precio as [Precio], P.unidades as [Unidades] FROM Productos P INNER JOIN Proveedores PR ON P.id_proveedor=PR.id_proveedor
INNER JOIN Categorias C ON P.id_categoria=C.id_categoria ORDER BY P.nombre
GO
/****** Object:  Trigger [TR_PRODUCTOS_INICIALIZACION]    Script Date: 08/24/2020 17:24:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[TR_PRODUCTOS_INICIALIZACION]
ON [dbo].[Productos]
AFTER INSERT
AS
BEGIN
	declare @id_producto int,
	@nombre varchar(30), @validar int
	SELECT @id_producto=id_producto,@nombre=nombre  FROM inserted
	SET @validar=(SELECT COUNT(nombre) FROM Productos WHERE nombre=@nombre)
	if @validar=2
	BEGIN
		DELETE Productos WHERE id_producto=@id_producto
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_LLENAR_COMBO_PRODUCTOS]    Script Date: 08/24/2020 17:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_LLENAR_COMBO_PRODUCTOS]
AS
SELECT*FROM Productos ORDER BY nombre
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_PRODUCTO]    Script Date: 08/24/2020 17:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ELIMINAR_PRODUCTO]
(
	@id_producto int
)
AS
DELETE Productos WHERE id_producto=@id_producto
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCAR_PRODUCTOS]    Script Date: 08/24/2020 17:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_BUSCAR_PRODUCTOS]
(
	@id_producto int = null,
	@nombre varchar(30)= null
)
AS
	SELECT P.id_producto as [Código], P.nombre as [Producto], PR.nombre as [Proveedor], C.Nombre as [Categoria],
    P.precio as [Precio], P.unidades as [Unidades] FROM Productos P INNER JOIN Proveedores PR ON P.id_proveedor=PR.id_proveedor
    INNER JOIN Categorias C ON P.id_categoria=C.id_categoria WHERE id_producto=@id_producto ORDER BY P.nombre
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCAR_PRODUCTO_NOMBRE]    Script Date: 08/24/2020 17:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_BUSCAR_PRODUCTO_NOMBRE]
(
	@nombre varchar(30)
)
AS
SELECT P.id_producto as [Código], P.nombre as [Producto], PR.nombre as [Proveedor], C.Nombre as [Categoria],
    P.precio as [Precio], P.unidades as [Unidades] FROM Productos P INNER JOIN Proveedores PR ON P.id_proveedor=PR.id_proveedor
    INNER JOIN Categorias C ON P.id_categoria=C.id_categoria WHERE P.nombre like+'%'+@nombre+'%' ORDER BY P.nombre
GO
/****** Object:  StoredProcedure [dbo].[SP_AGREGAR_PRODUCTO]    Script Date: 08/24/2020 17:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AGREGAR_PRODUCTO]
(
	@nombre varchar(30), @id_proveedor int, 
	@id_categoria int, @precio decimal(7,2),
	@unidades int
)
AS
INSERT INTO Productos(nombre,id_proveedor,id_categoria,precio,unidades)
VALUES(@nombre, @id_proveedor, @id_categoria, @precio,@unidades)
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZAR_PRODUCTOS]    Script Date: 08/24/2020 17:24:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ACTUALIZAR_PRODUCTOS]
(
	@nombre varchar(30), @id_proveedor int, 
	@id_categoria int, @precio decimal(7,2),
	@unidades int, @id_producto int
)
AS
UPDATE Productos SET nombre=@nombre, id_proveedor=@id_proveedor, id_categoria=@id_categoria, precio=@precio,
unidades=@unidades WHERE id_producto=@id_producto
GO
/****** Object:  ForeignKey [FK__Productos__id_ca__182C9B23]    Script Date: 08/24/2020 17:24:42 ******/
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK__Productos__id_ca__182C9B23] FOREIGN KEY([id_categoria])
REFERENCES [dbo].[Categorias] ([id_categoria])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK__Productos__id_ca__182C9B23]
GO
/****** Object:  ForeignKey [FK__Productos__id_pr__173876EA]    Script Date: 08/24/2020 17:24:42 ******/
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK__Productos__id_pr__173876EA] FOREIGN KEY([id_proveedor])
REFERENCES [dbo].[Proveedores] ([id_proveedor])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK__Productos__id_pr__173876EA]
GO
/****** Object:  ForeignKey [FK_Productos_Productos]    Script Date: 08/24/2020 17:24:42 ******/
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Productos] FOREIGN KEY([id_producto])
REFERENCES [dbo].[Productos] ([id_producto])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Productos]
GO
