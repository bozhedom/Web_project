using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;

var builder = WebApplication.CreateBuilder(args);
var environment = builder.Environment;
var services = builder.Services;

// Add services to the container.
services.AddControllersWithViews();

services.AddSpaStaticFiles(configuration => {
    configuration.RootPath = "client/build";
});

services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = new Microsoft.AspNetCore.Http.PathString("");
        });


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
app.UseSpaStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "client";

    if (environment.IsDevelopment())
    {
        spa.UseReactDevelopmentServer(npmScript: "start");
    }
});

app.Run();
