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
 

  
  
  
