using Back_End.Data;
using Back_End.Interfaces;
using Back_End.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});
builder.Services.AddScoped<IpersonRepository, PersonRepository>();

//added cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("https://myapp-front.thankfulbush-6e078cc6.northeurope.azurecontainerapps.io")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});
//containerized
//"http://localhost:8080"

//azure
//https://myapp-front.thankfulbush-6e078cc6.northeurope.azurecontainerapps.io/

var app = builder.Build();

// Apply migrations and create database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDBContext>();
        context.Database.Migrate();
        Console.WriteLine("Database migrated successfully2.");
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating or initializing the database.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//cors
app.UseCors();

//alternate methode-allows all to comsume api
//app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed(origin => true));

app.UseAuthorization();

app.MapControllers();

app.Run();
