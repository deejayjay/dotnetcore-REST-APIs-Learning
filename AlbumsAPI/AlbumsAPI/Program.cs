using AlbumsAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

// Create a CORS Policy
// Ref: https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-6.0#attr
builder.Services.AddCors(options =>
{
    options.AddPolicy("AlbumsCorsPolicy",
        policy =>
        {
            policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
}
);

builder.Services.AddControllers();

builder.Services.AddDbContext<AlbumContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("AlbumContext")));

// End of Add services to the container.


var app = builder.Build();

// Uses the seed initializer to seed the database
// Ref: https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/sql?view=aspnetcore-6.0&tabs=visual-studio#seed-the-database-2
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

// Enable the CORS middleware
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
