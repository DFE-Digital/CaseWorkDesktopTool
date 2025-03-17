using CaseWorkDesktopTool.Domain.Interfaces.Repositories;
using CaseWorkDesktopTool.Infrastructure.Database;
using CaseWorkDesktopTool.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

var builder = WebApplication.CreateBuilder(args);

// Get the middleware for authentication
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme).AddMicrosoftIdentityWebApp(builder.Configuration);
var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

// Tell our controllers that we require authentication
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new AuthorizeFilter(policy));
});

// Tell our Razor pages that we want to use authentication
builder.Services.AddRazorPages()
    .AddMvcOptions(options =>
    {
        options.Filters.Add(new AuthorizeFilter(policy));
    })
    .AddMicrosoftIdentityUI();

// DbContexts setup
builder.Services.AddDbContext<AcademisationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AcademiesConnection") ?? throw new InvalidOperationException("Connection string 'AcademisationContext' not found.")));

builder.Services.AddScoped<IAcademisationRepository, AcademisationRepository>();


builder.Services.AddDbContext<SigChangeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SigChangeConnection") ?? throw new InvalidOperationException("Connection string 'SigChangeContext' not found.")));

builder.Services.AddScoped<ISigChangeRepository, SigChangeRepository>();

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

// We want to use the authentication setup above
app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
