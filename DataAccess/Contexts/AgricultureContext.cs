using Entity.Concrate;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts;

public class AgricultureContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-2QRUQ1N\\MSSQLSERVER01;Database=DbAgriculture;Integrated Security=True;TrustServerCertificate=True");
    }
    
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Announcements> Announcements { get; set; }
    public DbSet<Adress> Adresses { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Service> Service { get; set; }
    public DbSet<Image> Images { get; set; }
}