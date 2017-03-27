using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using EPL.DataModel;

namespace EPL.Repository
{
    public class EplRepo
    {
        private readonly SqlConnection _connection;

        public EplRepo()
        {
            _connection = new SqlConnection(@"Server = sql5035.smarterasp.net; Database = DB_A1ACC5_test; User ID = DB_A1ACC5_test_admin; Password = 1234567a;");
            _connection.Open();
        }

        public List<Schedule> GetAllSchedule()
        {
            var sql = @"select * from schedule order by time";
            return _connection.Query<Schedule>(sql).ToList();
        
        }
        public void UpSertSchedule(Schedule scheduler)
        {
            var sql = @"IF EXISTS(SELECT 1 FROM  [dbo].[Schedule] WHERE Id=@Id)  
                         BEGIN UPDATE  [dbo].[Schedule] 
                              SET Homeid=(select TeamId from TeamInfo where TeamName=@HomeTeam),Awayid=(select TeamId from TeamInfo where TeamName=@AwayTeam),HomeTeam=@HomeTeam,AwayTeam=@AwayTeam,Link=@Link,Time=@Time where Id=@Id;
                         END ELSE BEGIN
                         INSERT INTO [dbo].[Schedule] ([Homeid],[Awayid],[HomeTeam],[AwayTeam],[Stadium] ,[Link],[Time])
                         VALUES ((select TeamId from TeamInfo where TeamName=@HomeTeam) ,(select TeamId from TeamInfo where TeamName=@AwayTeam),@HomeTeam,@AwayTeam,(select TeamStadium from TeamInfo where TeamName=@HomeTeam),@Link,@Time)
                         End";
            _connection.Execute(sql, scheduler);
            _connection.Close();
        }

        public void DeleteSchedule(int i)
        {
            var sql = @"delete from schedule where id ="+i;
            _connection.Execute(sql);
            _connection.Close();
        }
    }
}