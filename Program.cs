using Microsoft.EntityFrameworkCore;
using WebUygulamaProje1.Models;
using WebUygulamaProje1.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Servislerin konteynerine eklemeler yap�l�r.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<UygulamaDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<UygulamaDbContext>()
                                                .AddDefaultTokenProviders();

builder.Services.AddRazorPages();

// DİKKAT: Yeni bir Repository s�n�f olu�turdu�unuzda mutlaka burada servislere eklemelisiniz
// _kitapTuruRepository nesnesinin olu�turulmas�n� sa�l�yor Dependency Injection mekanizmas�
builder.Services.AddScoped<IKitapTuruRepository, KitapTuruRepository>();
builder.Services.AddScoped<IKitapRepository, KitapRepository>();
builder.Services.AddScoped<IKiralamaRepository, KiralamaRepository>();
builder.Services.AddScoped<IEmailSender, EmailSender>();

var app = builder.Build();

// HTTP iste�i pipeline'�n� yap�land�rma.
if (!app.Environment.IsDevelopment())
{
    // Hata durumunda "/Home/Error" sayfas�na y�nlendirme yap�l�r.
    app.UseExceptionHandler("/Home/Error");

    // Varsay�lan HSTS de�eri 30 g�nd�r. �retim senaryolar� i�in bunu de�i�tirebilirsiniz.
    // Detayl� bilgi i�in: https://aka.ms/aspnetcore-hsts
    app.UseHsts();
}

app.UseHttpsRedirection(); // HTTP'den HTTPS'ye y�nlendirme yap�l�r.
app.UseStaticFiles(); // Statik dosyalar�n sunulmas� i�in kullan�l�r.

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Controller=Home, Action=Index, id=Null olan varsay�lan route.

app.Run();
