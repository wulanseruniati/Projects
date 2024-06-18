using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args); // buat builder 

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); //cari endpoint (ujung backend)
builder.Services.AddSwaggerGen(); //dokumentasi

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Mapper));
// Retrieve the connection string from configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<Database>(options => {
    options.UseNpgsql(connectionString);
});
builder.Services.AddScoped<CategoryModule>(); //kalau ada yang butuh category module dibikinin
builder.Services.AddCors(opt => {
    opt.AddPolicy("CorsPolicy", policyBuilder => {
        policyBuilder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:5173");
    });
});
var app = builder.Build(); //aplikasi sdh di-install, mulai akan dipakai

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) //jika dalam development
{
    app.UseSwagger(); //swagger nyala
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
//kalau udah release, ga akan nyala
app.UseHttpsRedirection(); //utk redirect dr http ke https

/*var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};//data
//bikin endpoint weatherforecast yang ngasih data random
app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast") //ngasih nama method
.WithOpenApi();
*/
app.MapControllers();
app.Run();

/*record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}*/
