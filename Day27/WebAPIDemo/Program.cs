using AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); // create builder 

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); // discover endpoints (backend)
builder.Services.AddSwaggerGen(); // documentation
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Mapper));

// Retrieve the connection string from configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<Database>(options => {
    options.UseNpgsql(connectionString);
});

var app = builder.Build(); // application is set up, ready to be used

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // if in development
{
    app.UseSwagger(); // enable Swagger
    app.UseSwaggerUI();
}

// if released, it won't be enabled
app.UseHttpsRedirection(); // redirect from http to https

app.MapControllers();
app.Run();
