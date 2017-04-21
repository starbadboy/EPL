Hosting:https://member3.smarterasp.net/account/account_screen
Account : starbadboy 1234567a!

Database Server: sql5035.smarterasp.net
Account :DB_A1ACC5_test_admin 1234567a




Production link:
http://starbadboy-001-site1.atempurl.com/



insert into [DB_A1ACC5_test].[dbo].[TeamInfo]
  (TeamId,TeamName,TeamStadium)
  VALUES
  (91,'Bournemouth','Vitality Stadium'),
  (25,'Middlesbrough','Riverside Stadium'),
  (88,'Hull','KCOM Stadium, Hull'),
  (57,'Watford','Vicarage Road'),
  (80,'Swansea','Liberty Stadium'),
  (110,'Stoke','Bet365 Stadium'),
  (3,'Arsenal','Emirates Stadium'),
  (90,'Burnley','Turf Moor'),
  (8,'Chelse','Stamford Bridge'),
  (31,'Crystal Palace','Sellhurst Park'),
  (11,'Everton','Goodison Park'),
  (13,'Leicester City','King Power Stadium'),
  (14,'Liverpool','Anfield'),
  (1,'Manchester United','Old Trafford'),
  (20,'Southampton','St. Mary''s Stadium'),
  (6,'Tottenham Hotspur','White Hart Lane'),
  (35,'West Bromwich Albion','The Hawthorns'),
  (21,'West Ham United','London Stadium'),
  (43,'Manchester City','Etihad Stadium'),
  (56,'Sunderland','Stadium of Light')
  
  
  
    update Table_A set Table_A.HomeTeam=b.TeamName,Table_A.Stadium=b.TeamStadium 
  from
  Schedule AS Table_A
  inner join
   (select teamid,teamname,teamstadium from TeamInfo where TeamId in(90,14)) as b
   on Table_A.Homeid=b.TeamId 
 


insert into [DB_A1ACC5_test].[dbo].[Schedule](homeid,awayid,time) VALUES(91,25,'2017-04-22 22:00:00'),
   (88,57,'2017-04-22 22:00:00'),
   (80,110,'2017-04-22 22:00:00'),
   (21,11,'2017-04-22 22:00:00'),
   (90,1,'2017-04-23 21:15:00'),
   (14,31,'2017-04-23 23:30:00'),
   (8,20,'2017-04-26 02:45:00'),
   (3,13,'2017-04-27 02:45:00'),
   (25,56,'2017-04-27 02:45:00'),
   (31,6,'2017-04-27 03:00:00'),
   (43,1,'2017-04-28 03:00:00'),
   (20,88,'2017-04-29 22:00:00'),
   (110,21,'2017-04-29 22:00:00'),
   (56,91,'2017-04-29 22:00:00'),
   (35,13,'2017-04-29 22:00:00'),
   (25,90,'2017-04-30 00:30:00'),
   (1,80,'2017-04-30 19:00:00'),
   (11,8,'2017-04-30 21:05:00'),
   (25,43,'2017-04-30 21:05:00'),
   (6,3,'2017-04-30 23:30:00')
  
  
  
