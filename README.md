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





![AddActor](https://user-images.githubusercontent.com/109970604/182088373-d6084db2-147d-4cc7-8224-215efbb98ab9.png)
![addMovie](https://user-images.githubusercontent.com/109970604/182088375-0076f400-7a10-4d62-8a9d-acd9742891d2.png)
![AddProducer](https://user-images.githubusercontent.com/109970604/182088376-d34e4b2e-e343-4ba6-81ee-de7431755921.png)
![AllActors](https://user-images.githubusercontent.com/109970604/182088380-b9df20bc-e987-447a-b05a-bfd41d6ea0a5.png)
![AllMovies](https://user-images.githubusercontent.com/109970604/182088384-cac253e8-48a9-49f5-9bef-7c027d02a956.png)
![AllProducers](https://user-images.githubusercontent.com/109970604/182088388-b8be6d82-36c4-4374-b07b-7b0c4d5270de.png)
![ModifyMovieDetails](https://user-images.githubusercontent.com/109970604/182088442-854d29e5-d0b4-4582-b710-93942107f81d.png)







