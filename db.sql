
--drop database db_generador_frm
create database db_generador_frm
go

use db_generador_frm;
go


--tipo de control html
create table tb_tipo_campo(
	id int primary key identity,
	nombre varchar(255)
);

insert into tb_tipo_campo(nombre)
select 'text';

insert into tb_tipo_campo(nombre)
select 'label';

insert into tb_tipo_campo(nombre)
select 'select';

insert into tb_tipo_campo(nombre)
select 'select_option';

insert into tb_tipo_campo(nombre)
select 'number';

insert into tb_tipo_campo(nombre)
select 'email';

insert into tb_tipo_campo(nombre)
select 'password';

insert into tb_tipo_campo(nombre)
select 'textarea';

insert into tb_tipo_campo(nombre)
select 'button';

insert into tb_tipo_campo(nombre)
select 'submit';

insert into tb_tipo_campo(nombre)
select 'radio';

insert into tb_tipo_campo(nombre)
select 'checkbox';

insert into tb_tipo_campo(nombre)
select 'password';

insert into tb_tipo_campo(nombre)
select 'rut_cl';

insert into tb_tipo_campo(nombre)
select 'toogle_bt';

insert into tb_tipo_campo(nombre)
select 'datetime';

insert into tb_tipo_campo(nombre)
select 'date';

insert into tb_tipo_campo(nombre)
select 'time';

insert into tb_tipo_campo(nombre)
select 'relog';

insert into tb_tipo_campo(nombre)
select 'hidden';

--evento asociado para los controles
create table tb_evento_control(
	id int identity,
	nombre varchar(255),
	primary key(id)
);

insert into tb_evento_control(nombre)
select 'onclick';

insert into tb_evento_control(nombre)
select 'ondblclick';

insert into tb_evento_control(nombre)
select 'onchange';

insert into tb_evento_control(nombre)
select 'onblur';

insert into tb_evento_control(nombre)
select 'onmousedown';

insert into tb_evento_control(nombre)
select 'onmouseenter';

insert into tb_evento_control(nombre)
select 'onmouseleave';

insert into tb_evento_control(nombre)
select 'onmouseover';

insert into tb_evento_control(nombre)
select 'onkeypress';

insert into tb_evento_control(nombre)
select 'onkeyup';

insert into tb_evento_control(nombre)
select 'onfocus';

insert into tb_evento_control(nombre)
select 'onselect';

insert into tb_evento_control(nombre)
select 'onsubmit';

insert into tb_evento_control(nombre)
select 'onload';

--parametros para eventos asociados a los controles
create table tb_evento_control_parametro(
	id int,	
	nombre varchar(255),
	tipo varchar(50),
	evento_control_id int,
	primary key(id),
	foreign key (evento_control_id) references tb_evento_control(id)
);

--grupo al que pertenece el control
create table tb_grupo_ctrl(
	id int identity,
	nombre varchar(255),
	primary key(id)
);

insert into tb_grupo_ctrl(nombre)
select 'grupo_pruebas';


--control html
create table tb_control(
	id int identity not null,
	html_name varchar(100) not null,
	html_id varchar(100) not null,
	html_class varchar(300) null,
	html_required varchar(100) null,
	html_visible varchar(100) null,
	html_value varchar(500) null,
	html_text varchar(500) null,
	html_largo int null,
	html_placeholder varchar(255) null,
	tipo_campo_id int not null,
	grupo_ctrl_id int not null,
	primary key(id),
	foreign key (tipo_campo_id) references tb_tipo_campo(id),
	foreign key (grupo_ctrl_id) references tb_grupo_ctrl(id)
);

--prueba
insert into tb_control(html_name,html_id,html_class,html_required,html_visible,html_value,html_text,html_largo,tipo_campo_id,grupo_ctrl_id)
select 'txt_campo_prueba','txt_campo_prueba','form-control','required','visible','','',20,1,1;
--select * from tb_control
--asociacion del evento al control
create table tb_control_evento(
	id int identity,
	control_id int,
	nombre_fnc_js varchar(200),
	evento_control_id int,
	foreign key (control_id) references tb_control(id),
	foreign key (evento_control_id) references tb_evento_control(id)
);

--SPs
create procedure sp_get_tipoCampo
as 
begin
	select id, nombre
	from tb_tipo_campo
end;

create procedure sp_get_tipoCampoPorId(
	@id int
)
as 
begin
	select id, nombre
	from tb_tipo_campo
	where id = @id
end;

create procedure sp_get_grupoControles
as
begin 
	select * 
	from tb_grupo_ctrl
end;



