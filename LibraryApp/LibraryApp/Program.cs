using DataAccess.Interfaces;
using DataAccess.Repositories;
using DataModels.Models;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("ConnectionString");


Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Error)
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Fatal)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog();
builder.Services.AddSingleton<IBookRepo<Book>,BookRepo>();
builder.Services.AddSingleton<BogusBooks>();
// Add services to the container.
builder.Services.AddControllersWithViews();


// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
    //(
    //name: "default",
    //pattern: "{controller=Home}/{action=Index}/{id?}"
    //);

app.Run();
