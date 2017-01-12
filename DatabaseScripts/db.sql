create database cswtestdb;
use cswtestdb;

create table authors (
    id uniqueidentifier primary key not null,
	name varchar(100)
);

create table categories (
    id uniqueidentifier primary key not null,
	name varchar(100)
);

create table books (
	id uniqueidentifier primary key not null,
	name varchar(150) not null,
	summary varchar(500) not null default '',
	price decimal(10,2) not null default 0,
	picture nvarchar(max), 
	id_author uniqueidentifier foreign key references authors(id),
	id_category uniqueidentifier foreign key references categories(id)
);


