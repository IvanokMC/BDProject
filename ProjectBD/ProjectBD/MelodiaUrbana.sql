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
