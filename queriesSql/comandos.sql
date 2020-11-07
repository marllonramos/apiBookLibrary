create table livros(
	Id uniqueidentifier not null,
	Titulo varchar(100) not null,
	Descricao text null,
	Status varchar(20) not null check(Status in('Inativo', 'Ativo')),
	EditoraId uniqueidentifier not null,
	AutorId uniqueidentifier not null,
	CategoriaId uniqueidentifier not null
);


select * from autores
select * from categorias
select * from editoras
select * from livros



select li.id as livroId, li.titulo, li.descricao, li.status, 
edi.Id as editoraId, edi.nome as editoraNome, 
categ.Id as categoriaId, categ.Nome as categoriaNome,
aut.Id as autorId, aut.Nome as autorNome
from livros li inner join editoras edi
on li.editoraId = edi.Id
inner join categorias categ
on li.categoriaId = categ.Id
inner join autores aut
on li.autorId = aut.Id
where li.Id = '61FE40A9-1B44-4222-9241-1964CCB88B9E'


SELECT li.id AS livroId, li.titulo, li.descricao, li.status, 
    edi.Id AS editoraId, edi.nome AS editoraNome, 
    categ.Id AS categoriaId, categ.Nome AS categoriaNome,
    aut.Id AS autorId, aut.Nome AS autorNome
FROM livros li INNER JOIN editoras edi
    ON li.editoraId = edi.Id
    INNER JOIN categorias categ
    ON li.categoriaId = categ.Id
    INNER JOIN autores aut
    ON li.autorId = aut.Id
    WHERE aut.Id = 'DF19D5F2-4F6C-47C4-A3A1-F1FAE5FC817F'


create table leitor(
	Id uniqueidentifier not null,
	Nome varchar(120) not null,
	Email varchar(60) not null,
	Password varchar(60) not null
);

create table exemplares(
	Id uniqueidentifier not null,
	IdLeitor uniqueidentifier not null,
	IdLivro uniqueidentifier not null,
	Status int not null,
	InicioDataLeitura datetime null,
	FimDataLeitura datetime null,
	UltimaDataParalisacao datetime null,
	Paralisacao int not null
);