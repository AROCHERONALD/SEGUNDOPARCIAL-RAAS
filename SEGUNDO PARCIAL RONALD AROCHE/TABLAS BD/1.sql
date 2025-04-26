-- Creación de tablas
CREATE TABLE Jugadores (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Nivel INT DEFAULT 1,
    FechaCreacion DATETIME DEFAULT GETDATE()
);

CREATE TABLE Bloques (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50) NOT NULL,
    Tipo NVARCHAR(50) NOT NULL,
    Rareza NVARCHAR(20) NOT NULL
);

CREATE TABLE Inventario (
    Id INT PRIMARY KEY IDENTITY(1,1),
    JugadorId INT NOT NULL,
    BloqueId INT NOT NULL,
    Cantidad INT DEFAULT 1,
    FOREIGN KEY (JugadorId) REFERENCES Jugadores(Id),
    FOREIGN KEY (BloqueId) REFERENCES Bloques(Id)
);

-- Insertar 10 jugadores
INSERT INTO Jugadores (Nombre, Nivel) VALUES
('Steve', 15),
('Alex', 12),
('Notch', 99),
('Herobrine', 100),
('DiamondGamer', 45),
('RedstoneMaster', 32),
('CreeperHunter', 28),
('EndermanSlayer', 60),
('NetherExplorer', 38),
('VillageProtector', 22);

-- Insertar 10 bloques
INSERT INTO Bloques (Nombre, Tipo, Rareza) VALUES
('Madera de roble', 'Madera', 'Común'),
('Piedra', 'Mineral', 'Común'),
('Hierro', 'Mineral', 'Común'),
('Oro', 'Mineral', 'Raro'),
('Diamante', 'Mineral', 'Épico'),
('Esmeralda', 'Mineral', 'Épico'),
('Redstone', 'Mineral', 'Raro'),
('Lapislázuli', 'Mineral', 'Raro'),
('Obsidiana', 'Mineral', 'Raro'),
('Bloque de netherita', 'Mineral', 'Épico');

-- Insertar 10 registros de inventario
INSERT INTO Inventario (JugadorId, BloqueId, Cantidad) VALUES
(1, 1, 64),  -- Steve tiene 64 bloques de madera
(1, 3, 32),  -- Steve tiene 32 bloques de hierro
(2, 2, 128), -- Alex tiene 128 bloques de piedra
(3, 5, 5),   -- Notch tiene 5 diamantes
(4, 10, 1),  -- Herobrine tiene 1 bloque de netherita
(5, 5, 12),  -- DiamondGamer tiene 12 diamantes
(6, 7, 45),  -- RedstoneMaster tiene 45 redstone
(7, 4, 8),   -- CreeperHunter tiene 8 bloques de oro
(8, 6, 3),   -- EndermanSlayer tiene 3 esmeraldas
(9, 9, 14);  -- NetherExplorer tiene 14 obsidianas