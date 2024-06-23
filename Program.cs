using Application.Interface;
using Infrastructure.Data;
using Infrastructure.Implementaion.Repository;
using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Injecting the db context 
builder.Services.AddDbContext<ApplicationsDBcontext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("StudentPortal")));

builder.Services.AddScoped<IWebApplicationInterface, WebApplicationImplementation>();
builder.Services.AddScoped<IStudentMapper, StudentMapper>();

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
    pattern: "{controller=Students}/{action=Add}/{id?}");

app.Run();
