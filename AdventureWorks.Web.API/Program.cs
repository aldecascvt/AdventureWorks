using Microsoft.Extensions.Configuration;
using AdventureWorks.NetCore.Repository;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MoDbContext");

// Add services to the container.

//var connectionString = Configuration.GetConnectionString(nameof (MoDbContext));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
           c.SwaggerDoc("v1",
               new Microsoft.OpenApi.Models.OpenApiInfo { Title = "AdventureWorks.Web.API", Version = "v1" }));

builder.Services.AddDbContext<MoDbContext>(options => options.UseSqlServer(@"Data Source=DESKTOP-483RUS1\SQLDEV;Integrated Security=SSPI;Initial Catalog=AdventureWorks2019;"));
builder.Services.AddScoped<MoDbContext, MoDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}   

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
