create table tbVeterinarios
(
IdVet tinyint primary key identity(1, 1),
Nombre varchar(30) not null,
ApellidoPaterno varchar(30) not null,
ApellidoMaterno varchar(30) not null,
Calle varchar(60) not null,
NumExt int,
NumInt varchar(10),
CodigoPostal int not null,
IdLocalidad Int not null,
NSS varchar(20) not null,
CURP varchar(18) not null,
Telefono varchar(10) not null,
SueldoXDia money not null,
TarjetaCredito int not null,
IdTipoPer tinyint,
IdArea smallint,
foreign key (IdLocalidad) references tbLocalidades (IdLocalidad),
foreign key (IdTipoPer) references tbTipoPersonal (IdTipoPer),
foreign key (IdArea) references tbAreas (IdArea) 
);

create table tbTipoPersonal(
IdTipoPer tinyint primary key identity (1, 1),
Tipo varchar(30) not null
);

create table tbAreas(
IdArea smallint primary key identity (1, 1),
Area varchar(30) not null,
Ubicacion varchar(80) not null
);

create table tbLocalidades(
IdLocalidad int primary key identity (1, 1),
Localidad varchar(100) not null,
IdMunicipio smallint,
foreign key (IdMunicipio) references tbMunicipios (IdMunicipio) 
);

create table tbMunicipios(
IdMunicipio smallint primary key identity (1, 1),
Municipio varchar(100) not null,
IdEstado tinyint,
foreign key (IdEstado) references tbEstados (IdEstado)
);

create table tbEstados(
IdEstado tinyint primary key identity (1, 1),
Estado varchar(70) not null
);