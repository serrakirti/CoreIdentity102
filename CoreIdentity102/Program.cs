using CoreIdentity102.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/*1*/
builder.Services.AddDbContext<AppIdentityDbContex>(options =>//Scopesuz yaz�m�
options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConStr")));
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppIdentityDbContex>();//Bu proje �al��t��� s�rece arkada gizli bir haf�z ile tutuluyor. Projenin her yerinde bunu her yerden �ekebilirim.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();//Oturuma Giri� ��k�� i�lemlerinin kontrol edilmesini istiyoruz bu y�zden yaz�yoruz.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
