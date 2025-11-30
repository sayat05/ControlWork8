using System.Data;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDbConnection, NpgsqlConnection>(
    _ => new NpgsqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}




app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Library}/{action=Index}/{id?}");

app.Run();