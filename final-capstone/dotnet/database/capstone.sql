USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE reviews(
	review_id int IDENTITY(1,1) NOT NULL,
	user_id int NOT NULL,
	beer_id int NOT NULL,
	rating int NOT NULL,
	review_description varchar(300) NOT NULL,
	PRIMARY KEY (review_id),
	--FOREIGN KEY (user_id) REFERENCES users(user_id)
	)

CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL,
	PRIMARY KEY (user_id),
	--CONSTRAINT FK_UserReview FOREIGN KEY (user_id) REFERENCES Reviews(user_id),
)
CREATE TABLE breweries (
	brewery_id int IDENTITY(1,1) NOT NULL,
	brewery_owner_id int NOT NULL, --foreign key of user?
	email varchar(50) NULL,
	phone varchar(12)  NULL,
	website varchar(2083) NULL,
	brewery_description varchar(500) NULL,
	hours_operations varchar(100) NULL,
	address varchar(50) NULL,
	isActive bit NOT NULL,
	PRIMARY KEY (brewery_id)
	)
CREATE TABLE beer(
	beer_id int IDENTITY(1,1) NOT NULL,
	beer_name varchar(30) NOT NULL,
	description varchar(150) NOT NULL,
	image varchar(150) NOT NULL,
	abv decimal(5,1) NOT NULL,
	beer_type varchar(25) NOT NULL,
	PRIMARY KEY (beer_id)
	)
CREATE TABLE beers_by_brewery(
	beer_id int NOT NULL,
	brewery_id int NOT NULL,)
	



--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

GO