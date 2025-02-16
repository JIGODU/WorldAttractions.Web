using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WorldAttractionsExplorer.DataAccess;
using static WorldAttractionsExplorer.Services.ServiceCollection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ServerDbContext>
    (options => options.UseMySql(builder.Configuration.GetConnectionString("myconn")
        ,MySqlServerVersion.AutoDetect(builder.Configuration.GetConnectionString("myconn"))));

builder.Services.AddServiceCollection();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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