using Entity;
using Entity.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts;

public class AgricultureContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
{
    public AgricultureContext(DbContextOptions<AgricultureContext> options) : base(options)
    {
    }
    
    public AgricultureContext()
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-2QRUQ1N\\MSSQLSERVER01;Database=DbAgriculture;Integrated Security=True;TrustServerCertificate=True");
        }
    }
    
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Announcements> Announcements { get; set; }
    public DbSet<Adress> Adresses { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Service> Service { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<SocialMedia> SocialMedias { get; set; }
    public DbSet<Abaut> Abauts { get; set; }
}