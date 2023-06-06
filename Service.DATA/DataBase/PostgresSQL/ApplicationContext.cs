using Microsoft.EntityFrameworkCore;
using Service.DATA.Model;

namespace Service.DATA.DataBase.PostgresSQL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Candidates> Candidates { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MO_Candidate;Username=postgres;Password=22111964");
        }
    }
}
