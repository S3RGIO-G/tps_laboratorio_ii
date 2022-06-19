create database BD_Productos;
GO
use BD_Productos;
GO
create table CatalogoProductos(
id int identity primary key,
nombre varchar(50) not null,
marca varchar(50) not null,
tipo varchar(50) not null,
precio float not null); 
GO
insert into CatalogoProductos (nombre, marca, tipo, precio) values ('Ryzen 5 5600x', 'AMD', 'Procesador', 200.5);
insert into CatalogoProductos (nombre, marca, tipo, precio) values ('AB350-m', 'Gigabyte', 'MotherBoard', 80.7);
insert into CatalogoProductos (nombre, marca, tipo, precio) values ('i5 12600KF', 'Intel', 'Procesador', 180.9);
insert into CatalogoProductos (nombre, marca, tipo, precio) values ('RX 6600xt', 'AMD', 'GPU', 350.9);
insert into CatalogoProductos (nombre, marca, tipo, precio) values ('Disco Solido 512gb', 'Team Group', 'SSD', 120.5);
insert into CatalogoProductos (nombre, marca, tipo, precio) values ('Fuente 500w', 'ThermalTake', 'PSU', 100.25);
insert into CatalogoProductos (nombre, marca, tipo, precio) values ('RTX 3060ti', 'NVIDIA', 'GPU', 450.75);
insert into CatalogoProductos (nombre, marca, tipo, precio) values ('Gabinete MATREXX 55', 'DeepCool', 'Case', 90.78);
insert into CatalogoProductos (nombre, marca, tipo, precio) values ('Memoria 8gb 2666mhz', 'Kingston', 'RAM', 35.24);
insert into CatalogoProductos (nombre, marca, tipo, precio) values ('Memoria 16gb 3200mhz', 'Team Group', 'RAM', 60.66);
insert into CatalogoProductos (nombre, marca, tipo, precio) values ('Ryzen 3 3200g', 'AMD', 'Procesador', 130.45);
insert into CatalogoProductos (nombre, marca, tipo, precio) values ('Fuente 700w', 'Gigabyte', 'PSU', 220.15);
insert into CatalogoProductos (nombre, marca, tipo, precio) values ('RTX 3050', 'Zotac', 'GPU', 300.23);
insert into CatalogoProductos (nombre, marca, tipo, precio) values ('Z690-A', 'ASUS', 'MotherBoard', 140.15);
insert into CatalogoProductos (nombre, marca, tipo, precio) values ('Disco Solido M2 240gb', 'AOURUS', 'SSD', 75.15);

select * from CatalogoProductos;