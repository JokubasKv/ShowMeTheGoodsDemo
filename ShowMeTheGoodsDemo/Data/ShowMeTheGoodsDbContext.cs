using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
            optionsBuilder.UseNpgsql("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=ShowMeTheGoodDb");
        }
    }
}
