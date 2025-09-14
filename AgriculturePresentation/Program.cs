using DataAccess.Contexts;
using Entity.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AgriculturePresentation.Models;
using Business.Abstract;
using Business.Concrate;
using DataAccess.Abstract;
using DataAccess.Concrate.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    // Tüm Controller'lar için giriş zorunlu
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});

// Veritabanı Konfigürasyonu
builder.Services.AddDbContext<AgricultureContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity Konfigürasyonu
builder.Services.AddIdentity<AppUser, IdentityRole<int>>(options =>
{
    // Şifre Ayarları
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    
    // Kullanıcı Ayarları
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<AgricultureContext>()
.AddDefaultTokenProviders();

builder.Services.AddScoped<IServiceService, ServicesManager>();
builder.Services.AddScoped<IServiceDal, EfServiceDal>();
builder.Services.AddScoped<IAnnouncementsService, AnnouncementsManager>();
builder.Services.AddScoped<IAnnouncementsDal, EfAnnouncementDal>();
builder.Services.AddScoped<IImagesService, ImageManager>();
builder.Services.AddScoped<IImageDal, EfImageDal>();
builder.Services.AddScoped<IAddressService, AddressManager>();
builder.Services.AddScoped<IAdressDal, EfAdressDal>();
builder.Services.AddScoped<ITeamService, TeamManager>();
builder.Services.AddScoped<ITeamDal, EfTeamDal>(); 
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();
builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
builder.Services.AddScoped<IAbautService, AbautManager>();
builder.Services.AddScoped<IAbautDal, EfAbautDal>();

builder.Services.AddDbContext<AgricultureContext>();


// Çerez Kimlik Doğrulama Ayarları
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login/Index";
    options.ExpireTimeSpan = TimeSpan.FromDays(30); // 30 gün hatırla
    options.SlidingExpiration = true;
});

// Varsayılan kullanıcı ayarlarını yapılandır
builder.Services.Configure<DefaultUserSettings>(
    builder.Configuration.GetSection("DefaultUser"));

var app = builder.Build();

// HTTP İstek Pipeline'ını Yapılandır
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();  // Kimlik doğrulama
app.UseRouting();
app.UseAuthorization();   // Yetkilendirme

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

// Varsayılan Kullanıcı Oluştur
await VarsayilanKullaniciOlustur(app);

app.Run();

// Varsayılan Kullanıcı Oluşturma Metodu
async Task VarsayilanKullaniciOlustur(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
    
    var defaultUserSettings = new DefaultUserSettings();
    configuration.GetSection("DefaultUser").Bind(defaultUserSettings);
    
    if (!defaultUserSettings.CreateOnStartup)
    {
        Console.WriteLine("ℹ️ Varsayılan kullanıcı oluşturma devre dışı");
        return;
    }
    
    var mevcutKullanici = await userManager.FindByNameAsync(defaultUserSettings.Username);
    if (mevcutKullanici != null)
    {
        Console.WriteLine($"ℹ️ '{defaultUserSettings.Username}' kullanıcısı zaten mevcut");
        return;
    }
    
    var yeniKullanici = new AppUser
    {
        UserName = defaultUserSettings.Username,
        Email = defaultUserSettings.Email,
        EmailConfirmed = true
    };
    
    var sonuc = await userManager.CreateAsync(yeniKullanici, defaultUserSettings.Password);
    
    if (sonuc.Succeeded)
    {
        Console.WriteLine("✅ Varsayılan kullanıcı başarıyla oluşturuldu!");
        Console.WriteLine($"👤 Kullanıcı Adı: {defaultUserSettings.Username}");
        Console.WriteLine($"📧 E-posta: {defaultUserSettings.Email}");
    }
    else
    {
        Console.WriteLine("❌ Kullanıcı oluşturulurken hatalar:");
        foreach (var hata in sonuc.Errors)
        {
            Console.WriteLine($"- {hata.Description}");
        }
    }
}