using Microsoft.EntityFrameworkCore;

using Proj_3.DAL;
using Proj_3.DAL.Interfaces;
using Proj_3.DAL.Repositories;
using Team.Service.Implementations;
using Team.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

//database configure
var connection_string = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connection_string));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<ITeamService, TeamService>();

var app = builder.Build();

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
