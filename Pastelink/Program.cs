using Application;
using Application.Features.Command.AppUserCommand.CreateAppUser;
using MediatR;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Persistance;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System.Diagnostics;
using System;
using System.Globalization;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using static Serilog.Sinks.MSSqlServer.ColumnOptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistenceService();
builder.Services.AddApplication();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateAppUserHandler).Assembly));
builder.Services.AddControllers();

string CORSOpenPolicy = "OpenCORSPolicy";

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(
      name: CORSOpenPolicy,
      builder => {
          builder.AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed(origin => true);
      });
});

var columnOptions = new ColumnOptions();
columnOptions.Store.Remove(StandardColumn.Properties);

Logger Log = new LoggerConfiguration().Enrich.FromLogContext().
    WriteTo.MSSqlServer(builder.Configuration["ConnectionStrings:MSSql"],
    new MSSqlServerSinkOptions { AutoCreateSqlTable=true,TableName="Logs"},null,null,LogEventLevel.Information,null,
    columnOptions: columnOptions, null,null).MinimumLevel.Information().CreateLogger();


builder.Host.UseSerilog(Log);
builder.Services.AddAuthorization(options => options.AddPolicy("AdminRequired", policy => policy.RequireRole("Admin")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer("admin",
    options => options.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidAudience = builder.Configuration["Token:Audience"],
        ValidIssuer = builder.Configuration["Token:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:IssuerSigningKey"])),
        NameClaimType = ClaimTypes.Name,
    }); ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseStaticFiles();

app.UseRouting();
//UseCors must be placed after "UseRouting", but before "UseAuthorization"

app.UseCors(CORSOpenPolicy);


app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.Use(async (context, next) =>
{
    /*context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
    context.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");*/
    if (context.Request.Method == "OPTIONS")
    {
        context.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
        context.Response.StatusCode = 200;
        return;
    }
    await next();
});

app.Use(async (context, next) =>
{
    var user = context.User?.Identity?.IsAuthenticated!=null||true?context.User.Identity:null;
    await next();
}
);


app.MapControllers();

app.Run();
