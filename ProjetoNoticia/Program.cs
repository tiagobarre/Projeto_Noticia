using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ProjetoNoticia.Repository.Interfaces;
using System.Configuration;
using ProjetoNoticia.Controllers;
using System.Security.Cryptography;
using ProjetoNoticia.Repository.Repositories;
using ProjetoNoticia.Infra.DAO;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProjetoNoticiaContext>();

builder.Services.AddDbContext<ProjetoNoticiaContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("db")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<INoticiaRepository, NoticiaRepository>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
var app = builder.Build();

//builder.Services.AddDbContext<ProjetoNoticiaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("db")));


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
