using CrudJuegos.Data;
using CrudJuegos.Helpers;
using CrudJuegos.Providers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Agregamos el servicio de Mysql
builder.Services.AddDbContext<VideoJuegosContext> (options => options.UseMySql(
builder.Configuration.GetConnectionString("MySqlConnection"),
Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")));
//Agregamos los servicios de providers y helpers para hacer uso de las funciones
builder.Services.AddSingleton<PathProvider>();
builder.Services.AddSingleton<HelperUploadFiles>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
