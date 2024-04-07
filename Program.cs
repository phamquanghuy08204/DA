using BTLONKY5.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BTLONKY5.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BTLONKY5Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BTLONKY5Context") ?? throw new InvalidOperationException("Connection string 'BTLONKY5Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("NhaHangDB");
builder.Services.AddDbContext<QLDBcontext>(options => options.UseSqlServer(connectionString));

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
