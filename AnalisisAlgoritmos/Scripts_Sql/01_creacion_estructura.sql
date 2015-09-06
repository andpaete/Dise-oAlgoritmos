--use master
--drop  database [estaDiseno]

use master
go
	create database [estaDiseno]
go
	use [estaDiseno]
go
	create table dbo.algoritmo
	(
		id_algoritmo	int not null identity(1,1),
		nom_algoritmo	varchar(100) not null,
		constraint pk_algoritmo primary key(id_algoritmo)
	);

insert into dbo.algoritmo(nom_algoritmo) values('BurbujaSimple');
insert into dbo.algoritmo(nom_algoritmo) values('BurbujaMejorado');
insert into dbo.algoritmo(nom_algoritmo) values('Insercion');
insert into dbo.algoritmo(nom_algoritmo) values('seleccion');
insert into dbo.algoritmo(nom_algoritmo) values('Shell');
insert into dbo.algoritmo(nom_algoritmo) values('ArbolBinarioBusqueda');


create table dbo.rango
(
	id_rango		int  not null identity(1,1),
	valorInical		int  not null,
	valorFinal		int  not null,
	constraint pk_rango primary key(id_rango)
);


insert into dbo.rango(valorInical,valorFinal) values (0,100);
insert into dbo.rango(valorInical,valorFinal) values (0,1000);
insert into dbo.rango(valorInical,valorFinal) values (0,5000);
insert into dbo.rango(valorInical,valorFinal) values (0,10000);
insert into dbo.rango(valorInical,valorFinal) values (0,50000);
insert into dbo.rango(valorInical,valorFinal) values (0,100000);
insert into dbo.rango(valorInical,valorFinal) values (0,200000);
insert into dbo.rango(valorInical,valorFinal) values (0,400000);
insert into dbo.rango(valorInical,valorFinal) values (0,600000);
insert into dbo.rango(valorInical,valorFinal) values (0,800000);
insert into dbo.rango(valorInical,valorFinal) values (0,1000000);
insert into dbo.rango(valorInical,valorFinal) values (0,2000000);
insert into dbo.rango(valorInical,valorFinal) values (0,3000000);
insert into dbo.rango(valorInical,valorFinal) values (0,4000000);
insert into dbo.rango(valorInical,valorFinal) values (0,5000000);
insert into dbo.rango(valorInical,valorFinal) values (0,6000000);
insert into dbo.rango(valorInical,valorFinal) values (0,7000000);
insert into dbo.rango(valorInical,valorFinal) values (0,8000000);
insert into dbo.rango(valorInical,valorFinal) values (0,9000000);
insert into dbo.rango(valorInical,valorFinal) values (0,10000000);

create table dbo.estadisticXalgoritmo
(
	id_estadisXalgorit		int not null identity(1,1),
	id_algoritmo			int not null,
	id_rango				int not null,
	tiempo_cpu				numeric(7,3) not null,
	tiempo_total_eje		numeric(7,3) not null,
	tiempo_e_s				numeric(7,3) not null,
	porcentaje_cpu_wall     numeric(7,3) not null
);

go
ALTER TABLE dbo.estadisticXalgoritmo
ADD CONSTRAINT fk_estadisticXalgoritmo
FOREIGN KEY (id_algoritmo)
REFERENCES dbo.algoritmo(id_algoritmo)
go
ALTER TABLE dbo.estadisticXalgoritmo
ADD CONSTRAINT fk_rango
FOREIGN KEY (id_rango)
REFERENCES dbo.rango(id_rango)