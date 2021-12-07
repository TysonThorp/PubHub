

ALTER TABLE dbo.breweries
ADD brewery_name varchar (255); 

INSERT INTO breweries (brewery_owner_id ,brewery_name, email, phone, website, brewery_description, hours_operations, address, isActive)
VALUES

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