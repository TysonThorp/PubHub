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
	rating int NULL,
	review_description varchar(300) NULL,
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
	brewery_name varchar (255),
	email varchar(50) NULL,
	phone varchar(12) NULL,
	website varchar(2083) NULL,
	brewery_description varchar(500) NULL,
	hours_operations varchar(100) NULL,
	address varchar(50) NULL,
	isActive bit NOT NULL,
	PRIMARY KEY (brewery_id)
	)
CREATE TABLE beers(
	beer_id int IDENTITY(1,1) NOT NULL,
	beer_name varchar(30) NOT NULL,
	description varchar(150) NULL,
	image varchar(150) NULL,
	abv decimal(5,1) NULL,
	beer_type varchar(25) NULL,
	PRIMARY KEY (beer_id)
	)
CREATE TABLE beers_by_brewery(
	beer_id int NOT NULL,
	brewery_id int NOT NULL,)
	

--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('brewer','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','brewer');

INSERT INTO breweries (brewery_owner_id ,brewery_name, email, phone, website, brewery_description, hours_operations, address, isActive)
VALUES
(1,'Listermann Brewing Company', 'jess@listermannbrewing.com', '513-731-1130', 'https://www.listermannbrewing.com/', 'Family Owned, Cincinnati Brewed award winning beer!
DRINK. LOCAL. BEER!',  'Sun-Th 12pm - 9pm Fr, Sat 12pm - 10pm', '1621 Dana Ave Cincinnati, OH 45207', 1),
(2, 'Madtree Brewing', 'info@madtreebrewing.com', '513-836-8733', 'https://www.madtreebrewing.com/','MadTree Brewing connects people with nature and each other.
Founded in 2013, join us as we rise above the noise deepening our roots to thrive and amplify our impact on the world and people around us. Cheers!', 
'M-Th 11am - 11pm Fri 11am - 12am Sat 10am - 12am', '3301 Madison Rd Cincinnati OH 45209',1),
(3,'Rhinegeist Brewery', 'taproom@rhinegeist.com', '513-381-1367', 'https://rhinegeist.com/','Rhinegeist Brewery is located in the Over-the-Rhine historical 
district in Cincinnati, OH. We brewed our first batch on June 8th, 2013. Open 7 days a week.', 'M-Th 12pm - 10pm F, Sat 12pm - 12am Sun 12pm - 9pm',
'1910 Elm St, Cincinnati, OH 45202',1),
(4, 'Braxton Brewing Company','social@braxtonbrewing.com','859-261-5600','https://www.braxtonbrewing.com/','We’re crossing the river so you don’t have to. A new location – Braxton Brewing Company Cincinnati!',
'M 3pm - 10pm T-Th 11am - 10pm Fri, Sat 11am - 12am Sun 11am - 9pm','27 W 7th St, Covington, KY 41011',1),
(5, 'Taft''s Ale House','info@taftsalehouse.com','513-334-1393','https://taftsbeer.com/','Based in the great state of Ohio, Taft’s Brewing Co. is an award-winning brewery that’s been pouring fresh, 
flavorful libations and serving fine fare since its founding in Cincinnati, Ohio in 2015. C’mon in to our bar and restaurant locations that include Taft’s Ale House, 
Taft’s Brewporium – Cincinnati, and now open, Taft’s Brewporium – Columbus, to treat your belly to a cold, crisp pint of beer and piping hot meal today.',
'Sun-Th 11:30am - 10pm Fr, Sat 1130am - 11pm','1429 Race St, Cincinnati, OH 45202',1);

INSERT INTO beers (beer_name, description, abv, beer_type)
VALUES
('Gavel Banger','American IPA brewed and dry hopped with heaps of Citra and Mosiac hops. Juicy, hoppy justice.', 7, 'American IPA'),
('Cold Boy','This anytime lager features American Pilsner malt and Saaz hops for a clean, balanced character that drinks smooth every time.', 4.5,'Lager'),
('UDF Milkshake IPA','This hoppy and creamy milkshake IPA is brewed with heaps of hops, 
lactose, oats, and flaked wheat to bring you a refreshing, adults-only treat.',6.6,'Milkshake IPA'),
('Nellie''s Key Lime Ale','American wheat beer brewed with keylime juice straight from the islands and a hint of coriander. Refreshingly fruity.',4.8,'American Wheat Ale'),
('Frisch''s Pumpkin Pie Ale','Hints of cinnamon, ginger, and nutmeg combine with lactose and vanilla for a smooth, creamy finish. Better than grandma used to make!',6,'Pumpkin Pie Ale'),
('Storm','This golden cream ale is a traditional American lawnmower beer, featuring a medium body with a creamy palate feel.',4.8,'Golden Cream Ale'),
('Garage Beer','This premium lager is incredibly refreshing and thirst quenching.',4,'Premium Lager'),
('Tropical Flare','This straw yellow, hazy IPA was carefully refined over a year of innovation and experimentation at Braxton Labs.',6.8,'New England IPA'),
('Summer Trip','This tart German style ale features 50% wheat malt and is balanced from the acidity of passionfruit.',4.2,'Berliner Weisse'),
('Black Raspberry Chocolate Chip','2018’s batch is brewed with even MORE pure Black Raspberry Purée. — An irresistible collaboration between two handcrafted families.',
7,'Pastry Stout')

INSERT INTO reviews (user_id, beer_id, rating, review_description)
VALUES (1, 2, 10, 'Example review text by user for beer 2 with rating 10'),
       (1, 2, 5, 'Example review text by user for beer 2 with rating 5'),
	   (2, 3, 7, 'Example review text by admin for beer 3 with rating 7')

GO