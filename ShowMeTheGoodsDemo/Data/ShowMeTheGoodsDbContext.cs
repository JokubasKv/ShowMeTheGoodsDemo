using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShowMeTheGoodsDemo.Auth.Model;
using ShowMeTheGoodsDemo.Data.Entities;

namespace ShowMeTheGoodsDemo.Data
{
    public class ShowMeTheGoodsDbContext : IdentityDbContext<SiteRestUser>
    {
        private readonly IConfiguration _configuration;

        public DbSet<EventType> EventsType { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ShowMeTheGoodsDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // string s = _configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
            optionsBuilder.UseSqlServer("Data Source = tcp:showmethegoodsdemodbserver.database.windows.net,1433; Initial Catalog = ShowMeTheGoodsDemo_db; User Id = jokkve@showmethegoodsdemodbserver; Password = Burokas456.");
        }
    }
}
//"Server=tcp:showmethegoodsdemodbserver.database.windows.net,1433;Initial Catalog=ShowMeTheGoodsDemo_db;Persist Security Info=False;User ID=jokkve;Password=Burokas456.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
//
//"Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=ShowMeTheGoodDb"
//Data Source=showmethegoodsdemodbserver.database.windows.net,1433;Initial Catalog=ShowMeTheGoodsDemo_db;User ID=jokkve;Password=Burokas456.