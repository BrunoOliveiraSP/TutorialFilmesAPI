drop database moviedb;
create database moviedb;
use moviedb;


create table tb_filme (
	id_filme			int not null primary key auto_increment,
	nm_filme			varchar(100) not null ,
	ds_genero			varchar(100) not null ,
	vl_avaliacao		decimal(15,2) not null ,
	bt_disponivel		bool not null ,
	dt_estreia			datetime not null 
);


create table tb_diretor (
	id_diretor			int not null primary key auto_increment,
	nm_diretor			varchar(100) not null ,
	ds_pais				varchar(100) not null ,
	id_filme			int not null ,
	foreign key (id_filme) references tb_filme (id_filme)
);


create table tb_ator (
	id_ator				int not null primary key auto_increment,
	nm_ator				varchar(100) not null ,
	ds_pais				varchar(100) not null ,
	id_filme			int not null ,
	foreign key (id_filme) references tb_filme (id_filme)
);



insert into tb_filme (nm_filme, ds_genero, vl_avaliacao, bt_disponivel, dt_estreia) values ('Avengers: Endgame', 'Ação', 8.5, true, '2019-04-25');
insert into tb_filme (nm_filme, ds_genero, vl_avaliacao, bt_disponivel, dt_estreia) values ('Homem de Ferro', 'Ação', 7.0, true, '2008-04-14');

select * from tb_filme;



-- dotnet ef dbcontext scaffold "server=localhost;user id=root;password=1234;database=moviedb" Pomelo.EntityFrameworkCore.MySql -o Models --data-annotations --force

/*

    1. Introducao ao BD Relacional. Mostrar API e Tela funcionando
	2. Modelos Request. Funcionalidade Inserir. API. Versionamento de API
	3. Modelos Request. Funcionalidade Inserir. WinForm
	4. Retorno de ID no POST
    5. Modelos Response. Funcionalidade Consultar. API
	6. Modelos Response. Funcionalidade Consultar. WinForms. BindingList.
	7. Modelos UI. Consultar carregando Coluna Diretor e Qtd Atores

*/