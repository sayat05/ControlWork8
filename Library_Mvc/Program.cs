using System.Data;
using Library_Mvc.Interfaces;
using Library_Mvc.Repositories;
using Library_Mvc.Services;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDbConnection>(sp =>
    new NpgsqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ICategoryRepositories, CategoryRepository>();
builder.Services.AddScoped<IStatusBookRepository, StatusBookRepository>();
builder.Services.AddScoped<ILibraryUserRepository, LibraryUserRepository>();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();