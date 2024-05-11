using System.Net;
using Microsoft.EntityFrameworkCore;
using TeamHost.Application;
using TeamHost.Infrastructure;
using TeamHost.Persistence;
using TeamHost.Persistence.Context;
using TeamHost.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EfContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Profile/Login";
});

builder.Services.AddInfrastructure();
builder.Services.AddPersistenceLayer();
builder.Services.AddApplicationLayer();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IDbSeeder>();
var migrator = scope.ServiceProvider.GetRequiredService<Migrator>();
await seeder.SeedAsync(new CancellationToken());
await migrator.MigrateAsync();
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

app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area=Home}/{controller=Home}/{action=Index}/{id?}");

app.Run();