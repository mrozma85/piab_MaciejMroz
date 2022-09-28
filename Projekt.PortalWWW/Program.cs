using Microsoft.EntityFrameworkCore;
using Projekt.Data.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProjektContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjektContext")));

// Add services to the container.
builder.Services.AddControllersWithViews();

//START
builder.Services.AddSession(options =>
{
    // Set a short timeout for easy testing.
    options.IdleTimeout = TimeSpan.FromSeconds(40);
    options.Cookie.HttpOnly = true;
    // Make the session cookie essential
    options.Cookie.IsEssential = true;
});
//STOP

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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
