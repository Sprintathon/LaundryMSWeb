global using LibraryMSWeb.Components;
global using Microsoft.EntityFrameworkCore;
global using Data;
global using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Connection Configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if(string.IsNullOrEmpty(connectionString)){
    throw new Exception("Connection String is unvalid");
}
builder.Services.AddDbContext<ApplicationDatabaseContext>(
    options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
    );

builder.Services.AddScoped<ResourceService>();
builder.Services.AddScoped<VisitService>();
builder.Services.AddScoped<MemberService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
