using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WorldAttractionsExplorer.DataAccess;
using WorldAttractionsExplorer.DataAccess.Models;
using static WorldAttractionsExplorer.Services.ServiceCollection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ServerDbContext>
    (options => options.UseMySql(builder.Configuration.GetConnectionString("myconn")
        ,ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("myconn"))));

builder.Services.AddServiceCollection();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentity<Users, IdentityRole>()
    .AddEntityFrameworkStores<ServerDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Key").ToString())),
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").ToString(),
            ValidateAudience = true,
            ValidAudience = builder.Configuration.GetSection("Jwt:Audience").ToString(),
            ValidateLifetime = true
        };
    });

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"))
    .AddPolicy("GuideOrAbove", policy => policy.RequireRole("Admin","Guide"))
    .AddPolicy("UserOrAbove", policy => policy.RequireRole("Admin","Guide","User"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.UseHttpsRedirection();



app.Run();