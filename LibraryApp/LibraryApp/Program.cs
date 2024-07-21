using DataAccess.Interfaces;
using DataAccess.Repositories;
using DataModels.Models;
using Microsoft.Extensions.DependencyInjection;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
//take the Controller Uri for the http client service registration

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Error)
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Fatal)
    .Enrich.FromLogContext()
    .WriteTo.Console()
.CreateLogger();
builder.Host.UseSerilog();

// Add services to the container.
//register httpClient with address from appsettings
var localhost = configuration.GetSection("HttpClient").GetValue<string>("localhost");
builder.Services.AddHttpClient("BookController", client =>
{
    client.BaseAddress = new Uri(localhost);  
});

builder.Services.AddScoped<IBookRepo<Book>, BookRepo>();
builder.Services.AddSingleton<BogusBooks>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("OpenCorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddRazorPages();
builder.Services.AddControllers();



// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors("OpenCorsPolicy");

app.UseAuthorization();

app.MapRazorPages();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    

app.Run();
