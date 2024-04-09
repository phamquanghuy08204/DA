using BTLONKY5.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<QLDBcontext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NhaHangDB") ?? throw new InvalidOperationException("Connection string 'NhaHangDB' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure the database context
var connectionString = builder.Configuration.GetConnectionString("NhaHangDB");
builder.Services.AddDbContext<QLDBcontext>(options => options.UseSqlServer(connectionString));

// Configure session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(60);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
