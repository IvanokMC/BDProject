-- Crear base de datos
CREATE DATABASE MelodiaUrbana;
GO
USE MelodiaUrbana;
GO

-- =========================
-- Tipos de datos personalizados
-- =========================
EXEC sp_addtype TId, 'VARCHAR(6)', 'NOT NULL';
EXEC sp_addtype TNombreCorto, 'NVARCHAR(100)', 'NOT NULL';
EXEC sp_addtype TNombreLargo, 'NVARCHAR(200)', 'NOT NULL';
EXEC sp_addtype TDescripcion, 'NVARCHAR(1000)', 'NULL';
EXEC sp_addtype TFormato, 'NVARCHAR(10)', 'NULL';
EXEC sp_addtype TGenero, 'NVARCHAR(100)', 'NULL';
EXEC sp_addtype TPrecio, 'DECIMAL(10,2)', 'NOT NULL';
EXEC sp_addtype TCorreo, 'NVARCHAR(150)', 'NOT NULL';
EXEC sp_addtype TPassword, 'NVARCHAR(255)', 'NOT NULL';

-- =========================
-- Tabla ARTISTA (superclase)
-- =========================
CREATE TABLE Artista (
    id_artista TId PRIMARY KEY,
    nombre_artistico TNombreCorto,
    tipo_artista NVARCHAR(10) CHECK (tipo_artista IN ('solista', 'grupo')) NOT NULL,
    pais_origen TNombreCorto,
    genero_principal TGenero,
    fecha_inicio DATE,
    biografia TDescripcion,
    imagen TDescripcion
);

-- Subtipo: ArtistaSolista
CREATE TABLE ArtistaSolista (
    id_artista TId PRIMARY KEY,
    nombre_real TNombreCorto,
    fecha_nacimiento DATE,
    sexo NVARCHAR(10) CHECK (sexo IN ('M', 'F', 'Otro')),
    FOREIGN KEY (id_artista) REFERENCES Artista(id_artista)
);

-- Subtipo: GrupoMusical
CREATE TABLE GrupoMusical (
    id_artista TId PRIMARY KEY,
    fecha_formacion DATE,
    fecha_disolucion DATE,
    FOREIGN KEY (id_artista) REFERENCES Artista(id_artista)
);

-- Integrantes de grupos
CREATE TABLE IntegranteGrupo (
    id_artista_grupo TId,
    id_artista_miembro TId,
    rol TNombreCorto,
    fecha_ingreso DATE,
    fecha_salida DATE,
    PRIMARY KEY (id_artista_grupo, id_artista_miembro),
    FOREIGN KEY (id_artista_grupo) REFERENCES GrupoMusical(id_artista),
    FOREIGN KEY (id_artista_miembro) REFERENCES Artista(id_artista)
);

-- =========================
-- Tabla PRODUCTO (superclase)
-- =========================
CREATE TABLE Producto (
    id_producto TId PRIMARY KEY,
    titulo TNombreLargo,
    precio_unitario TPrecio DEFAULT 0.00
);

-- =========================
-- Subtipo: Álbum
-- =========================
CREATE TABLE Album (
    id_producto TId PRIMARY KEY,
    fecha_lanzamiento DATE,
    id_artista_principal TId,
    EsAlbumCompleto BIT DEFAULT 0, -- NUEVA COLUMNA
    FOREIGN KEY (id_producto) REFERENCES Producto(id_producto),
    FOREIGN KEY (id_artista_principal) REFERENCES Artista(id_artista)
);

-- =========================
-- Subtipo: Canción
-- =========================
CREATE TABLE Cancion (
    id_producto TId PRIMARY KEY,
    duracion TIME,
    formato TFormato,
    genero TGenero,
    es_sencillo BIT DEFAULT 0,
    id_album TId NULL,
    id_artista_principal TId NOT NULL, -- NUEVO: artista obligatorio
    FOREIGN KEY (id_producto) REFERENCES Producto(id_producto),
    FOREIGN KEY (id_album) REFERENCES Album(id_producto),
    FOREIGN KEY (id_artista_principal) REFERENCES Artista(id_artista)
);

-- =========================
-- Colaboraciones adicionales
-- =========================
CREATE TABLE Colaboracion (
    id_cancion TId,
    id_artista TId,
    rol TNombreCorto,
    PRIMARY KEY (id_cancion, id_artista),
    FOREIGN KEY (id_cancion) REFERENCES Cancion(id_producto),
    FOREIGN KEY (id_artista) REFERENCES Artista(id_artista)
);

-- =========================
-- Clientes
-- =========================
CREATE TABLE Cliente (
    id_cliente INT IDENTITY(1,1) PRIMARY KEY,
    nombre TNombreCorto,
    correo_electronico TCorreo UNIQUE,
    contraseña TPassword, -- en app, cifrada
    direccion TDescripcion
);

-- =========================
-- Comprobantes de venta
-- =========================
CREATE TABLE ComprobanteVenta (
    id_comprobante INT IDENTITY(1,1) PRIMARY KEY,
    id_cliente INT,
    fecha_venta DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_cliente) REFERENCES Cliente(id_cliente)
);

-- =========================
-- Detalle de venta
-- =========================
CREATE TABLE DetalleVenta (
    id_comprobante INT,
    id_producto TId,
    precio_unitario TPrecio,
    PRIMARY KEY (id_comprobante, id_producto),
    FOREIGN KEY (id_comprobante) REFERENCES ComprobanteVenta(id_comprobante),
    FOREIGN KEY (id_producto) REFERENCES Producto(id_producto)
);



INSERT INTO Artista VALUES
('A00001', 'Luna Vibe', 'solista', 'México', 'Pop', '2015-06-01', 'Cantante pop latinoamericana.', 'imagen1.jpg'),
('A00002', 'Beat Clash', 'grupo', 'Estados Unidos', 'Hip-Hop', '2010-03-15', 'Grupo pionero en rap fusión.', 'imagen2.jpg'),
('A00003', 'Estelar', 'solista', 'Perú', 'Indie', '2018-08-21', 'Compositor de baladas indie.', 'imagen3.jpg'),
('A00004', 'Los Urbanos', 'grupo', 'Argentina', 'Reggaeton', '2012-01-10', 'Banda de reggaeton urbana.', 'imagen4.jpg'),
('A00005', 'Nova Luz', 'solista', 'Chile', 'Electropop', '2019-11-05', 'Artista emergente de electropop.', 'imagen5.jpg');


INSERT INTO ArtistaSolista VALUES
('A00001', 'Lucía Martínez', '1990-04-23', 'F'),
('A00003', 'Esteban Ruiz', '1995-10-12', 'M'),
('A00005', 'Camila Torres', '1998-07-08', 'F');


INSERT INTO GrupoMusical VALUES
('A00002', '2010-03-15', NULL),
('A00004', '2012-01-10', '2021-12-31');



INSERT INTO IntegranteGrupo VALUES
('A00002', 'A00003', 'Baterista', '2010-05-01', NULL),
('A00002', 'A00001', 'Vocalista', '2012-09-01', '2015-01-01'),
('A00004', 'A00005', 'Productora', '2013-01-01', NULL),
('A00004', 'A00003', 'Corista', '2014-02-15', '2019-10-01'),
('A00004', 'A00001', 'Coreógrafa', '2015-06-10', NULL);



INSERT INTO Producto VALUES
('P00001', 'Brilla la Luna', 9.99),
('P00002', 'Sonidos del Barrio', 14.50),
('P00003', 'Ritmo Estelar', 8.75),
('P00004', 'Luz y Sombra', 11.25),
('P00005', 'Latidos Urbanos', 13.00);


INSERT INTO Album VALUES
('P00001', '2016-07-01', 'A00001', 1),
('P00002', '2011-11-20', 'A00002', 1),
('P00004', '2020-09-10', 'A00005', 0);


INSERT INTO Cancion VALUES
('P00003', '00:03:45', 'MP3', 'Indie', 1, NULL, 'A00003'),
('P00005', '00:04:15', 'MP3', 'Reggaeton', 0, 'P00002', 'A00004'),
('P00001', '00:03:30', 'WAV', 'Pop', 0, 'P00001', 'A00001'),
('P00002', '00:04:00', 'FLAC', 'Hip-Hop', 1, 'P00002', 'A00002'),
('P00004', '00:05:05', 'MP3', 'Electropop', 1, 'P00004', 'A00005');



INSERT INTO Colaboracion VALUES
('P00005', 'A00003', 'Compositor'),
('P00003', 'A00005', 'Productora'),
('P00001', 'A00002', 'Beatmaker'),
('P00002', 'A00001', 'Vocalista'),
('P00004', 'A00004', 'Remix');


INSERT INTO Cliente(nombre, correo_electronico, contraseña, direccion) VALUES
('Carlos Pérez', 'carlosp@gmail.com', 'abc123', 'Av. Siempre Viva 123'),
('Lucía Gómez', 'lucia_gz@hotmail.com', 'lucia456', 'Calle Luna 456'),
('Andrés Muñoz', 'andres.m@gmail.com', 'muñoz789', 'Jr. Sol 789'),
('Fernanda Torres', 'fer.t@gmail.com', '123fer456', 'Pje. Estrella 321'),
('Mario Díaz', 'mario.d@gmail.com', 'días987', 'Av. Central 987');

INSERT INTO ComprobanteVenta(id_cliente, fecha_venta) VALUES
(1, '2025-07-01 14:35:00'),
(2, '2025-07-05 10:20:00'),
(3, '2025-07-15 09:10:00'),
(4, '2025-07-20 18:45:00'),
(5, '2025-07-29 13:00:00');


INSERT INTO DetalleVenta VALUES
(1, 'P00001', 9.99),
(1, 'P00003', 8.75),
(2, 'P00002', 14.50),
(3, 'P00005', 13.00),
(4, 'P00004', 11.25);



-- =========================
-- Stored Procedures
-- =========================

-- Insertar Artista (general)
CREATE PROCEDURE InsertArtista
    @id_artista TId,
    @nombre_artistico TNombreCorto,
    @tipo_artista NVARCHAR(10),
    @pais_origen TNombreCorto,
    @genero_principal TGenero,
    @fecha_inicio DATE,
    @biografia TDescripcion,
    @imagen TDescripcion
AS
BEGIN
    INSERT INTO Artista (id_artista, nombre_artistico, tipo_artista, pais_origen, genero_principal, fecha_inicio, biografia, imagen)
    VALUES (@id_artista, @nombre_artistico, @tipo_artista, @pais_origen, @genero_principal, @fecha_inicio, @biografia, @imagen);
END;
GO

-- Insertar Artista Solista
CREATE PROCEDURE InsertArtistaSolista
    @id_artista TId,
    @nombre_artistico TNombreCorto,
    @pais_origen TNombreCorto,
    @genero_principal TGenero,
    @fecha_inicio DATE,
    @biografia TDescripcion,
    @imagen TDescripcion,
    @nombre_real TNombreCorto,
    @fecha_nacimiento DATE,
    @sexo NVARCHAR(10)
AS
BEGIN
    EXEC InsertArtista @id_artista, @nombre_artistico, 'solista', @pais_origen, @genero_principal, @fecha_inicio, @biografia, @imagen;
    INSERT INTO ArtistaSolista (id_artista, nombre_real, fecha_nacimiento, sexo)
    VALUES (@id_artista, @nombre_real, @fecha_nacimiento, @sexo);
END;
GO

-- Insertar Grupo Musical
CREATE PROCEDURE InsertGrupoMusical
    @id_artista TId,
    @nombre_artistico TNombreCorto,
    @pais_origen TNombreCorto,
    @genero_principal TGenero,
    @fecha_inicio DATE,
    @biografia TDescripcion,
    @imagen TDescripcion,
    @fecha_formacion DATE,
    @fecha_disolucion DATE = NULL
AS
BEGIN
    EXEC InsertArtista @id_artista, @nombre_artistico, 'grupo', @pais_origen, @genero_principal, @fecha_inicio, @biografia, @imagen;
    INSERT INTO GrupoMusical (id_artista, fecha_formacion, fecha_disolucion)
    VALUES (@id_artista, @fecha_formacion, @fecha_disolucion);
END;
GO

-- Insertar Integrante de Grupo
CREATE PROCEDURE InsertIntegranteGrupo
    @id_artista_grupo TId,
    @id_artista_miembro TId,
    @rol TNombreCorto,
    @fecha_ingreso DATE,
    @fecha_salida DATE = NULL
AS
BEGIN
    INSERT INTO IntegranteGrupo (id_artista_grupo, id_artista_miembro, rol, fecha_ingreso, fecha_salida)
    VALUES (@id_artista_grupo, @id_artista_miembro, @rol, @fecha_ingreso, @fecha_salida);
END;
GO

-- Insertar Producto (general)
CREATE PROCEDURE InsertProducto
    @id_producto TId,
    @titulo TNombreLargo,
    @precio_unitario TPrecio
AS
BEGIN
    INSERT INTO Producto (id_producto, titulo, precio_unitario)
    VALUES (@id_producto, @titulo, @precio_unitario);
END;
GO

-- Insertar Álbum
CREATE PROCEDURE InsertAlbum
    @id_producto TId,
    @titulo TNombreLargo,
    @precio_unitario TPrecio,
    @fecha_lanzamiento DATE,
    @id_artista_principal TId
AS
BEGIN
    EXEC InsertProducto @id_producto, @titulo, @precio_unitario;
    INSERT INTO Album (id_producto, fecha_lanzamiento, id_artista_principal)
    VALUES (@id_producto, @fecha_lanzamiento, @id_artista_principal);
END;
GO

-- Insertar Canción
CREATE PROCEDURE InsertCancion
    @id_producto TId,
    @titulo TNombreLargo,
    @precio_unitario TPrecio,
    @duracion TIME,
    @formato TFormato,
    @genero TGenero,
    @es_sencillo BIT,
    @id_album TId = NULL,
    @id_artista_principal TId
AS
BEGIN
    EXEC InsertProducto @id_producto, @titulo, @precio_unitario;
    INSERT INTO Cancion (id_producto, duracion, formato, genero, es_sencillo, id_album, id_artista_principal)
    VALUES (@id_producto, @duracion, @formato, @genero, @es_sencillo, @id_album, @id_artista_principal);
END;
GO

-- Insertar Colaboración
CREATE PROCEDURE InsertColaboracion
    @id_cancion TId,
    @id_artista TId,
    @rol TNombreCorto
AS
BEGIN
    INSERT INTO Colaboracion (id_cancion, id_artista, rol)
    VALUES (@id_cancion, @id_artista, @rol);
END;
GO

-- Insertar Cliente
CREATE PROCEDURE InsertCliente
    @nombre TNombreCorto,
    @correo_electronico TCorreo,
    @contraseña TPassword,
    @direccion TDescripcion
AS
BEGIN
    INSERT INTO Cliente (nombre, correo_electronico, contraseña, direccion)
    VALUES (@nombre, @correo_electronico, @contraseña, @direccion);
END;
GO

-- Insertar Comprobante de Venta
CREATE PROCEDURE InsertComprobanteVenta
    @id_cliente INT,
    @fecha_venta DATETIME = NULL,
    @id_comprobante INT OUTPUT
AS
BEGIN
    IF @fecha_venta IS NULL
        SET @fecha_venta = GETDATE();

    INSERT INTO ComprobanteVenta (id_cliente, fecha_venta)
    VALUES (@id_cliente, @fecha_venta);

    SET @id_comprobante = SCOPE_IDENTITY();
END;
GO

-- Insertar Detalle de Venta
CREATE PROCEDURE InsertDetalleVenta
    @id_comprobante INT,
    @id_producto TId,
    @precio_unitario TPrecio
AS
BEGIN
    INSERT INTO DetalleVenta (id_comprobante, id_producto, precio_unitario)
    VALUES (@id_comprobante, @id_producto, @precio_unitario);
END;
GO

-- =========================
-- Functions
-- =========================

-- Obtener el total de ventas de un cliente
CREATE FUNCTION GetTotalVentasCliente
(
    @id_cliente INT
)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @total_ventas DECIMAL(10, 2);

    SELECT @total_ventas = SUM(dv.precio_unitario)
    FROM ComprobanteVenta cv
    JOIN DetalleVenta dv ON cv.id_comprobante = dv.id_comprobante
    WHERE cv.id_cliente = @id_cliente;

    RETURN ISNULL(@total_ventas, 0.00);
END;
GO

-- =========================
-- Stored Procedures de Selección
-- =========================

-- Obtener Artistas
CREATE PROCEDURE GetArtistas
    @nombre_artistico_filtro TNombreCorto = NULL
AS
BEGIN
    SELECT
        A.id_artista,
        A.nombre_artistico,
        A.tipo_artista,
        A.pais_origen,
        A.genero_principal,
        A.fecha_inicio,
        A.biografia,
        A.imagen,
        CASE WHEN ASol.id_artista IS NOT NULL THEN ASol.nombre_real ELSE NULL END AS nombre_real_solista,
        CASE WHEN ASol.id_artista IS NOT NULL THEN ASol.fecha_nacimiento ELSE NULL END AS fecha_nacimiento_solista,
        CASE WHEN ASol.id_artista IS NOT NULL THEN ASol.sexo ELSE NULL END AS sexo_solista,
        CASE WHEN GMus.id_artista IS NOT NULL THEN GMus.fecha_formacion ELSE NULL END AS fecha_formacion_grupo,
        CASE WHEN GMus.id_artista IS NOT NULL THEN GMus.fecha_disolucion ELSE NULL END AS fecha_disolucion_grupo
    FROM Artista A
    LEFT JOIN ArtistaSolista ASol ON A.id_artista = ASol.id_artista
    LEFT JOIN GrupoMusical GMus ON A.id_artista = GMus.id_artista
    WHERE (@nombre_artistico_filtro IS NULL OR A.nombre_artistico LIKE '%' + @nombre_artistico_filtro + '%');
END;
GO

-- Obtener Canciones
CREATE PROCEDURE GetCanciones
    @titulo_filtro TNombreLargo = NULL,
    @genero_filtro TGenero = NULL,
    @artista_filtro TNombreCorto = NULL
AS
BEGIN
    SELECT
        C.id_producto AS id_cancion,
        P_Cancion.titulo AS titulo_cancion,
        P_Cancion.precio_unitario,
        C.duracion,
        C.formato,
        C.genero,
        C.es_sencillo,
        C.id_album,
        P_Album.titulo AS titulo_album,
        Art.nombre_artistico AS artista_principal,
        Art.id_artista AS id_artista_principal
    FROM Cancion C
    JOIN Producto P_Cancion ON C.id_producto = P_Cancion.id_producto
    LEFT JOIN Album A ON C.id_album = A.id_producto
    LEFT JOIN Producto P_Album ON A.id_producto = P_Album.id_producto
    JOIN Artista Art ON C.id_artista_principal = Art.id_artista
    WHERE ( @titulo_filtro IS NULL OR P_Cancion.titulo LIKE '%' + @titulo_filtro + '%')
      AND ( @genero_filtro IS NULL OR C.genero LIKE '%' + @genero_filtro + '%')
      AND ( @artista_filtro IS NULL OR Art.nombre_artistico LIKE '%' + @artista_filtro + '%');
END;
GO

-- Obtener Álbumes
CREATE PROCEDURE GetAlbums
    @titulo_filtro TNombreLargo = NULL,
    @artista_filtro TNombreCorto = NULL
AS
BEGIN
    SELECT
        Al.id_producto AS id_album,
        P.titulo AS titulo_album,
        P.precio_unitario,
        Al.fecha_lanzamiento,
        Art.nombre_artistico AS artista_principal,
        Art.id_artista AS id_artista_principal,
        Al.EsAlbumCompleto -- Incluir la nueva columna
    FROM Album Al
    JOIN Producto P ON Al.id_producto = P.id_producto
    JOIN Artista Art ON Al.id_artista_principal = Art.id_artista
    WHERE (@titulo_filtro IS NULL OR P.titulo LIKE '%' + @titulo_filtro + '%')
      AND (@artista_filtro IS NULL OR Art.nombre_artistico LIKE '%' + @artista_filtro + '%');
END;
GO

-- =========================
-- Trigger para actualizar EsAlbumCompleto
-- =========================
CREATE TRIGGER trg_UpdateAlbumCompleto
ON Cancion
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Obtener los IDs de álbum afectados por la operación
    DECLARE @AffectedAlbumIds TABLE (id_album TId);

    INSERT INTO @AffectedAlbumIds (id_album)
    SELECT DISTINCT id_album FROM INSERTED WHERE id_album IS NOT NULL;

    INSERT INTO @AffectedAlbumIds (id_album)
    SELECT DISTINCT id_album FROM DELETED WHERE id_album IS NOT NULL
    AND id_album NOT IN (SELECT id_album FROM @AffectedAlbumIds);

    -- Actualizar el estado EsAlbumCompleto para los álbumes afectados
    UPDATE A
    SET EsAlbumCompleto = CASE
                            WHEN (SELECT COUNT(*) FROM Cancion WHERE id_album = A.id_producto) >= 2 THEN 1
                            ELSE 0
                          END
    FROM Album A
    JOIN @AffectedAlbumIds aff ON A.id_producto = aff.id_album;
END;
GO

-- Obtener Clientes
CREATE PROCEDURE GetClientes
AS
BEGIN
    SELECT id_cliente, nombre, correo_electronico, direccion
    FROM Cliente;
END;
GO

-- Actualizar Cliente
CREATE PROCEDURE UpdateCliente
    @id_cliente INT,
    @nombre TNombreCorto,
    @correo_electronico TCorreo,
    @contraseña TPassword,
    @direccion TDescripcion
AS
BEGIN
    UPDATE Cliente
    SET
        nombre = @nombre,
        correo_electronico = @correo_electronico,
        contraseña = @contraseña,
        direccion = @direccion
    WHERE id_cliente = @id_cliente;
END;
GO

-- Eliminar Cliente
CREATE PROCEDURE DeleteCliente
    @id_cliente INT
AS
BEGIN
    DELETE FROM Cliente
    WHERE id_cliente = @id_cliente;
END;
GO

CREATE PROCEDURE DeleteComprobantesByCliente
@id_cliente INT
AS
BEGIN
-- Eliminar los detalles de venta asociados a los comprobantes de este cliente
DELETE FROM DetalleVenta
WHERE id_comprobante IN (SELECT id_comprobante FROM ComprobanteVenta WHERE id_cliente = @id_cliente);

-- Luego, eliminar los comprobantes de venta de este cliente
DELETE FROM ComprobanteVenta
WHERE id_cliente = @id_cliente;
END;


IF OBJECT_ID('InsertAlbum', 'P') IS NOT NULL
    DROP PROCEDURE InsertAlbum;
GO

CREATE PROCEDURE InsertAlbum
    @id_producto VARCHAR(6),
    @titulo NVARCHAR(200),
    @precio_unitario DECIMAL(10,2),
    @fecha_lanzamiento DATE,
    @id_artista_principal VARCHAR(6)
AS
BEGIN
    EXEC InsertProducto @id_producto, @titulo, @precio_unitario;
    INSERT INTO Album (id_producto, fecha_lanzamiento, id_artista_principal)
    VALUES (@id_producto, @fecha_lanzamiento, @id_artista_principal);
END;
GO

CREATE PROCEDURE UpdateAlbum
    @id_album VARCHAR(6),
    @titulo NVARCHAR(200),
    @precio_unitario DECIMAL(10,2),
    @fecha_lanzamiento DATE,
    @id_artista_principal VARCHAR(6)
AS
BEGIN
    UPDATE Producto
    SET titulo = @titulo,
        precio_unitario = @precio_unitario
    WHERE id_producto = @id_album;

    UPDATE Album
    SET fecha_lanzamiento = @fecha_lanzamiento,
        id_artista_principal = @id_artista_principal
    WHERE id_producto = @id_album;
END;
GO


CREATE PROCEDURE DeleteCancionesByAlbum
    @id_album VARCHAR(6)
AS
BEGIN
    DELETE FROM Cancion
    WHERE id_album = @id_album;
END;
GO

CREATE PROCEDURE DeleteAlbum
    @id_album VARCHAR(6)
AS
BEGIN
    -- Primero, eliminar las canciones asociadas a este álbum
    EXEC DeleteCancionesByAlbum @id_album;

    -- Luego, eliminar el álbum de la tabla Album
    DELETE FROM Album
    WHERE id_producto = @id_album;

    -- Finalmente, eliminar el producto asociado al álbum
    DELETE FROM Producto
    WHERE id_producto = @id_album;
END;
GO

CREATE PROCEDURE DeleteComprobantesByCliente
    @id_cliente INT
AS
BEGIN
    -- Eliminar los detalles de venta asociados a los comprobantes de este cliente
    DELETE FROM DetalleVenta
    WHERE id_comprobante IN (
        SELECT id_comprobante FROM ComprobanteVenta WHERE id_cliente = @id_cliente
    );

    -- Luego, eliminar los comprobantes de venta de este cliente
    DELETE FROM ComprobanteVenta
    WHERE id_cliente = @id_cliente;
END;
GO


CREATE PROCEDURE InsertProducto
    @id_producto VARCHAR(6),
    @titulo NVARCHAR(200),
    @precio_unitario DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Producto (id_producto, titulo, precio_unitario)
    VALUES (@id_producto, @titulo, @precio_unitario);
END;
GO

CREATE PROCEDURE InsertArtistaSolista
    @id_artista VARCHAR(6),
    @nombre_artistico NVARCHAR(100),
    @pais_origen NVARCHAR(100),
    @genero_principal NVARCHAR(100),
    @fecha_inicio DATE,
    @biografia NVARCHAR(1000),
    @imagen NVARCHAR(1000),
    @nombre_real NVARCHAR(100),
    @fecha_nacimiento DATE,
    @sexo NVARCHAR(10)
AS
BEGIN
    INSERT INTO Artista (id_artista, nombre_artistico, tipo_artista, pais_origen, genero_principal, fecha_inicio, biografia, imagen)
    VALUES (@id_artista, @nombre_artistico, 'solista', @pais_origen, @genero_principal, @fecha_inicio, @biografia, @imagen);

    INSERT INTO ArtistaSolista (id_artista, nombre_real, fecha_nacimiento, sexo)
    VALUES (@id_artista, @nombre_real, @fecha_nacimiento, @sexo);
END;
GO


CREATE PROCEDURE InsertGrupoMusical
    @id_artista VARCHAR(6),
    @nombre_artistico NVARCHAR(100),
    @pais_origen NVARCHAR(100),
    @genero_principal NVARCHAR(100),
    @fecha_inicio DATE,
    @biografia NVARCHAR(1000),
    @imagen NVARCHAR(1000),
    @fecha_formacion DATE,
    @fecha_disolucion DATE = NULL
AS
BEGIN
    INSERT INTO Artista (id_artista, nombre_artistico, tipo_artista, pais_origen, genero_principal, fecha_inicio, biografia, imagen)
    VALUES (@id_artista, @nombre_artistico, 'grupo', @pais_origen, @genero_principal, @fecha_inicio, @biografia, @imagen);

    INSERT INTO GrupoMusical (id_artista, fecha_formacion, fecha_disolucion)
    VALUES (@id_artista, @fecha_formacion, @fecha_disolucion);
END;
GO


CREATE PROCEDURE UpdateArtistaSolista
    @id_artista VARCHAR(6),
    @nombre_artistico NVARCHAR(100),
    @pais_origen NVARCHAR(100),
    @genero_principal NVARCHAR(100),
    @fecha_inicio DATE,
    @biografia NVARCHAR(1000),
    @imagen NVARCHAR(1000),
    @nombre_real NVARCHAR(100),
    @fecha_nacimiento DATE,
    @sexo NVARCHAR(10)
AS
BEGIN
    UPDATE Artista
    SET nombre_artistico = @nombre_artistico,
        pais_origen = @pais_origen,
        genero_principal = @genero_principal,
        fecha_inicio = @fecha_inicio,
        biografia = @biografia,
        imagen = @imagen
    WHERE id_artista = @id_artista;

    UPDATE ArtistaSolista
    SET nombre_real = @nombre_real,
        fecha_nacimiento = @fecha_nacimiento,
        sexo = @sexo
    WHERE id_artista = @id_artista;
END;
GO


CREATE PROCEDURE UpdateGrupoMusical
    @id_artista VARCHAR(6),
    @nombre_artistico NVARCHAR(100),
    @pais_origen NVARCHAR(100),
    @genero_principal NVARCHAR(100),
    @fecha_inicio DATE,
    @biografia NVARCHAR(1000),
    @imagen NVARCHAR(1000),
    @fecha_formacion DATE,
    @fecha_disolucion DATE = NULL
AS
BEGIN
    UPDATE Artista
    SET nombre_artistico = @nombre_artistico,
        pais_origen = @pais_origen,
        genero_principal = @genero_principal,
        fecha_inicio = @fecha_inicio,
        biografia = @biografia,
        imagen = @imagen
    WHERE id_artista = @id_artista;

    UPDATE GrupoMusical
    SET fecha_formacion = @fecha_formacion,
        fecha_disolucion = @fecha_disolucion
    WHERE id_artista = @id_artista;
END;
GO

CREATE PROCEDURE DeleteCancionesByArtista
    @id_artista VARCHAR(6)
AS
BEGIN
    DELETE FROM Cancion
    WHERE id_artista_principal = @id_artista;
END;
GO


CREATE PROCEDURE DeleteAlbumsByArtista
    @id_artista VARCHAR(6)
AS
BEGIN
    -- Primero, eliminar las canciones de los álbumes de este artista
    DELETE FROM Cancion
    WHERE id_album IN (SELECT id_producto FROM Album WHERE id_artista_principal = @id_artista);

    -- Luego, eliminar los álbumes de este artista
    DELETE FROM Album
    WHERE id_artista_principal = @id_artista;
END;
GO

CREATE PROCEDURE DeleteArtista
    @id_artista VARCHAR(6)
AS
BEGIN
    -- Eliminar canciones y álbumes asociados
    EXEC DeleteCancionesByArtista @id_artista;
    EXEC DeleteAlbumsByArtista @id_artista;

    -- Eliminar de tablas de subtipo
    DELETE FROM ArtistaSolista WHERE id_artista = @id_artista;
    DELETE FROM GrupoMusical WHERE id_artista = @id_artista;
    DELETE FROM IntegranteGrupo WHERE id_artista_grupo = @id_artista OR id_artista_miembro = @id_artista;

    -- Finalmente, eliminar de la tabla principal Artista
    DELETE FROM Artista
    WHERE id_artista = @id_artista;
END;
GO




