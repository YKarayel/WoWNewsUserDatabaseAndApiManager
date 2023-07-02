using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WoWNewsApi.Models;

namespace WoWNewsApi.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    CreatedDate = DateTime.Now.ToString(),
                    Email = "deneme@gmail.com",
                    Token = "weirjasdf1245pok",
                    Uid = "pwoefasöçdfm2123"

                },
                new User()
                {
                    Id = 2,
                    CreatedDate = DateTime.Now.ToString(),
                    Email = "deneme2@gmail.com",
                    Token = "sadfjwe",
                    Uid = "sdkfasdf"
                });
        }
    }
}
