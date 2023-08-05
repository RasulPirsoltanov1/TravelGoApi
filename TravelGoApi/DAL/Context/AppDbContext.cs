using Microsoft.EntityFrameworkCore;
using TravelGoApi.DAL.Entities;

namespace TravelGoApi.DAL.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-UGCLLOE\\MSSQLSERVER2;Database=TravelGoApiDB;integrated security=true;Encrypt=false;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Visitor> Visitors { get; set; }

    }
}
