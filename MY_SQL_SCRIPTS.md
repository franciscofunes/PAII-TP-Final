# MySQL SERVER SCRIPTS USED

```sql
CREATE TABLE Alumnos (
    Id INT AUTO_INCREMENT NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    NumIdentificacion INT UNIQUE NOT NULL,
    FechaNacimiento DATE NOT NULL,
    Direccion VARCHAR(255) NOT NULL,
    Telefono VARCHAR(20) NOT NULL,
    CorreoElectronico VARCHAR(255) NOT NULL,
    Carrera VARCHAR(100) NOT NULL,
    Promedio DECIMAL(5, 2) CHECK (Promedio >= 1 AND Promedio <= 100) NOT NULL,
    FechaIngreso DATE NOT NULL,
    PRIMARY KEY (Id)
);

INSERT INTO Alumnos (Nombre, Apellido, NumIdentificacion, FechaNacimiento, Direccion, Telefono, CorreoElectronico, Carrera, Promedio, FechaIngreso)
VALUES
    ('Juan', 'Perez', 12345, '1990-05-15', '123 Calle Principal', '555-123-4567', 'juan.perez@email.com', 'Informática', 85.5, '2020-09-01'),
    ('Maria', 'Gomez', 54321, '1992-08-20', '456 Calle Secundaria', '555-987-6543', 'maria.gomez@email.com', 'Medicina', 91.2, '2019-10-15'),
    ('Pedro', 'Rodriguez', 67890, '1988-03-10', '789 Calle Terciaria', '555-456-7890', 'pedro.rodriguez@email.com', 'Derecho', 76.8, '2021-01-05');

CREATE TABLE Inscripciones (
    Id INT AUTO_INCREMENT NOT NULL,
    FechaInscripcion DATE NOT NULL,
    Detalles TEXT,
    Estado VARCHAR(50) NOT NULL,
    AlumnoId INT NOT NULL,
    PRIMARY KEY (Id)
);

```

