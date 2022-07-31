"# IMDB.Solution" 

apis:
1. GET - api/Movies/GetAllMovies
2. GET - api/Actor/GetAllActors
3. GET - api/Producer/GetAllProducer
3. POST - api/Producer/AddProducer
5. POST - api/Actor/AddActor
6. POST - api/Movies/AddMovieDetails
7. PUT - api/Movies/ModifyMovieDetails


Pre-requisite DB scripts to be run in MS SQL - SSMS :

CREATE DATABASE IMDBDataBase
go

Use IMDBDataBase
go
IF OBJECT_ID('Movies')  IS NOT NULL
DROP TABLE Movies
GO
IF OBJECT_ID('Actors')  IS NOT NULL
DROP TABLE Actors
GO
IF OBJECT_ID('Producers')  IS NOT NULL
DROP TABLE Producers
GO
IF OBJECT_ID('MoviesActors')  IS NOT NULL
DROP TABLE MoviesActors
GO

create Table Movies(
		[MovieId] int identity(1001,1) primary key not null,
		[MovieName] nvarchar(50),
		[PosterImageSource] nvarchar(200),
		[DateOfRelease] date,
		[Plot] nvarchar(200),
		[Producer] int constraint fk_producer references Producers(ProducerId) not null,
		)
Insert into Movies(MovieName, PosterImageSource, DateOfRelease, Producer) values
	('My Beautiful Laundrette', 'my_beautiful_laundrette.png', '2022-08-01', 101 )
Insert into Movies(MovieName, PosterImageSource, DateOfRelease, Producer) values
	('Dead Men Tell No Tales', 'dead_men_tell_no_tales.png', '2022-07-02', 102 )
Insert into Movies(MovieName, PosterImageSource, DateOfRelease, Producer) values
	('Harry Porter', 'harry_porter.png', '2022-06-02', 103 )
Insert into Movies(MovieName, PosterImageSource, DateOfRelease, Producer) values
	('The Great Minds', 'the_great_minds.png', '2022-05-02', 102 )
Insert into Movies(MovieName, PosterImageSource, DateOfRelease, Producer) values
	('The Wilds', 'the_wilds.png', '2022-08-02', 101 )
	
create Table Actors(
		[ActorId] int identity primary key not null,
		[ActorName] nvarchar(100) not null,
		[ActorBio] nvarchar(300),
		[DateOfBirth] Date CONSTRAINT chk_DateOfBirthActor CHECK(DateOfBirth<GETDATE()) not null,
		[Gender] nvarchar(10) CONSTRAINT chk_GenderActor CHECK(Gender='Female' OR Gender='Male' OR Gender='Others') NOT NULL,
		)
Insert into Actors(ActorName, ActorBio, DateOfBirth, Gender) values 
	('Benedict Cumberbatch','My Beautiful Laundrette', '1984-09-28', 'Male')

Insert into Actors(ActorName, ActorBio, DateOfBirth, Gender) values 
	('Patrick Stewart','My Beautiful Laundrette', '1989-10-18', 'Male')

Insert into Actors(ActorName, ActorBio, DateOfBirth, Gender) values 
	('Christian Bale','The Dark Knight', '1974-01-30', 'Male')

create Table MoviesActors(
	[ID] int identity(20001, 1) primary key not null,
	[ActorId] int constraint fk_ActorId references Actors(ActorId) not null,
	[MovieId] int constraint fk_MovieId references Movies(MovieId) not null,
	)
Insert into MoviesActors(ActorId, MovieId) values (1, 1001)
Insert into MoviesActors(ActorId, MovieId) values (1, 1002)
Insert into MoviesActors(ActorId, MovieId) values (2, 1001)
Insert into MoviesActors(ActorId, MovieId) values (3, 1001)


create Table Producers(
		[ProducerId] int identity(101,1) primary key not null,
		[ProducerName] nvarchar(50) not null,
		[ProducerBio] nvarchar(300),
		[DateOfBirth] Date constraint chk_DateOfBirth CHECK(DateOfBirth<GETDATE()) not null,
		[Company] nvarchar(100),
		[Gender] nvarchar(10) constraint chk_Gender CHECK(Gender='Female' OR Gender='Male' OR Gender='Others') not null,
		)
Insert into Producers(ProducerName, ProducerBio, DateOfBirth, Company, Gender) values
	('Christian Bale','My Beautiful Laundrette', '1981-03-26', 'bite into a bone','Male')
Insert into Producers(ProducerName, ProducerBio, DateOfBirth, Company, Gender) values
	('Jason Blum','It was a huge wake-up call', '1979-05-19', 'HBO','Male')
Insert into Producers(ProducerName, ProducerBio, DateOfBirth, Company, Gender) values
	('Jerry Bruckheimer','Dead Men Tell No Tales', '1965-08-11', 'Pirates','Male')

select * from Actors
select * from Producers
select * from Movies
select * from MoviesActors

