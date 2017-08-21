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

        private SqlConnection _localsqlConnection;
        private SqlConnection _productionsqlConnection;

        public EplRepo()
        {
            _localsqlConnection = new SqlConnection(@"Server = .\SQLEXPRESS; Database = Epldb; User ID = test; Password = 1234asdf;");
            _productionsqlConnection = new SqlConnection(@"Data Source=SQL5036.SmarterASP.NET;Initial Catalog=DB_A27F66_epl;User Id=DB_A27F66_epl_admin;Password=asdf1234;");
            _connection = _productionsqlConnection;
            _connection.Open();
        }

        public List<Schedule> GetAllSchedule()
        {
            var sql = @"select t1.Id,Homeid,Awayid,HomeTeam,AwayTeam,stadium,HomeTeamCn,AwayTeamCn,Time,link,highlightlink,firsthalflink,secondhalflink from (
                        (select id, a.Homeid,a.Awayid,b.TeamName as HomeTeam,b.TeamStadium as stadium,b.TeamNameCN as HomeTeamcn, a.Time,a.link,a.highlightlink,a.firsthalflink,a.secondhalflink from schedule a join TeamInfo b on a.Homeid=b.TeamId) t1
                        left join
                        (select id, b.TeamName as AwayTeam,b.TeamNameCN as AwayTeamCn from schedule a join TeamInfo b on a.Awayid=b.TeamId) t2
                        on t1.id=t2.Id) order by time asc";
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
            var sql = @"delete from schedule where id =" + i;
            _connection.Execute(sql);
            _connection.Close();
        }

        public List<TvShow> GetAllTvShows()
        {
            var sql = @"select [Id] ,[Title],[ModifiedOn],[Episode],[Link],[Category] FROM [Tvshow]";
            return _connection.Query<TvShow>(sql).ToList();
        }
    }
}