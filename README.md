# API-Filmes
A API servirá de repositório para inserção de filmes 

Para execute-la siga os seguintes passos:

1-Clone o projeto

2-Execute - SQL SERVER

CREATE DATABASE Filme
USE Filme
CREATE TABLE Filme
(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Nome VARCHAR(100),
	[url] VARCHAR(MAX),
)

ALTER TABLE Filme ADD
	Categoria_Id INT NOT NULL,
	Streaming_Id INT NOT NULL,
	Nacionalidade_Id INT NOT NULL,

CREATE TABLE CategoriaFilme
(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Categoria VARCHAR(50),
)

CREATE TABLE StreamingFilme
(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Nome VARCHAR(50),
)

CREATE TABLE NacionalidadeFilme
(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Nacionalidade VARCHAR(50),
)

3- Abra o visual studio 2022 e atualize o .NET para a versão 6

4- Altere o appsettings.json com a sua connection string

5- Abra o Console do gerenciador de pacotes

6- insira dotnet ef dbcontext scaffold "Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models
*Substitua com a sua a sua string de conexão*
